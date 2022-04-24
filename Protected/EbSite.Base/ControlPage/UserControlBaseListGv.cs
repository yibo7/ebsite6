using System.Linq;
using EbSite.BLL;
using EbSite.Base.Configs.SysConfigs;

using EbSite.Control;
using EbSite.Core;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EbSite.Base.ControlPage
{

    abstract public class UserControlListBase : UserControlBaseListAll
    {

        ////搜索类型，0普通搜索，1为高级搜索
        //private int SearchType = 0;
        //protected int ListCount = 0;
        //protected PagesContrl pcPage;
        //protected PlaceHolder phSearchColumns;

        protected EbSite.Control.GridView gdList;
        protected EbSite.Control.Repeater rpList;
        //protected CustomTags ucCurrentTags;
        protected ToolBar ucToolBar;
        protected EasyuiDialog wbAdd = new EasyuiDialog();

        protected abstract string AddUrl { get; }

        virtual protected string GetAddUrl
        {
            get
            {
                if (!Equals(MenuAddID, Guid.Empty))
                {
                    return string.Format("{0}?mpid={1}&msid={2}", this.GetPageName, this.GetParentMenuID, this.MenuAddID);
                }
                else
                {
                    return string.Concat(GetUrl, "&", AddUrl);
                }
            }
        }

        #region 权限
        /// <summary>
        /// 添加权限的标识
        /// </summary>
        public virtual string PermissionAddID
        {
            get
            {
                return "";
            }
        }
        /// <summary>
        /// 删除权限的标识
        /// </summary>
        public virtual string PermissionDelID
        {
            get
            {
                return "";
            }
        }
        /// <summary>
        /// 修改权限的标识
        /// </summary>
        public virtual string PermissionModifyID
        {
            get
            {
                return "";
            }
        }

        #endregion

        public UserControlListBase()
        {
            base.Load += new EventHandler(this.BasePage_Load);

        }

        private void BasePage_Load(object sender, EventArgs e)
        {

            if (!object.Equals(this.ucToolBar, null))
            {
                this.ucToolBar.ItemClick += new EventToolBarItemClick(this.ucToolBar_ItemClick);
                this.BindToolBar();
            }
            if (!Equals(gdList, null))
            {
                this.gdList.RowCommand += new GridViewCommandEventHandler(this.gdList_RowCommand);
                this.gdList.RowCreated += new GridViewRowEventHandler(this.gdList_RowCreated);
                this.gdList.RowDataBound += new GridViewRowEventHandler(gdList_RowDataBound);

                this.gdList.AutoGenerateColumns = false;
            }
            else if (!Equals(rpList, null))
            {
                this.rpList.ItemCommand += new RepeaterCommandEventHandler(this.rpList_ItemCommand);
                this.rpList.ItemCreated += new RepeaterItemEventHandler(this.rpList_ItemCreated);
                this.rpList.ItemDataBound += new RepeaterItemEventHandler(this.rpList_ItemDataBound);
            }

            //if (!object.Equals(this.ucCurrentTags, null))
            //{
            //    this.ucCurrentTags.CssClass = "CustomTagButton";
            //    //this.ucCurrentTags.ItemCss = "TabCustomBT";
            //    //this.ucCurrentTags.CurrentCss = "TabCurrentBT";
            //}
            base.BasePage_Load();
        }

        #region rpList事件扩展
        virtual protected void rpList_ItemCommand(object sender, RepeaterCommandEventArgs e)
        {
            if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
            {
                if (e.CommandName == "DeleteModel")
                {
                    Delete(e.CommandArgument);
                    gdList_Bind();
                }
                else if (e.CommandName == "CopyModel")
                {
                    string id = e.CommandArgument.ToString();
                    //EbSite. BLL.NewsContent.GetCopyClass(int.Parse(id));
                    this.CopyData(id);
                    gdList_Bind();
                }
            }
        }
        virtual protected void rpList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
            {
                EbSite.Control.LinkButton lbDelete = (EbSite.Control.LinkButton)e.Item.FindControl("lbDelete");
                if (!Equals(lbDelete, null))
                {
                    if (!string.IsNullOrEmpty(this.PermissionDelID))
                    {
                        if (!IsHaveLimit(this.PermissionDelID))
                        {
                            lbDelete.Visible = false;
                        }
                        else
                        {
                            lbDelete.confirm = true;
                        }
                    }
                    else
                    {
                        lbDelete.Visible = false;
                    }
                }
                //检测是否有权限显示修改数据的按钮
                EasyuiDialog wbModify = (EasyuiDialog)e.Item.FindControl("wbModify");
                if (!object.Equals(wbModify, null))
                {
                    wbModify.LinkOnly = true;
                    if (!string.IsNullOrEmpty(this.PermissionModifyID))
                    {
                        if (!IsHaveLimit(this.PermissionModifyID))
                        {
                            wbModify.Visible = false;
                        }
                        else
                        {

                            System.Web.UI.WebControls.HiddenField hfIDKey = (System.Web.UI.WebControls.HiddenField)e.Item.FindControl("hfID");
                            if (!Equals(hfIDKey, null))
                            {
                                wbModify.Href = GetMofifyUrl(hfIDKey.Value);
                                wbModify.IsColseReLoad = true;
                            }


                        }
                    }
                    else
                    {
                        wbModify.Visible = false;
                    }
                }

                //检测是否有权限显示数据的按钮
                EasyuiDialog wbShow = (EasyuiDialog)e.Item.FindControl("wbShow");
                if (!object.Equals(wbShow, null))
                {
                    wbShow.LinkOnly = true;
                    System.Web.UI.WebControls.HiddenField hfIDKey = (System.Web.UI.WebControls.HiddenField)e.Item.FindControl("hfID");
                    if (!Equals(hfIDKey, null))
                    {
                        wbShow.Href = GetShowUrl(hfIDKey.Value);
                    }

                }
            }
        }
        virtual protected void rpList_ItemCreated(object sender, RepeaterItemEventArgs e)
        {
            if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
            {
            }
        }
        #endregion

        #region gdList事件扩展
        protected virtual void gdList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (object.Equals(e.CommandName, "DeleteModel"))
            {
                string iD = e.CommandArgument.ToString();
                this.Delete(iD);
                base.Response.Redirect(base.Request.RawUrl);
            }
            else if (object.Equals(e.CommandName, "copy"))
            {
                string iD = e.CommandArgument.ToString();
                this.CopyData(iD);
                base.Response.Redirect(base.Request.RawUrl);
            }
        }
        virtual protected void gdList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
            }
        }
        virtual protected string GetMofifyUrl(object id)
        {
            return string.Concat(GetUrl, "&", AddUrl, "&id=", id);
        }
        protected string GetShowUrl(object id)
        {
            return string.Concat(GetUrl, "&", ShowUrl, "&id=", id);
        }

        virtual protected void gdList_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //检测是否有权限显示删除数据的按钮
                GridViewRow row = e.Row;
                EbSite.Control.LinkButton lbDelete = (EbSite.Control.LinkButton)row.FindControl("lbDelete");
                if (!Equals(lbDelete, null))
                {
                    if (!string.IsNullOrEmpty(this.PermissionDelID))
                    {
                        if (!IsHaveLimit(this.PermissionDelID))
                        {
                            lbDelete.Visible = false;
                        }
                        else
                        {
                            //string sID = gdList.DataKeys[e.Row.RowIndex].Value.ToString();
                            //lbDelete.CommandArgument = sID;
                            //lbDelete.CommandName = "DeleteModel";
                            lbDelete.confirm = true;
                        }
                    }
                    else
                    {
                        lbDelete.Visible = false;
                    }
                }
                //检测是否有权限显示修改数据的按钮
                EasyuiDialog wbModify = (EasyuiDialog)row.FindControl("wbModify");
                if (!object.Equals(wbModify, null))
                {
                    wbModify.LinkOnly = true;//升级前端框架后，总是带来弹出窗口兼容的问题，所以统一去掉，有需要请在ui里添加
                    if (!string.IsNullOrEmpty(this.PermissionModifyID))
                    {
                        if (!IsHaveLimit(this.PermissionModifyID))
                        {
                            wbModify.Visible = false;
                        }
                        else
                        {
                            //string sIDName = gdList.DataKeyNames[0];
                            string sID = gdList.DataKeys[e.Row.RowIndex].Value.ToString();
                            wbModify.Href = GetMofifyUrl(sID);// string.Concat(GetUrl, "&", AddUrl, "&id=", sID);
                            wbModify.IsColseReLoad = true;

                        }
                    }
                    else
                    {
                        wbModify.Visible = false;
                    }
                    wbModify.IsFull = true;
                }

                //检测是否有权限显示数据的按钮
                EasyuiDialog wbShow = (EasyuiDialog)row.FindControl("wbShow");
                if (!object.Equals(wbShow, null))
                {
                    wbShow.LinkOnly = true;//升级前端框架后，总是带来弹出窗口兼容的问题，所以统一去掉，有需要请在ui里添加
                    string sID = gdList.DataKeys[e.Row.RowIndex].Value.ToString();
                    wbShow.Href = GetShowUrl(sID);// string.Concat(GetUrl, "&", ShowUrl, "&id=", sID);
                }
            }
        }
        #endregion

        #region 实现方法
        /// <summary>
        /// 获取所选ID集合
        /// </summary>
        override protected List<string> GetSelKeys
        {
            get
            {
                List<string> lst = new List<string>();
                if (!Equals(gdList, null))
                {


                    foreach (GridViewRow row in gdList.Rows)
                    {
                        // Access the CheckBox
                        System.Web.UI.WebControls.CheckBox cb = (System.Web.UI.WebControls.CheckBox)row.FindControl("Selector");
                        if (cb != null && cb.Checked)
                        {
                            lst.Add(gdList.DataKeys[row.RowIndex].Value.ToString());

                        }
                    }


                }
                else if (!Equals(rpList, null))
                {
                    string ids = Request["ebcheckboxname"];
                    if (!string.IsNullOrEmpty(ids))
                    {
                        string[] aids = ids.Split(',');
                        foreach (string aid in aids)
                        {
                            lst.Add(aid);
                        }
                    }
                }
                return lst;

            }
        }
        protected override bool IsListCtrNull
        {
            get
            {
                return object.Equals(this.gdList, null) && Equals(rpList, null);
            }
        }


        override protected void BindSearchData()
        {
            if (this.gdList != null)
            {
                this.gdList.DataSource = this.SearchList(out this.ListCount);
                this.gdList.DataBind();
                this.PageCtr_Bind("|qt,1");
            }
            else if (!Equals(rpList, null))
            {
                this.rpList.DataSource = this.SearchList(out this.ListCount);
                this.rpList.DataBind();
                this.PageCtr_Bind("|qt,1");

            }


        }

        override protected void gdList_Bind()
        {
            if (!Equals(gdList, null))
            {
                this.gdList.DataSource = this.LoadList(out this.ListCount);
                this.gdList.DataBind();
            }
            else if (!Equals(rpList, null))
            {
                this.rpList.DataSource = this.LoadList(out this.ListCount);
                this.rpList.DataBind();
            }



            if (string.IsNullOrEmpty(Request["pid"])) //在分类内容化下，会有分页 pid
            {
                this.PageCtr_Bind("");
            }
            else
            {
                this.PageCtr_Bind(string.Concat("|pid,", Request["pid"]));
            }

        }

        ///// <summary>
        ///// 载入数据
        ///// </summary>
        ///// <param name="iCount"></param>
        ///// <returns></returns>
        //protected abstract object LoadList(out int iCount);
        protected override void OutPutExcel()
        {
            if (!Equals(gdList))
                Utils.OutPutExcel(this.gdList);
            else if (!Equals(rpList))
                Utils.OutPutExcel(this.rpList);
        }

        protected override void OutPutWord()
        {
            if (!Equals(gdList))
                Utils.OutPutWord(this.gdList);
            else if (!Equals(rpList))
                Utils.OutPutWord(this.rpList);
        }
        #endregion

        #region 对外开放虚方法
        /// <summary>
        /// 查看数据的地址
        /// </summary>
        protected virtual string ShowUrl
        {
            get
            {
                return "";
            }
        }
        protected virtual void BindToolBar()
        {
            BindToolBar(false, false, false, false, false);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="IsCloseAdd">是否关闭添加</param>
        /// <param name="IsCloseDel">是否关闭删除</param>
        /// <param name="IsCloseOutEXL">是否关闭导出exl</param>
        /// <param name="IsCloseOutWord">是否关闭导出Word</param>
        /// <param name="IsCloseHelp">是否关闭帮助页</param>
        protected virtual void BindToolBar(bool IsCloseAdd, bool IsCloseDel, bool IsCloseOutEXL, bool IsCloseOutWord, bool IsCloseHelp)
        {
            ToolBarItem lb = new ToolBarItem();
            if (!IsCloseAdd)
            {

                if (IsHaveLimit(PermissionAddID))
                {
                    string addurl = GetAddUrl;// string.Concat(GetUrl, "&", this.AddUrl);

                    //this.ucToolBar.AddDialog(addurl, "添加", base.IISPath + "images/menus/add.gif", 800, 500, true, false);
                    lb = new ToolBarItem();
                    lb.Text = "添加";
                    lb.IsPostBack = false;
                    lb.OnClientClick = string.Format("location.href='{0}'", addurl);
                    lb.Img = string.Concat(IISPath, "images/menus/add.gif");
                    ucToolBar.Items.Add(lb);
                }

                //&box=1目前只应用在用户模块页面

            }
            if (!IsCloseDel)
            {
                if (IsHaveLimit(PermissionDelID))
                {
                    lb = new ToolBarItem();
                    lb.Text = "删除";
                    lb.OnClientClick = "return confirm('确认要删除所选项吗？');";
                    lb.Img = string.Concat(IISPath, "images/menus/Delete.gif");
                    lb.EventTag = "del";
                    ucToolBar.Items.Add(lb);
                }

            }
            if (!IsCloseHelp)
            {
                //添加帮助按钮-因为模块的帮助与主系统不同，所以这个地址要重写
                AddHelpBntToToolBar();
            }

            //if (!IsCloseOutEXL)
            //{
            //    lb = new Control.ToolBarItem();
            //    lb.Text = "导出";
            //    lb.Img = string.Concat(IISPath, "images/menus/word.png");
            //    lb.IsRight = true;
            //    lb.EventTag = "word";
            //    ucToolBar.Items.Add(lb);
            //}

            //if (!IsCloseOutWord)
            //{
            //    lb = new Control.ToolBarItem();
            //    lb.Text = "导出";
            //    lb.Img = string.Concat(IISPath, "images/menus/excel.png");
            //    lb.IsRight = true;
            //    lb.EventTag = "excel";
            //    ucToolBar.Items.Add(lb);
            //}


        }
        protected virtual void AddHelpBntToToolBar()
        {

            //添加帮助按钮
            ToolBarItem item = new ToolBarItem();
            item.Text = "帮助";
            item.Img = string.Concat(IISPath, "images/menus/help.png");
            item.IsRight = true;
            item.OnClientClick = string.Concat("window.open('", EbSite.Base.AppStartInit.OfficialsUrl, "/?key=", this.GetSubMenuID, "')");// string.Format("OpenDialog_Iframe('{0}{1}{2}','查看帮助',600,300);", AplicationGlobal.OfficialsUrl, "&id=", this.GetSubMenuID);
            item.IsPostBack = false;
            this.ucToolBar.Items.Add(item);
        }



        protected virtual void ucToolBar_ItemClick(object source, ItemClickArgs e)
        {
            string itemTag = e.ItemTag;
            if (itemTag != null)
            {
                if (!(itemTag == "del"))
                {
                    if (itemTag == "word")
                    {
                        OutPutWord();
                    }
                    else if (itemTag == "excel")
                    {
                        OutPutExcel();
                    }
                    else if (itemTag == "search")
                    {
                        this.SearchType = 0;
                        base.Session["swhere"] = "";
                        this.BindSearchData();
                    }
                    else if (itemTag == "searchadv")
                    {
                        this.SearchType = 1;
                        base.Session["swhere"] = "";
                        this.BindSearchData();
                    }
                }
                else
                {
                    if (!Equals(gdList, null))
                    {
                        //foreach (GridViewRow row in this.gdList.Rows)
                        //{
                        //    foreach (string selKey in GetSelKeys)
                        //    {
                        //        this.Delete(selKey);
                        //    }
                        //}
                        foreach (string selKey in GetSelKeys)
                        {
                            this.Delete(selKey);
                        }
                    }
                    else if (!Equals(rpList, null))
                    {
                        string sIDs = Request["ebcheckboxname"];
                        if (!string.IsNullOrEmpty(sIDs))
                        {
                            string[] ids = sIDs.Split(',');
                            foreach (string id in ids)
                            {
                                this.Delete(id);
                            }
                            //Deletes(sIDs);最好实现Deletes一次性删除
                        }

                    }


                    this.gdList_Bind();
                }
            }
        }
        #endregion

        #region 自定义方法
        public void ShowAdvSearch(string sTile)
        {
            if (string.IsNullOrEmpty(sTile))
            {
                sTile = "高级查询";
            }
            this.ucToolBar.AddBox("divSearchadv", sTile, "searchadv", base.IISPath + "images/Menus/Search-Add.gif");
        }

        public void ShowCustomSearch(string sTile)
        {
            if (string.IsNullOrEmpty(sTile))
            {
                sTile = "查询";
            }
            this.ucToolBar.AddBnt(sTile, base.IISPath + "images/menus/Search.gif", "search");
        }
        #endregion

        #region 搜索 排行 专题 数据源 统计表
        public List<EbSite.Entity.ModelClass> GetConDataTable()
        {
            //调出本站的内容模型 YHL 2014-1-22
            // WebModel wm = new WebModel();

            List<EbSite.Entity.ModelClass> ls = EbSite.BLL.WebModel.Instance.ModelClassList;//wm.ModelClassList;

            List<EbSite.Entity.ModelClass> nls = new List<EbSite.Entity.ModelClass>();
            string sv = string.Empty;
            sv = EbSite.BLL.DataSettings.Content.Instance.GetConfigCurrent.ContentTables;
            if (!string.IsNullOrEmpty(sv))
            {
                foreach (var li in ls)
                {
                    if (string.IsNullOrEmpty(li.TableName))
                    {
                        li.TableName = "newscontent"; //默认为 系统的
                    }
                    if (!string.IsNullOrEmpty(li.TableName))
                    {
                        if (sv.ToLower().Contains(li.TableName))
                        {
                            List<EbSite.Entity.ModelClass> xls = (from i in nls where i.TableName == li.TableName select i).ToList();
                            if (xls.Count == 0)
                                nls.Add(li);
                        }
                    }
                }

                return nls;
            }
            else
            {
                throw new NotImplementedException("请到 网站管理>内容管理>数据调整 中 操作 选择分表作为 搜索、排行、专题、标签 的数据源");
                return null;
            }
           
        }
        #endregion


    }


}
