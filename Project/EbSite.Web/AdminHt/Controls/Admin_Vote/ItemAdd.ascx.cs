using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.BLL;
using EbSite.Base.ControlPage;

namespace EbSite.Web.AdminHt.Controls.Admin_Vote
{
    public partial class ItemAdd : UserControlBaseSave
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public override string Permission
        {
            get
            {
                return "308";
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
            BLL.voteitem.Instance.InitModifyCtr(SID, phCtrList);
        }
        override protected void SaveModel()
        {

            lstOtherColumn.Add(new OtherColumn("VoteID",Request["vid"]));
       
            BLL.voteitem.Instance.SaveEntityFromCtr(phCtrList, lstOtherColumn);


        }
    }
}