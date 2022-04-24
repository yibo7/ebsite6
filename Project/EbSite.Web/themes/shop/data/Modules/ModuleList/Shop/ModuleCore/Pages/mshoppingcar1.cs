using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using EbSite.Modules.Shop.ModuleCore.Cart;

namespace EbSite.Modules.Shop.ModuleCore.Pages
{
    public class mshoppingcar1 : MshoppingcarBase
    {
        protected global::System.Web.UI.HtmlControls.HtmlGenericControl gotobuy;

        protected EbSite.Control.Repeater ScoreRep;
        protected void Page_Load(object sender, EventArgs e)
        {

            Page.Title = "我的购物车";

            if (TotalCount < 1)
            {
                gotobuy.Visible = false;
            }
            ScoreBind();
        }

        private void ScoreBind()
        {
            //得到当前用户的总积分 来检索

            int iaddscore =EbSite.Core.Utils.StrToInt( this.ltlPoints.Text,0);
            int score = 0;
            if (EbSite.Base.Host.Instance.UserID > 0)
            {
                 score = EbSite.Base.Host.Instance.GetUserCreditsByID(EbSite.Base.Host.Instance.UserID) + iaddscore;
            }
            else
            {
                score = iaddscore;
            }

            this.ltlSumPoints.Text = score.ToString();
            List<Entity.creditproduct> ls = ModuleCore.BLL.creditproduct.Instance.GetListArrayCache(0, "IsSaling=1 and Credit<=" + score, "");
            ScoreRep.DataSource = ls;
            ScoreRep.DataBind();
            //if (ls.Count == 0)
            //{
            //    this.ltlNoGift.Text = "<div class=\"nogift\"> 没有此积分段的礼品</div>";
            //}

        }

    }
}