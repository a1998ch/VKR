﻿namespace ViewGUI
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
            this.textBoxAddObj = new System.Windows.Forms.TextBox();
            this.AddElement = new System.Windows.Forms.Button();
            this.ButtonClose = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBoxAddObj);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(414, 76);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Введите диспетчерское наименование объекта электроэнергетики";
            // 
            // textBoxAddObj
            // 
            this.textBoxAddObj.Location = new System.Drawing.Point(6, 19);
            this.textBoxAddObj.Name = "textBoxAddObj";
            this.textBoxAddObj.Size = new System.Drawing.Size(402, 20);
            this.textBoxAddObj.TabIndex = 0;
            // 
            // AddElement
            // 
            this.AddElement.Location = new System.Drawing.Point(12, 111);
            this.AddElement.Name = "AddElement";
            this.AddElement.Size = new System.Drawing.Size(186, 37);
            this.AddElement.TabIndex = 1;
            this.AddElement.Text = "Добавить";
            this.AddElement.UseVisualStyleBackColor = true;
            this.AddElement.Click += new System.EventHandler(this.AddElementClick);
            // 
            // ButtonClose
            // 
            this.ButtonClose.Location = new System.Drawing.Point(249, 111);
            this.ButtonClose.Name = "ButtonClose";
            this.ButtonClose.Size = new System.Drawing.Size(171, 37);
            this.ButtonClose.TabIndex = 2;
            this.ButtonClose.Text = "Отмена";
            this.ButtonClose.UseVisualStyleBackColor = true;
            this.ButtonClose.Click += new System.EventHandler(this.ButtonCloseClick);
            // 
            // AddNewObjForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(438, 161);
            this.Controls.Add(this.ButtonClose);
            this.Controls.Add(this.AddElement);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.Name = "AddNewObjForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AddNewObjForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AddNewObjFormFormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBoxAddObj;
        private System.Windows.Forms.Button AddElement;
        private System.Windows.Forms.Button ButtonClose;
    }
}