using System;
using EbSite.Base.Modules;


namespace EbSite.Modules.BBS.AdminPages.Controls.Vote
{
    public partial class VoteManage_XZGL_show : MPUCBaseShow<ModuleCore.Entity.toupiao>
    {
        public override string Permission
        {
            get
            {
                return "dddd7b";
            }
        }
      

        protected override void Delete()
        {
            ModuleCore.BLL.toupiao.Instance.Delete(long.Parse(GetKeyID));
        }
        protected override ModuleCore.Entity.toupiao LoadModel()
        {
            ModuleCore.Entity.toupiao md = ModuleCore.BLL.toupiao.Instance.GetEntity(long.Parse(GetKeyID));
            if (Equals(md, null)) md = new ModuleCore.Entity.toupiao();//防止删除后的页面出错
            return md;
        }        
    }
}