using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Web.UI.WebControls;
using EbSite.BLL;
using EbSite.Base.ControlPage;
using EbSite.Control;
//using EbSite.Core.Static.BatchCreatManager;
using EbSite.Entity;
using LinkButton = System.Web.UI.WebControls.LinkButton;

namespace EbSite.Web.AdminHt.Controls.Admin_Class
{
    public partial class ClassConfigList : UserControlListBase
    {
        protected override string AddUrl
        {
            get { throw new NotImplementedException(); }
        }

       

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               
            }

        }
           

        override protected void gdList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            base.gdList_RowCommand(sender, e);

            if (Equals(e.CommandName, "addcontent"))
            {
                string id = e.CommandArgument.ToString();
                Response.Redirect("Admin_Content.aspx?t=4&cid=" + id);

            } 
        }

         

        override protected void gdList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //Entity.NewsClass drData = (Entity.NewsClass)e.Row.DataItem;
                //Entity.ClassConfigs cf = BLL.ClassConfigs.Instance.GetClassConfigsByClassID(drData.ID);
                //if (!cf.IsCanAddContent) //是否可以添加内容
                //{
                //    LinkButton drpCtrType = (LinkButton)e.Row.Cells[3].FindControl("lbAddcontent");
                //    drpCtrType.Visible = false;
                //    drpCtrType = (LinkButton)e.Row.Cells[3].FindControl("lbShowcontent");
                //    drpCtrType.Visible = false;
                //}
                 
            }
        }


        /////////////////////////////

        
        //private bool IsLongClass = Base.Configs.SysConfigs.ConfigsControl.Instance.IsLongClass;
        override protected object LoadList(out int iCount)
        {
            return BLL.ClassConfigs.Instance.GetListPages(pcPage.PageIndex, pcPage.PageSize, "", "", out iCount);
        }
        protected override void Delete(object ID)
        {
            BLL.ClassConfigs.Instance.Delete(Core.Utils.ObjectToInt(ID));
        }



        #region 工具栏的初始化
        protected System.Web.UI.WebControls.TextBox txtKeyWord = new System.Web.UI.WebControls.TextBox();
        protected System.Web.UI.WebControls.DropDownList drpSearchTp = new System.Web.UI.WebControls.DropDownList();
        protected System.Web.UI.WebControls.DropDownList drpLike = new System.Web.UI.WebControls.DropDownList();
        override protected void BindToolBar()
        {

            base.BindToolBar(true, false, false, false, false);
            ucToolBar.AddLine();

            txtKeyWord.ID = "txtKeyWord";
            ucToolBar.AddCtr(txtKeyWord);

            //string sFileds = Base.Configs.SysConfigs.ConfigsControl.Instance.AdminSearchClassFileds;
            string sFileds = BLL.DataSettings.Category.Instance.GetConfigCurrent.AdminSearchFileds;
            if (!string.IsNullOrEmpty(sFileds))
            {
                string[] Columns = sFileds.Split(',');

                foreach (string sC in Columns)
                {
                    string[] OneItem = sC.Split('|');

                    if (OneItem.Length == 2)
                    {
                        ListItem li = new ListItem(OneItem[1], OneItem[0]);

                        drpSearchTp.Items.Add(li);
                    }
                }
            }
            drpSearchTp.ID = "drpSearchTp";
            ucToolBar.AddCtr(drpSearchTp);

            drpLike.ID = "drpLike";
            ListItem liIt = new ListItem("准确", "1");
            drpLike.Items.Add(liIt);
            liIt = new ListItem("模糊", "2");
            drpLike.Items.Add(liIt);
            ucToolBar.AddCtr(drpLike);

            base.ShowCustomSearch("查询");

            //ucToolBar.AddBnt("高级", "images/MenuImg/Search-Add.gif", "", false, "OpenDialog_Save('divSearh',OnSearch)");

            ucToolBar.AddLine();

            ucToolBar.AddBnt("生成静态", string.Concat(IISPath, "images/Menus/ie.png"), "", false, "OpenDialog_SavePost('divMakeHtml',OnMakeClassHtml,true)", "生成静态页面，没有选择将生成全部");



        }
        #endregion

        #region 工具栏事件扩展

        //protected override void ucToolBar_ItemClick(object source, Control.ItemClickArgs e)
        //{
        //    base.ucToolBar_ItemClick(source, e);
        //    switch (e.ItemTag)
        //    {
        //        case "good":
        //            break;
        //    }
        //}

        #endregion
             

    }
}


        