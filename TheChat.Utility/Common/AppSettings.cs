using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheChat.Utility.Common
{
    public static class AppSettings
    {
        static AppSettings()
        {
            IConfigurationRoot objConfig = new ConfigurationBuilder()
                                   .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                                   .AddJsonFile("appsettings.json")
                                   .Build();

            MySQLConnectionString = objConfig.GetValue<string>("ConnectionStrings:MySQLConnectionString");
            MySQLConnectionStringForMessage = objConfig.GetValue<string>("ConnectionStrings:MySQLConnectionStringForMessage");


            JwtKey = "MEQO3WI7JK2VNoaDvbncja/ZkqPLMNB30c+aR4yHzygn5qNBVcvbtBpw4+SwZh4+NBVCXi3KJHlSXKPri6bXr8==";
            JwtIssuer = "Pintube";
            JwtAudience = "Audience";
            JwtAddExpireTime = "260000";

            // email alert for test environment



            //email alert for live environment

            EmailHost = "smtp.zoho.eu";
            EmailPort = 587;
            EmailFrom = "alerts@namesapp.com";
            EmailPass = "2AvMXrktRMAk";
            EmailAlias = "TheChat";
            EmailEnableSsl = true;

            UserStatus = objConfig.GetValue<string>("UserStatus");
            LiveURL = objConfig.GetValue<string>("LiveURL");
            WithOrigins = objConfig.GetValue<string>("WithOrigins").Split(",");
            DocumentUploadURL = objConfig.GetValue<string>("DocumentUploadURL");
            FeedBackSendMailAddress = "feedback@pintube.com";
            ReportUserSendMailAddress = "reportuser@pintube.com";
            PintubeDefaultPassword = "A!b@c#d$Pintube2018";
            ExternalCompanies = new string[] { "CV-Library","Pintube" };

        }

        public static string MySQLConnectionString { get; }
        public static string MySQLConnectionStringForMessage { get; }
        public static string JwtKey { get; }
        public static string JwtIssuer { get; }
        public static string JwtAudience { get; }
        public static string JwtAddExpireTime { get; }

        public static string EmailHost { get; }
        public static int EmailPort { get; }
        public static string EmailFrom { get; }
        public static string EmailPass { get; }
        public static string EmailAlias { get; }
        public static bool EmailEnableSsl { get; }


        public static string UserStatus { get; }

        public static string LiveURL { get; }

        public static string[] WithOrigins { get; }

        public static string DocumentUploadURL { get; }

        public static string FeedBackSendMailAddress { get; }

        public static string ReportUserSendMailAddress { get; }

        public static string PintubeDefaultPassword { get; }

        public static string[] ExternalCompanies { get; }

        public static string HttpRequestTokenVariable { get; set; } = "Authorization";

        public static string HttpRequestTokenVariable1 { get; set; } = "TOKEN_NO";

        public static string MobileNotificationAPIEndPoint { get; set; } = "https://exp.host/--/api/v2/push/send";
    }
}
