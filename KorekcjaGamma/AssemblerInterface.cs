using System;
using System.Runtime.InteropServices;

namespace KorekcjaGamma
{
    unsafe class AssemblerInterface
    {

        [DllImport("BibliotekaASM.dll")]
        public static unsafe extern int gamma_correction(int* r, int* g, int* b, int* r_l, int* g_l, int* b_l);
        [DllImport("BibliotekaASM.dll")]
        public static unsafe extern int gen_lut(float* gamma_value, float* lut);

        public static int[] GenerateLutTable(double gammaValue)
        {
            unsafe
            {
                int[] luTable = new int[256];
                fixed (int* lut = luTable)
                {
                    float tmpGamma = (1.0f / (float)gammaValue);
                    float e;
                    for (int i = 0; i < luTable.Length; i++)
                    {
                        e = (float)((float)i/255.0f);
                        gen_lut(&tmpGamma, &e);
                        if (e > 255)
                        {
                            e = 255;
                        }
                        if (((int)e) < 0)
                        {
                            e = 0;
                        }
                        lut[i] = (int)e;
                    }
                }
                return luTable;
            }
        }

        public static void PerformGammaCorrection(byte[] orginalImagePart, int[] luTable)
        {
            int r = new int();
            int g = new int();
            int b = new int();
            int r_l = new int();
            int g_l = new int();
            int b_l = new int();
            for (int i = 0; i < orginalImagePart.Length; i += 4)
            {
                r = orginalImagePart[i];
                g = orginalImagePart[i + 1];
                b = orginalImagePart[i + 2];
                r_l = luTable[(int)orginalImagePart[i]];
                g_l = luTable[(int)orginalImagePart[i + 1]];
                b_l = luTable[(int)orginalImagePart[i + 2]];
                gamma_correction(&r, &g, &b, &r_l, &g_l, &b_l);
                orginalImagePart[i] = (byte)r;
                orginalImagePart[i + 1] = (byte)g;
                orginalImagePart[i + 2] = (byte)b;
            }
        }
    }
}
