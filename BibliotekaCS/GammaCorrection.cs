﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotekaCS
{
    public static class GammaCorrection
    {
        public static int[] GenerateLutTable(double gammaValue) {
            int[] luTable = new int[256];
            for (int i = 0; i < 256; i++) {
                int luValue = (int)Math.Floor(255 * Math.Pow((double)(i / 255.0), 1 / gammaValue));
                if (luValue > 255)
                    luValue = 255;
                luTable[i] = luValue;
            }
            return luTable;
        }

        public static void PerformGammaCorrection(byte[] orginalImagePart, int[] luTable) {
            int w = 0;
            while(w < orginalImagePart.Length) {
                orginalImagePart[w] = (byte)(luTable[orginalImagePart[w]]);
                w++;
                orginalImagePart[w] = (byte)(luTable[orginalImagePart[w]]);
                w++;
                orginalImagePart[w] = (byte)(luTable[orginalImagePart[w]]);
                w++;
                orginalImagePart[w] = 255;
                w++;
            }
        }
    }

    public class ImagePixel
    {
        public byte R { get; set; }
        public byte G { get; set; }
        public byte B { get; set; }
        public byte A { get; set; }

        public ImagePixel(byte R, byte G, byte B, byte alpha)
        {
            this.R = R;
            this.G = G;
            this.B = B;
            this.A = alpha;
        }
    }
}
