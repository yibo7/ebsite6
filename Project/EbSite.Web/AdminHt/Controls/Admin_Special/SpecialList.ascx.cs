using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using EbSite.Base.ControlPage;
using EbSite.Base.Static.BatchCreatManager;

//using EbSite.Core.Static.BatchCreatManager;

namespace EbSite.Web.AdminHt.Controls.Admin_Special
{
    public partial class SpecialList : UserControlListBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
              
            }
        }
        public override string Permission
        {
            get
            {
                return "68";
            }
        }
        public override string PermissionAddID
        {
            get
            {
                return "67";
            }
        }
        public override string PermissionModifyID
        {
            get
            {
                return "186";
            }
        }
        public override string PermissionDelID
        {
            get
            {
                return "191";
            }
        }
        public string MakeCoder(object id, object classname)
        {
            string sclassname = Core.Strings.GetString.NoHTML(classname.ToString());
            return string.Format("<a href=\"&lt;%=EbSite.Base.Host.Instance.GetSpecialHref({0},1)%&gt;\" >{1}</a>", id, sclassname);
        }

        override protected void gdList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            base.gdList_RowCommand(sender,e);
            if (Equals(e.CommandName, "showcontent")) 
            {
                string id = e.CommandArgument.ToString();

                Response.Redirect(GetMenuLink(0) + "&sid=" + id + "&modelid=" + GetConDataTable()[0].ID);
            }
            else if (Equals(e.CommandName, "addcontent"))
            {
                int id = int.Parse(e.CommandArgument.ToString());

                Response.Redirect(GetMenuLink(0) + "&asid=" + id + "&modelid=" + GetConDataTable()[0].ID);
            }
            else if (Equals(e.CommandName, "modify"))
            {
                int id = int.Parse(e.CommandArgument.ToString());

                Response.Redirect(GetMenuLink(5)+"&id=" + id);
            }
            else if (Equals(e.CommandName, "CopySpecial"))
            {
                string id = e.CommandArgument.ToString();
                BLL.SpecialClass.GetCopySpecial(int.Parse(id), base.GetSiteID);
                //这里要刷新GridView
                base.gdList_Bind();

            }
            
            
        }
       

        override protected string AddUrl
        {
            get
            {
                return "t=0";
            }
        }
        override protected object LoadList(out int iCount)
        {
            return BLL.SpecialClass.GetTree_pic(pcPage.PageIndex, pcPage.PageSize, out iCount, base.GetSiteID);
            
        }
        override protected SearchParameter[] GetSearchParameters
        {
            get
            {
                List<SearchParameter> lstSp = new List<SearchParameter>();
                
                SearchParameter spModel = new SearchParameter();
                spModel.ColumnName = "SpecialName";
                spModel.ColumnValue = ucToolBar.GetItemVal(txtKeyWord).Trim();

                if (string.IsNullOrEmpty(spModel.ColumnValue))
                    TipsAlert("请输入关键词!");
                spModel.IsString = true;

                lstSp.Add(spModel);

                return lstSp.ToArray();
            }
        }
        override protected object SearchList(out int iCount)
        {
            return BLL.SpecialClass.GetListPages(pcPage.PageIndex, pcPage.PageSize, base.GetWhere(true), out iCount, base.GetSiteID);
        }
        override protected void Delete(object iID)
        {
            BLL.SpecialClass.Delete(int.Parse(iID.ToString()), base.GetSiteID);

        }


        #region 工具栏的初始化
        protected Control.TextBox txtKeyWord = new Control.TextBox();
        override protected void BindToolBar()
        {

            base.BindToolBar();
            ucToolBar.AddLine();

            txtKeyWord.ID = "txtKeyWord";
            ucToolBar.AddCtr(txtKeyWord);

            ucToolBar.AddBnt("查询", string.Concat(IISPath, "images/Menus/Search.gif"), "search");

            //ucToolBar.AddBnt("高级", "images/MenuImg/Search-Add.gif", "", false, "OpenDialog_Save('divSearh',OnSearch)");

            ucToolBar.AddLine();
            ucToolBar.AddBnt("生成静态", string.Concat(IISPath, "images/Menus/ie.png"), "html", true, "return confirm('如果不选择专题将生成全部，确认要生成静态页面吗？')","生成所选专题静态页面,不选择将生成所有专题");
           

        }
        #endregion

        #region 工具栏事件扩展

        protected override void ucToolBar_ItemClick(object source, Control.ItemClickArgs e)
        {
            base.ucToolBar_ItemClick(source, e);
            EbSite.Base.Static.BatchCreatManager.Special slHtml = new Base.Static.BatchCreatManager.Special(GetSiteID);
            switch (e.ItemTag)
            {
                case "html":
                    bool IsCheckIDs = false;
                    foreach (GridViewRow row in gdList.Rows)
                    {

                        CheckBox cb = (CheckBox)row.FindControl("Selector");
                        if (cb != null && cb.Checked)
                        {
                            int nID = Convert.ToInt32(gdList.DataKeys[row.RowIndex].Value);

                            slHtml.AddIDs(nID);
                            IsCheckIDs = true;
                        }
                    }
                    if (!IsCheckIDs)
                    {
                        slHtml.StarID = 1;
                        slHtml.EndID = EbSite.BLL.SpecialClass.GetMaxId();
                    }
                  
                    Response.Redirect(MakeUtils.GetProgressPageLink_Make(HtmlMakeType.Special));
                    break;
            }
        }

        #endregion


    }
}