using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EbSite.Modules.Wenda.CustomPage
{
    public partial class AskClassSelect : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string sqlStr = " ParentID= "+0;
                int siteid = 2;// EbSite.Base.Host.Instance.GetSiteID;
                List<EbSite.Entity.NewsClass> oneList = EbSite.BLL.NewsClass.GetListArr(sqlStr, siteid);
                OneListBox.DataSource = oneList;
                OneListBox.DataTextField = "ClassName";
                OneListBox.DataValueField = "ID";
                OneListBox.DataBind();
            }
        }

        protected void okButton_Click(object sender, EventArgs e)
        {
            int asktype = 0;
            string askString = "";
            if(!string.IsNullOrEmpty(oneNameAndIDTextBox.Text.Trim()))
            {
                asktype = 1;
                askString += oneNameAndIDTextBox.Text.Trim() + "|";
            }
            if (!string.IsNullOrEmpty(twoNameAndIDTextBox.Text.Trim()))
            {
                asktype = 2;
                askString +=  twoNameAndIDTextBox.Text.Trim() + "|";
            }
            if (!string.IsNullOrEmpty(threeNameAndIDTextBox.Text.Trim()))
            {
                asktype = 3;
                askString +=  threeNameAndIDTextBox.Text.Trim() + "|";
            }

            if (askString.Length > 0) askString = askString.Substring(0, askString.Length - 1);

            if(asktype!=0)
            {
                string finalStr = asktype + "*" + askString;
                this.ClientScript.RegisterStartupScript(this.GetType(), "", "<script language=\"javascript\">window.returnValue=\"" + finalStr + "\";self.close();</script>");
            }
            
        }

        protected void OneListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string oneValue = OneListBox.SelectedValue;
            string sqlStr = " ParentID= " + oneValue;
            int siteid = 2;//EbSite.Base.Host.Instance.GetSiteID;
            List<EbSite.Entity.NewsClass> twoList = EbSite.BLL.NewsClass.GetListArr(sqlStr, siteid);
            TwoListBox.DataSource = twoList;
            TwoListBox.DataTextField = "ClassName";
            TwoListBox.DataValueField = "ID";
            TwoListBox.DataBind();

            oneNameAndIDTextBox.Text = OneListBox.SelectedItem.Text+"," + OneListBox.SelectedItem.Value;
            twoNameAndIDTextBox.Text = "";
            threeNameAndIDTextBox.Text = "";
        }

        protected void TwoListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string twoValue = TwoListBox.SelectedValue;
            string sqlStr = " ParentID= " + twoValue;
            int siteid = 2;// EbSite.Base.Host.Instance.GetSiteID;
            List<EbSite.Entity.NewsClass> threeList = EbSite.BLL.NewsClass.GetListArr(sqlStr, siteid);
            ThreeListBox.DataSource = threeList;
            ThreeListBox.DataTextField = "ClassName";
            ThreeListBox.DataValueField = "ID";
            ThreeListBox.DataBind();

            twoNameAndIDTextBox.Text = TwoListBox.SelectedItem.Text + "," + TwoListBox.SelectedItem.Value;
            threeNameAndIDTextBox.Text = "";
        }

        protected void ThreeListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            threeNameAndIDTextBox.Text = ThreeListBox.SelectedItem.Text + "," + ThreeListBox.SelectedItem.Value;
        }
    }
}