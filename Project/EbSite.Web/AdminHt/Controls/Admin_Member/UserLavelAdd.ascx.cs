using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using EbSite.Base.ControlPage;
using EbSite.BLL.User;
using EbSite.Core;

namespace EbSite.Web.AdminHt.Controls.Admin_Member
{
    public partial class UserLavelAdd : UserControlBaseSave
    {

        public override string Permission
        {
            get
            {
                return "76";
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


            BLL.UserLevel.Instance.InitModifyCtr(SID, phCtrList);
        }

        override protected void SaveModel()
        {
            //Base.BLL.OtherColumn cRealname = new OtherColumn("ErrCount", "0");
            //lstOtherColumn.Add(cRealname);
            BLL.UserLevel.Instance.SaveEntityFromCtr(phCtrList, lstOtherColumn);


        }

    }
}