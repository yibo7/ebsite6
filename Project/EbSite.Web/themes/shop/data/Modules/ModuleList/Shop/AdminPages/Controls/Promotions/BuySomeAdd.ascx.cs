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
    public partial class BuySomeAdd : MPUCBaseSave
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
                return "42";
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
            proModel.Description = this.txtDescription.Text;
            proModel.PromoteType = (int)ModuleCore.BLL.EPromotionsType.买几送几;
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

            ModuleCore.Entity.PromotionFullNumGive proNumGive = new ModuleCore.Entity.PromotionFullNumGive();
            proNumGive.PromotionsID = proID;
            proNumGive.BuyQuantity = Core.Utils.StrToInt(this.txtBuyQuantity.Text, 0);
            proNumGive.GiveQuantity = Core.Utils.StrToInt(this.txtGiveQuantity.Text, 0);
            //添加
            ModuleCore.BLL.PromotionFullNumGive.Instance.Add(proNumGive);
            Response.Redirect(string.Format("Promotions.aspx?muid={0}&mid={1}&t=34&tp={2}&id={3}", "e3d7ac92-bd84-4e54-8bbd-797d327cc74f", base.ModuleID, (int)ModuleCore.BLL.EPromotionsType.买几送几, proID));

        } 
    }
}