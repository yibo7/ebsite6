using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.Page;

namespace EbSite.Web.AdminHt.Controls.Admin_Modules
{
    public partial class Online : BaseList
    {
        public override string Permission
        {
            get
            {
                return "1";
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!IsPostBack)
            //{
            //    BLL.Update.UpdateBll ub = new UpdateBll();
            //    int iC = 0;
            //    gdList.DataSource = ub.GetModules(pcPage.PageIndex, pcPage.PageSize, "", "", out iC);
            //    gdList.DataBind();
            //    pcPage.AllCount = iC;
            //    pcPage.PageSize = 15;

            //}
        }
        protected override string AddUrl
        {
            get { throw new NotImplementedException(); }
        }
        protected override void Delete(object ID)
        {
            throw new NotImplementedException();
        }
        protected override object LoadList(out int iCount)
        {
            iCount = 0;
            return null;
        }
        protected override object SearchList(out int iCount)
        {
            iCount = 0;
            return null;
        }
        #region 初使化工具条
        protected System.Web.UI.WebControls.TextBox txtKeyWord = new System.Web.UI.WebControls.TextBox();
        protected System.Web.UI.WebControls.DropDownList lbType = new System.Web.UI.WebControls.DropDownList();
        override protected void BindToolBar()
        {
            base.BindToolBar(true, true, true, true,false);
            lbType.ID = "lbType";
            ListItem liIt = new ListItem("模块名称", "title");
            lbType.Items.Add(liIt);
            liIt = new ListItem("模块简介", "content");
            lbType.Items.Add(liIt);
            ucToolBar.AddCtr(lbType);
            txtKeyWord.ID = "txtKeyWord";
            txtKeyWord.Attributes.Add("style","width:130px");
            ucToolBar.AddCtr(txtKeyWord);
            base.ShowCustomSearch("查询");
        }
        #endregion
    }
}