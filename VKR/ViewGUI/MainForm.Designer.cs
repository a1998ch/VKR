
namespace ViewGUI
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.Start = new System.Windows.Forms.ToolStripMenuItem();
            this.StartSystem = new System.Windows.Forms.ToolStripMenuItem();
            this.StopSystem = new System.Windows.Forms.ToolStripMenuItem();
            this.SystemDB = new System.Windows.Forms.ToolStripMenuItem();
            this.ConnectDB = new System.Windows.Forms.ToolStripMenuItem();
            this.AddEditDataDB = new System.Windows.Forms.ToolStripMenuItem();
            this.ExternalSystems = new System.Windows.Forms.ToolStripMenuItem();
            this.OikDB = new System.Windows.Forms.ToolStripMenuItem();
            this.CalcRastrWin3 = new System.Windows.Forms.ToolStripMenuItem();
            this.Documentation = new System.Windows.Forms.ToolStripMenuItem();
            this.AboutProg = new System.Windows.Forms.ToolStripMenuItem();
            this.Manual = new System.Windows.Forms.ToolStripMenuItem();
            this.CheckedListBoxEnObj = new System.Windows.Forms.CheckedListBox();
            this.AddEnObjButton = new System.Windows.Forms.Button();
            this.SelectionOfRequestedData = new System.Windows.Forms.Button();
            this.ChoiceOfSchema = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Start,
            this.SystemDB,
            this.ExternalSystems,
            this.Documentation});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(570, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // Start
            // 
            this.Start.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StartSystem,
            this.StopSystem});
            this.Start.Name = "Start";
            this.Start.Size = new System.Drawing.Size(69, 24);
            this.Start.Text = "Запуск";
            // 
            // StartSystem
            // 
            this.StartSystem.Name = "StartSystem";
            this.StartSystem.Size = new System.Drawing.Size(234, 26);
            this.StartSystem.Text = "Запустить Систему";
            this.StartSystem.Click += new System.EventHandler(this.StartSystemClick);
            // 
            // StopSystem
            // 
            this.StopSystem.Name = "StopSystem";
            this.StopSystem.Size = new System.Drawing.Size(234, 26);
            this.StopSystem.Text = "Остановить Систему";
            this.StopSystem.Click += new System.EventHandler(this.StopSystemClick);
            // 
            // SystemDB
            // 
            this.SystemDB.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ConnectDB,
            this.AddEditDataDB});
            this.SystemDB.Name = "SystemDB";
            this.SystemDB.Size = new System.Drawing.Size(176, 24);
            this.SystemDB.Text = "База данных Системы";
            // 
            // ConnectDB
            // 
            this.ConnectDB.Name = "ConnectDB";
            this.ConnectDB.Size = new System.Drawing.Size(359, 26);
            this.ConnectDB.Text = "Подключение к БД";
            this.ConnectDB.Click += new System.EventHandler(this.ConnectDBClick);
            // 
            // AddEditDataDB
            // 
            this.AddEditDataDB.Name = "AddEditDataDB";
            this.AddEditDataDB.Size = new System.Drawing.Size(359, 26);
            this.AddEditDataDB.Text = "Добавить/Редактировать данные в БД";
            this.AddEditDataDB.Click += new System.EventHandler(this.AddEditDataDBClick);
            // 
            // ExternalSystems
            // 
            this.ExternalSystems.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OikDB,
            this.CalcRastrWin3});
            this.ExternalSystems.Name = "ExternalSystems";
            this.ExternalSystems.Size = new System.Drawing.Size(152, 24);
            this.ExternalSystems.Text = "Внешние Системы";
            // 
            // OikDB
            // 
            this.OikDB.Name = "OikDB";
            this.OikDB.Size = new System.Drawing.Size(289, 26);
            this.OikDB.Text = "БД ОИК \"СК-11\"";
            this.OikDB.Click += new System.EventHandler(this.OikDBClick);
            // 
            // CalcRastrWin3
            // 
            this.CalcRastrWin3.Name = "CalcRastrWin3";
            this.CalcRastrWin3.Size = new System.Drawing.Size(289, 26);
            this.CalcRastrWin3.Text = "Расчётная модель RastrWin3";
            this.CalcRastrWin3.Click += new System.EventHandler(this.CalcRastrWin3Click);
            // 
            // Documentation
            // 
            this.Documentation.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AboutProg,
            this.Manual});
            this.Documentation.Name = "Documentation";
            this.Documentation.Size = new System.Drawing.Size(81, 24);
            this.Documentation.Text = "Справка";
            // 
            // AboutProg
            // 
            this.AboutProg.Name = "AboutProg";
            this.AboutProg.Size = new System.Drawing.Size(278, 26);
            this.AboutProg.Text = "О программе";
            // 
            // Manual
            // 
            this.Manual.Name = "Manual";
            this.Manual.Size = new System.Drawing.Size(278, 26);
            this.Manual.Text = "Руководство пользователя";
            // 
            // CheckedListBoxEnObj
            // 
            this.CheckedListBoxEnObj.FormattingEnabled = true;
            this.CheckedListBoxEnObj.Location = new System.Drawing.Point(12, 42);
            this.CheckedListBoxEnObj.Name = "CheckedListBoxEnObj";
            this.CheckedListBoxEnObj.Size = new System.Drawing.Size(316, 364);
            this.CheckedListBoxEnObj.TabIndex = 2;
            this.CheckedListBoxEnObj.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.CheckedListBoxEnObjItemCheck);
            // 
            // AddEnObjButton
            // 
            this.AddEnObjButton.Location = new System.Drawing.Point(362, 42);
            this.AddEnObjButton.Name = "AddEnObjButton";
            this.AddEnObjButton.Size = new System.Drawing.Size(171, 47);
            this.AddEnObjButton.TabIndex = 3;
            this.AddEnObjButton.Text = "Добавить объект электроэнергетики";
            this.AddEnObjButton.UseVisualStyleBackColor = true;
            this.AddEnObjButton.Click += new System.EventHandler(this.AddEnObjButtonClick);
            // 
            // SelectionOfRequestedData
            // 
            this.SelectionOfRequestedData.Location = new System.Drawing.Point(362, 116);
            this.SelectionOfRequestedData.Name = "SelectionOfRequestedData";
            this.SelectionOfRequestedData.Size = new System.Drawing.Size(171, 54);
            this.SelectionOfRequestedData.TabIndex = 4;
            this.SelectionOfRequestedData.Text = "Выбор запрашиваемых данных";
            this.SelectionOfRequestedData.UseVisualStyleBackColor = true;
            this.SelectionOfRequestedData.Click += new System.EventHandler(this.SelectionOfRequestedDataClick);
            // 
            // ChoiceOfSchema
            // 
            this.ChoiceOfSchema.Location = new System.Drawing.Point(362, 195);
            this.ChoiceOfSchema.Name = "ChoiceOfSchema";
            this.ChoiceOfSchema.Size = new System.Drawing.Size(171, 51);
            this.ChoiceOfSchema.TabIndex = 5;
            this.ChoiceOfSchema.Text = "Выбор схемно-режимной ситуации";
            this.ChoiceOfSchema.UseVisualStyleBackColor = true;
            this.ChoiceOfSchema.Click += new System.EventHandler(this.ChoiceOfSchemaClick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(570, 421);
            this.Controls.Add(this.ChoiceOfSchema);
            this.Controls.Add(this.SelectionOfRequestedData);
            this.Controls.Add(this.AddEnObjButton);
            this.Controls.Add(this.CheckedListBoxEnObj);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainFormLoad);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem Start;
        private System.Windows.Forms.ToolStripMenuItem StopSystem;
        private System.Windows.Forms.ToolStripMenuItem StartSystem;
        private System.Windows.Forms.ToolStripMenuItem SystemDB;
        private System.Windows.Forms.ToolStripMenuItem ConnectDB;
        private System.Windows.Forms.ToolStripMenuItem AddEditDataDB;
        private System.Windows.Forms.ToolStripMenuItem Documentation;
        private System.Windows.Forms.ToolStripMenuItem AboutProg;
        private System.Windows.Forms.ToolStripMenuItem Manual;
        private System.Windows.Forms.ToolStripMenuItem ExternalSystems;
        private System.Windows.Forms.ToolStripMenuItem CalcRastrWin3;
        private System.Windows.Forms.ToolStripMenuItem OikDB;
        private System.Windows.Forms.CheckedListBox CheckedListBoxEnObj;
        private System.Windows.Forms.Button AddEnObjButton;
        private System.Windows.Forms.Button SelectionOfRequestedData;
        private System.Windows.Forms.Button ChoiceOfSchema;
    }
}

