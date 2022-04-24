using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.BLL.ModulesBll;
using EbSite.Control;
using EbSite.Entity.Module;
using CheckBox = System.Web.UI.WebControls.CheckBox;

namespace EbSite.Web.AdminHt.Controls.Admin_Modules
{
    public partial class LimitRole : BaseList
    {


        public override string Permission
        {
            get
            {
                return "237";
            }
        }
        public string Name
        {
            get
            {
                if (!string.IsNullOrEmpty(Request["name"]))
                {
                    return Request.QueryString["name"];
                }
                return "";
                
            }
        }
        override protected object LoadList(out int iCount)
        {
            iCount = 0;
            BLL.ModulesBll.LimitsForAdminer bll = new LimitsForAdminer(base.GetModuleID);
            return bll.GetLimitsFull;
        }

        override protected object SearchList(out int iCount)
        {
            iCount = 0;
            return null;
            //return BLL.Respon.Instance.Search(pcPage.PageIndex, pcPage.PageSize, "", out iCount, ucToolBar.GetItemVal(txtOne).Trim());
        }
        override protected void Delete(object iID)
        {
            //BLL.Respon.Instance.Delete(long.Parse(iID.ToString()));

        }
        private int GetRoleID
        {
            get
            {
                if(!string.IsNullOrEmpty(Request["rid"]))
                {
                    return int.Parse(Request["rid"]);
                }
                return 0;
            }
        }
        protected override void gdList_RowCreated(object sender, GridViewRowEventArgs e)
        {
            base.gdList_RowCreated(sender, e);
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                GridViewRow row = e.Row;
                CheckBox wbShow = (CheckBox)row.FindControl("Selector");
                if (!object.Equals(wbShow, null))
                {
                    string sID = gdList.DataKeys[e.Row.RowIndex].Value.ToString();

                    if(bllLimitRole.IsHave(GetRoleID, int.Parse(sID)))
                    {
                        wbShow.Checked = true;
                    }
                }


            }
        }
        private BLL.ModulesBll.LimitRole<int> bllLimitRole
        {
            get
            {
                return new BLL.ModulesBll.LimitRoleForAdminer(base.GetModuleID);
            }
        } 
        protected void bntSave_Click(object sender,EventArgs e)
        {
            List<EbSite.Entity.Module.LimitRoleInfo<int>> lst = new List<LimitRoleInfo<int>>();
            foreach (GridViewRow row in this.gdList.Rows)
            {
                System.Web.UI.WebControls.CheckBox box = (System.Web.UI.WebControls.CheckBox)row.FindControl("Selector");
                if ((box != null) && box.Checked)
                {
                        string sLimitID = this.gdList.DataKeys[row.RowIndex].Value.ToString();
                        LimitRoleInfo<int> md = new LimitRoleInfo<int>();
                        md.LimitID = int.Parse(sLimitID);
                        md.RoleID = GetRoleID;
                        lst.Add(md);
                }
            }

            bllLimitRole.AddList(lst,GetRoleID);

            EbSite.Core.Strings.cJavascripts.RunClientJs(this, "ColseGreyBox();");
        }
    }
}