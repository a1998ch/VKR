
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
            this.справкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemAboutProg = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemManual = new System.Windows.Forms.ToolStripMenuItem();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.расчётToolStripMenuItem,
            this.справкаToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(362, 24);
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
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // ToolStripMenuItemSave
            // 
            this.ToolStripMenuItemSave.Name = "ToolStripMenuItemSave";
            this.ToolStripMenuItemSave.Size = new System.Drawing.Size(208, 22);
            this.ToolStripMenuItemSave.Text = "Сохранить как...";
            // 
            // ToolStripMenuItemBD
            // 
            this.ToolStripMenuItemBD.Name = "ToolStripMenuItemBD";
            this.ToolStripMenuItemBD.Size = new System.Drawing.Size(208, 22);
            this.ToolStripMenuItemBD.Text = "Выгрузить данные из БД";
            this.ToolStripMenuItemBD.Click += new System.EventHandler(this.ToolStripMenuItemBDClick);
            // 
            // ToolStripMenuItemExit
            // 
            this.ToolStripMenuItemExit.Name = "ToolStripMenuItemExit";
            this.ToolStripMenuItemExit.Size = new System.Drawing.Size(208, 22);
            this.ToolStripMenuItemExit.Text = "Выход";
            // 
            // расчётToolStripMenuItem
            // 
            this.расчётToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItemCalc,
            this.ToolStripMenuItemAdd});
            this.расчётToolStripMenuItem.Name = "расчётToolStripMenuItem";
            this.расчётToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.расчётToolStripMenuItem.Text = "Расчёт";
            // 
            // ToolStripMenuItemCalc
            // 
            this.ToolStripMenuItemCalc.Name = "ToolStripMenuItemCalc";
            this.ToolStripMenuItemCalc.Size = new System.Drawing.Size(214, 22);
            this.ToolStripMenuItemCalc.Text = "Запустить расчёт";
            this.ToolStripMenuItemCalc.Click += new System.EventHandler(this.ToolStripMenuItemCalcClick);
            // 
            // ToolStripMenuItemAdd
            // 
            this.ToolStripMenuItemAdd.Name = "ToolStripMenuItemAdd";
            this.ToolStripMenuItemAdd.Size = new System.Drawing.Size(214, 22);
            this.ToolStripMenuItemAdd.Text = "Добавить новый элемент";
            // 
            // справкаToolStripMenuItem
            // 
            this.справкаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItemAboutProg,
            this.ToolStripMenuItemManual});
            this.справкаToolStripMenuItem.Name = "справкаToolStripMenuItem";
            this.справкаToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.справкаToolStripMenuItem.Text = "Справка";
            // 
            // ToolStripMenuItemAboutProg
            // 
            this.ToolStripMenuItemAboutProg.Name = "ToolStripMenuItemAboutProg";
            this.ToolStripMenuItemAboutProg.Size = new System.Drawing.Size(221, 22);
            this.ToolStripMenuItemAboutProg.Text = "О программе";
            // 
            // ToolStripMenuItemManual
            // 
            this.ToolStripMenuItemManual.Name = "ToolStripMenuItemManual";
            this.ToolStripMenuItemManual.Size = new System.Drawing.Size(221, 22);
            this.ToolStripMenuItemManual.Text = "Руководство пользователя";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(59, 36);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(195, 67);
            this.textBox1.TabIndex = 1;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(362, 154);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
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
    }
}

