using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.ControlPage;
using EbSite.Base.Modules;
using EbSite.Core.FSO;
using EbSite.Entity;

namespace EbSite.Modules.UserBaseInfo.AdminPages.Controls.Splace
{
    public partial class ThemesList : MPUCBaseList
    {
        public override Guid ModuleMenuID
        {
            get
            {
                return new Guid("1c4b9237-eb79-478e-8735-6f5ea50d8d54");
            }
        }
        public override string PageName
        {
            get
            {
                return "皮肤列表";
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
                return 2;
            }
        }
        public override string Permission
        {
            get
            {
                return "3";
            }
        }
        public override string PermissionAddID
        {
            get
            {
                return "4";
            }
        }

        /// <summary>
        /// 修改数据的权限ID
        /// </summary>
        public override string PermissionModifyID
        {
            get
            {
                return "4";
            }
        }
        /// <summary>
        /// 删除数据的权限ID
        /// </summary>
        public override string PermissionDelID
        {
            get
            {
                return "4";
            }
        }

        override protected string AddUrl
        {
            get
            {
                return "t=0";
            }
        }
        //override protected string ShowUrl
        //{
        //    get
        //    {
        //        return "?&t=1&mid=" + ModuleID;
        //    }
        //}

        override protected object LoadList(out int iCount)
        {
            
            return BLL.SpaceThemes.Instance.GetListPages(pcPage.PageIndex, pcPage.PageSize, out iCount);
        }
        private string strWhere = "";
        //override protected SearchParameter[] GetSearchParameters
        //{
        //    get
        //    {
        //        List<SearchParameter> lstSp = new List<SearchParameter>();

        //        SearchParameter spModel = new SearchParameter();
        //        spModel.ColumnName = "ThemeName";
        //        spModel.ColumnValue = ucToolBar.GetItemVal(txtKeyWord).Trim();
        //        spModel.SearchWhere = EmSearchWhere.模糊匹配;
        //        if (string.IsNullOrEmpty(spModel.ColumnValue))
        //            TipsAlert("请输入关键词!");


        //        lstSp.Add(spModel);

        //        return lstSp.ToArray();
        //    }
        //}
        override protected object SearchList(out int iCount)
        {
            strWhere = BLL.SpaceThemes.Instance.StrWhere(ucToolBar.GetItemVal(txtKeyWord), ucToolBar.GetItemVal(ThemeClassID));
            return BLL.SpaceThemes.Instance.GetListPages(pcPage.PageIndex, pcPage.PageSize, GetWhere(true), "", out iCount);
        }
        override protected string BulderSearchWhere(bool IsValueEmpytNoSearch)
        {
            return string.Format(strWhere);
        }
        override protected void Delete(object iID)
        {
            //先要检测此皮肤有没有占用
            List<EbSite.Entity.SpaceSetting> ls = BLL.SpaceSetting.Instance.GetListArray("ThemeID=" + iID);
            if (ls.Count > 0)
            {
                base.Tips("提示", "此皮肤被占用，不能删除！");
            }
            else
            {
                //同时删除 home\themes\ 内容
                Entity.SpaceThemes md = EbSite.BLL.SpaceThemes.Instance.GetEntity(int.Parse(iID.ToString()));
                if (!Equals(md, null))
                {
                    string filename = md.ThemePath;
                    string Folder = HttpContext.Current.Server.MapPath("/home/themes/" + filename);
                    if (EbSite.Core.FSO.FObject.IsExist(Folder, FsoMethod.Folder))
                        EbSite.Core.FSO.FObject.Delete(Folder, FsoMethod.Folder);

                }
                EbSite.BLL.SpaceThemes.Instance.Delete(int.Parse(iID.ToString()));
            }
        }
        private void BindBankId()
        {
            ThemeClassID.DataTextField = "classname";
            ThemeClassID.DataValueField = "id";
            ThemeClassID.DataSource = EbSite.BLL.SpaceThemeClass.Instance.GetListArray("");
            ThemeClassID.DataBind();
        }

        #region 工具栏的初始化
        protected System.Web.UI.WebControls.Label LbKey = new Label();
        protected System.Web.UI.WebControls.TextBox txtKeyWord = new System.Web.UI.WebControls.TextBox();
        protected System.Web.UI.WebControls.Label LbName = new Label();
        protected System.Web.UI.WebControls.DropDownList ThemeClassID = new DropDownList();

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
            LbName.Text = "皮肤分类";
            ucToolBar.AddCtr(LbName);
            ThemeClassID.ID = "ThemeClassID";
            BindBankId();
            ucToolBar.AddCtr(ThemeClassID);

            base.ShowCustomSearch("查询");

            //ucToolBar.AddBnt("高级", "images/MenuImg/Search-Add.gif", "", false, "OpenDialog_Save('divSearh',OnSearch)");

            ucToolBar.AddBnt("载入皮肤", IISPath + "images/menus/plugins.png", "addThemes", true, "return confirm('确认要进行此操作吗？');", "如果存在同名皮肤将不再添加");


        }
        #endregion

        #region 工具栏事件扩展

        protected override void ucToolBar_ItemClick(object source, Control.ItemClickArgs e)
        {
            base.ucToolBar_ItemClick(source, e);
            switch (e.ItemTag)
            {
                case "addThemes":

                    #region 生成新的皮肤文件夹 把复制的皮肤文件Copy ThemePath.text 中
                    //得到路径文件夹
                    string url = HttpContext.Current.Server.MapPath(IISPath + "home/themes/");
                    
                    List<string> ls = Core.Utils.GetFolder(HttpContext.Current.Server.MapPath(IISPath + "home/themes/"));
           
                    for (int i = 0; i < ls.Count; i++)
                    {
                        //先要检测有没有录过
                        List<Entity.SpaceThemes> list = BLL.SpaceThemes.Instance.GetListArray("ThemeName='"+ls[i]+"'");
                        if (list.Count > 0)
                        {

                        }
                        else
                        {
                            EbSite.Entity.SpaceThemes md = new SpaceThemes();
                            md.ThemeName = ls[i]; // 文件名称 ThemeName.Text;
                            md.ThemePath = ls[i]; //文件的路径 ThemePath.Text;
                            md.Author = Base.Host.Instance.UserName; //Author.Text;
                            md.UserID = UserID;
                            md.AddTime = DateTime.Now;
                            md.ThemeClassID = 1;
                            md.UserGroupID = 1;
                            BLL.SpaceThemes.Instance.Add(md);
                            
                        }
                    }
                    #endregion
                    break;
            }
        }

        #endregion

        #region 得到皮肤分类的名称 yhl 2012-01-04
        public static string SpaceThemeName(int id)
        {
            string na = "";
            if(id==0)
            {
                return na = "";
            }
            else
            {
                na = EbSite.BLL.SpaceThemeClass.Instance.GetEntity(id).ClassName;
                return na;
            }
        }
        #endregion
    }
}