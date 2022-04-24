using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.Modules;
using EbSite.Entity;

namespace EbSite.Modules.Wenda.AdminPages.Controls.AskOperate
{
    public partial class AskShow : MPUCBaseShow<Entity.NewsContent>
    {
        /// <summary>
        /// 权限全部
        /// </summary>
        public override string Permission
        {
            get
            {
                return "10";
            }
        }
        /// <summary>
        /// 重写删除
        /// </summary>
        protected override void Delete()
        {
            //Model.Delete();
        }
        /// <summary>
        /// 重写Load事件
        /// </summary>
        protected override Entity.NewsContent LoadModel()
        {
            //ModuleCore.Entity.Answers md = new ModuleCore.Entity.Answers(int.Parse(GetKeyID));
            //if (Equals(md, null)) md = new ModuleCore.Entity.Answers();//防止删除后的页面出错
            //return md;

            Entity.NewsContent md1 = Base.AppStartInit.NewsContentInstDefault.GetModelDefaultFiled(int.Parse(GetKeyID));
            if(Equals(md1,null)) md1 = new NewsContent();
            return md1;
        }
    }
}