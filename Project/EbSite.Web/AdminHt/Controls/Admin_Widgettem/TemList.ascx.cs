using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using EbSite.Base.ControlPage;
using EbSite.Core.FSO;
using EbSite.Entity;

namespace EbSite.Web.AdminHt.Controls.Admin_Ctrtem
{
    public partial class TemList : UserControlListBase
    {
        public override string Permission
        {
            get
            {
                return "118";
            }
        }
        public override string PermissionAddID
        {
            get
            {
                return "119";
            }
        }
        /// <summary>
        /// 修改数据的权限ID
        /// </summary>
        public override string PermissionModifyID
        {
            get
            {
                return "182";
            }
        }
        /// <summary>
        /// 删除数据的权限ID
        /// </summary>
        public override string PermissionDelID
        {
            get
            {
                return "219";
            }
        }
        override protected string AddUrl
        {
            get
            {
                return "t=3";
            }
        }
        public string iTemTpID
        {
            get
            {
                if (!string.IsNullOrEmpty(Request.QueryString["ttp"]))
                    return Request.QueryString["ttp"];
                else
                    return "";
            }

        }

        override protected object LoadList(out int iCount)
        {
            iCount = 0;
            List<CtrTemList> lstRz = new List<CtrTemList>();
            List<CtrTemList> list = BLL.Ctrtem.TemListInstace.TemBll(GetSiteID).SelectCtrTemLists_ByClassID(ClassID);

            if (!"".Equals(iTemTpID))
            {
                foreach (var ctrTem in list)
                {
                    if (ctrTem.ClassId.ToString().Equals(iTemTpID))
                    {
                        lstRz.Add(ctrTem);
                    }
                }
            }
            else
            {
                lstRz = list;
            }
            return lstRz;
        }

        override protected object SearchList(out int iCount)
        {
            iCount = 0;
            List<Entity.CtrTemList> lstRz = new List<Entity.CtrTemList>();
            List<Entity.CtrTemList> lst = BLL.Ctrtem.TemListInstace.TemBll(GetSiteID).SelectCtrTemLists_ByClassID(ClassID);
            string sKeyTitle = ucToolBar.GetItemVal(txtOne).Trim();

            if (!string.IsNullOrEmpty(sKeyTitle))
            {
                foreach (Entity.CtrTemList item in lst)
                {
                    if (item.Title.IndexOf(sKeyTitle) > -1)
                    {
                        lstRz.Add(item);
                    }
                }
            }
            else
            {
                lstRz = lst;
            }

            return lstRz; 
        }
        override protected void Delete(object iID)
        {
            BLL.Ctrtem.TemListInstace.TemBll(GetSiteID).DeleteCtrTemLists(new Guid(iID.ToString()));

        }
        private Guid ClassID
        {
            get
            {
                if(!string.IsNullOrEmpty(Request["cid"]))
                {
                    return new Guid(Request["cid"]);
                }
                return Guid.Empty;
            }
        }

        protected Label lblTemName = new Label();
        protected Control.TextBox txtOne = new Control.TextBox();
        protected Control.DropDownList drpTemTp = new Control.DropDownList();
        protected override void BindToolBar()
        {
            base.BindToolBar();

            ucToolBar.AddLine();

            lblTemName.ID = "lblTemName";
            lblTemName.Text = "模板名称：";
            ucToolBar.AddCtr(lblTemName);

            txtOne.ID = "txtKeyWord";
            ucToolBar.AddCtr(txtOne);

            base.ShowCustomSearch("查询");

            ucToolBar.AddLine();

            drpTemTp.ID = "drpTemTp";
            ucToolBar.AddCtr(drpTemTp);
            drpTemTp.AppendDataBoundItems = true;
            ListItem temItem = new ListItem("-----模板类别-----", "");
            drpTemTp.Items.Add(temItem);
            drpTemTp.DataTextField = "Title";
            drpTemTp.DataValueField = "ID";
            drpTemTp.Attributes.Add("onchange", "OnTemTpChange(this)");
            drpTemTp.DataSource = BLL.Ctrtem.TemClass.FillCtrTemClasss();
            drpTemTp.DataBind();
            
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ucToolBar.SetItemVal(drpTemTp, iTemTpID);
            }
        }
        override protected void gdList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            base.gdList_RowCommand(sender, e);
            if (Equals(e.CommandName, "CopyData"))
            {
                Guid id = new Guid(e.CommandArgument.ToString());

                Entity.CtrTemList cmCopy = BLL.Ctrtem.TemListInstace.TemBll(GetSiteID).SelectCtrTemLists(id);

                cmCopy.ID = Guid.NewGuid();
                cmCopy.Title = string.Concat("复制-", cmCopy.Title);
                cmCopy.AddDate = DateTime.Now;
                cmCopy.TemContent = BLL.Ctrtem.TemListInstace.TemBll(GetSiteID).GetATemFileContent(id);

                BLL.Ctrtem.TemListInstace.TemBll(GetSiteID).InsertCtrTemLists(cmCopy);

                base.gdList_Bind();
            }
        }

    }
}