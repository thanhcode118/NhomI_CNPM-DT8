namespace WinFormsAppCaKoi
{
    partial class fSignUp
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
            panelSignUp = new Panel();
            panelUserNameSignUp = new Panel();
            textBox1 = new TextBox();
            txbUserNameSignUp = new TextBox();
            panelPassWordSignUp = new Panel();
            txbPassWordSignUp = new TextBox();
            textBox3 = new TextBox();
            btnSignUp = new Button();
            btnExitSignUp = new Button();
            panelSignUp.SuspendLayout();
            panelUserNameSignUp.SuspendLayout();
            panelPassWordSignUp.SuspendLayout();
            SuspendLayout();
            // 
            // panelSignUp
            // 
            panelSignUp.Controls.Add(btnExitSignUp);
            panelSignUp.Controls.Add(btnSignUp);
            panelSignUp.Controls.Add(panelPassWordSignUp);
            panelSignUp.Controls.Add(panelUserNameSignUp);
            panelSignUp.Location = new Point(5, 7);
            panelSignUp.Name = "panelSignUp";
            panelSignUp.Size = new Size(786, 430);
            panelSignUp.TabIndex = 0;
            // 
            // panelUserNameSignUp
            // 
            panelUserNameSignUp.Controls.Add(txbUserNameSignUp);
            panelUserNameSignUp.Controls.Add(textBox1);
            panelUserNameSignUp.Location = new Point(7, 5);
            panelUserNameSignUp.Name = "panelUserNameSignUp";
            panelUserNameSignUp.Size = new Size(771, 84);
            panelUserNameSignUp.TabIndex = 0;
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Arial", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            textBox1.Location = new Point(17, 23);
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.Size = new Size(277, 44);
            textBox1.TabIndex = 0;
            textBox1.Text = "Tên đăng nhập:";
            // 
            // txbUserNameSignUp
            // 
            txbUserNameSignUp.Location = new Point(316, 33);
            txbUserNameSignUp.Name = "txbUserNameSignUp";
            txbUserNameSignUp.Size = new Size(452, 31);
            txbUserNameSignUp.TabIndex = 1;
            // 
            // panelPassWordSignUp
            // 
            panelPassWordSignUp.Controls.Add(txbPassWordSignUp);
            panelPassWordSignUp.Controls.Add(textBox3);
            panelPassWordSignUp.Location = new Point(7, 108);
            panelPassWordSignUp.Name = "panelPassWordSignUp";
            panelPassWordSignUp.Size = new Size(771, 84);
            panelPassWordSignUp.TabIndex = 1;
            // 
            // txbPassWordSignUp
            // 
            txbPassWordSignUp.Location = new Point(316, 33);
            txbPassWordSignUp.Name = "txbPassWordSignUp";
            txbPassWordSignUp.Size = new Size(452, 31);
            txbPassWordSignUp.TabIndex = 1;
            txbPassWordSignUp.UseSystemPasswordChar = true;
            // 
            // textBox3
            // 
            textBox3.Font = new Font("Arial", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            textBox3.Location = new Point(17, 23);
            textBox3.Name = "textBox3";
            textBox3.ReadOnly = true;
            textBox3.Size = new Size(277, 44);
            textBox3.TabIndex = 0;
            textBox3.Text = "Mật khẩu:";
            // 
            // btnSignUp
            // 
            btnSignUp.Location = new Point(323, 207);
            btnSignUp.Name = "btnSignUp";
            btnSignUp.Size = new Size(171, 53);
            btnSignUp.TabIndex = 2;
            btnSignUp.Text = "Đăng ký";
            btnSignUp.UseVisualStyleBackColor = true;
            btnSignUp.Click += btnSignUp_Click;
            // 
            // btnExitSignUp
            // 
            btnExitSignUp.Location = new Point(607, 207);
            btnExitSignUp.Name = "btnExitSignUp";
            btnExitSignUp.Size = new Size(171, 53);
            btnExitSignUp.TabIndex = 3;
            btnExitSignUp.Text = "Thoát";
            btnExitSignUp.UseVisualStyleBackColor = true;
            btnExitSignUp.Click += btnExitSignUp_Click;
            // 
            // fSignUp
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panelSignUp);
            Name = "fSignUp";
            Text = "Tạo tài khoản";
            panelSignUp.ResumeLayout(false);
            panelUserNameSignUp.ResumeLayout(false);
            panelUserNameSignUp.PerformLayout();
            panelPassWordSignUp.ResumeLayout(false);
            panelPassWordSignUp.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelSignUp;
        private Panel panelUserNameSignUp;
        private TextBox txbUserNameSignUp;
        private TextBox textBox1;
        private Button btnExitSignUp;
        private Button btnSignUp;
        private Panel panelPassWordSignUp;
        private TextBox txbPassWordSignUp;
        private TextBox textBox3;
    }
}