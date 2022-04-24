using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EbSite.Modules.BBS.ModuleCore.DALInterface;

namespace EbSite.Modules.BBS.ModuleCore.DAL.MySql
{
    public partial class BBS : IDataProvider
    {
        public static string sPre
        {
            get
            {
                return "bbs_";//SettingInfo.Instance.TablePrefix;
            }
        }
        public static readonly DataProfile.DBHelper DB = new DataProfile.DBHelper();
    }
}