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
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();

            if (!User.loggedIn)
            {
                LoginForm f = new LoginForm();
                f.Show(this);
            }
        }
    }
}
