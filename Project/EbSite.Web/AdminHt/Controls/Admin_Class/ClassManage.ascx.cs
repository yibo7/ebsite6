using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Web.UI.WebControls;
using EbSite.BLL;
using EbSite.Base.ControlPage;
using EbSite.BLL.GetLink;
using EbSite.Control;
//using EbSite.Core.Static.BatchCreatManager;
using EbSite.Entity;
using LinkButton = System.Web.UI.WebControls.LinkButton;

namespace EbSite.Web.AdminHt.Controls.Admin_Class
{
    public partial class ClassManage : ClassListBase
    {
        

        private int GetPClassID
        {
            get
            {
                if (!string.IsNullOrEmpty(Request["pid"]))
                {
                    return int.Parse(Request["pid"]);
                }
                return 0;
            }
        }

        protected string GetTemUrl(object cid)
        {
            int iClassId = Core.Utils.ObjectToInt(cid);
            
            if (iClassId>0)
            {
                Guid temId = BLL.ClassConfigs.Instance.GetClassTemID(iClassId);
                string sRealUrl = LinkClass.Instance.GetAspxInstance(GetSiteID).GetClassHref_OrderBy(iClassId, 1, 0);
                string sTem =   TempFactory.Instance.GetTemPathByCache(temId);

                return sRealUrl.Replace("list.aspx", sTem);

            }

            return "";
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                IsMakeing();
                txtEndID.Text = BLL.NewsClass.GetMaxId().ToString();
                //BindSearchType();
                if (gdList.AllowPaging)
                {
                    
                }
              
            }

        }

