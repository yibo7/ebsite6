using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.Modules;
using EbSite.Control;
using DropDownList = System.Web.UI.WebControls.DropDownList;

namespace EbSite.Modules.UserBaseInfo.UserPages.Controls.AccountMoney
{
    public partial class BalanceDetails : MPUCBaseListForUserRp
    {
        //public override bool IsCloseTagsTitle
        //{
        //    get
        //    {
        //        return true;
        //    }
        //}
        public override int OrderID
        {
            get
            {
                return 3;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                 if (!EbSite.Base.Host.Instance.IsOpenBalance(base.UserID))
                {
                    //没有开启 预付款功能
                    Response.Redirect(EbSite.Base.Host.Instance.GetOpenBalance);

                }
               
            }
        }
        public override Guid ModuleMenuID
        {
            get
            {
                return new Guid("bcf359d4-99f8-458b-b7c2-6e8edbc274fc");
            }
        }
        public override string PageName
        {
            get
            {
                return "预付款收支流水";
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
        /// 此权限ID不为空，将要求用户登录后才能访问此页面
        /// </summary>
        public override string Permission
        {
            get
            {
                return "7";
            }
        }

      

        override protected object LoadList(out int iCount)
        {
            return EbSite.BLL.AccountMoneyLog.Instance.GetListPages(this.pcPage.PageIndex, pcPage.PageSize, "userid=" + base.UserID, "TradeDate desc", out  iCount);
        }
        public string StrSqlWhere = "";
        override protected object SearchList(out int iCount)
        {

            string Timestart = ucToolBar.GetItemVal(DateCtr);
            string TimeEnd = ucToolBar.GetItemVal(DateCtrEnd);
            string typeid = ucToolBar.GetItemVal(dropDB);
            StrSqlWhere = BLL.AccountMoneyLog.Instance.StrWhere(Timestart, TimeEnd, typeid,base.UserID);
            return EbSite.BLL.AccountMoneyLog.Instance.GetListPages(pcPage.PageIndex, pcPage.PageSize, base.GetWhere(true), "TradeDate desc", out iCount);
        }
        override protected string BulderSearchWhere(bool IsValueEmpytNoSearch)
        {
            return string.Format(StrSqlWhere);
        }
        override protected void Delete(object iID)
        {

        }

        protected void BindDrop()
        {
            dropDB.DataSource = EbSite.BLL.AccountMoneyType.GetAccountMoneyTypes();
            dropDB.DataTextField = "Text";
            dropDB.DataValueField = "ID";
            dropDB.DataBind();
            
        }
        #region 工具栏的初始化

        protected Label LbTime = new Label();
      
        protected EbSite.Control.DatePicker DateCtr = new DatePicker();
        protected EbSite.Control.DatePicker DateCtrEnd = new DatePicker();
        protected Label LbTimeEnd = new Label();

        protected Label LbLX = new Label();
        protected DropDownList dropDB = new DropDownList();
        override protected void BindToolBar()
        {

            base.BindToolBar(true);
            LbTime.ID = "LbTime";
            LbTime.Text = "起始时间";
            ucToolBar.AddCtr(LbTime);

            DateCtr.ID = "DateCtr";
            
            ucToolBar.AddCtr(DateCtr);

            LbTimeEnd.ID = "LbTimeEnd";
            LbTimeEnd.Text = "结束时间";
            ucToolBar.AddCtr(LbTimeEnd);

            DateCtrEnd.ID = "DateCtrEnd";
            ucToolBar.AddCtr(DateCtrEnd);


            LbLX.ID = "LbLX";
            LbLX.Text = "类型";
            ucToolBar.AddCtr(LbLX);

            dropDB.ID = "dropDB";
            BindDrop();
            ucToolBar.AddCtr(dropDB);
           // ucToolBar.AddDDownListOnchange(DropIsYear, "swnr");
            ucToolBar.AddBnt("查询", IISPath + "images/menus/Search.gif", "search");


        }
        #endregion

        #region 工具栏事件扩展

        protected override void ucToolBar_ItemClick(object source, Control.ItemClickArgs e)
        {
            base.ucToolBar_ItemClick(source, e);
            switch (e.ItemTag)
            {
                case "good":
                    break;
            }
        }

        #endregion
    }
}