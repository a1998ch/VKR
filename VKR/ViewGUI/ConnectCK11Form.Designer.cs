namespace ViewGUI
{
    partial class ConnectCK11Form
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
            this.AddressBdrvTextBox = new System.Windows.Forms.TextBox();
            this.PortBdrvTextBox = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.PortPcTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.AddressPcTextBox = new System.Windows.Forms.TextBox();
            this.ButtonOK = new System.Windows.Forms.Button();
            this.ButtonClose = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // AddressBdrvTextBox
            // 
            this.AddressBdrvTextBox.Location = new System.Drawing.Point(179, 34);
            this.AddressBdrvTextBox.Name = "AddressBdrvTextBox";
            this.AddressBdrvTextBox.Size = new System.Drawing.Size(310, 22);
            this.AddressBdrvTextBox.TabIndex = 0;
            // 
            // PortBdrvTextBox
            // 
            this.PortBdrvTextBox.Location = new System.Drawing.Point(179, 75);
            this.PortBdrvTextBox.Name = "PortBdrvTextBox";
            this.PortBdrvTextBox.Size = new System.Drawing.Size(310, 22);
            this.PortBdrvTextBox.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.PortPcTextBox);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.AddressPcTextBox);
            this.groupBox1.Controls.Add(this.AddressBdrvTextBox);
            this.groupBox1.Controls.Add(this.PortBdrvTextBox);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(503, 198);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Подключение к СК-11";
            // 
            // PortPcTextBox
            // 
            this.PortPcTextBox.Location = new System.Drawing.Point(179, 155);
            this.PortPcTextBox.Name = "PortPcTextBox";
            this.PortPcTextBox.Size = new System.Drawing.Size(310, 22);
            this.PortPcTextBox.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 155);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 16);
            this.label4.TabIndex = 6;
            this.label4.Text = "Порт:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 118);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(166, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "Адрес рабочей станции:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(139, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "Порт сервиса БДРВ:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "Адрес БДРВ:";
            // 
            // AddressPcTextBox
            // 
            this.AddressPcTextBox.Location = new System.Drawing.Point(179, 115);
            this.AddressPcTextBox.Name = "AddressPcTextBox";
            this.AddressPcTextBox.Size = new System.Drawing.Size(310, 22);
            this.AddressPcTextBox.TabIndex = 2;
            // 
            // ButtonOK
            // 
            this.ButtonOK.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ButtonOK.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.ButtonOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonOK.Location = new System.Drawing.Point(12, 237);
            this.ButtonOK.Name = "ButtonOK";
            this.ButtonOK.Size = new System.Drawing.Size(177, 42);
            this.ButtonOK.TabIndex = 3;
            this.ButtonOK.Text = "ОК";
            this.ButtonOK.UseVisualStyleBackColor = false;
            this.ButtonOK.Click += new System.EventHandler(this.ButtonOKClick);
            // 
            // ButtonClose
            // 
            this.ButtonClose.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ButtonClose.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.ButtonClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonClose.Location = new System.Drawing.Point(338, 237);
            this.ButtonClose.Name = "ButtonClose";
            this.ButtonClose.Size = new System.Drawing.Size(177, 42);
            this.ButtonClose.TabIndex = 4;
            this.ButtonClose.Text = "Отмена";
            this.ButtonClose.UseVisualStyleBackColor = false;
            this.ButtonClose.Click += new System.EventHandler(this.ButtonCloseClick);
            // 
            // ConnectCK11Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(527, 291);
            this.Controls.Add(this.ButtonClose);
            this.Controls.Add(this.ButtonOK);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "ConnectCK11Form";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Подключение к СК-11";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ConnectCK11FormFormClosing);
            this.Load += new System.EventHandler(this.ConnectCK11FormLoad);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox AddressBdrvTextBox;
        private System.Windows.Forms.TextBox PortBdrvTextBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox AddressPcTextBox;
        private System.Windows.Forms.Button ButtonOK;
        private System.Windows.Forms.Button ButtonClose;
        private System.Windows.Forms.TextBox PortPcTextBox;
        private System.Windows.Forms.Label label4;
    }
}