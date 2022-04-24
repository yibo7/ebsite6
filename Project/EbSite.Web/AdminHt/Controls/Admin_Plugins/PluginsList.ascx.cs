using System;
using System.Collections.Generic;
using System.IO;
using System.Web.UI.WebControls;
using EbSite.Base.ControlPage;
using EbSite.Base.Extension.Manager;
using EbSite.Base.Plugin;
using EbSite.Entity;

namespace EbSite.Web.AdminHt.Controls.Admin_Plugins
{
    public partial class PluginsList : UserControlListBase
    {
        public override string Permission
        {
            get
            {
                return "136";
            }
        }
        public override string PermissionAddID
        {
            get
            {
                return "137";
            }
        }
        /// <summary>
        /// 修改数据的权限ID
        /// </summary>
        public override string PermissionModifyID
        {
            get
            {
                return "138";
            }
        }
        /// <summary>
        /// 删除数据的权限ID
        /// </summary>
        public override string PermissionDelID
        {
            get
            {
                return "136";
            }
        }
        override protected string AddUrl
        {
            get
            {
                return "t=4";
            }
        }

        override protected object LoadList(out int iCount)
        {
            iCount = 0;
           return EbSite.Base.Plugin.PluginManager.Instance.Extensions;
            //return BLL.Plugins.Plugin.Instance.GetPluginInfos(0);
            //EbSite.Base.Plugin.Collectors.GetAllProviders()
        }

        override protected object SearchList(out int iCount)
        {
            iCount = 0;
            //return null;
            //List<ManagedExtension> lst = EbSite.Base.Plugin.PluginManager.Instance.Extensions;
            //List<ManagedExtension> lstRz1 = new List<ManagedExtension>();
            //string sBaseType = ucToolBar.GetItemVal(drpType);
            //string sKey = ucToolBar.GetItemVal(txtKeyWord);
            //if (!string.IsNullOrEmpty(sBaseType))
            //{
            //    foreach (ManagedExtension info in lst)
            //    {
            //        if (info.BaseType.Equals(sBaseType))
            //        {
            //            lstRz1.Add(info);
            //        }

            //    }
            //}
            //else
            //{
            //    lstRz1 = lst;
            //}

            string sBaseType = ucToolBar.GetItemVal(drpType);
            string sKey = ucToolBar.GetItemVal(txtKeyWord);
            List<ManagedExtension> lstRz1 = PluginManager.Instance.GetPluginInfoByType(sBaseType,-1);

            List<ManagedExtension> lstRz2 = new List<ManagedExtension>();
            if (!string.IsNullOrEmpty(sKey))
            {
                foreach (ManagedExtension info in lstRz1)
                {
                    if (info.Description.IndexOf(sKey) > -1)
                    {
                        lstRz2.Add(info);
                    }

                }
            }
            else
            {
                lstRz2 = lstRz1;
            }

            return lstRz2;
        }
        override protected void Delete(object iID)
        {
            //BLL.Plugins.Plugin.Instance.DeletePlugin(new Guid(iID.ToString()));

        }
        #region 工具条初使化
        protected System.Web.UI.WebControls.Label lb = new Label();
        protected System.Web.UI.WebControls.DropDownList drpType = new DropDownList();
        protected System.Web.UI.WebControls.TextBox txtKeyWord = new TextBox();
        protected override void BindToolBar()
        {
            base.BindToolBar(true, true, true, true,false);
            ucToolBar.AddDialog(base.HostApi.GetModuleUrlForAdmin(new Guid("03fc411f-eed0-4afe-a5c2-b5c80d196b70"), new Guid("8a2b0cc7-3c97-4b6e-a4af-d6d185d6765f")), "下载插件", IISPath + "images/menus/menuDown.GIF");

            lb.ID = "lb";
            lb.Text = "插件名称";
            ucToolBar.AddCtr(lb);
            txtKeyWord.ID = "txtKeyWord";
            txtKeyWord.Attributes.Add("style", "width:130px"); 
            ucToolBar.AddCtr(txtKeyWord);

            drpType.DataSource = PluginManager.Instance.GetPluginType;//BLL.Plugins.Plugin.Instance.GetPluginType;
            drpType.DataValueField = "Value";
            drpType.DataTextField = "Text";
            drpType.ID = "drpType";
            drpType.DataBind();
            ucToolBar.AddCtr(drpType);

            base.ShowCustomSearch("查询");


        }
        protected override void ucToolBar_ItemClick(object source, Control.ItemClickArgs e)
        {
            base.ucToolBar_ItemClick(source, e);
            switch (e.ItemTag)
            {
                case "putout":

                   

                    List<string> lstPaths = new List<string>();
                    foreach (string selKey in GetSelKeys)
                    {
                        string sp = Server.MapPath(string.Format("{0}Datastore/widgets/{1}.xml", IISPath, selKey));
                        lstPaths.Add(sp);

                       

                    }
                   
                    string sUrl = string.Format("{0}UploadFile/temp/{1}.zip", IISPath, Path.GetRandomFileName());
                    string sSavePath = Server.MapPath(sUrl);
                   
                    Core.FSO.FObject.ZipFilesList(lstPaths, sSavePath);

                    Response.Redirect(Base.Configs.SysConfigs.ConfigsControl.Instance.DomainName + sUrl);

                    //Core.Utils.RunClientJs(this, string.Format("window.open('{0}')", sSavePath)););););););
                    break;
                
            }


        }
        #endregion
    }
}