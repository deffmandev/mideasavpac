namespace mideasav
{
    partial class SetingCom
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            SelDevicePac = new ComboBox();
            label2 = new Label();
            label3 = new Label();
            PortCom = new ComboBox();
            BtnValide = new Button();
            SuspendLayout();
            // 
            // SelDevicePac
            // 
            SelDevicePac.DropDownStyle = ComboBoxStyle.DropDownList;
            SelDevicePac.FormattingEnabled = true;
            SelDevicePac.ImeMode = ImeMode.NoControl;
            SelDevicePac.Items.AddRange(new object[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16" });
            SelDevicePac.Location = new Point(230, 98);
            SelDevicePac.Name = "SelDevicePac";
            SelDevicePac.RightToLeft = RightToLeft.No;
            SelDevicePac.Size = new Size(72, 23);
            SelDevicePac.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(25, 101);
            label2.Name = "label2";
            label2.Size = new Size(171, 15);
            label2.TabIndex = 3;
            label2.Text = "Numero de la pompe a chaleur";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(25, 49);
            label3.Name = "label3";
            label3.Size = new Size(133, 15);
            label3.TabIndex = 5;
            label3.Text = "Port de communication";
            // 
            // PortCom
            // 
            PortCom.DropDownStyle = ComboBoxStyle.DropDownList;
            PortCom.FormattingEnabled = true;
            PortCom.Items.AddRange(new object[] { "COM1", "COM2", "COM3" });
            PortCom.Location = new Point(230, 46);
            PortCom.Name = "PortCom";
            PortCom.Size = new Size(72, 23);
            PortCom.TabIndex = 4;
            // 
            // BtnValide
            // 
            BtnValide.Location = new Point(220, 143);
            BtnValide.Name = "BtnValide";
            BtnValide.Size = new Size(92, 41);
            BtnValide.TabIndex = 6;
            BtnValide.Text = "Validé";
            BtnValide.UseVisualStyleBackColor = true;
            BtnValide.Click += BtnValide_Click;
            // 
            // seting
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(353, 211);
            Controls.Add(BtnValide);
            Controls.Add(label3);
            Controls.Add(PortCom);
            Controls.Add(label2);
            Controls.Add(SelDevicePac);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            ImeMode = ImeMode.AlphaFull;
            Name = "seting";
            Text = "Configuration Port";
            Load += seting_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        public ComboBox SelDevicePac;
        private Label label2;
        private Label label3;
        public ComboBox PortCom;
        private Button BtnValide;
    }
}