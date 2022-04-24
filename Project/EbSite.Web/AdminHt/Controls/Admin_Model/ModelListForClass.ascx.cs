using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using EbSite.BLL;
using EbSite.BLL.ModelBll;

namespace EbSite.Web.AdminHt.Controls.Admin_Model
{

    public partial class ModelListForClass : ModelListBase<EbSite.Entity.NewsClass>
    {

        public override ModelBase<EbSite.Entity.NewsClass> bllModel
        {
            get
            {
                return new ClassModel(GetSiteID);
            }
        }

        override protected string AddUrl
        {
            get
            {
                return "mt=1&t=0";
            }
        }
      override  protected string GetOrderUrl(object id)
        {
            return string.Concat("?mt=1&t=3&id=", id);
        }
      protected string GetEditFiledUrl(object id)
      {
          return string.Concat("?mt=1&t=4&id=", id);
      }
       
    }
}