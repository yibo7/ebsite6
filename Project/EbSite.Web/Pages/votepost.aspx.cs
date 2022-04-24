using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EbSite.Web.Pages
{
    public partial class votepost : EbSite.Base.Page.CustomPage
    {
        protected Entity.vote Model;
        private int GetVoteID
        {
            get
            {
                if (!string.IsNullOrEmpty(Request["vid"]))
                    return int.Parse(Request["vid"]);
                {
                    Tips("出错了", "请参数不对！");
                    return 0;
                }

            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Model = EbSite.BLL.vote.Instance.GetEntity(GetVoteID);
                inithead();
                BindVote();
            }

        }

        private void BindVote()
        {
            List<Entity.voteitem> lstvoteitem = EbSite.BLL.voteitem.Instance.GetListArray(GetVoteID);
            rpVote.DataSource = lstvoteitem;
            rpVote.DataBind();
        }

        private void inithead()
        {

            base.SeoTitle = string.Concat("参与投票-", SiteName);
            base.SeoKeyWord = GetSeoWord(SeoSite.SeoTagIndexKeyWord, "");
            base.SeoDes = GetSeoWord(SeoSite.SeoTagIndexDes, "");

        }

        protected string BindItems(object sItemsid,object sItemName)
        {
            if (!Model.IsMoreSel)
            {
                return string.Format("<input type=\"radio\" value=\"{0}\" id=\"voteitem{0}\" name=\"voteitem\"/><label for=\"voteitem{0}\" >{1}</label>", sItemsid, sItemName); 
            }
            else
            {
                return string.Format("<input type=\"checkbox\" value=\"{0}\" id=\"voteitem{0}\" name=\"voteitem{0}\"/><label for=\"voteitem{0}\" >{1}</label>", sItemsid, sItemName); 
            }
           
        }
    }
}