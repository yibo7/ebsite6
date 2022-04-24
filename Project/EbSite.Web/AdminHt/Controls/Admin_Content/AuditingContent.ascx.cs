using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using EbSite.BLL;
using EbSite.Base.ControlPage;

namespace EbSite.Web.AdminHt.Controls.Admin_Content
{
    public partial class AuditingContent : UserControlListBase
    {
        public override string Permission
        {
            get
            {
                return "63";
            }
        }
        /// <summary>
        /// 删除数据的权限ID
        /// </summary>
        public override string PermissionDelID
        {
            get
            {
                return "1";
            }
        }
        /// <summary>
        /// 修改数据的权限ID
        /// </summary>
        public override string PermissionModifyID
        {
            get
            {
                return "1";
            }
        }
        /// <summary>
        /// 本页面没有添加
        /// </summary>
        override protected string AddUrl
        {
            get
            {
                return "t=0";
            }
        }

        public Guid ModelID
        {
            get
            {
                if (!string.IsNullOrEmpty(Request.QueryString["modelid"]))
                    return new Guid(Request.QueryString["modelid"]);
                else
                    return Guid.Empty;
            }
        }

        private NewsContentSplitTable NewsContentInst
        {
            get { return EbSite.Base.AppStartInit.GetNewsContentInst(ModelID,GetSiteID); }
        }
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                //调出本站的内容模型 YHL 2014-1-22
                WebModel wm = new WebModel(GetSiteID);
                List<Entity.ModelClass> ls = wm.ModelClassList;
                repWebModel.DataSource = ls;
                repWebModel.DataBind();
            }

        }

        override protected object LoadList(out int iCount)
        {

            return NewsContentInst.GetListNoAllow(pcPage.PageIndex, pcPage.PageSize, out iCount, base.GetSiteID);


        }

        override protected object SearchList(out int iCount)
        {
            return NewsContentInst.GetListPages(pcPage.PageIndex, pcPage.PageSize, base.GetWhere(true), out iCount, false, base.GetSiteID);
        }
        override protected void Delete(object iID)
        {
            NewsContentInst.Delete(int.Parse(iID.ToString()),base.GetSiteID);

        }


        override protected void gdList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            base.gdList_RowCommand(sender, e);
            if (Equals(e.CommandName, "allownew"))
            {
                int iupsid = Convert.ToInt32(e.CommandArgument);

                NewsContentInst.AllowContent(iupsid, GetSiteID);
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

        #region 工具栏的初始化
        protected Control.TextBox txtKeyWord = new Control.TextBox();
        protected Control.DropDownList drpSearchTp = new Control.DropDownList();
        protected Control.DropDownList drpLike = new Control.DropDownList();
        protected Control.DropDownList drpContentClass = new Control.DropDownList();
        //protected DropDownList drpTopType = new DropDownList();
        override protected void BindToolBar()
        {

            base.BindToolBar(true, false, true, false, false);
            ucToolBar.AddBnt("批量通过", string.Concat(IISPath, "images/Menus/Image-Ok.gif"), "allow");
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

        }
        #endregion
        #region 工具栏事件扩展

        protected override void ucToolBar_ItemClick(object source, Control.ItemClickArgs e)
        {
            base.ucToolBar_ItemClick(source, e);
            switch (e.ItemTag)
            {
                case "allow":
                    foreach (GridViewRow row in gdList.Rows)
                    {
                        // Access the CheckBox
                        System.Web.UI.WebControls.CheckBox cb = (System.Web.UI.WebControls.CheckBox)row.FindControl("Selector");
                        if (cb != null && cb.Checked)
                        {

                            int iID = Convert.ToInt32(gdList.DataKeys[row.RowIndex].Value);

                            NewsContentInst.AllowContent(iID, GetSiteID);
                        }
                    }
                    gdList_Bind();
                    break;
            }
        }

        #endregion

    }
}