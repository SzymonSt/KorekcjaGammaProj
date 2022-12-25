﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KorekcjaGamma
{
    public class ImagePixel {
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
    public partial class Form1 : Form
    {
        AssemblerInterface asm;
        private int threadCount;
        private Bitmap imageBitmap;
        private static byte[] finalImageBytes;
        public Form1()
        {
            InitializeComponent();
            threadCount = Environment.ProcessorCount;
            asm = new AssemblerInterface();
        }

        private Bitmap loadImage(String imagePath) {
            //TODO catch file not found exception
            return new Bitmap(imagePath);
        }

        private List<ImagePixel[]> splitBytesForMultipleThreads(Bitmap imageBitmap, int threadCount) {
            List<ImagePixel[]> splittedImageBitmap = new List<ImagePixel[]>(threadCount);
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
                i++;
            }

            int fullStop = 0;
            int ln = 0;
            for (int p=0; p < threadCount; p++) {
                if (rValue > 0)
                {
                    ln = (int)(totalPixelCount / threadCount) + 1;
                    splittedImageBitmap[p] = new ImagePixel[ln];
                    rValue--;
                }
                else {
                    ln = (int)totalPixelCount / threadCount;
                    splittedImageBitmap[p] = new ImagePixel[ln];
                }
                Array.Copy(imagePixels, fullStop, splittedImageBitmap[p], 0, ln);
                fullStop = ln + 1;
            }

            return splittedImageBitmap;
        }

        private void SpawnThreads(List<ImagePixel[]> splittedImageBitmap, int threadCount) {
            ThreadPool.SetMinThreads(threadCount, threadCount);
            ThreadPool.SetMaxThreads(threadCount, threadCount);
            byte[] x;
            for (int i=0; i<threadCount; i++) {
                ThreadPool.QueueUserWorkItem(new WaitCallback(delegate (Object state) {
                    x = GammaThingWhatever(splittedImageBitmap[i]);
                }), null);
            }
        }

        private static byte[] GammaThingWhatever(ImagePixel[] pxSlice) {
            //option one - edit global variable (each thread will lock it for execution time)
            //dont know how it will influence performance(possible deadlock) 
            lock (finalImageBytes) { 
                
            }

            //option two - return whatever ASM lib returns
            //we would need to wait for each thread, not sure about possible consequnces
            return new byte[1];
        }

        //sample code
        private void button1_Click(object sender, EventArgs e)
        {
            int wynik = asm.executeAsmProcLicz();
            DialogResult result = MessageBox.Show(wynik.ToString(),"Test", MessageBoxButtons.OK);
        }
        //---
    }
}
