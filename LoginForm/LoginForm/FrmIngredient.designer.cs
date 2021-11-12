
namespace RJCodeAdvance
{
    partial class FrmIngredient
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmIngredient));
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.bt1 = new Guna.UI2.WinForms.Guna2Button();
            this.imageSlide = new System.Windows.Forms.PictureBox();
            this.bt2 = new Guna.UI2.WinForms.Guna2Button();
            this.bt3 = new Guna.UI2.WinForms.Guna2Button();
            this.bt4 = new Guna.UI2.WinForms.Guna2Button();
            this.bt5 = new Guna.UI2.WinForms.Guna2Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.uC_Input_Ingredient1 = new RJCodeAdvance.ControlIngredient.UC_Input_Ingredient_OLD();
            this.uC_ingredient1 = new RJCodeAdvance.ControlIngredient.UC_ingredient_OLD();
            this.uC_typeOfIngredient1 = new RJCodeAdvance.ControlIngredient.UC_typeOfIngredient();
            this.uC_Supplier1 = new RJCodeAdvance.ControlIngredient.UC_Supplier();
            this.uC_Unit1 = new RJCodeAdvance.ControlIngredient.UC_Unit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageSlide)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.bt5);
            this.panel1.Controls.Add(this.bt4);
            this.panel1.Controls.Add(this.bt3);
            this.panel1.Controls.Add(this.bt2);
            this.panel1.Controls.Add(this.bt1);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.imageSlide);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(213, 569);
            this.panel1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(7, 9);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(50, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(62, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 23);
            this.label1.TabIndex = 5;
            this.label1.Text = "Ingredient";
            // 
            // bt1
            // 
            this.bt1.BackColor = System.Drawing.Color.Transparent;
            this.bt1.BorderRadius = 22;
            this.bt1.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.bt1.Checked = true;
            this.bt1.CheckedState.FillColor = System.Drawing.Color.White;
            this.bt1.CheckedState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(118)))), ((int)(((byte)(212)))));
            this.bt1.CheckedState.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image4")));
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
            this.bt1.Location = new System.Drawing.Point(25, 160);
            this.bt1.Name = "bt1";
            this.bt1.ShadowDecoration.Parent = this.bt1;
            this.bt1.Size = new System.Drawing.Size(186, 43);
            this.bt1.TabIndex = 7;
            this.bt1.Text = "Nhập nguyên liệu";
            this.bt1.UseTransparentBackground = true;
            this.bt1.CheckedChanged += new System.EventHandler(this.bt1_CheckedChanged);
            // 
            // imageSlide
            // 
            this.imageSlide.Image = ((System.Drawing.Image)(resources.GetObject("imageSlide.Image")));
            this.imageSlide.Location = new System.Drawing.Point(175, 130);
            this.imageSlide.Name = "imageSlide";
            this.imageSlide.Size = new System.Drawing.Size(39, 102);
            this.imageSlide.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.imageSlide.TabIndex = 8;
            this.imageSlide.TabStop = false;
            // 
            // bt2
            // 
            this.bt2.BackColor = System.Drawing.Color.Transparent;
            this.bt2.BorderRadius = 22;
            this.bt2.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.bt2.CheckedState.FillColor = System.Drawing.Color.White;
            this.bt2.CheckedState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(118)))), ((int)(((byte)(212)))));
            this.bt2.CheckedState.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image3")));
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
            this.bt2.Location = new System.Drawing.Point(25, 233);
            this.bt2.Name = "bt2";
            this.bt2.ShadowDecoration.Parent = this.bt2;
            this.bt2.Size = new System.Drawing.Size(186, 43);
            this.bt2.TabIndex = 9;
            this.bt2.Text = "Nguyên liệu";
            this.bt2.UseTransparentBackground = true;
            this.bt2.CheckedChanged += new System.EventHandler(this.bt1_CheckedChanged);
            // 
            // bt3
            // 
            this.bt3.BackColor = System.Drawing.Color.Transparent;
            this.bt3.BorderRadius = 22;
            this.bt3.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.bt3.CheckedState.FillColor = System.Drawing.Color.White;
            this.bt3.CheckedState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(118)))), ((int)(((byte)(212)))));
            this.bt3.CheckedState.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image2")));
            this.bt3.CheckedState.Parent = this.bt3;
            this.bt3.CustomImages.Parent = this.bt3;
            this.bt3.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.bt3.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.bt3.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.bt3.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.bt3.DisabledState.Parent = this.bt3;
            this.bt3.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(118)))), ((int)(((byte)(212)))));
            this.bt3.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt3.ForeColor = System.Drawing.Color.White;
            this.bt3.HoverState.Parent = this.bt3;
            this.bt3.Image = ((System.Drawing.Image)(resources.GetObject("bt3.Image")));
            this.bt3.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.bt3.ImageSize = new System.Drawing.Size(25, 25);
            this.bt3.Location = new System.Drawing.Point(25, 306);
            this.bt3.Name = "bt3";
            this.bt3.ShadowDecoration.Parent = this.bt3;
            this.bt3.Size = new System.Drawing.Size(186, 43);
            this.bt3.TabIndex = 10;
            this.bt3.Text = "Loại nguyên liệu";
            this.bt3.UseTransparentBackground = true;
            this.bt3.CheckedChanged += new System.EventHandler(this.bt1_CheckedChanged);
            // 
            // bt4
            // 
            this.bt4.BackColor = System.Drawing.Color.Transparent;
            this.bt4.BorderRadius = 22;
            this.bt4.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.bt4.CheckedState.FillColor = System.Drawing.Color.White;
            this.bt4.CheckedState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(118)))), ((int)(((byte)(212)))));
            this.bt4.CheckedState.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image1")));
            this.bt4.CheckedState.Parent = this.bt4;
            this.bt4.CustomImages.Parent = this.bt4;
            this.bt4.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.bt4.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.bt4.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.bt4.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.bt4.DisabledState.Parent = this.bt4;
            this.bt4.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(118)))), ((int)(((byte)(212)))));
            this.bt4.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt4.ForeColor = System.Drawing.Color.White;
            this.bt4.HoverState.Parent = this.bt4;
            this.bt4.Image = ((System.Drawing.Image)(resources.GetObject("bt4.Image")));
            this.bt4.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.bt4.ImageSize = new System.Drawing.Size(25, 25);
            this.bt4.Location = new System.Drawing.Point(25, 379);
            this.bt4.Name = "bt4";
            this.bt4.ShadowDecoration.Parent = this.bt4;
            this.bt4.Size = new System.Drawing.Size(186, 43);
            this.bt4.TabIndex = 11;
            this.bt4.Text = "Nhà cung cấp";
            this.bt4.UseTransparentBackground = true;
            this.bt4.CheckedChanged += new System.EventHandler(this.bt1_CheckedChanged);
            // 
            // bt5
            // 
            this.bt5.BackColor = System.Drawing.Color.Transparent;
            this.bt5.BorderRadius = 22;
            this.bt5.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.bt5.CheckedState.FillColor = System.Drawing.Color.White;
            this.bt5.CheckedState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(118)))), ((int)(((byte)(212)))));
            this.bt5.CheckedState.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image")));
            this.bt5.CheckedState.Parent = this.bt5;
            this.bt5.CustomImages.Parent = this.bt5;
            this.bt5.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.bt5.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.bt5.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.bt5.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.bt5.DisabledState.Parent = this.bt5;
            this.bt5.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(118)))), ((int)(((byte)(212)))));
            this.bt5.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt5.ForeColor = System.Drawing.Color.White;
            this.bt5.HoverState.Parent = this.bt5;
            this.bt5.Image = ((System.Drawing.Image)(resources.GetObject("bt5.Image")));
            this.bt5.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.bt5.ImageSize = new System.Drawing.Size(25, 25);
            this.bt5.Location = new System.Drawing.Point(25, 452);
            this.bt5.Name = "bt5";
            this.bt5.ShadowDecoration.Parent = this.bt5;
            this.bt5.Size = new System.Drawing.Size(186, 43);
            this.bt5.TabIndex = 12;
            this.bt5.Text = "Đơn vị";
            this.bt5.UseTransparentBackground = true;
            this.bt5.CheckedChanged += new System.EventHandler(this.bt1_CheckedChanged);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.uC_Input_Ingredient1);
            this.panel2.Controls.Add(this.uC_Unit1);
            this.panel2.Controls.Add(this.uC_Supplier1);
            this.panel2.Controls.Add(this.uC_typeOfIngredient1);
            this.panel2.Controls.Add(this.uC_ingredient1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(213, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1100, 569);
            this.panel2.TabIndex = 1;
            // 
            // uC_Input_Ingredient1
            // 
            this.uC_Input_Ingredient1.BackColor = System.Drawing.Color.White;
            this.uC_Input_Ingredient1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uC_Input_Ingredient1.Location = new System.Drawing.Point(0, 0);
            this.uC_Input_Ingredient1.Name = "uC_Input_Ingredient1";
            this.uC_Input_Ingredient1.Size = new System.Drawing.Size(1100, 569);
            this.uC_Input_Ingredient1.TabIndex = 0;
            // 
            // uC_ingredient1
            // 
            this.uC_ingredient1.BackColor = System.Drawing.Color.White;
            this.uC_ingredient1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uC_ingredient1.Location = new System.Drawing.Point(0, 0);
            this.uC_ingredient1.Name = "uC_ingredient1";
            this.uC_ingredient1.Size = new System.Drawing.Size(1100, 569);
            this.uC_ingredient1.TabIndex = 1;
            // 
            // uC_typeOfIngredient1
            // 
            this.uC_typeOfIngredient1.BackColor = System.Drawing.Color.White;
            this.uC_typeOfIngredient1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uC_typeOfIngredient1.Location = new System.Drawing.Point(0, 0);
            this.uC_typeOfIngredient1.Name = "uC_typeOfIngredient1";
            this.uC_typeOfIngredient1.Size = new System.Drawing.Size(1100, 569);
            this.uC_typeOfIngredient1.TabIndex = 2;
            // 
            // uC_Supplier1
            // 
            this.uC_Supplier1.BackColor = System.Drawing.Color.White;
            this.uC_Supplier1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uC_Supplier1.Location = new System.Drawing.Point(0, 0);
            this.uC_Supplier1.Name = "uC_Supplier1";
            this.uC_Supplier1.Size = new System.Drawing.Size(1100, 569);
            this.uC_Supplier1.TabIndex = 3;
            // 
            // uC_Unit1
            // 
            this.uC_Unit1.BackColor = System.Drawing.Color.White;
            this.uC_Unit1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uC_Unit1.Location = new System.Drawing.Point(0, 0);
            this.uC_Unit1.Name = "uC_Unit1";
            this.uC_Unit1.Size = new System.Drawing.Size(1100, 569);
            this.uC_Unit1.TabIndex = 4;
            // 
            // FrmIngredient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(118)))), ((int)(((byte)(212)))));
            this.ClientSize = new System.Drawing.Size(1313, 569);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.ImeMode = System.Windows.Forms.ImeMode.On;
            this.Name = "FrmIngredient";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageSlide)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2Button bt1;
        private System.Windows.Forms.PictureBox imageSlide;
        private Guna.UI2.WinForms.Guna2Button bt5;
        private Guna.UI2.WinForms.Guna2Button bt4;
        private Guna.UI2.WinForms.Guna2Button bt3;
        private Guna.UI2.WinForms.Guna2Button bt2;
        private System.Windows.Forms.Panel panel2;
        private ControlIngredient.UC_Input_Ingredient_OLD uC_Input_Ingredient1;
        private ControlIngredient.UC_Unit uC_Unit1;
        private ControlIngredient.UC_Supplier uC_Supplier1;
        private ControlIngredient.UC_typeOfIngredient uC_typeOfIngredient1;
        private ControlIngredient.UC_ingredient_OLD uC_ingredient1;
    }
}