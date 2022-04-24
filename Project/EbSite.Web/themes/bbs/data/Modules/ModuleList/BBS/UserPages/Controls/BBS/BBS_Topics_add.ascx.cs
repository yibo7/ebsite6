using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.BLL;
using EbSite.Base.Modules;


namespace EbSite.Modules.BBS.UserPages.Controls.BBS
{
    public partial class BBS_Topics_add : MPUCBaseSaveForUser
    {
        /// <summary>
        /// 要修改的帖子ID
        /// </summary>
        protected long GetTopiceID
        {
            get
            {
                if (string.IsNullOrEmpty(Request.QueryString["tip"]))
                {
                    return 0;
                }
                return long.Parse(Request.QueryString["tip"]);
            }
        }


        /// <summary>
        /// 版块的ID
        /// </summary>
        protected string GetBkId
        {
            get
            {
                return Request.QueryString["bkId"];
            }
        }
        /// <summary>
        /// 版块的名称
        /// </summary>
        protected string GetBkName
        {
            get
            {
                ModuleCore.Entity.Channels md = ModuleCore.BLL.Channels.Instance.GetEntity(int.Parse(GetBkId));
                return md.ChannelName;
            }
        }
        public override string Permission
        {
            get
            {
                return "7";
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
                bntSave.Visible = false;
                ipSave.Visible = true;
                if (GetTopiceID > 0)
                {
                    bntSave.Visible = true;
                    ipSave.Visible = false;
                    ModuleCore.Entity.Topics md = ModuleCore.BLL.Topics.Instance.GetEntity(GetTopiceID);
                    this.TopicTitle.Text = md.TopicTitle;
                    this.TopicContent.Text = md.TopicContent;
                }
            }
            IfTp();
        }
        override protected void InitModifyCtr()
        {

        }
        override protected void SaveModel()
        {
            if (string.IsNullOrEmpty(TopicContent.Text))
            {
                base.ShowTipsPop("帖子内容没有添写！");
            }
            else
            {
                if (GetTopiceID > 0)
                {
                    ModuleCore.Entity.Topics md = ModuleCore.BLL.Topics.Instance.GetEntity(GetTopiceID);
                    md.TopicTitle=this.TopicTitle.Text;
                    md.TopicContent = this.TopicContent.Text;
                    md.UpdatedTime = DateTime.Now;

                    ModuleCore.BLL.Topics.Instance.Update(md);
                    base.ShowTipsPop("修改成功!");
                }
                
            }
        }

        private void IfTp()
        {

        }
    }
}