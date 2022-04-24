using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.ControlPage;

namespace EbSite.Web.AdminHt.Controls.Admin_Menu
{
    public partial class UserMenu_Move : UserControlBaseSave
    {
        public override string Permission
        {
            get
            {
                return "161";
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
            }

        }
        private void BindData()
        {
            lbsSourceclass.DataTextField = "menuname";
            lbsSourceclass.DataValueField = "id";
            lbsSourceclass.DataSource = BLL.MenusForUser.Instance.GetTree(0);
            lbsSourceclass.DataBind();

            lbsTarget.DataTextField = "menuname";
            lbsTarget.DataValueField = "id";
            lbsTarget.DataSource = BLL.MenusForUser.Instance.GetTree(0);
            lbsTarget.DataBind();
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
        }

        override protected void SaveModel()
        {
            if (lbsSourceclass.SelectedValue == lbsTarget.SelectedValue)
            {
                base.TipsAlert("您所要移动的分类与目标分类相同，无法移动！");
                return;
            }

            if (string.IsNullOrEmpty(lbsSourceclass.SelectedValue) || string.IsNullOrEmpty(lbsTarget.SelectedValue))
            {
                base.TipsAlert("请选择好源分类与目标分类！");
                return;
            }

            Guid iSoureClassID = new Guid(lbsSourceclass.SelectedValue);
            Guid iTargetClassID = new Guid(lbsTarget.SelectedValue);
            bool IsToSub = (Equals(movetype.SelectedValue, "1"));
            BLL.MenusForUser.Instance.MoveClass(iSoureClassID, iTargetClassID, IsToSub);

            BindData();

        }
    }
}