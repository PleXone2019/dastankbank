using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace DaStankBankUploader
{
    static class Program
    {
        public static string ytDevKey = "AI39si7cCBBlWGtvH-LoOXo_d4qh6jkZWOyjJbeUA9HIBA_olm8hojE7gkeYo1ix0rEtiCT4eAzCe5dDksKyFtL1AukYms_xMA";

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Main());
        }
    }
}
