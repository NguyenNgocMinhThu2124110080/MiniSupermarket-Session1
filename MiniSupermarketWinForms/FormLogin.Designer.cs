namespace MiniSupermarketWinForms {
    partial class FormLogin {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent() {
            this.lblUser = new System.Windows.Forms.Label();
            this.lblPass = new System.Windows.Forms.Label();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.txtPass = new System.Windows.Forms.TextBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.SuspendLayout();
            
            // lblUser
            this.lblUser.AutoSize = true;
            this.lblUser.Location = new System.Drawing.Point(30, 33);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(58, 13);
            this.lblUser.TabIndex = 0;
            this.lblUser.Text = "Tài khoản:";
            
            // lblPass
            this.lblPass.AutoSize = true;
            this.lblPass.Location = new System.Drawing.Point(30, 69);
            this.lblPass.Name = "lblPass";
            this.lblPass.Size = new System.Drawing.Size(55, 13);
            this.lblPass.TabIndex = 1;
            this.lblPass.Text = "Mật khẩu:";
            
            // txtUser
            this.txtUser.Location = new System.Drawing.Point(94, 30);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(178, 20);
            this.txtUser.TabIndex = 2;
            
            // txtPass
            this.txtPass.Location = new System.Drawing.Point(94, 66);
            this.txtPass.Name = "txtPass";
            this.txtPass.PasswordChar = '*';
            this.txtPass.Size = new System.Drawing.Size(178, 20);
            this.txtPass.TabIndex = 3;
            this.txtPass.UseSystemPasswordChar = true;
            
            // btnLogin
            this.btnLogin.Location = new System.Drawing.Point(94, 102);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(178, 30);
            this.btnLogin.TabIndex = 4;
            this.btnLogin.Text = "Đăng nhập hệ thống";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            
            // FormLogin
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(304, 161);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.txtPass);
            this.Controls.Add(this.txtUser);
            this.Controls.Add(this.lblPass);
            this.Controls.Add(this.lblUser);
            this.Name = "FormLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đăng nhập hệ thống";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.Label lblPass;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.TextBox txtPass;
        private System.Windows.Forms.Button btnLogin;
    }
}
