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
    public partial class ModifyItems : Form
    {
        HashSet<listMusicItem> items = new HashSet<listMusicItem>();

        public ModifyItems(System.Windows.Forms.CheckedListBox.CheckedItemCollection i)
        {
            foreach (listMusicItem e in i)
                items.Add(e);

            InitializeComponent();
            doDefaultTexts();
            InitData();
        }
        public ModifyItems(System.Windows.Forms.CheckedListBox.ObjectCollection i)
        {
            foreach (listMusicItem e in i)
                items.Add(e);

            InitializeComponent();
            doDefaultTexts();
            InitData();
        }

        public ModifyItems()
        {
            InitializeComponent();
            doDefaultTexts();
        }

        private void InitData()
        {
            // add music items
            foreach (listMusicItem e in items)
            {
                lstItems.Items.Add(e);
            }

            // poll WP for categories

            // poll YT for categories
            cmbYTCat.Items.Clear();
            foreach (string key in User.YTCategories.Keys)
            {
                cmbYTCat.Items.Add(User.YTCategories[key]);
            }

            // poll WP for tags

            // select first item
            lstItems.SelectedIndex = 0;
        }

        private void doDefaultTexts()
        {
            txtWPTags.Text = @"The following is a list of valid post tags:
%albumart% - the album art image
%YTvideo% - the embedded video (default settings)
%YTID% - the youtube video ID (for your own embedding)";
        }

        /// <summary>
        /// This event occurs when the selected item is changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lstItems_SelectedValueChanged(object sender, EventArgs e)
        {
            // check if we wish to save?

            // load data -- panel 1
            listMusicItem sel = (listMusicItem)lstItems.SelectedItem;
            txtAlbum.Text = sel.album;
            txtArtist.Text = sel.artist;
            txtTitle.Text = sel.title;

            if (sel.ytCat != "")
            {
                cmbYTCat.SelectedItem = sel.ytCat;
            }
            else
            {
                cmbYTCat.SelectedItem = null;
            }

            sel.ytTags = txtYTTags.Text;
            sel.wpTags = txtWPTags.Text;

            // load data -- panel 2
            System.Drawing.Image.GetThumbnailImageAbort d = new Image.GetThumbnailImageAbort(ImageAborted);
            if (sel.bg != "")
            {
                Image img = Image.FromFile(sel.bg, true);
                btnVideoBG.Image = img.GetThumbnailImage(195, 162, d, System.IntPtr.Zero);
                btnVideoBG.Text = "";
                txtBGpath.Text = sel.bg;
            }
            else
            {
                btnVideoBG.Image = null;
                btnVideoBG.Text = "n/a";
                txtBGpath.Text = "";
            }

            if (sel.images.Length > 0 && sel.images[0] != null)
            {
                // we'll just load the first image...
                Image img = sel.images[0];
                btnAlbumArt.Image = img.GetThumbnailImage(195, 162, d, System.IntPtr.Zero);
                btnAlbumArt.Text = "";
                txtBGpath.Text = "";
            }
            else if (sel.customAlbumArt)
            {
                // see if there is an image path specified
                Image img = Image.FromFile(sel.albumArt);
                btnAlbumArt.Image = img.GetThumbnailImage(195, 162, d, System.IntPtr.Zero);
                btnAlbumArt.Text = "";
                txtAlbumPath.Text = sel.albumArt;
            }
            else
            {
                btnAlbumArt.Image = null;
                btnAlbumArt.Text = "n/a";
                txtAlbumPath.Text = "";
            }

            // load data -- panel 3+4
            if (sel.WPPost == "")
            {
                txtWPPost.Text = Properties.Settings.Default.wpPost;
            }
            else
            {
                txtYTDesc.Text = sel.WPPost;
            }

            if (sel.YTDesc == "")
            {
                txtYTDesc.Text = Properties.Settings.Default.ytDesc;
            }
            else
            {
                txtYTDesc.Text = sel.YTDesc;
            }
        }

        // some random unused crap, meh
        bool ImageAborted()
        {
            return false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Saving...");

            listMusicItem i = (listMusicItem)lstItems.SelectedItem;

            // panel 1
            i.artist = txtArtist.Text;
            i.album = txtAlbum.Text;
            i.title = txtTitle.Text;

            if (cmbYTCat.SelectedItem != null)
            {
                i.ytCat = cmbYTCat.SelectedItem.ToString();
            }

            txtYTTags.Text = i.ytTags;
            txtWPTags.Text = i.wpTags;

            // panel 2

            // panel 3 + 4
            if (txtYTDesc.Text != Properties.Settings.Default.ytDesc)
            {
                i.YTDesc = txtYTDesc.Text;
            }
            else
            {
                i.YTDesc = "";
            }

            if (txtWPPost.Text != Properties.Settings.Default.wpPost)
            {
                i.WPPost = txtWPPost.Text;
            }
            else
            {
                i.WPPost = "";
            }

            Console.WriteLine("Done!");
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.ytDesc = txtYTDesc.Text;
            MessageBox.Show(
                "Default set to: \n" + Properties.Settings.Default.ytDesc, 
                "New Default Set!", 
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnWPPostDef_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.wpPost = txtWPPost.Text;
            MessageBox.Show(
                "Default set to: \n" + Properties.Settings.Default.wpPost,
                "New Default Set!",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnWPPostReset_Click(object sender, EventArgs e)
        {
            txtWPPost.Text = Properties.Settings.Default.wpPost;
        }

        private void btnYTDescReset_Click(object sender, EventArgs e)
        {
            txtYTDesc.Text = Properties.Settings.Default.ytDesc;
        }
    }
}
