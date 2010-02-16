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
            this.chkYTsave = new System.Windows.Forms.CheckBox();
            this.chkWPsave = new System.Windows.Forms.CheckBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblYoutube
            // 
            this.lblYoutube.AutoSize = true;
            this.lblYoutube.Font = new System.Drawing.Font("Calibri", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblYoutube.Location = new System.Drawing.Point(12, 9);
            this.lblYoutube.Name = "lblYoutube";
            this.lblYoutube.Size = new System.Drawing.Size(126, 39);
            this.lblYoutube.TabIndex = 0;
            this.lblYoutube.Text = "Youtube";
            // 
            // lblWordpress
            // 
            this.lblWordpress.AutoSize = true;
            this.lblWordpress.Font = new System.Drawing.Font("Calibri", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWordpress.Location = new System.Drawing.Point(12, 156);
            this.lblWordpress.Name = "lblWordpress";
            this.lblWordpress.Size = new System.Drawing.Size(160, 39);
            this.lblWordpress.TabIndex = 1;
            this.lblWordpress.Text = "Wordpress";
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
            this.txtWPpass.Location = new System.Drawing.Point(19, 237);
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
            this.txtWPuser.Location = new System.Drawing.Point(19, 198);
            this.txtWPuser.Name = "txtWPuser";
            this.txtWPuser.Size = new System.Drawing.Size(185, 33);
            this.txtWPuser.TabIndex = 4;
            this.txtWPuser.Text = "username";
            this.txtWPuser.TextChanged += new System.EventHandler(this.txtEditBoxes_TextChanged);
            // 
            // chkYTsave
            // 
            this.chkYTsave.AutoSize = true;
            this.chkYTsave.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkYTsave.Location = new System.Drawing.Point(19, 131);
            this.chkYTsave.Name = "chkYTsave";
            this.chkYTsave.Size = new System.Drawing.Size(55, 22);
            this.chkYTsave.TabIndex = 3;
            this.chkYTsave.Text = "save";
            this.chkYTsave.UseVisualStyleBackColor = true;
            // 
            // chkWPsave
            // 
            this.chkWPsave.AutoSize = true;
            this.chkWPsave.Location = new System.Drawing.Point(19, 276);
            this.chkWPsave.Name = "chkWPsave";
            this.chkWPsave.Size = new System.Drawing.Size(55, 22);
            this.chkWPsave.TabIndex = 6;
            this.chkWPsave.Text = "save";
            this.chkWPsave.UseVisualStyleBackColor = true;
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(19, 304);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(185, 50);
            this.btnLogin.TabIndex = 7;
            this.btnLogin.Text = "login";
            this.btnLogin.UseVisualStyleBackColor = true;
            // 
            // LoginForm
            // 
            this.AcceptButton = this.btnLogin;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(222, 366);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.chkWPsave);
            this.Controls.Add(this.chkYTsave);
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
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DaStankBank Uploader";
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
        private System.Windows.Forms.CheckBox chkYTsave;
        private System.Windows.Forms.CheckBox chkWPsave;
        private System.Windows.Forms.Button btnLogin;
    }
}

