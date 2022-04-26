using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.UI.WebControls;
using EbSite.Base.ControlPage;
using EbSite.BLL.ModulesBll;
using EbSite.Core;
using EbSite.Core.FSO;
using EbSite.Entity;

namespace EbSite.Web.AdminHt.Controls.Admin_Ctr
{
    public partial class CtrlsList : UserControlListBase
    {
        public override string Permission
        {
            get
            {
                return "179";
            }
        }
        /// <summary>
        /// 修改数据的权限ID
        /// </summary>
        public override string PermissionModifyID
        {
            get
            {
                return "214";
            }
        }
        /// <summary>
        /// 删除数据的权限ID
        /// </summary>
        public override string PermissionDelID
        {
            get
            {
                return "213";
            }
        }
        override protected string AddUrl
        {
            get
            {
                return "t=1";
            }
        }
        /// <summary>
        /// 控件分类
        /// </summary>
        private string iCtrType
        {
            get
            {
                if (!string.IsNullOrEmpty(Request.QueryString["ctp"]))
                    return Request.QueryString["ctp"];
                else
                    return "";
            }
        }

        override protected object LoadList(out int iCount)
        {
            iCount = 0;
            List<WidgetShow> list = new List<WidgetShow>();
            if (!"".Equals(iCtrType))
            {
                List<WidgetShow> templist = Base.ExtWidgets.ModelCtr.DataBLL.Instance.GetList();
                foreach (var widget in templist)
                {
                    if (widget.TypeWidget.Equals(iCtrType))
                        list.Add(widget);
                }
            }
            else
            {
                list = Base.ExtWidgets.ModelCtr.DataBLL.Instance.GetList();
            }
            return list;
        }

        override protected object SearchList(out int iCount)
        {
            iCount = 0;
            List<WidgetShow> lstRz = new List<WidgetShow>();
            List<WidgetShow> lst = Base.ExtWidgets.ModelCtr.DataBLL.Instance.GetList();
            string sKeyTitle = ucToolBar.GetItemVal(txtOne).Trim();
            string searchType = ucToolBar.GetItemVal(drpSearchTp);



            foreach (WidgetShow widget in lst)
            {
                if (searchType.Equals("0"))
                {
                    if (widget.Title.IndexOf(sKeyTitle) > -1) //Equals(sKeyTitle)
                    {
                        lstRz.Add(widget);
                    }
                }
                else if (searchType.Equals("1"))
                {
                    if (widget.DataID.ToString().IndexOf(sKeyTitle) > -1) //Equals(sKeyTitle)
                    {
                        lstRz.Add(widget);
                    }
                }
            }
            return lstRz;
        }
        override protected void Delete(object iID)
        {
            //ModelCtrlUtils.DeleteCtrlByID(iID.ToString());
            Base.ExtWidgets.ModelCtr.DataBLL.Instance.Delete(iID.ToString());

        }

