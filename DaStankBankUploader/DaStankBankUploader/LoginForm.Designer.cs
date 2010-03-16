namespace DaStankBankUploader
{
    partial class LoginForm
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
            this.lblYoutube = new System.Windows.Forms.Label();
            this.lblWordpress = new System.Windows.Forms.Label();
            this.txtYTuser = new System.Windows.Forms.TextBox();
            this.txtYTpass = new System.Windows.Forms.TextBox();
            this.txtWPpass = new System.Windows.Forms.TextBox();
            this.txtWPuser = new System.Windows.Forms.TextBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.txtWPUrl = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblYoutube
            // 
            this.lblYoutube.AutoSize = true;
            this.lblYoutube.Font = new System.Drawing.Font("Calibri", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblYoutube.Location = new System.Drawing.Point(12, 9);
            this.lblYoutube.Name = "lblYoutube";
            this.lblYoutube.Size = new System.Drawing.Size(127, 39);
            this.lblYoutube.TabIndex = 0;
            this.lblYoutube.Text = "youtube";
            // 
            // lblWordpress
            // 
            this.lblWordpress.AutoSize = true;
            this.lblWordpress.Font = new System.Drawing.Font("Calibri", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWordpress.Location = new System.Drawing.Point(12, 127);
            this.lblWordpress.Name = "lblWordpress";
            this.lblWordpress.Size = new System.Drawing.Size(156, 39);
            this.lblWordpress.TabIndex = 1;
            this.lblWordpress.Text = "wordpress";
            // 
            // txtYTuser
            // 
            this.txtYTuser.BackColor = System.Drawing.SystemColors.Control;
            this.txtYTuser.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtYTuser.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtYTuser.ForeColor = System.Drawing.Color.LightGray;
            this.txtYTuser.Location = new System.Drawing.Point(19, 52);
            this.txtYTuser.Name = "txtYTuser";
            this.txtYTuser.Size = new System.Drawing.Size(185, 33);
            this.txtYTuser.TabIndex = 1;
            this.txtYTuser.Text = "username";
            this.txtYTuser.TextChanged += new System.EventHandler(this.txtEditBoxes_TextChanged);
            // 
            // txtYTpass
            // 
            this.txtYTpass.BackColor = System.Drawing.SystemColors.Control;
            this.txtYTpass.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtYTpass.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtYTpass.ForeColor = System.Drawing.Color.LightGray;
            this.txtYTpass.Location = new System.Drawing.Point(19, 91);
            this.txtYTpass.Name = "txtYTpass";
            this.txtYTpass.PasswordChar = '*';
            this.txtYTpass.Size = new System.Drawing.Size(185, 33);
            this.txtYTpass.TabIndex = 2;
            this.txtYTpass.Text = "pass";
            this.txtYTpass.TextChanged += new System.EventHandler(this.txtEditBoxes_TextChanged);
            // 
            // txtWPpass
            // 
            this.txtWPpass.BackColor = System.Drawing.SystemColors.Control;
            this.txtWPpass.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtWPpass.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtWPpass.ForeColor = System.Drawing.Color.LightGray;
            this.txtWPpass.Location = new System.Drawing.Point(19, 208);
            this.txtWPpass.Name = "txtWPpass";
            this.txtWPpass.PasswordChar = '*';
            this.txtWPpass.Size = new System.Drawing.Size(185, 33);
            this.txtWPpass.TabIndex = 5;
            this.txtWPpass.Text = "pass";
            this.txtWPpass.TextChanged += new System.EventHandler(this.txtEditBoxes_TextChanged);
            // 
            // txtWPuser
            // 
            this.txtWPuser.BackColor = System.Drawing.SystemColors.Control;
            this.txtWPuser.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtWPuser.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtWPuser.ForeColor = System.Drawing.Color.LightGray;
            this.txtWPuser.Location = new System.Drawing.Point(19, 169);
            this.txtWPuser.Name = "txtWPuser";
            this.txtWPuser.Size = new System.Drawing.Size(185, 33);
            this.txtWPuser.TabIndex = 4;
            this.txtWPuser.Text = "username";
            this.txtWPuser.TextChanged += new System.EventHandler(this.txtEditBoxes_TextChanged);
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(19, 286);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(185, 50);
            this.btnLogin.TabIndex = 7;
            this.btnLogin.Text = "login";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // txtWPUrl
            // 
            this.txtWPUrl.BackColor = System.Drawing.SystemColors.Control;
            this.txtWPUrl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtWPUrl.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtWPUrl.ForeColor = System.Drawing.Color.LightGray;
            this.txtWPUrl.Location = new System.Drawing.Point(19, 247);
            this.txtWPUrl.Name = "txtWPUrl";
            this.txtWPUrl.Size = new System.Drawing.Size(185, 33);
            this.txtWPUrl.TabIndex = 8;
            this.txtWPUrl.Text = "www.url.to/wordpress";
            // 
            // LoginForm
            // 
            this.AcceptButton = this.btnLogin;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(222, 352);
            this.Controls.Add(this.txtWPUrl);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.txtWPpass);
            this.Controls.Add(this.txtWPuser);
            this.Controls.Add(this.txtYTpass);
            this.Controls.Add(this.txtYTuser);
            this.Controls.Add(this.lblWordpress);
            this.Controls.Add(this.lblYoutube);
            this.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "LoginForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DaStankBank Login";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblYoutube;
        private System.Windows.Forms.Label lblWordpress;
        private System.Windows.Forms.TextBox txtYTuser;
        private System.Windows.Forms.TextBox txtYTpass;
        private System.Windows.Forms.TextBox txtWPpass;
        private System.Windows.Forms.TextBox txtWPuser;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.TextBox txtWPUrl;
    }
}

