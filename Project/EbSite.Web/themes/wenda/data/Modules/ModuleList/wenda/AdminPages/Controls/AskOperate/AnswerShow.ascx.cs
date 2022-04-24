using System;
using EbSite.Base.Modules;
using EbSite.Modules.Wenda.ModuleCore.Entity;

namespace EbSite.Modules.Wenda.AdminPages.Controls.AskOperate
{
    public partial class AnswerShow : MPUCBaseShow<ModuleCore.Entity.Answers>
    {
        /// <summary>
        /// 权限全部
        /// </summary>
        public override string Permission
        {
            get
            {
                return "25";
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
