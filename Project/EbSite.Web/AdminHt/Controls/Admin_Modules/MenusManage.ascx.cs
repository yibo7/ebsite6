using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.MobileControls;
using System.Web.UI.WebControls;
using EbSite.Base.Page;
using System.Web;
using EbSite.BLL.ModulesBll;
using EbSite.Entity.Module;
using TextBox = System.Web.UI.WebControls.TextBox;

namespace EbSite.Web.AdminHt.Controls.Admin_Modules
{
    //
    public partial class MenusManage : BaseList
    {
        public override string Permission
        {
            get
            {
                return "237";
            }
        }

        override protected string AddUrl
        {
            get
            {
                return "";
            }
        }
        override protected object LoadList(out int iCount)
        {
            iCount = 0;
            return null;
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
            //this.gdList.DataSource = BLL.Menus.Instance.GetTree_pic(0);
            //this.gdList.DataBind();
            MenusForAdminer mm = new MenusForAdminer(GetModuleID);
            ModulePageInfo md = mm.GetEntity(GetMenuID);
            this.MenuName.Text = md.PageName;

            Entity.Menus a =
              BLL.Menus.Instance.GetEntity(GetMenuID);

            if (!Equals(a, null))
            {
                lbsTarget.SelectedValue = a.id.ToString(); //让ListBox默认选中
            }

            lbsTarget.DataTextField = "menuname";
            lbsTarget.DataValueField = "id";
            lbsTarget.DataSource = BLL.Menus.Instance.GetTree(0);
            lbsTarget.DataBind();



        }
        protected void gdList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            CheckBox cb = (CheckBox)e.Row.FindControl("Selector");
            TextBox tb = (TextBox)e.Row.FindControl("TextBox1");
            if (!Equals(tb, null))
            {
                string tag = GetCheckControl(tb.Text);
                if (tag != "")
                {
                    cb.Checked = true;
                }
            }
        }
        protected string GetCheckControl(string columName)
        {
            string tag = "";
            List<Entity.Menus> lsit = BLL.Menus.Instance.GetListArray("ModulesMenusID='" + GetMenuID + "' and id='" + columName + "'");
            if (lsit.Count > 0)
            {
                tag = "1";
            }
            return tag;
        }


        protected void bntOK_Click(object sender, EventArgs e)
        {
            //先查找此菜单是否已添加
            Entity.Menus a =
                BLL.Menus.Instance.GetEntity(new Guid(System.Web.HttpContext.Current.Request.QueryString["mid"]));
            if (!Equals(a, null))
            {
                //就直接移动
            }
            else
            {
                //先添加
                Entity.Menus model = BLL.Menus.Instance.GetEntity(new Guid(lbsTarget.SelectedValue));
                Entity.Menus NewModel = new Entity.Menus();
                NewModel.ParentID = model.ParentID;
                //NewModel.ModulesID = System.Web.HttpContext.Current.Request.QueryString["ModulesID"];

                MenusForAdminer mm = new MenusForAdminer(GetModuleID);
                ModulePageInfo md = mm.GetEntity(GetMenuID);
                NewModel.ModulesID = new Guid(md.ModuleID.ToString());

                NewModel.id = md.id;//这里最关键，不要在用业务层中的new guid();

                NewModel.MenuName = md.PageName;
                //NewModel.companyId = 0;//先给定一个
                NewModel.ImageUrl = "/images/Menu/User (2).gif";
                NewModel.AddTime = DateTime.Now;
                NewModel.OrderID = 1;//给成默认的1,下面自动给排序


               // NewModel.CtrPath = md.FileName;
                NewModel.PageUrl = md.FileName;
                BLL.Menus.Instance.Add(NewModel);

            }


            //移动菜单　
            Guid iSoureClassID = GetMenuID;
            Guid iTargetClassID = new Guid(lbsTarget.SelectedValue);
            bool IsToSub = (Equals(movetype.SelectedValue, "1"));
            BLL.Menus.Instance.MoveClass(iSoureClassID, iTargetClassID, IsToSub);
            #region
            //foreach (GridViewRow row in gdList.Rows)
            //{
            //    CheckBox cb = (CheckBox)row.FindControl("Selector");
            //    if (cb != null && cb.Checked)
            //    {
            //        TextBox columName = (TextBox)row.FindControl("TextBox1");
            //        Entity.Menus model = BLL.Menus.Instance.GetEntity(new Guid(columName.Text));

            //        Entity.Menus NewModel = new Entity.Menus();

            //        NewModel.ParentID = model.ParentID;
            //        NewModel.ModulesID = System.Web.HttpContext.Current.Request.QueryString["ModulesID"];
            //        //ID　不能用。ID到业务层自动生成GUID.
            //        //2011-01-20　现在可以查询。
            //        //仿照经理的模块的添加帮助写的。
            //        //NewModel.id = new Guid( System.Web.HttpContext.Current.Request.QueryString["mid"]);

            //        ModuleMenu mm = new ModuleMenu(new Guid(System.Web.HttpContext.Current.Request.QueryString["ModulesID"]));
            //        ModulePageInfo md = mm.GetEntity(new Guid(System.Web.HttpContext.Current.Request.QueryString["mid"]));

            //        //NewModel.MenuName = System.Web.HttpContext.Current.Request.QueryString["Name"];
            //        NewModel.MenuName = md.PageName;
            //        NewModel.companyId = 0;//先给定一个
            //        NewModel.ImageUrl = "/images/Menu/User (2).gif";
            //        NewModel.AddTime = DateTime.Now;
            //        NewModel.OrderID = model.OrderID;//在选定的菜单上面加上菜单.要把此orderID给新的菜单.它下面的都要加1

            //        //查出＞=orderid 的所有菜单
            //        List<Entity.Menus> lsit = BLL.Menus.Instance.GetListArray("parentid='"+model.ParentID+"' and orderid>="+model.OrderID);
            //        if(lsit.Count>0)
            //        {
            //            foreach (Entity.Menus li in lsit)
            //            {
            //                Entity.Menus updateModel = BLL.Menus.Instance.GetEntity(li.id);
            //                updateModel.id = li.id;
            //                updateModel.OrderID = li.OrderID + 1;
            //                BLL.Menus.Instance.Update(updateModel);

            //            }
            //        }

            //       // NewModel.ModulesMenusID = System.Web.HttpContext.Current.Request.QueryString["mid"];


            //       // NewModel.CtrPath = System.Web.HttpContext.Current.Request.QueryString["ctrPath"];
            //        NewModel.CtrPath = md.FileName;
            //        BLL.Menus.Instance.Add(NewModel);
            //    }
            //}
            #endregion
            EbSite.Core.Strings.cJavascripts.RunClientJs(this, "ColseGreyBox();");

        }
    }
}