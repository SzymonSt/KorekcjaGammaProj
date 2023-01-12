using System;
using System.Runtime.InteropServices;

namespace KorekcjaGamma
{
    unsafe class AssemblerInterface
    {
        [DllImport("BibliotekaASM.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr gen_lut();

/*        [DllImport("BibliotekaASM.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int licz();*/

        public static int[] GenerateLutTable(double gammaValue) {
            unsafe
            {
                IntPtr lookupTableAddress = gen_lut();
                float[] t = new float[256];
                //float* lookupTable = (float*)lookupTableAddress;
                Marshal.Copy(lookupTableAddress, t, 0, 256);
                return new int[1];
            }
        }

        public static void PerformGammaCorrection(byte[] orginalImagePart, int[] luTable) { 
            
        }
    }
}
