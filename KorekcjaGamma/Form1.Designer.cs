
namespace KorekcjaGamma
{
    partial class Form1
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.asmBtn = new System.Windows.Forms.Button();
            this.saveBtn = new System.Windows.Forms.Button();
            this.fileChooserBtn = new System.Windows.Forms.Button();
            this.csharpBtn = new System.Windows.Forms.Button();
            this.threadSlider = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.originalImg = new System.Windows.Forms.PictureBox();
            this.finalImg = new System.Windows.Forms.PictureBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.asmTimeLabel = new System.Windows.Forms.Label();
            this.csharpTimeLabel = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.gammaInput = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.threadSlider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.originalImg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.finalImg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gammaInput)).BeginInit();
            this.SuspendLayout();
            // 
            // asmBtn
            // 
            this.asmBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            resources.ApplyResources(this.asmBtn, "asmBtn");
            this.asmBtn.Name = "asmBtn";
            this.asmBtn.UseVisualStyleBackColor = true;
            this.asmBtn.Click += new System.EventHandler(this.asmBtn_Click);
            // 
            // saveBtn
            // 
            this.saveBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            resources.ApplyResources(this.saveBtn, "saveBtn");
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // fileChooserBtn
            // 
            this.fileChooserBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            resources.ApplyResources(this.fileChooserBtn, "fileChooserBtn");
            this.fileChooserBtn.Name = "fileChooserBtn";
            this.fileChooserBtn.UseVisualStyleBackColor = true;
            this.fileChooserBtn.Click += new System.EventHandler(this.fileChooserBtn_Click);
            // 
            // csharpBtn
            // 
            this.csharpBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            resources.ApplyResources(this.csharpBtn, "csharpBtn");
            this.csharpBtn.Name = "csharpBtn";
            this.csharpBtn.UseVisualStyleBackColor = true;
            this.csharpBtn.Click += new System.EventHandler(this.csharpBtn_Click);
            // 
            // threadSlider
            // 
            this.threadSlider.Cursor = System.Windows.Forms.Cursors.Hand;
            this.threadSlider.LargeChange = 2;
            resources.ApplyResources(this.threadSlider, "threadSlider");
            this.threadSlider.Maximum = 6;
            this.threadSlider.Name = "threadSlider";
            this.threadSlider.Value = 1;
            this.threadSlider.Scroll += new System.EventHandler(this.threadSlider_Scroll);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Name = "label2";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Name = "label3";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Name = "label4";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Name = "label5";
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Name = "label6";
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Name = "label7";
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Name = "label8";
            // 
            // originalImg
            // 
            resources.ApplyResources(this.originalImg, "originalImg");
            this.originalImg.Name = "originalImg";
            this.originalImg.TabStop = false;
            // 
            // finalImg
            // 
            resources.ApplyResources(this.finalImg, "finalImg");
            this.finalImg.Name = "finalImg";
            this.finalImg.TabStop = false;
            // 
            // label9
            // 
            resources.ApplyResources(this.label9, "label9");
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Name = "label9";
            // 
            // label10
            // 
            resources.ApplyResources(this.label10, "label10");
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Name = "label10";
            // 
            // asmTimeLabel
            // 
            resources.ApplyResources(this.asmTimeLabel, "asmTimeLabel");
            this.asmTimeLabel.ForeColor = System.Drawing.Color.White;
            this.asmTimeLabel.Name = "asmTimeLabel";
            // 
            // csharpTimeLabel
            // 
            resources.ApplyResources(this.csharpTimeLabel, "csharpTimeLabel");
            this.csharpTimeLabel.ForeColor = System.Drawing.Color.White;
            this.csharpTimeLabel.Name = "csharpTimeLabel";
            // 
            // label11
            // 
            resources.ApplyResources(this.label11, "label11");
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Name = "label11";
            // 
            // gammaInput
            // 
            this.gammaInput.DecimalPlaces = 2;
            resources.ApplyResources(this.gammaInput, "gammaInput");
            this.gammaInput.Maximum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.gammaInput.Name = "gammaInput";
            this.gammaInput.Value = new decimal(new int[] {
            22,
            0,
            0,
            65536});
            this.gammaInput.ValueChanged += new System.EventHandler(this.gammaInput_ValueChanged);
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(37)))), ((int)(((byte)(55)))));
            this.Controls.Add(this.gammaInput);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.csharpTimeLabel);
            this.Controls.Add(this.asmTimeLabel);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.finalImg);
            this.Controls.Add(this.originalImg);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.threadSlider);
            this.Controls.Add(this.csharpBtn);
            this.Controls.Add(this.fileChooserBtn);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.asmBtn);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.ShowIcon = false;
            ((System.ComponentModel.ISupportInitialize)(this.threadSlider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.originalImg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.finalImg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gammaInput)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button asmBtn;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.Button fileChooserBtn;
        private System.Windows.Forms.Button csharpBtn;
        private System.Windows.Forms.TrackBar threadSlider;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.PictureBox originalImg;
        private System.Windows.Forms.PictureBox finalImg;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label asmTimeLabel;
        private System.Windows.Forms.Label csharpTimeLabel;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.NumericUpDown gammaInput;
    }
}

