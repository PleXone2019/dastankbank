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

            // poll WP for tags

            // select first item
            lstItems.SelectedIndex = 0;
        }

        private void doDefaultTexts()
        {
            txtYTDesc.Text = @"Da Stank Bank
Music Blog For Drum & Bass, Dubstep, Electro

Youtube:
http://www.youtube.com/user/Dastankbank
Blog:
http://www.theootz.com/dastankbank/
Facebook:
http://www.facebook.com/pages/Toronto-ON/Da-Stank-Bank/257926353411?ref=ts";

            txtWPPost.Text = "%albumart% \n" +
"<object classid=\"clsid:d27cdb6e-ae6d-11cf-96b8-444553540000\" width=\"480\" height=\"295\" codebase=\"http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=6,0,40,0\"><param name=\"allowFullScreen\" value=\"true\" /><param name=\"allowscriptaccess\" value=\"always\" /><param name=\"src\" value=\"http://www.youtube.com/v/%YTID%&hl=en_US&fs=1&rel=0&color1=0x3873bd&color2=0x3873bd\" /><param name=\"allowfullscreen\" value=\"true\" /><embed type=\"application/x-shockwave-flash\" width=\"480\" height=\"295\" src=\"http://www.youtube.com/v/%YTID%&hl=en_US&fs=1&rel=0&color1=0x3873bd&color2=0x3873bd\" allowscriptaccess=\"always\" allowfullscreen=\"true\"></embed></object>";

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

            // load data -- panel 3

            // load data -- panel 4
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
            i.artist = txtArtist.Text;
            i.album = txtAlbum.Text;
            i.title = txtTitle.Text;

            Console.WriteLine("Done!");
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
            this.Close();
        }
    }
}
