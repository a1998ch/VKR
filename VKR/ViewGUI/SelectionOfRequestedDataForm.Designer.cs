namespace ViewGUI
{
    partial class SelectionOfRequestedDataForm
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
            this.treeViewObj = new System.Windows.Forms.TreeView();
            this.ButtonOK = new System.Windows.Forms.Button();
            this.ButtonClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // treeViewObj
            // 
            this.treeViewObj.Location = new System.Drawing.Point(16, 15);
            this.treeViewObj.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.treeViewObj.Name = "treeViewObj";
            this.treeViewObj.Size = new System.Drawing.Size(397, 431);
            this.treeViewObj.TabIndex = 0;
            // 
            // ButtonOK
            // 
            this.ButtonOK.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ButtonOK.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.ButtonOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonOK.Location = new System.Drawing.Point(16, 470);
            this.ButtonOK.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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
            this.ButtonClose.Location = new System.Drawing.Point(235, 470);
            this.ButtonClose.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ButtonClose.Name = "ButtonClose";
            this.ButtonClose.Size = new System.Drawing.Size(177, 42);
            this.ButtonClose.TabIndex = 4;
            this.ButtonClose.Text = "Отмена";
            this.ButtonClose.UseVisualStyleBackColor = false;
            this.ButtonClose.Click += new System.EventHandler(this.ButtonCloseClick);
            // 
            // SelectionOfRequestedDataForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(431, 528);
            this.Controls.Add(this.ButtonClose);
            this.Controls.Add(this.ButtonOK);
            this.Controls.Add(this.treeViewObj);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.Name = "SelectionOfRequestedDataForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Выбор аналоговых значений из СК-11";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CustomizeSettingsFormFormClosing);
            this.Load += new System.EventHandler(this.CustomizeSettingsFormLoad);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.TreeView treeViewObj;
        private System.Windows.Forms.Button ButtonOK;
        private System.Windows.Forms.Button ButtonClose;
    }
}