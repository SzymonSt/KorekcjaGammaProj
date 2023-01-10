using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace KorekcjaGamma
{
    public partial class Form1 : Form
    {
        AssemblerInterface asm;
        private int threadCount;
        private Bitmap imageBitmap;
        private static byte[] finalImageBytes;
        List<ImagePixel[]> splittedImageBitmapResult;

        //tmp
        String tmpFilePath = "C:\\Users\\Milosz\\Downloads\\example.jpg";
        public Form1()
        {
            InitializeComponent();
            threadCount = Environment.ProcessorCount;
            asm = new AssemblerInterface();
            splittedImageBitmapResult = splitBytesForMultipleThreads(loadImage(tmpFilePath), threadCount);
            splittedImageBitmapResult.ForEach(imagePxs => {
                Console.WriteLine(imagePxs[0].B);
            });
            spawnThreads(splittedImageBitmapResult, threadCount);
        }

        private Bitmap loadImage(String imagePath) {
            //TODO catch file not found exception
            return new Bitmap(imagePath);
        }

        private List<ImagePixel[]> splitBytesForMultipleThreads(Bitmap imageBitmap, int threadCount) {
            List<ImagePixel[]> splittedImageBitmap = new List<ImagePixel[]>();
            int totalPixelCount = imageBitmap.Width * imageBitmap.Height;
            int rValue = totalPixelCount % threadCount;
            ImagePixel[] imagePixels = new ImagePixel[totalPixelCount];
            int i = 0;
            for (int x=0; x < imageBitmap.Width; x++) {
                for (int y = 0; y < imageBitmap.Height; y++) {
                    Color originalPixel = imageBitmap.GetPixel(x, y);
                    imagePixels[i] = new ImagePixel(originalPixel.R, originalPixel.G,
                                                        originalPixel.B, originalPixel.A);
                    i++;
                }
            }

            int fullStop = 0;
            int ln = 0;
            for (int p=0; p < threadCount; p++) {
                if (rValue > 0)
                {
                    ln = (int)(totalPixelCount / threadCount) + 1;
                    splittedImageBitmap.Add(new ImagePixel[ln]);
                    rValue--;
                }
                else {
                    ln = (int)totalPixelCount / threadCount;
                    splittedImageBitmap.Add(new ImagePixel[ln]);
                }
                Array.Copy(imagePixels, fullStop, splittedImageBitmap[p], 0, ln);
                fullStop = ln + 1;
            }

            return splittedImageBitmap;
        }

        private void spawnThreads(List<ImagePixel[]> splittedImageBitmap, int threadCount) {
            ThreadPool.SetMinThreads(threadCount, threadCount);
            ThreadPool.SetMaxThreads(threadCount, threadCount);
            byte[] x;
            for (int i=0; i<threadCount; i++) {
                var splittedTmp = splittedImageBitmap[i];
                ThreadPool.QueueUserWorkItem(new WaitCallback(delegate (Object state) {
                    GammaThingWhatever(splittedTmp);
                }), null);
            }
        }

        private static void GammaThingWhatever(ImagePixel[] pxSlice) {
            //option ONE - edit global variable (each thread will lock it for execution time)
            //dont know how it will influence performance(possible deadlock) 
            //lock (finalImageBytes) { 
            //    
            //}

            //option TWO - return whatever ASM lib returns
            //we would need to wait for each thread, not sure about possible consequnces
            //return new byte[1];

            //tmp
            Console.WriteLine("Thread nr. {0}", Thread.CurrentThread.ManagedThreadId);
            //to test upperbound of threads
            Thread.Sleep(1000);
        }

        private void saveFinalToFile(byte[] data, string filePath) {
            BinaryWriter writer = new BinaryWriter(File.OpenWrite(filePath));
            writer.Write(data);
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
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

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
                    saveBtn.Enabled = true;
                    asmBtn.Enabled = true;
                    csharpBtn.Enabled = true;
                }
                catch (IOException)
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
            threadCount = (int)Math.Pow(2, threadSlider.Value);
        }
        //---
    }
    public class ImagePixel
    {
        public byte R { get; private set; }
        public byte G { get; private set; }
        public byte B { get; private set; }
        public byte A { get; private set; }

        public ImagePixel(byte R, byte G, byte B, byte alpha)
        {
            this.R = R;
            this.G = G;
            this.B = B;
            this.A = alpha;
        }
    }
}
