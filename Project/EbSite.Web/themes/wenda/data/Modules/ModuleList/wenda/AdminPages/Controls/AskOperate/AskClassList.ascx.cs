using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.ControlPage;
using EbSite.Base.Modules;

namespace EbSite.Modules.Wenda.AdminPages.Controls.AskOperate
{
    public partial class AskClassList : MPUCBaseList
    {
        public override string PageName
        {
            get
            {
                return "提问分类";
            }
        }
        /// <summary>
        /// 是否添加到管理页面菜单之中
        /// </summary>
        public override bool IsAddToAdminMenus
        {
            get
            {
                return false;
            }
        }
        /// <summary>
        /// 权限全部
        /// </summary>
        public override string Permission
        {
            get
            {
                return "1";
            }
        }
        /// <summary>
        /// 添加
        /// </summary>
        public override string PermissionAddID
        {
            get
            {
                return "2";
            }
        }
        /// <summary>
        /// 修改
        /// </summary>
        public override string PermissionModifyID
        {
            get
            {
                return "3";
            }
        }
        /// <summary>
        /// 删除
        /// </summary>
        public override string PermissionDelID
        {
            get
            {
                return "4";
            }
        }
        /// <summary>
        /// 菜单ID
        /// </summary>
        public override Guid ModuleMenuID
        {
            get
            {
                return new Guid("F06055FB-1CDA-45D6-8DA5-E84C241B83BB");
            }
        }
        override protected string AddUrl
        {
            get
            {
                return "t=0";
            }
        }
        override protected string ShowUrl
        {
            get
            {
                return "t=1";
            }
        }
        public override int OrderID
        {
            get
            {
                return 1;
            }
        }
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
        override protected object LoadList(out int iCount)
        {
            //return ModuleCore.BLL.Answers.Instance.GetListPages(pcPage.PageIndex, iPageSize, out iCount);
            //if (!IsPostBack)
            //{
            //    if (base.CurrentSite.IsClassContent || GetPClassID > 0)
            //    {
            //        return BLL.NewsClass.GetListPages_SubClass(pcPage.PageIndex, pcPage.PageSize, GetPClassID,
            //                                                   out iCount, 2);
            //    }
            //    else
            //    {
            //        iCount = 0;
            //        return BLL.NewsClass.GetTree_pic(5000, 2);
            //    }
            //}

            //return EbSite.BLL.NewsClass.GetListPages(pcPage.PageIndex, iPageSize, " ID <> "+111, "", out iCount,
            //                                  EbSite.Base.Host.Instance.GetSiteID);

            iCount = 0;
            return BLL.NewsClass.GetTree_pic(5000, 1);
        }
        /// <summary>
        /// 重写简单查询条件
        /// </summary>
        override protected SearchParameter[] GetSearchParameters
        {
            get
            {
                List<SearchParameter> lstSp = new List<SearchParameter>();
                SearchParameter spModel = new SearchParameter();


                spModel.ColumnName = "id";
                spModel.ColumnValue = ucToolBar.GetItemVal(id);
                spModel.IsString = true;
                spModel.SearchWhere = EmSearchWhere.相等匹配;
                lstSp.Add(spModel);


                return lstSp.ToArray();
            }
        }
        override protected object SearchList(out int iCount)
        {
            //return ModuleCore.BLL.Answers.Instance.GetListPages(pcPage.PageIndex, pcPage.PageSize, base.GetWhere(true), "", out iCount);
            iCount = 0;
            return null;
        }
        override protected void Delete(object iID)
        {
            //ModuleCore.BLL.Answers.Instance.Delete(int.Parse(iID.ToString()));
            int classid = int.Parse(iID.ToString());
            EbSite.Entity.NewsClass myNewsClass = BLL.NewsClass.GetModel(classid);
            if (myNewsClass.ParentID == 0)
            {
                base.TipsAlert("根分类不能删除");
                return;
            }

            BLL.NewsClass.Delete(classid,2);
        }
        #region  工具栏的初始化
        protected System.Web.UI.WebControls.Label LbName = new Label();
        protected System.Web.UI.WebControls.TextBox id = new TextBox();
        override protected void BindToolBar()
        {
            base.BindToolBar();
            //ucToolBar.AddLine();
            //LbName.ID = "LbName";
            //LbName.Text = "分类名称";
            //ucToolBar.AddCtr(LbName);
            //id.ID = "id";
            //id.Attributes.Add("style", "width:90px");
            //ucToolBar.AddCtr(id);
            //base.ShowCustomSearch("查询");
        }
        #endregion
    }
}