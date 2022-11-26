namespace ViewGUI
{
    partial class DatabaseEditorForm
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
            this.dataGridViewDB = new System.Windows.Forms.DataGridView();
            this.groupBoxDB = new System.Windows.Forms.GroupBox();
            this.ImportFromCSV = new System.Windows.Forms.Button();
            this.DataExportFromDB = new System.Windows.Forms.Button();
            this.LoadDataIntoDB = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDB)).BeginInit();
            this.groupBoxDB.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewDB
            // 
            this.dataGridViewDB.AllowUserToAddRows = false;
            this.dataGridViewDB.AllowUserToResizeColumns = false;
            this.dataGridViewDB.AllowUserToResizeRows = false;
            this.dataGridViewDB.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewDB.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDB.Location = new System.Drawing.Point(22, 27);
            this.dataGridViewDB.Name = "dataGridViewDB";
            this.dataGridViewDB.RowHeadersVisible = false;
            this.dataGridViewDB.RowHeadersWidth = 51;
            this.dataGridViewDB.RowTemplate.Height = 24;
            this.dataGridViewDB.Size = new System.Drawing.Size(735, 456);
            this.dataGridViewDB.TabIndex = 0;
            // 
            // groupBoxDB
            // 
            this.groupBoxDB.Controls.Add(this.dataGridViewDB);
            this.groupBoxDB.Location = new System.Drawing.Point(13, 60);
            this.groupBoxDB.Name = "groupBoxDB";
            this.groupBoxDB.Size = new System.Drawing.Size(775, 499);
            this.groupBoxDB.TabIndex = 1;
            this.groupBoxDB.TabStop = false;
            this.groupBoxDB.Text = "База данных";
            // 
            // ImportFromCSV
            // 
            this.ImportFromCSV.Location = new System.Drawing.Point(35, 12);
            this.ImportFromCSV.Name = "ImportFromCSV";
            this.ImportFromCSV.Size = new System.Drawing.Size(165, 42);
            this.ImportFromCSV.TabIndex = 2;
            this.ImportFromCSV.Text = "Импорт данных из csv";
            this.ImportFromCSV.UseVisualStyleBackColor = true;
            this.ImportFromCSV.Click += new System.EventHandler(this.ImportFromCSVClick);
            // 
            // DataExportFromDB
            // 
            this.DataExportFromDB.Location = new System.Drawing.Point(230, 12);
            this.DataExportFromDB.Name = "DataExportFromDB";
            this.DataExportFromDB.Size = new System.Drawing.Size(155, 41);
            this.DataExportFromDB.TabIndex = 3;
            this.DataExportFromDB.Text = "Экспорт в csv";
            this.DataExportFromDB.UseVisualStyleBackColor = true;
            this.DataExportFromDB.Click += new System.EventHandler(this.DataExportFromDBClick);
            // 
            // LoadDataIntoDB
            // 
            this.LoadDataIntoDB.Location = new System.Drawing.Point(410, 13);
            this.LoadDataIntoDB.Name = "LoadDataIntoDB";
            this.LoadDataIntoDB.Size = new System.Drawing.Size(258, 40);
            this.LoadDataIntoDB.TabIndex = 4;
            this.LoadDataIntoDB.Text = "Добавить данные в БД";
            this.LoadDataIntoDB.UseVisualStyleBackColor = true;
            this.LoadDataIntoDB.Click += new System.EventHandler(this.LoadDataIntoDBClick);
            // 
            // DatabaseEditorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 603);
            this.Controls.Add(this.LoadDataIntoDB);
            this.Controls.Add(this.DataExportFromDB);
            this.Controls.Add(this.ImportFromCSV);
            this.Controls.Add(this.groupBoxDB);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "DatabaseEditorForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DatabaseEditorForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DatabaseEditorFormClosing);
            this.Load += new System.EventHandler(this.DatabaseEditorFormLoad);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDB)).EndInit();
            this.groupBoxDB.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewDB;
        private System.Windows.Forms.GroupBox groupBoxDB;
        private System.Windows.Forms.Button ImportFromCSV;
        private System.Windows.Forms.Button DataExportFromDB;
        private System.Windows.Forms.Button LoadDataIntoDB;
    }
}