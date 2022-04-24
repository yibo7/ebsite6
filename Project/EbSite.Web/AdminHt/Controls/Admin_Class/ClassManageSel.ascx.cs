using System;
using System.Collections.Generic;
using System.Web.Services;
using System.Web.UI.WebControls;
using EbSite.Base.EntityCustom;
using EbSite.Base.Json;
using EbSite.BLL;
using EbSite.Entity;
using NewsClass = EbSite.Entity.NewsClass;

namespace EbSite.Web.AdminHt.Controls.Admin_Class
{
    public partial class ClassManageSel : ClassListBase
    {
        

        protected void Page_Load(object sender, EventArgs e)
        {
           
            if (!IsPostBack)
            {
                int count = 0;
               List<EbSite.Entity.NewsClass> lst = BLL.NewsClass.GetModelIdListPages(1, 1000, 0, out count, base.GetSiteID, ModelID);
                List<TreeItem> lstTree = new List<TreeItem>();

                foreach (NewsClass newClass in lst)
                {
                    lstTree.Add(new TreeItem(newClass.ID, newClass.ClassName, 0, newClass.IsCanAddSub ? "1" : "0"));
                }

                selClass.DataSoure = lstTree;
            }
           

        }

        protected int cid
        {
            get
            {
                if (!string.IsNullOrEmpty(Request["id"]))
                {
                    return int.Parse(Request["id"]);
                }
                return 0;
            }
        }

        protected override object LoadList(out int iCount)
        {
            iCount = 0;
            return null;
        }
    }

}