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
                f.ShowDialog();
            }
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
    }
}
