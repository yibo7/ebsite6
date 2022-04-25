using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.ControlPage;
using EbSite.Base.Page;

namespace EbSite.Web.AdminHt.Controls.Admin_Modules
{
    public partial class ModuleList : UserControlListBase
    {
        public override string Permission
        {
            get
            {
                return "130";
            }
        }
        public override string PermissionAddID
        {
            get
            {
                return "131";
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
        /// 删除数据的权限ID
        /// </summary>
        public override string PermissionDelID
        {
            get
            {
                return "236";
            }
        }
        override protected string AddUrl
        {
            get
            {
                return "t=4";
            }
        }

        override protected object LoadList(out int iCount)
        {
            iCount = 0;
            return EbSite.BLL.ModulesBll.Modules.Instance.DataListBySiteID(GetSiteID);

        }

        override protected object SearchList(out int iCount)
        {
            iCount = 0;
            IEnumerable<Entity.ModuleInfo> lsit = EbSite.BLL.ModulesBll.Modules.Instance.DataListBySiteID(GetSiteID);
            string key = ucToolBar.GetItemVal(txtKeyWord).Trim();
            //List<Entity.ModuleInfo> ls = (from li in lsit where (li.ModuleName.Contains(key) ) select li).ToList();
            //return ls;
            return lsit;
        }
        override protected void Delete(object iID)
        {
            EbSite.BLL.ModulesBll.Modules.Instance.DelModel(new Guid(iID.ToString()));

        }
        #region 工具条初使化
        protected System.Web.UI.WebControls.Label lb=new Label();
        protected System.Web.UI.WebControls.TextBox txtKeyWord=new TextBox();
        protected override void BindToolBar()
        {
            base.BindToolBar(true,true,true,true,false);
            //ucToolBar.AddDialog(base.HostApi.GetModuleUrlForAdmin(new Guid("03fc411f-eed0-4afe-a5c2-b5c80d196b70"), new Guid("b1c484ee-90d7-427e-8a64-3f45d91f5515")), "下载模块", IISPath + "images/menus/menuDown.GIF");

            lb.ID = "lb";
            lb.Text = "模块名称";
            ucToolBar.AddCtr(lb);
            txtKeyWord.ID = "txtKeyWord";
            txtKeyWord.Attributes.Add("style","width:130px");
            ucToolBar.AddCtr(txtKeyWord);

            base.ShowCustomSearch("查询");


        }
        #endregion
    }
}