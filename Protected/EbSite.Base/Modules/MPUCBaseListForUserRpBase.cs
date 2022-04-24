using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using EbSite.Base.ControlPage;
using EbSite.Control;

namespace EbSite.Base.Modules
{
    public abstract class MPUCBaseListForUserRpBase : UserControlBaseListAll
    {

        
       virtual protected Guid MenuShowID
       {
           get { return Guid.Empty; }
       }
        protected string GetShowUrl(object id)
        {
            return string.Concat("?mukey=", MenuShowID,"&id=",id);
        }
        protected override string GetSplitPagePram
        {
            get
            {
                string str = "";
                if (!string.IsNullOrEmpty(Request["mukey"]))
                {
                    str = string.Format("mukey,{0}", Request["mukey"]);
                }
                return str;
            }
        }
        protected EbSite.Control.Repeater gdList;
        //protected ToolBar ucToolBar;
        /// <summary>
        /// 获取当前模块的ID
        /// </summary>
        protected Guid ModuleID
        {
            get
            {
                if (!string.IsNullOrEmpty(Request["mid"]))
                {
                    return new Guid(Request["mid"]);
                }
                else
                {
                    Tips("出错了", "找不到相应的模块数据，请确认访问路径是否正确！");
                }
                return Guid.Empty;
            }
        }
        /// <summary>
        /// 获取当前菜单的ID
        /// </summary>
        protected Guid MenuID
        {
            get
            {
                if (!string.IsNullOrEmpty(Request["muid"]))
                {
                    return new Guid(Request["muid"]);
                }
                else
                {
                    Tips("出错了", "找不到相应的菜单数据，请确认访问路径是否正确！");
                }
                return Guid.Empty;
            }
        }
        /// <summary>
        /// 获取当前模块所在的相对路径
        /// </summary>
        protected string GetCurrentModulePath
        {
            get
            {
                return EbSite.BLL.ModulesBll.Modules.Instance.GetModelPath(ModuleID);
            }
        }
        public MPUCBaseListForUserRpBase()
        {
            base.Load += new EventHandler(this.BasePage_Load);
        }

