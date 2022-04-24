using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.ControlPage;
using EbSite.Base.Modules;
using EbSite.Control;
using EbSite.Modules.Wenda.ModuleCore.BLL;
using DropDownList = EbSite.Control.DropDownList;
using LinkButton = System.Web.UI.WebControls.LinkButton;
using TextBox = System.Web.UI.WebControls.TextBox;

namespace EbSite.Modules.Wenda.AdminPages.Controls.AskOperate
{
    public partial class AskList : MPUCBaseList
    {
        #region 权限

        public override string PageName
        {
            get { return "提问列表"; }
        }

        /// <summary>
        /// 是否添加到管理页面菜单之中
        /// </summary>
        public override bool IsAddToAdminMenus
        {
            get { return true; }
        }

        /// <summary>
        /// 权限全部
        /// </summary>
        public override string Permission
        {
            get { return "6"; }
        }

        /// <summary>
        /// 添加
        /// </summary>
        public override string PermissionAddID
        {
            get { return "7"; }
        }

        /// <summary>
        /// 修改
        /// </summary>
        public override string PermissionModifyID
        {
            get { return "8"; }
        }

        /// <summary>
        /// 删除
        /// </summary>
        public override string PermissionDelID
        {
            get { return "9"; }
        }

        #endregion

        /// <summary>
        /// 菜单ID
        /// </summary>
        public override Guid ModuleMenuID
        {
            get { return new Guid("b2541aee-0104-4ed8-9a53-fc41f33f5246"); }
        }

        protected override string AddUrl
        {
            get { return "t=2"; }
        }

        protected override string ShowUrl
        {
            get { return "t=3"; }
        }

        public override int OrderID
        {
            get { return 2; }
        }

        public string strSqlWhere = "";

