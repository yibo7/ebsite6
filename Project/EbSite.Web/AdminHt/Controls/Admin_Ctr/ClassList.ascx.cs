using System;
using EbSite.Base.ControlPage;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace EbSite.Web.AdminHt.Controls.Admin_Ctr
{
    public partial class ClassList :UserControlListBase
    {
        public override string Permission
        {
            get
            {
                return "112";
            }
        }
        public override string PermissionAddID
        {
            get
            {
                return "113";
            }
        }
        /// <summary>
        /// 修改数据的权限ID
        /// </summary>
        public override string PermissionModifyID
        {
            get
            {
                return "216";
            }
        }
        /// <summary>
        /// 删除数据的权限ID
        /// </summary>
        public override string PermissionDelID
        {
            get
            {
                return "215";
            }
        }
        override protected string AddUrl
        {
            get
            {
                return "t=6";
            }
        }
        override protected object LoadList(out int iCount)
        {
            iCount = 0;
            return BLL.ClassCustom.Provider.Factory.ModelCtrl().Fills();
        }

        override protected object SearchList(out int iCount)
        {
            iCount = 0;
            List<Entity.ClassCustom> lstRz = new List<Entity.ClassCustom>();
            List<Entity.ClassCustom> lst = BLL.ClassCustom.Provider.Factory.ModelCtrl().Fills();

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
            BLL.ClassCustom.Provider.Factory.ModelCtrl().Delete(iID.ToString());

        }

        protected Control.TextBox txtOne = new Control.TextBox();
        protected Label lblClassName = new Label();
        protected override void BindToolBar()
        {
            base.BindToolBar();

            ucToolBar.AddLine();

            lblClassName.ID = "lblClassName";
            ucToolBar.AddCtr(lblClassName);
            lblClassName.Text = "分类名称：";

            txtOne.ID = "txtKeyWord";
            ucToolBar.AddCtr(txtOne);

            base.ShowCustomSearch("查询");

        }
    }
}