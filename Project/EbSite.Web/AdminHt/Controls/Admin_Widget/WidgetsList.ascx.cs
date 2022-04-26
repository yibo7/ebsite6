using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI.WebControls;
using System.Xml;
using EbSite.Base.ControlPage;
using EbSite.Base.ExtWidgets;
using EbSite.Base.ExtWidgets.WidgetsManage;
using EbSite.Core.FSO;
using EbSite.Entity;
using EbSite.Web.AdminHt.Controls.Admin_Ctr;

namespace EbSite.Web.AdminHt.Controls.Admin_Widgets
{
    public partial class WidgetsList : UserControlListBase
    {
        public override string Permission
        {
            get
            {
                return "122";
            }
        }
        public override string PermissionAddID
        {
            get
            {
                return "123";
            }
        }
        /// <summary>
        /// 修改数据的权限ID
        /// </summary>
        public override string PermissionModifyID
        {
            get
            {
                return "235";
            }
        }
        /// <summary>
        /// 删除数据的权限ID
        /// </summary>
        public override string PermissionDelID
        {
            get
            {
                return "234";
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
        /// 部件分类
        /// </summary>
        private string iWidgetType
        {
            get
            {
                if (!string.IsNullOrEmpty(Request.QueryString["wtp"]))
                    return Request.QueryString["wtp"];
                else
                    return "";
            }
        }

        /// <summary>
        /// 模板分类
        /// </summary>
        private string iTemType
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
            List<WidgetShow> list = new List<WidgetShow>();
            if (!"".Equals(iWidgetType))
            {
                list = Base.ExtWidgets.WidgetsManage.DataBLL.Instance.GetListByType(iWidgetType);// WidgetUtils.GetWidgetByType(iWidgetType);
            }
            //<option value="789cbcbe-77c4-452b-8598-e2481dac56e1">EbSite模块部件</option>
            //<option value="ee2c9cb6-52cd-4678-8de0-b8e3967df7d0">EbSite主站部件</option>
            //    789cbcbe-77c4-452b-8598-e5645dac89e2    当前皮肤
            else if ("ee2c9cb6-52cd-4678-8de0-b8e3967df7d0".Equals(iTemType))
            {
                list = Base.ExtWidgets.WidgetsManage.DataBLL.Instance.GetList(ZoneName);
                List<WidgetShow> newList = (from li in list
                                            where (li.ModulID == new Guid("00000000-0000-0000-0000-000000000000"))
                                            select li
                                      ).ToList();
                list = newList;
            }
            else if ("789cbcbe-77c4-452b-8598-e2481dac56e1".Equals(iTemType))
            {
                list = Base.ExtWidgets.WidgetsManage.DataBLL.Instance.GetList(ZoneName);
                List<WidgetShow> newList = (from li in list
                                            where (li.ModulID != new Guid("00000000-0000-0000-0000-000000000000"))
                                            select li
                                      ).ToList();
                list = newList;
            }
            //else if ("789cbcbe-77c4-452b-8598-e5645dac89e2".Equals(iTemType))//当前皮肤下的部件
            //{
            //    list = Base.ExtWidgets.WidgetsManage.DataBLL.Instance.GetList(ZoneName);
            //    List<WidgetShow> newList = (from li in list
            //                                where (!string.IsNullOrEmpty(li.ThemePath))
            //                                select li
            //                          ).ToList();
            //    list = newList;
            //}
            else
            {
                list = Base.ExtWidgets.WidgetsManage.DataBLL.Instance.GetList(ZoneName);//WidgetUtils.GetWidgetsList(ZoneName);
            }
            return list;
        }

        override protected object SearchList(out int iCount)
        {
            iCount = 0;
            List<WidgetShow> lstRz = new List<WidgetShow>();
            List<WidgetShow> lst = Base.ExtWidgets.WidgetsManage.DataBLL.Instance.GetList(ZoneName);//WidgetUtils.GetWidgetsList(ZoneName);
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
            //WidgetUtils.DeleteWidgetByID(iID.ToString(), ZoneName);
            Base.ExtWidgets.WidgetsManage.DataBLL.Instance.Delete(iID.ToString());

        }
        //protected Label label = new Label(); 
        protected TextBox txtOne = new TextBox();
        protected Label lblTemTp = new Label();
        protected Label lblWidgetTp = new Label();
        protected DropDownList drpSearchTp = new DropDownList();
        protected DropDownList drpTemTp = new DropDownList();
        protected DropDownList drpWidgetTp = new DropDownList();
        //protected DropDownList drpThemeTp = new DropDownList();
        protected override void BindToolBar()
        {
            base.BindToolBar(true, false, true, true, false);

            //ucToolBar.AddBox("divPutin", "导入部件", "putin", IISPath + "images/menus/Doc-Previous.gif");
            //ucToolBar.AddBnt("导出部件", IISPath + "images/menus/Doc-Next.gif", "putout");

            //ucToolBar.AddDialog(base.HostApi.GetModuleUrlForAdmin(new Guid("03fc411f-eed0-4afe-a5c2-b5c80d196b70"), new Guid("b129a8d3-0171-4008-8def-157d8c63fd33")), "下载部件", IISPath + "images/menus/menuDown.GIF");


            ucToolBar.AddLine();
            txtOne.ID = "txtKeyWord";
            ucToolBar.AddCtr(txtOne);

            drpSearchTp.ID = "drpSearchTp";
            ucToolBar.AddCtr(drpSearchTp);

            ListItem li = new ListItem("部件名称", "0");
            ListItem li2 = new ListItem("部件ID", "1");
            drpSearchTp.Items.Add(li);
            drpSearchTp.Items.Add(li2);

            base.ShowCustomSearch("查询");

            ucToolBar.AddLine();

            //lblTemTp.ID = "lblTemTp";
            //lblTemTp.Text = " 模板分类 ";
            //ucToolBar.AddCtr(lblTemTp);

            drpTemTp.ID = "drpTemTp";
            ucToolBar.AddCtr(drpTemTp);
            drpTemTp.AppendDataBoundItems = true;
            ListItem temItem = new ListItem("部件类别检索(所有)", "");
            drpTemTp.Items.Add(temItem);
            drpTemTp.DataTextField = "Title";
            drpTemTp.DataValueField = "ID";
            drpTemTp.Attributes.Add("onchange", "OnTemTpChange(this)");
            drpTemTp.DataSource = BLL.ClassCustom.Provider.Factory.Widget().Fills();
            drpTemTp.DataBind();

            drpWidgetTp.ID = "drpWidgetTp";
            ucToolBar.AddCtr(drpWidgetTp);
            ListItem widgetItem = new ListItem("站点自带类型", "");
            drpWidgetTp.Items.Add(widgetItem);
            drpWidgetTp.Attributes.Add("onchange", "OnWidgetTpChange(this)");
            List<WidGetEntity> widgetsType = Base.ExtWidgets.WidgetsManage.DataBLL.Instance.GetTemList();//WidgetUtils.GetWidgetCtrList();
            foreach (WidGetEntity tp in widgetsType)
            {
                //ListItem li = new ListItem();
                drpWidgetTp.Items.Add(tp.TypeName);
            }


            //drpThemeTp.ID = "drpThemeTp";
            //ucToolBar.AddCtr(drpThemeTp);
            //drpThemeTp.AppendDataBoundItems = true;
            //ListItem themeItem = new ListItem("皮肤分类", "");
            //drpThemeTp.Items.Add(themeItem);
            //drpThemeTp.DataTextField = "ThemesName";
            //drpThemeTp.DataValueField = "ID";
            //drpThemeTp.Attributes.Add("onchange", "OnThemeTpChange(this)");
            //drpThemeTp.DataSource = BLL.ThemesPC.Instance.FillList(); ;
            //drpThemeTp.DataBind();
            

        }
        protected override void ucToolBar_ItemClick(object source, Control.ItemClickArgs e)
        {
            base.ucToolBar_ItemClick(source, e);
            //switch (e.ItemTag)
            //{
            //    //case "putout":

            //    //    StringBuilder sb = new StringBuilder();

            //    //    List<string> lstPaths = new List<string>();
            //    //    foreach (string selKey in GetSelKeys)
            //    //    {
            //    //        string sp = Server.MapPath(string.Format("{0}Datastore/widgets/{1}.xml", IISPath, selKey));
            //    //        lstPaths.Add(sp);

            //    //        Entity.WidgetShow md = Base.ExtWidgets.WidgetsManage.DataBLL.Instance.GetEntityByID(new Guid(selKey)); // WidgetUtils.GetWidgetByID(new Guid(selKey));
           

            //    //        sb.Append(md.DataID);
            //    //        sb.Append("|");
            //    //        sb.Append(md.Title);
            //    //        sb.Append("|");
            //    //        sb.Append(md.TypeWidget);
            //    //        sb.Append("|");
            //    //        //sb.Append(md.ShowTitle);
            //    //        sb.Append("|");
            //    //        sb.Append(md.ModulID);
            //    //        sb.Append("*");

            //    //    }
            //    //    //把sb写入到UploadFile/temp 临时文件中
            //    //    string fUrl = HttpContext.Current.Server.MapPath("/UploadFile/temp/widgetList.txt");
            //    //   //去掉最后一个*号
            //    //    if(sb.Length>0)
            //    //    {
            //    //        sb = sb.Remove(sb.Length - 1, 1);
            //    //    }
            //    //    EbSite.Core.FSO.FObject.WriteFile(fUrl, sb.ToString());
            //    //    string sUrl = string.Format("{0}UploadFile/temp/{1}.zip", IISPath, Path.GetRandomFileName());
            //    //    string sSavePath = Server.MapPath(sUrl);
            //    //    lstPaths.Add(fUrl);//添加到压缩的列表中
            //    //    Core.FSO.FObject.ZipFilesList(lstPaths, sSavePath);
            //    //    Core.FSO.FObject.Delete(fUrl, FsoMethod.File);//删除临时文件
            //    //    Response.Redirect(Base.Configs.SysConfigs.ConfigsControl.Instance.DomainName + sUrl);

            //    //    //Core.Utils.RunClientJs(this, string.Format("window.open('{0}')", sSavePath)););););););
            //    //    break;
            //    //case "putin":
            //    //    if (this.txtMdPath.ValSavePath == "")
            //    //    {
            //    //        base.ShowTipsPop(" 请先上传部件的Zip压缩包!");
            //    //    }
            //    //    else
            //    //    {
            //    //        string zipUrl = HttpContext.Current.Server.MapPath("/" + this.txtMdPath.ValSavePath);
            //    //        string unzipUrl = HttpContext.Current.Server.MapPath("/" + this.SetPathUrl.Text);

            //    //        bool tag = Core.FSO.FObject.UnZipFile(zipUrl, unzipUrl);

            //    //        string SS = Core.FSO.FObject.ReadFile(unzipUrl + "/widgetList.txt");

            //    //        string[] arry = Core.Strings.cConvert.SplitArray(SS, '*');
            //    //        for (int i = 0; i < arry.Length; i++)
            //    //        {

            //    //            string[] arryTemp = Core.Strings.cConvert.SplitArray(arry[i], '|');
            //    //            Entity.WidgetShow md = new WidgetShow();
            //    //            md.DataID = new Guid(arryTemp[0]); 
            //    //            md.Title = arryTemp[1];
            //    //            md.TypeWidget = arryTemp[2];
            //    //            //md.ShowTitle = Convert.ToBoolean(arryTemp[3]);
            //    //            md.ModulID =new Guid(arryTemp[4]);
            //    //            md.ThemePath = EbSite.BLL.ThemesPC.Instance.GetCurrentUsedTheme.ThemePath;
            //    //            Base.ExtWidgets.WidgetsManage.DataBLL.Instance.AddData(md.DataID, md.TypeWidget, md.Title, md.ModulID, md.ThemePath);
            //    //            //WidgetUtils.AddWidget(md);
            //    //        }
            //    //        if (tag)
            //    //        {
            //    //            Core.FSO.FObject.Delete(unzipUrl + "/widgetList.txt", FsoMethod.File);
            //    //            base.ShowTipsPop(" 部件导入成功!");

            //    //        }

            //    //    }



            //        break;
            //}


        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //BindData();
                ucToolBar.SetItemVal(drpTemTp, iTemType);
                ucToolBar.SetItemVal(drpWidgetTp, iWidgetType);
            }
        }
        protected string ModifyUrl(object sType, object sID)
        {
            return string.Format("?t=1&type={0}&id={1}", sType, sID);
        }
        protected string MakeCoder(string sID, string sName)
        {
            return EbSite.Control.Widget.GetWidgetCtrCoder(sID, sName);

            //return string.Concat("<XS:Widget   WidgetID=\"", sID, "\" runat=\"server\"/>");
        }

        private string ZoneName = Base.ExtWidgets.WidgetsManage.DataBLL.Instance.DefualtZoneName;
        override protected void gdList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            base.gdList_RowCommand(sender, e);
            if (Equals(e.CommandName, "CopyData"))
            {
                Guid id = new Guid(e.CommandArgument.ToString());
                //string zone =  DataBLL.Instance.DefualtZoneName;
                Entity.WidgetShow md = DataBLL.Instance.GetEntityByID(id, ZoneName);
                Guid newID = Guid.NewGuid();

                DataBLL.Instance.AddData(newID, md.Name, string.Concat("复制-", md.Title), md.ModulID);

                //复制配置数据
                string sDataSetPath = Server.MapPath(string.Concat(IISPath, "Datastore/widgets/",id,".xml"));
                if (FObject.IsExist(sDataSetPath,FsoMethod.File))
                {
                   string sTem =  Core.FSO.FObject.ReadFile(sDataSetPath);
                   sDataSetPath = Server.MapPath(string.Concat(IISPath,"Datastore/widgets/", newID, ".xml"));
                   Core.FSO.FObject.WriteFile(sDataSetPath, sTem);
                }
               

                base.gdList_Bind();
            }
        }

    }
}