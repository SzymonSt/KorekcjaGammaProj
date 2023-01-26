using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using BibliotekaCS;

namespace KorekcjaGamma
{
    public partial class Form1 : Form
    {
        AssemblerInterface asm;
        private int threadCount;
        private double gammaValue = 2.2;
        private int totalPixelCount;
        Bitmap imgBitmap;
        byte[] imageBytes;
        List<byte[]> splittedImageBitmapResult;
        public Form1()
        {
            InitializeComponent();
            threadCount = Environment.ProcessorCount;
            threadSlider.Value = threadCount;
            threadLabel.Text = threadCount.ToString();
            asm = new AssemblerInterface();
        }

        private List<byte[]> splitBytesForMultipleThreads(Image imageBitmap, int threadCount) {
            List<byte[]> splittedImageBitmap = new List<byte[]>();
            imageBytes = GetImagePixelBytes(imgBitmap);
            totalPixelCount = imageBytes.Length / 4;
            int rValue = (totalPixelCount) % threadCount;
            int fullStop = 0;
            int ln;
            for (int p = 0; p < threadCount; p++)
            {
                if (rValue > 0)
                {
                    ln = (int)((totalPixelCount / threadCount) + 1)*4;
                    splittedImageBitmap.Add(new byte[ln]);
                    rValue--;
                }
                else
                {
                    ln = (int)(totalPixelCount / threadCount)*4;
                    splittedImageBitmap.Add(new byte[ln]);
                }
                Array.Copy(imageBytes, fullStop, splittedImageBitmap[p], 0, ln);
                fullStop += ln;
            }
            return splittedImageBitmap;
        }
        private byte[] GetImagePixelBytes(Bitmap imageBitmap) {
            BitmapData bitmapData = imageBitmap.LockBits(new Rectangle(0, 0, imageBitmap.Width, imageBitmap.Height),
                System.Drawing.Imaging.ImageLockMode.ReadWrite, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            int rawDataLength = bitmapData.Stride * bitmapData.Height;
            Console.WriteLine(rawDataLength);
            byte[] imagePixelRawData = new byte[rawDataLength];
            Marshal.Copy(bitmapData.Scan0, imagePixelRawData, 0, rawDataLength);
            imageBitmap.UnlockBits(bitmapData);
            return imagePixelRawData;
        }

        private void spawnThreadsForCSLib(List<byte[]> splittedImageBitmap,int[] luTable ,int threadCount) {
            ThreadPool.SetMinThreads(threadCount, threadCount);
            ThreadPool.SetMaxThreads(threadCount, threadCount);
            var list = new List<int>(threadCount);
            for (var i = 0; i < threadCount; i++) list.Add(i);
            using (CountdownEvent calcEvent = new CountdownEvent(threadCount))
            {
                for (var i = 0; i < threadCount; i++)
                {
                    ThreadPool.QueueUserWorkItem(x =>
                    {
                        GammaCorrection.PerformGammaCorrection(splittedImageBitmap[int.Parse(x.ToString())], luTable);
                        calcEvent.Signal();
                    }, list[i]);
                }
                calcEvent.Wait();
                Console.WriteLine(calcEvent.CurrentCount);
            }

        }

        private void saveFinalToTmpBitmap(List<byte[]> data) {
            byte[] resultBytes = new byte[imageBytes.Length];
            int fullStop = 0;
            data.ForEach(new Action<byte[]>(a => {
                Array.Copy(a, 0, resultBytes, fullStop, a.Length);
                fullStop += a.Length; 
            }));
            Console.WriteLine(resultBytes.Length);
            BitmapData resData = imgBitmap.LockBits(new Rectangle(0, 0, imgBitmap.Width, imgBitmap.Height),
                    ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);
            int bytes = resData.Stride * resData.Height;
            Marshal.Copy(resultBytes, 0, resData.Scan0, bytes);
            imgBitmap.UnlockBits(resData);
        }

        //sample code
        private void asmBtn_Click(object sender, EventArgs e)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            int wynik = asm.executeAsmProcLicz();
            DialogResult result = MessageBox.Show(wynik.ToString(),"Test", MessageBoxButtons.OK);

            stopwatch.Stop();
            asmTimeLabel.Text = stopwatch.ElapsedMilliseconds + "ms";
        }

        private void csharpBtn_Click(object sender, EventArgs e)
        {
            Console.WriteLine("threads: "+threadCount);
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            splittedImageBitmapResult = splitBytesForMultipleThreads(originalImg.Image, threadCount);
            int[] luTable = GammaCorrection.GenerateLutTable(2.2);
            spawnThreadsForCSLib(splittedImageBitmapResult, luTable, threadCount);
            Console.WriteLine("Done processing");
            saveFinalToTmpBitmap(splittedImageBitmapResult);
            finalImg.Image = imgBitmap;
            stopwatch.Stop();
            csharpTimeLabel.Text = stopwatch.ElapsedMilliseconds + "ms";
        }
        private void fileChooserBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "jpg files(.*jpg)|*.jpg| PNG files(.*png)|*.png| All Files(*.*)|*.*";
            DialogResult result = dialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                string imgLocation = dialog.FileName;
                try
                {
                    originalImg.ImageLocation = imgLocation;
                    imgBitmap = new Bitmap(imgLocation);
                    saveBtn.Enabled = true;
                    asmBtn.Enabled = true;
                    csharpBtn.Enabled = true;
                }
                catch (Exception)
                {
                    MessageBox.Show("Wystapił błąd podczas wczytywania pliku.");
                }
            }
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog() { Filter = @"PNG|*.png" })
            {
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    finalImg.Image.Save(saveFileDialog.FileName);
                    MessageBox.Show("Zdjęcie zostało pomyślnie zapisane.");
                }
            }
        }

        private void threadSlider_Scroll(object sender, EventArgs e)
        {
            threadCount = threadSlider.Value;
            threadLabel.Text = threadCount.ToString();
        }

        private void gammaInput_ValueChanged(object sender, EventArgs e)
        {
            double gamma;

            if (gammaInput.Value < 0)
            {
                gamma = 0.00;
            }
            else if (gammaInput.Value > 4)
            {
                gamma = 4.00;
            }
            else
            {
                gamma = (double)gammaInput.Value;
            }

            gammaValue = gamma;
            gammaInput.Text = gamma.ToString();
        }
        //---
    }
}
