using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KorekcjaGamma
{
    public partial class Form1 : Form
    {
        AssemblerInterface asm;
        public Form1()
        {
            InitializeComponent();
            asm = new AssemblerInterface();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int wynik = asm.executeAsmProcLicz();
            DialogResult result = MessageBox.Show(wynik.ToString(),"Test", MessageBoxButtons.OK);
        }
    }
}
