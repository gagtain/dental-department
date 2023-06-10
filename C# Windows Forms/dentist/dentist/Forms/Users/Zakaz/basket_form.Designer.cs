namespace kursach
{
    partial class basket_form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(basket_form));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.аккаунтToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.моиДанныеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выйтиИзАккаунтаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.оНасToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.менюУслугToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.заказыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.админПанельToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.отделенияToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.списокToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.добавитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.стоматологиToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.списокToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.добавитьToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.сервисыToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.списокToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.добавитьToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.аккаунтToolStripMenuItem,
            this.оНасToolStripMenuItem,
            this.менюУслугToolStripMenuItem,
            this.заказыToolStripMenuItem,
            this.админПанельToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(896, 29);
            this.menuStrip1.TabIndex = 12;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // аккаунтToolStripMenuItem
            // 
            this.аккаунтToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.моиДанныеToolStripMenuItem,
            this.выйтиИзАккаунтаToolStripMenuItem});
            this.аккаунтToolStripMenuItem.Name = "аккаунтToolStripMenuItem";
            this.аккаунтToolStripMenuItem.Size = new System.Drawing.Size(75, 25);
            this.аккаунтToolStripMenuItem.Text = "Аккаунт";
            // 
            // моиДанныеToolStripMenuItem
            // 
            this.моиДанныеToolStripMenuItem.Name = "моиДанныеToolStripMenuItem";
            this.моиДанныеToolStripMenuItem.Size = new System.Drawing.Size(206, 24);
            this.моиДанныеToolStripMenuItem.Text = "Мои данные";
            this.моиДанныеToolStripMenuItem.Click += new System.EventHandler(this.моиДанныеToolStripMenuItem_Click);
            // 
            // выйтиИзАккаунтаToolStripMenuItem
            // 
            this.выйтиИзАккаунтаToolStripMenuItem.Name = "выйтиИзАккаунтаToolStripMenuItem";
            this.выйтиИзАккаунтаToolStripMenuItem.Size = new System.Drawing.Size(206, 24);
            this.выйтиИзАккаунтаToolStripMenuItem.Text = "Выйти из аккаунта";
            this.выйтиИзАккаунтаToolStripMenuItem.Click += new System.EventHandler(this.выйтиИзАккаунтаToolStripMenuItem_Click);
            // 
            // оНасToolStripMenuItem
            // 
            this.оНасToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.оНасToolStripMenuItem.Name = "оНасToolStripMenuItem";
            this.оНасToolStripMenuItem.Size = new System.Drawing.Size(62, 25);
            this.оНасToolStripMenuItem.Text = "О нас";
            this.оНасToolStripMenuItem.Click += new System.EventHandler(this.оНасToolStripMenuItem_Click);
            // 
            // менюУслугToolStripMenuItem
            // 
            this.менюУслугToolStripMenuItem.Name = "менюУслугToolStripMenuItem";
            this.менюУслугToolStripMenuItem.Size = new System.Drawing.Size(102, 25);
            this.менюУслугToolStripMenuItem.Text = "Меню услуг";
            this.менюУслугToolStripMenuItem.Click += new System.EventHandler(this.менюУслугToolStripMenuItem_Click);
            // 
            // заказыToolStripMenuItem
            // 
            this.заказыToolStripMenuItem.Name = "заказыToolStripMenuItem";
            this.заказыToolStripMenuItem.Size = new System.Drawing.Size(70, 25);
            this.заказыToolStripMenuItem.Text = "Заказы";
            this.заказыToolStripMenuItem.Click += new System.EventHandler(this.заказыToolStripMenuItem_Click);
            // 
            // админПанельToolStripMenuItem
            // 
            this.админПанельToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.отделенияToolStripMenuItem1,
            this.стоматологиToolStripMenuItem1,
            this.сервисыToolStripMenuItem1});
            this.админПанельToolStripMenuItem.Name = "админПанельToolStripMenuItem";
            this.админПанельToolStripMenuItem.Size = new System.Drawing.Size(122, 25);
            this.админПанельToolStripMenuItem.Text = "Админ панель";
            // 
            // отделенияToolStripMenuItem1
            // 
            this.отделенияToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.списокToolStripMenuItem,
            this.добавитьToolStripMenuItem});
            this.отделенияToolStripMenuItem1.Name = "отделенияToolStripMenuItem1";
            this.отделенияToolStripMenuItem1.Size = new System.Drawing.Size(166, 24);
            this.отделенияToolStripMenuItem1.Text = "отделения";
            // 
            // списокToolStripMenuItem
            // 
            this.списокToolStripMenuItem.Name = "списокToolStripMenuItem";
            this.списокToolStripMenuItem.Size = new System.Drawing.Size(143, 24);
            this.списокToolStripMenuItem.Text = "список";
            this.списокToolStripMenuItem.Click += new System.EventHandler(this.списокToolStripMenuItem_Click);
            // 
            // добавитьToolStripMenuItem
            // 
            this.добавитьToolStripMenuItem.Name = "добавитьToolStripMenuItem";
            this.добавитьToolStripMenuItem.Size = new System.Drawing.Size(143, 24);
            this.добавитьToolStripMenuItem.Text = "добавить";
            this.добавитьToolStripMenuItem.Click += new System.EventHandler(this.добавитьToolStripMenuItem_Click);
            // 
            // стоматологиToolStripMenuItem1
            // 
            this.стоматологиToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.списокToolStripMenuItem1,
            this.добавитьToolStripMenuItem1});
            this.стоматологиToolStripMenuItem1.Name = "стоматологиToolStripMenuItem1";
            this.стоматологиToolStripMenuItem1.Size = new System.Drawing.Size(166, 24);
            this.стоматологиToolStripMenuItem1.Text = "стоматологи";
            // 
            // списокToolStripMenuItem1
            // 
            this.списокToolStripMenuItem1.Name = "списокToolStripMenuItem1";
            this.списокToolStripMenuItem1.Size = new System.Drawing.Size(143, 24);
            this.списокToolStripMenuItem1.Text = "список";
            this.списокToolStripMenuItem1.Click += new System.EventHandler(this.списокToolStripMenuItem1_Click);
            // 
            // добавитьToolStripMenuItem1
            // 
            this.добавитьToolStripMenuItem1.Name = "добавитьToolStripMenuItem1";
            this.добавитьToolStripMenuItem1.Size = new System.Drawing.Size(143, 24);
            this.добавитьToolStripMenuItem1.Text = "добавить";
            this.добавитьToolStripMenuItem1.Click += new System.EventHandler(this.добавитьToolStripMenuItem1_Click);
            // 
            // сервисыToolStripMenuItem1
            // 
            this.сервисыToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.списокToolStripMenuItem2,
            this.добавитьToolStripMenuItem2});
            this.сервисыToolStripMenuItem1.Name = "сервисыToolStripMenuItem1";
            this.сервисыToolStripMenuItem1.Size = new System.Drawing.Size(166, 24);
            this.сервисыToolStripMenuItem1.Text = "сервисы";
            // 
            // списокToolStripMenuItem2
            // 
            this.списокToolStripMenuItem2.Name = "списокToolStripMenuItem2";
            this.списокToolStripMenuItem2.Size = new System.Drawing.Size(143, 24);
            this.списокToolStripMenuItem2.Text = "список";
            this.списокToolStripMenuItem2.Click += new System.EventHandler(this.списокToolStripMenuItem2_Click);
            // 
            // добавитьToolStripMenuItem2
            // 
            this.добавитьToolStripMenuItem2.Name = "добавитьToolStripMenuItem2";
            this.добавитьToolStripMenuItem2.Size = new System.Drawing.Size(143, 24);
            this.добавитьToolStripMenuItem2.Text = "добавить";
            this.добавитьToolStripMenuItem2.Click += new System.EventHandler(this.добавитьToolStripMenuItem2_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(653, 39);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(170, 53);
            this.button1.TabIndex = 13;
            this.button1.Text = "Оформить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(269, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(154, 24);
            this.label1.TabIndex = 14;
            this.label1.Text = "Сумма корзины:";
            // 
            // basket_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(896, 561);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.menuStrip1);
            this.Name = "basket_form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Корзина";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form5_FormClosed);
            this.Load += new System.EventHandler(this.Form5_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem аккаунтToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem моиДанныеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem выйтиИзАккаунтаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem оНасToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem менюУслугToolStripMenuItem;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem заказыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem админПанельToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem отделенияToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem списокToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem добавитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem стоматологиToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem списокToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem добавитьToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem сервисыToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem списокToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem добавитьToolStripMenuItem2;
    }
}