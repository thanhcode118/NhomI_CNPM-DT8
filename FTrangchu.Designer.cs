namespace WinFormsAppCK
{
    partial class FTrangchu
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
            panel1 = new Panel();
            menuStrip1 = new MenuStrip();
            chiTiếtVềCuộcThithôngTinLịchThiĐấuToolStripMenuItem = new ToolStripMenuItem();
            giảiThưởngToolStripMenuItem = new ToolStripMenuItem();
            luậtThiĐấuToolStripMenuItem = new ToolStripMenuItem();
            tiêuChíChấmĐiểmToolStripMenuItem = new ToolStripMenuItem();
            tinTứcLiênQuanToolStripMenuItem = new ToolStripMenuItem();
            menuStrip2 = new MenuStrip();
            label1 = new Label();
            panel1.SuspendLayout();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(label1);
            panel1.Controls.Add(menuStrip2);
            panel1.Location = new Point(0, 27);
            panel1.Name = "panel1";
            panel1.Size = new Size(1079, 477);
            panel1.TabIndex = 0;
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { chiTiếtVềCuộcThithôngTinLịchThiĐấuToolStripMenuItem, giảiThưởngToolStripMenuItem, luậtThiĐấuToolStripMenuItem, tiêuChíChấmĐiểmToolStripMenuItem, tinTứcLiênQuanToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1079, 28);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            // 
            // chiTiếtVềCuộcThithôngTinLịchThiĐấuToolStripMenuItem
            // 
            chiTiếtVềCuộcThithôngTinLịchThiĐấuToolStripMenuItem.Name = "chiTiếtVềCuộcThithôngTinLịchThiĐấuToolStripMenuItem";
            chiTiếtVềCuộcThithôngTinLịchThiĐấuToolStripMenuItem.Size = new Size(299, 24);
            chiTiếtVềCuộcThithôngTinLịchThiĐấuToolStripMenuItem.Text = "Chi tiết về cuộc thi (thông tin, lịch thi đấu)";
            // 
            // giảiThưởngToolStripMenuItem
            // 
            giảiThưởngToolStripMenuItem.Name = "giảiThưởngToolStripMenuItem";
            giảiThưởngToolStripMenuItem.Size = new Size(101, 24);
            giảiThưởngToolStripMenuItem.Text = "Giải thưởng";
            // 
            // luậtThiĐấuToolStripMenuItem
            // 
            luậtThiĐấuToolStripMenuItem.Name = "luậtThiĐấuToolStripMenuItem";
            luậtThiĐấuToolStripMenuItem.Size = new Size(101, 24);
            luậtThiĐấuToolStripMenuItem.Text = "Luật thi đấu";
            // 
            // tiêuChíChấmĐiểmToolStripMenuItem
            // 
            tiêuChíChấmĐiểmToolStripMenuItem.Name = "tiêuChíChấmĐiểmToolStripMenuItem";
            tiêuChíChấmĐiểmToolStripMenuItem.Size = new Size(152, 24);
            tiêuChíChấmĐiểmToolStripMenuItem.Text = "Tiêu chí chấm điểm";
            // 
            // tinTứcLiênQuanToolStripMenuItem
            // 
            tinTứcLiênQuanToolStripMenuItem.Name = "tinTứcLiênQuanToolStripMenuItem";
            tinTứcLiênQuanToolStripMenuItem.Size = new Size(133, 24);
            tinTứcLiênQuanToolStripMenuItem.Text = "Tin tức liên quan";
            // 
            // menuStrip2
            // 
            menuStrip2.ImageScalingSize = new Size(20, 20);
            menuStrip2.Location = new Point(0, 0);
            menuStrip2.Name = "menuStrip2";
            menuStrip2.Size = new Size(1079, 24);
            menuStrip2.TabIndex = 0;
            menuStrip2.Text = "menuStrip2";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(260, 161);
            label1.Name = "label1";
            label1.Size = new Size(0, 20);
            label1.TabIndex = 1;
            // 
            // FTrangchu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1079, 516);
            Controls.Add(panel1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "FTrangchu";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Trang chủ";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private MenuStrip menuStrip1;
        private Label label1;
        private MenuStrip menuStrip2;
        private ToolStripMenuItem chiTiếtVềCuộcThithôngTinLịchThiĐấuToolStripMenuItem;
        private ToolStripMenuItem giảiThưởngToolStripMenuItem;
        private ToolStripMenuItem luậtThiĐấuToolStripMenuItem;
        private ToolStripMenuItem tiêuChíChấmĐiểmToolStripMenuItem;
        private ToolStripMenuItem tinTứcLiênQuanToolStripMenuItem;
    }
}