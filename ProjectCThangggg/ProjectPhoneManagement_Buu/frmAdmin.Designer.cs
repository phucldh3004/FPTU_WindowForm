namespace ProjectPhoneManagement_Buu
{
    partial class Admin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Admin));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnExit_Login = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnMnPhone = new System.Windows.Forms.Button();
            this.btnMnStaff = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(435, 450);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(435, 74);
            this.panel2.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(126, 208);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 45);
            this.label1.TabIndex = 0;
            this.label1.Text = "Admin";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnExit_Login);
            this.panel3.Controls.Add(this.btnLogout);
            this.panel3.Controls.Add(this.btnMnPhone);
            this.panel3.Controls.Add(this.btnMnStaff);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(435, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(365, 450);
            this.panel3.TabIndex = 1;
            // 
            // btnExit_Login
            // 
            this.btnExit_Login.Image = ((System.Drawing.Image)(resources.GetObject("btnExit_Login.Image")));
            this.btnExit_Login.Location = new System.Drawing.Point(325, 3);
            this.btnExit_Login.Name = "btnExit_Login";
            this.btnExit_Login.Size = new System.Drawing.Size(37, 37);
            this.btnExit_Login.TabIndex = 3;
            this.btnExit_Login.UseVisualStyleBackColor = true;
            this.btnExit_Login.Click += new System.EventHandler(this.btnExit_Login_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(141, 397);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(93, 37);
            this.btnLogout.TabIndex = 3;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnMnPhone
            // 
            this.btnMnPhone.Location = new System.Drawing.Point(79, 257);
            this.btnMnPhone.Name = "btnMnPhone";
            this.btnMnPhone.Size = new System.Drawing.Size(214, 75);
            this.btnMnPhone.TabIndex = 1;
            this.btnMnPhone.Text = "Manage Phone";
            this.btnMnPhone.UseVisualStyleBackColor = true;
            this.btnMnPhone.Click += new System.EventHandler(this.btnMnPhone_Click);
            // 
            // btnMnStaff
            // 
            this.btnMnStaff.Location = new System.Drawing.Point(79, 117);
            this.btnMnStaff.Name = "btnMnStaff";
            this.btnMnStaff.Size = new System.Drawing.Size(214, 75);
            this.btnMnStaff.TabIndex = 0;
            this.btnMnStaff.Text = "Manage Staff";
            this.btnMnStaff.UseVisualStyleBackColor = true;
            this.btnMnStaff.Click += new System.EventHandler(this.btnMnStaff_Click);
            // 
            // Admin
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Admin";
            this.Text = "Admin";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnMnStaff;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnMnPhone;
        private System.Windows.Forms.Button btnLogout;

        private System.Windows.Forms.Button btnExit_Login;

    }
}