        private void BasePage_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                string sIDs = Request["ebcheckboxname"];
                if (!string.IsNullOrEmpty(sIDs))
                    Deletes(sIDs);
            }
            DeleteFromUrl();
            
            
            if (!object.Equals(this.gdList, null))
            {
                this.gdList.ItemCommand += new RepeaterCommandEventHandler(this.gdList_ItemCommand);
                this.gdList.ItemCreated += new RepeaterItemEventHandler(this.gdList_ItemCreated);
                this.gdList.ItemDataBound += new RepeaterItemEventHandler(this.gdList_ItemDataBound);
                
            }
            base.BasePage_Load();
        }

        protected virtual void ucToolBar_ItemClick(object source, ItemClickArgs e)
        {
            string itemTag = e.ItemTag;
            if (!string.IsNullOrEmpty(itemTag))
            {

                if (itemTag.Equals("search"))
                {
                    this.SearchType = 0;
                    base.Session["swhere"] = "";
                    this.BindSearchData();
                }
                else if (itemTag.Equals("searchadv"))
                {
                    this.SearchType = 1;
                    base.Session["swhere"] = "";
                    this.BindSearchData();
                }
                else if (itemTag.Equals("del"))
                {
                    if (UserID > 0)
                    {
                        string sIDs = Request["cbdataid"];//ebcheckboxname
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
                //else if (itemTag.Equals("edit"))
                //{

                //}
                //else if (itemTag.Equals("add"))
                //{
                //    Response.Redirect(AddUrl);
                //}
            }
        }

        protected virtual void BindToolBar()
        {
            BindToolBar(false);
        }
        protected virtual string AddUrlType
        {
            get { return string.Empty; }
        }
        protected virtual string ShowUrlType
        {
            get { return string.Empty; }
        }
        
        /// <summary>
        /// 非弹出框添加
        /// </summary>
        protected string AddUrl
        {
            get
            {               
                //return string.Concat(Request.RawUrl, "&t=", AddUrlType);
                string url = Request.RawUrl;
                if (url.IndexOf("?") == -1)
                {
                    url = string.Concat(url, "?mukey=", MenuAddID);
                }
                else
                {
                    url = string.Concat(url.Split('?')[0], "?mukey=", MenuAddID);
                }
                return url;

            }
        }
        /// <summary>
        /// 非弹出框修改
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        protected string ModifyUrl(string id)
        {

            return string.Concat(AddUrl, "&id=", id); 
           
        }
        protected string ShowUrl(string id)
        {

            return string.Concat(Request.RawUrl, "&t=", ShowUrlType, "&id=", id);

        }
        ///// <summary>
        ///// 弹出框修改
        ///// </summary>
        ///// <param name="id"></param>
        ///// <returns></returns>
        //protected string ModifyBoxUrl(string id)
        //{

        //    return string.Concat(AddUrlBox, "&id=", id);

        //}
        protected string DelUrl(string id)
        {
            if (Request.RawUrl.IndexOf("?") > 1)
            {
                return string.Concat(Request.RawUrl, "&delid=", id);
            }
            else
            {
                return string.Concat(Request.RawUrl, "?delid=", id);
            }
            

        }
        private void DeleteFromUrl()
        {
            string sID = Request["delid"];
            if (!string.IsNullOrEmpty(sID))
            {
                Delete(sID);
                Response.Redirect(GetFromURL);
            }

        }
        protected virtual void BindToolBar(bool IsCloseAdd)
        {
            BindToolBar(IsCloseAdd, true);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="IsCloseAdd">否则关闭添加按钮</param>
        /// <param name="IsCloseDel">是否关闭删除按钮</param>
        protected virtual void BindToolBar(bool IsCloseAdd, bool IsCloseDel)
        {

           
        }

        #region 实现方法
        /// <summary>
        /// 获取所选ID集合
        /// </summary>
        override protected List<string> GetSelKeys
        {
            get
            {
                List<string> lst = new List<string>();

                //foreach (GridViewRow row in gdList.Rows)
                //{
                //    // Access the CheckBox
                //    System.Web.UI.WebControls.CheckBox cb = (System.Web.UI.WebControls.CheckBox)row.FindControl("Selector");
                //    if (cb != null && cb.Checked)
                //    {
                //        lst.Add(gdList.DataKeys[row.RowIndex].Value.ToString());

                //    }
                //}

                return lst;
            }
        }
        protected override bool IsListCtrNull
        {
            get
            {
                return object.Equals(this.gdList, null);
            }
        }


        override protected void BindSearchData()
        {
            this.gdList.DataSource = this.SearchList(out this.ListCount);
            this.gdList.DataBind();
            this.PageCtr_Bind("|qt,1");
        }

        override protected void gdList_Bind()
        {
            this.gdList.DataSource = this.LoadList(out this.ListCount);
            this.gdList.DataBind();
            this.PageCtr_Bind("");
        }
        #endregion

        #region 对处开放方法
        /// <summary>
        /// 批量删除,ID用逗号分开
        /// </summary>
        /// <param name="IDs"></param>
        virtual protected void Deletes(string IDs)
        {
            
        }
        virtual protected void gdList_ItemCommand(object sender, RepeaterCommandEventArgs e)
        {
            if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
            {
                base.Response.Redirect(base.Request.RawUrl);
            }
        }
        virtual protected void gdList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
            {
            }
        }
        virtual protected void gdList_ItemCreated(object sender, RepeaterItemEventArgs e)
        {
            if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
            {
            }
        }
        #endregion

        /// <summary>
        /// 检测当前用户是否具有某个权限ID
        /// </summary>
        /// <param name="LimitID">权限Id</param>
        /// <returns></returns>
        override protected bool IsHaveLimit(string LimitID)
        {

            return HostApi.IsHaveLimitForUser(EbSite.Base.AppStartInit.UserID, int.Parse(LimitID), ModuleID);
        }

    }
}

