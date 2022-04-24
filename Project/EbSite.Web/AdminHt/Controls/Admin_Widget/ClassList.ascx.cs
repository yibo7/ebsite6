using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace EbSite.Web.AdminHt.Controls.Admin_Widget
{
    public partial class ClassList : EbSite.Base.ControlPage.UserControlListBase
    {
        public override string Permission
        {
            get
            {
                return "121";
            }
        }
        public override string PermissionAddID
        {
            get
            {
                return "180";
            }
        }
        /// <summary>
        /// 修改数据的权限ID
        /// </summary>
        public override string PermissionModifyID
        {
            get
            {
                return "1";
            }
        }
        /// <summary>
        /// 删除数据的权限ID
        /// </summary>
        public override string PermissionDelID
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
                return "t=5";
            }
        }
        override protected object LoadList(out int iCount)
        {
            iCount = 0;
            return BLL.ClassCustom.Provider.Factory.Widget().Fills();
        }

        override protected object SearchList(out int iCount)
        {
            iCount = 0;
            List<Entity.ClassCustom> lstRz = new List<Entity.ClassCustom>();
            List<Entity.ClassCustom> lst = BLL.ClassCustom.Provider.Factory.Widget().Fills();
            string sKeyTitle = ucToolBar.GetItemVal(txtOne).Trim();

            if (!string.IsNullOrEmpty(sKeyTitle))
            {
                foreach (Entity.ClassCustom item in lst)
                {
                    if (item.Title.IndexOf(sKeyTitle) > -1)
                    {
                        lstRz.Add(item);
                    }
                }
            }
            else
            {
                lstRz = lst;
            }

            return lstRz;
        }
        override protected void Delete(object iID)
        {
            BLL.ClassCustom.Provider.Factory.Widget().Delete(iID.ToString());

        }

        protected TextBox txtOne = new TextBox();
        protected Label lblClassName = new Label();
        protected override void BindToolBar()
        {
            base.BindToolBar(true,true,false,false,false);

            //ucToolBar.AddLine();

            lblClassName.ID = "lblClassName";
            ucToolBar.AddCtr(lblClassName);
            lblClassName.Text = "分类名称：";

            txtOne.ID = "txtKeyWord";
            ucToolBar.AddCtr(txtOne);

            base.ShowCustomSearch("查询");

        }
    }
}