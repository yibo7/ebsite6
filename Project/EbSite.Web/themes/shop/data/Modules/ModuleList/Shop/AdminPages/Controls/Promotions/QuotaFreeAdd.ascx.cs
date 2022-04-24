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
    public partial class QuotaFreeAdd : MPUCBaseSave
    {
        public override string PageName
        {
            get
            {
                return "满额免费用添加";
            }
        }
        public override string Permission
        {
            get
            {
                return "50";
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

                this.chkFreeItem.DataTextField = "Text";
                this.chkFreeItem.DataValueField = "Value";
                this.chkFreeItem.DataSource = ModuleCore.BLL.PromotionFreeItemType.GetPromotionFreeItemTypes();
                this.chkFreeItem.DataBind();
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
            proModel.Description = this.txtDescription.Text;
            proModel.PromoteType = (int)ModuleCore.BLL.EPromotionsType.满额免费用;
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

            ModuleCore.Entity.PromotionPriceFree proPriFree = new ModuleCore.Entity.PromotionPriceFree();
            proPriFree.PromotionsID = proID;
            proPriFree.Amount = decimal.Parse(this.txtAmount.Text);

            //遍历免费项目
            foreach (ListItem fitem in this.chkFreeItem.Items)
            {
                if (fitem.Value.Equals("1"))
                {
                    proPriFree.FreightFree = fitem.Selected ? true : false;
                }
                else if (fitem.Value.Equals("2"))
                {
                    proPriFree.ServiceFree = fitem.Selected ? true : false;
                }
                else if (fitem.Value.Equals("3"))
                {
                    proPriFree.PayFee = fitem.Selected ? true : false;
                }
            }

            //添加
            ModuleCore.BLL.PromotionPriceFree.Instance.Add(proPriFree);
        }
    }
}