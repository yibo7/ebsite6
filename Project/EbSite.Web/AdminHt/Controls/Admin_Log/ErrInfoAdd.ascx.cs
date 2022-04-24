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

namespace EbSite.Web.AdminHt.Controls.Admin_Log
{
    public partial class ErrInfoAdd : UserControlBaseSave
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
            BLL.ErrInfo.Instance.InitModifyCtr(SID, phCtrList);
        }
        override protected void SaveModel()
        {
            Base.BLL.OtherColumn cRealname = new OtherColumn("ErrCount", "0");
            lstOtherColumn.Add(cRealname);
            BLL.ErrInfo.Instance.SaveEntityFromCtr(phCtrList, lstOtherColumn);


        }
    }
}