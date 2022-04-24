using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.ControlPage;

namespace EbSite.Web.AdminHt.Controls.Admin_Spider
{
    public partial class VisitInfo : UserControlListBase
    {
        #region 权限

        public override string Permission
        {
            get
            {
                return "163";
            }
        }
        /// <summary>
        /// 删除数据的权限ID
        /// </summary>
        public override string PermissionDelID
        {
            get
            {
                return "163";
            }
        }
        /// <summary>
        /// 添加数据的权限ID
        /// </summary>
        public override string PermissionAddID
        {
            get
            {
                return "163";
            }
        }
        /// <summary>
        /// 修改数据权限ID
        /// </summary>
        public override string PermissionModifyID
        {
            get
            {
                return "163";
            }
        }
        #endregion

        override protected string AddUrl
        {
            get
            {
                return "t=1";
            }
        }
        override protected object LoadList(out int iCount)
        { 
            return BLL.spiderlog.Instance.GetListPages(pcPage.PageIndex, pcPage.PageSize, out iCount);
        }

        protected override string BulderSearchWhere(bool IsValueEmpytNoSearch)
        {
            string sStateDate = ucToolBar.GetItemVal(dtStart);
            string sEndDate = ucToolBar.GetItemVal(dtEnd);
            int iSpiderId = int.Parse(ucToolBar.GetItemVal(drpSpider));
            int iHttpState = int.Parse(ucToolBar.GetItemVal(drpHttpState));
            string sUrl = ucToolBar.GetItemVal(txtUrl).Trim();
            string sWhere = string.Format("AddDateTimeInt > UNIX_TIMESTAMP('{0} 00:00:01') and AddDateTimeInt<UNIX_TIMESTAMP('{1} 23:59:59')  ", sStateDate, sEndDate);

            if (iSpiderId > 0)
            {
                sWhere = string.Concat(sWhere, " AND SpiderId=", iSpiderId);

            }
            if (iHttpState > 0)
            {
                sWhere = string.Concat(sWhere, " AND HttpState=", iHttpState);

            }
            if (!string.IsNullOrEmpty(sUrl))
            {
                sWhere = string.Concat(sWhere, " AND Url='", sUrl, "'");
            }
            return sWhere;
        }

        override protected object SearchList(out int iCount)
        { 
            return BLL.spiderlog.Instance.GetListPages(pcPage.PageIndex, pcPage.PageSize, base.GetWhere(true), "", out iCount);
              
        }
        override protected void Delete(object iID)
        {
            //BLL.IISLOG.SpiderBll.Instance.Delete(int.Parse(iID.ToString()));

        }
        protected Control.DropDownList drpSpider = new Control.DropDownList();
        protected Control.DropDownList drpHttpState = new Control.DropDownList();
        protected Control.DatePicker dtStart = new Control.DatePicker();
        protected Control.DatePicker dtEnd = new Control.DatePicker();
        protected Control.TextBox txtUrl = new Control.TextBox();
        override protected void BindToolBar()
        {

            base.BindToolBar(true, true, true, true, false);

            Label lb = new Label();
            lb.Text = "开始时间:";
            lb.ID = "lbStart";
            ucToolBar.AddCtr(lb);
            dtStart.Value = DateTime.Now.ToString();
            dtStart.ID = "dtStart";
            ucToolBar.AddCtr(dtStart);


              lb = new Label();
            lb.Text = "结束时间:";
            lb.ID = "lbEnd";
            ucToolBar.AddCtr(lb);
            dtEnd.Value = DateTime.Now.ToString();
            dtEnd.ID = "dtEnd";
            ucToolBar.AddCtr(dtEnd);
            ucToolBar.AddLine();

            drpSpider.Items.Add(new ListItem("所有爬虫", "0"));
            drpSpider.AppendDataBoundItems = true;
            drpSpider.DataTextField = "SpiderCnName";
            drpSpider.DataValueField = "ID";
            drpSpider.DataSource = BLL.IISLOG.SpiderBll.Instance.FillList();
            drpSpider.DataBind();
            drpSpider.ID = "drpSpider";
            ucToolBar.AddCtr(drpSpider);

            drpHttpState.ID = "drpHttpState";
            ListItem liIt = new ListItem("所有状态", "0");
            drpHttpState.Items.Add(liIt);

            liIt = new ListItem("404", "404");
            drpHttpState.Items.Add(liIt);

            liIt = new ListItem("500", "500");
            drpHttpState.Items.Add(liIt);

            liIt = new ListItem("200", "200");
            drpHttpState.Items.Add(liIt);

            ucToolBar.AddCtr(drpHttpState);

            lb = new Label();
            lb.Text = "访问地址:";
            lb.ID = "lbVUrl";
            ucToolBar.AddCtr(lb);

            txtUrl.ID = "txtUrl";
            ucToolBar.AddCtr(txtUrl);

            ucToolBar.AddBnt("查询", string.Concat(IISPath, "images/Menus/Search.gif"), "search");

          
             

        } 

        //protected override void ucToolBar_ItemClick(object source, Control.ItemClickArgs e)
        //{
        //    base.ucToolBar_ItemClick(source, e);
        //    switch (e.ItemTag)
        //    {
        //        case "good":
                    
        //            gdList_Bind();
        //            break;
             
        //    }
        //}

    }
}