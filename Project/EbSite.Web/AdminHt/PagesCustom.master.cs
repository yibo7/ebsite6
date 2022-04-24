using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using EbSite.Base;
using EbSite.BLL;

namespace EbSite.Web.AdminHt
{
    public partial class PagesCustom : BaseMaster
    { 
        //protected string GetRols
        //{
        //    get
        //    {
        //        StringBuilder sb = new StringBuilder();
        //        //EbSite.BLL.GetLink.HrefFactory.GetAspxInstance(GetSiteID).GetRemark()
        //        foreach (string role in ap.Roles)
        //        {
        //            sb.Append(role);
        //            sb.Append("|");
        //        }
        //        if (sb.Length > 1)
        //            sb.Remove(sb.Length - 1, 1);
        //        if (sb.Length == 0) return "未分配角色";
        //        return sb.ToString();
        //    }
        //}

        //protected AdminPrincipal ap;

        
        //public void MoneyOptionChanged(object sender, EventArgs e)
        //{
        //    //if (!string.IsNullOrEmpty(drpSites.SelectedValue))
        //    //{


        //    //    Core.Utils.WriteCookie("adminsiteid", drpSites.SelectedValue);

        //    //    Response.Redirect(Request.RawUrl);

        //    //}
        //    //else
        //    //{

        //    //    Base.Host.Instance.Tips("", "站点列表取值为空，操作错误");
        //    //}
        //}

        //protected Entity.Sites SiteModel;
        //protected void Page_Load(object sender, System.EventArgs e)
        //{
        //    if (!IsPostBack)
        //    {

        //        ap = AppStartInit.CheckAdmin();
        //        //llRoles.Text = GetRols;

        //        rpTopMenus.ItemDataBound += new RepeaterItemEventHandler(rpTopMenus_ItemBound);
        //        //Control.Repeater rpTopicReplies = e.Page.FindControl("rpTopicReplies") as Control.Repeater;
        //        var pMenus = BLL.Menus.Instance.GetMenusByParentID(Guid.Empty, Base.Host.Instance.UserName);

        //        SiteModel = Host.Instance.CurrentSite;

                

        //        rpTopMenus.DataSource = pMenus;
        //        rpTopMenus.DataBind();

        //        //rpTopMenusSub
        //        //drpSites.DataTextField = "SiteName";
        //        //drpSites.DataValueField = "id";

        //        List<Entity.Sites> ls = BLL.Sites.Instance.FillList();
        //        List<Entity.Sites> nls = (from i in ls orderby i.id ascending select i).ToList();
        //        rpSites.DataSource = nls;
        //        rpSites.DataBind();
        //        //drpSites.DataSource = nls;
        //        //drpSites.DataBind();
        //        //drpSites.SelectedValue = Base.Host.Instance.GetSiteID.ToString();

        //        //CurrentSiteName.Text = Base.Host.Instance.CurrentSite.SiteName;
        //        //if (IsHaveLimit("316"))//有没有管理站点的权限
        //        //{
        //        //    logoRight.Visible = true;
        //        //}
        //        //else
        //        //{
        //        //    logoRight.Visible = false;
        //        //}
        //        llVersion.Text = AppStartInit.ASSEMBLY_VERSION;


        //    }
        //}
        //protected void rpTopMenus_ItemBound(object sender, RepeaterItemEventArgs e)
        //{
             

        //    if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
        //    {
        //        Repeater rpContrent = e.Item.FindControl("rpTopMenusSub") as Repeater;
        //        if (!Equals(rpContrent, null))
        //        {
        //            Entity.Menus md = e.Item.DataItem as Entity.Menus;
        //            if (!Equals(md, null))
        //            {
        //                string sUsName = EbSite.Base.Host.Instance.UserName;
        //                List<Entity.Menus> plst = BLL.Menus.Instance.GetMenusByParentID(md.id, sUsName);
        //                rpContrent.DataSource = plst;
        //                rpContrent.DataBind();
        //            }

        //        }
                 

        //    }



        //}
        //protected void rpTopMenusSub_ItemDataBound(object sender, RepeaterItemEventArgs e)
        //{


        //    if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
        //    {
        //        Repeater rpContrent = e.Item.FindControl("rpTopMenusSubSub") as Repeater;
        //        if (!Equals(rpContrent, null))
        //        {
        //            Entity.Menus md = e.Item.DataItem as Entity.Menus;
        //            if (!Equals(md, null))
        //            {
        //                string sUsName = EbSite.Base.Host.Instance.UserName;
        //                List<Entity.Menus> plst = BLL.Menus.Instance.GetMenusByParentID(md.id, sUsName);

        //                if (md.id == new Guid("bb33d5ce-094a-420c-8bf7-dccb77524a6a"))
        //                {
        //                    Guid rmId = Guid.Empty;
        //                    if (SiteModel.IsClassContent) //是否分类内容化
        //                    {
        //                        rmId = new Guid("e93a5109-8da7-4342-9a97-288323a49379");
        //                    }
        //                    else
        //                    {
        //                        rmId = new Guid("eac8e169-ead9-485a-9dd3-e4ce31508fc4");
        //                    }
        //                    var mn = plst.First(x => x.id == rmId);
        //                    plst.Remove(mn);

        //                }


        //                rpContrent.DataSource = plst;
        //                rpContrent.DataBind();
        //            }

        //        }


        //    }



        //}

        //protected  bool IsHaveLimit(string LimitID)
        //{
        //    //AdminPrincipal user = AdminPrincipal.ValidateLogin(UserName);
        //    if (ap != null)
        //    {
        //        if (!string.IsNullOrEmpty(LimitID) && ap.HasPermissionID(int.Parse(LimitID)))
        //        {
        //            return true;
        //        }
        //    }

        //    return false;
        //}
       

        //protected void lbLogout_Click(object sender, EventArgs e)
        //{
        //    BLL.User.UserIdentity.SignOutAdmin();
        //    Base.AppStartInit.RedirectToIndex();
        //}
    }
}
