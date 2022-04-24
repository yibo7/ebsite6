using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.Modules;


namespace EbSite.Modules.BBS.AdminPages.Controls.Vote
{
    public partial class Vote_CJTP : MPUCBaseList
    {
        protected string s;
        protected string title;
        protected string ifDX;

        public override string Permission
        {
            get
            {
                return "1";
            }
        }
        override protected string AddUrl
        {
            get
            {
                return "t=2";
               // return "NetDisk.aspx?t=2&mid="+ModuleID;
            }
        }
        public string TagCls
        {
            get
            {
                return Request["cls"];
            }
        }


        override protected object LoadList(out int iCount)
        {
            return ModuleCore.BLL.toupiaobt.Instance.GetListPagesByGkuName(pcPage.PageIndex, pcPage.PageSize, out iCount, UserName);
        }

        override protected object SearchList(out int iCount)
        {
            iCount = 0;
            return null;
        }
        override protected void Delete(object iID)
        {

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadTB();
            }
        }

        protected void lbTP_Click(object sender, EventArgs e)
        {           
            for (int i = 0; i < gvXZ.Rows.Count; i++)
            {
                if ((gvXZ.Rows[i].FindControl("cbXZ") as CheckBox).Checked)
                {
                    string id = (gvXZ.Rows[i].FindControl("lbId") as Label).Text;
                    ModuleCore.Entity.toupiao tp = ModuleCore.BLL.toupiao.Instance.getByTpUsername(UserName, id);
                    if (tp != null)
                    {
                        tp.piaoshu = tp.piaoshu + 1;
                        tp.TpUsername = tp.TpUsername + UserName + ",";
                      //  tp.TpRealname = tp.TpRealname + UserRealname + ",";
                        ModuleCore.BLL.toupiao.Instance.Update(tp);
                    }
                    else
                    {
                        base.ShowTipsPop("请勿重复投票!");
                    }
                }
            }
            LoadTB();
        }
        protected void LoadTB()
        {
            string bid = Convert.ToString(Request.QueryString["id"]);
            ModuleCore.Entity.toupiaobt tpbt = ModuleCore.BLL.toupiaobt.Instance.GetEntity(long.Parse(bid));
            ifDX = tpbt.xuanze;
            List<ModuleCore.Entity.toupiao> tpList = ModuleCore.BLL.toupiao.Instance.getArrayListBybigId(bid);
            gvXZ.DataSource = tpList;
            gvXZ.DataBind();            
            if (tpList.Count > 0)
            {
                title = "'"+tpList[0].bigtitle+"'";
                for (int i = 0; i < tpList.Count; i++)
                {
                    if (i < (tpList.Count - 1))
                    {
                        s = s + "['" + tpList[i].title + "'," + Convert.ToString(tpList[i].piaoshu) + "]" + ",";
                    }
                    else
                    {
                        s = s + "['" + tpList[i].title + "'," + Convert.ToString(tpList[i].piaoshu) + "]";
                    }
                }
            }
        }
    }
}