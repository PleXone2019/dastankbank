using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Splicer;
using Splicer.Timeline;
using Splicer.Renderer;
using Splicer.Utilities;
using Splicer.WindowsMedia;

namespace DaStankBankUploader
{
    /// <summary>
    /// This class takes an mp3 file (path) and creates/saves a video
    /// object in the same folder as the mp3 file.
    /// </summary>
    class VideoFromMusic
    {
        private string mp3path = "";
        private string mp3name = "";
        private string videoname = "";
        private string videopath = "";
        private string backgroundImage = "";
        public IRenderer renderer;

        ICallbackParticipant[] audioProgress;
        ICallbackParticipant[] videoProgress;

        public VideoFromMusic(string PathToMP3File, string backgroundImage)
        {
            audioProgress = new ICallbackParticipant[1];
            videoProgress = new ICallbackParticipant[1];

            // get all the path data
            mp3path = Path.GetFullPath(PathToMP3File);
            mp3name = Path.GetFileNameWithoutExtension(PathToMP3File);
            this.backgroundImage = Path.GetFullPath(backgroundImage);
            //videoname = mp3name + ".avi";
            videoname = Path.GetFileNameWithoutExtension(Path.GetTempFileName()) + ".avi";
            videopath = Path.Combine(Path.GetDirectoryName(mp3path), videoname);

            Console.WriteLine("Video From Music");
            Console.WriteLine("mp3path: " + mp3path);
            Console.WriteLine("mp3name: " + mp3name);
            Console.WriteLine("backgroundImage: " + this.backgroundImage);
            Console.WriteLine("videoName: " + videoname);
            Console.WriteLine("videopath: " + videopath);

            Render();
        }

        /// <summary>
        /// Render the video from the music file/background image
        /// </summary>
        public void Render()
        {
            Console.WriteLine("\n\nBegin render...");
            using (ITimeline timeline = new DefaultTimeline())
            {
                Console.Write("Create group...");
                // create our primary group
                IGroup group = timeline.AddVideoGroup("background", 15.0, 32, 720, 480);
                Console.WriteLine("done.");

                Console.Write("Create tracks...");
                // add a video and audio track to the group
                ITrack videoTrack = group.AddTrack();
                ITrack audioTrack = timeline.AddAudioGroup().AddTrack();
                Console.WriteLine("done.");

                // add the audio/bg image
                Console.Write("Create audio track...");
                IClip audio = audioTrack.AddAudio(this.mp3path);
                Console.WriteLine("done.");

                Console.Write("Create video track...");
                IClip clip1 = videoTrack.AddImage(this.backgroundImage, 0, audio.Duration);
                Console.WriteLine("done.");

                // set up progress indicators
                audioProgress[0] = new PercentageProgressParticipant(timeline);
                videoProgress[0] = new PercentageProgressParticipant(timeline);

                // render our video out to avi
                Console.Write("Render...");
                renderer = new Splicer.Renderer.WindowsMediaRenderer(
                    timeline, videopath, WindowsMediaProfiles.HighQualityVideo, videoProgress, audioProgress);
                renderer.Render();
                //AsyncCallback cb = new AsyncCallback(CallBack);
                //IAsyncResult ar = renderer.BeginRender(cb, renderer.State);
                Console.WriteLine("done.");
            }
        }

        private void CallBack(IAsyncResult ar)
        {
            Console.WriteLine("--- CALLBACK STARTED");
            //renderer.EndRender(ar);
            Console.WriteLine("--- CALLBACK ENDED");
        }
    }
}
