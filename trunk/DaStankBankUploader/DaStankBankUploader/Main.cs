using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.IO;

namespace DaStankBankUploader
{
    public partial class Main : Form
    {
        Thread tRender;
        listMusicItem currentRenderingItem = null;

        public Main()
        {
            InitializeComponent();
            lblAudio.Visible = false;
            lblVideo.Visible = false;

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
            txtBGImage.Text = Properties.Settings.Default.bgimage;

            btnModify.Enabled = false;
        }

        private void addPathsToList(string[] paths)
        {
            foreach (string p in paths)
                addPathsToList(p);
        }

        private void addPathsToList(string path)
        {
            listMusicItem i = new listMusicItem(path, txtBGImage.Text, txtOutputDir.Text);
            listFiles.Items.Add(i);
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

                UpdateItemPaths();
            }
        }

        private void UpdateItemPaths()
        {
            foreach (listMusicItem i in listFiles.Items)
            {
                i.updatePaths(txtBGImage.Text, txtOutputDir.Text);
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
                addPathsToList(f.FileNames);
                btnModify.Enabled = true;
            }
        }

        /// <summary>
        /// Begin the rendering process and then upload
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            // TODO verify all image paths, music file paths, output path

            // save data
            Properties.Settings.Default.outputpath = txtOutputDir.Text;
            Properties.Settings.Default.bgimage = txtBGImage.Text;
            Properties.Settings.Default.Save();

            // hide button, show progress stuff
            btnRender.Visible = false;

            lblAudio.Visible = true;
            lblVideo.Visible = true;
            lblCurrent.Visible = true;
            lblTotal.Visible = true;
            pbarCurFileA.Visible = true;
            pbarCurFileV.Visible = true;
            pbarTotal.Visible = true;
            btnCancel.Visible = true;

            pbarTotal.Maximum = listFiles.Items.Count;
            pbarTotal.Value = 0;

            listFiles.Enabled = false;
            btnAddFile.Enabled = false;
            btnAddFolder.Enabled = false;
            btnChooseBG.Enabled = false;
            btnChooseOutput.Enabled = false;
            btnModify.Enabled = false;
            btnRemove.Enabled = false;
            txtBGImage.Enabled = false;
            txtOutputDir.Enabled = false;

            tRender = new Thread(doRender);
            tRender.Start();
        }

        private void doRender()
        {
            // do rendering stuff here
            foreach (listMusicItem i in listFiles.Items)
            {
                currentRenderingItem = i;
                //pbarCurFileA.Value = 0;
                //pbarCurFileV.Value = 0;
                ProgressBarSet d = new ProgressBarSet(SetProgressBarValue);
                pbarCurFileA.Invoke(d, new object[] { 0, pbarCurFileA });
                pbarCurFileV.Invoke(d, new object[] { 0, pbarCurFileV });

                i.Render(pbarCurFileA, pbarCurFileV);

                pbarTotal.Invoke(d, new object[] { pbarTotal.Value + 1, pbarTotal });
                //pbarTotal.Value = pbarTotal.Value + 1;
            }
            currentRenderingItem = null;

            UIActions de = new UIActions(RenderStopped);
            pbarTotal.Invoke(de);
        }

        void SetProgressBarValue(int i, ProgressBar p)
        {
            p.Value = i;
        }

        private void RenderStopped()
        {
            // hide progress stuff, show button
            btnRender.Visible = true;

            lblAudio.Visible = false;
            lblVideo.Visible = false;
            lblCurrent.Visible = false;
            lblTotal.Visible = false;
            pbarCurFileA.Visible = false;
            pbarCurFileV.Visible = false;
            pbarTotal.Visible = false;
            btnCancel.Visible = false;

            listFiles.Enabled = true;
            btnAddFile.Enabled = true;
            btnAddFolder.Enabled = true;
            btnChooseBG.Enabled = true;
            btnChooseOutput.Enabled = true;
            btnModify.Enabled = true;
            btnRemove.Enabled = true;
            txtBGImage.Enabled = true;
            txtOutputDir.Enabled = true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            RenderStopped();
        }

        /// <summary>
        /// Delete selected items from listbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRemove_Click(object sender, EventArgs e)
        {
            while ( listFiles.CheckedIndices.Count > 0 )
                listFiles.Items.RemoveAt(listFiles.CheckedIndices[0]);

            if (listFiles.Items.Count == 0)
                btnModify.Enabled = false;
        }
        
        /// <summary>
        /// Let the user choose the default background image for each
        /// video file.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnChooseBG_Click(object sender, EventArgs e)
        {
            OpenFileDialog f = new OpenFileDialog();
            f.CheckFileExists = true;
            f.CheckPathExists = true;
            f.Filter = "Image Files (*.jpg)|*.jpg|All files (*.*)|*.*";
            f.Multiselect = false;
            f.Title = "Choose the image file to use...";
            if (f.ShowDialog() == DialogResult.OK)
            {
                txtBGImage.Text = f.FileName;
                UpdateItemPaths();
            }
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            ModifyItems i;
            //if (listFiles.CheckedItems.Count > 0)
            //{
                // if items are checked, send only those to the form
                //i = new ModifyItems(listFiles.CheckedItems);
            //} else {
                // send all
                i = new ModifyItems(listFiles.Items);
            //}
            i.ShowDialog();
        }
    }
}
