namespace ViewGUI
{
    partial class ChoiceOfSchemaForm
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
            this.OK = new System.Windows.Forms.Button();
            this.ButtonClose = new System.Windows.Forms.Button();
            this.comboBoxScheme = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // OK
            // 
            this.OK.BackColor = System.Drawing.SystemColors.ControlLight;
            this.OK.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.OK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OK.Location = new System.Drawing.Point(16, 138);
            this.OK.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.OK.Name = "OK";
            this.OK.Size = new System.Drawing.Size(177, 42);
            this.OK.TabIndex = 0;
            this.OK.Text = "OK";
            this.OK.UseVisualStyleBackColor = false;
            this.OK.Click += new System.EventHandler(this.OKClick);
            // 
            // ButtonClose
            // 
            this.ButtonClose.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ButtonClose.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.ButtonClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonClose.Location = new System.Drawing.Point(243, 138);
            this.ButtonClose.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ButtonClose.Name = "ButtonClose";
            this.ButtonClose.Size = new System.Drawing.Size(177, 42);
            this.ButtonClose.TabIndex = 1;
            this.ButtonClose.Text = "Отмена";
            this.ButtonClose.UseVisualStyleBackColor = false;
            this.ButtonClose.Click += new System.EventHandler(this.ButtonCloseClick);
            // 
            // comboBoxScheme
            // 
            this.comboBoxScheme.FormattingEnabled = true;
            this.comboBoxScheme.Location = new System.Drawing.Point(8, 36);
            this.comboBoxScheme.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comboBoxScheme.Name = "comboBoxScheme";
            this.comboBoxScheme.Size = new System.Drawing.Size(257, 24);
            this.comboBoxScheme.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboBoxScheme);
            this.groupBox1.Location = new System.Drawing.Point(29, 15);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(391, 85);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Выбор схемно-режимной ситуации";
            // 
            // ChoiceOfSchemaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(436, 194);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ButtonClose);
            this.Controls.Add(this.OK);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.Name = "ChoiceOfSchemaForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Выбор схемно-режимной ситуации";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ChoiceOfSchemaFormClosing);
            this.Load += new System.EventHandler(this.ChoiceOfSchemaFormLoad);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button OK;
        private System.Windows.Forms.Button ButtonClose;
        private System.Windows.Forms.ComboBox comboBoxScheme;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}