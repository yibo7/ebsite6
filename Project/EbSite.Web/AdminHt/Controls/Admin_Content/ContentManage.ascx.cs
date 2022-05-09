using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.BLL;
using EbSite.Base.ControlPage;
using EbSite.Control;
//using EbSite.Core.Static.BatchCreatManager;
using EbSite.Core.Strings;
using DropDownList = System.Web.UI.WebControls.DropDownList;
using SpecialNews = EbSite.Entity.SpecialNews;
using TextBox = System.Web.UI.WebControls.TextBox;

namespace EbSite.Web.AdminHt.Controls.Admin_Content
{
    public partial class ContentManage : UserControlListBase
    {
        #region 权限

        public override string Permission
        {
            get
            {
                return "62";
            }
        }
        public override string PermissionAddID
        {
            get
            {
                return "61";
            }
        }
        /// <summary>
        /// 修改数据的权限ID
        /// </summary>
        public override string PermissionModifyID
        {
            get
            {
                return "189";
            }
        }
        /// <summary>
        /// 删除数据的权限ID
        /// </summary>
        public override string PermissionDelID
        {
            get
            {
                return "188";
            }
        }

        #endregion

        /// <summary>
        /// 查看某个专题下的数据之id
        /// </summary>
        private int iSpecialID
        {
            get
            {
                if (!string.IsNullOrEmpty(Request.QueryString["sid"]))
                    return Convert.ToInt32(Request.QueryString["sid"]);
                else
                    return -1;
            }
        }
        /// <summary>
        /// 添加数据到某个专题下之id
        /// </summary>
        private int iAddDataToSpecialByID
        {
            get
            {
                if (!string.IsNullOrEmpty(Request.QueryString["asid"]))
                    return Convert.ToInt32(Request.QueryString["asid"]);
                else
                    return -1;
            }
        }

        /// <summary>
        /// 分类id
        /// </summary>
        private int iClassID
        {
            get
            {
                if (!string.IsNullOrEmpty(Request.QueryString["cid"]))
                    return Convert.ToInt32(Request.QueryString["cid"]);
                else
                    return -1;
            }
        }
        protected override string GetSplitPagePram
        {
            get
            {

                string str = "";
                if (iClassID > 0)
                {
                    str = string.Format("t,{0}|cid,{1}", base.PageType, iClassID);
                }
                else if (iSpecialID > 0)
                {
                    str = string.Format("t,{0}|sid,{1}", base.PageType, iSpecialID);
                }
                else if (iAddDataToSpecialByID > 0)
                {
                    str = string.Format("t,{0}|asid,{1}", base.PageType, iAddDataToSpecialByID);
                }
                else
                {
                    str = base.GetSplitPagePram;
                }
                return string.Concat(str, "|cls,", iOrderByID, "|modelid,", ModelID);
            }
        }

        protected override string GetUrl
        {
            get
            {
                if (iClassID > 0)
                { 
                    return string.Format("{0}?t={1}&cid={2}", this.GetPageName, this.PageType, this.iClassID);
                }
                else if (iSpecialID > 0)
                {
                    return string.Format("{0}?t={1}&sid={2}", this.GetPageName, this.PageType, this.iSpecialID);
                }
                else if (iAddDataToSpecialByID > 0)
                {
                    return string.Format("{0}?t={1}&asid={2}", this.GetPageName, this.PageType, this.iAddDataToSpecialByID);
                }
                else
                {
                    return base.GetUrl;
                }

            }
        }
        public int iOrderByID
        {
            get
            {
                if (!string.IsNullOrEmpty(Request.QueryString["cls"]))
                    return Convert.ToInt32(Request.QueryString["cls"]);
                else
                    return -1;//默认排序，id desc
            }

        }


