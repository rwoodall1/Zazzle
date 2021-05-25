using Core;
using System.Net.Mail;
namespace Utilities
{
    public class ApplicationConfig
    {
        //********************* DO NOT FORGET TO SET THE VALUE IN THE STARTUP FILE *******************************
        //********************************************************************************************************
        //********************************************************************************************************
        //********************************************************************************************************
        //********************************************************************************************************
        //********************************************************************************************************
        //********************************************************************************************************
        public static string DefaultConnectionString { get; set; }
        public static string ZazzleRootUrl { get; set; }
        public static string VendorId { get; set; }
        public static string SecretKey { get; set; }
        public static string AppVersion { get; set; }
          public static string Environment { get; set; }
        public static string CurrentYear { get; set; }
        public static string IsDeveloperMachine { get; set; }
        public static string ErrorEmailAddress { get; set; }
        public static SMTPConfig SMTPConfig { get; set; }

        //********************* DO NOT FORGET TO SET THE VALUE IN THE STARTUP FILE *******************************
        //********************************************************************************************************
        //********************************************************************************************************
        //********************************************************************************************************
        //********************************************************************************************************
        //********************************************************************************************************
        //********************************************************************************************************
    }
    public class SMTPConfig { 
        public string From { get; set; }
        public string Password { get; set; }
        public int Port { get; set; }
        public string Server { get; set; }
        public string User { get; set; }

    }
   }
