using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.ControlPage;

namespace EbSite.Web.AdminHt.Controls.Admin_Coupons
{
    public partial class SendMember : UserControlBaseSave
    {
        public override string PageName
        {
            get
            {
                return "发送给会员";
            }
        }
        public override string Permission
        {
            get
            {
                return "159";
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
            RandBand();
        }

        override protected void InitModifyCtr()
        {
            //BLL.Coupons.Instance.InitModifyCtr(SID, phCtrList);
        }
        override protected void SaveModel()
        {
            int iCount = 0;
            Guid gid = Guid.NewGuid();
            if (RdoName.SelectedValue == "0")//发送给指定的会员
            {
                #region
                string names = this.txtMemberNames.Text.Trim();
                if (!string.IsNullOrEmpty(names))
                {

                    string[] arry = names.Split(',');
                    string info = "";

                    foreach (var s in arry)
                    {
                        Entity.CouponItems md = new Entity.CouponItems();
                        md.CouponId = int.Parse(SID);
                        md.LotNumber = gid.ToString();
                        md.ClaimCode = Core.Strings.GetString.RandomNUMSTR(15);
                        md.AddDateTime = DateTime.Now;
                        bool ikey = EbSite.Base.Host.Instance.ExistsUserName(s);

                        if (ikey)
                        {
                            EbSite.Base.EntityAPI.MembershipUserEb mdoel = EbSite.Base.Host.Instance.GetUser(s);
                            md.UserId = mdoel.id;
                            md.EmailAddress = mdoel.emailAddress;
                            iCount += 1;
                            BLL.CouponItems.Instance.Add(md);
                        }
                        else
                        {
                            info += s + ",";
                        }
                        if (!string.IsNullOrEmpty(info))
                        {
                            info = info.Remove(info.Length - 1, 1);
                            base.TipsAlert(info + " 没有对应的用户");
                        }
                    }
                }
                else
                {
                    base.TipsAlert("请添写要发送的会员名称！");
                }
                #endregion
            }
            else //发送给指定的会员等级
            {
                List<Base.EntityAPI.MembershipUserEb> ls = EbSite.BLL.User.MembershipUserEb.Instance.GetListArray(0, "userlevel=" + rank.SelectedValue, "");

                foreach (var membershipUserEb in ls)
                {
                    Entity.CouponItems md = new Entity.CouponItems();
                    md.CouponId = int.Parse(SID);
                    md.LotNumber = gid.ToString();
                    md.ClaimCode = Core.Strings.GetString.RandomNUMSTR(15);
                    md.AddDateTime = DateTime.Now;
                    md.UserId = membershipUserEb.id;
                    md.EmailAddress = membershipUserEb.emailAddress;
                    iCount += 1;
                    BLL.CouponItems.Instance.Add(md);

                }
            }
            Entity.Coupons model = BLL.Coupons.Instance.GetEntity(int.Parse(SID));
            model.SentCount += iCount;
            model.Update();

            base.TipsAlert("此次发送操作已成功，优惠券发送数量："+iCount );
        }

        private void RandBand()
        {
            List<Entity.UserLevel> ls = BLL.UserLevel.Instance.GetListArray("");
            rank.DataSource = ls;
            rank.DataValueField = "id";
            rank.DataTextField = "LevelName";
            rank.DataBind();
        }
        protected void RdoName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (RdoName.SelectedValue == "0")//发送给指定的会员
            {
                this.rank.Enabled = false;
                this.txtMemberNames.Enabled = true;
            }
            else
            {
                this.rank.Enabled = true;
                this.txtMemberNames.Enabled = false;
            }
        }
    }
}