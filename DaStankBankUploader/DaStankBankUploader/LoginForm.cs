using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DaStankBankUploader
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();

            // check if we have saved user data
            if (!Properties.Settings.Default.firstTime)
            {
                txtWPpass.Text = Properties.Settings.Default.wpPass;
                txtWPuser.Text = Properties.Settings.Default.wpUser;
                txtWPUrl.Text = Properties.Settings.Default.wpURL;
                txtYTpass.Text = Properties.Settings.Default.ytPass;
                txtYTuser.Text = Properties.Settings.Default.ytUser;
            }
        }

        private void txtEditBoxes_TextChanged(object sender, EventArgs e)
        {
            ((TextBox)sender).ForeColor = Color.Black;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            // create a new user object and log in
            User.login(txtYTuser.Text, txtYTpass.Text, txtWPuser.Text, txtWPpass.Text, txtWPUrl.Text);

            this.Close();
            this.Dispose();
        }

        private void btnEnd_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
