using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.BLL;
using EbSite.Base.ControlPage;
using EbSite.Base.Modules;
using EbSite.Web.AdminHt.Controls.Admin_Class;

namespace EbSite.Web.AdminHt.Controls.Admin_Spider
{
    public partial class SpiderAdd : UserControlBaseSave
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public override string Permission
        {
            get
            {
                return "163";
            }
        }
        override protected string KeyColumnName
        {
            get
            {
                return "id";
            }
        }
        override protected void InitModifyCtr()
        {
            BLL.IISLOG.SpiderBll.Instance.InitModifyCtr(int.Parse(SID), phCtrList);
        }
        override protected void SaveModel()
        {
            Base.BLL.OtherColumn cRealname = new OtherColumn("SpiderCount", "0");
            lstOtherColumn.Add(cRealname);
            BLL.IISLOG.SpiderBll.Instance.SaveEntityFromCtr(phCtrList, lstOtherColumn);


        }
    }
}