using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base;
using EbSite.Base.ControlPage;

namespace EbSite.Web.AdminHt.Controls.Admin_WelCome
{
    public partial class ServerInfo : Base
    {
        public override string Permission
        {
            get
            {
                return "311";
            }
        }

        protected string GetContentCount
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                List<EbSite.Entity.ModelClass> list = EbSite.Base.Configs.Model.ConfigsControl.GetModelList(EbSite.BLL.WebModel.Instance.WebModelName, GetSiteID);
                foreach (EbSite.Entity.ModelClass md in list)
                {
                    string tbName = md.TableName;

                    if (!string.IsNullOrEmpty(tbName))
                    {
                       EbSite.BLL.NewsContentSplitTable bll =  AppStartInit.GetNewsContentInst(tbName);
                        sb.Append("<tr>");
                       sb.AppendFormat("<td class=\"header\">内容表:{0}</td>", tbName);
                       sb.AppendFormat("<td>{0}</td>", bll.GetCountByToday(GetSiteID));
                       sb.AppendFormat("<td>{0}</td>", bll.GetCountByWeek(GetSiteID));
                       sb.AppendFormat("<td>{0}</td>", bll.GetCountByMonth(GetSiteID));
                       sb.AppendFormat("<td>{0}</td>", bll.GetCountByQuarter(GetSiteID));
                       sb.AppendFormat("<td>{0}</td>", bll.GetCountByYear(GetSiteID));
                       sb.AppendFormat("<td>{0}</td>", bll.GetCountAll(GetSiteID));
                       sb.Append("</tr>");
                    }
                }
               
                return sb.ToString();
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}