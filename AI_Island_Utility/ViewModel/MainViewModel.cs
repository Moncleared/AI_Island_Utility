using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using MySql.Data.MySqlClient;
using System;
using System.Windows;
using System.Windows.Controls;
using AI_Island_Utility.Extensions;
using AI_Island_Utility.Model;
using Microsoft.Practices.ServiceLocation;
using AI_Island_Utility.View;

namespace AI_Island_Utility.ViewModel
{
    public class MainViewModel : ViewModelBase
    {

        public MainViewModel()
        {
            DatabaseModel = new DatabaseModel();
            DatabaseModel.Database = "dayz_epoch";
            DatabaseModel.Port = "3306";
        }

        #region Observable Properties for View
        private DatabaseModel fDatabaseModel;
        public DatabaseModel DatabaseModel
        {
            get { return fDatabaseModel; }
            set
            {
                if (value != fDatabaseModel)
                {
                    fDatabaseModel = value;
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

            //need to do null check values here, calling .Trim() on null = bad lawl
            string vConnectionString;
            string vUsername = this.DatabaseModel.Username.Trim();
            string vHost = this.DatabaseModel.Host.Trim();
            string vDatabase = this.DatabaseModel.Database.Trim();
            string vPort = this.DatabaseModel.Port.Trim();

            //This is a bad practice, exposing a password into plain text. I don't care for right now, we can deal with this later
            //Notice we're using an "Extension" method here though, .ConvertToUnsecureString is defined in SecurityExtensions.cs
            //Extensions essentially allow you to add Methods to already existing classes that you may or may not have created (SecureString for example)
            string vPassword = string.Empty;
            if (pPasswordBox != null)
            {
                vPassword = pPasswordBox.SecurePassword.ConvertToUnsecureString();
            }

            vConnectionString = string.Format("server={0};port={1};uid={2};pwd={3};database={4};", vHost, vPort, vUsername, vPassword, vDatabase);

            //this is for debugging so i don't have to type the contents into the ui every time
            //i have a local mysql database installed on my laptop so connection actually works
            vConnectionString = string.Format("server=localhost;port=3306;uid=root;pwd=test123;database=dayz_epoch;", vHost, vPort, vUsername, vPassword, vDatabase);

            try
            {
                using (MySqlConnection vMySqlConnection = new MySqlConnection())
                {
                    vMySqlConnection.ConnectionString = vConnectionString;
                    vMySqlConnection.Open();
                    
                    ScriptView vScriptView = new ScriptView();
                    vScriptView.ShowDialog();

                    /*
                    using (MySqlCommand vMySqlCommand = new MySqlCommand())
                    {
                        vMySqlCommand.CommandText = "DELETE FROM `object_data` WHERE `ObjectUID` = '0000500001393';DELETE FROM `object_data` WHERE `ObjectUID` = '0000500001394';DELETE FROM `object_data` WHERE `ObjectUID` = '0000500001395';DELETE FROM `object_data` WHERE `ObjectUID` = '0000500001396'; DELETE FROM `object_data` WHERE `ObjectUID` = '0000500001397'; DELETE FROM `object_data` WHERE `ObjectUID` = '0000500001398';";
                        vMySqlCommand.CommandText += "UPDATE character_data SET `inventory` = REPLACE(`inventory`,'ItemKeyGreen1904','ItemKeyKit');UPDATE character_data SET `backpack` = REPLACE(`backpack`,'ItemKeyGreen1904','ItemKeyKit');UPDATE object_data SET `inventory` = REPLACE(`inventory`,'ItemKeyGreen1904','ItemKeyKit');";
                        vMySqlCommand.CommandText += "UPDATE character_data SET `inventory` = REPLACE(`inventory`,'ItemKeyGreen1355','ItemKeyKit');UPDATE character_data SET `backpack` = REPLACE(`backpack`,'ItemKeyGreen1355','ItemKeyKit');UPDATE object_data SET `inventory` = REPLACE(`inventory`,'ItemKeyGreen1355','ItemKeyKit');";
                        vMySqlCommand.CommandText += "UPDATE character_data SET `inventory` = REPLACE(`inventory`,'ItemKeyGreen1248','ItemKeyKit');UPDATE character_data SET `backpack` = REPLACE(`backpack`,'ItemKeyGreen1248','ItemKeyKit');UPDATE object_data SET `inventory` = REPLACE(`inventory`,'ItemKeyGreen1248','ItemKeyKit');UPDATE character_data SET `inventory` = REPLACE(`inventory`,'ItemKeyGreen1364','ItemKeyKit');UPDATE character_data SET `backpack` = REPLACE(`backpack`,'ItemKeyGreen1364','ItemKeyKit');UPDATE object_data SET `inventory` = REPLACE(`inventory`,'ItemKeyGreen1364','ItemKeyKit');UPDATE character_data SET `inventory` = REPLACE(`inventory`,'ItemKeyGreen137','ItemKeyKit');UPDATE character_data SET `backpack` = REPLACE(`backpack`,'ItemKeyGreen137','ItemKeyKit');UPDATE object_data SET `inventory` = REPLACE(`inventory`,'ItemKeyGreen137','ItemKeyKit');";
                        vMySqlCommand.CommandText += "INSERT INTO `object_data` (`ObjectID`, `ObjectUID`, `Instance`, `Classname`, `Datestamp`, `LastUpdated`, `CharacterID`, `Worldspace`, `Inventory`, `Hitpoints`, `Fuel`, `Damage`) VALUES  (NULL, '0000500001393', '11', 'MTVR', NOW(), NOW(), '1904', '[135,[13313.4,2738.29,0]]', '[[[],[]],[[\"ItemAntibiotic\",\"ItemBandage\",\"ItemBloodbag\",\"ItemEpinephrine\",\"ItemMorphine\",\"ItemPainkiller\",\"ItemSodaRbull\",\"FoodCanFrankBeans\",\"FoodCanPasta\",\"FoodCanSardines\",\"ItemSodaCoke\",\"ItemSodaOrangeSherbet\",\"ItemHeatPack\"],[15,15,15,15,15,15,15,15,15,15,15,15,15]],[[\"DZ_Backpack_EP1\",\"DZ_LargeGunBag_EP1\"],[1,1]]]', '[[\"motor\",0.8],[\"karoserie\",1],[\"palivo\",0.8],[\"wheel_1_1_steering\",1],[\"wheel_2_1_steering\",1],[\"wheel_1_2_steering\",1],[\"wheel_2_2_steering\",1]]', '0.01000', '0.05'),  (NULL, '0000500001394', '11', 'MTVR', NOW(), NOW(), '1355', '[292,[14133.5,2747.52,0]]', '[[[\"ItemCrowbar\"],[2]],[[\"ItemLockbox\",\"30m_plot_kit\",\"metal_floor_kit\",\"CinderBlocks\",\"cinder_wall_kit\",\"MortarBucket\",\"MortarBucket\",\"PartScrap\",\"PartWoodPile\",\"forest_large_net_kit\"],[3,3,3,3,3,15,5,10,15,3]],[[\"DZ_Backpack_EP1\",\"DZ_LargeGunBag_EP1\"],[1,1]]]', '[[\"motor\",0.8],[\"karoserie\",1],[\"palivo\",0.8],[\"wheel_1_1_steering\",1],[\"wheel_2_1_steering\",1],[\"wheel_1_2_steering\",1],[\"wheel_2_2_steering\",1]]', '0.01000', '0.05'),  (NULL, '0000500001395', '11', 'MTVR', NOW(), NOW(), '1248', '[150,[13596.3,3156.26,0]]', '[[[\"ItemBriefcase100oz\",\"AKS_74_kobra\",\"M16A2GL\",\"AKS_74_U\",\"FN_FAL\",\"M9SD\",\"SCAR_L_STD_Mk4CQT\",\"Pecheneg_DZ\",\"bizon_silenced\",\"M4A1_HWS_GL_SD_Camo\",\"NVGoggles\",\"ItemGPS\",\"G36A_camo\"],[2,3,3,3,3,3,3,3,3,3,2,2,1]],[[\"ItemBloodbag\",\"100Rnd_762x54_PK\",\"30Rnd_556x45_Stanag\",\"100Rnd_762x51_M240\",\"30Rnd_556x45_G36SD\",\"10Rnd_9x39_SP5_VSS\",\"ItemAntibiotic\",\"30Rnd_545x39_AK\",\"20Rnd_762x51_FNFAL\",\"20Rnd_762x51_B_SCAR\",\"64Rnd_9x19_SD_Bizon\",\"1Rnd_HE_GP25\",\"PartGeneric\",\"PartEngine\",\"PartGlass\",\"PartVRotor\",\"ItemJerrycan\",\"ItemTent\"],[10,10,10,10,10,10,10,10,10,10,10,10,4,2,6,2,10,2]],[[\"DZ_Backpack_EP1\",\"DZ_LargeGunBag_EP1\"],[1,1]]]', '[[\"motor\",0.8],[\"karoserie\",1],[\"palivo\",0.8],[\"wheel_1_1_steering\",1],[\"wheel_2_1_steering\",1],[\"wheel_1_2_steering\",1],[\"wheel_2_2_steering\",1]]', '0.01000', '0.05'),  (NULL, '0000500001396', '11', 'MTVR', NOW(), NOW(), '1364', '[337,[13669.7,2882.46,0]]', '[[[\"ItemBriefcase100oz\",\"AKS_74_kobra\",\"M16A2GL\",\"AKS_74_U\",\"FN_FAL\",\"M9SD\",\"SCAR_L_STD_Mk4CQT\",\"Pecheneg_DZ\",\"bizon_silenced\",\"M4A1_HWS_GL_SD_Camo\",\"NVGoggles\",\"ItemGPS\",\"G36A_camo\"],[2,3,3,3,3,3,3,3,3,3,2,2,1]],[[\"ItemBloodbag\",\"100Rnd_762x54_PK\",\"30Rnd_556x45_Stanag\",\"100Rnd_762x51_M240\",\"30Rnd_556x45_G36SD\",\"10Rnd_9x39_SP5_VSS\",\"ItemAntibiotic\",\"30Rnd_545x39_AK\",\"20Rnd_762x51_FNFAL\",\"20Rnd_762x51_B_SCAR\",\"64Rnd_9x19_SD_Bizon\",\"1Rnd_HE_GP25\",\"PartGeneric\",\"PartEngine\",\"PartGlass\",\"PartVRotor\",\"ItemJerrycan\",\"ItemTent\"],[10,10,10,10,10,10,10,10,10,10,10,10,4,2,6,2,10,2]],[[\"DZ_Backpack_EP1\",\"DZ_LargeGunBag_EP1\"],[1,1]]]', '[[\"motor\",0.8],[\"karoserie\",1],[\"palivo\",0.8],[\"wheel_1_1_steering\",1],[\"wheel_2_1_steering\",1],[\"wheel_1_2_steering\",1],[\"wheel_2_2_steering\",1]]', '0.01000', '0.05'),  (NULL, '0000500001397', '11', 'MTVR', NOW(), NOW(), '1370', '[311,[14054.2,2888.33,0]]', '[[[\"ItemCrowbar\"],[2]],[[\"ItemLockbox\",\"30m_plot_kit\",\"metal_floor_kit\",\"CinderBlocks\",\"cinder_wall_kit\",\"MortarBucket\",\"MortarBucket\",\"PartScrap\",\"PartWoodPile\",\"forest_large_net_kit\"],[3,3,3,3,3,15,5,10,15,3]],[[\"DZ_Backpack_EP1\",\"DZ_LargeGunBag_EP1\"],[1,1]]]', '[[\"motor\",0.8],[\"karoserie\",1],[\"palivo\",0.8],[\"wheel_1_1_steering\",1],[\"wheel_2_1_steering\",1],[\"wheel_1_2_steering\",1],[\"wheel_2_2_steering\",1]]', '0.01000', '0.05'),  (NULL, '0000500001398', '11', 'GunRack_DZ', NOW(), NOW(), '871', '[319.618,[13693.4,2904.62,4.478]]', '[[[\"ItemKeyGreen137\",\"ItemKeyGreen1355\",\"ItemKeyGreen1248\",\"ItemKeyGreen1904\",\"ItemKeyGreen1364\"],[1,1,1,1,1]],[[],[]],[[],[]]]', '[]', '0.00000', '0.00000');";
                        vMySqlCommand.CommandType = System.Data.CommandType.Text;
                        vMySqlCommand.Connection = vMySqlConnection;

                        int vReturnValue = vMySqlCommand.ExecuteNonQuery();
                    }
                     */
                }
            }
            catch (MySqlException vException)
            {
                MessageBox.Show(vException.Message);
            }
        }
    }
}