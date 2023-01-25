using System;
using System.Runtime.InteropServices;

namespace KorekcjaGamma
{
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct StructToAssembler
    {
        public int r;
        public int g;
    }
    unsafe class AssemblerInterface
    {
        public static StructToAssembler struktura = new StructToAssembler();
        static public int[] aArg1 = { 0, 0, 0, 0 };

        [DllImport("BibliotekaASM.dll")]
        public static unsafe extern StructToAssembler gamma_correction(StructToAssembler* x);

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
            unsafe
            {
                for (int i = 0; i < orginalImagePart.Length; i += 4)
                {
                    struktura.r = orginalImagePart[i];
                    struktura.g = orginalImagePart[i + 1];
                    fixed (StructToAssembler* x = &struktura)
                    {
                        Console.WriteLine(orginalImagePart[i]);
                        Console.WriteLine(orginalImagePart[i + 1]);
                        Console.WriteLine(orginalImagePart[i + 2]);
                        Console.WriteLine(orginalImagePart[i + 3]);
                        Console.WriteLine("-------------");
                        //StructToAssembler y = new StructToAssembler();
                        gamma_correction(x);
                        Console.WriteLine("After processing:");
                        Console.WriteLine("D" + struktura.r);
                        Console.WriteLine("D" + struktura.g);

                    }
                }
            }
        }
    }
}
