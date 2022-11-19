
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
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemSave = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemBD = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemExit = new System.Windows.Forms.ToolStripMenuItem();
            this.расчётToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemCalc = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemConnectBD = new System.Windows.Forms.ToolStripMenuItem();
            this.справкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemAboutProg = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemManual = new System.Windows.Forms.ToolStripMenuItem();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.расчётToolStripMenuItem,
            this.справкаToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(760, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItemSave,
            this.ToolStripMenuItemBD,
            this.ToolStripMenuItemExit});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(59, 24);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // ToolStripMenuItemSave
            // 
            this.ToolStripMenuItemSave.Name = "ToolStripMenuItemSave";
            this.ToolStripMenuItemSave.Size = new System.Drawing.Size(264, 26);
            this.ToolStripMenuItemSave.Text = "Сохранить как...";
            // 
            // ToolStripMenuItemBD
            // 
            this.ToolStripMenuItemBD.Name = "ToolStripMenuItemBD";
            this.ToolStripMenuItemBD.Size = new System.Drawing.Size(264, 26);
            this.ToolStripMenuItemBD.Text = "Выгрузить данные из БД";
            this.ToolStripMenuItemBD.Click += new System.EventHandler(this.ToolStripMenuItemBDClick);
            // 
            // ToolStripMenuItemExit
            // 
            this.ToolStripMenuItemExit.Name = "ToolStripMenuItemExit";
            this.ToolStripMenuItemExit.Size = new System.Drawing.Size(264, 26);
            this.ToolStripMenuItemExit.Text = "Выход";
            // 
            // расчётToolStripMenuItem
            // 
            this.расчётToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItemCalc,
            this.ToolStripMenuItemAdd,
            this.ToolStripMenuItemConnectBD});
            this.расчётToolStripMenuItem.Name = "расчётToolStripMenuItem";
            this.расчётToolStripMenuItem.Size = new System.Drawing.Size(68, 24);
            this.расчётToolStripMenuItem.Text = "Расчёт";
            // 
            // ToolStripMenuItemCalc
            // 
            this.ToolStripMenuItemCalc.Name = "ToolStripMenuItemCalc";
            this.ToolStripMenuItemCalc.Size = new System.Drawing.Size(270, 26);
            this.ToolStripMenuItemCalc.Text = "Запустить расчёт";
            this.ToolStripMenuItemCalc.Click += new System.EventHandler(this.ToolStripMenuItemCalcClick);
            // 
            // ToolStripMenuItemAdd
            // 
            this.ToolStripMenuItemAdd.Name = "ToolStripMenuItemAdd";
            this.ToolStripMenuItemAdd.Size = new System.Drawing.Size(270, 26);
            this.ToolStripMenuItemAdd.Text = "Добавить новый элемент";
            // 
            // ToolStripMenuItemConnectBD
            // 
            this.ToolStripMenuItemConnectBD.Name = "ToolStripMenuItemConnectBD";
            this.ToolStripMenuItemConnectBD.Size = new System.Drawing.Size(270, 26);
            this.ToolStripMenuItemConnectBD.Text = "Подключить БД";
            this.ToolStripMenuItemConnectBD.Click += new System.EventHandler(this.ToolStripMenuItemConnectBDClick);
            // 
            // справкаToolStripMenuItem
            // 
            this.справкаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItemAboutProg,
            this.ToolStripMenuItemManual});
            this.справкаToolStripMenuItem.Name = "справкаToolStripMenuItem";
            this.справкаToolStripMenuItem.Size = new System.Drawing.Size(81, 24);
            this.справкаToolStripMenuItem.Text = "Справка";
            // 
            // ToolStripMenuItemAboutProg
            // 
            this.ToolStripMenuItemAboutProg.Name = "ToolStripMenuItemAboutProg";
            this.ToolStripMenuItemAboutProg.Size = new System.Drawing.Size(278, 26);
            this.ToolStripMenuItemAboutProg.Text = "О программе";
            // 
            // ToolStripMenuItemManual
            // 
            this.ToolStripMenuItemManual.Name = "ToolStripMenuItemManual";
            this.ToolStripMenuItemManual.Size = new System.Drawing.Size(278, 26);
            this.ToolStripMenuItemManual.Text = "Руководство пользователя";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(24, 45);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(259, 82);
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
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemBD;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemSave;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemExit;
        private System.Windows.Forms.ToolStripMenuItem расчётToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemCalc;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemAdd;
        private System.Windows.Forms.ToolStripMenuItem справкаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemAboutProg;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemManual;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemConnectBD;
    }
}

