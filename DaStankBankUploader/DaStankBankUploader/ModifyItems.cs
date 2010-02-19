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
        public ModifyItems()
        {
            InitializeComponent();

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
    }
}
