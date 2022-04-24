using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using EbSite.Base.ControlPage;
using EbSite.BLL;
using EbSite.BLL.ModelBll;

namespace EbSite.Web.AdminHt.Controls.Admin_Model
{
    public partial class ModelListForContent : ModelListBase<EbSite.Entity.NewsContent>
    {
        public override ModelBase<EbSite.Entity.NewsContent> bllModel 
        { 
            get
            {
                return new WebModel(GetSiteID);
            } 
        }
        override protected string AddUrl
        {
            get
            {
                return "mt=0&t=0";
            }
        }

       override protected string GetOrderUrl(object id)
        {
            return string.Concat("?mt=0&t=3&id=", id);
        }
       protected string GetEditFiledUrl(object id)
        {
            return string.Concat("?mt=0&t=4&id=", id);
        }

    }
}