using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.ControlPage;
using EbSite.BLL;
using EbSite.BLL.ModelBll;
using EbSite.Base.ControlPage;
using EbSite.Entity;

namespace EbSite.Web.AdminHt.dialog.Controls.dialog
{
    public partial class UserField : UserControlListBase
    {
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
            throw new NotImplementedException();
        }
        public int iClassCount = 0;
        private ModelBase<BLL.User.UserProfile> bllModel;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bllModel = new UserModel(GetSiteID);
                List<Entity.ModelClass> ls = bllModel.ModelClassList;
                RepUserModel.DataSource = ls;
                RepUserModel.DataBind();
                iClassCount = ls.Count;


                RepUserAll.DataSource = ls;
                RepUserAll.DataBind();
            }
        }

        public void rpList_ItemDataBound(object sender, System.Web.UI.WebControls.RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Entity.ModelClass drData = (Entity.ModelClass)e.Item.DataItem;
                Guid GID = drData.ID;
                Control.Repeater rpListEx = e.Item.Controls[0].FindControl("RepUserField") as Control.Repeater;
                if (!Equals(rpListEx, null))
                {
                    ModelClass mc = bllModel.GeModelByID(GID);
                    rpListEx.DataSource = mc.GetUsedFileds();
                    rpListEx.DataBind();
                }
            }
        }
       
    }
}