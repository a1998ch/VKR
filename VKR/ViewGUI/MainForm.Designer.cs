
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
            this.DatabaseDataImport = new System.Windows.Forms.ToolStripMenuItem();
            this.ExternalSystems = new System.Windows.Forms.ToolStripMenuItem();
            this.бДРВОИКСК11ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.расчётнаяМодельRastrWin3ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Documentation = new System.Windows.Forms.ToolStripMenuItem();
            this.AboutProg = new System.Windows.Forms.ToolStripMenuItem();
            this.Manual = new System.Windows.Forms.ToolStripMenuItem();
            this.textBox1 = new System.Windows.Forms.TextBox();
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
            this.menuStrip1.Size = new System.Drawing.Size(760, 28);
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
            // 
            // SystemDB
            // 
            this.SystemDB.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ConnectDB,
            this.AddEditDataDB,
            this.DatabaseDataImport});
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
            // 
            // DatabaseDataImport
            // 
            this.DatabaseDataImport.Name = "DatabaseDataImport";
            this.DatabaseDataImport.Size = new System.Drawing.Size(359, 26);
            this.DatabaseDataImport.Text = "Импорт данных БД";
            this.DatabaseDataImport.Click += new System.EventHandler(this.DatabaseDataImportClick);
            // 
            // ExternalSystems
            // 
            this.ExternalSystems.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.бДРВОИКСК11ToolStripMenuItem,
            this.расчётнаяМодельRastrWin3ToolStripMenuItem});
            this.ExternalSystems.Name = "ExternalSystems";
            this.ExternalSystems.Size = new System.Drawing.Size(152, 24);
            this.ExternalSystems.Text = "Внешние Системы";
            // 
            // бДРВОИКСК11ToolStripMenuItem
            // 
            this.бДРВОИКСК11ToolStripMenuItem.Name = "бДРВОИКСК11ToolStripMenuItem";
            this.бДРВОИКСК11ToolStripMenuItem.Size = new System.Drawing.Size(289, 26);
            this.бДРВОИКСК11ToolStripMenuItem.Text = "БДРВ ОИК \"СК-11\"";
            // 
            // расчётнаяМодельRastrWin3ToolStripMenuItem
            // 
            this.расчётнаяМодельRastrWin3ToolStripMenuItem.Name = "расчётнаяМодельRastrWin3ToolStripMenuItem";
            this.расчётнаяМодельRastrWin3ToolStripMenuItem.Size = new System.Drawing.Size(289, 26);
            this.расчётнаяМодельRastrWin3ToolStripMenuItem.Text = "Расчётная модель RastrWin3";
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
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(24, 45);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(723, 436);
            this.textBox1.TabIndex = 1;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(760, 518);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
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
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ToolStripMenuItem DatabaseDataImport;
        private System.Windows.Forms.ToolStripMenuItem ExternalSystems;
        private System.Windows.Forms.ToolStripMenuItem бДРВОИКСК11ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem расчётнаяМодельRastrWin3ToolStripMenuItem;
    }
}

