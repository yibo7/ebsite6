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
    /// 满额免费用
    /// </summary>
    public partial class QuotaFree : MPUCBaseList
    {
        public override string PageName
        {
            get
            {
                return "满额免费用";
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
                return "49";
            }
        }
        /// <summary>
        /// 添加
        /// </summary>
        public override string PermissionAddID
        {
            get
            {
                return "50";
            }
        }
        /// <summary>
        /// 修改
        /// </summary>
        public override string PermissionModifyID
        {
            get
            {
                return "51";
            }
        }
        /// <summary>
        /// 删除
        /// </summary>
        public override string PermissionDelID
        {
            get
            {
                return "52";
            }
        }

        public override int OrderID
        {
            get
            {
                return 4;
            }
        }
        /// <summary>
        /// 菜单ID
        /// </summary>
        public override Guid ModuleMenuID
        {
            get
            {
                return new Guid("806f6e11-4fab-4cf6-a9ab-37a5a04f09fc");
            }
        }
        override protected string AddUrl
        {
            get
            {
                return "t=50";
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
            return ModuleCore.BLL.Promotions.Instance.GetListPages(pcPage.PageIndex, iPageSize, string.Format("promotetype={0}", (int)ModuleCore.BLL.EPromotionsType.满额免费用), "id", out iCount);
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
            return ModuleCore.BLL.Promotions.Instance.GetListPages(pcPage.PageIndex, pcPage.PageSize, string.Format("promotetype={0} and titlename=\"{1}\"", (int)ModuleCore.BLL.EPromotionsType.满额免费用, ucToolBar.GetItemVal(txtKeyWord)), "", out iCount);
        }
        override protected void Delete(object iID)
        {
            ModuleCore.BLL.Promotions.Instance.DeleteByType(int.Parse(iID.ToString()), ModuleCore.BLL.EPromotionsType.满额免费用);
        }
        #region  工具栏的初始化
        protected System.Web.UI.WebControls.Label labPromo = new Label();
        protected System.Web.UI.WebControls.TextBox txtKeyWord = new TextBox();
        override protected void BindToolBar()
        {
            base.BindToolBar(false, true, false, false, false);
            labPromo.ID = "labpromo";
            labPromo.Text = "活动名称:";
            txtKeyWord.ID = "txtKeyWord";
            txtKeyWord.Width = 150;

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
                ModuleCore.Entity.PromotionPriceFree proFree = ModuleCore.BLL.PromotionPriceFree.Instance.GetEntity("PromotionsID=" + rowID);
                if (proFree != null)
                {
                    string freeItem = string.Format("{0}{1}{2}", proFree.FreightFree ? "订单运费，" : "", proFree.ServiceFree ? "订单选项费，" : "", proFree.PayFee ? "订单支付手续费" : "");
                    if (!string.IsNullOrEmpty(freeItem))
                    {
                        freeItem = freeItem.TrimEnd('，');
                    }
                    labInfo.Text = string.Format("满足金额:{0} 免费项目:{1}", proFree.Amount, freeItem);
                }

                #endregion 绑定促销信息

            }
        }
    }
}