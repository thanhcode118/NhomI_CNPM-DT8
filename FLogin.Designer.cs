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
            textBox2 = new TextBox();
            textBox1 = new TextBox();
            lbPass = new Label();
            lbUsername = new Label();
            btThoat = new Button();
            btDangky = new Button();
            btDangnhap = new Button();
            label1 = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(textBox2);
            panel1.Controls.Add(textBox1);
            panel1.Controls.Add(lbPass);
            panel1.Controls.Add(lbUsername);
            panel1.Controls.Add(btThoat);
            panel1.Controls.Add(btDangky);
            panel1.Controls.Add(btDangnhap);
            panel1.Location = new Point(9, 99);
            panel1.Name = "panel1";
            panel1.Size = new Size(779, 339);
            panel1.TabIndex = 0;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(257, 137);
            textBox2.Multiline = true;
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(346, 34);
            textBox2.TabIndex = 2;
            textBox2.UseSystemPasswordChar = true;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(257, 74);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(346, 34);
            textBox1.TabIndex = 1;
            textBox1.UseSystemPasswordChar = true;
            // 
            // lbPass
            // 
            lbPass.AutoSize = true;
            lbPass.Font = new Font("Showcard Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbPass.Location = new Point(117, 134);
            lbPass.Name = "lbPass";
            lbPass.Size = new Size(64, 26);
            lbPass.TabIndex = 0;
            lbPass.Text = "Pass:";
            // 
            // lbUsername
            // 
            lbUsername.AutoSize = true;
            lbUsername.Font = new Font("Showcard Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbUsername.Location = new Point(117, 74);
            lbUsername.Name = "lbUsername";
            lbUsername.Size = new Size(121, 26);
            lbUsername.TabIndex = 0;
            lbUsername.Text = "Username:";
            lbUsername.Click += lnten_Click;
            // 
            // btThoat
            // 
            btThoat.BackColor = SystemColors.ControlDark;
            btThoat.Location = new Point(509, 215);
            btThoat.Name = "btThoat";
            btThoat.Size = new Size(94, 29);
            btThoat.TabIndex = 5;
            btThoat.Text = "Thoát";
            btThoat.UseVisualStyleBackColor = false;
            btThoat.Click += btThoat_Click;
            // 
            // btDangky
            // 
            btDangky.BackColor = SystemColors.ControlDark;
            btDangky.Location = new Point(385, 215);
            btDangky.Name = "btDangky";
            btDangky.Size = new Size(94, 29);
            btDangky.TabIndex = 4;
            btDangky.Text = "Đăng ký";
            btDangky.UseVisualStyleBackColor = false;
            // 
            // btDangnhap
            // 
            btDangnhap.BackColor = SystemColors.ControlDark;
            btDangnhap.Location = new Point(257, 215);
            btDangnhap.Name = "btDangnhap";
            btDangnhap.Size = new Size(94, 29);
            btDangnhap.TabIndex = 3;
            btDangnhap.Text = "Đăng nhập";
            btDangnhap.UseVisualStyleBackColor = false;
            btDangnhap.Click += btDangnhap_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Showcard Gothic", 22.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.Highlight;
            label1.Location = new Point(238, 50);
            label1.Name = "label1";
            label1.Size = new Size(325, 46);
            label1.TabIndex = 0;
            label1.Text = "Cuộc Thi Cá Koi";
            // 
            // FLogin
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 497);
            Controls.Add(panel1);
            Controls.Add(label1);
            Name = "FLogin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FLogin";
            FormClosing += FLogin_FormClosing;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Button btThoat;
        private Button btDangky;
        private Button btDangnhap;
        private Label label1;
        private Label lbUsername;
        private Label lbPass;
        private TextBox textBox2;
        private TextBox textBox1;
    }
}
