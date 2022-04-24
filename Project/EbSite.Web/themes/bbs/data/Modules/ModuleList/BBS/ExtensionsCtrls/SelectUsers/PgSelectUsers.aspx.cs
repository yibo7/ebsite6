using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.Page;

namespace EbSite.Modules.BBS.ExtensionsCtrls
{
    public partial class PgSelectUsers : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BindTree(ListTreeView.Nodes, 0);
        }
        /// <summary>
        /// 为0表示多选,为1表示单选
        /// </summary>
        private int GetSelType
        {
            get
            {
                if (!string.IsNullOrEmpty(Request["slt"]))
                {
                    return int.Parse(Request["slt"]);
                }
                else
                {
                    return 0;
                }
            }
        }
        private string SplitChar = ",";
        private void BindTree(TreeNodeCollection Nds, long ParentID)
        {
            List<EbSite.Base.EntityAPI.MembershipUserEb> lstUser = BLL.User.MembershipUserEb.Instance.GetListArray(0, "", "id asc");
            foreach (EbSite.Base.EntityAPI.MembershipUserEb lsitusername in lstUser)
            {
                TreeNode OrganizationNode1 = new TreeNode();
                OrganizationNode1.Value = lsitusername.id.ToString();
                //if (lsitusername.IsOnline)
                //{
                //    OrganizationNode1.ImageUrl = "/images/menu/on1.gif";
                //}
                //else
                //{
                //    OrganizationNode1.ImageUrl = "/images/menu/on2.gif";
                //}
                string sBntType = "checkbox";
                string sNameID = "";
                if (GetSelType == 1)
                {
                    sBntType = "radio";
                    sNameID = "name=\"radiouserid\"";
                }

                string sHtml = string.Format("<span >{3}<input onclick='CheckUser(this)' value=\"{0}{2}{1}{2}{3}\"  type=\"{4}\" {5} /></span>", lsitusername.id, lsitusername.UserName, SplitChar, lsitusername.NiName, sBntType, sNameID);
                OrganizationNode1.Text = sHtml;
                OrganizationNode1.SelectAction = TreeNodeSelectAction.Expand;
                OrganizationNode1.Expanded = true;
            }
        }
    }
}