using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.BLL;
using EbSite.Base.Modules;
using EbSite.Modules.CQ.ModuleCore.Configs;
using EbSite.Modules.CQ.ModuleCore.Entity;

namespace EbSite.Modules.CQ.AdminPages.Controls.Setting
{
    public partial class Configs : MPUCBaseSave
    {
       
        public override Guid ModuleMenuID
        {
            get
            {
                return new Guid("42a545bb-e8be-4ef6-b6e9-9c7b3536750f");
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                Title.Text = SvConfigsControl.Instance.Title;
                ChatModel.SelectedValue = SvConfigsControl.Instance.ChatModel.ToString();
                Demo.Text = SvConfigsControl.Instance.Demo.ToString();
                DemoModel.SelectedValue = SvConfigsControl.Instance.DemoModel.ToString();
                FloatListModel.SelectedValue = SvConfigsControl.Instance.FloatListModel.ToString();
                FloatPlaceModel.SelectedValue = SvConfigsControl.Instance.FloatPlaceModel.ToString();
                IsShowClose.SelectedValue = SvConfigsControl.Instance.IsShowClose.ToString();
                IsShowMore.SelectedValue = SvConfigsControl.Instance.IsShowMore.ToString();
                IsSaveOrder.Checked = SvConfigsControl.Instance.IsSaveOrder;
                txtTop.Text = SvConfigsControl.Instance.Top.ToString();
                IsFull.SelectedValue = (SvConfigsControl.Instance.IsFull)?"1":"0";
                txtFloatServiceLink.Text = SvConfigsControl.Instance.FloatServiceLink;
                txtFloatServiceMaxNum.Text = SvConfigsControl.Instance.FloatServiceMaxNum.ToString();
                cbIsServicerOutLink.Checked = SvConfigsControl.Instance.IsServicerOutLink;
                txtWelComeInfo.Text = SvConfigsControl.Instance.WelcomeInfo;

                txtTimeSpan.Text = SvConfigsControl.Instance.TimeSpan.ToString();
                txtTimeSpanToAuto.Text = SvConfigsControl.Instance.TimeSpanToAuto.ToString();
                rbTimeSpanToAutoModel.SelectedValue = SvConfigsControl.Instance.TimeSpanToAutoModel.ToString();
                txtMaxReceive.Text = SvConfigsControl.Instance.MaxReceive.ToString();

                cbIsOpenInvite.Checked = SvConfigsControl.Instance.IsOpenInvite;
                txtInviteTimeSpan.Text = SvConfigsControl.Instance.InviteTimeSpan.ToString();
                txtInviteInfo.Text = SvConfigsControl.Instance.InviteInfo;
                rbInviteModel.SelectedValue = SvConfigsControl.Instance.InviteModel.ToString();
                cbIsOpenAppraise.Checked = SvConfigsControl.Instance.IsOpenAppraise;


            }

           
        }
        public override string Permission
        {
            get
            {
                return "7";
            }
        }
        public override string PageName
        {
            get
            {
                return "订单宝配置";
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
                return 10;
            }
        }
        override protected string KeyColumnName
        {
            get
            {
                return "id";
            }
        }
        override protected void InitModifyCtr()
        {

        }
        override protected void SaveModel()
        {
            SvConfigsInfo md = new SvConfigsInfo();

            SvConfigsControl.Instance.Title = Title.Text;
            SvConfigsControl.Instance.ChatModel = int.Parse(ChatModel.SelectedValue);
            SvConfigsControl.Instance.Demo = Demo.Text;
            SvConfigsControl.Instance.DemoModel = int.Parse(DemoModel.SelectedValue);
            SvConfigsControl.Instance.FloatListModel = int.Parse(FloatListModel.SelectedValue);
            SvConfigsControl.Instance.FloatPlaceModel = int.Parse(FloatPlaceModel.SelectedValue);
            SvConfigsControl.Instance.IsShowClose = int.Parse(IsShowClose.SelectedValue);

            SvConfigsControl.Instance.IsShowMore = int.Parse(IsShowMore.SelectedValue);
            SvConfigsControl.Instance.IsSaveOrder = IsSaveOrder.Checked;
            SvConfigsControl.Instance.Top = int.Parse(txtTop.Text);
            SvConfigsControl.Instance.IsFull = (IsFull.SelectedValue=="0")?false:true;
            SvConfigsControl.Instance.FloatServiceLink = txtFloatServiceLink.Text;
            SvConfigsControl.Instance.FloatServiceMaxNum = int.Parse(txtFloatServiceMaxNum.Text);
            SvConfigsControl.Instance.IsServicerOutLink = cbIsServicerOutLink.Checked;
            SvConfigsControl.Instance.WelcomeInfo = txtWelComeInfo.Text.Replace("'","’");

            SvConfigsControl.Instance.TimeSpan = int.Parse(txtTimeSpan.Text);
            SvConfigsControl.Instance.TimeSpanToAuto = int.Parse(txtTimeSpanToAuto.Text);
            SvConfigsControl.Instance.TimeSpanToAutoModel = int.Parse(rbTimeSpanToAutoModel.SelectedValue);
            SvConfigsControl.Instance.MaxReceive = int.Parse(txtMaxReceive.Text);

            SvConfigsControl.Instance.IsOpenInvite = cbIsOpenInvite.Checked;
            SvConfigsControl.Instance.InviteTimeSpan = int.Parse(txtInviteTimeSpan.Text);
            SvConfigsControl.Instance.InviteInfo = txtInviteInfo.Text;
            SvConfigsControl.Instance.InviteModel = int.Parse(rbInviteModel.SelectedValue);
            SvConfigsControl.Instance.IsOpenAppraise = cbIsOpenAppraise.Checked;

            SvConfigsControl.SaveConfig();

            SvConfigsControl.UpdateSettingJs();


        }

       

    }
}