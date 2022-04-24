
namespace EbSite.Modules.Ask.ModuleCore.DAL.SqlServer
{
    public partial class Ask
    {
        public static string sPre
        {
            get
            {
                if (!SettingInfo.Instance.GetBaseConfig.Instance.IsUserSysConn) //SettingInfo.Instance.IsUserSysConn
                {
                    return SettingInfo.Instance.GetBaseConfig.Instance.TablePrefix;
                }
                else
                {
                   
                    return Base.Host.Instance.GetSysTablePrefix;
                }
            }
        }
        
        public static readonly DataProfile.DBHelper DB = new DataProfile.DBHelper();
    }
    
}