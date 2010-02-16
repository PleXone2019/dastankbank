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

            // get the user to log in...we need the data for later!
            LoginForm f = new LoginForm();
            f.ShowDialog();

            if (!User.loggedIn)
            {
                Console.WriteLine("Quit!");

                // user probably close dialog, quit
                Application.Exit();
                Environment.Exit(0);
            }

            // if we get to this point, we're logged in and good to go so time
            // to load saved data
            txtOutputDir.Text = Properties.Settings.Default.outputpath;
        }

        /// <summary>
        /// Let the user choose the output folder
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnChooseOutput_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.Description = "Choose a folder with the mp3 files you would like to convert.";

            if (f.ShowDialog() == DialogResult.OK)
            {
                txtOutputDir.Text = f.SelectedPath;
            }
        }

        /// <summary>
        /// Let the user add a single file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog f = new OpenFileDialog();
            f.CheckFileExists = true;
            f.CheckPathExists = true;
            f.Filter = "MP3 Files (*.mp3)|*.mp3|All files (*.*)|*.*";
            f.Multiselect = true;
            f.Title = "Choose music files to add...";
            if (f.ShowDialog() == DialogResult.OK)
            {
                foreach (string name in f.FileNames)
                {
                    Console.WriteLine(name);
                }
            }
        }

        /// <summary>
        /// Deselect (un check) all items
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void deselectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Select (check) all items
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Begin the rendering process and then upload
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.outputpath = txtOutputDir.Text;
            Properties.Settings.Default.Save();

            // hide button, show progress stuff
            btnRender.Visible = false;

            lblCurrent.Visible = true;
            lblTotal.Visible = true;
            pbarCurFile.Visible = true;
            pbarTotal.Visible = true;
            btnCancel.Visible = true;

            foreach (String i in listFiles.CheckedItems)
            {
                Console.WriteLine(i);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            // hide progress stuff, show button
            btnRender.Visible = true;

            lblCurrent.Visible = false;
            lblTotal.Visible = false;
            pbarCurFile.Visible = false;
            pbarTotal.Visible = false;
            btnCancel.Visible = false;
        }
    }
}
