using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.ControlPage;
using EbSite.Base.Modules;
using System.Data;

namespace EbSite.Modules.Shop.AdminPages.Controls.SelReport
{
    public partial class salereport : MPUCBaseShow<ModuleCore.Entity.Buy_Orders>
    {
        #region
        public override string PageName
        {
            get
            {
                return "生意报表";
            }
        }
        /// <summary>
        /// 是否添加到管理页面菜单之中
        /// </summary>
        public override bool IsAddToAdminMenus
        {
            get
            {
                return true;
            }
        }
        /// <summary>
        /// 权限全部
        /// </summary>
        public override string Permission
        {
            get
            {
                return "61";
            }
        }
     
        

        public override int OrderID
        {
            get
            {
                return 1;
            }
        }
        /// <summary>
        /// 菜单ID
        /// </summary>
        public override Guid ModuleMenuID
        {
            get
            {
                return new Guid("6fc17302-fdd8-4b8b-a618-d7da971162b5");
            }
        }

        protected override ModuleCore.Entity.Buy_Orders LoadModel()
        {
            throw new NotImplementedException();
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindMonthData();
                BindDayData();
            }
        }

        private void BindMonthData()
        {
            int year = EbSite.Core.Utils.StrToInt(this.ddl_YearMonth.SelectedValue, 2013);
            if (this.rdolist_month.SelectedValue.Equals("l"))
            {
                this.litTotalCount.Text = "总交易量";
                this.litHeightCount.Text = "最高峰交易量";
                this.litmonthtitle.Text = "交易量";
            }
            else if (this.rdolist_month.SelectedValue.Equals("e"))
            {
                this.litTotalCount.Text = "总交易额";
                this.litHeightCount.Text = "最高峰交易额";
                this.litmonthtitle.Text = "交易额";
            }
            else if (this.rdolist_month.SelectedValue.Equals("r"))
            {
                this.litTotalCount.Text = "总利润";
                this.litHeightCount.Text = "最高峰利润";
                this.litmonthtitle.Text = "利润";
            }

            int sumCount=0,maxCount = 0;
            DataTable dt = ModuleCore.BLL.Buy_Orders.Instance.GetOrderCount("m", year, this.rdolist_month.SelectedValue, out sumCount, out maxCount);
            if (dt != null)
            {
                this.rptDataList_Month.DataSource = dt;
                this.rptDataList_Month.DataBind();
            }
            this.litMonthSumCount.Text = sumCount.ToString();
            this.litMonthMaxCount.Text = maxCount.ToString();
        }

        protected void btnSeachMonth_Click(object sender, EventArgs e)
        {
            BindMonthData();
        }

        protected void btnSeachDay_Click(object sender, EventArgs e)
        {
            BindDayData();
        }

        private void BindDayData()
        {
            this.ddl_MonthDay.SelectedValue = DateTime.Now.Month.ToString();
            int year = EbSite.Core.Utils.StrToInt(string.Concat(this.ddl_YearMonth.SelectedValue,this.ddl_MonthDay.SelectedValue), 201301);
            if (this.rdoMonthDay.SelectedValue.Equals("l"))
            {
                this.litDayTotalCount.Text = "总交易量";
                this.litDayHeightCount.Text = "最高峰交易量";
                this.litDaytitle.Text = "交易量";
            }
            else if (this.rdoMonthDay.SelectedValue.Equals("e"))
            {
                this.litDayTotalCount.Text = "总交易额";
                this.litDayHeightCount.Text = "最高峰交易额";
                this.litDaytitle.Text = "交易额";
            }
            else if (this.rdoMonthDay.SelectedValue.Equals("r"))
            {
                this.litDayTotalCount.Text = "总利润";
                this.litDayHeightCount.Text = "最高峰利润";
                this.litDaytitle.Text = "利润";
            }

            int sumCount = 0, maxCount = 0;
            DataTable dt = ModuleCore.BLL.Buy_Orders.Instance.GetOrderCount("d", year, this.rdoMonthDay.SelectedValue, out sumCount, out maxCount);
            if (dt != null)
            {
                this.rptDataListDay.DataSource = dt;
                this.rptDataListDay.DataBind();
            }
            this.litDayTCount.Text = sumCount.ToString();
            this.litDayHCount.Text = maxCount.ToString();
        }

    }
}