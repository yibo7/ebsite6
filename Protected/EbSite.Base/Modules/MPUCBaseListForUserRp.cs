using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using EbSite.Base.ControlPage;
using EbSite.Control;

namespace EbSite.Base.Modules
{
    public abstract class MPUCBaseListForUserRp : MPUCBaseListForUserRpBase
    {

      
        protected ToolBar ucToolBar;
        
        public MPUCBaseListForUserRp()
        {
            base.Load += new EventHandler(this.BasePage_Load);
        }

        private void BasePage_Load(object sender, EventArgs e)
        {
         
            if (!object.Equals(this.ucToolBar, null))
            {
            
                ucToolBar.ThemesPath = string.Concat(IISPath, "js/plugin/toolbar/theme1/index.css");

                this.ucToolBar.ItemClick += new EventToolBarItemClick(this.ucToolBar_ItemClick);
                this.BindToolBar();
            }
          
            base.BasePage_Load();
        }
        protected override void BindToolBar(bool IsCloseAdd, bool IsCloseDel)
        {

            ToolBarItem lb = new ToolBarItem();
            if (!IsCloseAdd)
            {

                ucToolBar.AddBnt("添加", string.Concat(base.IISPath, "images/menus/add.gif"), "add", false, string.Concat("window.location.href ='", this.AddUrl,"'"), "添加数据");

            }
            if (!IsCloseDel)
            {
                lb = new ToolBarItem();
                lb.Text = "删除";
                lb.OnClientClick = "return confirm('确认要删除所选项吗？');";
                lb.Img = string.Concat(IISPath, "images/menus/Delete.gif");
                lb.EventTag = "del";
                ucToolBar.Items.Add(lb);

            }
        }

        //protected virtual void ucToolBar_ItemClick(object source, ItemClickArgs e)
        //{
        //    string itemTag = e.ItemTag;
        //    if (itemTag != null)
        //    {
        //        if (!(itemTag == "del"))
        //        {
        //            if (itemTag == "search")
        //            {
        //                this.SearchType = 0;
        //                base.Session["swhere"] = "";
        //                this.BindSearchData();
        //            }
        //            else if (itemTag == "searchadv")
        //            {
        //                this.SearchType = 1;
        //                base.Session["swhere"] = "";
        //                this.BindSearchData();
        //            }
        //        }
        //        else
        //        {
        //            //foreach (GridViewRow row in this.gdList.)
        //            //{
        //            //    foreach (string selKey in GetSelKeys)
        //            //    {
        //            //        this.Delete(selKey);
        //            //    }
        //            //}
        //            this.gdList_Bind();
        //        }
        //    }
        //}

        //protected virtual void BindToolBar()
        //{
        //    BindToolBar(false);
        //}
        //protected virtual string AddUrlType
        //{
        //    get { return string.Empty; }
        //}
        //protected virtual string ShowUrlType
        //{
        //    get { return string.Empty; }
        //}
        /// <summary>
        /// 弹出框
        /// </summary>
        protected string AddUrlBox
        {
            get
            {
                return string.Concat("?box=1&t=" , AddUrlType); 
            }
        }
        
        /// <summary>
        /// 弹出框修改
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        protected string ModifyBoxUrl(string id)
        {
            return string.Concat(AddUrl, "&id=", id);
            //return string.Concat(AddUrlBox, "&id=", id);

        }
        protected override string GetUrl
        {
            get
            {

                return string.Format("{0}?mukey={1}", this.GetPageName, this.ModuleMenuID);
            }
        }
        //protected string DelUrl(string id)
        //{
        //    if (Request.RawUrl.IndexOf("?") > 1)
        //    {
        //        return string.Concat(Request.RawUrl, "&delid=", id);
        //    }
        //    else
        //    {
        //        return string.Concat(Request.RawUrl, "?delid=", id);
        //    }
            

        //}
        //private void DeleteFromUrl()
        //{
        //    string sID = Request["delid"];
        //    if (!string.IsNullOrEmpty(sID))
        //    {
        //        Delete(sID);
        //        Response.Redirect(GetFromURL);
        //    }

        //}
        //protected virtual void BindToolBar(bool IsCloseAdd)
        //{
        //    BindToolBar(IsCloseAdd, true);
        //}

        //protected virtual void BindToolBar(bool IsCloseAdd, bool IsCloseDel)
        //{
        //    ToolBarItem lb = new ToolBarItem();
        //    if (!IsCloseAdd)
        //    {
        //        this.ucToolBar.AddDialog(this.AddUrlBox, "添加", base.IISPath + "images/menus/add.gif", 800, 500, true, false);

        //    }
        //    if (!IsCloseDel)
        //    {
        //        lb = new ToolBarItem();
        //        lb.Text = "删除";
        //        lb.OnClientClick = "return confirm('确认要删除所选项吗？');";
        //        lb.Img = string.Concat(IISPath, "images/menus/Delete.gif");
        //        lb.EventTag = "del";
        //        ucToolBar.Items.Add(lb);

        //    }
            


        //}

        #region 实现方法
        ///// <summary>
        ///// 获取所选ID集合
        ///// </summary>
        //override protected List<string> GetSelKeys
        //{
        //    get
        //    {
        //        List<string> lst = new List<string>();

        //        //foreach (GridViewRow row in gdList.Rows)
        //        //{
        //        //    // Access the CheckBox
        //        //    System.Web.UI.WebControls.CheckBox cb = (System.Web.UI.WebControls.CheckBox)row.FindControl("Selector");
        //        //    if (cb != null && cb.Checked)
        //        //    {
        //        //        lst.Add(gdList.DataKeys[row.RowIndex].Value.ToString());

        //        //    }
        //        //}

        //        return lst;
        //    }
        //}
        //protected override bool IsListCtrNull
        //{
        //    get
        //    {
        //        return object.Equals(this.gdList, null);
        //    }
        //}


        //override protected void BindSearchData()
        //{
        //    this.gdList.DataSource = this.SearchList(out this.ListCount);
        //    this.gdList.DataBind();
        //    this.PageCtr_Bind("|qt,1");
        //}

        //override protected void gdList_Bind()
        //{
        //    this.gdList.DataSource = this.LoadList(out this.ListCount);
        //    this.gdList.DataBind();
        //    this.PageCtr_Bind("");
        //}
        #endregion

        #region 对处开放方法
        ///// <summary>
        ///// 批量删除,ID用逗号分开
        ///// </summary>
        ///// <param name="IDs"></param>
        //virtual protected void Deletes(string IDs)
        //{
            
        //}
        //virtual protected void gdList_ItemCommand(object sender, RepeaterCommandEventArgs e)
        //{
        //    if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
        //    {
        //        base.Response.Redirect(base.Request.RawUrl);
        //    }
        //}
        //virtual protected void gdList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        //{
        //    if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
        //    {
        //    }
        //}
        //virtual protected void gdList_ItemCreated(object sender, RepeaterItemEventArgs e)
        //{
        //    if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
        //    {
        //    }
        //}
        #endregion

        //// <summary>
        //// 检测当前用户是否具有某个权限ID
        //// </summary>
        //// <param name="LimitID">权限Id</param>
        //// <returns></returns>
        ////override protected bool IsHaveLimit(string LimitID)
        ////{

        ////    return HostApi.IsHaveLimitForUser(EbSite.Base.AppStartInit.UserID, int.Parse(LimitID), ModuleID);
        ////}

    }
}

