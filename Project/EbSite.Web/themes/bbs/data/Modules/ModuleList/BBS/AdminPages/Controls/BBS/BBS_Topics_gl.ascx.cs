using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.Modules;
using EbSite.Modules.BBS.ModuleCore.Entity;


namespace EbSite.Modules.BBS.AdminPages.Controls.BBS
{
    public partial class BBS_Topics_gl : MPUCBaseShow<ModuleCore.Entity.Topics>
    {
        public override string Permission
        {
            get
            {
                return "7";
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                InitddlBKFL();
            }
        }

        protected override void Delete()
        {
            ModuleCore.BLL.Topics.Instance.Delete(int.Parse(GetKeyID));
        }
        protected override Topics LoadModel()
        {
            Topics md = ModuleCore.BLL.Topics.Instance.GetEntity(int.Parse(GetKeyID));
            if (Equals(md, null)) md = new Topics();//防止删除后的页面出错
            return md;
        }

        private void SaveEntity()
        {
            int l = 0;
            for (int i = 0; i < rbXX.Items.Count; i++)
            {
                if (rbXX.Items[i].Selected)
                {
                    l = 1;
                }
            }
            if (l == 1)
            {
                if (rbXX.Items[0].Selected)
                {
                    Model.DeleteFlag = 1;
                }
                else if (rbXX.Items[1].Selected)
                {
                    Model.TitleColorFlag = 1;
                    Model.TitleColorTime = DateTime.Now;
                    Model.TitleColorCode = cpColor.Color;
                }
                else if (rbXX.Items[2].Selected)
                {
                    Model.TitleBoldFlag = 1;
                    Model.TitleBoldTime = DateTime.Now;
                }
                else if (rbXX.Items[3].Selected)
                {
                    Model.OrderTopFlag = 1;
                    Model.OrderTopMasterUserID = int.Parse(Convert.ToString(UserID));
                   // Model.OrderTopMasterUserName = UserRealname;
                    Model.OrderTopTime = DateTime.Now;
                }
                else if (rbXX.Items[4].Selected)
                {
                    Model.OrderTopFlag = 0;
                }
                else if (rbXX.Items[5].Selected)
                {
                    Model.SiteOrderTopFlag = 1;
                    Model.SiteOrderTopMasterUserID = int.Parse(Convert.ToString(UserID));
                   // Model.SiteOrderTopMasterUserName = UserRealname;
                    Model.SiteOrderTopTime = DateTime.Now;
                }
                else if (rbXX.Items[6].Selected)
                {
                    Model.SiteOrderTopFlag = 0;
                }
                else if (rbXX.Items[7].Selected)
                {
                    Model.GoodFlag = 1;
                    Model.GoodMasterUserID = int.Parse(Convert.ToString(UserID));
                  //  Model.GoodMasterUserName = UserRealname;
                    Model.GoodTime = DateTime.Now;
                    Model.GoodImageUrl = "";
                    Model.GoodDescription = "";
                }
                else if (rbXX.Items[8].Selected)
                {
                    Model.GoodFlag = 0;
                }
                else if (rbXX.Items[9].Selected)
                {
                    Model.RecommendFlag = 1;
                    Model.RecommendMasterUserID = int.Parse(Convert.ToString(UserID));
                   // Model.RecommendMasterUserName = UserRealname;
                    Model.RecommendTime = DateTime.Now;
                }
                else if (rbXX.Items[10].Selected)
                {
                    Model.RecommendFlag = 0;
                }
                else if (rbXX.Items[11].Selected)
                {
                    Model.ChannelID = int.Parse(ddlBKFL.SelectedValue);
                    Model.ChannelName = ddlBKFL.SelectedItem.Text;
                }
                Model.UpdatedTime = DateTime.Now;
                ModuleCore.BLL.Topics.Instance.Update(Model);
                base.ShowTipsPop("更新成功!");
            }
            else
            {
                base.ShowTipsPop("请选择选项!");
            }
        }

        private void InitddlBKFL()
        {
            ddlBKFL.DataSource = ModuleCore.BLL.Channels.Instance.GetListArray("");
            ddlBKFL.DataBind();
        }
        protected void btnBC_Click(object sender, EventArgs e)
        {
            SaveEntity();
        }

        protected void btnClose_Click(object sender, EventArgs e)
        {
            base.ColseGreyBox(true);
        }
    }
}