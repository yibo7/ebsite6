using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.Modules;

namespace EbSite.Modules.UserBaseInfo.UserPages.Controls.MAddress
{
    public partial class Show : MPUCBaseShowMobile<EbSite.Entity.Address>
    {
        
        public override Guid ModuleMenuID
        {
            get
            {
                return new Guid("6836309c-c063-4226-a39e-a8d71e7c527d");
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected override EbSite.Entity.Address LoadModel()
        {
            if (!string.IsNullOrEmpty(GetKeyID))
            {
                return BLL.Address.Instance.GetEntity(int.Parse(GetKeyID));
            }
            else
            {
                Tips("出错了", "找不到要查看的记录!");
                return null;
            }
        }
    }
}