        #region 工具栏的初始化
        protected Control.TextBox txtOne = new Control.TextBox();
        protected Control.DropDownList drpSearchTp = new Control.DropDownList();
        protected Control.DropDownList drpTemTp = new Control.DropDownList();
        protected Control.DropDownList drpCtrTp = new Control.DropDownList();
        protected override void BindToolBar()
        {
            base.BindToolBar(true, false, true, true, false);

            //label.ID = "lblOne";
            //label.Text = " 控件名称 ";
            //ucToolBar.AddCtr(label);
            ucToolBar.AddBox("divPutin", "导入控件", "putin", IISPath + "images/menus/Doc-Previous.gif");
            ucToolBar.AddBnt("导出控件", IISPath + "images/menus/Doc-Next.gif", "putout");
            //ucToolBar.AddDialog(base.HostApi.GetModuleUrlForAdmin(new Guid("03fc411f-eed0-4afe-a5c2-b5c80d196b70"), new Guid("bdbd3f29-4e33-4c16-a261-f6a9e7631d2e")), "下载控件", IISPath + "images/menus/menuDown.GIF");

            ucToolBar.AddLine();

            txtOne.ID = "txtKeyWord";
            ucToolBar.AddCtr(txtOne);

            drpSearchTp.ID = "drpSearchTp";
            ucToolBar.AddCtr(drpSearchTp);
            ListItem li = new ListItem("控件名称", "0");
            ListItem li2 = new ListItem("控件ID", "1");
            drpSearchTp.Items.Add(li);
            drpSearchTp.Items.Add(li2);

            base.ShowCustomSearch("查询");

            ucToolBar.AddLine();

            drpTemTp.ID = "drpTemTp";
            ucToolBar.AddCtr(drpTemTp);
            drpTemTp.AppendDataBoundItems = true;
            ListItem TemItem = new ListItem("控件分类", "");
            drpTemTp.Items.Add(TemItem);
            drpTemTp.DataTextField = "Title";
            drpTemTp.DataValueField = "ID";
            drpTemTp.Attributes.Add("onchange", "OnTemTpChange(this)");
            drpTemTp.DataSource = BLL.ClassCustom.Provider.Factory.ModelCtrl().Fills();
            drpTemTp.DataBind();


            drpCtrTp.ID = "drpCtrTp";
            ucToolBar.AddCtr(drpCtrTp);
            drpCtrTp.AppendDataBoundItems = true;
            ListItem ctrItem = new ListItem("控件类型", "");
            drpCtrTp.Items.Add(ctrItem);
            drpCtrTp.DataTextField = "TypeName";
            drpTemTp.DataValueField = "TypeName";
            drpCtrTp.Attributes.Add("onchange", "OnCtrTpChange(this)");
            drpCtrTp.DataSource = Base.ExtWidgets.ModelCtr.DataBLL.Instance.GetTemList();//ModelCtrlUtils.GetExtensionsCtrlsType();
            drpCtrTp.DataBind();

        }
        #endregion
        protected override void ucToolBar_ItemClick(object source, Control.ItemClickArgs e)
        {
            base.ucToolBar_ItemClick(source, e);
            switch (e.ItemTag)
            {
                case "putout":
                    List<string> lstPaths = new List<string>();
                    foreach (string selKey in GetSelKeys)
                    {
                        string sp = Server.MapPath(string.Format("{0}Datastore/Ctrl/{1}.xml", IISPath, selKey));
                        lstPaths.Add(sp);
                    }
                    string sUrl = string.Format("{0}UploadFile/temp/{1}.zip", IISPath, Path.GetRandomFileName());
                    string sSavePath = Server.MapPath(sUrl);

                    Core.FSO.FObject.ZipFilesList(lstPaths, sSavePath);

                    Response.Redirect(Base.Configs.SysConfigs.ConfigsControl.Instance.DomainName + sUrl);

                    //Core.Utils.RunClientJs(this, string.Format("window.open('{0}')", sSavePath)););););););
                    break;
                case "putin":
                    if (this.txtMdPath.ValSavePath == "")
                    {
                        base.ShowTipsPop(" 请先上传控件的Zip压缩包!");
                    }
                    else
                    {
                        string zipUrl = HttpContext.Current.Server.MapPath("/" + this.txtMdPath.ValSavePath);
                        string unzipUrl = HttpContext.Current.Server.MapPath("/" + this.SetPathUrl.Text);

                        bool tag = Core.FSO.FObject.UnZipFile(zipUrl, unzipUrl);
                        if (tag)
                        {
                            base.ShowTipsPop(" 控件导入成功!");

                        }

                    }

                    break;
               
                    

            }


        }

        protected string MakeCoder(string sID)
        {
            return ("<XS:ExtensionsCtrls   ModelCtrlID=\"" + sID + "\" runat=\"server\"/>");
        }
        protected string ModifyUrl(object sType, object sID)
        {
            return string.Format("Admin_Ctr.aspx?t=7&type={0}&id={1}", sType, sID);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!base.IsPostBack)
            {
                //ucToolBar.SetItemVal(drpTemTp, iTemType);
                ucToolBar.SetItemVal(drpCtrTp, iCtrType);
            }
        }
        override protected void gdList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            base.gdList_RowCommand(sender, e);
            if (Equals(e.CommandName, "CopyData"))
            {
                Guid id = new Guid(e.CommandArgument.ToString());
                //string zone =  DataBLL.Instance.DefualtZoneName;
                Entity.WidgetShow md = Base.ExtWidgets.ModelCtr.DataBLL.Instance.GetEntityByID(id);
                Guid newID = Guid.NewGuid();

                Base.ExtWidgets.ModelCtr.DataBLL.Instance.AddData(newID, md.Name, string.Concat("复制-", md.Title), md.ModulID);

                //复制配置数据
                string sDataSetPath = Server.MapPath(string.Concat(IISPath, "Datastore/Ctrl/", id, ".xml"));
                if (FObject.IsExist(sDataSetPath, FsoMethod.File))
                {
                    string sTem = Core.FSO.FObject.ReadFile(sDataSetPath);
                    sDataSetPath = Server.MapPath(string.Concat(IISPath, "Datastore/Ctrl/", newID, ".xml"));
                    Core.FSO.FObject.WriteFile(sDataSetPath, sTem);
                }


                base.gdList_Bind();
            }
        }


    }
}