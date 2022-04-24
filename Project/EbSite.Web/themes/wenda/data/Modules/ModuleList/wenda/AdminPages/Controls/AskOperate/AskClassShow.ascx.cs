using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.Modules;

namespace EbSite.Modules.Wenda.AdminPages.Controls.AskOperate
{
    public partial class AskClassShow : MPUCBaseShow<ModuleCore.Entity.Answers>
    {
        /// <summary>
        /// 权限全部
        /// </summary>
        public override string Permission
        {
            get
            {
                return "5";
            }
        }
        /// <summary>
        /// 重写删除
        /// </summary>
        protected override void Delete()
        {
            Model.Delete();
        }
        /// <summary>
        /// 重写Load事件
        /// </summary>
        protected override ModuleCore.Entity.Answers LoadModel()
        {
            ModuleCore.Entity.Answers md = new ModuleCore.Entity.Answers(int.Parse(GetKeyID));
            if (Equals(md, null)) md = new ModuleCore.Entity.Answers();//防止删除后的页面出错
            return md;
        }
    }
}