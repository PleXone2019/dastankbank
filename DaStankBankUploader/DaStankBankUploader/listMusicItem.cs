using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ID3;
using ID3.ID3v2Frames.BinaryFrames;
using System.IO;
using System.Drawing;

namespace DaStankBankUploader
{
    /// <summary>
    /// A set of actions to perform on the UI
    /// </summary>
    public delegate void UIActions();

    /// <summary>
    /// A music item that's in the list.
    /// </summary>
    class listMusicItem : Object
    {
        public string path = "";
        public string bg = "";
        private string outpath;

        // mp3 data
        public string title;
        public string artist;
        public string album;

        public Image[] images; // things like album art

        // if set to true, then we'll look at the "albumArt" string for path
        // to the album art image
        public bool customAlbumArt = false;
        public string albumArt = "";

        public VideoFromMusic v;

        public listMusicItem(string path, string bg, string outpath)
        {
            this.path = path;
            updatePaths(bg, outpath);

            // get ze id3 dataz!
            // http://www.codeproject.com/KB/cs/Do_Anything_With_ID3.aspx
            ID3Info f = new ID3Info(path, true);
            ID3v2 id3 = f.ID3v2Info;

            this.title = id3.GetTextFrame("TIT2");
            this.artist = id3.GetTextFrame("TPE1");
            this.album = id3.GetTextFrame("TALB");

            Console.WriteLine("------ File ID3 data :: " + Path.GetFileName(path));
            Console.WriteLine("Title: " + title);
            Console.WriteLine("Artist: " + artist);
            Console.WriteLine("Album: " + album);
            
            // try to get any images if possible
            images = new Image[id3.AttachedPictureFrames.Count];
            for (int i = 0; i < id3.AttachedPictureFrames.Count; i++)
            {
                AttachedPictureFrame ap = id3.AttachedPictureFrames.Items[i];

                // :o SHOCK! HORROR! no seriously, who cares what goes wrong here...
                try { images[i] = Image.FromStream(ap.Data); }
                catch { }
            }

            Console.WriteLine("Images Found: " + images.Length.ToString());
        }

        public void updatePaths(string bg, string outpath)
        {
            this.bg = bg;
            this.outpath = outpath;
        }

        public override string ToString()
        {
            return Path.GetFileName(path);
        }

        public void Render(ProgressBar pbarAudio, ProgressBar pbarVideo)
        {
            v = new VideoFromMusic(path, bg, outpath);
            v.Render(pbarAudio, pbarVideo);
        }
    }
}
