using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.IO;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.MobileControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using EbSite.Base.ControlPage;
using System.Collections.Generic;
using EbSite.Entity;


namespace EbSite.Web.AdminHt.Controls.Admin_Data
{
    public partial class CacheManage : UserControlListBase
    {
       

        #region 权限

        public override string Permission
        {
            get
            {
                return "287";
            }
        }
        /// <summary>
        /// 删除数据的权限ID
        /// </summary>
        public override string PermissionDelID
        {
            get
            {
                return "287";
            }
        }

        #endregion
         
        override protected string AddUrl
        {
            get
            {
                return "";
            }
        }
        override protected object LoadList(out int iCount)
        {
            iCount = 0; 
            List<Entity.ListItemModel> lst = new List<Entity.ListItemModel>();
            List<string> ls= EbSite.Base.Host.CacheApp.GetCacheKeys; //EbSite.Core.CacheManager.GetAllCacheList;
            foreach (var l in ls)
            {
                Entity.ListItemModel m=new ListItemModel(l,"");
                lst.Add(m);
            }
            return lst;
        }


        override protected object SearchList(out int iCount)
        {
            iCount = 0;
            return null;
        }
        override protected void Delete(object iID)
        {
           EbSite.Base.Host.CacheApp.Remove("",iID.ToString());  //EbSite.Core.CacheManager.RemoveACache(iID.ToString());

        }

        #region 工具栏的初始化
        override protected void BindToolBar()
        {

            base.BindToolBar();
            ucToolBar.AddLine();

            //txtKeyWord.ID = "txtKeyWord";
            //ucToolBar.AddCtr(txtKeyWord);
            
            //base.ShowCustomSearch("清除所有缓存");
            //ucToolBar.AddBnt("清除所有缓存", string.Concat(IISPath, "images/Menus/ie.png"), "",
            //    false, "OpenDialog_Save('divMakeHtml',OnMakeClassHtml)", "生成静态页面，没有选择将生成全部");

            string sjsSearch = "return confirm('确认要清除所有缓存吗？');";

            ucToolBar.AddBnt("清除所有缓存", string.Concat(IISPath, "images/Menus/Search.gif"), "clearallchace", true, sjsSearch, "正在清除所有缓存");
            }
            #endregion

        #region 工具栏事件扩展
        protected override void ucToolBar_ItemClick(object source, Control.ItemClickArgs e)
        {
            base.ucToolBar_ItemClick(source, e);
            switch (e.ItemTag)
            {

                case "clearallchace": //修改web.config来重启应用
                    
                    EbSite.Base.Host.CacheApp.Clear(); //EbSite.Core.CacheManager.RemoveAllCache();
                    break;
             
            }
        }
        #endregion

    }
}