using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using EbSite.Base.ControlPage;

namespace EbSite.Web.AdminHt.Controls.Admin_Content
{
   abstract public class CommentListBase : UserControlListBase
    {
        protected global::EbSite.Control.Repeater rpRemarkClass;
       private int iDefaultClassId = 0;
       private List<Entity.RemarkClass> lst;
       public CommentListBase()
       {
            lst = BLL.RemarkClass.Instance.GetModelList();

            if (lst.Count > 0)
            {
                iDefaultClassId = lst[0].id;
            }
        }

       protected void Page_Load(object sender, EventArgs e)
        {
            rpRemarkClass.DataSource = lst;
            rpRemarkClass.DataBind();

        }
        protected string GetCurrentClass(object id)
        {
            return Core.Utils.GetCurrentClass(id, CID, "", "active");
        }
        protected int CID
        {
            get
            {
                if (!string.IsNullOrEmpty(Request["cid"]))
                {
                    return int.Parse(Request["cid"]);
                }
                else
                {
                    
                    return iDefaultClassId;
                }
            }
        }

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

            iCount = BLL.Remark.GetCount(string.Format("   RemarkClassID={0}  ", CID));


            return EbSite.BLL.Remark.GetModelList(string.Format("   RemarkClassID={0}  ", CID), 2, pcPage.PageIndex, pcPage.PageSize);
        }

       protected override string BulderSearchWhere(bool IsValueEmpytNoSearch)
       {
            string sWhere = string.Format(" RemarkClassID={0}  ", CID);

            string sKeyWord = ucToolBar.GetItemVal(txtKeyWord);
            
            string sColumns = ucToolBar.GetItemVal(drpColumns);

            if (!string.IsNullOrEmpty(sKeyWord))
            {
                if (string.IsNullOrEmpty(sColumns)) //搜索评论
                {
                    if (!string.IsNullOrEmpty(sKeyWord))
                        sWhere = string.Format("{0} AND Body like '%{1}%'", sWhere, sKeyWord);
                }
                else
                {
                    if (Core.Utils.IsNumeric(sKeyWord))
                    {
                        if (sColumns == "1") //搜索内容ID
                        {
                            sWhere = string.Format("{0} AND ContentID={1}", sWhere, sKeyWord);

                        }
                        else if (sColumns == "2") //搜索分类ID
                        {
                            sWhere = string.Format("{0} AND ClassID={1}", sWhere, sKeyWord);

                        }
                    }
                    else
                    {
                        base.TipsAlert("请输入数字");
                    }

                }

            }

           return sWhere;
       }

        override protected object SearchList(out int iCount)
        {
            int iTopType = int.Parse(ucToolBar.GetItemVal(drpTopType));
            string sWhere = GetWhere(false);

            iCount = BLL.Remark.GetCount(sWhere);
            return EbSite.BLL.Remark.GetModelList(sWhere, iTopType, pcPage.PageIndex, pcPage.PageSize);
        }
        override protected void Delete(object iID)
        {
            BLL.Remark.Delete(int.Parse(iID.ToString()));
        }

        #region 工具栏的初始化
        protected System.Web.UI.WebControls.TextBox txtKeyWord = new TextBox();
        protected DropDownList drpTopType = new DropDownList();
        protected DropDownList drpColumns = new DropDownList();
        override protected void BindToolBar()
        {

            base.BindToolBar(true, false, true, true, false);

            txtKeyWord.ID = "txtKeyWord";
            ucToolBar.AddCtr(txtKeyWord);

            ListItem dliColumns = new ListItem("搜索评论", "");
            drpColumns.Items.Add(dliColumns);
            dliColumns = new ListItem("搜索内容ID", "1");
            drpColumns.Items.Add(dliColumns);
            dliColumns = new ListItem("搜索分类ID", "2");
            drpColumns.Items.Add(dliColumns);
            //dliColumns = new ListItem("搜索评论", "3");
            //drpColumns.Items.Add(dliColumns);

            drpColumns.ID = "drpColumns";
            ucToolBar.AddCtr(drpColumns);
            ucToolBar.AddLine();

            ListItem liTopType = new ListItem("全部", "2");
            drpTopType.Items.Add(liTopType);
            liTopType = new ListItem("未审核", "0");
            drpTopType.Items.Add(liTopType);
            liTopType = new ListItem("已审核", "1");
            drpTopType.Items.Add(liTopType);

            drpTopType.ID = "drpTopType";
            //drpTopType.Attributes.Add("onchange", "OnTopChange(this)");
            ucToolBar.AddCtr(drpTopType);

            ucToolBar.AddBnt("查询", string.Concat(IISPath, "images/Menus/Search.gif"), "search");

            ucToolBar.AddBnt("批量通过", string.Concat(IISPath, "images/Menus/Image-Ok.gif"), "allow");

            ucToolBar.AddBnt("查看举报", string.Concat(IISPath, "images/Menus/Warning.gif"), "jibao");

        }
        #endregion

        #region 工具栏事件扩展

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
                        EbSite.BLL.Remark.AllowOnePost(iupsid);
                    }

                    BindSearchData();
                    break;
                case "jibao":
                    SetWhere("Information>0");
                    BindSearchData();
                    break;

            }
        }

        #endregion

        #region gdList事件扩展
        override protected void gdList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            base.gdList_RowCommand(sender, e);
            if (Equals(e.CommandName, "AuditingModel"))
            {
                int iupsid = Convert.ToInt32(e.CommandArgument);
                EbSite.BLL.Remark.AllowOnePost(iupsid);
                BindSearchData();
            }
            

        }
        #endregion 


    }
}