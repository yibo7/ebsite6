using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.ControlPage;
using EbSite.Base.Modules;
using EbSite.Modules.BBS.ModuleCore.Entity;
namespace EbSite.Modules.BBS.AdminPages.Controls.BBSmanagement
{
    public partial class BBS_Topics_gl : MPUCBaseSave//MPUCBaseShow<Topics>
    {
        public override string Permission
        {
            get
            {
                return "17";
            }
        }
        protected override string KeyColumnName
        {
            get
            {
                return "id";
            }
        }
        protected override void InitModifyCtr()
        {
            // ModuleCore.BLL.Topics.Instance.InitModifyCtr(SID, phCtrList);
            ModuleCore.Entity.Topics Model = ModuleCore.BLL.Topics.Instance.GetEntity(int.Parse(SID));
            drpPatentID.DataTextField = "ChannelName";
            drpPatentID.DataValueField = "id";
            drpPatentID.DataSource = ModuleCore.BLL.Channels.Instance.GetTree(0);
            drpPatentID.DataBind();

            drpPatentID.SelectedValue = Model.ChannelID.ToString();
        }
        protected override void SaveModel()
        {
            ModuleCore.Entity.Topics Model = ModuleCore.BLL.Topics.Instance.GetEntity(int.Parse(SID));
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
                if (rbXX.Items[0].Selected) //删除
                {
                    Model.DeleteFlag = 1;
                }
                else if (rbXX.Items[1].Selected)//标题变色
                {
                    Model.TitleColorFlag = 1;
                    Model.TitleColorTime = DateTime.Now;
                    Model.TitleColorCode = cpColor.Color;
                }
                else if (rbXX.Items[2].Selected)//加粗
                {
                    Model.TitleBoldFlag = 1;
                    Model.TitleBoldTime = DateTime.Now;
                }
                else if (rbXX.Items[3].Selected)//板块置顶
                {
                    Model.OrderTopFlag = 1;
                    Model.OrderTopMasterUserID = int.Parse(Convert.ToString(base.UserID));
                    Model.OrderTopMasterUserName = base.UserNiname; //UserRealname;----yhl
                    Model.OrderTopTime = DateTime.Now;
                }
                else if (rbXX.Items[4].Selected)//取消板块置顶
                {
                    Model.OrderTopFlag = 0;
                }
                else if (rbXX.Items[5].Selected)//全站置顶
                {
                    Model.SiteOrderTopFlag = 1;
                    Model.SiteOrderTopMasterUserID = int.Parse(Convert.ToString(UserID));
                    Model.SiteOrderTopMasterUserName = base.UserNiname;
                    Model.SiteOrderTopTime = DateTime.Now;
                }
                else if (rbXX.Items[6].Selected)//取消全站置顶
                {
                    Model.SiteOrderTopFlag = 0;
                }
                else if (rbXX.Items[7].Selected)//加精
                {
                    Model.GoodFlag = 1;
                    Model.GoodMasterUserID = int.Parse(Convert.ToString(UserID));
                    Model.GoodMasterUserName = base.UserNiname;
                    Model.GoodTime = DateTime.Now;
                    Model.GoodImageUrl = "";
                    Model.GoodDescription = "";
                }
                else if (rbXX.Items[8].Selected)//取消加精
                {
                    Model.GoodFlag = 0;
                }
                else if (rbXX.Items[9].Selected)//推荐
                {
                    Model.RecommendFlag = 1;
                    Model.RecommendMasterUserID = int.Parse(Convert.ToString(UserID));
                    Model.RecommendMasterUserName = base.UserNiname;
                    Model.RecommendTime = DateTime.Now;
                }
                else if (rbXX.Items[10].Selected)//取消推荐
                {
                    Model.RecommendFlag = 0;
                }
                else if (rbXX.Items[11].Selected)//帖子转移至
                {
                    Model.ChannelID = int.Parse(drpPatentID.SelectedValue);
                    Model.ChannelName = ModuleCore.BLL.Channels.Instance.GetEntity(int.Parse(drpPatentID.SelectedValue)).ChannelName;//drpPatentID.SelectedItem.Text;
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

        protected void btnClose_Click(object sender, EventArgs e)
        {
            base.ColseGreyBox(true);
        }
    }
}