using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.ControlPage;

namespace EbSite.Web.AdminHt.Controls.Admin_Content
{
    public partial class EvaluateList : UserControlListBase
    {
        public override string Permission
        {
            get
            {
                return "127";
            }
        }
        /// <summary>
        /// 删除数据的权限ID
        /// </summary>
        public override string PermissionDelID
        {
            get
            {
                return "222";
            }
        }
        override protected string AddUrl
        {
            get
            {
                return "";
            }
        }
        override protected object LoadList(out int iCount)
        {
            iCount = BLL.RemarkSublist.GetCount("ParentID=" + ParentID);
            return BLL.RemarkSublist.GetModelList("ParentID="+ParentID, true, pcPage.PageIndex, pcPage.PageSize);
        }
        protected override string BulderSearchWhere(bool IsValueEmpytNoSearch)
        {
            // string sWhere = string.Format(" ParentID={0}  ", ParentID);
            string sWhere = "";
             string sKeyWord = ucToolBar.GetItemVal(txtKeyWord);

            

            if (!string.IsNullOrEmpty(sKeyWord))
            {
                sWhere = string.Format(" Body like '%{0}%'", sKeyWord);

            }

            return sWhere;
        }

        override protected object SearchList(out int iCount)
        {
            int iTopType = int.Parse(ucToolBar.GetItemVal(drpTopType));
            string sWhere = GetWhere(false);

            iCount = BLL.RemarkSublist.GetCount(sWhere);
            return EbSite.BLL.RemarkSublist.GetModelList(sWhere, iTopType, pcPage.PageIndex, pcPage.PageSize);
        }
        override protected void Delete(object iID)
        {
            BLL.RemarkSublist.Delete(int.Parse(iID.ToString()));
        }

        private int ParentID
        {
            get
            {
                if (!string.IsNullOrEmpty(Request["cid"]))
                {
                    return int.Parse(Request["cid"]);
                }
                return 0;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }


        #region 工具栏的初始化
        protected System.Web.UI.WebControls.TextBox txtKeyWord = new TextBox();
        protected DropDownList drpTopType = new DropDownList(); 
        override protected void BindToolBar()
        {

            base.BindToolBar(true, false, true, true, false);

            txtKeyWord.ID = "txtKeyWord";
            ucToolBar.AddCtr(txtKeyWord);
              

            ListItem liTopType = new ListItem("全部", "2");
            drpTopType.Items.Add(liTopType);
            liTopType = new ListItem("未审核", "0");
            drpTopType.Items.Add(liTopType);
            liTopType = new ListItem("已审核", "1");
            drpTopType.Items.Add(liTopType);

            drpTopType.ID = "drpTopType";
            //drpTopType.Attributes.Add("onchange", "OnTopChange(this)");
            ucToolBar.AddCtr(drpTopType);

            ucToolBar.AddBnt("查询", string.Concat(IISPath, "images/Menus/Search.gif"), "search","这里的搜索是搜索全部回复");

            ucToolBar.AddBnt("批量通过", string.Concat(IISPath, "images/Menus/Image-Ok.gif"), "allow");

            ucToolBar.AddBnt("查看举报", string.Concat(IISPath, "images/Menus/Warning.gif"), "jibao");

        }
        #endregion

        

        protected override void ucToolBar_ItemClick(object source, Control.ItemClickArgs e)
        {
            base.ucToolBar_ItemClick(source, e);
            switch (e.ItemTag)
            {
                case "allow":
                    List<string> Ids = base.GetSelKeys;

                    foreach (string Id in Ids)
                    {
                        int iupsid = Convert.ToInt32(Id);
                        EbSite.BLL.RemarkSublist.AllowOnePost(iupsid);
                    }

                    BindSearchData();
                    break;
                case "jibao":
                    SetWhere("Information>0");
                    BindSearchData();
                    break;

            }
        }
        #region gdList事件扩展
        override protected void gdList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            base.gdList_RowCommand(sender, e);
            if (Equals(e.CommandName, "AuditingModel"))
            {
                int iupsid = Convert.ToInt32(e.CommandArgument);
                EbSite.BLL.RemarkSublist.AllowOnePost(iupsid);
                BindSearchData();
            }


        }
        #endregion 
    }
}