using System;
namespace EbSite.Modules.Shop
{
    public partial class Setting : Base.Modules.Settings
    {
       
        public override string PageName
        {
            get
            {
                return "模块设置";
            }
        }
        public override void Save()
        {
            //SettingInfo md = new SettingInfo();

            //Configs.Instance.Model.IsSaveShopCar = SettingInfo.Instance.IsSaveShopCar;


            //    Configs.Instance.Save();

            Configs.Instance.Model.IsSaveShopCar=bool.Parse(this.IsSaveShopCar.SelectedValue); //是否保存购物车

            Configs.Instance.Model.IsOpenInvoice = bool.Parse(this.IsOpenInvoice.SelectedValue); //能否开发票

            Configs.Instance.Model.OrderTaxPoint = int.Parse(this.OrderTaxPoint.Text); //订单税点

            Configs.Instance.Model.ScorePayPoint = int.Parse(this.ScorePayPoint.Text);//积分支付比例

            Configs.Instance.Model.IsNoGood = bool.Parse(this.IsNoGood.SelectedValue);//是否启用缺货处理

            Configs.Instance.Model.UserGroup = int.Parse(this.UserGroup.SelectedValue);//添加缺货登记的对象  0：所有用户 1.注册用户

            Configs.Instance.Model.IsOkEmail = bool.Parse(this.IsOkEmail.SelectedValue);//用户下单完成时是否发邮件

            Configs.Instance.Model.IsSendEmail = bool.Parse(this.IsSendEmail.SelectedValue);//发货时 是否发邮件

            Configs.Instance.Model.IsCancelEmail = bool.Parse(this.IsCancelEmail.SelectedValue);//取消订单时 是否发邮件

            Configs.Instance.Model.LessMoney = decimal.Parse(this.LessMoney.Text);//最小购物金额

            Configs.Instance.Model.AutoCloseOrderDays = int.Parse(this.AutoCloseOrderDays.Text);//过期几天自动关闭订单

            Configs.Instance.Model.AutoFinishOrderDays = int.Parse(this.AutoFinishOrderDays.Text);//发货几天自动完成订单

            Configs.Instance.Model.IsPrintGift = bool.Parse(this.IsPrintGift.SelectedValue);//是否打印赠品

            Configs.Instance.Model.DownPriceMsgTemplate = this.txtDownNoticeMsgTemp.Text;
            Configs.Instance.Model.DownPriceEmailTemplate = this.txtDownNoticeEmailTemp.Text;
            Configs.Instance.Model.RequestGroupMsgTemplate = this.txtRequestGroupMsgTemp.Text;
            Configs.Instance.Model.RequestGroupEmailTemplate = this.txtRequestGroupEmailTemp.Text;

            Configs.Instance.Save();

            //SettingInfo.Instance.GetSysConfig.SaveConfig(md);
            //base.SaveConfig(md);


        }
        public override void LoadConfigs()
        {
            //cbIsAllow.Checked = SettingInfo.Instance.IsAllowUserAdd;
            this.IsSaveShopCar.SelectedValue = Configs.Instance.Model.IsSaveShopCar.ToString();

            this.IsOpenInvoice.SelectedValue = Configs.Instance.Model.IsOpenInvoice.ToString();

            this.OrderTaxPoint.Text = Configs.Instance.Model.OrderTaxPoint.ToString();

            this.ScorePayPoint.Text = Configs.Instance.Model.ScorePayPoint.ToString();

            this.IsNoGood.SelectedValue = Configs.Instance.Model.IsNoGood.ToString();

            this.UserGroup.SelectedValue = Configs.Instance.Model.UserGroup.ToString();

            this.IsOkEmail.SelectedValue = Configs.Instance.Model.IsOkEmail.ToString();//用户下单完成时是否发邮件

            this.IsSendEmail.SelectedValue = Configs.Instance.Model.IsSendEmail.ToString();//发货时 是否发邮件

            this.IsCancelEmail.SelectedValue = Configs.Instance.Model.IsCancelEmail.ToString();//取消订单时 是否发邮件

            this.LessMoney.Text = Configs.Instance.Model.LessMoney.ToString();//最小购物金额

            this.AutoCloseOrderDays.Text = Configs.Instance.Model.AutoCloseOrderDays.ToString();//过期几天自动关闭订单

            this.AutoFinishOrderDays.Text = Configs.Instance.Model.AutoFinishOrderDays.ToString();//发货几天自动完成订单

            this.IsPrintGift.SelectedValue = Configs.Instance.Model.IsPrintGift.ToString();//是否打印赠品

            this.txtDownNoticeMsgTemp.Text = Configs.Instance.Model.DownPriceMsgTemplate;
            this.txtDownNoticeEmailTemp.Text = Configs.Instance.Model.DownPriceEmailTemplate;
            this.txtRequestGroupMsgTemp.Text = Configs.Instance.Model.RequestGroupMsgTemplate;
            this.txtRequestGroupEmailTemp.Text = Configs.Instance.Model.RequestGroupEmailTemplate;

        }
        public override void CustomTags()
        {
            base.AddTags("购物流程设置", "tg1");
            base.AddTags("第三方平台", "tg2");
        }
    }
}