        public Guid ModelID
        {
            get
            {
                if (!string.IsNullOrEmpty(Request.QueryString["modelid"]))
                    return new Guid(Request.QueryString["modelid"]);
                else
                    // return Guid.Empty; //解决默认 选上一个的问题
                    return GetConDataTable()[0].ID;
            }
        }
        /// <summary>
        /// 前台 Repeater的 模板
        /// </summary>
        public Guid ListTemID
        {
            get { return EbSite.BLL.WebModel.Instance.GeModelByID(ModelID).ListTemID; }
        }

        private NewsContentSplitTable NewsContentInst
        {
            get { return EbSite.Base.AppStartInit.GetNewsContentInst(ModelID,GetSiteID); }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {

                 
                IsMakeing();
                txtEndID.Text = NewsContentInst.GetMaxId().ToString();
                ucToolBar.SetItemVal(drpTopType, iOrderByID.ToString());

                //调出本站的内容模型 YHL 2014-1-22
              
                if (iAddDataToSpecialByID > 0 || iSpecialID>0)
                {
                    repWebModel.DataSource = GetConDataTable();
                }
                else
                {
                    WebModel wm = new WebModel(GetSiteID);
                    List<Entity.ModelClass> ls = wm.ModelClassList;
                    ls = (from i in ls orderby i.AddDate ascending select i).ToList();
                    repWebModel.DataSource = ls;
                }     
                repWebModel.DataBind();
            }

        }

        override protected string AddUrl
        {
            get
            {
                return "t=4";
            }
        }
        override protected SearchParameter[] GetSearchParameters
        {
            get
            {
                List<SearchParameter> lstSp = new List<SearchParameter>();
                int st = int.Parse(ucToolBar.GetItemVal(drpLike));


                SearchParameter spModel = new SearchParameter();
                spModel.ColumnName = ucToolBar.GetItemVal(drpSearchTp);
                spModel.ColumnValue = ucToolBar.GetItemVal(txtKeyWord).Trim();
                if (string.IsNullOrEmpty(spModel.ColumnValue))
                    TipsAlert("请输入关键词再搜索！");
                spModel.IsString = !Equals(ucToolBar.GetItemVal(drpSearchTp), "id");
                spModel.SearchLink = EmSearchLink.与连and;
                if (st == 1)
                {
                    spModel.SearchWhere = EmSearchWhere.相等匹配;
                }
                else
                {
                    spModel.SearchWhere = EmSearchWhere.模糊匹配;
                }

                lstSp.Add(spModel);

                return lstSp.ToArray();
            }
        }
        //private List<EbSite.Entity.NewsContent> dDataList()
        //{

        //}
        protected override bool On_Loading()
        {
            if (iAddDataToSpecialByID > 0)
            {
                string sv = string.Empty;
                sv = BLL.DataSettings.Content.Instance.GetConfigCurrent.ContentTables;
                if (!string.IsNullOrEmpty(sv))
                {
                    return true;
                }
                else
                {
                    base.Tips("请到 网站管理>内容管理>数据调整 中 操作 选择分表作为 搜索、排行、专题、标签 的数据源");
                    return false;
                }
            }
            return true;
        }
        override protected object LoadList(out int iCount)
        {
            //Guid ListTemID = Guid.Empty;

            //if (iClassID > 0)
            //{
            //    EbSite.Entity.NewsClass mdClass = EbSite.BLL.NewsClass.GetModel(iClassID);

            //     ListTemID = BLL.ClassConfigs.Instance.GetListTemID(iClassID);
            //}
            //else
            //{
            //   ListTemID =  ClassConfigs.Instance.GetClassConfigs(GetSiteID).ListTemID;
            //}

            if (ListTemID != Guid.Empty)
            {
                EbSite.Entity.ContentTem mdTem = EbSite.BLL.ContentTem.Instance.GetEntity(ListTemID);

                string sHeaderTem = EbSite.BLL.ContentTem.Instance.GetHeaderTemUrlByID(mdTem.id);
                string sListTem = EbSite.BLL.ContentTem.Instance.GetListemUrlByID(mdTem.id);
                rpList.HeaderTemplate = LoadTemplate(sHeaderTem);
                rpList.ItemTemplate = LoadTemplate(sListTem);
            }

            //连接中的参数  cls 用来区分排行类别,cid 分类ID，sid 专题ID
            return NewsContentInst.GetListPages(pcPage.PageIndex, pcPage.PageSize, out iCount, iSpecialID,
                                                iClassID,
                                                iOrderByID, base.GetSiteID, "", iAddDataToSpecialByID);

        }

