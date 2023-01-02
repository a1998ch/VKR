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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DatabaseEditorForm));
            this.dataGridViewDB = new System.Windows.Forms.DataGridView();
            this.groupBoxDB = new System.Windows.Forms.GroupBox();
            this.TreeViewVoltage = new System.Windows.Forms.TreeView();
            this.ButtonVoltage = new System.Windows.Forms.Button();
            this.ImportFromCSV = new System.Windows.Forms.Button();
            this.DataExportFromDB = new System.Windows.Forms.Button();
            this.LoadDataIntoDB = new System.Windows.Forms.Button();
            this.LoadDataFromDb = new System.Windows.Forms.Button();
            this.dataBaseDataSet = new ViewGUI.DataBaseDataSet();
            this.dataBaseDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.energyobjectBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.energy_objectTableAdapter = new ViewGUI.DataBaseDataSetTableAdapters.Energy_objectTableAdapter();
            this.schemadataBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.schema_dataTableAdapter = new ViewGUI.DataBaseDataSetTableAdapters.Schema_dataTableAdapter();
            this.groupBoxFilter = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDB)).BeginInit();
            this.groupBoxDB.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataBaseDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataBaseDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.energyobjectBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.schemadataBindingSource)).BeginInit();
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
            this.TreeViewVoltage.Location = new System.Drawing.Point(254, 95);
            this.TreeViewVoltage.Name = "TreeViewVoltage";
            this.TreeViewVoltage.Size = new System.Drawing.Size(92, 86);
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
            this.ButtonVoltage.Location = new System.Drawing.Point(226, 14);
            this.ButtonVoltage.Name = "ButtonVoltage";
            this.ButtonVoltage.Size = new System.Drawing.Size(23, 19);
            this.ButtonVoltage.TabIndex = 7;
            this.ButtonVoltage.UseVisualStyleBackColor = false;
            this.ButtonVoltage.Click += new System.EventHandler(this.ButtonVoltageClick);
            // 
            // ImportFromCSV
            // 
            this.ImportFromCSV.Location = new System.Drawing.Point(35, 12);
            this.ImportFromCSV.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ImportFromCSV.Name = "ImportFromCSV";
            this.ImportFromCSV.Size = new System.Drawing.Size(165, 42);
            this.ImportFromCSV.TabIndex = 2;
            this.ImportFromCSV.Text = "Импорт данных из csv";
            this.ImportFromCSV.UseVisualStyleBackColor = true;
            this.ImportFromCSV.Click += new System.EventHandler(this.ImportFromCSVClick);
            // 
            // DataExportFromDB
            // 
            this.DataExportFromDB.Location = new System.Drawing.Point(228, 10);
            this.DataExportFromDB.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.DataExportFromDB.Name = "DataExportFromDB";
            this.DataExportFromDB.Size = new System.Drawing.Size(155, 41);
            this.DataExportFromDB.TabIndex = 3;
            this.DataExportFromDB.Text = "Экспорт в csv";
            this.DataExportFromDB.UseVisualStyleBackColor = true;
            this.DataExportFromDB.Click += new System.EventHandler(this.DataExportFromDBClick);
            // 
            // LoadDataIntoDB
            // 
            this.LoadDataIntoDB.Location = new System.Drawing.Point(411, 11);
            this.LoadDataIntoDB.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.LoadDataIntoDB.Name = "LoadDataIntoDB";
            this.LoadDataIntoDB.Size = new System.Drawing.Size(259, 39);
            this.LoadDataIntoDB.TabIndex = 4;
            this.LoadDataIntoDB.Text = "Добавить данные в БД";
            this.LoadDataIntoDB.UseVisualStyleBackColor = true;
            this.LoadDataIntoDB.Click += new System.EventHandler(this.LoadDataIntoDBClick);
            // 
            // LoadDataFromDb
            // 
            this.LoadDataFromDb.Location = new System.Drawing.Point(689, 10);
            this.LoadDataFromDb.Margin = new System.Windows.Forms.Padding(4);
            this.LoadDataFromDb.Name = "LoadDataFromDb";
            this.LoadDataFromDb.Size = new System.Drawing.Size(207, 37);
            this.LoadDataFromDb.TabIndex = 5;
            this.LoadDataFromDb.Text = "Загрузить данные из бд";
            this.LoadDataFromDb.UseVisualStyleBackColor = true;
            this.LoadDataFromDb.Click += new System.EventHandler(this.LoadDataFromDbClick);
            // 
            // dataBaseDataSet
            // 
            this.dataBaseDataSet.DataSetName = "DataBaseDataSet";
            this.dataBaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dataBaseDataSetBindingSource
            // 
            this.dataBaseDataSetBindingSource.DataSource = this.dataBaseDataSet;
            this.dataBaseDataSetBindingSource.Position = 0;
            // 
            // energyobjectBindingSource
            // 
            this.energyobjectBindingSource.DataMember = "Energy_object";
            this.energyobjectBindingSource.DataSource = this.dataBaseDataSetBindingSource;
            // 
            // energy_objectTableAdapter
            // 
            this.energy_objectTableAdapter.ClearBeforeFill = true;
            // 
            // schemadataBindingSource
            // 
            this.schemadataBindingSource.DataMember = "Schema_data";
            this.schemadataBindingSource.DataSource = this.dataBaseDataSetBindingSource;
            // 
            // schema_dataTableAdapter
            // 
            this.schema_dataTableAdapter.ClearBeforeFill = true;
            // 
            // groupBoxFilter
            // 
            this.groupBoxFilter.Controls.Add(this.label1);
            this.groupBoxFilter.Controls.Add(this.ButtonVoltage);
            this.groupBoxFilter.Location = new System.Drawing.Point(12, 74);
            this.groupBoxFilter.Name = "groupBoxFilter";
            this.groupBoxFilter.Size = new System.Drawing.Size(1069, 39);
            this.groupBoxFilter.TabIndex = 6;
            this.groupBoxFilter.TabStop = false;
            this.groupBoxFilter.Text = "Фильтр";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(63, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(148, 16);
            this.label1.TabIndex = 8;
            this.label1.Text = "Уровень напряжения:";
            // 
            // DatabaseEditorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1093, 639);
            this.Controls.Add(this.TreeViewVoltage);
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
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DatabaseEditorForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DatabaseEditorFormClosing);
            this.Load += new System.EventHandler(this.DatabaseEditorFormLoad);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDB)).EndInit();
            this.groupBoxDB.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataBaseDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataBaseDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.energyobjectBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.schemadataBindingSource)).EndInit();
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
        private System.Windows.Forms.BindingSource dataBaseDataSetBindingSource;
        private DataBaseDataSet dataBaseDataSet;
        private System.Windows.Forms.BindingSource energyobjectBindingSource;
        private DataBaseDataSetTableAdapters.Energy_objectTableAdapter energy_objectTableAdapter;
        private System.Windows.Forms.BindingSource schemadataBindingSource;
        private DataBaseDataSetTableAdapters.Schema_dataTableAdapter schema_dataTableAdapter;
        private System.Windows.Forms.GroupBox groupBoxFilter;
        private System.Windows.Forms.Label label1;
    }
}