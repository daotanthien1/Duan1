
namespace RJCodeAdvance
{
    partial class FrmEmployees
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmEmployees));
            this.bt2 = new Guna.UI2.WinForms.Guna2Button();
            this.bt1 = new Guna.UI2.WinForms.Guna2Button();
            this.imageSlide = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.uC_employee1 = new RJCodeAdvance.ControlEmployees.UC_employee();
            this.uC_TypeOfEmployee1 = new RJCodeAdvance.ControlEmployees.UC_TypeOfEmployee();
            ((System.ComponentModel.ISupportInitialize)(this.imageSlide)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // bt2
            // 
            this.bt2.BackColor = System.Drawing.Color.Transparent;
            this.bt2.BorderRadius = 22;
            this.bt2.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.bt2.CheckedState.FillColor = System.Drawing.Color.White;
            this.bt2.CheckedState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(118)))), ((int)(((byte)(212)))));
            this.bt2.CheckedState.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image")));
            this.bt2.CheckedState.Parent = this.bt2;
            this.bt2.CustomImages.Parent = this.bt2;
            this.bt2.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.bt2.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.bt2.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.bt2.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.bt2.DisabledState.Parent = this.bt2;
            this.bt2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(118)))), ((int)(((byte)(212)))));
            this.bt2.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt2.ForeColor = System.Drawing.Color.White;
            this.bt2.HoverState.Parent = this.bt2;
            this.bt2.Image = ((System.Drawing.Image)(resources.GetObject("bt2.Image")));
            this.bt2.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.bt2.ImageSize = new System.Drawing.Size(25, 25);
            this.bt2.Location = new System.Drawing.Point(27, 190);
            this.bt2.Name = "bt2";
            this.bt2.ShadowDecoration.Parent = this.bt2;
            this.bt2.Size = new System.Drawing.Size(186, 43);
            this.bt2.TabIndex = 7;
            this.bt2.Text = "Vai trò";
            this.bt2.UseTransparentBackground = true;
            this.bt2.CheckedChanged += new System.EventHandler(this.bt1_CheckedChanged);
            // 
            // bt1
            // 
            this.bt1.BackColor = System.Drawing.Color.Transparent;
            this.bt1.BorderRadius = 22;
            this.bt1.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.bt1.Checked = true;
            this.bt1.CheckedState.FillColor = System.Drawing.Color.White;
            this.bt1.CheckedState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(118)))), ((int)(((byte)(212)))));
            this.bt1.CheckedState.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image1")));
            this.bt1.CheckedState.Parent = this.bt1;
            this.bt1.CustomImages.Parent = this.bt1;
            this.bt1.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.bt1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.bt1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.bt1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.bt1.DisabledState.Parent = this.bt1;
            this.bt1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(118)))), ((int)(((byte)(212)))));
            this.bt1.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt1.ForeColor = System.Drawing.Color.White;
            this.bt1.HoverState.Parent = this.bt1;
            this.bt1.Image = ((System.Drawing.Image)(resources.GetObject("bt1.Image")));
            this.bt1.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.bt1.ImageSize = new System.Drawing.Size(25, 25);
            this.bt1.Location = new System.Drawing.Point(26, 116);
            this.bt1.Name = "bt1";
            this.bt1.ShadowDecoration.Parent = this.bt1;
            this.bt1.Size = new System.Drawing.Size(186, 43);
            this.bt1.TabIndex = 5;
            this.bt1.Text = "Nhân viên";
            this.bt1.UseTransparentBackground = true;
            this.bt1.CheckedChanged += new System.EventHandler(this.bt1_CheckedChanged);
            // 
            // imageSlide
            // 
            this.imageSlide.Image = ((System.Drawing.Image)(resources.GetObject("imageSlide.Image")));
            this.imageSlide.Location = new System.Drawing.Point(175, 86);
            this.imageSlide.Name = "imageSlide";
            this.imageSlide.Size = new System.Drawing.Size(39, 102);
            this.imageSlide.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.imageSlide.TabIndex = 6;
            this.imageSlide.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(5, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(50, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(59, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 23);
            this.label1.TabIndex = 3;
            this.label1.Text = "Employees";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(118)))), ((int)(((byte)(212)))));
            this.panel1.Controls.Add(this.bt2);
            this.panel1.Controls.Add(this.bt1);
            this.panel1.Controls.Add(this.imageSlide);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(213, 569);
            this.panel1.TabIndex = 6;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.uC_employee1);
            this.panel2.Controls.Add(this.uC_TypeOfEmployee1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(213, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1100, 569);
            this.panel2.TabIndex = 7;
            // 
            // uC_employee1
            // 
            this.uC_employee1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uC_employee1.Location = new System.Drawing.Point(0, 0);
            this.uC_employee1.Name = "uC_employee1";
            this.uC_employee1.Size = new System.Drawing.Size(1100, 569);
            this.uC_employee1.TabIndex = 0;
            // 
            // uC_TypeOfEmployee1
            // 
            this.uC_TypeOfEmployee1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uC_TypeOfEmployee1.Location = new System.Drawing.Point(0, 0);
            this.uC_TypeOfEmployee1.Name = "uC_TypeOfEmployee1";
            this.uC_TypeOfEmployee1.Size = new System.Drawing.Size(1100, 569);
            this.uC_TypeOfEmployee1.TabIndex = 1;
            // 
            // FrmEmployees
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1313, 569);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmEmployees";
            ((System.ComponentModel.ISupportInitialize)(this.imageSlide)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Button bt2;
        private Guna.UI2.WinForms.Guna2Button bt1;
        private System.Windows.Forms.PictureBox imageSlide;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private ControlEmployees.UC_employee uC_employee1;
        private ControlEmployees.UC_TypeOfEmployee uC_TypeOfEmployee1;
    }
}