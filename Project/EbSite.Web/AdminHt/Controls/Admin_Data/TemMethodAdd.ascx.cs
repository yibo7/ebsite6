using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.BLL;
using EbSite.Base.ControlPage;

namespace EbSite.Web.AdminHt.Controls.Admin_Data
{
    public partial class TemMethodAdd : UserControlBaseSave
    {
        public override string Permission
        {
            get
            {
                return "288";
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
            BLL.TemMethod.Instance.InitModifyCtr(new Guid(SID), phCtrList);
        }
        override protected void SaveModel()
        {
            //Base.BLL.OtherColumn cRealname = new OtherColumn("IsAuditing", "true");
            //lstOtherColumn.Add(cRealname);
            BLL.TemMethod.Instance.SaveEntityFromCtr(phCtrList, lstOtherColumn);
        }
    }
}