        public string MakeCoder(object id,object classname)
        {
            string sclassname = Core.Strings.GetString.NoHTML(classname.ToString());
            
            return string.Format("<a href=\"&lt;%=EbSite.Base.Host.Instance.GetClassHref({0},1)%&gt;\" >{1}</a>", id,  sclassname);
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
                    TipsAlert("请输入关键词!");

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
        //private void BindSearchType()
        //{
        //    string sFileds = Configs.SysConfigs.ConfigsControl.Instance.AdminSearchClassFileds;

        //    if (!string.IsNullOrEmpty(sFileds))
        //    {
        //        string[] Columns = sFileds.Split(',');

        //        foreach (string sC in Columns)
        //        {
        //            string[] OneItem = sC.Split('|');

        //            if (OneItem.Length == 2)
        //            {
        //                ListItem li = new ListItem(OneItem[1], OneItem[0]);

        //                drpSearchType.Items.Add(li);
        //            }
        //        }
        //    }
        //}
        private void IsMakeing()
        {
            Base.Static.BatchCreatManager.WebClass md = Base.Static.BatchCreatManager.WebClass.Instance(GetSiteID);
            if (md!=null)
            {
                if (md.IsMakeing)
                {
                    lbInfo.Text = "正在生成分类列表页,<a href='" + Base.Static.BatchCreatManager.MakeUtils.GetProgressPageLink_Show(Base.Static.BatchCreatManager.HtmlMakeType.WebClass) + "'>点击这里查看</a>";

                }
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
            else if (Equals(e.CommandName, "showcontent"))
            {
                string id = e.CommandArgument.ToString();

                Entity.ClassConfigs cmd = EbSite.BLL.ClassConfigs.Instance.GetByClassID(Convert.ToInt32(id));
                if (!Equals(cmd, null))
                {
                    Response.Redirect(string.Format("{0}&cid={1}&modelid={2}", GetMenuLink(0), id,cmd.ContentModelID));
                }
                else
                {
                    Response.Redirect(string.Format("{0}&cid={1}", GetMenuLink(0), id));
                }
               
            }
            else if (Equals(e.CommandName, "showsubclass"))
            {
                int id = int.Parse(e.CommandArgument.ToString());

                Response.Redirect(string.Concat(GetUrl, "&modelid=", ModelID, "&pid=", id));
            }
            else if (Equals(e.CommandName, "addsubclass"))
            {
                int id = int.Parse(e.CommandArgument.ToString());
                Response.Redirect(string.Concat(GetUrl, "&", AddUrl, "&pid=", id));
            }
            else if (Equals(e.CommandName, "CopyClass"))
            {
                string id = e.CommandArgument.ToString();
                BLL.NewsClass.GetCopyClass(int.Parse(id));
                //这里要刷新GridView
                base.gdList_Bind();

            }
        }


        protected void btnMake_Click(object sender, EventArgs e)
        {
            Base.Static.BatchCreatManager.WebClass wcHtml = new Base.Static.BatchCreatManager.WebClass(GetSiteID);
            
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
                int iStarID = int.Parse(txtStarID.Text);
                int iEndID = int.Parse(txtEndID.Text);

                if (iEndID >= iStarID)
                {
                    wcHtml.StarID = iStarID;
                    wcHtml.EndID = iEndID;
                }
            }

            Response.Redirect(Base.Static.BatchCreatManager.MakeUtils.GetProgressPageLink_Make(Base.Static.BatchCreatManager.HtmlMakeType.WebClass));

        }


        override protected void gdList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Entity.NewsClass drData = (Entity.NewsClass)e.Row.DataItem;
                Entity.ClassConfigs cf = BLL.ClassConfigs.Instance.GetByClassID(drData.ID);
                if (!cf.IsCanAddContent) //是否可以添加内容
                {
                    LinkButton drpCtrType = (LinkButton)e.Row.Cells[3].FindControl("lbAddcontent");
                    drpCtrType.Visible = false;
                    drpCtrType = (LinkButton)e.Row.Cells[3].FindControl("lbShowcontent");
                    drpCtrType.Visible = false;
                }
                if (!cf.IsCanAddSub) //是否可以添加子分类
                {

                    LinkButton drpCtrType = (LinkButton)e.Row.Cells[3].FindControl("lbShowsubclass");
                    drpCtrType.Visible = false;
                    LinkButton wbCtrType = (LinkButton)e.Row.Cells[3].FindControl("lbAddsubclass");
                    wbCtrType.Visible = false;
                }
                if (!string.IsNullOrEmpty(cf.SubClassAddName))
                {
                    LinkButton drpCtrType = (LinkButton)e.Row.Cells[3].FindControl("lbShowsubclass");

                    drpCtrType.Text = string.Concat("查看", cf.SubClassAddName);
                    LinkButton wbCtrType = (LinkButton)e.Row.Cells[3].FindControl("lbAddsubclass");
                    wbCtrType.Text = string.Concat("添加", cf.SubClassAddName);
                }
                else
                {
                    LinkButton drpCtrType = (LinkButton)e.Row.Cells[3].FindControl("lbShowsubclass");
                    drpCtrType.Text = string.Format("<img title=\"查看子分类\" src=\"{0}images/listsub.gif\" />", IISPath);

                    LinkButton wbCtrType = (LinkButton)e.Row.Cells[3].FindControl("lbAddsubclass");
                   wbCtrType.Text =  string.Format("<img title=\"添加子分类\" src=\"{0}images/addsub.gif\" />",IISPath);
                }
                if (!base.CurrentSite.IsClassContent)
                {
                    LinkButton lbCtrType = (LinkButton)e.Row.Cells[3].FindControl("lbShowsubclass");
                    lbCtrType.Visible = false;
                }
            }
        }


        /////////////////////////////

        
        //private bool IsLongClass = Base.Configs.SysConfigs.ConfigsControl.Instance.IsLongClass;
        override protected object LoadList(out int iCount)
        {
            if (base.CurrentSite.IsClassContent || GetPClassID > 0)
            {
                divNavClassToContent.Visible = true;
                divNavClassToContent.InnerHtml = BLL.NewsClass.GetNavAdmin(base.GetUrl+"&modelid="+ModelID,GetPClassID);
              //  return BLL.NewsClass.GetListPages_SubClass(pcPage.PageIndex,  pcPage.PageSize, GetPClassID, out iCount, base.GetSiteID);
                return BLL.NewsClass.GetModelIdListPages(pcPage.PageIndex, pcPage.PageSize, GetPClassID, out iCount,
                                                         base.GetSiteID, ModelID);
            }
            else
            {
                iCount = 0;
                return BLL.NewsClass.GetTreeModelID_pic(5000, base.GetSiteID,ModelID);

            }
        }

        


        #region 工具栏的初始化
        protected Control.TextBox txtKeyWord = new Control.TextBox();
        protected Control.DropDownList drpSearchTp = new Control.DropDownList();
        protected Control.DropDownList drpLike = new Control.DropDownList();
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


        protected override string GetSplitPagePram
        {
            get
            {
                string str = "";
                if (base.PageType > -1)
                {
                    str = string.Format("t,{0}", base.PageType);
                }
                else
                {
                    str = string.Format("msid,{0}|mpid,{1}|modelid,{2}",  this.GetSubMenuID, this.GetParentMenuID,this.ModelID);
                }
                if (this.GetSubPageType > 0)
                {
                    str = str + "|st," + this.GetSubPageType;
                }
                return str;
            }
        }

    }
}


        