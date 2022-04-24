using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Entity;
using EbSite.Web.AdminHt.Controls.Admin_Modules;

namespace EbSite.Web.AdminHt.Controls.Admin_Plugins
{
    public partial class OutPutPlugins : EbSite.Base.ControlPage.UserControlBase
    {
        public override string Permission
        {
            get
            {
                return "136";
            }
        }

        /// <summary>
        /// 获取当前菜单ID
        /// </summary>
        protected Guid GetMenuID
        {
            get
            {
                if (!string.IsNullOrEmpty(Request["id"]))
                {
                    return new Guid(Request["id"]);
                }
                else
                {
                    Tips("出错了", "找不到相应的菜单数据，请确认访问路径是否正确！");
                }
                return Guid.Empty;
            }
        }
        
        ///// <summary>
        ///// 获取当前插件实体
        ///// </summary>
        //protected EbSite.Entity.PluginInfo Model
        //{
        //    get
        //    {
        //        return null;
        //        //PluginInfo md = new PluginInfo();
        //        //if (!Equals(GetMenuID, Guid.Empty))
        //        //{
        //        //    return BLL.Plugins.Plugin.Instance.GetEntity(GetMenuID);
        //        //}
        //        //return md;
        //    }
        //}
       
        protected void bntOut_Click(object sender, EventArgs e)
        {
            string sSavePath = Server.MapPath(string.Format("{0}UploadFile/temp/{1}.zip", IISPath, Path.GetRandomFileName()));
            string fileurl = Server.MapPath("Plugins/");
            Core.FSO.FObject.ZipFile(HttpContext.Current.Server.MapPath(fileurl), sSavePath);


        }


    }
}