using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base;
using EbSite.Base.ControlPage;

namespace EbSite.Web.AdminHt.Controls.Admin_Lucene
{
    public partial class Configs : UserControlBaseSave
    {
        public override string Permission
        {
            get
            {
                return "304";
            }
        }
        override protected string KeyColumnName
        {
            get
            {
                return "id";
            }
        }
        override protected void InitModifyCtr()
        {
            throw new NotImplementedException();
        }
        override protected void SaveModel()
        {
            llRz.Text = "";
            int iNum = int.Parse(txtNum.Text);
            int iTop = int.Parse(txtTop.Text);
            List<string> s = Host.Instance.SegmentWords(txtContent.Text,GetSiteID, iNum, iTop);
            foreach (var a in s)
            { 
                llRz.Text += a+",";
            }
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!base.IsPostBack)
            {
                string s = EbSite.Base.Configs.SysConfigs.ConfigsControl.Instance.GetSearchEngineType(GetSiteID);
                llSearchPlugin.Text = string.IsNullOrEmpty(s) ? "系统默认" : s;

            }
        }

    }
}