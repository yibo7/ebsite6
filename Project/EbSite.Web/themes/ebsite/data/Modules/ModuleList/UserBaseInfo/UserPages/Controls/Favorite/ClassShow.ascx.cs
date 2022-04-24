using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.Modules;

namespace EbSite.Modules.UserBaseInfo.UserPages.Controls.Favorite
{
    public partial class ClassShow : MPUCBaseShow<Entity.FavoriteClass>
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected override Entity.FavoriteClass LoadModel()
        {
            if(!string.IsNullOrEmpty(GetKeyID))
            {
                return BLL.FavoriteClass.GetModel(int.Parse(GetKeyID));
            }
            else
            {
                Tips("出错了","找不到要查看的记录!");
                return null;
            }
        }
    }
}