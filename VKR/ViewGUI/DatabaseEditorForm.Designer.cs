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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DatabaseEditorForm));
            this.dataGridViewDB = new System.Windows.Forms.DataGridView();
            this.groupBoxDB = new System.Windows.Forms.GroupBox();
            this.TreeViewVoltage = new System.Windows.Forms.TreeView();
            this.ButtonVoltage = new System.Windows.Forms.Button();
            this.ImportFromCSV = new System.Windows.Forms.Button();
            this.DataExportFromDB = new System.Windows.Forms.Button();
            this.LoadDataIntoDB = new System.Windows.Forms.Button();
            this.LoadDataFromDb = new System.Windows.Forms.Button();
            this.groupBoxFilter = new System.Windows.Forms.GroupBox();
            this.ButtonEnergyObj = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.ButtonSchema = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.ButtonClearFilter = new System.Windows.Forms.Button();
            this.ButtonRegType = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.TreeViewRegType = new System.Windows.Forms.TreeView();
            this.TreeViewSchema = new System.Windows.Forms.TreeView();
            this.TreeViewEnObj = new System.Windows.Forms.TreeView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDB)).BeginInit();
            this.groupBoxDB.SuspendLayout();
            this.groupBoxFilter.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewDB
            // 
            this.dataGridViewDB.AllowUserToAddRows = false;
            this.dataGridViewDB.AllowUserToResizeColumns = false;
            this.dataGridViewDB.AllowUserToResizeRows = false;
            this.dataGridViewDB.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewDB.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDB.Location = new System.Drawing.Point(21, 27);
            this.dataGridViewDB.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridViewDB.Name = "dataGridViewDB";
            this.dataGridViewDB.RowHeadersVisible = false;
            this.dataGridViewDB.RowHeadersWidth = 51;
            this.dataGridViewDB.RowTemplate.Height = 24;
            this.dataGridViewDB.Size = new System.Drawing.Size(1045, 455);
            this.dataGridViewDB.TabIndex = 0;
            // 
            // groupBoxDB
            // 
            this.groupBoxDB.Controls.Add(this.dataGridViewDB);
            this.groupBoxDB.Location = new System.Drawing.Point(12, 130);
            this.groupBoxDB.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBoxDB.Name = "groupBoxDB";
            this.groupBoxDB.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBoxDB.Size = new System.Drawing.Size(1072, 498);
            this.groupBoxDB.TabIndex = 1;
            this.groupBoxDB.TabStop = false;
            this.groupBoxDB.Text = "База данных";
            // 
            // TreeViewVoltage
            // 
            this.TreeViewVoltage.CheckBoxes = true;
            this.TreeViewVoltage.Location = new System.Drawing.Point(851, 94);
            this.TreeViewVoltage.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TreeViewVoltage.Name = "TreeViewVoltage";
            this.TreeViewVoltage.Size = new System.Drawing.Size(92, 77);
            this.TreeViewVoltage.TabIndex = 6;
            this.TreeViewVoltage.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.TreeViewVoltageAfterCheck);
            this.TreeViewVoltage.MouseLeave += new System.EventHandler(this.TreeViewVoltageMouseLeave);
            // 
            // ButtonVoltage
            // 
            this.ButtonVoltage.BackColor = System.Drawing.SystemColors.Control;
            this.ButtonVoltage.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ButtonVoltage.BackgroundImage")));
            this.ButtonVoltage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ButtonVoltage.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.ButtonVoltage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonVoltage.Location = new System.Drawing.Point(828, 16);
            this.ButtonVoltage.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ButtonVoltage.Name = "ButtonVoltage";
            this.ButtonVoltage.Size = new System.Drawing.Size(27, 23);
            this.ButtonVoltage.TabIndex = 7;
            this.ButtonVoltage.UseVisualStyleBackColor = false;
            this.ButtonVoltage.Click += new System.EventHandler(this.ButtonVoltageClick);
            // 
            // ImportFromCSV
            // 
            this.ImportFromCSV.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ImportFromCSV.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.ImportFromCSV.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ImportFromCSV.Location = new System.Drawing.Point(12, 10);
            this.ImportFromCSV.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ImportFromCSV.Name = "ImportFromCSV";
            this.ImportFromCSV.Size = new System.Drawing.Size(259, 39);
            this.ImportFromCSV.TabIndex = 2;
            this.ImportFromCSV.Text = "Импорт данных из csv";
            this.ImportFromCSV.UseVisualStyleBackColor = false;
            this.ImportFromCSV.Click += new System.EventHandler(this.ImportFromCSVClick);
            // 
            // DataExportFromDB
            // 
            this.DataExportFromDB.BackColor = System.Drawing.SystemColors.ControlLight;
            this.DataExportFromDB.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.DataExportFromDB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DataExportFromDB.Location = new System.Drawing.Point(283, 11);
            this.DataExportFromDB.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.DataExportFromDB.Name = "DataExportFromDB";
            this.DataExportFromDB.Size = new System.Drawing.Size(259, 39);
            this.DataExportFromDB.TabIndex = 3;
            this.DataExportFromDB.Text = "Экспорт в csv";
            this.DataExportFromDB.UseVisualStyleBackColor = false;
            this.DataExportFromDB.Click += new System.EventHandler(this.DataExportFromDBClick);
            // 
            // LoadDataIntoDB
            // 
            this.LoadDataIntoDB.BackColor = System.Drawing.SystemColors.ControlLight;
            this.LoadDataIntoDB.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.LoadDataIntoDB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LoadDataIntoDB.Location = new System.Drawing.Point(553, 11);
            this.LoadDataIntoDB.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.LoadDataIntoDB.Name = "LoadDataIntoDB";
            this.LoadDataIntoDB.Size = new System.Drawing.Size(259, 39);
            this.LoadDataIntoDB.TabIndex = 4;
            this.LoadDataIntoDB.Text = "Добавить данные в БД";
            this.LoadDataIntoDB.UseVisualStyleBackColor = false;
            this.LoadDataIntoDB.Click += new System.EventHandler(this.LoadDataIntoDBClick);
            // 
            // LoadDataFromDb
            // 
            this.LoadDataFromDb.BackColor = System.Drawing.SystemColors.ControlLight;
            this.LoadDataFromDb.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.LoadDataFromDb.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LoadDataFromDb.Location = new System.Drawing.Point(819, 11);
            this.LoadDataFromDb.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.LoadDataFromDb.Name = "LoadDataFromDb";
            this.LoadDataFromDb.Size = new System.Drawing.Size(259, 39);
            this.LoadDataFromDb.TabIndex = 5;
            this.LoadDataFromDb.Text = "Загрузить данные из бд";
            this.LoadDataFromDb.UseVisualStyleBackColor = false;
            this.LoadDataFromDb.Click += new System.EventHandler(this.LoadDataFromDbClick);
            // 
            // groupBoxFilter
            // 
            this.groupBoxFilter.Controls.Add(this.ButtonEnergyObj);
            this.groupBoxFilter.Controls.Add(this.label4);
            this.groupBoxFilter.Controls.Add(this.ButtonSchema);
            this.groupBoxFilter.Controls.Add(this.label3);
            this.groupBoxFilter.Controls.Add(this.ButtonClearFilter);
            this.groupBoxFilter.Controls.Add(this.ButtonRegType);
            this.groupBoxFilter.Controls.Add(this.label2);
            this.groupBoxFilter.Controls.Add(this.label1);
            this.groupBoxFilter.Controls.Add(this.ButtonVoltage);
            this.groupBoxFilter.Location = new System.Drawing.Point(12, 57);
            this.groupBoxFilter.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBoxFilter.Name = "groupBoxFilter";
            this.groupBoxFilter.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBoxFilter.Size = new System.Drawing.Size(1069, 44);
            this.groupBoxFilter.TabIndex = 6;
            this.groupBoxFilter.TabStop = false;
            this.groupBoxFilter.Text = "Фильтр";
            // 
            // ButtonEnergyObj
            // 
            this.ButtonEnergyObj.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ButtonEnergyObj.BackgroundImage")));
            this.ButtonEnergyObj.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ButtonEnergyObj.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.ButtonEnergyObj.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonEnergyObj.Location = new System.Drawing.Point(213, 14);
            this.ButtonEnergyObj.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ButtonEnergyObj.Name = "ButtonEnergyObj";
            this.ButtonEnergyObj.Size = new System.Drawing.Size(27, 23);
            this.ButtonEnergyObj.TabIndex = 15;
            this.ButtonEnergyObj.UseVisualStyleBackColor = true;
            this.ButtonEnergyObj.Click += new System.EventHandler(this.ButtonEnergyObjClick);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(195, 16);
            this.label4.TabIndex = 14;
            this.label4.Text = "Объект электроэнергетики: ";
            // 
            // ButtonSchema
            // 
            this.ButtonSchema.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ButtonSchema.BackgroundImage")));
            this.ButtonSchema.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ButtonSchema.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.ButtonSchema.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonSchema.Location = new System.Drawing.Point(444, 14);
            this.ButtonSchema.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ButtonSchema.Name = "ButtonSchema";
            this.ButtonSchema.Size = new System.Drawing.Size(27, 23);
            this.ButtonSchema.TabIndex = 13;
            this.ButtonSchema.UseVisualStyleBackColor = true;
            this.ButtonSchema.Click += new System.EventHandler(this.ButtonSchemaClick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(245, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(194, 16);
            this.label3.TabIndex = 12;
            this.label3.Text = "Схемно-режимная ситуация: ";
            // 
            // ButtonClearFilter
            // 
            this.ButtonClearFilter.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ButtonClearFilter.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.ButtonClearFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonClearFilter.Location = new System.Drawing.Point(901, 10);
            this.ButtonClearFilter.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ButtonClearFilter.Name = "ButtonClearFilter";
            this.ButtonClearFilter.Size = new System.Drawing.Size(163, 28);
            this.ButtonClearFilter.TabIndex = 11;
            this.ButtonClearFilter.Text = "Отчистить фильтр";
            this.ButtonClearFilter.UseVisualStyleBackColor = false;
            this.ButtonClearFilter.Click += new System.EventHandler(this.ButtonClearFilterClick);
            // 
            // ButtonRegType
            // 
            this.ButtonRegType.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ButtonRegType.BackgroundImage")));
            this.ButtonRegType.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ButtonRegType.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.ButtonRegType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonRegType.Location = new System.Drawing.Point(635, 15);
            this.ButtonRegType.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ButtonRegType.Name = "ButtonRegType";
            this.ButtonRegType.Size = new System.Drawing.Size(27, 23);
            this.ButtonRegType.TabIndex = 10;
            this.ButtonRegType.UseVisualStyleBackColor = true;
            this.ButtonRegType.Click += new System.EventHandler(this.ButtonRegTypeClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(485, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(142, 16);
            this.label2.TabIndex = 9;
            this.label2.Text = "Тип регулирования: ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(675, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(148, 16);
            this.label1.TabIndex = 8;
            this.label1.Text = "Уровень напряжения:";
            // 
            // TreeViewRegType
            // 
            this.TreeViewRegType.Location = new System.Drawing.Point(661, 94);
            this.TreeViewRegType.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TreeViewRegType.Name = "TreeViewRegType";
            this.TreeViewRegType.Size = new System.Drawing.Size(183, 77);
            this.TreeViewRegType.TabIndex = 11;
            this.TreeViewRegType.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.TreeViewRegTypeAfterCheck);
            this.TreeViewRegType.MouseLeave += new System.EventHandler(this.TreeViewRegTypeMouseLeave);
            // 
            // TreeViewSchema
            // 
            this.TreeViewSchema.Location = new System.Drawing.Point(477, 94);
            this.TreeViewSchema.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TreeViewSchema.Name = "TreeViewSchema";
            this.TreeViewSchema.Size = new System.Drawing.Size(208, 77);
            this.TreeViewSchema.TabIndex = 14;
            this.TreeViewSchema.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.TreeViewSchemaAfterCheck);
            this.TreeViewSchema.MouseLeave += new System.EventHandler(this.TreeViewSchemaMouseLeave);
            // 
            // TreeViewEnObj
            // 
            this.TreeViewEnObj.Location = new System.Drawing.Point(243, 94);
            this.TreeViewEnObj.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TreeViewEnObj.Name = "TreeViewEnObj";
            this.TreeViewEnObj.Size = new System.Drawing.Size(297, 77);
            this.TreeViewEnObj.TabIndex = 12;
            this.TreeViewEnObj.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.TreeViewEnObjAfterCheck);
            this.TreeViewEnObj.MouseLeave += new System.EventHandler(this.TreeViewEnObjMouseLeave);
            // 
            // DatabaseEditorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1093, 639);
            this.Controls.Add(this.TreeViewVoltage);
            this.Controls.Add(this.TreeViewEnObj);
            this.Controls.Add(this.TreeViewSchema);
            this.Controls.Add(this.TreeViewRegType);
            this.Controls.Add(this.groupBoxFilter);
            this.Controls.Add(this.LoadDataFromDb);
            this.Controls.Add(this.LoadDataIntoDB);
            this.Controls.Add(this.DataExportFromDB);
            this.Controls.Add(this.ImportFromCSV);
            this.Controls.Add(this.groupBoxDB);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.Name = "DatabaseEditorForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Работа с базой данных";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DatabaseEditorFormClosing);
            this.Load += new System.EventHandler(this.DatabaseEditorFormLoad);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDB)).EndInit();
            this.groupBoxDB.ResumeLayout(false);
            this.groupBoxFilter.ResumeLayout(false);
            this.groupBoxFilter.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewDB;
        private System.Windows.Forms.GroupBox groupBoxDB;
        private System.Windows.Forms.Button ImportFromCSV;
        private System.Windows.Forms.Button DataExportFromDB;
        private System.Windows.Forms.Button LoadDataIntoDB;
        private System.Windows.Forms.Button LoadDataFromDb;
        private System.Windows.Forms.TreeView TreeViewVoltage;
        private System.Windows.Forms.Button ButtonVoltage;
        private System.Windows.Forms.GroupBox groupBoxFilter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button ButtonRegType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TreeView TreeViewRegType;
        private System.Windows.Forms.Button ButtonClearFilter;
        private System.Windows.Forms.Button ButtonEnergyObj;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button ButtonSchema;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TreeView TreeViewSchema;
        private System.Windows.Forms.TreeView TreeViewEnObj;
    }
}