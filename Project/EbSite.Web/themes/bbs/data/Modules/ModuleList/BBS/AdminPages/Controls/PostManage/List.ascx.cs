using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.ControlPage;
using EbSite.Base.Modules;

namespace EbSite.Modules.BBS.AdminPages.Controls.PostManage
{
    public partial class List : MPUCBaseList
    {
        private int ClassID
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
        public override string PageName
        {
            get
            {
                return "回帖列表";
            }
        }
        /// <summary>
        /// 是否添加到管理页面菜单之中
        /// </summary>
        public override bool IsAddToAdminMenus
        {
            get
            {
                return true;
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
                return "1";
            }
        }
        /// <summary>
        /// 修改
        /// </summary>
        public override string PermissionModifyID
        {
            get
            {
                return "1";
            }
        }
        /// <summary>
        /// 删除
        /// </summary>
        public override string PermissionDelID
        {
            get
            {
                return "1";
            }
        }

        public override int OrderID
        {
            get
            {
                return 1;
            }
        }
        /// <summary>
        /// 菜单ID
        /// </summary>
        public override Guid ModuleMenuID
        {
            get
            {
                
                return new Guid("b1afa924-63d6-478d-acef-7e395e822378");
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
            return ModuleCore.BLL.TopicReplies.Instance.GetListPages(pcPage.PageIndex, iPageSize, "DeleteFlag=0", "", out iCount, ClassID);
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


                spModel.ColumnName = "ReplyContent";
                spModel.ColumnValue = ucToolBar.GetItemVal(txtkeyword);
                spModel.IsString = true;
                spModel.SearchWhere = EmSearchWhere.模糊匹配;
                lstSp.Add(spModel);


                return lstSp.ToArray();
            }
        }
        override protected object SearchList(out int iCount)
        {
            return ModuleCore.BLL.TopicReplies.Instance.GetListPages(pcPage.PageIndex, pcPage.PageSize, base.GetWhere(true), "", out iCount, ClassID);
        }
        override protected void Delete(object iID)
        {
            ModuleCore.BLL.TopicReplies.Instance.SetPostToDel(int.Parse(iID.ToString()), ClassID);
        }

        protected string CutStr(object str)
        {
            return EbSite.Core.Strings.GetString.CutLen(str.ToString(),200);
        }

        #region  工具栏的初始化
        protected System.Web.UI.WebControls.Label LbName = new Label();
        protected System.Web.UI.WebControls.TextBox txtkeyword = new TextBox();
        override protected void BindToolBar()
        {
            base.BindToolBar(true,false,true,true,true);
            ucToolBar.AddLine();
            LbName.ID = "LbName";
            LbName.Text = "回帖内容:";
            ucToolBar.AddCtr(LbName);
            txtkeyword.ID = "keyword";
            txtkeyword.Attributes.Add("style", "width:200px");
            ucToolBar.AddCtr(txtkeyword);
            base.ShowCustomSearch("查询");
        }
        #endregion
        
    }
}