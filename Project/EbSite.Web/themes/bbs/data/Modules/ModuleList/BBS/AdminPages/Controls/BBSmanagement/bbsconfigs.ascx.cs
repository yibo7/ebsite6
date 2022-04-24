using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.ControlPage;
using EbSite.Base.Modules;
using EbSite.Modules.BBS.ModuleCore.Entity;


namespace EbSite.Modules.BBS.AdminPages.Controls.BBSmanagement
{
    public partial class bbsconfigs : MPUCBaseList
    {
        public override int OrderID
        {
            get
            {
                return 1;
            }
        }
        public override string PageName
        {
            get
            {
                return "版块管理";
            }
        }
        public override Guid ModuleMenuID
        {
            get
            {
                return new Guid("d668b1fa-1ce9-45f1-8f9e-87150dd5670e");
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
        #region 权限
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
                return "11";
            }
        }
        #endregion
        override protected string AddUrl
        {
            get
            {
                return "t=7";
            }
        }
        protected override string ShowUrl
        {
            get
            {
                return "t=8";
            }
        }
        protected Label label = new Label();
        protected TextBox txtOne = new TextBox();
        protected override void BindToolBar()
        {
            base.BindToolBar(false, false, true, true,false);

            label.ID = "lblOne";
            label.Text = " 版块名称 ";
            ucToolBar.AddCtr(label);

            txtOne.ID = "txtChannelName";
            ucToolBar.AddCtr(txtOne);
            base.ShowCustomSearch("查询");
            ucToolBar.AddDialog("t=2", "移动版块", string.Concat(IISPath, "images/Menus/arrow-resize-090.png"));     
        }

        override protected object LoadList(out int iCount)
        {
            iCount = 0;
            return ModuleCore.BLL.Channels.Instance.GetTree_pic(0);
        }

        override protected object SearchList(out int iCount)
        {
            iCount = 0;
            List<Channels> lsit = ModuleCore.BLL.Channels.Instance.GetTree_pic(0);
            List<Channels> ls = new List<Channels>();
            foreach (Channels menuse in lsit)
            {
                if (menuse.ChannelName.IndexOf(ucToolBar.GetItemVal(txtOne).Trim()) != -1)
                {
                    ls.Add(menuse);
                }
            }

            return ls;
        }

        override protected SearchParameter[] GetSearchParameters
        {
            get
            {
                List<SearchParameter> lstSp = new List<SearchParameter>();
                SearchParameter spModel = new SearchParameter();
                spModel.ColumnName = "ChannelName";
                spModel.ColumnValue = ucToolBar.GetItemVal(txtOne).Trim();
                spModel.IsString = true;
                spModel.SearchLink = EmSearchLink.不连用于最后一个;
                spModel.SearchWhere = EmSearchWhere.模糊匹配;
                lstSp.Add(spModel);
                return lstSp.ToArray();
            }
        }
        override protected void Delete(object iID)
        {
            //这时要判断版块下有没有帖子
            //若要删除 同时删除帖子和版主
           // EbSite.Modules.BBS.ModuleCore.BLL.Channels.Instance.Delete(int.Parse(iID.ToString()));
        }

       
        protected string Tp(string sTp)
        {
            string ChannelImageUrl = "";
            if (sTp.Length > 35)
            {
                ChannelImageUrl = sTp.Substring(0, 35) + "....";
            }
            else
            {
                ChannelImageUrl = sTp;
            }
            return ChannelImageUrl;
        }
    }
}