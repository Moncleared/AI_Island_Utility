using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace AI_Island_Utility.Model
{
    public class DatabaseModel : ObservableObject
    {
        private string fUsername;
        public string Username
        {
            get { return fUsername; }
            set
            {
                if (value != fUsername)
                {
                    fUsername = value;
                    RaisePropertyChanged("Username");
                }
            }
        }

        private string fPassword;
        public string Password
        {
            get { return fPassword; }
            set
            {
                if (value != fPassword)
                {
                    fPassword = value;
                    RaisePropertyChanged("Password");
                }
            }
        }

        private string fHost;
        public string Host
        {
            get { return fHost; }
            set
            {
                if (value != fHost)
                {
                    fHost = value;
                    RaisePropertyChanged("Host");
                }
            }
        }

        private string fPort;
        public string Port
        {
            get { return fPort; }
            set
            {
                if (value != fPort)
                {
                    fPort = value;
                    RaisePropertyChanged("Port");
                }
            }
        }

        private string fDatabase;
        public string Database
        {
            get { return fDatabase; }
            set
            {
                if (value != fDatabase)
                {
                    fDatabase = value;
                    RaisePropertyChanged("Database");
                }
            }
        }
    }
}
