using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace getsetcode.Helpers
{
    public static class EmmaMorris
    {
        public static DateTime DotNetSkillsStartDate { get { return DateTime.Parse(ConfigurationManager.AppSettings["DotNetSkillsStartDate"]); } }

        public static string EmailRecipientAddress { get { return ConfigurationManager.AppSettings["EmailRecipientAddress"]; } }
        
        public static string EmailRecipientName { get { return ConfigurationManager.AppSettings["EmailRecipientName"]; } }

        public static string ContactMeSubject { get { return ConfigurationManager.AppSettings["ContactMeSubject"]; } }

        public static string SmtpServer { get { return ConfigurationManager.AppSettings["SmtpServer"]; } }

        public static int SmtpPort { get { return int.Parse(ConfigurationManager.AppSettings["SmtpPort"]); } }

        public static string SmtpUsername { get { return ConfigurationManager.AppSettings["SmtpUsername"]; } }

        public static string SmtpPassword { get { return ConfigurationManager.AppSettings["SmtpPassword"]; } }

        public static int DefaultThumbnailSize { get { return int.Parse(ConfigurationManager.AppSettings["DefaultThumbnailSize"]); } }

        public static string DefaultImageRoot { get { return ConfigurationManager.AppSettings["DefaultImageRoot"]; } }

        public static int DefaultPersonImageSize { get { return int.Parse(ConfigurationManager.AppSettings["DefaultPersonImageSize"]); } }

        public static string DefaultPersonImageFileName { get { return ConfigurationManager.AppSettings["DefaultPersonImageFileName"]; } }

        public static string DatabaseImageRoot { get { return ConfigurationManager.AppSettings["DatabaseImageRoot"]; } }

        public static int HistoryItemsPerLoad { get { return int.Parse(ConfigurationManager.AppSettings["HistoryItemsPerLoad"]); } }
    }
}
