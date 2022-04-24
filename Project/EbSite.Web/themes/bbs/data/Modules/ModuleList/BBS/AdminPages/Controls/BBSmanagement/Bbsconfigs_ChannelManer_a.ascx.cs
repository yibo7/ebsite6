using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.EntityAPI;
using EbSite.Base.Modules;
using EbSite.Modules.BBS.ModuleCore.Entity;


namespace EbSite.Modules.BBS.AdminPages.Controls.BBSmanagement
{
    public partial class Bbsconfigs_ChannelManer_a : MPUCBaseSave
    {
        public override string Permission
        {
            get
            {
                return "15";
            }
        }
        override protected string KeyColumnName
        {
            get
            {
                return "id";
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // base.HostApi.EBMembershipInstance  http://forum.sxcms.com/default.html
                binddata();
            }

        }
        /// <summary>
        /// 版块列表
        /// </summary>
        private void binddata()
        {
            drpPatentID.DataTextField = "ChannelName";
            drpPatentID.DataValueField = "Id";
            drpPatentID.DataSource = ModuleCore.BLL.Channels.Instance.GetTree(0);//BLL.Menus.Instance.GetTree(0);
            drpPatentID.DataBind();
        }
        override protected void InitModifyCtr()
        {

            ModuleCore.BLL.ChannelMasters.Instance.InitModifyCtr(SID, phCtrList);
            ModuleCore.Entity.ChannelMasters md = ModuleCore.BLL.ChannelMasters.Instance.GetEntity(int.Parse(SID));

            txtUserName.Text = md.UserName;
            if (!string.IsNullOrEmpty(md.ChannelID.ToString()))
                drpPatentID.SelectedValue = md.ChannelID.ToString();
        }
        override protected void SaveModel()
        {
            ModuleCore.Entity.ChannelMasters bbsChannelMasters = new ChannelMasters();
            bbsChannelMasters.ChannelID = Convert.ToInt32(drpPatentID.SelectedValue);

            bbsChannelMasters.UserID = base.HostApi.EBMembershipInstance.GetUserIDByUserName(txtUserName.Text);
            bbsChannelMasters.UserName = txtUserName.Text;

            bbsChannelMasters.ChannelName =
                ModuleCore.BLL.Channels.Instance.GetEntity(Convert.ToInt32(drpPatentID.SelectedValue)).ChannelName;
            //这里要验证 写的用户是否正确
            if (bbsChannelMasters.UserID > 0)
            {
                if (!string.IsNullOrEmpty(SID))
                {
                    bbsChannelMasters.id = Convert.ToInt32(SID);
                }
                if (!string.IsNullOrEmpty(SID))
                {
                    ModuleCore.BLL.ChannelMasters.Instance.Update(bbsChannelMasters);
                    ShowTipsPop("修改成功!");
                }
                else
                {
                    ModuleCore.BLL.ChannelMasters.Instance.Add(bbsChannelMasters);
                    ShowTipsPop("保存成功！");
                }
            }
            else
            {
                TipsAlert("此用户不存在");
                //ShowTipsPop("此用户不存在!");
            }
        }
    }
}