using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.Modules;
using EbSite.Entity;

namespace EbSite.Modules.UserBaseInfo.AdminPages.Controls.Splace
{
    public partial class DefaultTabList : MPUCBaseList
    {
        public override string PageName
        {
            get
            {
                return "默认空间标签";
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
        public override int OrderID
        {
            get
            {
                return 4;
            }
        }
        public override string Permission
        {
            get
            {
                return "5";
            }
        }
        public override string PermissionAddID
        {
            get
            {
                return "6";
            }
        }

        /// <summary>
        /// 修改数据的权限ID
        /// </summary>
        public override string PermissionModifyID
        {
            get
            {
                return "6";
            }
        }
        /// <summary>
        /// 删除数据的权限ID
        /// </summary>
        public override string PermissionDelID
        {
            get
            {
                return "6";
            }
        }

        override protected string AddUrl
        {
            get
            {
                return "t=4";
            }
        }
        protected string InitWidgetsUrl(object id)
        {

            return string.Concat(GetUrl, "&t=7&id=", id);

        }
        public override Guid ModuleMenuID
        {
            get
            {
                return new Guid("848de1a0-98e7-40fd-99da-2918586d623a");
            }
        }


        override protected object LoadList(out int iCount)
        {
            iCount = 0;
            return EbSite.BLL.SpaceTabsDefault.Instance.FillList();
        }

        override protected object SearchList(out int iCount)
        {
            iCount = 0;
            List<Entity.SpaceTabsDefault> NLs = new List<SpaceTabsDefault>();
            List<Entity.SpaceTabsDefault> ls = EbSite.BLL.SpaceTabsDefault.Instance.FillList();
            string tkey = ucToolBar.GetItemVal(txtKeyWord);

            NLs = (from li in ls
                   where
                      ("" == tkey || (li.TabName == ucToolBar.GetItemVal(txtKeyWord))) &&
                       (li.UserGroupID == int.Parse(ucToolBar.GetItemVal(UserGroupID)))
                   select li
                                                   ).ToList();
            return NLs;
        }
        override protected void Delete(object iID)
        {
            EbSite.BLL.SpaceTabsDefault.Instance.Delete(new Guid(iID.ToString()));
        }

        private void BindBankId()
        {
            UserGroupID.AppendDataBoundItems = true;
            UserGroupID.Items.Insert(0, new ListItem("所有用户", "0"));
            UserGroupID.DataTextField = "groupname";
            UserGroupID.DataValueField = "id";
            UserGroupID.DataSource = EbSite.BLL.User.UserGroupProfile.UserGroupProfiles;
            UserGroupID.DataBind();
        }
        #region 工具栏的初始化
        protected System.Web.UI.WebControls.Label LbKey = new Label();
        protected System.Web.UI.WebControls.TextBox txtKeyWord = new System.Web.UI.WebControls.TextBox();
        protected System.Web.UI.WebControls.Label LbName = new Label();
        protected System.Web.UI.WebControls.DropDownList UserGroupID = new DropDownList();
        override protected void BindToolBar()
        {

            base.BindToolBar();
            ucToolBar.AddLine();
            LbKey.ID = "LbKey";
            LbKey.Text = "标签名称";
            ucToolBar.AddCtr(LbKey);
            txtKeyWord.ID = "txtKeyWord";
            ucToolBar.AddCtr(txtKeyWord);

            LbName.ID = "LbName";
            LbName.Text = "用户组";
            ucToolBar.AddCtr(LbName);
            UserGroupID.ID = "UserGroupID";
            BindBankId();
            ucToolBar.AddCtr(UserGroupID);
            base.ShowCustomSearch("查询");

            ucToolBar.AddBnt("将标签更新到所有用户网站下", IISPath + "images/menus/application_cascade.png", "savetouser", true, "return confirm('确认要进行此操作吗？');", "这个操作比较危险，更改后所有用户将添加以下标签,如果存在同名标签将不再添加");



        }
        #endregion

        #region 工具栏事件扩展

        protected override void ucToolBar_ItemClick(object source, Control.ItemClickArgs e)
        {
            base.ucToolBar_ItemClick(source, e);
            switch (e.ItemTag)
            {
                case "savetouser":
                    // base.ShowTipsPop("开发中");
                    List<Entity.SpaceTabs> OldLs = BLL.SpaceTabs.Instance.GetListArray(0, "", " ");
                    var Nls = (from o in OldLs select o.UserID).ToList().Distinct();
                    foreach (var nl in Nls)
                    {
                        CompleteTag(nl);
                    }
                    break;
            }
        }

        #endregion

        #region 得到用户组名称 yhl 2012-01-04
        public static string UserGroupName(int GroupID)
        {
            if (GroupID == 0)
            {
                return "所有用户";
            }
            string na = EbSite.BLL.User.UserGroupProfile.GetUserGroupProfile(GroupID).GroupName;
            return na;
        }
        #endregion

        #region 通过用户ID 查到用户组ID
        /// <summary>
        /// 
        /// </summary>
        /// <param name="uid">用户ID</param>
        private void CompleteTag(int uid)
        {
            //int GroupId = EbSite.Base.Host.Instance.CurrentFirstGroup.Id;//用户组id
            int GroupId = EbSite.Base.AppStartInit.RoleID;
            List<Entity.SpaceTabsDefault> ls = EbSite.BLL.SpaceTabsDefault.Instance.FillList();

            //得到用户组下的所有标签
            List<Entity.SpaceTabsDefault> NLs = (from li in ls
                                                 where
                                                (li.UserGroupID == GroupId) || (li.UserGroupID == 0)
                                                 select li).ToList();
            //然后去匹配 原有的标签
            List<Entity.SpaceTabs> OldLs = BLL.SpaceTabs.Instance.GetListArray(0, "UserID=" + uid, " OrderNum asc");
            int i = (from o in OldLs select o).Last().OrderNum + 1;//排序 ID
            foreach (Entity.SpaceTabsDefault spaceTabse in NLs)
            {
                if (IsExist(OldLs, spaceTabse.TabName))
                {
                    Entity.SpaceTabs md = new SpaceTabs();
                    md.TabName = spaceTabse.TabName;//标签名称
                    md.Layout = spaceTabse.Layout;//版式
                    md.UserID = uid;
                    md.ParentID = 0;
                    md.OrderNum = i;
                    int tabid = md.Add();

                    //还在把标签下对应的部件给批量的添加进去
                    //spaceTabse.id   默认标签的ID
                    List<Entity.SpaceTabDefaultWidgetInfo> ols = BLL.SpaceTabDefaultWidget.Instance.FillList();
                    List<Entity.SpaceTabDefaultWidgetInfo> nls = (from c in ols where c.TabId == spaceTabse.id select c).ToList();

                    foreach (Entity.SpaceTabDefaultWidgetInfo il in nls)
                    {
                        Entity.SpaceTabWidget wmd = new SpaceTabWidget();
                        wmd.TabID = tabid;
                        wmd.WidgetID = il.WidgetsID;
                        wmd.LayoutPane = il.LayoutPane;
                        wmd.UserID = uid;
                        wmd.OrderNum = 0;
                        BLL.SpaceTabWidget.Instance.Add(wmd);
                    }


                    i++;
                }
            }



        }
        private bool IsExist(List<Entity.SpaceTabs> OldLs, string TabName)
        {
            bool k = false;
            List<Entity.SpaceTabs> nlis =
                (from c in OldLs where c.TabName == TabName && c.ParentID == 0 select c).ToList();
            if (nlis.Count > 0)
            {

            }
            else
            {
                k = true;
            }
            return k;
        }
        #endregion
    }
}