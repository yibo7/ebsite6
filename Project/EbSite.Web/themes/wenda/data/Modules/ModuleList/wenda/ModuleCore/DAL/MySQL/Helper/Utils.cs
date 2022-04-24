using System;
using System.Collections.Generic;
using System.Web;

namespace EbSite.Modules.Wenda.ModuleCore.DAL.MySQL
{
    public partial class Ask : DALInterface.IDataProvider
    {
        public static string sPre
        {
            get
            {
                //if (!SettingInfo.Instance.GetBaseConfig.Instance.IsUserSysConn)
                //{
                //    return SettingInfo.Instance.GetBaseConfig.Instance.TablePrefix;
                //}
                //else
                //{

                //    return Base.Host.Instance.GetSysTablePrefix;
                //}
                return "ask_";
                // return SettingInfo.Instance.GetBaseConfig.Instance.TablePrefix;
            }
        }
        public static readonly DataProfile.DBHelper DB = new DataProfile.DBHelper();
    }
}