
namespace LoginForm
{
    partial class FrmLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLogin));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btClose = new Guna.UI.WinForms.GunaGradientCircleButton();
            this.gunaLabel1 = new Guna.UI.WinForms.GunaLabel();
            this.gunaLabel2 = new Guna.UI.WinForms.GunaLabel();
            this.txtPassword = new Guna.UI.WinForms.GunaTextBox();
            this.txtUserName = new Guna.UI.WinForms.GunaTextBox();
            this.gunaLabel3 = new Guna.UI.WinForms.GunaLabel();
            this.btLogin = new Guna.UI.WinForms.GunaGradientButton();
            this.gunaGradientButton1 = new Guna.UI.WinForms.GunaGradientButton();
            this.gunaCircleButton1 = new Guna.UI.WinForms.GunaCircleButton();
            this.gunaPanel1 = new Guna.UI.WinForms.GunaPanel();
            this.gunaCircleButton5 = new Guna.UI.WinForms.GunaCircleButton();
            this.gunaCircleButton4 = new Guna.UI.WinForms.GunaCircleButton();
            this.gunaCircleButton3 = new Guna.UI.WinForms.GunaCircleButton();
            this.gunaCircleButton2 = new Guna.UI.WinForms.GunaCircleButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.gunaPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(-1, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(369, 407);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(50)))), ((int)(((byte)(79)))));
            this.panel1.Controls.Add(this.btClose);
            this.panel1.Location = new System.Drawing.Point(368, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(315, 39);
            this.panel1.TabIndex = 1;
            // 
            // btClose
            // 
            this.btClose.Animated = true;
            this.btClose.AnimationHoverSpeed = 0.07F;
            this.btClose.AnimationSpeed = 0.03F;
            this.btClose.BaseColor1 = System.Drawing.Color.SlateBlue;
            this.btClose.BaseColor2 = System.Drawing.Color.Fuchsia;
            this.btClose.BorderColor = System.Drawing.Color.Black;
            this.btClose.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btClose.FocusedColor = System.Drawing.Color.Empty;
            this.btClose.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btClose.ForeColor = System.Drawing.Color.White;
            this.btClose.Image = ((System.Drawing.Image)(resources.GetObject("btClose.Image")));
            this.btClose.ImageSize = new System.Drawing.Size(29, 29);
            this.btClose.Location = new System.Drawing.Point(270, 2);
            this.btClose.Name = "btClose";
            this.btClose.OnHoverBaseColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(145)))), ((int)(((byte)(221)))));
            this.btClose.OnHoverBaseColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(85)))), ((int)(((byte)(255)))));
            this.btClose.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btClose.OnHoverForeColor = System.Drawing.Color.LightGray;
            this.btClose.OnHoverImage = null;
            this.btClose.OnPressedColor = System.Drawing.Color.Black;
            this.btClose.Size = new System.Drawing.Size(42, 36);
            this.btClose.TabIndex = 0;
            this.btClose.Click += new System.EventHandler(this.btClose_Click);
            // 
            // gunaLabel1
            // 
            this.gunaLabel1.AutoSize = true;
            this.gunaLabel1.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gunaLabel1.ForeColor = System.Drawing.Color.Fuchsia;
            this.gunaLabel1.Location = new System.Drawing.Point(388, 112);
            this.gunaLabel1.Name = "gunaLabel1";
            this.gunaLabel1.Size = new System.Drawing.Size(76, 17);
            this.gunaLabel1.TabIndex = 3;
            this.gunaLabel1.Text = "Tài Khoản";
            // 
            // gunaLabel2
            // 
            this.gunaLabel2.AutoSize = true;
            this.gunaLabel2.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gunaLabel2.ForeColor = System.Drawing.Color.Fuchsia;
            this.gunaLabel2.Location = new System.Drawing.Point(388, 167);
            this.gunaLabel2.Name = "gunaLabel2";
            this.gunaLabel2.Size = new System.Drawing.Size(74, 17);
            this.gunaLabel2.TabIndex = 4;
            this.gunaLabel2.Text = "Mật Khẩu";
            // 
            // txtPassword
            // 
            this.txtPassword.BackColor = System.Drawing.Color.Transparent;
            this.txtPassword.BaseColor = System.Drawing.Color.DimGray;
            this.txtPassword.BorderColor = System.Drawing.Color.Black;
            this.txtPassword.BorderSize = 1;
            this.txtPassword.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPassword.FocusedBaseColor = System.Drawing.Color.White;
            this.txtPassword.FocusedBorderColor = System.Drawing.Color.Blue;
            this.txtPassword.FocusedForeColor = System.Drawing.SystemColors.ControlText;
            this.txtPassword.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.ForeColor = System.Drawing.Color.Silver;
            this.txtPassword.Location = new System.Drawing.Point(478, 158);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '\0';
            this.txtPassword.Radius = 10;
            this.txtPassword.SelectedText = "";
            this.txtPassword.Size = new System.Drawing.Size(193, 36);
            this.txtPassword.TabIndex = 6;
            this.txtPassword.Text = "Password";
            this.txtPassword.Enter += new System.EventHandler(this.txtPassword_Enter);
            this.txtPassword.Leave += new System.EventHandler(this.txtPassword_Leave);
            // 
            // txtUserName
            // 
            this.txtUserName.BackColor = System.Drawing.Color.Transparent;
            this.txtUserName.BaseColor = System.Drawing.Color.DimGray;
            this.txtUserName.BorderColor = System.Drawing.Color.Black;
            this.txtUserName.BorderSize = 1;
            this.txtUserName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtUserName.FocusedBaseColor = System.Drawing.Color.White;
            this.txtUserName.FocusedBorderColor = System.Drawing.Color.Blue;
            this.txtUserName.FocusedForeColor = System.Drawing.SystemColors.ControlText;
            this.txtUserName.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUserName.ForeColor = System.Drawing.Color.Silver;
            this.txtUserName.Location = new System.Drawing.Point(479, 106);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.PasswordChar = '\0';
            this.txtUserName.Radius = 10;
            this.txtUserName.SelectedText = "";
            this.txtUserName.Size = new System.Drawing.Size(193, 36);
            this.txtUserName.TabIndex = 7;
            this.txtUserName.Text = "User Name";
            this.txtUserName.Enter += new System.EventHandler(this.txtUserName_Enter);
            this.txtUserName.Leave += new System.EventHandler(this.txtUserName_Leave);
            // 
            // gunaLabel3
            // 
            this.gunaLabel3.AutoSize = true;
            this.gunaLabel3.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gunaLabel3.ForeColor = System.Drawing.Color.DodgerBlue;
            this.gunaLabel3.Location = new System.Drawing.Point(499, 55);
            this.gunaLabel3.Name = "gunaLabel3";
            this.gunaLabel3.Size = new System.Drawing.Size(72, 26);
            this.gunaLabel3.TabIndex = 8;
            this.gunaLabel3.Text = "Login";
            // 
            // btLogin
            // 
            this.btLogin.Animated = true;
            this.btLogin.AnimationHoverSpeed = 0.07F;
            this.btLogin.AnimationSpeed = 0.03F;
            this.btLogin.BackColor = System.Drawing.Color.Transparent;
            this.btLogin.BaseColor1 = System.Drawing.Color.SlateBlue;
            this.btLogin.BaseColor2 = System.Drawing.Color.Fuchsia;
            this.btLogin.BorderColor = System.Drawing.Color.Black;
            this.btLogin.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btLogin.FocusedColor = System.Drawing.Color.Empty;
            this.btLogin.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btLogin.ForeColor = System.Drawing.Color.White;
            this.btLogin.Image = ((System.Drawing.Image)(resources.GetObject("btLogin.Image")));
            this.btLogin.ImageSize = new System.Drawing.Size(20, 20);
            this.btLogin.Location = new System.Drawing.Point(476, 218);
            this.btLogin.Name = "btLogin";
            this.btLogin.OnHoverBaseColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(145)))), ((int)(((byte)(221)))));
            this.btLogin.OnHoverBaseColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(85)))), ((int)(((byte)(255)))));
            this.btLogin.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btLogin.OnHoverForeColor = System.Drawing.Color.Silver;
            this.btLogin.OnHoverImage = null;
            this.btLogin.OnPressedColor = System.Drawing.Color.Black;
            this.btLogin.Radius = 15;
            this.btLogin.Size = new System.Drawing.Size(111, 32);
            this.btLogin.TabIndex = 9;
            this.btLogin.Text = "Login";
            this.btLogin.Click += new System.EventHandler(this.btLogin_Click);
            // 
            // gunaGradientButton1
            // 
            this.gunaGradientButton1.Animated = true;
            this.gunaGradientButton1.AnimationHoverSpeed = 0.07F;
            this.gunaGradientButton1.AnimationSpeed = 0.03F;
            this.gunaGradientButton1.BackColor = System.Drawing.Color.Transparent;
            this.gunaGradientButton1.BaseColor1 = System.Drawing.Color.SlateBlue;
            this.gunaGradientButton1.BaseColor2 = System.Drawing.Color.Fuchsia;
            this.gunaGradientButton1.BorderColor = System.Drawing.Color.Black;
            this.gunaGradientButton1.DialogResult = System.Windows.Forms.DialogResult.None;
            this.gunaGradientButton1.FocusedColor = System.Drawing.Color.Empty;
            this.gunaGradientButton1.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gunaGradientButton1.ForeColor = System.Drawing.Color.White;
            this.gunaGradientButton1.Image = ((System.Drawing.Image)(resources.GetObject("gunaGradientButton1.Image")));
            this.gunaGradientButton1.ImageSize = new System.Drawing.Size(22, 22);
            this.gunaGradientButton1.Location = new System.Drawing.Point(438, 267);
            this.gunaGradientButton1.Name = "gunaGradientButton1";
            this.gunaGradientButton1.OnHoverBaseColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(145)))), ((int)(((byte)(221)))));
            this.gunaGradientButton1.OnHoverBaseColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(85)))), ((int)(((byte)(255)))));
            this.gunaGradientButton1.OnHoverBorderColor = System.Drawing.Color.Black;
            this.gunaGradientButton1.OnHoverForeColor = System.Drawing.Color.Silver;
            this.gunaGradientButton1.OnHoverImage = null;
            this.gunaGradientButton1.OnPressedColor = System.Drawing.Color.Black;
            this.gunaGradientButton1.Radius = 15;
            this.gunaGradientButton1.Size = new System.Drawing.Size(191, 32);
            this.gunaGradientButton1.TabIndex = 10;
            this.gunaGradientButton1.Text = "Forgot Password";
            this.gunaGradientButton1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // gunaCircleButton1
            // 
            this.gunaCircleButton1.Animated = true;
            this.gunaCircleButton1.AnimationHoverSpeed = 0.07F;
            this.gunaCircleButton1.AnimationSpeed = 0.03F;
            this.gunaCircleButton1.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.gunaCircleButton1.BorderColor = System.Drawing.Color.Black;
            this.gunaCircleButton1.DialogResult = System.Windows.Forms.DialogResult.None;
            this.gunaCircleButton1.FocusedColor = System.Drawing.Color.Empty;
            this.gunaCircleButton1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.gunaCircleButton1.ForeColor = System.Drawing.Color.White;
            this.gunaCircleButton1.Image = ((System.Drawing.Image)(resources.GetObject("gunaCircleButton1.Image")));
            this.gunaCircleButton1.ImageSize = new System.Drawing.Size(46, 46);
            this.gunaCircleButton1.Location = new System.Drawing.Point(8, 5);
            this.gunaCircleButton1.Name = "gunaCircleButton1";
            this.gunaCircleButton1.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.gunaCircleButton1.OnHoverBorderColor = System.Drawing.Color.Black;
            this.gunaCircleButton1.OnHoverForeColor = System.Drawing.Color.White;
            this.gunaCircleButton1.OnHoverImage = null;
            this.gunaCircleButton1.OnPressedColor = System.Drawing.Color.Black;
            this.gunaCircleButton1.Size = new System.Drawing.Size(47, 43);
            this.gunaCircleButton1.TabIndex = 11;
            // 
            // gunaPanel1
            // 
            this.gunaPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.gunaPanel1.Controls.Add(this.gunaCircleButton5);
            this.gunaPanel1.Controls.Add(this.gunaCircleButton4);
            this.gunaPanel1.Controls.Add(this.gunaCircleButton3);
            this.gunaPanel1.Controls.Add(this.gunaCircleButton2);
            this.gunaPanel1.Controls.Add(this.gunaCircleButton1);
            this.gunaPanel1.Location = new System.Drawing.Point(368, 356);
            this.gunaPanel1.Name = "gunaPanel1";
            this.gunaPanel1.Size = new System.Drawing.Size(315, 51);
            this.gunaPanel1.TabIndex = 12;
            // 
            // gunaCircleButton5
            // 
            this.gunaCircleButton5.Animated = true;
            this.gunaCircleButton5.AnimationHoverSpeed = 0.07F;
            this.gunaCircleButton5.AnimationSpeed = 0.03F;
            this.gunaCircleButton5.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.gunaCircleButton5.BorderColor = System.Drawing.Color.Black;
            this.gunaCircleButton5.DialogResult = System.Windows.Forms.DialogResult.None;
            this.gunaCircleButton5.FocusedColor = System.Drawing.Color.Empty;
            this.gunaCircleButton5.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.gunaCircleButton5.ForeColor = System.Drawing.Color.White;
            this.gunaCircleButton5.Image = ((System.Drawing.Image)(resources.GetObject("gunaCircleButton5.Image")));
            this.gunaCircleButton5.ImageSize = new System.Drawing.Size(46, 46);
            this.gunaCircleButton5.Location = new System.Drawing.Point(261, 5);
            this.gunaCircleButton5.Name = "gunaCircleButton5";
            this.gunaCircleButton5.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(143)))), ((int)(((byte)(255)))));
            this.gunaCircleButton5.OnHoverBorderColor = System.Drawing.Color.Black;
            this.gunaCircleButton5.OnHoverForeColor = System.Drawing.Color.White;
            this.gunaCircleButton5.OnHoverImage = null;
            this.gunaCircleButton5.OnPressedColor = System.Drawing.Color.Black;
            this.gunaCircleButton5.Size = new System.Drawing.Size(47, 43);
            this.gunaCircleButton5.TabIndex = 15;
            // 
            // gunaCircleButton4
            // 
            this.gunaCircleButton4.Animated = true;
            this.gunaCircleButton4.AnimationHoverSpeed = 0.07F;
            this.gunaCircleButton4.AnimationSpeed = 0.03F;
            this.gunaCircleButton4.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.gunaCircleButton4.BorderColor = System.Drawing.Color.Black;
            this.gunaCircleButton4.DialogResult = System.Windows.Forms.DialogResult.None;
            this.gunaCircleButton4.FocusedColor = System.Drawing.Color.Empty;
            this.gunaCircleButton4.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.gunaCircleButton4.ForeColor = System.Drawing.Color.White;
            this.gunaCircleButton4.Image = ((System.Drawing.Image)(resources.GetObject("gunaCircleButton4.Image")));
            this.gunaCircleButton4.ImageSize = new System.Drawing.Size(46, 46);
            this.gunaCircleButton4.Location = new System.Drawing.Point(198, 3);
            this.gunaCircleButton4.Name = "gunaCircleButton4";
            this.gunaCircleButton4.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(143)))), ((int)(((byte)(255)))));
            this.gunaCircleButton4.OnHoverBorderColor = System.Drawing.Color.Black;
            this.gunaCircleButton4.OnHoverForeColor = System.Drawing.Color.White;
            this.gunaCircleButton4.OnHoverImage = null;
            this.gunaCircleButton4.OnPressedColor = System.Drawing.Color.Black;
            this.gunaCircleButton4.Size = new System.Drawing.Size(47, 43);
            this.gunaCircleButton4.TabIndex = 14;
            // 
            // gunaCircleButton3
            // 
            this.gunaCircleButton3.Animated = true;
            this.gunaCircleButton3.AnimationHoverSpeed = 0.07F;
            this.gunaCircleButton3.AnimationSpeed = 0.03F;
            this.gunaCircleButton3.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.gunaCircleButton3.BorderColor = System.Drawing.Color.Black;
            this.gunaCircleButton3.DialogResult = System.Windows.Forms.DialogResult.None;
            this.gunaCircleButton3.FocusedColor = System.Drawing.Color.Empty;
            this.gunaCircleButton3.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.gunaCircleButton3.ForeColor = System.Drawing.Color.White;
            this.gunaCircleButton3.Image = ((System.Drawing.Image)(resources.GetObject("gunaCircleButton3.Image")));
            this.gunaCircleButton3.ImageSize = new System.Drawing.Size(46, 46);
            this.gunaCircleButton3.Location = new System.Drawing.Point(133, 4);
            this.gunaCircleButton3.Name = "gunaCircleButton3";
            this.gunaCircleButton3.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(143)))), ((int)(((byte)(255)))));
            this.gunaCircleButton3.OnHoverBorderColor = System.Drawing.Color.Black;
            this.gunaCircleButton3.OnHoverForeColor = System.Drawing.Color.White;
            this.gunaCircleButton3.OnHoverImage = null;
            this.gunaCircleButton3.OnPressedColor = System.Drawing.Color.Black;
            this.gunaCircleButton3.Size = new System.Drawing.Size(47, 43);
            this.gunaCircleButton3.TabIndex = 13;
            // 
            // gunaCircleButton2
            // 
            this.gunaCircleButton2.Animated = true;
            this.gunaCircleButton2.AnimationHoverSpeed = 0.07F;
            this.gunaCircleButton2.AnimationSpeed = 0.03F;
            this.gunaCircleButton2.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.gunaCircleButton2.BorderColor = System.Drawing.Color.Black;
            this.gunaCircleButton2.DialogResult = System.Windows.Forms.DialogResult.None;
            this.gunaCircleButton2.FocusedColor = System.Drawing.Color.Empty;
            this.gunaCircleButton2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.gunaCircleButton2.ForeColor = System.Drawing.Color.White;
            this.gunaCircleButton2.Image = ((System.Drawing.Image)(resources.GetObject("gunaCircleButton2.Image")));
            this.gunaCircleButton2.ImageSize = new System.Drawing.Size(46, 46);
            this.gunaCircleButton2.Location = new System.Drawing.Point(70, 5);
            this.gunaCircleButton2.Name = "gunaCircleButton2";
            this.gunaCircleButton2.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(143)))), ((int)(((byte)(255)))));
            this.gunaCircleButton2.OnHoverBorderColor = System.Drawing.Color.Black;
            this.gunaCircleButton2.OnHoverForeColor = System.Drawing.Color.White;
            this.gunaCircleButton2.OnHoverImage = null;
            this.gunaCircleButton2.OnPressedColor = System.Drawing.Color.Black;
            this.gunaCircleButton2.Size = new System.Drawing.Size(47, 43);
            this.gunaCircleButton2.TabIndex = 12;
            // 
            // FrmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(58)))), ((int)(((byte)(50)))));
            this.ClientSize = new System.Drawing.Size(683, 407);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.gunaPanel1);
            this.Controls.Add(this.gunaGradientButton1);
            this.Controls.Add(this.btLogin);
            this.Controls.Add(this.gunaLabel3);
            this.Controls.Add(this.gunaLabel2);
            this.Controls.Add(this.gunaLabel1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmLogin";
            this.Load += new System.EventHandler(this.FrmLogin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.gunaPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        private Guna.UI.WinForms.GunaLabel gunaLabel1;
        private Guna.UI.WinForms.GunaLabel gunaLabel2;
        private Guna.UI.WinForms.GunaTextBox txtPassword;
        private Guna.UI.WinForms.GunaTextBox txtUserName;
        private Guna.UI.WinForms.GunaLabel gunaLabel3;
        private Guna.UI.WinForms.GunaGradientButton btLogin;
        private Guna.UI.WinForms.GunaGradientButton gunaGradientButton1;
        private Guna.UI.WinForms.GunaCircleButton gunaCircleButton1;
        private Guna.UI.WinForms.GunaPanel gunaPanel1;
        private Guna.UI.WinForms.GunaCircleButton gunaCircleButton5;
        private Guna.UI.WinForms.GunaCircleButton gunaCircleButton4;
        private Guna.UI.WinForms.GunaCircleButton gunaCircleButton3;
        private Guna.UI.WinForms.GunaCircleButton gunaCircleButton2;
        private Guna.UI.WinForms.GunaGradientCircleButton btClose;
    }
}

