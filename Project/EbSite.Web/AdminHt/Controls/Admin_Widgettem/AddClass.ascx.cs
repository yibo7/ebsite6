using System;
using System.Collections;
using System.Configuration;
using System.Data;

using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using EbSite.Base.ControlPage;
using EbSite.Entity;

namespace EbSite.Web.AdminHt.Controls.Admin_Tem
{
    public partial class AddClass : UserControlBaseSave
    {
        public override string Permission
        {
            get
            {
                return "116";
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
            Entity.CtrTemClass cm = BLL.Ctrtem.TemClass.SelectCtrTemClasss(new Guid(SID));

            txtClassTitle.Text = cm.Title;
            txtClassInfo.Text = cm.Description;
           
        }

        override protected void SaveModel()
        {
            Entity.CtrTemClass mdNC = new CtrTemClass();

            mdNC.Title = txtClassTitle.Text;
            mdNC.Description = txtClassInfo.Text;

            if (!string.IsNullOrEmpty(SID)) //修改分类
            {
                mdNC.ID = new Guid(SID);
                BLL.Ctrtem.TemClass.UpdateCtrTemClasss(mdNC);
            }

            else    //添加一级分类
            {
                mdNC.ID = Guid.NewGuid();
                mdNC.AddDate = DateTime.Now;
                BLL.Ctrtem.TemClass.InsertCtrTemClasss(mdNC);
            }
        }

        //protected void Page_Load(object sender, EventArgs e)
        //{

        //    if (!IsPostBack)
        //    {
        //        InitModify();
        //    }


        //}
        //private Guid id
        //{
        //    get
        //    {
        //        if (!string.IsNullOrEmpty(Request["id"]))
        //        {
        //            return new Guid(Request["id"]);
        //        }
        //        return Guid.Empty;
        //    }
        //}

        //private void InitModify()
        //{
        //    if (id != Guid.Empty)
        //    {
        //        Entity.CtrTemClass cm = BLL.Ctrtem.TemClass.SelectCtrTemClasss(id);

        //        txtClassTitle.Text = cm.Title;
        //        txtClassInfo.Text = cm.Description;
        //    }
        //}


        //protected void btnAdd_Click(object sender, EventArgs e)
        //{

        //    Entity.CtrTemClass mdNC = new CtrTemClass();

        //    mdNC.Title = txtClassTitle.Text;
        //    mdNC.Description = txtClassInfo.Text;

        //    if (id != Guid.Empty) //修改分类
        //    {
        //        mdNC.ID = id;
        //        BLL.Ctrtem.TemClass.UpdateCtrTemClasss(mdNC);  
        //    }

        //    else    //添加一级分类
        //    {
        //        mdNC.ID = Guid.NewGuid();
        //        mdNC.AddDate = DateTime.Now;
        //        BLL.Ctrtem.TemClass.InsertCtrTemClasss(mdNC);
        //    }


        //}
    }
}