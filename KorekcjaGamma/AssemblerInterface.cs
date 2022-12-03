using System.Runtime.InteropServices;

namespace KorekcjaGamma
{
    unsafe class AssemblerInterface
    {
        [DllImport("BibliotekaASM.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int licz();

        public int executeAsmProcLicz()
        {
            return licz();
        }
    }
}
