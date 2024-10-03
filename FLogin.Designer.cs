namespace WinFormsAppCK
{
    partial class FLogin
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            btThoat = new Button();
            btDangky = new Button();
            btDangnhap = new Button();
            btTrangchu = new Button();
            label1 = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(btThoat);
            panel1.Controls.Add(btDangky);
            panel1.Controls.Add(btDangnhap);
            panel1.Controls.Add(btTrangchu);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(9, 5);
            panel1.Name = "panel1";
            panel1.Size = new Size(779, 433);
            panel1.TabIndex = 0;
            // 
            // btThoat
            // 
            btThoat.BackColor = SystemColors.ControlDark;
            btThoat.Location = new Point(682, 401);
            btThoat.Name = "btThoat";
            btThoat.Size = new Size(94, 29);
            btThoat.TabIndex = 4;
            btThoat.Text = "Thoát";
            btThoat.UseVisualStyleBackColor = false;
            btThoat.Click += btThoat_Click;
            // 
            // btDangky
            // 
            btDangky.BackColor = SystemColors.ControlDark;
            btDangky.Location = new Point(501, 250);
            btDangky.Name = "btDangky";
            btDangky.Size = new Size(94, 29);
            btDangky.TabIndex = 3;
            btDangky.Text = "Đăng ký";
            btDangky.UseVisualStyleBackColor = false;
            // 
            // btDangnhap
            // 
            btDangnhap.BackColor = SystemColors.ControlDark;
            btDangnhap.Location = new Point(325, 250);
            btDangnhap.Name = "btDangnhap";
            btDangnhap.Size = new Size(94, 29);
            btDangnhap.TabIndex = 2;
            btDangnhap.Text = "Đăng nhập";
            btDangnhap.UseVisualStyleBackColor = false;
            // 
            // btTrangchu
            // 
            btTrangchu.BackColor = SystemColors.ControlDark;
            btTrangchu.Location = new Point(155, 250);
            btTrangchu.Name = "btTrangchu";
            btTrangchu.Size = new Size(94, 29);
            btTrangchu.TabIndex = 1;
            btTrangchu.Text = "Trang chủ";
            btTrangchu.UseVisualStyleBackColor = false;
            btTrangchu.Click += btTrangchu_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Showcard Gothic", 22.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.Highlight;
            label1.Location = new Point(214, 170);
            label1.Name = "label1";
            label1.Size = new Size(325, 46);
            label1.TabIndex = 0;
            label1.Text = "Cuộc Thi Cá Koi";
            // 
            // FLogin
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panel1);
            Name = "FLogin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FLogin";
            FormClosing += FLogin_FormClosing;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button btThoat;
        private Button btDangky;
        private Button btDangnhap;
        private Button btTrangchu;
        private Label label1;
    }
}
