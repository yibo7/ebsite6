using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.ControlPage;
using EbSite.Base.Modules;

namespace EbSite.Modules.Shop.AdminPages.Controls.Promotions
{
    /// <summary>
    /// 满额打折
    /// </summary>
    public partial class FullDiscount : MPUCBaseList
    {
        public override string PageName
        {
            get
            {
                return "满额打折";
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
                return "45";
            }
        }
        /// <summary>
        /// 添加
        /// </summary>
        public override string PermissionAddID
        {
            get
            {
                return "46";
            }
        }
        /// <summary>
        /// 修改
        /// </summary>
        public override string PermissionModifyID
        {
            get
            {
                return "47";
            }
        }
        /// <summary>
        /// 删除
        /// </summary>
        public override string PermissionDelID
        {
            get
            {
                return "48";
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
                return new Guid("adeab7eb-1bff-4b76-a886-c0e3987667c8");
            }
        }
        override protected string AddUrl
        {
            get
            {
                return "t=46";
            }
        }
        override protected string ShowUrl
        {
            get
            {
                return "t=1";
            }
        }
        override protected object LoadList(out int iCount)
        {
            return ModuleCore.BLL.Promotions.Instance.GetListPages(pcPage.PageIndex, iPageSize, string.Format("promotetype={0}",(int)ModuleCore.BLL.EPromotionsType.满额打折), "id", out iCount);
        }
        /// <summary>
        /// 重写简单查询条件
        /// </summary>
        override protected SearchParameter[] GetSearchParameters
        {
            get
            {
                List<SearchParameter> lstSp = new List<SearchParameter>();
                return lstSp.ToArray();
            }
        }
        override protected object SearchList(out int iCount)
        {
            return ModuleCore.BLL.Promotions.Instance.GetListPages(pcPage.PageIndex, pcPage.PageSize, string.Format("promotetype={0} and titlename=\"{1}\"", (int)ModuleCore.BLL.EPromotionsType.满额打折,ucToolBar.GetItemVal(txtKeyWord)), "", out iCount);
        }
        override protected void Delete(object iID)
        {
            ModuleCore.BLL.Promotions.Instance.DeleteByType(int.Parse(iID.ToString()),ModuleCore.BLL.EPromotionsType.满额打折);
        }
        #region  工具栏的初始化
        protected System.Web.UI.WebControls.Label labPromo = new Label();
        protected System.Web.UI.WebControls.TextBox txtKeyWord=new TextBox();
        override protected void BindToolBar()
        {
            base.BindToolBar(false, true, false, false, false);
            labPromo.ID = "labpromo";
            labPromo.Text = "活动名称:";
            txtKeyWord.ID = "txtKeyWord";
            txtKeyWord.Width =150;

            ucToolBar.AddCtr(labPromo);
            ucToolBar.AddCtr(txtKeyWord);
            base.ShowCustomSearch("查询");
            ucToolBar.AddLine();
        }

        #endregion

        override protected void gdList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string rowID = this.gdList.DataKeys[e.Row.RowIndex]["ID"].ToString();

                #region 适用用户角色

                Label labUL = (Label)e.Row.FindControl("labUerLeval");
                List<ModuleCore.Entity.PromotionsRole> uRoleList = ModuleCore.BLL.PromotionsRole.Instance.GetListArray("PromotionsID=" + rowID);
                if (uRoleList != null && uRoleList.Count > 0)
                {
                    string labTxt = "";
                    foreach (ModuleCore.Entity.PromotionsRole mRole in uRoleList)
                    {
                        labTxt += ModuleCore.BLL.PromotionUserLevelType.GetPromotionUserLevelTypeName(mRole.UserRoleID.ToString()) + "，";
                    }
                    if (!string.IsNullOrEmpty(labTxt))
                    {
                        labTxt = labTxt.Substring(0, labTxt.Length - 1);
                    }
                    labUL.Text = labTxt;
                }

                #endregion 适用用户角色

                #region 绑定促销信息

                Label labInfo = (Label)e.Row.FindControl("labProInfo");
                ModuleCore.Entity.PromotionFullPriceCut proPriCut = ModuleCore.BLL.PromotionFullPriceCut.Instance.GetEntity("PromotionsID=" + rowID);
                if (proPriCut != null)
                {
                    labInfo.Text = string.Format("满足金额:{0},折扣类型:{1},折扣值:{2}", proPriCut.Amount, proPriCut.ValueType.ToString().Replace("0", "优惠金额").Replace("1", "折扣率"), proPriCut.DiscountValue);
                }
                #endregion 绑定促销信息

            }
        }
    }
}