using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.UI.WebControls;
using EbSite.Core;
using EbSite.Core.FSO;
using EbSite.Modules.CQ.ModuleCore.Configs;
using EbSite.Modules.CQ.ModuleCore.Entity;

namespace EbSite.Modules.CQ.ModuleCore.BLL
{
    public class ChatPlugin : EbSite.Base.Datastore.XMLProviderBaseInt<Entity.ChatPlugin>
    {
        public static readonly ChatPlugin Instance = new ChatPlugin();
        /// <summary>
        /// 重写菜单的保存路径-绝对
        /// </summary>
        public override string SavePath
        {
            get
            {
                return HttpContext.Current.Server.MapPath(string.Concat(SettingInfo.Instance.GetBaseConfig.Instance.ModulePath, "DataStore/ChatPlugin/"));
            }
        }

        private ChatPlugin()
        {
            if (!FObject.IsExist(SavePath, FsoMethod.Folder))
            {
                FObject.Create(SavePath, FsoMethod.Folder);
            }
           
        }
        public void BuilderJs()
        {
            string sPath = HttpContext.Current.Server.MapPath("../dialog/plugins.js");
            List<Entity.ChatPlugin> lst = FillList();
            if (lst.Count > 0)
            {
                StringBuilder sb = new StringBuilder("var plugins = [ ");

                foreach (Entity.ChatPlugin info in lst)
                {
                    sb.Append("{  ");
                    sb.AppendFormat("id: {0}, title: \"{1}\",url:\"{2}\"", info.id, info.PluginTitle, info.Url);
                    sb.Append("},");
                }
                sb.Remove(sb.Length - 1, 1);
                sb.Append("] ;");


                Core.FSO.FObject.WriteFileUtf8(sPath, sb.ToString());
            }
        }
        

    }
}