        override protected object SearchList(out int iCount)
        {

            return NewsContentInst.GetListPages(pcPage.PageIndex, pcPage.PageSize, out iCount, iSpecialID, iClassID,
                                                iOrderByID, base.GetSiteID, base.GetWhere(true), iAddDataToSpecialByID);
            //return NewsContentInst.GetListPages(pcPage.PageIndex, pcPage.PageSize, base.GetWhere(true), out iCount, base.GetSiteID);
        }
        override protected void Delete(object iID)
        {
            NewsContentInst.Delete(int.Parse(iID.ToString()),base.GetSiteID);

        }

        protected override void CopyData(object ID)
        {
            NewsContentInst.GetCopyContent(int.Parse(ID.ToString()), GetSiteID);
        }

        #region gdList事件扩展
        override protected void gdList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            base.gdList_RowCommand(sender, e);
            if (Equals(e.CommandName, "UpGood"))
            {

                int iupsid = Convert.ToInt32(e.CommandArgument);

                NewsContentInst.UploadIsGood(iupsid);
                gdList_Bind();
            }
            else if (Equals(e.CommandName, "Modify"))
            {
                int iupsid = Convert.ToInt32(e.CommandArgument);
                Response.Redirect(string.Concat(AddUrl, "&id=", iupsid));
            }
            else if (Equals(e.CommandName, "showcontent"))
            {
                string id = e.CommandArgument.ToString();
                Response.Redirect(string.Format("{0}&cid={1}", GetMenuLink(0), id));
            }
            //else if (Equals(e.CommandName, "CopyClass"))
            //{
            //    string id = e.CommandArgument.ToString();
            //    NewsContentInst.GetCopyClass(int.Parse(id), GetSiteID);
            //    //这里要刷新GridView
            //    base.gdList_Bind();

            //}
        }
        #endregion 


        #region 专题处理

        protected void AddToSpecial()
        {
    
            List<string> selKeys = base.GetSelKeys;

            foreach (string key in selKeys)
            {
                int nID = Convert.ToInt32(key);
                Entity.SpecialNews md = new SpecialNews();



                #region yhl 2013-07-30 加到所有父类中

                List<Entity.SpecialClass> spls = EbSite.BLL.SpecialClass.SpecialClass_GetParents(iAddDataToSpecialByID,
                                                                                                 "");
                foreach (var specialClass in spls)
                {
                    md.NewsID = nID;
                    md.SpecialClassID = specialClass.id;//iAddDataToSpecialByID;
                    Entity.NewsContent mdcontent = NewsContentInst.GetModel(nID, GetSiteID);
                    md.ClassID = mdcontent.ClassID;
                    Entity.ClassConfigs cmd = BLL.ClassConfigs.Instance.GetByClassID(mdcontent.ClassID);
                    if(!Equals(cmd, null))
                    {
                        md.ModelID = cmd.ContentModelID;
                    }
                    else
                    {
                        md.ModelID = Guid.Empty;
                    }

                    if (!BLL.SpecialNews.ExistsContent(md))
                        BLL.SpecialNews.Add(md);
                }

                #endregion



            }

            gdList_Bind();

        }

