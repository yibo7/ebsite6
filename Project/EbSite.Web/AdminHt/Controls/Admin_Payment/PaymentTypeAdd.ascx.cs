using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.ControlPage;
using EbSite.Entity;

namespace EbSite.Web.AdminHt.Controls.Admin_Payment
{
    public partial class PaymentTypeAdd : UserControlBaseSave
    {
        public override string Permission
        {
            get
            {
                return "159";
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
           
            Entity.PayTypeInfo model = BLL.PayTypeInfo.Instance.GetEntity(int.Parse(SID));
            this.Name.Text = model.Name;
            this.OrderID.Text = model.OrderID.ToString();
            this.Demo.Text = model.Demo.ToString();
            //List<Entity.PayTypeInfo> s = BLL.PayTypeInfo.Instance.GetSalesTeamTree(0);
            //ParentID.DataSource = s;
            //ParentID.DataTextField = "Name";
            //ParentID.DataValueField = "id";
            //ParentID.DataBind();
            //ParentID.Items.Insert(0, new ListItem("根目录", "0"));
            //ParentID.SelectedValue = model.ParentID.ToString();
        }
        override protected void SaveModel()
        {
            if (string.IsNullOrEmpty(SID))
            {
                Entity.PayTypeInfo md = new PayTypeInfo();
                md.Name = Name.Text.Trim();
                md.ParentID = 0;
                md.Demo = Demo.Text;
                md.OrderID = int.Parse(OrderID.Text);
                //if (ParentID.SelectedValue == "")
                //{
                //    md.ParentID = 0;
                //}
                //else
                //{
                //    md.ParentID = int.Parse(ParentID.SelectedValue);
                //}
                BLL.PayTypeInfo.Instance.Add(md);
            }
            else
            {
                Entity.PayTypeInfo model = BLL.PayTypeInfo.Instance.GetEntity(int.Parse(SID));
                model.Name = this.Name.Text;
                model.ParentID = 0;
                model.Demo = Demo.Text;
                model.OrderID = int.Parse(OrderID.Text);
                //if (ParentID.SelectedValue == "")
                //{
                //    model.ParentID = 0;
                //}
                //else
                //{
                //    model.ParentID = int.Parse(ParentID.SelectedValue);
                //}
                BLL.PayTypeInfo.Instance.Update(model);
            }

            // BLL.PayTypeInfo.Instance.SaveEntityFromCtr(phCtrList, null);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (string.IsNullOrEmpty(SID))
                //BindSiteDrpList();
        }
        ///// <summary>
        ///// 父级站点
        ///// </summary>
        //private void BindSiteDrpList()
        //{
        //    List<Entity.PayTypeInfo> s = BLL.PayTypeInfo.Instance.GetSalesTeamTree(0);
        //    ParentID.DataSource = s;
        //    ParentID.DataTextField = "Name";
        //    ParentID.DataValueField = "id";
        //    ParentID.DataBind();
        //    ParentID.Items.Insert(0, new ListItem("根目录", "0"));

        //}
    }
}