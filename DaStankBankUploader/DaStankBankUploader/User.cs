using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Google.YouTube;

namespace DaStankBankUploader
{
    class User
    {
        String ytUser = "";
        String ytPass = "";
        String wpUser = "";
        String wpPass = "";
        bool hasData = false;

        YouTubeRequestSettings settings;
        YouTubeRequest request;

        public User(string ytUser, string ytPass, string wpUser, string wpPass)
        {
            Properties.Settings.Default.ytUser = this.ytUser = ytUser;
            Properties.Settings.Default.ytPass = this.ytPass = ytPass;
            Properties.Settings.Default.wpUser = this.wpUser = wpUser;
            Properties.Settings.Default.wpPass = this.wpPass = wpPass;

            Properties.Settings.Default.firstTime = false;

            hasData = true;

            Properties.Settings.Default.Save();
        }

        public bool login()
        {
            if (hasData)
            {
                settings = new YouTubeRequestSettings(
                    "Da Stank Bank",
                    Program.ytDevKey, this.ytUser, this.ytPass);
                request = new YouTubeRequest(settings);

                return true;
            }
            else
            {
                //TODO change to a custom exception
                throw new Exception("No User Data");
            }
        }
    }
}
