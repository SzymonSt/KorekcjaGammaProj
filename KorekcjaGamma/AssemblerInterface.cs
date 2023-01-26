using System;
using System.Runtime.InteropServices;

namespace KorekcjaGamma
{
    unsafe class AssemblerInterface
    {

        [DllImport("BibliotekaASM.dll")]
        public static unsafe extern int gamma_correction(int* r, int* g, int* b, int* r_l, int* g_l, int* b_l);

        public static int[] GenerateLutTable(double gammaValue)
        {
            unsafe
            {
                //IntPtr lookupTableAddress = gen_lut();
                //float[] t = new float[256];
                //float* lookupTable = (float*)lookupTableAddress;
                //Marshal.Copy(lookupTableAddress, t, 0, 256);
                return new int[1];
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