        protected void RemoveToSpecial()
        {
            //foreach (GridViewRow row in gdList.Rows)
            //{
            //    System.Web.UI.WebControls.CheckBox cb = (System.Web.UI.WebControls.CheckBox)row.FindControl("Selector");

            //    if (cb != null && cb.Checked)
            //    {
            //        int nID = Convert.ToInt32(gdList.DataKeys[row.RowIndex].Value);

            //        Entity.SpecialNews md = new SpecialNews();

            //        md.NewsID = nID;

            //        md.SpecialClassID = iSpecialID;

            //        BLL.SpecialNews.Delete(md);
            //    }
            //}
            List<string> selKeys = base.GetSelKeys;

            foreach (string key in selKeys)
            {
                int nID = Convert.ToInt32(key);

                #region yhl 2013-07-30 加到所有父类中
                List<Entity.SpecialClass> spls = EbSite.BLL.SpecialClass.SpecialClass_GetParents(iSpecialID, "");
                foreach (var specialClass in spls)
                {
                    Entity.SpecialNews md = new SpecialNews();
                    md.NewsID = nID;
                    md.SpecialClassID = specialClass.id;//iSpecialID;
                    BLL.SpecialNews.Delete(md);
                }
                #endregion
            }

            Response.Redirect(Request.RawUrl);
        }

        #endregion



        #region 静态页生成处理

        private void IsMakeing()
        {
            Base.Static.BatchCreatManager.WebContent md = EbSite.Base.Static.BatchCreatManager.WebContent.Instance(GetSiteID);
            if (md != null)
            {
                if (md.IsMakeing)
                {
                    lbInfo.Text = "正在生成,<a href='" + Base.Static.BatchCreatManager.MakeUtils.GetProgressPageLink_Show(Base.Static.BatchCreatManager.HtmlMakeType.WebContent) + "'>点击这里查看</a>";
                    btnMake.Enabled = false;
                }

            }


        }

        protected void btnMake_Click(object sender, EventArgs e)
        {
            Base.Static.BatchCreatManager.WebContent wcHtml = new Base.Static.BatchCreatManager.WebContent(GetSiteID, ModelID, iClassID);
            bool IsCheck = false;
            //foreach (GridViewRow row in gdList.Rows)
            //{

            //    System.Web.UI.WebControls.CheckBox cb = (System.Web.UI.WebControls.CheckBox)row.FindControl("Selector");
            //    if (cb != null && cb.Checked)
            //    {
            //        IsCheck = true;
            //        int ContentID = Convert.ToInt32(gdList.DataKeys[row.RowIndex].Value);
            //        wcHtml.AddIDs(ContentID);
            //    }
            //}

            List<string> selKeys = base.GetSelKeys;

            foreach (string key in selKeys)
            {
                IsCheck = true;
                int ContentID = Convert.ToInt32(key);
                wcHtml.AddIDs(ContentID);
            }

            if (!IsCheck) //如果不选择,起始ID生成
            {
                int iStarID = int.Parse(txtID.Text);
                int iEndID = int.Parse(txtEndID.Text);

                if (iEndID >= iStarID)
                {
                    wcHtml.StarID = iStarID;
                    wcHtml.EndID = iEndID;
                }
            }

            Response.Redirect(Base.Static.BatchCreatManager.MakeUtils.GetProgressPageLink_Make(Base.Static.BatchCreatManager.HtmlMakeType.WebContent, ModelID));


        }

        #endregion

