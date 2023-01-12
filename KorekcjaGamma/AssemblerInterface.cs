using System;
using System.Runtime.InteropServices;

namespace KorekcjaGamma
{
    unsafe class AssemblerInterface
    {
        [DllImport("BibliotekaASM.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int gen_lut();

/*        [DllImport("BibliotekaASM.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int licz();*/

        public static int[] GenerateLutTable(double gammaValue) {
            int test = gen_lut();
            IntPtr address = (IntPtr)test; // the address you want to access
            var value = Marshal.ReadInt32(address);
            Console.WriteLine(value);
            return new int[1];
        }

        public static void PerformGammaCorrection(byte[] orginalImagePart, int[] luTable) { 
            
        }
    }
}
