namespace WinFormsAppCaKoi
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
            panelLogin = new Panel();
            btnExit = new Button();
            btnLogin = new Button();
            panelPassWordLogin = new Panel();
            txbPassWord = new TextBox();
            textBox3 = new TextBox();
            panelUserNameLogin = new Panel();
            txbUserName = new TextBox();
            textBox1 = new TextBox();
            panelLogin.SuspendLayout();
            panelPassWordLogin.SuspendLayout();
            panelUserNameLogin.SuspendLayout();
            SuspendLayout();
            // 
            // panelLogin
            // 
            panelLogin.Controls.Add(btnExit);
            panelLogin.Controls.Add(btnLogin);
            panelLogin.Controls.Add(panelPassWordLogin);
            panelLogin.Controls.Add(panelUserNameLogin);
            panelLogin.Location = new Point(12, 12);
            panelLogin.Name = "panelLogin";
            panelLogin.Size = new Size(776, 426);
            panelLogin.TabIndex = 0;
            // 
            // btnExit
            // 
            btnExit.Location = new Point(615, 245);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(142, 46);
            btnExit.TabIndex = 3;
            btnExit.Text = "Thoát";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += btnExit_Click;
            // 
            // btnLogin
            // 
            btnLogin.Location = new Point(297, 245);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(142, 46);
            btnLogin.TabIndex = 2;
            btnLogin.Text = "Đăng nhập";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // panelPassWordLogin
            // 
            panelPassWordLogin.Controls.Add(txbPassWord);
            panelPassWordLogin.Controls.Add(textBox3);
            panelPassWordLogin.Location = new Point(0, 143);
            panelPassWordLogin.Name = "panelPassWordLogin";
            panelPassWordLogin.Size = new Size(770, 96);
            panelPassWordLogin.TabIndex = 1;
            // 
            // txbPassWord
            // 
            txbPassWord.Location = new Point(286, 34);
            txbPassWord.Name = "txbPassWord";
            txbPassWord.Size = new Size(481, 31);
            txbPassWord.TabIndex = 1;
            txbPassWord.UseSystemPasswordChar = true;
            // 
            // textBox3
            // 
            textBox3.BackColor = SystemColors.MenuBar;
            textBox3.Font = new Font("Arial", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            textBox3.ForeColor = SystemColors.WindowText;
            textBox3.Location = new Point(13, 24);
            textBox3.Name = "textBox3";
            textBox3.ReadOnly = true;
            textBox3.Size = new Size(258, 44);
            textBox3.TabIndex = 0;
            textBox3.Text = "Mật khẩu:";
            textBox3.TextChanged += textBox3_TextChanged;
            // 
            // panelUserNameLogin
            // 
            panelUserNameLogin.Controls.Add(txbUserName);
            panelUserNameLogin.Controls.Add(textBox1);
            panelUserNameLogin.Location = new Point(3, 17);
            panelUserNameLogin.Name = "panelUserNameLogin";
            panelUserNameLogin.Size = new Size(770, 102);
            panelUserNameLogin.TabIndex = 0;
            // 
            // txbUserName
            // 
            txbUserName.Location = new Point(283, 38);
            txbUserName.Name = "txbUserName";
            txbUserName.Size = new Size(481, 31);
            txbUserName.TabIndex = 1;
            // 
            // textBox1
            // 
            textBox1.BackColor = SystemColors.MenuBar;
            textBox1.Font = new Font("Arial", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            textBox1.ForeColor = SystemColors.WindowText;
            textBox1.Location = new Point(10, 28);
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.Size = new Size(258, 44);
            textBox1.TabIndex = 0;
            textBox1.Text = "Tên đăng nhập:";
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // FLogin
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panelLogin);
            Name = "FLogin";
            Text = "Đăng nhập";
            panelLogin.ResumeLayout(false);
            panelPassWordLogin.ResumeLayout(false);
            panelPassWordLogin.PerformLayout();
            panelUserNameLogin.ResumeLayout(false);
            panelUserNameLogin.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelLogin;
        private Panel panelUserNameLogin;
        private TextBox textBox1;
        private Panel panelPassWordLogin;
        private TextBox txbPassWord;
        private TextBox textBox3;
        private TextBox txbUserName;
        private Button btnLogin;
        private Button btnExit;
    }
}
