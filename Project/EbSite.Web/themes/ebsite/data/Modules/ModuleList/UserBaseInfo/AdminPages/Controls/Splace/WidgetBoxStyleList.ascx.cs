using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.ControlPage;
using EbSite.Base.Modules;

namespace EbSite.Modules.UserBaseInfo.AdminPages.Controls.Splace
{
    public partial class WidgetBoxStyleList : MPUCBaseList
    {
        public override Guid ModuleMenuID
        {
            get
            {
                return new Guid("75761b94-d1c7-4f21-b411-b77f8e6f155a");
            }
        }
        public override string PageName
        {
            get
            {
                return "边框样式";
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
        public override int OrderID
        {
            get
            {
                return 5;
            }
        }
        public override string Permission
        {
            get
            {
                return "11";
            }
        }
        public override string PermissionAddID
        {
            get
            {
                return "12";
            }
        }

        /// <summary>
        /// 修改数据的权限ID
        /// </summary>
        public override string PermissionModifyID
        {
            get
            {
                return "12";
            }
        }
        /// <summary>
        /// 删除数据的权限ID
        /// </summary>
        public override string PermissionDelID
        {
            get
            {
                return "12";
            }
        }

        override protected string AddUrl
        {
            get
            {
                return "t=9";
            }
        }
        //override protected string ShowUrl
        //{
        //    get
        //    {
        //        return "?&t=1&mid=" + ModuleID;
        //    }
        //}

        override protected object LoadList(out int iCount)
        {

            return BLL.WidgetBoxStyle.Instance.GetListPages(pcPage.PageIndex, pcPage.PageSize, out iCount);
        }
        override protected SearchParameter[] GetSearchParameters
        {
            get
            {
                List<SearchParameter> lstSp = new List<SearchParameter>();

                SearchParameter spModel = new SearchParameter();
                spModel.ColumnName = "Title";
                spModel.ColumnValue = ucToolBar.GetItemVal(txtKeyWord).Trim();
                spModel.SearchWhere = EmSearchWhere.模糊匹配;
                if (string.IsNullOrEmpty(spModel.ColumnValue))
                    TipsAlert("请输入关键词!");


                lstSp.Add(spModel);

                return lstSp.ToArray();
            }
        }
        override protected object SearchList(out int iCount)
        {
            iCount = 0;
            return null;
           // return BLL.WidgetBoxStyle.Instance.GetListPages(pcPage.PageIndex, pcPage.PageSize, base.GetWhere(true), "", out iCount);
        }
        override protected void Delete(object iID)
        {
            EbSite.BLL.WidgetBoxStyle.Instance.Delete(new Guid(iID.ToString()));
        }


        #region 工具栏的初始化
        protected System.Web.UI.WebControls.TextBox txtKeyWord = new System.Web.UI.WebControls.TextBox();
        override protected void BindToolBar()
        {

            base.BindToolBar();
            ucToolBar.AddLine();

            txtKeyWord.ID = "txtKeyWord";
            ucToolBar.AddCtr(txtKeyWord);


            base.ShowCustomSearch("查询");

            //ucToolBar.AddBnt("高级", "images/MenuImg/Search-Add.gif", "", false, "OpenDialog_Save('divSearh',OnSearch)");



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
        
        protected  string GetThemeName(int sid)
        {
            string name = "";
            if(sid==0)
            {
                name = "所有皮肤";
            }
            else
            {
                EbSite.Entity.SpaceThemes md = BLL.SpaceThemes.Instance.GetEntity(Convert.ToInt16(sid));
                if(!Equals(md,null))
                {
                    name = md.ThemeName;
                }
            }
            return name;
          

        }
    }
}