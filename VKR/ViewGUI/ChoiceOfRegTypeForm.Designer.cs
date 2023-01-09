namespace ViewGUI
{
    partial class ChoiceOfRegTypeForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboBoxReg = new System.Windows.Forms.ComboBox();
            this.OK = new System.Windows.Forms.Button();
            this.ButtonClose = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboBoxReg);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(335, 75);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Выбор типа регулирования";
            // 
            // comboBoxReg
            // 
            this.comboBoxReg.FormattingEnabled = true;
            this.comboBoxReg.Location = new System.Drawing.Point(6, 29);
            this.comboBoxReg.Name = "comboBoxReg";
            this.comboBoxReg.Size = new System.Drawing.Size(194, 21);
            this.comboBoxReg.TabIndex = 0;
            // 
            // OK
            // 
            this.OK.BackColor = System.Drawing.SystemColors.ControlLight;
            this.OK.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.OK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OK.Location = new System.Drawing.Point(18, 130);
            this.OK.Name = "OK";
            this.OK.Size = new System.Drawing.Size(133, 34);
            this.OK.TabIndex = 1;
            this.OK.Text = "ОК";
            this.OK.UseVisualStyleBackColor = false;
            this.OK.Click += new System.EventHandler(this.OKClick);
            // 
            // ButtonClose
            // 
            this.ButtonClose.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ButtonClose.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.ButtonClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonClose.Location = new System.Drawing.Point(214, 130);
            this.ButtonClose.Name = "ButtonClose";
            this.ButtonClose.Size = new System.Drawing.Size(133, 34);
            this.ButtonClose.TabIndex = 2;
            this.ButtonClose.Text = "Отмена";
            this.ButtonClose.UseVisualStyleBackColor = false;
            this.ButtonClose.Click += new System.EventHandler(this.ButtonCloseClick);
            // 
            // ChoiceOfRegTypeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(359, 178);
            this.Controls.Add(this.ButtonClose);
            this.Controls.Add(this.OK);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.Name = "ChoiceOfRegTypeForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ChoiceOfRegTypeForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ChoiceOfRegTypeFormClosing);
            this.Load += new System.EventHandler(this.ChoiceOfRegTypeFormLoad);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox comboBoxReg;
        private System.Windows.Forms.Button OK;
        private System.Windows.Forms.Button ButtonClose;
    }
}