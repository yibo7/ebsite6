using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Entity;

namespace EbSite.Web.Pages
{

    
    public partial class voteview : EbSite.Base.Page.CustomPage
    {
        protected Entity.vote Model;
        private int GetVoteID
        {
            get
            {
                if (!string.IsNullOrEmpty(Request["vid"]))
                    return int.Parse(Request["vid"]);
                {
                    Tips("出错了","请参数不对！");
                    return 0;
                }
               
            }
        }

        private string[] RandColor = { "4EAF04", "BDE777", "6C81B6", "B8E4EF", "D743B3", "E93329", "EE335E", "FFC535", "FFC535", "DF8655", "D8E929" };
        private int ColorIndex = -1;
        public string GetColor
        {
            get
            {
                if (Model.IsItemColorRan)
                {
                    if (ColorIndex >= RandColor.Length - 1)
                    {
                        ColorIndex = -1;
                    }
                    ColorIndex++;
                    return RandColor[ColorIndex];
                }
                return RandColor[0];

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
        private void inithead()
        {

            base.SeoTitle = string.Concat("查看投票-", SiteName);
            base.SeoKeyWord = GetSeoWord(SeoSite.SeoTagIndexKeyWord, "");
            base.SeoDes = GetSeoWord(SeoSite.SeoTagIndexDes, "");

        }

        private void BindVote()
        {
            List<Entity.voteitem> lstvoteitem = EbSite.BLL.voteitem.Instance.GetListArray(GetVoteID);
            int iAllPostCount = Model.VoteCount;
             List<Entity.voteitem> lstvoteitemnew = new List<voteitem>();
            foreach (voteitem vitem in lstvoteitem)
            {
                int width = iAllPostCount != 0 ? (int)Math.Ceiling(200 * Convert.ToDouble(vitem.PostCount) / Convert.ToDouble(iAllPostCount)) : 0;
                vitem.ItemWidth = width;

                string spc = "0%";

                if (iAllPostCount > 0)
                {
                    spc = Convert.ToDouble(vitem.PostCount / Convert.ToDouble(iAllPostCount)).ToString("##.##%");
                }
                vitem.Percent = spc;
                lstvoteitemnew.Add(vitem);
            }

            rpVote.DataSource = lstvoteitemnew;
            rpVote.DataBind();

            //string[] aItems = CvToItems();
            //string[] aValues = CvToValues();

            
            //List<VoteItem> lst = new List<VoteItem>();
            //for (int i = 0; i < aItems.Length; i++)
            //{
            //    VoteItem li = new VoteItem();

            //    li.ItemName = aItems[i];
            //    int iCount = int.Parse(aValues[i]);
            //    li.PostCount = iCount;
            //    int width = iAllPostCount != 0 ? (int)Math.Ceiling(200 * Convert.ToDouble(iCount) / Convert.ToDouble(iAllPostCount)) : 0;

            //    li.ItemWidth = width;

            //    string spc = "0%";

            //    if (iAllPostCount > 0)
            //    {
            //        spc = Convert.ToDouble(iCount / Convert.ToDouble(iAllPostCount)).ToString("##.##%");
            //    }


            //    li.Percent = spc;

            //    lst.Add(li);
            //}

            //rpVote.DataSource = lst;
            //rpVote.DataBind();

        }
    }
}