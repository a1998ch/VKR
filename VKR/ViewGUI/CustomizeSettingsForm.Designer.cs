namespace ViewGUI
{
    partial class CustomizeSettingsForm
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
            this.treeViewObj.Location = new System.Drawing.Point(12, 12);
            this.treeViewObj.Name = "treeViewObj";
            this.treeViewObj.Size = new System.Drawing.Size(299, 351);
            this.treeViewObj.TabIndex = 0;
            // 
            // ButtonOK
            // 
            this.ButtonOK.Location = new System.Drawing.Point(12, 382);
            this.ButtonOK.Name = "ButtonOK";
            this.ButtonOK.Size = new System.Drawing.Size(125, 35);
            this.ButtonOK.TabIndex = 3;
            this.ButtonOK.Text = "ОК";
            this.ButtonOK.UseVisualStyleBackColor = true;
            this.ButtonOK.Click += new System.EventHandler(this.ButtonOKClick);
            // 
            // ButtonClose
            // 
            this.ButtonClose.Location = new System.Drawing.Point(176, 382);
            this.ButtonClose.Name = "ButtonClose";
            this.ButtonClose.Size = new System.Drawing.Size(135, 35);
            this.ButtonClose.TabIndex = 4;
            this.ButtonClose.Text = "Отмена";
            this.ButtonClose.UseVisualStyleBackColor = true;
            this.ButtonClose.Click += new System.EventHandler(this.ButtonCloseClick);
            // 
            // CustomizeSettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(323, 429);
            this.Controls.Add(this.ButtonClose);
            this.Controls.Add(this.ButtonOK);
            this.Controls.Add(this.treeViewObj);
            this.MaximizeBox = false;
            this.Name = "CustomizeSettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CustomizeSettingsForm";
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