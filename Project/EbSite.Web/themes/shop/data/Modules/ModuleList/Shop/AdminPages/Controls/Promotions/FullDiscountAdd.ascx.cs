using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.BLL;
using EbSite.Base.Modules;

namespace EbSite.Modules.Shop.AdminPages.Controls.Promotions
{
    public partial class FullDiscountAdd : MPUCBaseSave
    {
        public override string PageName
        {
            get
            {
                return "满额打折添加";
            }
        }
        public override string Permission
        {
            get
            {
                return "46";
            }
        }
        override protected string KeyColumnName
        {
            get
            {
                return "ID";
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.chkUserLevel.DataTextField = "Text";
                this.chkUserLevel.DataValueField = "Value";
                this.chkUserLevel.DataSource = ModuleCore.BLL.PromotionUserLevelType.GetPromotionUserLevelTypes();
                this.chkUserLevel.DataBind();
            }
        }
       
       
        override protected void InitModifyCtr()
        {
            ModuleCore.BLL.PromotionFullPriceCut.Instance.InitModifyCtr(SID, phCtrList);
        }
        override protected void SaveModel()
        {
            //促销活动主表
            ModuleCore.Entity.Promotions proModel = new ModuleCore.Entity.Promotions();
            proModel.TitleName = this.TitleName.Text;
            proModel.Description = this.txtDiscountValue.Text;
            proModel.PromoteType = (int)ModuleCore.BLL.EPromotionsType.满额打折;
            int proID = ModuleCore.BLL.Promotions.Instance.Add(proModel);

            #region 处理适用角色

            ModuleCore.Entity.PromotionsRole proRoleModel = new ModuleCore.Entity.PromotionsRole();
            //遍历用户等级
            foreach (ListItem litem in this.chkUserLevel.Items)
            {
                if (litem.Selected)
                {
                    proRoleModel = new ModuleCore.Entity.PromotionsRole();
                    proRoleModel.PromotionsID = proID;
                    proRoleModel.UserRoleID = Core.Utils.StrToInt(litem.Value, 0);
                    //添加
                    ModuleCore.BLL.PromotionsRole.Instance.Add(proRoleModel);
                }
            }

            #endregion 处理适用角色

            ModuleCore.Entity.PromotionFullPriceCut proPriCut = new ModuleCore.Entity.PromotionFullPriceCut();
            proPriCut.PromotionsID = proID;
            proPriCut.Amount = decimal.Parse(this.txtAmount.Text);
            proPriCut.ValueType = Core.Utils.StrToInt(this.rdoSaleType.SelectedItem.Value, 0);
            if (this.rdoSaleType.SelectedItem.Value.Equals("1"))
            {
                proPriCut.DiscountValue = Core.Utils.StrToInt(this.txtZKL.Text, 0);
            }
            else
            {
                proPriCut.DiscountValue = Core.Utils.StrToInt(this.txtDiscountValue.Text, 0);
            }
            //添加
            ModuleCore.BLL.PromotionFullPriceCut.Instance.Add(proPriCut);
        }
    }
}