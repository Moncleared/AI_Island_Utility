using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using MySql.Data.MySqlClient;
using System;
using System.Windows;
using System.Windows.Controls;
using AI_Island_Utility.Extensions;

namespace AI_Island_Utility.ViewModel
{
    public class MainViewModel : ViewModelBase
    {

        public MainViewModel()
        {
            Database = "dayz_epoch";
            Port = "3306";
        }

        #region Observable Properties for View
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
        #endregion

        #region Events
        private RelayCommand<PasswordBox> fLoginCommand;
        public RelayCommand<PasswordBox> LoginCommand
        {
            get
            {
                if (fLoginCommand == null)
                {
                    fLoginCommand = new RelayCommand<PasswordBox>((s) => LoginMySql(s));
                }
                return fLoginCommand;
            }
        }


        #endregion

        public void LoginMySql(PasswordBox pPasswordBox)
        {
            string vConnectionString;
            string vUsername = this.Username.Trim();
            string vHost = this.Host.Trim();
            string vDatabase = this.Database.Trim();
            string vPort = this.Port.Trim();

            //This is a bad practice, exposing a password into plain text. I don't care for right now, we can deal with this later
            //Notice we're using an "Extension" method here though, .ConvertToUnsecureString is defined in SecurityExtensions.cs
            //Extensions essentially allow you to add Methods to already existing classes that you may or may not have created (SecureString for example)
            string vPassword = string.Empty;
            if (pPasswordBox != null)
            {
                vPassword = pPasswordBox.SecurePassword.ConvertToUnsecureString();
            }

            vConnectionString = string.Format("server={0};port={1};uid={2};pwd={3};database={4};", vHost, vPort, vUsername, vPassword, vDatabase);

            try
            {
                using (MySqlConnection vMySqlConnection = new MySqlConnection())
                {
                    vMySqlConnection.ConnectionString = vConnectionString;
                    vMySqlConnection.Open();
                    MessageBox.Show("Successfully connected to the database!");
                }
            }
            catch (MySqlException vException)
            {
                MessageBox.Show(vException.Message);
            }
        }
    }
}