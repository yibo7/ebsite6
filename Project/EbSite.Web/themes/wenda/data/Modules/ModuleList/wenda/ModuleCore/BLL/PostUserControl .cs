using System;
using System.Data;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.UI.WebControls;
using EbSite.Base.Configs.ConfigsBase;
using EbSite.Core.FSO;
using EbSite.Modules.Wenda.ModuleCore.Entity;
namespace EbSite.Modules.Wenda.ModuleCore.BLL
{
    /// <summary>
    /// 业务逻辑类Config 的摘要说明。
    /// </summary>
    public class PostUserControl : EbSite.Base.Datastore.XMLProviderBaseInt<Entity.PostUser>
    {
         public static readonly PostUserControl Instance = new PostUserControl();
        /// <summary>
        /// 重写数据的保存路径-绝对
        /// </summary>
        public override string SavePath
        {
            get
            {
                string mpath = EbSite.Base.Host.Instance.GetModulePath(new Guid("4e0edb7e-1b30-41ad-9f74-d63c80458c35"));

                if (!Equals(HttpContext.Current, null))
                {
                    return HttpContext.Current.Server.MapPath("~/" + mpath + "/DataStore/PostUser/");
                }
                return "";
            }
        }
        private PostUserControl ()
        {
            if (!FObject.IsExist(SavePath, FsoMethod.Folder))
            {
                FObject.Create(SavePath, FsoMethod.Folder);
            }
        }
        


        
    }
}

