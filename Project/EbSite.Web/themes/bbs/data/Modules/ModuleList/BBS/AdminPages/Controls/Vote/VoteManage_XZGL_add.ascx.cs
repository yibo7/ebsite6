using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.BLL;
using EbSite.Base.Modules;


namespace EbSite.Modules.BBS.AdminPages.Controls.Vote
{
    public partial class VoteManage_XZGL_add : MPUCBaseSave
    {
        public override string Permission
        {
            get
            {
                return "dddd7b";
            }
        }
        override protected string KeyColumnName
        {
            get
            {
                return "id";
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {            
            if (!IsPostBack)
            {
                if (string.IsNullOrEmpty(Convert.ToString(SID)))
                {
                    ddlSSZT.DataSource = ModuleCore.BLL.toupiaobt.Instance.GetListArrayByUname(UserName);
                    ddlSSZT.DataBind();
                }                  
            }
        }
        override protected void InitModifyCtr()
        {
            if (!string.IsNullOrEmpty(Convert.ToString(SID)))
            {
                ddlSSZT.DataSource = ModuleCore.BLL.toupiaobt.Instance.GetListArrayByUname(UserName);
                ddlSSZT.DataBind();
                ModuleCore.Entity.toupiao tp = ModuleCore.BLL.toupiao.Instance.GetEntity(long.Parse(SID.ToString()));
                ddlSSZT.SelectedValue = tp.bigId;               
            }
            ModuleCore.BLL.toupiao.Instance.InitModifyCtr(SID, phCtrList);
        }

        
        override protected void SaveModel()
        {
            Base.BLL.OtherColumn cl = new OtherColumn("color",cpColor.Color);
            lstOtherColumn.Add(cl);
            cl = new OtherColumn("bigId",ddlSSZT.SelectedValue);
            lstOtherColumn.Add(cl);
            cl = new OtherColumn("bigtitle",ddlSSZT.SelectedItem.Text);
            lstOtherColumn.Add(cl);
            cl = new OtherColumn("shuoming", "");
            lstOtherColumn.Add(cl);
            cl = new OtherColumn("Username", UserName);
            lstOtherColumn.Add(cl);
            //cl = new OtherColumn("Realname",UserRealname);
            //lstOtherColumn.Add(cl);
            cl = new OtherColumn("TpUsername","");
            lstOtherColumn.Add(cl);
            cl = new OtherColumn("TpRealname","");
            lstOtherColumn.Add(cl);
            ModuleCore.BLL.toupiao.Instance.SaveEntityFromCtr(phCtrList, lstOtherColumn);
        }
    }
}