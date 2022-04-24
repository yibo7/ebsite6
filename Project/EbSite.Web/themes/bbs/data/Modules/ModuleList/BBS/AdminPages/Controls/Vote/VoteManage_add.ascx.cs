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
    public partial class VoteManage_add : MPUCBaseSave
    {
        public override string Permission
        {
            get
            {
                return "2";
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
            string id = Convert.ToString(Request.QueryString["id"]);
            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(id))
                {
                    ModuleCore.Entity.toupiaobt tpbt = ModuleCore.BLL.toupiaobt.Instance.GetEntity(long.Parse(id));
                    ddlIfOpen.SelectedValue = tpbt.ifopen;
                    ddlXZLX.SelectedValue = tpbt.xuanze;
                    //sbuTPRY.UserNames = tpbt.Gkusername;
                    //sbuTPRY.RealNames = tpbt.Gkrealname;
                }                  
            }
        }
        override protected void InitModifyCtr()
        {
            ModuleCore.BLL.toupiaobt.Instance.InitModifyCtr(SID, phCtrList);
        }

        
        override protected void SaveModel()
        {
            Base.BLL.OtherColumn cl = new OtherColumn("xuanze",ddlXZLX.SelectedValue);
            lstOtherColumn.Add(cl);            
            cl = new OtherColumn("Username", UserName);
            lstOtherColumn.Add(cl);
            //cl = new OtherColumn("Realname",UserRealname);
            //lstOtherColumn.Add(cl);
            //cl = new OtherColumn("Gkusername",sbuTPRY.UserNames);
            //lstOtherColumn.Add(cl);
            //cl = new OtherColumn("Gkrealname",sbuTPRY.RealNames);
            //lstOtherColumn.Add(cl);
            cl = new OtherColumn("type","进行中");
            lstOtherColumn.Add(cl);
            cl = new OtherColumn("ifopen", ddlIfOpen.SelectedValue);
            lstOtherColumn.Add(cl);
            ModuleCore.BLL.toupiaobt.Instance.SaveEntityFromCtr(phCtrList, lstOtherColumn);
        }
    }
}