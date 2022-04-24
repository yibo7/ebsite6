using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.Modules;

namespace EbSite.Modules.Shop.AdminPages.Controls.RequestGroup
{
    public partial class RequestShow : MPUCBaseShow<ModuleCore.Entity.requestgroup>
    {
       
        protected void Page_Load(object sender, EventArgs e)
        {
            EbSite.Entity.NewsContent md = Base.AppStartInit.NewsContentInstDefault.GetModel(int.Parse(GetKeyID),GetSiteID);
            if (Equals(md, null)) md = new EbSite.Entity.NewsContent();//防止删除后的页面出错
            this.lbName.Text = md.NewsTitle;

            string ids = Request.QueryString["id"];

            RepItem.DataSource = ModuleCore.BLL.requestgroup.Instance.GetListArray(0, "productid="+ids+" and isnotice=0", "");
            RepItem.DataBind();
        }
        public override string PageName
        {
            get
            {
                return "求团购查看";
            }
        }
        /// <summary>
        /// 权限全部
        /// </summary>
        public override string Permission
        {
            get
            {
                return "99";
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
        protected override ModuleCore.Entity.requestgroup LoadModel()
        {
            return null;
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            //string strMsg = SettingInfo.Instance.RequestGroupMsgTemplate.Replace("#商品名称#", this.lbName.Text);// string.Format("尊敬的客户,您关注的商品{0}可以团购啦！咨询电话：{1}—【北迈网】", this.lbName.Text, "010-51659881");
            
           string strMsg = Configs.Instance.Model.RequestGroupMsgTemplate.Replace("#商品名称#", this.lbName.Text);// string.Format("尊敬的客户,您关注的商品{0}可以团购啦！咨询电话：{1}—【北迈网】", this.lbName.Text, "010-51659881");
            SendMsg(strMsg, 0);
        }

        protected void btnPriced_Click(object sender, EventArgs e)
        {
            string strMsg = Configs.Instance.Model.RequestGroupEmailTemplate.Replace("#商品名称#", this.lbName.Text);// string.Format("尊敬的客户,您关注的商品{0}可以团购啦！咨询电话：{1}—【北迈网】", this.lbName.Text, "010-51659881");
            SendMsg(strMsg,1);
        }
        /// <summary>
        /// 发送降价通知
        /// </summary>
        /// <param name="strMsg">通知内容</param>
        /// <param name="flag">标示 1:发送Email信息,0:发送手机短信</param>
        public void SendMsg(string strMsg, int flag)
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
                                ModuleCore.Entity.requestgroup md = ModuleCore.BLL.requestgroup.Instance.GetEntity(id);
                                md.IsNotice =1;
                                ModuleCore.BLL.requestgroup.Instance.Update(md);
                            }
                            if (flag > 0)
                            {
                                EbSite.Base.Host.Instance.SendEmailPool(strMobile, "商品团购通知_北迈网", strMsg);
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