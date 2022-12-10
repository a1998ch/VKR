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
            this.LoadDataFromDb = new System.Windows.Forms.Button();
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
            this.dataGridViewDB.Location = new System.Drawing.Point(16, 22);
            this.dataGridViewDB.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dataGridViewDB.Name = "dataGridViewDB";
            this.dataGridViewDB.RowHeadersVisible = false;
            this.dataGridViewDB.RowHeadersWidth = 51;
            this.dataGridViewDB.RowTemplate.Height = 24;
            this.dataGridViewDB.Size = new System.Drawing.Size(647, 370);
            this.dataGridViewDB.TabIndex = 0;
            // 
            // groupBoxDB
            // 
            this.groupBoxDB.Controls.Add(this.dataGridViewDB);
            this.groupBoxDB.Location = new System.Drawing.Point(10, 49);
            this.groupBoxDB.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBoxDB.Name = "groupBoxDB";
            this.groupBoxDB.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBoxDB.Size = new System.Drawing.Size(667, 405);
            this.groupBoxDB.TabIndex = 1;
            this.groupBoxDB.TabStop = false;
            this.groupBoxDB.Text = "База данных";
            // 
            // ImportFromCSV
            // 
            this.ImportFromCSV.Location = new System.Drawing.Point(26, 10);
            this.ImportFromCSV.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ImportFromCSV.Name = "ImportFromCSV";
            this.ImportFromCSV.Size = new System.Drawing.Size(124, 34);
            this.ImportFromCSV.TabIndex = 2;
            this.ImportFromCSV.Text = "Импорт данных из csv";
            this.ImportFromCSV.UseVisualStyleBackColor = true;
            this.ImportFromCSV.Click += new System.EventHandler(this.ImportFromCSVClick);
            // 
            // DataExportFromDB
            // 
            this.DataExportFromDB.Location = new System.Drawing.Point(172, 10);
            this.DataExportFromDB.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.DataExportFromDB.Name = "DataExportFromDB";
            this.DataExportFromDB.Size = new System.Drawing.Size(116, 33);
            this.DataExportFromDB.TabIndex = 3;
            this.DataExportFromDB.Text = "Экспорт в csv";
            this.DataExportFromDB.UseVisualStyleBackColor = true;
            this.DataExportFromDB.Click += new System.EventHandler(this.DataExportFromDBClick);
            // 
            // LoadDataIntoDB
            // 
            this.LoadDataIntoDB.Location = new System.Drawing.Point(308, 11);
            this.LoadDataIntoDB.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.LoadDataIntoDB.Name = "LoadDataIntoDB";
            this.LoadDataIntoDB.Size = new System.Drawing.Size(194, 32);
            this.LoadDataIntoDB.TabIndex = 4;
            this.LoadDataIntoDB.Text = "Добавить данные в БД";
            this.LoadDataIntoDB.UseVisualStyleBackColor = true;
            this.LoadDataIntoDB.Click += new System.EventHandler(this.LoadDataIntoDBClick);
            // 
            // LoadDataFromDb
            // 
            this.LoadDataFromDb.Location = new System.Drawing.Point(518, 12);
            this.LoadDataFromDb.Name = "LoadDataFromDb";
            this.LoadDataFromDb.Size = new System.Drawing.Size(155, 30);
            this.LoadDataFromDb.TabIndex = 5;
            this.LoadDataFromDb.Text = "Загрузить данные из бд";
            this.LoadDataFromDb.UseVisualStyleBackColor = true;
            this.LoadDataFromDb.Click += new System.EventHandler(this.LoadDataFromDbClick);
            // 
            // DatabaseEditorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(688, 490);
            this.Controls.Add(this.LoadDataFromDb);
            this.Controls.Add(this.LoadDataIntoDB);
            this.Controls.Add(this.DataExportFromDB);
            this.Controls.Add(this.ImportFromCSV);
            this.Controls.Add(this.groupBoxDB);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
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
        private System.Windows.Forms.Button LoadDataFromDb;
    }
}