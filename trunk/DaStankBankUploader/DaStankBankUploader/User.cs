using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        public static bool loggedIn = false;

        static YouTubeRequestSettings settings;
        static YouTubeRequest request;

        public static void login(string ytUser, string ytPass, string wpUser, string wpPass, string wpURL)
        {
            // save/set data
            Properties.Settings.Default.ytUser = User.ytUser = ytUser;
            Properties.Settings.Default.ytPass = User.ytPass = ytPass;
            Properties.Settings.Default.wpUser = User.wpUser = wpUser;
            Properties.Settings.Default.wpPass = User.wpPass = wpPass;
            Properties.Settings.Default.wpURL = User.wpURL = wpURL;
            Properties.Settings.Default.firstTime = false;
            Properties.Settings.Default.Save();

            ytLogin();

            loggedIn = true;
        }

        private static void ytLogin()
        {
            Console.Write("[yt] Logging in to: " + User.ytUser + " ...");
            settings = new YouTubeRequestSettings("Da Stank Bank", Program.ytDevKey, User.ytUser, User.ytPass);
            request = new YouTubeRequest(settings);
            Console.WriteLine("done.");
        }
    }
}
