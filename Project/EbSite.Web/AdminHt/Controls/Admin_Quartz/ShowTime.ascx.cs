using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.ControlPage;
using EbSite.BLL.GetLink;
using EbSite.BLL.Jobs;
using EbSite.Entity;

namespace EbSite.Web.AdminHt.Controls.Admin_Quartz
{
    public partial class ShowTime : UserControlBaseShow<Entity.JobTask>
    {
        protected string GetRunTime
        {
            get
            {
                string sExpression = Model.CronExpressionString;

                List<DateTime> list = QuartzHelper.GetNextFireTime(sExpression, 10);

                StringBuilder sb = new StringBuilder();
                foreach (var time in list)
                {
                    //sb.AppendFormat("<h3>{0}</h3><br/>", time);
                    sb.AppendFormat("<h3>{0} {1}</h3><br/>", time.ToLongDateString(), time.ToLongTimeString());
                }
                return sb.ToString();

            }
        }
        protected override JobTask LoadModel()
        {
            
            return BLL.JobTask.Instance.GetEntity(new Guid(GetKeyID));
        }
    }
}