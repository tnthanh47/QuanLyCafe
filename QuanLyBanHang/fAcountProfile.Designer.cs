namespace QuanLyBanHang
{
    partial class fAcountProfile
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fAcountProfile));
            this.label1 = new System.Windows.Forms.Label();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.bunifuGradientPanel1 = new Bunifu.Framework.UI.BunifuGradientPanel();
            this.txbType = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txbRePassword = new System.Windows.Forms.TextBox();
            this.lbRePassword = new System.Windows.Forms.Label();
            this.txbNewPassword = new System.Windows.Forms.TextBox();
            this.lbNewPassword = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txbPassword = new System.Windows.Forms.TextBox();
            this.txbDisplayName = new System.Windows.Forms.TextBox();
            this.lbPassword = new System.Windows.Forms.Label();
            this.lbDisplayName = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txbAccount = new System.Windows.Forms.TextBox();
            this.lbAccount = new System.Windows.Forms.Label();
            this.bunifuGradientPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 423);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 20);
            this.label1.TabIndex = 5;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(461, 731);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(130, 45);
            this.btnUpdate.TabIndex = 6;
            this.btnUpdate.Text = "Cập nhật";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnExit
            // 
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.Location = new System.Drawing.Point(617, 731);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(130, 45);
            this.btnExit.TabIndex = 7;
            this.btnExit.Text = "Thoát";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // bunifuGradientPanel1
            // 
            this.bunifuGradientPanel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuGradientPanel1.BackgroundImage")));
            this.bunifuGradientPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bunifuGradientPanel1.Controls.Add(this.txbType);
            this.bunifuGradientPanel1.Controls.Add(this.label4);
            this.bunifuGradientPanel1.Controls.Add(this.txbRePassword);
            this.bunifuGradientPanel1.Controls.Add(this.lbRePassword);
            this.bunifuGradientPanel1.Controls.Add(this.txbNewPassword);
            this.bunifuGradientPanel1.Controls.Add(this.lbNewPassword);
            this.bunifuGradientPanel1.Controls.Add(this.label3);
            this.bunifuGradientPanel1.Controls.Add(this.txbPassword);
            this.bunifuGradientPanel1.Controls.Add(this.txbDisplayName);
            this.bunifuGradientPanel1.Controls.Add(this.lbPassword);
            this.bunifuGradientPanel1.Controls.Add(this.lbDisplayName);
            this.bunifuGradientPanel1.Controls.Add(this.label2);
            this.bunifuGradientPanel1.Controls.Add(this.txbAccount);
            this.bunifuGradientPanel1.Controls.Add(this.lbAccount);
            this.bunifuGradientPanel1.GradientBottomLeft = System.Drawing.SystemColors.HotTrack;
            this.bunifuGradientPanel1.GradientBottomRight = System.Drawing.SystemColors.ActiveCaption;
            this.bunifuGradientPanel1.GradientTopLeft = System.Drawing.Color.Tan;
            this.bunifuGradientPanel1.GradientTopRight = System.Drawing.Color.SandyBrown;
            this.bunifuGradientPanel1.Location = new System.Drawing.Point(-4, -2);
            this.bunifuGradientPanel1.Name = "bunifuGradientPanel1";
            this.bunifuGradientPanel1.Quality = 10;
            this.bunifuGradientPanel1.Size = new System.Drawing.Size(779, 803);
            this.bunifuGradientPanel1.TabIndex = 9;
            // 
            // txbType
            // 
            this.txbType.Location = new System.Drawing.Point(331, 291);
            this.txbType.Name = "txbType";
            this.txbType.ReadOnly = true;
            this.txbType.Size = new System.Drawing.Size(381, 26);
            this.txbType.TabIndex = 10;
            this.txbType.Tag = "Loại tài khoản";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(80, 280);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(244, 37);
            this.label4.TabIndex = 9;
            this.label4.Tag = "";
            this.label4.Text = "Loại tài khoản:";
            // 
            // txbRePassword
            // 
            this.txbRePassword.Location = new System.Drawing.Point(331, 610);
            this.txbRePassword.Name = "txbRePassword";
            this.txbRePassword.Size = new System.Drawing.Size(381, 26);
            this.txbRePassword.TabIndex = 1;
            this.txbRePassword.UseSystemPasswordChar = true;
            // 
            // lbRePassword
            // 
            this.lbRePassword.AutoSize = true;
            this.lbRePassword.BackColor = System.Drawing.Color.Transparent;
            this.lbRePassword.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbRePassword.Location = new System.Drawing.Point(172, 599);
            this.lbRePassword.Name = "lbRePassword";
            this.lbRePassword.Size = new System.Drawing.Size(152, 37);
            this.lbRePassword.TabIndex = 0;
            this.lbRePassword.Text = "Nhập lại:";
            // 
            // txbNewPassword
            // 
            this.txbNewPassword.Location = new System.Drawing.Point(331, 534);
            this.txbNewPassword.Name = "txbNewPassword";
            this.txbNewPassword.Size = new System.Drawing.Size(381, 26);
            this.txbNewPassword.TabIndex = 1;
            this.txbNewPassword.UseSystemPasswordChar = true;
            // 
            // lbNewPassword
            // 
            this.lbNewPassword.AutoSize = true;
            this.lbNewPassword.BackColor = System.Drawing.Color.Transparent;
            this.lbNewPassword.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNewPassword.Location = new System.Drawing.Point(88, 523);
            this.lbNewPassword.Name = "lbNewPassword";
            this.lbNewPassword.Size = new System.Drawing.Size(236, 37);
            this.lbNewPassword.TabIndex = 0;
            this.lbNewPassword.Text = "Mật khẩu mới:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Purple;
            this.label3.Location = new System.Drawing.Point(41, 435);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(275, 33);
            this.label3.TabIndex = 8;
            this.label3.Text = "Thay đổi mật khẩu:";
            // 
            // txbPassword
            // 
            this.txbPassword.Location = new System.Drawing.Point(331, 361);
            this.txbPassword.Name = "txbPassword";
            this.txbPassword.Size = new System.Drawing.Size(381, 26);
            this.txbPassword.TabIndex = 1;
            this.txbPassword.UseSystemPasswordChar = true;
            // 
            // txbDisplayName
            // 
            this.txbDisplayName.Location = new System.Drawing.Point(331, 217);
            this.txbDisplayName.Name = "txbDisplayName";
            this.txbDisplayName.Size = new System.Drawing.Size(381, 26);
            this.txbDisplayName.TabIndex = 1;
            // 
            // lbPassword
            // 
            this.lbPassword.AutoSize = true;
            this.lbPassword.BackColor = System.Drawing.Color.Transparent;
            this.lbPassword.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPassword.Location = new System.Drawing.Point(158, 350);
            this.lbPassword.Name = "lbPassword";
            this.lbPassword.Size = new System.Drawing.Size(166, 37);
            this.lbPassword.TabIndex = 0;
            this.lbPassword.Text = "Mật khẩu:";
            // 
            // lbDisplayName
            // 
            this.lbDisplayName.AutoSize = true;
            this.lbDisplayName.BackColor = System.Drawing.Color.Transparent;
            this.lbDisplayName.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDisplayName.Location = new System.Drawing.Point(116, 206);
            this.lbDisplayName.Name = "lbDisplayName";
            this.lbDisplayName.Size = new System.Drawing.Size(208, 37);
            this.lbDisplayName.TabIndex = 0;
            this.lbDisplayName.Text = "Tên hiển thị:";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Purple;
            this.label2.Location = new System.Drawing.Point(41, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(310, 47);
            this.label2.TabIndex = 2;
            this.label2.Text = "Thông tin tài khoản:";
            // 
            // txbAccount
            // 
            this.txbAccount.Location = new System.Drawing.Point(331, 134);
            this.txbAccount.Name = "txbAccount";
            this.txbAccount.ReadOnly = true;
            this.txbAccount.Size = new System.Drawing.Size(381, 26);
            this.txbAccount.TabIndex = 1;
            this.txbAccount.TextChanged += new System.EventHandler(this.txbAccount_TextChanged);
            // 
            // lbAccount
            // 
            this.lbAccount.AutoSize = true;
            this.lbAccount.BackColor = System.Drawing.Color.Transparent;
            this.lbAccount.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbAccount.Location = new System.Drawing.Point(71, 123);
            this.lbAccount.Name = "lbAccount";
            this.lbAccount.Size = new System.Drawing.Size(253, 37);
            this.lbAccount.TabIndex = 0;
            this.lbAccount.Text = "Tên đăng nhập:";
            // 
            // fAcountProfile
            // 
            this.AcceptButton = this.btnUpdate;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.CancelButton = this.btnExit;
            this.ClientSize = new System.Drawing.Size(774, 800);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bunifuGradientPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "fAcountProfile";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thông tin tài khoản";
            this.bunifuGradientPanel1.ResumeLayout(false);
            this.bunifuGradientPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txbAccount;
        private System.Windows.Forms.Label lbAccount;
        private System.Windows.Forms.TextBox txbDisplayName;
        private System.Windows.Forms.Label lbDisplayName;
        private System.Windows.Forms.TextBox txbPassword;
        private System.Windows.Forms.Label lbPassword;
        private System.Windows.Forms.TextBox txbNewPassword;
        private System.Windows.Forms.Label lbNewPassword;
        private System.Windows.Forms.TextBox txbRePassword;
        private System.Windows.Forms.Label lbRePassword;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label label3;
        private Bunifu.Framework.UI.BunifuGradientPanel bunifuGradientPanel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txbType;
        private System.Windows.Forms.Label label4;
    }
}