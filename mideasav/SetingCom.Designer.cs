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
            cb1 = new CheckBox();
            cb2 = new CheckBox();
            cb3 = new CheckBox();
            cb4 = new CheckBox();
            cb5 = new CheckBox();
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
            PortCom.Items.AddRange(new object[] { "COM1", "COM2", "COM3", "COM4", "COM5", "COM6", "COM7", "COM8", "COM9", "COM10", "COM11", "COM12", "COM13", "COM14", "COM15", "COM16", "COM17", "COM18", "COM19", "COM20", "COM21", "COM22", "COM23", "COM24", "COM25" });
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
            // cb1
            // 
            cb1.AutoSize = true;
            cb1.Location = new Point(394, 24);
            cb1.Name = "cb1";
            cb1.Size = new Size(68, 19);
            cb1.TabIndex = 7;
            cb1.Text = "Temp In";
            cb1.UseVisualStyleBackColor = true;
            // 
            // cb2
            // 
            cb2.AutoSize = true;
            cb2.Location = new Point(394, 50);
            cb2.Name = "cb2";
            cb2.Size = new Size(78, 19);
            cb2.TabIndex = 8;
            cb2.Text = "Temp Out";
            cb2.UseVisualStyleBackColor = true;
            // 
            // cb3
            // 
            cb3.AutoSize = true;
            cb3.Location = new Point(394, 75);
            cb3.Name = "cb3";
            cb3.Size = new Size(81, 19);
            cb3.TabIndex = 9;
            cb3.Text = "Frequance";
            cb3.UseVisualStyleBackColor = true;
            // 
            // cb4
            // 
            cb4.AutoSize = true;
            cb4.Location = new Point(394, 102);
            cb4.Name = "cb4";
            cb4.Size = new Size(54, 19);
            cb4.TabIndex = 10;
            cb4.Text = "Debit";
            cb4.UseVisualStyleBackColor = true;
            // 
            // cb5
            // 
            cb5.AutoSize = true;
            cb5.Location = new Point(394, 127);
            cb5.Name = "cb5";
            cb5.Size = new Size(131, 19);
            cb5.TabIndex = 11;
            cb5.Text = "Echangeur Exterieur";
            cb5.UseVisualStyleBackColor = true;
            // 
            // SetingCom
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(967, 211);
            Controls.Add(cb5);
            Controls.Add(cb4);
            Controls.Add(cb3);
            Controls.Add(cb2);
            Controls.Add(cb1);
            Controls.Add(BtnValide);
            Controls.Add(label3);
            Controls.Add(PortCom);
            Controls.Add(label2);
            Controls.Add(SelDevicePac);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            ImeMode = ImeMode.AlphaFull;
            Name = "SetingCom";
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
        private CheckBox cb1;
        private CheckBox cb2;
        private CheckBox cb3;
        private CheckBox cb4;
        private CheckBox cb5;
    }
}