        #region 工具栏的初始化
        protected Control.TextBox txtKeyWord = new Control.TextBox();
        protected Control.DropDownList drpSearchTp = new Control.DropDownList();
        protected Control.DropDownList drpLike = new Control.DropDownList();
        //protected DropDownList drpContentClass = new DropDownList();
        protected Control.DropDownList drpTopType = new Control.DropDownList();
        override protected void BindToolBar()
        {

            base.BindToolBar(true, false, true, true, false);
            ucToolBar.AddBnt("推荐", string.Concat(IISPath, "images/Menus/hot.png"), "good");
            ucToolBar.AddLine();

            txtKeyWord.ID = "txtKeyWord";
            ucToolBar.AddCtr(txtKeyWord);

            //string sFileds = Base.Configs.SysConfigs.ConfigsControl.Instance.AdminSearchContentFileds;
            string sFileds = BLL.DataSettings.Content.Instance.GetConfigCurrent.AdminSearchFileds;
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

            ucToolBar.AddBnt("查询", string.Concat(IISPath, "images/Menus/Search.gif"), "search");

            ucToolBar.AddBnt("高级", string.Concat(IISPath, "images/Menus/Search-Add.gif"), "", false, "OpenDialog_Save('divSearh',OnSearch)", "高级查询");

            ucToolBar.AddLine();

            //drpContentClass.Items.Add(new ListItem("所有分类", ""));
            //drpContentClass.AppendDataBoundItems = true;
            //drpContentClass.DataTextField = "ClassName";
            //drpContentClass.DataValueField = "ID";
            //drpContentClass.DataSource = BLL.NewsClass.GetContentClassesTree(1000);
            //drpContentClass.DataBind();
            //drpContentClass.ID = "drpContentClass";
            //drpContentClass.Attributes.Add("onchange", "OnClassChange(this)");
            //drpContentClass.Width = 100;
            //ucToolBar.AddCtr(drpContentClass);

            string sItems = "已审核,|未审核,1|推荐,2|总排行,3|日排行,4|周排行,5|月排行,6|收藏最多,7|好评最多,8|评论最多,9";

            string[] aItems = sItems.Split('|');

            foreach (string item in aItems)
            {
                string[] OneIt = item.Split(',');
                ListItem liTopType = new ListItem(OneIt[0], OneIt[1]);
                drpTopType.Items.Add(liTopType);
            }
            drpTopType.ID = "drpTopType";
            drpTopType.Attributes.Add("onchange", "OnTopChange(this)");
            ucToolBar.AddCtr(drpTopType);

            if (iSpecialID > 0)
            {
                ucToolBar.AddBnt("移出专题", string.Concat(IISPath, "images/Menus/News-Cancel.gif"), "moveoutsp");

            }
            else if (iAddDataToSpecialByID > 0)
            {
                ucToolBar.AddBnt("移到专题", string.Concat(IISPath, "images/Menus/News-Add.gif"), "addtosp");
            }
            else
            {//
                ucToolBar.AddBnt("生成静态", string.Concat(IISPath, "images/Menus/ie.png"), "", false, "OpenDialog_SavePost('divMakeHtml',OnMakeHtml,true)", "生成静态页面，不选将生成全部");
                //ucToolBar.AddBnt("移动到分类", string.Concat(IISPath, "images/Menus/Image-Send.gif"), "", false, "OpenDialog_SavePost('divMoveClass',OnMoveClass,true)", "请选择要移动的内容，可以移动到其它分类中");
                ucToolBar.AddBnt("移动到分类", string.Concat(IISPath, "images/Menus/Image-Send.gif"), "movetoclass", false, "OnMoveClass()", "请选择要移动的内容，可以移动到其它分类中");
            }

        }
        #endregion

        #region 工具栏事件扩展

        protected override void ucToolBar_ItemClick(object source, Control.ItemClickArgs e)
        {
            base.ucToolBar_ItemClick(source, e);
            switch (e.ItemTag)
            {
                case "good":
                    //foreach (GridViewRow row in gdList.Rows)
                    //{
                    //    // Access the CheckBox
                    //    System.Web.UI.WebControls.CheckBox cb = (System.Web.UI.WebControls.CheckBox)row.FindControl("Selector");
                    //    if (cb != null && cb.Checked)
                    //    {

                    //        int musicID = Convert.ToInt32(gdList.DataKeys[row.RowIndex].Value);

                    //        NewsContentInst.UploadIsGood(musicID);
                    //    }
                    //}

                    List<string> selKeys = base.GetSelKeys;

                    foreach (string key in selKeys)
                    {
                        int musicID = Convert.ToInt32(key);

                        NewsContentInst.UploadIsGood(musicID);
                    }

                    gdList_Bind();
                    break;
                case "moveoutsp":
                    RemoveToSpecial();
                    break;
                case "addtosp":
                    AddToSpecial();
                    break;
            }
        }

        #endregion
    }
}