        protected override object LoadList(out int iCount)
        {
            return Base.AppStartInit.NewsContentInstDefault.GetListNoAllow(pcPage.PageIndex, iPageSize, out iCount,
                                                         SettingInfo.Instance.GetSiteID);
        }
        static private int GetRandNum()
        {
            int min = 1;
            int max = 1000;
            Random a = new Random();
            int result = a.Next(min, max);

            return result;

        }
        protected void gdList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "CheckModel")
            {
                string id = e.CommandArgument.ToString();
               

                //2013-08-14 YHL 添加 由于 开启审核 这里通过时 要复制到 ask_class_article

                TranAddClassArticle(int.Parse(id));

                ////发表问题 审核 通过
                ////操作配置表 未解决+1
                //int inocont = ConfigControl.Instance.NoCount;
                //ConfigControl.Instance.NoCount = inocont + 1;
                //ConfigControl.SaveConfig();
            }
        }

        private void TranAddClassArticle(int id)
        {

            EbSite.Entity.NewsContent md = Base.AppStartInit.NewsContentInstDefault.GetModelDefaultFiled(id);
            md.IsAuditing = true;
            md.ID = id;
            Base.AppStartInit.NewsContentInstDefault.Update(md);

           
            ModuleCore.Entity.class_article classArticlemodel =
                                   new ModuleCore.Entity.class_article();

            Entity.NewsClass newsClassmodel =
                EbSite.BLL.NewsClass.GetModel(md.ClassID);
            classArticlemodel.ClassName = newsClassmodel.Annex7;
            classArticlemodel.NewsTitle = md.NewsTitle;
            classArticlemodel.UserID = UserID;
            classArticlemodel.AddTime = DateTime.Now;
            classArticlemodel.Classid = md.ClassID;
            classArticlemodel.Annex14 = newsClassmodel.Annex14;
            classArticlemodel.AskId = id;
            classArticlemodel.AskAddTime = DateTime.Now;
            classArticlemodel.RandNum = GetRandNum();

            ModuleCore.BLL.class_article.Instance.Add(classArticlemodel);
        }
        protected void gdList_DataBound(object sender, GridViewRowEventArgs e)
        {
            if (!EbSite.Base.Configs.SysConfigs.ConfigsControl.Instance.AuditingContent)
            {
                if (gdList.PageCount > 0)
                    e.Row.Cells[5].Attributes.Add("style", "display:none");
            }
        }

        protected override void gdList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Entity.NewsContent drData = (Entity.NewsContent) e.Row.DataItem;
                if (EbSite.Base.Configs.SysConfigs.ConfigsControl.Instance.AuditingContent)
                {
                    if (drData.IsAuditing)
                    {
                        LinkButton drpCtrType = (LinkButton) e.Row.Cells[6].FindControl("lbCheck");
                        drpCtrType.Visible = false;
                    }
                }
                else
                {
                    e.Row.Cells[5].Attributes.Add("style", "display:none");
                    LinkButton drpCtrType = (LinkButton) e.Row.Cells[6].FindControl("lbCheck");
                    drpCtrType.Visible = false;
                }
            }
        }


        protected override object SearchList(out int iCount)
        {
            //string title = ucToolBar.GetItemVal(this.NewsTitle); //标题
            //string classid = ucToolBar.GetItemVal(DrpListClass); //分类id
            //string stateid = ucToolBar.GetItemVal(DrpListState); //状态id
            //string scordid = ucToolBar.GetItemVal(DrpListScore); //是否悬赏
            //string chedkid = ucToolBar.GetItemVal(DrpListCheck);
            //strSqlWhere = StrWhere(title, classid, stateid, scordid, chedkid);
            //return BLL.NewsContent.GetListPages(pcPage.PageIndex, pcPage.PageSize, base.GetWhere(true), out iCount,
            //                                    SettingInfo.Instance.GetSiteID);
            iCount = 0;
            return null;
        }

        protected override string BulderSearchWhere(bool IsValueEmpytNoSearch)
        {
            return string.Format(strSqlWhere);
        }

        protected override string BulderSearchWhereAdv(bool IsValueEmpytNoSearch)
        {
            return string.Format(strSqlWhere);
        }

        /// <summary>
        /// 得到当站点的SiteID
        /// </summary>
        protected static int SiteDI
        {
            get { return SettingInfo.Instance.GetSiteID; }
        }

        protected override void Delete(object iID)
        {
            string sqlStr = "QID=" + iID.ToString();
            var temp = ModuleCore.BLL.Answers.Instance.GetListArray(sqlStr);
            if (temp.Count > 0)
            {
                base.ShowTipsPop("不能删除,此问题已有人回答");
                return;
            }
            Base.AppStartInit.NewsContentInstDefault.Delete(int.Parse(iID.ToString()));
            List<ModuleCore.Entity.expertAsk> exls = ModuleCore.BLL.expertAsk.Instance.GetListArray(0, " qid="+iID, "");

            if (exls.Count > 0)
            {
                foreach (var expertAsk in exls)
                {
                    ModuleCore.BLL.expertAsk.Instance.Delete(expertAsk.id);
                }
            }
        }

        protected List<Entity.NewsClass> GetClass(int pid)
        {

            List<Entity.NewsClass> lst = EbSite.BLL.NewsClass.GetListArr("annex10=1", "", SiteDI);
                //GetSubClass(pid, 0, SiteDI);   //GetListByIDs(pid.ToString(), 2);

            return lst;
        }
        #region
        //protected string StrWhere(string title, string classid, string stateid, string scordid, string checkid)
        //{
        //    string strWhere = "";
        //    if (!string.IsNullOrEmpty(title))
        //    {
        //        strWhere += " newstitle like '%" + title + "%' and";
        //    }
        //    if (!string.IsNullOrEmpty(classid))
        //    {
        //        strWhere += " classid=" + classid + " and";
        //    }
        //    if (!string.IsNullOrEmpty(stateid))
        //    {
        //        strWhere += " annex4='" + stateid + "' and";
        //    }
        //    if (!string.IsNullOrEmpty(scordid))
        //    {
        //        if (Convert.ToInt32(scordid) == 1) //有悬赏
        //        {
        //            strWhere += " annex1>0 and";
        //        }
        //        if (Convert.ToInt32(scordid) == 0)
        //        {
        //            strWhere += " annex1=0 and";
        //        }
        //    }
        //    if (!string.IsNullOrEmpty(checkid))
        //    {
        //        if (Convert.ToInt32(checkid) == 1) //已审核
        //        {
        //            strWhere += " isauditing=1 and";
        //        }
        //        if (Convert.ToInt32(checkid) == 0) //未审核
        //        {
        //            strWhere += " isauditing=0 and";
        //        }
        //    }

        //    if (!string.IsNullOrEmpty(strWhere))
        //    {

        //        strWhere = strWhere.Remove(strWhere.Length - 3, 3);
        //    }

        //    return strWhere;
        //}
        #endregion
        #region  工具栏的初始化

        protected System.Web.UI.WebControls.Label LbName = new Label();
        protected System.Web.UI.WebControls.TextBox NewsTitle = new TextBox();

        protected System.Web.UI.WebControls.Label LbClassName = new Label();
        protected EbSite.Control.DropDownList DrpListClass = new DropDownList();

        protected System.Web.UI.WebControls.Label LbStateName = new Label();
        protected EbSite.Control.DropDownList DrpListState = new DropDownList();

        protected System.Web.UI.WebControls.Label LbScoreName = new Label();
        protected EbSite.Control.DropDownList DrpListScore = new DropDownList();


        protected System.Web.UI.WebControls.Label LbCheckName = new Label();
        protected EbSite.Control.DropDownList DrpListCheck = new DropDownList();

        protected override void BindToolBar()
        {
            base.BindToolBar(true, true, true, true, true);
            ucToolBar.AddBnt("批量通过", string.Concat(IISPath, "images/Menus/Image-Ok.gif"), "allow");
        }

        protected override void ucToolBar_ItemClick(object source, Control.ItemClickArgs e)
        {
            base.ucToolBar_ItemClick(source, e);
            switch (e.ItemTag)
            {
                case "allow":
                    foreach (GridViewRow row in gdList.Rows)
                    {
                        
                        System.Web.UI.WebControls.CheckBox cb = (System.Web.UI.WebControls.CheckBox)row.FindControl("Selector");
                        if (cb != null && cb.Checked)
                        {
                            int iID = Convert.ToInt32(gdList.DataKeys[row.RowIndex].Value);
                            TranAddClassArticle(iID);
                        }
                    }
                    gdList_Bind();
                    break;
            }
        }
    //override protected void BindToolBar()
        //{
        //    base.BindToolBar(true, false, true, true, true);
        //    ucToolBar.AddLine();
        //    LbName.ID = "LbName";
        //    LbName.Text = "问题名称";
        //    ucToolBar.AddCtr(LbName);
        //    NewsTitle.ID = "NewsTitle";
        //    NewsTitle.Attributes.Add("style", "width:150px");
        //    ucToolBar.AddCtr(NewsTitle);


        //    LbClassName.ID = "LbClassName";
        //    LbClassName.Text = "分类";
        //    ucToolBar.AddCtr(LbClassName);
        //    DrpListClass.ID = "LbClassName";
        //    DrpListClass.Attributes.Add("style", "width:90px");

        //    DrpListClass.AppendDataBoundItems = true;
        //    ListItem ctrItem1 = new ListItem("全部", "");
        //    DrpListClass.Items.Add(ctrItem1);
        //    DrpListClass.DataTextField = "classname";
        //    DrpListClass.DataValueField = "id";
        //    // DrpListState.Attributes.Add("onchange", "OnCtrTpChange(this)");
        //    DrpListClass.DataSource = GetClass(0);
        //    DrpListClass.DataBind();
        //    ucToolBar.AddCtr(DrpListClass);


        //    LbStateName.ID = "LbStateName";
        //    LbStateName.Text = "状态";
        //    ucToolBar.AddCtr(LbStateName);

        //    DrpListState.ID = "DrpListState";
        //    DrpListState.Attributes.Add("style", "width:70px");
        //    DrpListState.AppendDataBoundItems = true;
        //    ListItem ctrItem = new ListItem("全部", "");
        //    DrpListState.Items.Add(ctrItem);

        //    ListItem li11 = new ListItem("未解决", "1");
        //    ListItem li12 = new ListItem("已解决", "2");
        //    ListItem li13 = new ListItem("已关闭", "3");
        //    DrpListState.Items.Add(li11);
        //    DrpListState.Items.Add(li12);
        //    DrpListState.Items.Add(li13);
        //    ucToolBar.AddCtr(DrpListState);

        //    LbScoreName.ID = "LbScoreName";
        //    LbScoreName.Text = "是否悬赏";
        //    ucToolBar.AddCtr(LbScoreName);
        //    DrpListScore.ID = "DrpListScore";
        //    DrpListScore.Attributes.Add("style", "width:55px");
        //    ListItem li = new ListItem("全部", "");
        //    ListItem li3 = new ListItem("否", "0");
        //    ListItem li2 = new ListItem("是", "1");
        //    DrpListScore.Items.Add(li);
        //    DrpListScore.Items.Add(li2);
        //    DrpListScore.Items.Add(li3);

        //    ucToolBar.AddCtr(DrpListScore);


        //     if (EbSite.Base.Configs.SysConfigs.ConfigsControl.Instance.AuditingContent)
        //    {
        //        LbCheckName.ID = "LbCheckName";
        //        LbCheckName.Text = "是否审核";
        //        ucToolBar.AddCtr(LbCheckName);
        //        DrpListCheck.ID = "DrpListCheck";
        //        DrpListCheck.Attributes.Add("style", "width:75px");
        //        ListItem li31 = new ListItem("全部", "");
        //        ListItem li32 = new ListItem("未审核", "0");
        //        ListItem li33 = new ListItem("已审核", "1");
        //        DrpListCheck.Items.Add(li31);
        //        DrpListCheck.Items.Add(li32);
        //        DrpListCheck.Items.Add(li33);

        //        ucToolBar.AddCtr(DrpListCheck);
        //    }
        //    base.ShowCustomSearch("查询");
        //}
        #endregion
    }
}