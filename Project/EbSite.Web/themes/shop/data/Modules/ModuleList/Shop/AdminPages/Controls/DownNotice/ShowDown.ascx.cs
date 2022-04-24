using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.Modules;

namespace EbSite.Modules.Shop.AdminPages.Controls.DownNotice
{
    public partial class ShowDown : MPUCBaseShow<ModuleCore.Entity.CutPriceTips>
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            EbSite.Entity.NewsContent md = Base.AppStartInit.NewsContentInstDefault.GetModel(int.Parse(GetKeyID),GetSiteID);
            if (Equals(md, null)) md = new EbSite.Entity.NewsContent();//防止删除后的页面出错
            this.lbName.Text = md.NewsTitle;

            string ids = Request.QueryString["id"];

            RepItem.DataSource = ModuleCore.BLL.CutPriceTips.Instance.GetListArray(0, "productid=" + ids+" and isnotice=0", "");
            RepItem.DataBind();
        }
        public override string PageName
        {
            get
            {
                return "降价查看";
            }
        }
        /// <summary>
        /// 权限全部
        /// </summary>
        public override string Permission
        {
            get
            {
                return "9";
            }
        }
        /// <summary>
        /// 重写删除
        /// </summary>
        protected override void Delete()
        {
            Model.Delete();
        }
        /// <summary>
        /// 重写Load事件
        /// </summary>
        protected override ModuleCore.Entity.CutPriceTips LoadModel()
        {
            return null;
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            //降价通知发送手机短信
            string strMsg = Configs.Instance.Model.DownPriceMsgTemplate.Replace("#商品名称#", this.lbName.Text);  // string.Format("尊敬的客户,您关注的商品{0}已经降价。咨询电话：{1}—【北迈网】",this.lbName.Text, "010-51659881");
            SendMsg(strMsg,0); 
        }

        protected void btnPriced_Click(object sender, EventArgs e)
        {
            //降价通知发送电子邮件
            string strMsg = Configs.Instance.Model.DownPriceEmailTemplate.Replace("#商品名称#", this.lbName.Text);// string.Format("尊敬的客户,您关注的商品{0}已经降价。咨询电话：{1}—【北迈网】", this.lbName.Text, "010-51659881");
            SendMsg(strMsg, 1);           
        }
        /// <summary>
        /// 发送降价通知
        /// </summary>
        /// <param name="strMsg">通知内容</param>
        /// <param name="flag">标示 1:发送Email信息,0:发送手机短信</param>
        public void SendMsg(string strMsg,int flag)
        {
            RepeaterItemCollection itemList = this.RepItem.Items;
            if (itemList != null && itemList.Count > 0)
            {
                foreach (RepeaterItem item in itemList)
                {
                    if (item.ItemType == ListItemType.AlternatingItem || item.ItemType == ListItemType.Item)
                    {
                        string strMobile = "";
                        if (flag > 0)
                        {
                            Literal litMobile = (Literal)item.FindControl("litEmail");
                            strMobile = litMobile.Text.Trim();
                            //判断如果不符合邮件格式，则不进行发送
                            if (!EbSite.Core.Strings.Validate.IsValidEmail(strMobile))
                            {
                                continue;
                            }
                        }
                        else
                        {
                            Literal litMobile = (Literal)item.FindControl("litMobile");
                            strMobile = litMobile.Text.Trim();
                            //判断如果不符合手机号码，则不进行发送
                            if (!EbSite.Core.Strings.Validate.IsMobile(strMobile))
                            {
                                continue;
                            }
                        }
                        if (!string.IsNullOrEmpty(strMobile))
                        {
                            HiddenField hidid = (HiddenField)item.FindControl("hidid");
                            int id = Core.Utils.StrToInt(hidid.Value, 0);
                            if (id > 0)
                            {
                                ModuleCore.Entity.CutPriceTips md = ModuleCore.BLL.CutPriceTips.Instance.GetEntity(id);
                                md.IsNotice = true;
                                ModuleCore.BLL.CutPriceTips.Instance.Update(md);
                            }
                            if (flag > 0)
                            {
                                EbSite.Base.Host.Instance.SendEmailPool(strMobile, "商品降价通知_北迈网", strMsg);
                            }
                            else
                            {
                                EbSite.Base.Host.Instance.SendMobileMsg(strMsg, strMobile, strMobile);
                            }
                        }
                    }
                }
                base.RunJs("alert('发送完毕！')");
            }
        }

    }
}