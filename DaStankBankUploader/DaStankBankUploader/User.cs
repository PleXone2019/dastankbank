using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Google.GData.Client;
using Google.GData.Extensions;
using Google.GData.YouTube;
using Google.GData.Extensions.MediaRss;
using Google.YouTube;
using System.Xml;

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

        /// <summary>
        /// Youtube Categories
        /// From: http://gdata.youtube.com/schemas/2007/categories.cat
        /// </summary>
        static Dictionary<string, string> cats = new Dictionary<string, string>();

        public static Dictionary<string, string> YTCategories
        {
            get
            {
                if (cats.Count == 0)
                {
                    string catURL = "http://gdata.youtube.com/schemas/2007/categories.cat";

                    Console.WriteLine("Getting YT Cats...");
                    XmlTextReader xml = new XmlTextReader(catURL);
                    while (xml.Read())
                    {
                        XmlNodeType nType = xml.NodeType;
                        if (nType == XmlNodeType.Element && xml.Name.ToString() == "atom:category")
                        {
                            Console.WriteLine(xml["term"] + " -> " + xml["label"]);
                            cats.Add(xml["term"], xml["label"]);
                        }
                    }
                }
                return cats;
            }
        }

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
