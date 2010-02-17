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
            txtBGImage.Text = Properties.Settings.Default.bgimage;
        }

        private void addPathsToList(string[] paths)
        {
            foreach (string p in paths)
                addPathsToList(p);
        }

        private void addPathsToList(string path)
        {
            listMusicItem i = new listMusicItem(path);
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
                addPathsToList(f.FileNames);
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

            lblCurrent.Visible = true;
            lblTotal.Visible = true;
            pbarCurFileA.Visible = true;
            pbarCurFileV.Visible = true;
            pbarTotal.Visible = true;
            btnCancel.Visible = true;

            pbarTotal.Maximum = listFiles.Items.Count;
            pbarTotal.Value = 0;

            // do rendering stuff here
            foreach (listMusicItem i in listFiles.Items)
            {
                pbarCurFileA.Value = 0;
                pbarCurFileV.Value = 0;

                i.Render(pbarCurFileA, pbarCurFileV, txtBGImage.Text, txtOutputDir.Text);

                pbarTotal.Value = pbarTotal.Value + 1;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            // hide progress stuff, show button
            btnRender.Visible = true;

            lblCurrent.Visible = false;
            lblTotal.Visible = false;
            pbarCurFileA.Visible = false;
            pbarCurFileV.Visible = false;
            pbarTotal.Visible = false;
            btnCancel.Visible = false;
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
                txtBGImage.Text = f.FileName;
        }
    }

    /// <summary>
    /// Delegate to set progress bar status
    /// </summary>
    public delegate void ProgressBarSet(int value, ProgressBar pbar);

    /// <summary>
    /// A music item that's in the list.
    /// </summary>
    class listMusicItem : Object
    {
        private string path = "";
        private ProgressBar pbarA;
        private ProgressBar pbarV;
        private string bg;
        private string outpath;

        public VideoFromMusic v;

        public listMusicItem(string path)
        {
            this.path = path;
        }

        public override string ToString()
        {
            return path;
        }

        public void Render(ProgressBar pbarAudio, ProgressBar pbarVideo, string bg, string outpath)
        {
            this.pbarA = pbarAudio;
            this.pbarV = pbarVideo;
            this.bg = bg;
            this.outpath = outpath;

            v = new VideoFromMusic(path, bg, outpath);
            v.Render();
            v.audioProgress[0].ProgressChanged += new EventHandler<Splicer.Renderer.ProgressChangedEventArgs>(listMusicItem_ProgressChangedAudio);
            v.videoProgress[0].ProgressChanged += new EventHandler<Splicer.Renderer.ProgressChangedEventArgs>(listMusicItem_ProgressChangedVideo);
        }

        void listMusicItem_ProgressChangedVideo(object sender, Splicer.Renderer.ProgressChangedEventArgs e)
        {
            Console.Write("V: ");
            ProgressBarSet d = new ProgressBarSet(SetProgressBarValue);
            pbarV.Invoke(d, new object[] { (int)Math.Round((e.Progress * 100), 0), pbarV });
            Console.WriteLine(pbarV.Value);
        }

        void listMusicItem_ProgressChangedAudio(object sender, Splicer.Renderer.ProgressChangedEventArgs e)
        {
            Console.Write("A: ");
            ProgressBarSet d = new ProgressBarSet(SetProgressBarValue);
            pbarA.Invoke(d, new object[] { (int)Math.Round((e.Progress * 100), 0), pbarA });
            Console.WriteLine(pbarA.Value);
        }

        void SetProgressBarValue(int i, ProgressBar p)
        {
            p.Value = i;
        }
    }
}
