﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Google.GData.Client;
using Google.GData.Extensions;
using Google.GData.YouTube;
using Google.GData.Extensions.MediaRss;
using Google.YouTube;

namespace DaStankBankUploader
{
    static class User
    {
        static String ytUser = "";
        static String ytPass = "";
        static String wpUser = "";
        static String wpPass = "";
        static String wpURL = "";

        static YouTubeRequestSettings settings;
        static YouTubeRequest request;

        public static bool loggedIn = false;

        public static YouTubeRequest YTRequest
        {
            get { return request; }
        }

        public static YouTubeRequestSettings YTSettings
        {
            get { return settings; }
        }

        public static string YTUser
        {
            get { return ytUser; }
        }

        public static bool login(string ytUser, string ytPass, string wpUser, string wpPass, string wpURL)
        {
            // save/set data
            Properties.Settings.Default.ytUser = User.ytUser = ytUser;
            Properties.Settings.Default.ytPass = User.ytPass = ytPass;
            Properties.Settings.Default.wpUser = User.wpUser = wpUser;
            Properties.Settings.Default.wpPass = User.wpPass = wpPass;
            Properties.Settings.Default.wpURL = User.wpURL = wpURL;
            Properties.Settings.Default.firstTime = false;
            Properties.Settings.Default.Save();

            loggedIn = ytLogin();
            return loggedIn;
        }

        // youtube stuff

        // Should get these from http://gdata.youtube.com/schemas/2007/categories.cat
        public enum YTCatagory
        {
            Film,
            Autos,
            Music,
            Animals,
            Sports,
            Travel,
            Shortmov,
            Videoblog,
            Games,
            Comedy,
            People,
            News,
            Entertainment,
            Education,
            Howto,
            Nonprofit,
            Tech
        }

        private static bool ytLogin()
        {
            //http://trailsinthesand.com/programmatically-uploading-videos-to-youtube/ 
            Console.WriteLine("[yt] Logging in to: " + User.ytUser + " ...");
            settings = new YouTubeRequestSettings("Da Stank Bank", Program.ytDevKey, User.ytUser, User.ytPass);
            request = new YouTubeRequest(settings);

            string url = "http://gdata.youtube.com/feeds/api/users/" + User.ytUser + "/uploads";

            try
            {
                Feed<Video> videoFeed = request.Get<Video>(new Uri(url));
                foreach (Video entry in videoFeed.Entries)
                {
                    Console.WriteLine("Entry: " + entry.Id + " -> " + entry.Title);
                    if (entry.ReadOnly == false)
                    {
                        Console.WriteLine("\tVideo is editable by the current user.");
                    }
                }
            }
            catch (ClientFeedException e)
            {
                Console.WriteLine("E: " + e);
            }
            catch (GDataRequestException)
            {
                // if this happens we're likely NOT logged in!
                return false;
            }

            Console.WriteLine("done.");
            return true;
        }
    }
}
