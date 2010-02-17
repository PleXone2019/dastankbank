﻿using System;
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

        public PercentageProgressParticipant[] audioProgress = new PercentageProgressParticipant[1];
        public PercentageProgressParticipant[] videoProgress = new PercentageProgressParticipant[1];

        /// <summary>
        /// A video to be created from a music file.
        /// </summary>
        /// <param name="PathToMP3File">the path to the mp3 file to make into a video</param>
        /// <param name="backgroundImage">the background (static) image's path to use in the video</param>
        /// <param name="outpath">where to save the file</param>
        public VideoFromMusic(string PathToMP3File, string backgroundImage, string outpath)
        {
            // get all the path data
            mp3path = Path.GetFullPath(PathToMP3File);
            mp3name = Path.GetFileNameWithoutExtension(PathToMP3File);
            this.backgroundImage = Path.GetFullPath(backgroundImage);
            videoname = mp3name + ".avi";
            //videoname = Path.GetFileNameWithoutExtension(Path.GetTempFileName()) + ".avi";
            //videopath = Path.Combine(Path.GetDirectoryName(mp3path), videoname);
            videopath = Path.Combine(outpath, videoname);

            Console.WriteLine("Video From Music");
            Console.WriteLine("mp3path: " + mp3path);
            Console.WriteLine("mp3name: " + mp3name);
            Console.WriteLine("backgroundImage: " + this.backgroundImage);
            Console.WriteLine("videoName: " + videoname);
            Console.WriteLine("videopath: " + videopath);
        }

        /// <summary>
        /// Render the video from the music file/background image, asynchronously.
        /// 
        /// Attach event handlers to audioProgress[0] and videoProgress[0] to monitor 
        /// progress, AFTER this function has been called!
        /// </summary>
        public void Render()
        {
            Console.WriteLine("\nBegin render...");
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

                // render our video out
                Console.Write("Render Start...");
                renderer = new Splicer.Renderer.WindowsMediaRenderer(
                    timeline, videopath, WindowsMediaProfiles.HighQualityVideo, 
                    videoProgress, audioProgress);
                renderer.Render();
                Console.WriteLine("Render Completed.");

                //AsyncCallback cb = new AsyncCallback(CallBack);
                //IAsyncResult ar = renderer.BeginRender(cb, renderer.State);
            }
        }

        /*
        private void CallBack(IAsyncResult ar)
        {
            renderer.EndRender(ar);

            // block until done
            while (renderer.State != RendererState.GraphCompleted) { }
            Console.WriteLine("Render Completed.");
        }
         * */
    }
}
