namespace ViewGUI
{
    partial class SensitivityFactorForm
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
            this.SensitivityFactorTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ButtonOK = new System.Windows.Forms.Button();
            this.ButtonCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // SensitivityFactorTextBox
            // 
            this.SensitivityFactorTextBox.Location = new System.Drawing.Point(301, 6);
            this.SensitivityFactorTextBox.Name = "SensitivityFactorTextBox";
            this.SensitivityFactorTextBox.Size = new System.Drawing.Size(100, 20);
            this.SensitivityFactorTextBox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(283, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Коэффициент чувствительности напряжения: ";
            // 
            // ButtonOK
            // 
            this.ButtonOK.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ButtonOK.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.ButtonOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonOK.Location = new System.Drawing.Point(12, 60);
            this.ButtonOK.Name = "ButtonOK";
            this.ButtonOK.Size = new System.Drawing.Size(133, 34);
            this.ButtonOK.TabIndex = 2;
            this.ButtonOK.Text = "ОК";
            this.ButtonOK.UseVisualStyleBackColor = false;
            this.ButtonOK.Click += new System.EventHandler(this.ButtonOKClick);
            // 
            // ButtonCancel
            // 
            this.ButtonCancel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ButtonCancel.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.ButtonCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonCancel.Location = new System.Drawing.Point(268, 60);
            this.ButtonCancel.Name = "ButtonCancel";
            this.ButtonCancel.Size = new System.Drawing.Size(133, 34);
            this.ButtonCancel.TabIndex = 3;
            this.ButtonCancel.Text = "Отмена";
            this.ButtonCancel.UseVisualStyleBackColor = false;
            this.ButtonCancel.Click += new System.EventHandler(this.ButtonCancelClick);
            // 
            // SensitivityFactorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(416, 106);
            this.Controls.Add(this.ButtonCancel);
            this.Controls.Add(this.ButtonOK);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SensitivityFactorTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "SensitivityFactorForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SensitivityFactorForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SensitivityFactorFormClosing);
            this.Load += new System.EventHandler(this.SensitivityFactorFormLoad);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox SensitivityFactorTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button ButtonOK;
        private System.Windows.Forms.Button ButtonCancel;
    }
}