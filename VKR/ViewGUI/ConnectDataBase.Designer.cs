
namespace ViewGUI
{
    partial class ConnectDataBase
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
            this.ConnectDB = new System.Windows.Forms.Button();
            this.NameServerLabel = new System.Windows.Forms.Label();
            this.NameDBLabel = new System.Windows.Forms.Label();
            this.ServerConnection = new System.Windows.Forms.GroupBox();
            this.NameDB = new System.Windows.Forms.TextBox();
            this.NameServer = new System.Windows.Forms.TextBox();
            this.Cancellation = new System.Windows.Forms.Button();
            this.ServerConnection.SuspendLayout();
            this.SuspendLayout();
            // 
            // ConnectDB
            // 
            this.ConnectDB.Location = new System.Drawing.Point(15, 247);
            this.ConnectDB.Margin = new System.Windows.Forms.Padding(4);
            this.ConnectDB.Name = "ConnectDB";
            this.ConnectDB.Size = new System.Drawing.Size(145, 28);
            this.ConnectDB.TabIndex = 8;
            this.ConnectDB.Text = "Соединить";
            this.ConnectDB.UseVisualStyleBackColor = true;
            this.ConnectDB.Click += new System.EventHandler(this.ConnectDBClick);
            // 
            // NameServerLabel
            // 
            this.NameServerLabel.AutoSize = true;
            this.NameServerLabel.Location = new System.Drawing.Point(22, 41);
            this.NameServerLabel.Name = "NameServerLabel";
            this.NameServerLabel.Size = new System.Drawing.Size(94, 16);
            this.NameServerLabel.TabIndex = 9;
            this.NameServerLabel.Text = "Имя сервера:";
            // 
            // NameDBLabel
            // 
            this.NameDBLabel.AutoSize = true;
            this.NameDBLabel.Location = new System.Drawing.Point(22, 105);
            this.NameDBLabel.Name = "NameDBLabel";
            this.NameDBLabel.Size = new System.Drawing.Size(123, 16);
            this.NameDBLabel.TabIndex = 10;
            this.NameDBLabel.Text = "Имя Базы данных:";
            // 
            // ServerConnection
            // 
            this.ServerConnection.Controls.Add(this.NameDB);
            this.ServerConnection.Controls.Add(this.NameDBLabel);
            this.ServerConnection.Controls.Add(this.NameServer);
            this.ServerConnection.Controls.Add(this.NameServerLabel);
            this.ServerConnection.Location = new System.Drawing.Point(15, 12);
            this.ServerConnection.Name = "ServerConnection";
            this.ServerConnection.Size = new System.Drawing.Size(536, 176);
            this.ServerConnection.TabIndex = 11;
            this.ServerConnection.TabStop = false;
            this.ServerConnection.Text = "Соединение с сервером";
            // 
            // NameDB
            // 
            this.NameDB.Location = new System.Drawing.Point(177, 102);
            this.NameDB.Name = "NameDB";
            this.NameDB.Size = new System.Drawing.Size(336, 22);
            this.NameDB.TabIndex = 13;
            // 
            // NameServer
            // 
            this.NameServer.Location = new System.Drawing.Point(177, 41);
            this.NameServer.Name = "NameServer";
            this.NameServer.Size = new System.Drawing.Size(336, 22);
            this.NameServer.TabIndex = 12;
            // 
            // Cancellation
            // 
            this.Cancellation.Location = new System.Drawing.Point(192, 247);
            this.Cancellation.Name = "Cancellation";
            this.Cancellation.Size = new System.Drawing.Size(131, 28);
            this.Cancellation.TabIndex = 12;
            this.Cancellation.Text = "Отмена";
            this.Cancellation.UseVisualStyleBackColor = true;
            this.Cancellation.Click += new System.EventHandler(this.CancellationClick);
            // 
            // ConnectDataBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(579, 288);
            this.Controls.Add(this.Cancellation);
            this.Controls.Add(this.ServerConnection);
            this.Controls.Add(this.ConnectDB);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "ConnectDataBase";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ConnectDataBase";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ConnectDataBaseClosing);
            this.Load += new System.EventHandler(this.ConnectDataBaseLoad);
            this.ServerConnection.ResumeLayout(false);
            this.ServerConnection.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ConnectDB;
        private System.Windows.Forms.Label NameServerLabel;
        private System.Windows.Forms.Label NameDBLabel;
        private System.Windows.Forms.GroupBox ServerConnection;
        private System.Windows.Forms.TextBox NameDB;
        private System.Windows.Forms.TextBox NameServer;
        private System.Windows.Forms.Button Cancellation;
    }
}