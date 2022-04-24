using System;
using System.Collections.Generic;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.Modules;

namespace EbSite.Modules.UserBaseInfo.AdminPages.Controls.Splace
{
    public partial class LayoutPaneList : MPUCBaseList
    {
        public override Guid ModuleMenuID
        {
            get
            {
                return new Guid("392bef63-2ba0-44c5-bcdd-5f595954e8f1");
            }
        }
        public override string PageName
        {
            get
            {
                return "空间版式";
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
                return 1;
            }
        }
        public override string Permission
        {
            get
            {
                return "9";
            }
        }
        public override string PermissionAddID
        {
            get
            {
                return "10";
            }
        }

        /// <summary>
        /// 修改数据的权限ID
        /// </summary>
        public override string PermissionModifyID
        {
            get
            {
                return "10";
            }
        }
        /// <summary>
        /// 删除数据的权限ID
        /// </summary>
        public override string PermissionDelID
        {
            get
            {
                return "10";
            }
        }

        override protected string AddUrl
        {
            get
            {
                return "t=5";
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
            iCount = 0;
            return BLL.LayoutPane.Instance.FillList();
        }

        override protected object SearchList(out int iCount)
        {
            iCount = 0;
            return BLL.LayoutPane.Instance.FillList();
            //return BLL.LayoutPane.Instance.GetListPages(pcPage.PageIndex, pcPage.PageSize, base.GetWhere(true),  out iCount);
        }
        override protected void Delete(object iID)
        {
            

            //删除*.ascx 和缩略图
            Entity.LayoutPaneInfo md = EbSite.BLL.LayoutPane.Instance.GetEntity(new Guid(iID.ToString()));
            if (!Equals(md, null))
            {
                string filename = md.FileName;

                //要检测 有没有被占用
                List<EbSite.Entity.SpaceTabs> ls = BLL.SpaceTabs.Instance.GetListArray("layout='"+filename+"'");
                if(ls.Count>0)
                {
                    base.Tips("提示", "此版式被占用，不能删除！"); 
                }
                else
                {
                    string fAscx = HttpContext.Current.Server.MapPath(IISPath + "home/layoutpanes/" + filename + ".ascx");
                    string fJpg = HttpContext.Current.Server.MapPath(IISPath + "home/layoutpanes/" + filename + ".jpg");
                    //首先检测 文件是否存在
                    if (EbSite.Core.FSO.FObject.IsExist(fAscx, EbSite.Core.FSO.FsoMethod.File))
                    {
                        EbSite.Core.FSO.FObject.Delete(fAscx, EbSite.Core.FSO.FsoMethod.File);
                    }
                    if (EbSite.Core.FSO.FObject.IsExist(fJpg, EbSite.Core.FSO.FsoMethod.File))
                    {
                        EbSite.Core.FSO.FObject.Delete(fJpg, EbSite.Core.FSO.FsoMethod.File);
                    }
                    EbSite.BLL.LayoutPane.Instance.Delete(new Guid(iID.ToString()));
                } 
            }
           
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
    }
}