namespace app_m.Books
{
    partial class Login
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.tb_tk = new ns1.SiticoneTextBox();
            this.mk = new ns1.SiticoneTextBox();
            this.siticoneButton1 = new ns1.SiticoneButton();
            this.siticoneShadowForm1 = new ns1.SiticoneShadowForm(this.components);
            this.siticoneButton2 = new ns1.SiticoneButton();
            this.SuspendLayout();
            // 
            // tb_tk
            // 
            this.tb_tk.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tb_tk.BorderRadius = 6;
            this.tb_tk.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tb_tk.DefaultText = "";
            this.tb_tk.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.tb_tk.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.tb_tk.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tb_tk.DisabledState.Parent = this.tb_tk;
            this.tb_tk.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tb_tk.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tb_tk.FocusedState.Parent = this.tb_tk;
            this.tb_tk.HoveredState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tb_tk.HoveredState.Parent = this.tb_tk;
            this.tb_tk.IconLeft = ((System.Drawing.Image)(resources.GetObject("tb_tk.IconLeft")));
            this.tb_tk.Location = new System.Drawing.Point(289, 150);
            this.tb_tk.Name = "tb_tk";
            this.tb_tk.PasswordChar = '\0';
            this.tb_tk.PlaceholderText = "";
            this.tb_tk.SelectedText = "";
            this.tb_tk.ShadowDecoration.Parent = this.tb_tk;
            this.tb_tk.Size = new System.Drawing.Size(179, 32);
            this.tb_tk.TabIndex = 0;
            // 
            // mk
            // 
            this.mk.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.mk.BorderRadius = 6;
            this.mk.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.mk.DefaultText = "";
            this.mk.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.mk.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.mk.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.mk.DisabledState.Parent = this.mk;
            this.mk.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.mk.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.mk.FocusedState.Parent = this.mk;
            this.mk.HoveredState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.mk.HoveredState.Parent = this.mk;
            this.mk.IconLeft = ((System.Drawing.Image)(resources.GetObject("mk.IconLeft")));
            this.mk.Location = new System.Drawing.Point(289, 188);
            this.mk.Name = "mk";
            this.mk.PasswordChar = '*';
            this.mk.PlaceholderText = "";
            this.mk.SelectedText = "";
            this.mk.ShadowDecoration.Parent = this.mk;
            this.mk.Size = new System.Drawing.Size(179, 32);
            this.mk.TabIndex = 1;
            // 
            // siticoneButton1
            // 
            this.siticoneButton1.BorderColor = System.Drawing.Color.Blue;
            this.siticoneButton1.BorderRadius = 6;
            this.siticoneButton1.BorderStyle = System.Drawing.Drawing2D.DashStyle.Custom;
            this.siticoneButton1.CheckedState.Parent = this.siticoneButton1;
            this.siticoneButton1.CustomImages.Parent = this.siticoneButton1;
            this.siticoneButton1.FillColor = System.Drawing.Color.White;
            this.siticoneButton1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.siticoneButton1.ForeColor = System.Drawing.Color.DimGray;
            this.siticoneButton1.HoveredState.Parent = this.siticoneButton1;
            this.siticoneButton1.Location = new System.Drawing.Point(329, 239);
            this.siticoneButton1.Name = "siticoneButton1";
            this.siticoneButton1.ShadowDecoration.Parent = this.siticoneButton1;
            this.siticoneButton1.Size = new System.Drawing.Size(95, 23);
            this.siticoneButton1.TabIndex = 2;
            this.siticoneButton1.Text = "Đăng nhập";
            this.siticoneButton1.Click += new System.EventHandler(this.siticoneButton1_Click);
            // 
            // siticoneButton2
            // 
            this.siticoneButton2.BorderColor = System.Drawing.Color.Blue;
            this.siticoneButton2.BorderRadius = 6;
            this.siticoneButton2.BorderStyle = System.Drawing.Drawing2D.DashStyle.Custom;
            this.siticoneButton2.CheckedState.Parent = this.siticoneButton2;
            this.siticoneButton2.CustomImages.Parent = this.siticoneButton2;
            this.siticoneButton2.FillColor = System.Drawing.Color.White;
            this.siticoneButton2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.siticoneButton2.ForeColor = System.Drawing.Color.DimGray;
            this.siticoneButton2.HoveredState.Parent = this.siticoneButton2;
            this.siticoneButton2.Location = new System.Drawing.Point(361, 383);
            this.siticoneButton2.Name = "siticoneButton2";
            this.siticoneButton2.ShadowDecoration.Parent = this.siticoneButton2;
            this.siticoneButton2.Size = new System.Drawing.Size(41, 11);
            this.siticoneButton2.TabIndex = 3;
            this.siticoneButton2.Text = "Thoát";
            this.siticoneButton2.Click += new System.EventHandler(this.siticoneButton2_Click);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(777, 488);
            this.Controls.Add(this.siticoneButton2);
            this.Controls.Add(this.siticoneButton1);
            this.Controls.Add(this.mk);
            this.Controls.Add(this.tb_tk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.TransparencyKey = System.Drawing.Color.Red;
            this.Load += new System.EventHandler(this.Login_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ns1.SiticoneTextBox tb_tk;
        private ns1.SiticoneTextBox mk;
        private ns1.SiticoneButton siticoneButton1;
        private ns1.SiticoneShadowForm siticoneShadowForm1;
        private ns1.SiticoneButton siticoneButton2;
    }
}