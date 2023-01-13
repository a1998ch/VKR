namespace ViewGUI
{
    partial class AddNewObjForm
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
            this.treeViewObj = new System.Windows.Forms.TreeView();
            this.AddElement = new System.Windows.Forms.Button();
            this.ButtonClose = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.treeViewObj);
            this.groupBox1.Location = new System.Drawing.Point(16, 15);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(552, 385);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Выбор объекта электроэнергетики";
            // 
            // treeViewObj
            // 
            this.treeViewObj.Location = new System.Drawing.Point(8, 23);
            this.treeViewObj.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.treeViewObj.Name = "treeViewObj";
            this.treeViewObj.Size = new System.Drawing.Size(535, 354);
            this.treeViewObj.TabIndex = 0;
            // 
            // AddElement
            // 
            this.AddElement.BackColor = System.Drawing.SystemColors.ControlLight;
            this.AddElement.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.AddElement.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddElement.Location = new System.Drawing.Point(24, 407);
            this.AddElement.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.AddElement.Name = "AddElement";
            this.AddElement.Size = new System.Drawing.Size(177, 42);
            this.AddElement.TabIndex = 1;
            this.AddElement.Text = "Добавить";
            this.AddElement.UseVisualStyleBackColor = false;
            this.AddElement.Click += new System.EventHandler(this.AddElementClick);
            // 
            // ButtonClose
            // 
            this.ButtonClose.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ButtonClose.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.ButtonClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonClose.Location = new System.Drawing.Point(383, 407);
            this.ButtonClose.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ButtonClose.Name = "ButtonClose";
            this.ButtonClose.Size = new System.Drawing.Size(177, 42);
            this.ButtonClose.TabIndex = 2;
            this.ButtonClose.Text = "Отмена";
            this.ButtonClose.UseVisualStyleBackColor = false;
            this.ButtonClose.Click += new System.EventHandler(this.ButtonCloseClick);
            // 
            // AddNewObjForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 468);
            this.Controls.Add(this.ButtonClose);
            this.Controls.Add(this.AddElement);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.Name = "AddNewObjForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Выбор объекта электроэнергетики";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AddNewObjFormFormClosing);
            this.Load += new System.EventHandler(this.AddNewObjFormLoad);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button AddElement;
        private System.Windows.Forms.Button ButtonClose;
        private System.Windows.Forms.TreeView treeViewObj;
    }
}