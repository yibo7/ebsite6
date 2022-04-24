using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.ControlPage;

namespace EbSite.Web.AdminHt.Controls.Admin_Spider
{
    public partial class VisitSum : UserControlListBase
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
            iCount = 0;
            return BLL.spiderlog.Instance.GetVisitSum("",100);
        }

        protected override string BulderSearchWhere(bool IsValueEmpytNoSearch)
        {
            string sStateDate = ucToolBar.GetItemVal(dtStart);
            string sEndDate = ucToolBar.GetItemVal(dtEnd);
            int iSpiderId = int.Parse(ucToolBar.GetItemVal(drpSpider)); 
            string sWhere = string.Format("AddDateTimeInt > UNIX_TIMESTAMP('{0} 00:00:01') and AddDateTimeInt<UNIX_TIMESTAMP('{1} 23:59:59')  ", sStateDate, sEndDate);

            if (iSpiderId > 0)
            {
                sWhere = string.Concat(sWhere, " AND SpiderId=", iSpiderId);

            }
           
            return sWhere;
        }

        override protected object SearchList(out int iCount)
        {
            iCount = 0;
            int iTop = int.Parse(ucToolBar.GetItemVal(txtTop));
            return BLL.spiderlog.Instance.GetVisitSum(base.GetWhere(true), iTop);
              
        }
        override protected void Delete(object iID)
        {
            //BLL.IISLOG.SpiderBll.Instance.Delete(int.Parse(iID.ToString()));

        }
        protected Control.DropDownList drpSpider = new Control.DropDownList();
        protected Control.DatePicker dtStart = new Control.DatePicker();
        protected Control.DatePicker dtEnd = new Control.DatePicker();
        protected Control.TextBox txtTop = new Control.TextBox();
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

            lb = new Label();
            lb.Text = "获取记录数:";
            lb.ID = "lbVUrl";
            
            ucToolBar.AddCtr(lb);

            txtTop.ID = "txtTop";
            txtTop.Text = "100";
            ucToolBar.AddCtr(txtTop);

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