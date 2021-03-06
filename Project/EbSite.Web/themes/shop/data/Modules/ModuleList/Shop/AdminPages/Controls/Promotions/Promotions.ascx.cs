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
    public partial class Promotions: MPUCBaseList
    {
        /// <summary>
        /// 批发打折
        /// </summary>
        public override string PageName
        {
            get
            {
                return "批发打折";
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
                return "13";
            }
        }
        /// <summary>
        /// 添加
        /// </summary>
        public override string PermissionAddID
        {
            get
            {
                return "14";
            }
        }
        /// <summary>
        /// 修改
        /// </summary>
        public override string PermissionModifyID
        {
            get
            {
                return "15";
            }
        }
        /// <summary>
        /// 删除
        /// </summary>
        public override string PermissionDelID
        {
            get
            {
                return "16";
            }
        }

        public override int OrderID
        {
            get
            {
                return 3;
            }
        }
        /// <summary>
        /// 菜单ID
        /// </summary>
        public override Guid ModuleMenuID
        {
            get
            {
                return new Guid("e3d7ac92-bd84-4e54-8bbd-797d327cc74f");
            }
        }
        override protected string AddUrl
        {
            get
            {
                return "t=14";
            }
        }
        override protected string ShowUrl
        {
            get
            {
                return "t=1";
            }
        }
        public string AddUrlEx
        {
            get
            {
                return string.Format("Promotions.aspx?muid={0}&mid={1}&t=0",base.MenuID, base.ModuleID);
            }
        }
        public string GoodsListUrl
        {
            get
            {
                return string.Format("Promotions.aspx?muid={0}&mid={1}&t=34", base.MenuID, base.ModuleID);
            }
        }
        override protected object LoadList(out int iCount)
        {
            return ModuleCore.BLL.Promotions.Instance.GetListPages(pcPage.PageIndex, iPageSize, string.Format("promotetype={0}", (int)ModuleCore.BLL.EPromotionsType.批发打折), "id", out iCount);
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
            return ModuleCore.BLL.Promotions.Instance.GetListPages(pcPage.PageIndex, pcPage.PageSize, string.Format("promotetype={0} and titlename=\"{1}\"", (int)ModuleCore.BLL.EPromotionsType.批发打折,ucToolBar.GetItemVal(txtKeyWord)), "", out iCount);
        }
        override protected void Delete(object iID)
        {
            ModuleCore.BLL.Promotions.Instance.Delete(int.Parse(iID.ToString()));
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
                        labTxt += ModuleCore.BLL.PromotionUserLevelType.GetPromotionUserLevelTypeName(mRole.UserRoleID.ToString()) + ",";
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
                Label labView = (Label)e.Row.FindControl("labViewLink");

                ModuleCore.Entity.PromotionWholesale proWho = ModuleCore.BLL.PromotionWholesale.Instance.GetEntity("PromotionsID=" + rowID);
                if (proWho != null)
                {
                    labInfo.Text = string.Format("购买数量:{0} 折扣值:{1}  &nbsp;&nbsp;", proWho.Quantity, proWho.DiscountValue);
                    labView.Text = string.Format("<a href=\"javascript:void(0)\" onclick=\"OpenGoodsList({0},4)\" style=\"color:Blue; text-decoration:underline;\">查看促销商品</a>",rowID);
                }

                #endregion 绑定促销信息

            }
        }
    }
}