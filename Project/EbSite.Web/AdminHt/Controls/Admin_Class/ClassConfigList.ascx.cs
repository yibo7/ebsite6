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
            get {
                return "t=5";
            }
        }
        public override string Permission
        {
            get
            {
                return "185";
            }
        }
        public override string PermissionAddID
        {
            get
            {
                return "185";
            }
        }
        /// <summary>
        /// 修改数据的权限ID
        /// </summary>
        public override string PermissionModifyID
        {
            get
            {
                return "185";
            }
        }

        /// <summary>
        /// 删除数据的权限ID 这里用的是分类的
        /// </summary>
        public override string PermissionDelID
        {
            get
            {
                return "185";
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               
            }

        } 
        protected override void CopyData(object ID)
        {
            int id = int.Parse(ID.ToString());
            var model = BLL.ClassConfigs.Instance.GetEntity(id);
            model.ConfigName = string.Concat(model.ConfigName, "-COPY");
            model.IsDefault = false;
            BLL.ClassConfigs.Instance.Add(model);
        }
        override protected object SearchList(out int iCount)
        {
            string key = ucToolBar.GetItemVal(txtKeyWord).Trim();
            string sWhere = string.Format("ConfigName like '%{0}%'",key);
            return BLL.ClassConfigs.Instance.GetListPages(pcPage.PageIndex, pcPage.PageSize, sWhere, "", out iCount, base.GetSiteID);
        }

        override protected object LoadList(out int iCount)
        { 
            return BLL.ClassConfigs.Instance.GetListPages(pcPage.PageIndex, pcPage.PageSize, "", "", out iCount, base.GetSiteID);
        }
        protected override void Delete(object ID)
        {
            BLL.ClassConfigs.Instance.Delete(Core.Utils.ObjectToInt(ID));
        }

        override protected void gdList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            base.gdList_RowCommand(sender, e);

            if (Equals(e.CommandName, "modifyCf"))
            {
                string id = e.CommandArgument.ToString();
                Response.Redirect(string.Format("admin_class.aspx?t=5&id={0}", id));

            }
            else if (Equals(e.CommandName, "SetToDefault"))
            {
                string id = e.CommandArgument.ToString();
                BLL.ClassConfigs.Instance.UpdateDefault(int.Parse(id), GetSiteID);
                base.gdList_Bind();
            } 
        }
        override protected void gdList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Entity.ClassConfigs cf = (Entity.ClassConfigs)e.Row.DataItem; 
                if (cf.IsDefault) //系统默认的配置，不能删除
                {
                    LinkButton drpCtrType = (LinkButton)e.Row.Cells[2].FindControl("lbDelete");
                    drpCtrType.Visible = false;
                    LinkButton lbSetDefault = (LinkButton)e.Row.Cells[2].FindControl("lbSetDefault");
                    lbSetDefault.Visible = false;
                    
                } 
            }
        }
        #region 工具栏的初始化
        protected System.Web.UI.WebControls.TextBox txtKeyWord = new System.Web.UI.WebControls.TextBox();
        override protected void BindToolBar()
        {

            base.BindToolBar(false, true, false, false, false);
            ucToolBar.AddLine();

            txtKeyWord.ID = "txtKeyWord";
            ucToolBar.AddCtr(txtKeyWord);             

            base.ShowCustomSearch("查询");              
 


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


        