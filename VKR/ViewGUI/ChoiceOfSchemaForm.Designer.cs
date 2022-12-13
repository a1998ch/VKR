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
            this.Close = new System.Windows.Forms.Button();
            this.comboBoxScheme = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // OK
            // 
            this.OK.Location = new System.Drawing.Point(14, 139);
            this.OK.Name = "OK";
            this.OK.Size = new System.Drawing.Size(133, 42);
            this.OK.TabIndex = 0;
            this.OK.Text = "OK";
            this.OK.UseVisualStyleBackColor = true;
            this.OK.Click += new System.EventHandler(this.OKClick);
            // 
            // Close
            // 
            this.Close.Location = new System.Drawing.Point(179, 139);
            this.Close.Name = "Close";
            this.Close.Size = new System.Drawing.Size(127, 42);
            this.Close.TabIndex = 1;
            this.Close.Text = "Отмена";
            this.Close.UseVisualStyleBackColor = true;
            this.Close.Click += new System.EventHandler(this.CloseClick);
            // 
            // comboBoxScheme
            // 
            this.comboBoxScheme.FormattingEnabled = true;
            this.comboBoxScheme.Location = new System.Drawing.Point(6, 19);
            this.comboBoxScheme.Name = "comboBoxScheme";
            this.comboBoxScheme.Size = new System.Drawing.Size(121, 21);
            this.comboBoxScheme.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboBoxScheme);
            this.groupBox1.Location = new System.Drawing.Point(22, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(263, 56);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Выбор схемно-режимной ситуации";
            // 
            // ChoiceOfSchemaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(327, 199);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.Close);
            this.Controls.Add(this.OK);
            this.MaximizeBox = false;
            this.Name = "ChoiceOfSchemaForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ChoiceOfSchemaForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ChoiceOfSchemaFormClosing);
            this.Load += new System.EventHandler(this.ChoiceOfSchemaFormLoad);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button OK;
        private System.Windows.Forms.Button Close;
        private System.Windows.Forms.ComboBox comboBoxScheme;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}