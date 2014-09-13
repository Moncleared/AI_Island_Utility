using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MySql.Data.MySqlClient;
using System.Windows;

namespace AI_Island_Utility
{
    public class ViewModel : ObservableObject
    {

        #region Observable Properties for View
        private string fUserName;
        public string UserName
        {
            get { return fUserName; }
            set
            {
                if (value != fUserName)
                {
                    fUserName = value;
                    OnPropertyChanged("UserName");
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
                    OnPropertyChanged("Password");
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
                    OnPropertyChanged("Host");
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
                    OnPropertyChanged("Port");
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
                    OnPropertyChanged("Database");
                }
            }
        }
        #endregion

        #region Events
        private ICommand fLoginCommand;
        public ICommand LoginCommand
        {
            get
            {
                if (fLoginCommand == null)
                {
                    fLoginCommand = new RelayCommand(param => LoginMySql());
                }
                return fLoginCommand;
            }
        }

        #endregion

        public void LoginMySql()
        {
            string vConnectionString;
            string vUsername = this.UserName.Trim();
            string vPassword = this.Password.Trim();
            string vHost = this.Host.Trim();
            string vPort = this.Port.Trim();
            string vDatabase = this.Database.Trim();

            vConnectionString = string.Format("server={0};uid={1};pwd={2};database={3};", vHost, vUsername, vPassword, vDatabase);

            try
            {
                using (MySqlConnection vMySqlConnection = new MySqlConnection())
                {
                    vMySqlConnection.ConnectionString = vConnectionString;
                    vMySqlConnection.Open();
                }
            }
            catch (MySqlException vException)
            {
                MessageBox.Show(vException.Message);
            }
        }
    }
}
