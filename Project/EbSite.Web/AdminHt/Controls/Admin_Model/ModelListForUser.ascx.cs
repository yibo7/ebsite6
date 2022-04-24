using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using EbSite.BLL;
using EbSite.BLL.ModelBll;

namespace EbSite.Web.AdminHt.Controls.Admin_Model
{
    public partial class ModelListForUser : ModelListBase<BLL.User.UserProfile>
    {
        public override ModelBase<BLL.User.UserProfile> bllModel
        {
            get
            {
                return new UserModel(GetSiteID);
            }
        }

        override protected string AddUrl
        {
            get
            {
                return "mt=2&t=0";
            }
        }

       override protected string GetOrderUrl(object id)
        {
            return string.Concat("?mt=2&t=3&id=", id);
        }
       protected string GetEditFiledUrl(object id)
       {
           return string.Concat("?mt=2&t=4&id=", id);
       }
    }
}