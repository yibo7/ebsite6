using System;
using System.Threading;
using System.Web;
using System.Web.UI.WebControls;
using EbSite.Base.ControlPage;
//using EbSite.Core.Static.BatchCreatManager;

namespace EbSite.Web.AdminHt.Controls.Admin_Content
{
    public partial class LabelManage : UserControlListBase
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                IsMakeing();
                txtLab.Text = string.Format("标签主要分为标签列表与标签结果页，<a target=\"_blank\" href=\"{0}\">点这里可以查看标签列表页</a> ",EbSite.Base.Host.Instance.TagsList(1));
            }
        }
        public override string Permission
        {
            get
            {
                return "64";
            }
        }
        /// <summary>
        /// 删除数据的权限ID
        /// </summary>
        public override string PermissionDelID
        {
            get
            {
                return "190";
            }
        }
        public override string PermissionModifyID
        {
            get
            {
                return "190";
            }
        }
        override protected string AddUrl
        {
            get
            {
                return "t=3";
            }
        }
        override protected object LoadList(out int iCount)
        {
            string siTop = ucToolBar.GetItemVal(drpTopType);
            int iTop = 1;
            if (!string.IsNullOrEmpty(siTop)) iTop = int.Parse(siTop);
            return BLL.TagKey.GetListPages(pcPage.PageIndex, pcPage.PageSize, iTop, out iCount, base.GetSiteID);


        }
        override protected object SearchList(out int iCount)
        {
            throw new NotImplementedException();
        }
        override protected void Delete(object iID)
        {
            BLL.TagKey.Delete(int.Parse(iID.ToString()));

        }


        #region 工具栏的初始化
        protected Control.TextBox txtKeyStart = new Control.TextBox();
        protected Control.TextBox txtKeyEnd = new Control.TextBox();
        protected Control.DropDownList drpTopType = new Control.DropDownList();
        override protected void BindToolBar()
        {
            base.BindToolBar(true, false, true, false, false);
            string sjsAll = "return confirm('确认要生成所有标签列表吗？');";
            if (isTagValue)
                sjsAll = "alert('正在生成所有标签列表，请生成完毕后再试');reutrn false;";

            ucToolBar.AddBnt("生成所有标签列表", string.Concat(IISPath, "images/Menus/Image-Ok.gif"), "Makeall", true, sjsAll, "生成所有的标签列表页面，比较占用资源，请小心");
            ucToolBar.AddLine();
            Label lb = new Label();
            lb.ID = "lb";
            lb.Text = "开始ID：";
            ucToolBar.AddCtr(lb);

            txtKeyStart.ID = "txtKeyStart";
            txtKeyStart.Width = 50;
            txtKeyStart.Text = "0";
            ucToolBar.AddCtr(txtKeyStart);

             lb = new Label();
            lb.Text = "结束ID：";
            lb.ID = "lb";
            ucToolBar.AddCtr(lb);

            txtKeyEnd.ID = "txtKeyEnd";
            txtKeyEnd.Width = 50;
            txtKeyEnd.Text = EbSite.BLL.TagKey.GetMaxId().ToString();
            ucToolBar.AddCtr(txtKeyEnd);

            string sjsSearch = "return confirm('确认要生成标签搜索页吗？');";
            if (isMakeTaglist)
                sjsSearch = "alert('正在生成所有标签列表，请生成完毕后再试');reutrn false;";

            ucToolBar.AddBnt("生成标签搜索页", string.Concat(IISPath, "images/Menus/Search.gif"), "searchlb", true, sjsSearch, "生成所有标签搜索页，比较占用资源，请小心使用");
            ucToolBar.AddLine();
            lb = new Label();
            lb.ID = "lb";
            lb.Text = "排序方式：";
            ucToolBar.AddCtr(lb);
            drpTopType.ID = "drpTopType";
            drpTopType.Items.Add(new ListItem("最新标签","1"));
            drpTopType.Items.Add(new ListItem("热门标签", "2"));
            ucToolBar.AddCtr(drpTopType);
            //ucToolBar.AddDialog(string.Concat(GetUrl,"&t=2"), "设置随机颜色",string.Concat(IISPath, "images/Menus/20110509090845817_easyicon_cn_16.png"));
            //ucToolBar.AddBox("divMerge", "合并标签", "OnMerge", string.Concat(IISPath, "images/Menus/20110509091407741_easyicon_cn_16.png"));
            ucToolBar.AddBnt("合并标签", string.Concat(IISPath, "images/Menus/20110509091407741_easyicon_cn_16.png"), "", false, "OpenDialog_SavePost('divMerge',OnMerge,true)", "合并两个标签下的内容");
        }
        #endregion
        protected void btnMerge_Click(object sender, EventArgs e)
        {
            int iID = Core.Utils.StrToInt(txtID.Text.Trim(), 0);
            int iTarget = Core.Utils.StrToInt(txtTargetID.Text.Trim(), 0);

            if (iID > 0 && iTarget>0)
                EbSite.BLL.TagKey.MergeLable(iID, iTarget);

        }

        
        #region 工具栏事件扩展

        protected override void ucToolBar_ItemClick(object source, Control.ItemClickArgs e)
        {
            //Base.Static.BatchCreatManager.TagSearchList tslHtml = new Base.Static.BatchCreatManager.TagSearchList(GetSiteID);
            base.ucToolBar_ItemClick(source, e);
            switch (e.ItemTag)
            {
                case "Makeall":
                    Base.Static.BatchCreatManager.TagList tslTagList = new Base.Static.BatchCreatManager.TagList(GetSiteID);
                    //tslTagList.Star();
                    Response.Redirect(Base.Static.BatchCreatManager.MakeUtils.GetProgressPageLink_Make(Base.Static.BatchCreatManager.HtmlMakeType.TagList));
                        
                    break;
                case "searchlb":
                        
                        Base.Static.BatchCreatManager.TagSearchList wcHtml = new Base.Static.BatchCreatManager.TagSearchList(GetSiteID);
                     
                        //if (!string.IsNullOrEmpty(sS.Trim()) && !string.IsNullOrEmpty(sE.Trim()))
                        //{
                        //    StarID = int.Parse(sS);
                        //    EndID = int.Parse(sE);
                        //}
                        //if (EndID >= StarID) //批量生成
                        //{
                        //    tslHtml.StarID = StarID;
                        //    tslHtml.EndID = EndID;
                        //    //tslHtml.Star();
                        //    Response.Redirect(Base.Static.BatchCreatManager.MakeUtils.GetProgressPageLink_Make(Base.Static.BatchCreatManager.HtmlMakeType.TagSearchList));
                        //}


                         bool IsCheck = false;
                        foreach (GridViewRow row in gdList.Rows)
                        {
                            // Access the CheckBox
                            System.Web.UI.WebControls.CheckBox cb = (System.Web.UI.WebControls.CheckBox)row.FindControl("Selector");
                            if (cb != null && cb.Checked)
                            {
                                IsCheck = true;
                                int ClassID = Convert.ToInt32(gdList.DataKeys[row.RowIndex].Value);
                                wcHtml.AddIDs(ClassID);
                            }
                        }
                        if (!IsCheck) //如果不选择,起始ID生成
                        {
                            int StarID = 0;
                            int EndID = 0;
                            string sS = ucToolBar.GetItemVal(txtKeyStart);
                            string sE = ucToolBar.GetItemVal(txtKeyEnd);

                            if (!string.IsNullOrEmpty(sS.Trim()) && !string.IsNullOrEmpty(sE.Trim()))
                            {
                                StarID = int.Parse(sS);
                                EndID = int.Parse(sE);
                            }
                            if (EndID >= StarID)
                            {
                                wcHtml.StarID = StarID;
                                wcHtml.EndID = EndID;
                            }
                        }
                        Response.Redirect(Base.Static.BatchCreatManager.MakeUtils.GetProgressPageLink_Make(Base.Static.BatchCreatManager.HtmlMakeType.TagSearchList));
                    break;
            }
        }

        #endregion

        private bool isMakeTaglist = false;
        private bool isTagValue = false;
        private void IsMakeing()
        {
            string url = "";
            Base.Static.BatchCreatManager.TagList mdTagList = Base.Static.BatchCreatManager.TagList.Instance(GetSiteID);
            if (mdTagList!=null)
            {
                if (mdTagList.IsMakeing)
                {
                    url = "正在生成,<a href='" + Base.Static.BatchCreatManager.MakeUtils.GetProgressPageLink_Show(Base.Static.BatchCreatManager.HtmlMakeType.TagList) + "'>点击这里查看</a>";

                    isMakeTaglist = true;
                }

            }


            Base.Static.BatchCreatManager.TagSearchList mdTagSearchList = Base.Static.BatchCreatManager.TagSearchList.Instance(GetSiteID);
           if (mdTagSearchList!=null)
           {
               if (mdTagSearchList.IsMakeing)
               {
                   url += "正在生成标签搜索页,<a href='" + Base.Static.BatchCreatManager.MakeUtils.GetProgressPageLink_Show(Base.Static.BatchCreatManager.HtmlMakeType.TagSearchList) + "'>点击这里查看</a>";
                   isTagValue = true;
               }
           }
          

            lbInfo.Text = url;


        }


        #region 旧
        //private int PageIndex
        //{
        //    get
        //    {
        //        if (!string.IsNullOrEmpty(Request.QueryString["p"]))
        //            return Convert.ToInt32(Request.QueryString["p"]);
        //        else
        //            return 1;
        //    }
        //}
        //private int iSearchCount
        //{
        //    get
        //    {
        //        return BLL.TagKey.GetCount();
        //    }

        //}
        //private int iPageSize
        //{
        //    get
        //    {
        //        return 20;
        //    }

        //}
        //private int iTop
        //{
        //    get
        //    {
        //        if(!string.IsNullOrEmpty(Request["odb"]))
        //        {
        //            return int.Parse(Request["odb"]);
        //        }
        //        return 1;
        //    }
        //}
        //protected void Page_Load(object sender, EventArgs e)
        //{
        //    if (!IsPostBack)
        //    {
                
        //        bindgrigv();
        //        IsMakeing();

        //    }
        //}

        //private void bindgrigv()
        //{
        //    gvTag.DataSource = BLL.TagKey.GetListPages(PageIndex, iPageSize, iTop);
        //    gvTag.DataBind();
        //    txtEndID.Text = BLL.TagKey.GetMaxId().ToString();
        //    intpages();
        //}
        //private void intpages()
        //{
        //    pgCtr.AllCount = iSearchCount;
        //    pgCtr.PageSize = iPageSize;
        //    pgCtr.CurrentClass = "Pages_Current";
        //    pgCtr.ParentClass = "PagesClass";
        //}

        //protected void gvClass_RowCommand(object sender, GridViewCommandEventArgs e)
        //{
        //    if (Equals(e.CommandName, "deletetags"))
        //    {

        //        int iupsid = Convert.ToInt32(e.CommandArgument);

        //        BLL.TagKey.Delete(iupsid);
        //        bindgrigv();
        //    }
        //}

        
        //private void IsMakeing()
        //{
        //    string url = "";
        //    if (Core.Static.BatchCreatManager.TagList.Instance.IsMakeing)
        //    {
        //        url = "正在生成,<a href='" + MakeUtils.GetProgressPageLink_Show(HtmlMakeType.TagList) + "'>点击这里查看</a>";
                
        //        btnMake_Taglist.Enabled = false;
        //    }
        //    else if (Core.Static.BatchCreatManager.TagSearchList.Instance.IsMakeing)
        //    {
        //        url += "正在生成标签搜索页,<a href='" + MakeUtils.GetProgressPageLink_Show(HtmlMakeType.TagSearchList) + "'>点击这里查看</a>";
        //        btnMake_TagValue.Enabled = false;
        //    }
        //    lbInfo.Text = url;
            

        //}
        //protected void btnMake_Taglist_Click(object sender, EventArgs e)
        //{
        //    //Core.Static.BatchCreatManager.TagList.Instance.Star();
        //    Response.Redirect(MakeUtils.GetProgressPageLink_Make(HtmlMakeType.TagList));
        //}
        //protected void btnMake_TagValue_Click(object sender, EventArgs e)
        //{
        //    int StarID = 0;
        //    int EndID = 0;
        //    if (!string.IsNullOrEmpty(txtID.Text.Trim()) && !string.IsNullOrEmpty(txtEndID.Text.Trim()))
        //    {
        //        StarID = int.Parse(txtID.Text.Trim());
        //        EndID = int.Parse(txtEndID.Text.Trim());
        //    }
        //    if (EndID >= StarID) //批量生成
        //    {
        //        Core.Static.BatchCreatManager.TagSearchList.Instance.StarID = StarID;
        //        Core.Static.BatchCreatManager.TagSearchList.Instance.EndID = EndID;
        //        Response.Redirect(MakeUtils.GetProgressPageLink_Make(HtmlMakeType.TagSearchList));
        //    }


        //}

        #endregion

    }
}