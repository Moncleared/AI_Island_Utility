using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using MySql.Data.MySqlClient;
using System;
using System.Windows;
using System.Windows.Controls;
using AI_Island_Utility.Extensions;
using AI_Island_Utility.Model;

namespace AI_Island_Utility.ViewModel
{
    public class ScriptViewModel : ViewModelBase
    {

        public ScriptViewModel()
        {

            ScriptText = "DELETE FROM `object_data` WHERE `ObjectUID` = '0000500001393';DELETE FROM `object_data` WHERE `ObjectUID` = '0000500001394';DELETE FROM `object_data` WHERE `ObjectUID` = '0000500001395';DELETE FROM `object_data` WHERE `ObjectUID` = '0000500001396';DELETE FROM `object_data` WHERE `ObjectUID` = '0000500001397';DELETE FROM `object_data` WHERE `ObjectUID` = '0000500001398';";
            ScriptText += "UPDATE character_data SET `inventory` = REPLACE(`inventory`,'ItemKeyGreen1904','ItemKeyKit');UPDATE character_data SET `backpack` = REPLACE(`backpack`,'ItemKeyGreen1904','ItemKeyKit');UPDATE object_data SET `inventory` = REPLACE(`inventory`,'ItemKeyGreen1904','ItemKeyKit');";
            ScriptText += "UPDATE character_data SET `inventory` = REPLACE(`inventory`,'ItemKeyGreen1355','ItemKeyKit');UPDATE character_data SET `backpack` = REPLACE(`backpack`,'ItemKeyGreen1355','ItemKeyKit');UPDATE object_data SET `inventory` = REPLACE(`inventory`,'ItemKeyGreen1355','ItemKeyKit');";
            ScriptText += "UPDATE character_data SET `inventory` = REPLACE(`inventory`,'ItemKeyGreen1248','ItemKeyKit');UPDATE character_data SET `backpack` = REPLACE(`backpack`,'ItemKeyGreen1248','ItemKeyKit');UPDATE object_data SET `inventory` = REPLACE(`inventory`,'ItemKeyGreen1248','ItemKeyKit');UPDATE character_data SET `inventory` = REPLACE(`inventory`,'ItemKeyGreen1364','ItemKeyKit');UPDATE character_data SET `backpack` = REPLACE(`backpack`,'ItemKeyGreen1364','ItemKeyKit');UPDATE object_data SET `inventory` = REPLACE(`inventory`,'ItemKeyGreen1364','ItemKeyKit');UPDATE character_data SET `inventory` = REPLACE(`inventory`,'ItemKeyGreen137','ItemKeyKit');UPDATE character_data SET `backpack` = REPLACE(`backpack`,'ItemKeyGreen137','ItemKeyKit');UPDATE object_data SET `inventory` = REPLACE(`inventory`,'ItemKeyGreen137','ItemKeyKit');";
            ScriptText += "INSERT INTO `object_data` (`ObjectID`, `ObjectUID`, `Instance`, `Classname`, `Datestamp`, `LastUpdated`, `CharacterID`, `Worldspace`, `Inventory`, `Hitpoints`, `Fuel`, `Damage`) VALUES  (NULL, '0000500001393', '11', 'MTVR', NOW(), NOW(), '1904', '[135,[13313.4,2738.29,0]]', '[[[],[]],[[\"ItemAntibiotic\",\"ItemBandage\",\"ItemBloodbag\",\"ItemEpinephrine\",\"ItemMorphine\",\"ItemPainkiller\",\"ItemSodaRbull\",\"FoodCanFrankBeans\",\"FoodCanPasta\",\"FoodCanSardines\",\"ItemSodaCoke\",\"ItemSodaOrangeSherbet\",\"ItemHeatPack\"],[15,15,15,15,15,15,15,15,15,15,15,15,15]],[[\"DZ_Backpack_EP1\",\"DZ_LargeGunBag_EP1\"],[1,1]]]', '[[\"motor\",0.8],[\"karoserie\",1],[\"palivo\",0.8],[\"wheel_1_1_steering\",1],[\"wheel_2_1_steering\",1],[\"wheel_1_2_steering\",1],[\"wheel_2_2_steering\",1]]', '0.01000', '0.05'),  (NULL, '0000500001394', '11', 'MTVR', NOW(), NOW(), '1355', '[292,[14133.5,2747.52,0]]', '[[[\"ItemCrowbar\"],[2]],[[\"ItemLockbox\",\"30m_plot_kit\",\"metal_floor_kit\",\"CinderBlocks\",\"cinder_wall_kit\",\"MortarBucket\",\"MortarBucket\",\"PartScrap\",\"PartWoodPile\",\"forest_large_net_kit\"],[3,3,3,3,3,15,5,10,15,3]],[[\"DZ_Backpack_EP1\",\"DZ_LargeGunBag_EP1\"],[1,1]]]', '[[\"motor\",0.8],[\"karoserie\",1],[\"palivo\",0.8],[\"wheel_1_1_steering\",1],[\"wheel_2_1_steering\",1],[\"wheel_1_2_steering\",1],[\"wheel_2_2_steering\",1]]', '0.01000', '0.05'),  (NULL, '0000500001395', '11', 'MTVR', NOW(), NOW(), '1248', '[150,[13596.3,3156.26,0]]', '[[[\"ItemBriefcase100oz\",\"AKS_74_kobra\",\"M16A2GL\",\"AKS_74_U\",\"FN_FAL\",\"M9SD\",\"SCAR_L_STD_Mk4CQT\",\"Pecheneg_DZ\",\"bizon_silenced\",\"M4A1_HWS_GL_SD_Camo\",\"NVGoggles\",\"ItemGPS\",\"G36A_camo\"],[2,3,3,3,3,3,3,3,3,3,2,2,1]],[[\"ItemBloodbag\",\"100Rnd_762x54_PK\",\"30Rnd_556x45_Stanag\",\"100Rnd_762x51_M240\",\"30Rnd_556x45_G36SD\",\"10Rnd_9x39_SP5_VSS\",\"ItemAntibiotic\",\"30Rnd_545x39_AK\",\"20Rnd_762x51_FNFAL\",\"20Rnd_762x51_B_SCAR\",\"64Rnd_9x19_SD_Bizon\",\"1Rnd_HE_GP25\",\"PartGeneric\",\"PartEngine\",\"PartGlass\",\"PartVRotor\",\"ItemJerrycan\",\"ItemTent\"],[10,10,10,10,10,10,10,10,10,10,10,10,4,2,6,2,10,2]],[[\"DZ_Backpack_EP1\",\"DZ_LargeGunBag_EP1\"],[1,1]]]', '[[\"motor\",0.8],[\"karoserie\",1],[\"palivo\",0.8],[\"wheel_1_1_steering\",1],[\"wheel_2_1_steering\",1],[\"wheel_1_2_steering\",1],[\"wheel_2_2_steering\",1]]', '0.01000', '0.05'),  (NULL, '0000500001396', '11', 'MTVR', NOW(), NOW(), '1364', '[337,[13669.7,2882.46,0]]', '[[[\"ItemBriefcase100oz\",\"AKS_74_kobra\",\"M16A2GL\",\"AKS_74_U\",\"FN_FAL\",\"M9SD\",\"SCAR_L_STD_Mk4CQT\",\"Pecheneg_DZ\",\"bizon_silenced\",\"M4A1_HWS_GL_SD_Camo\",\"NVGoggles\",\"ItemGPS\",\"G36A_camo\"],[2,3,3,3,3,3,3,3,3,3,2,2,1]],[[\"ItemBloodbag\",\"100Rnd_762x54_PK\",\"30Rnd_556x45_Stanag\",\"100Rnd_762x51_M240\",\"30Rnd_556x45_G36SD\",\"10Rnd_9x39_SP5_VSS\",\"ItemAntibiotic\",\"30Rnd_545x39_AK\",\"20Rnd_762x51_FNFAL\",\"20Rnd_762x51_B_SCAR\",\"64Rnd_9x19_SD_Bizon\",\"1Rnd_HE_GP25\",\"PartGeneric\",\"PartEngine\",\"PartGlass\",\"PartVRotor\",\"ItemJerrycan\",\"ItemTent\"],[10,10,10,10,10,10,10,10,10,10,10,10,4,2,6,2,10,2]],[[\"DZ_Backpack_EP1\",\"DZ_LargeGunBag_EP1\"],[1,1]]]', '[[\"motor\",0.8],[\"karoserie\",1],[\"palivo\",0.8],[\"wheel_1_1_steering\",1],[\"wheel_2_1_steering\",1],[\"wheel_1_2_steering\",1],[\"wheel_2_2_steering\",1]]', '0.01000', '0.05'),  (NULL, '0000500001397', '11', 'MTVR', NOW(), NOW(), '1370', '[311,[14054.2,2888.33,0]]', '[[[\"ItemCrowbar\"],[2]],[[\"ItemLockbox\",\"30m_plot_kit\",\"metal_floor_kit\",\"CinderBlocks\",\"cinder_wall_kit\",\"MortarBucket\",\"MortarBucket\",\"PartScrap\",\"PartWoodPile\",\"forest_large_net_kit\"],[3,3,3,3,3,15,5,10,15,3]],[[\"DZ_Backpack_EP1\",\"DZ_LargeGunBag_EP1\"],[1,1]]]', '[[\"motor\",0.8],[\"karoserie\",1],[\"palivo\",0.8],[\"wheel_1_1_steering\",1],[\"wheel_2_1_steering\",1],[\"wheel_1_2_steering\",1],[\"wheel_2_2_steering\",1]]', '0.01000', '0.05'),  (NULL, '0000500001398', '11', 'GunRack_DZ', NOW(), NOW(), '871', '[319.618,[13693.4,2904.62,4.478]]', '[[[\"ItemKeyGreen137\",\"ItemKeyGreen1355\",\"ItemKeyGreen1248\",\"ItemKeyGreen1904\",\"ItemKeyGreen1364\"],[1,1,1,1,1]],[[],[]],[[],[]]]', '[]', '0.00000', '0.00000');";

            //Format it
            ScriptText = ScriptText.Replace(";", ";"+Environment.NewLine);
        }

        private string fScriptText;
        public string ScriptText
        {
            get { return fScriptText; }
            set
            {
                if (value != fScriptText)
                {
                    fScriptText = value;
                    RaisePropertyChanged("ScriptText");
                }
            }
        }
    }
}