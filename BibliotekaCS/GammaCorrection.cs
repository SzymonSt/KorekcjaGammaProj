using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotekaCS
{
    public static class GammaCorrection
    {
        public static int[] GenerateLutTable(int gammaValue) {
            int[] luTable = new int[256];
            for (int i = 0; i < 256; i++) {
                int luValue = (int)Math.Floor(255 * Math.Pow(i / 255.0, 1 / gammaValue));
                if (luValue > 255)
                    luValue = 255;
                luTable[i] = luValue;
            }
            return luTable;
        }

        public static void PerformGammaCorrection(ImagePixel[] orginalImagePart, int[] luTable) {
            for (int w = 0; w < orginalImagePart.Length; w++) {
                orginalImagePart[w].A = 255;
                orginalImagePart[w].R = (byte)luTable[orginalImagePart[w].R];
                orginalImagePart[w].G = (byte)luTable[orginalImagePart[w].G];
                orginalImagePart[w].B = (byte)luTable[orginalImagePart[w].B];
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
