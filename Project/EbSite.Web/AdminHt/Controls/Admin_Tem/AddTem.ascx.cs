using System;
using System.IO;
using EbSite.BLL;
using EbSite.Core.FSO;
using Templates = EbSite.Entity.Templates;

namespace EbSite.Web.AdminHt.Controls.Admin_Tem
{
    public partial class AddTem : BaseAdd
    {
        public override string Permission
        {
            get
            {
                return "96";
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
            ModifyDiv.Visible = false;
            cbAddToEdit.Visible = false;
            tlName.Text = "编辑模板";

            //Entity.Templates cm = TempFactory.Instance.GetModel(new Guid(SID));
            Entity.Templates cm = TemBll.GetModel(new Guid(SID));
            

            txtTemName.Text = cm.TemName;
          
            drpTemClass.SelectedValue = cm.TemType.ToString();
            txtTemFileName.Text = cm.TemPath;
            //if (cm.TemType == 1)
            //{
            //    drpModel.Visible = true;
            //    drpModel.Items.Clear();
            //    drpModel.DataTextField = "ModelName";
            //    drpModel.DataValueField = "id";
            //    drpModel.DataSource = BLL.ClassModel.Instance.ModelClassList;
            //    drpModel.DataBind();
            //    drpModel.SelectedValue = cm.ModelClassID.ToString();
            //}
            //if (cm.TemType == 2)
            //{
            //    drpModel.Visible = true;
            //    drpModel.Items.Clear();
            //    drpModel.DataTextField = "ModelName";
            //    drpModel.DataValueField = "id";
            //    drpModel.DataSource = BLL.WebModel.Instance.ModelClassList;
            //    drpModel.DataBind();
            //    drpModel.SelectedValue = cm.ModelClassID.ToString();
            //}

        }
        override protected void SaveModel()
        {
            //string sThemes = CurrentSite.PageTheme ;

            string sThemes = CurrentThemeName;

            Entity.Templates mdNC = new Templates(ThemesFolder);
            int iTemType = int.Parse(drpTemClass.SelectedValue);
            mdNC.TemName = txtTemName.Text.Trim();
            mdNC.TemType = iTemType;
            mdNC.IsNoSysTem = true;
            mdNC.Themes = sThemes;
            ////只有分类与内容模板可以使用模型
            //if (drpTemClass.SelectedValue == "0" || drpTemClass.SelectedValue == "3"|| drpTemClass.SelectedValue == "4")
            //{

            //}
            //else
            //{
            //    mdNC.ModelClassID = new Guid(drpModel.SelectedValue);//模型ID
            //}
          
            if (!string.IsNullOrEmpty(SID)) //修改
            {

                mdNC.ID = new Guid(SID);
                //mdNC.TempFileName = TempFactory.Instance.GetModel(new Guid(SID)).TempFileName;
                //TempFactory.Instance.Update(mdNC);
                mdNC.TempFileName = TemBll.GetModel(new Guid(SID)).TempFileName;
                TemBll.Update(mdNC);
                

            }

            else    //添加
            {

                //生成模板文件
                string sfName = Path.GetRandomFileName();

                if (!cbRandName.Checked)
                {
                    sfName = txtTemFileName.Text;
                }
                //模板前缀
                //string sPre = BLL.TemplatesPC.GetTemClass(iTemType).PrefixName;
                string sPre = TemBll.GetTemClass(iTemType).PrefixName;
                

                string sFileName = string.Concat(sPre, sfName, ".aspx");
                sfName = string.Concat(IISPath, TemBll.ThemesFolder, "/", sThemes, "/pages/", sFileName);

                string sTemPath = Server.MapPath(sfName);

                if (!Core.FSO.FObject.IsExist(sTemPath, FsoMethod.File))
                {
                    int iType = int.Parse(drpTemClass.SelectedValue);
                    string sTemHtml = "";
                    if (iType == 0) //首页
                    {

                        if (!cbDefualtTem.Checked)
                        {
                            if (ThemesType == 2)
                            {
                                sTemHtml = MTem_HTML;
                            }
                            else
                            {
                                sTemHtml = Tem_HTML;
                            }
                           
                        }
                        else
                        {
                            //sTemHtml = TempFactory.Instance.sDefault_IndexHTML;
                            sTemHtml = TemBll.sDefault_IndexHTML();
                            
                        }
                    }
                    else if (iType == 1) //分类模板
                    {

                        if (!cbDefualtTem.Checked)
                        {
                            if (ThemesType == 2)
                            {
                                sTemHtml = MTem_HTML.Replace("EbSite.Web.Pagesm.index", "EbSite.Web.Pagesm.list");
                            }
                            else
                            {
                                sTemHtml = Tem_HTML.Replace("EbSite.Web.Pages.index", "EbSite.Web.Pages.list");
                            }
                        }
                        else
                        {
                            sTemHtml = TemBll.sDefault_ListHTML();
                        }


                    }
                    else if (iType == 2) //内容模板
                    {
                        if (!cbDefualtTem.Checked)
                        {
                            if (ThemesType == 2)
                            {
                                sTemHtml = MTem_HTML.Replace("EbSite.Web.Pagesm.index", "EbSite.Web.Pagesm.content");
                            }
                            else
                            {
                                sTemHtml = Tem_HTML.Replace("EbSite.Web.Pages.index", "EbSite.Web.Pages.content");
                            }
                        }
                        else
                        {
                            sTemHtml = TemBll.sDefault_ContentHTML();
                        }



                    }
                    else if (iType == 3) //专题模板
                    {
                        if (!cbDefualtTem.Checked)
                        {
                            if (ThemesType == 2)
                            {
                                sTemHtml = MTem_HTML.Replace("EbSite.Web.Pagesm.index", "EbSite.Web.Pagesm.special");
                            }
                            else
                            {
                                sTemHtml = Tem_HTML.Replace("EbSite.Web.Pages.index", "EbSite.Web.Pages.special");
                            }
                        }
                        else
                        {
                            sTemHtml = TemBll.sDefault_SpecialHTML();
                        }
                    }
                    
                    Core.FSO.FObject.WriteFile(sTemPath, sTemHtml);
                }
                else
                {
                    TipsAlert("已经存在与此名称相同的模板文件");

                    return;
                }
                
                //mdNC.TemPath = sfName;
                mdNC.Themes = sThemes;
                mdNC.TempFileName = sFileName;
                mdNC.ID = Guid.NewGuid();
                //TempFactory.Instance.Add(mdNC);
                TemBll.Add(mdNC);

                if (cbAddToEdit.Checked)
                {
                    Response.Redirect(string.Concat("Admin_Tem.aspx?tt=",ThemesType,"&theme=",sThemes,"&t=4&id=", mdNC.ID));
                }


            }
            Core.Utils.AppRestart();
            //base.ColseGreyBox(true);
        }
        private string Tem_HTML = "<%@ Page Language=\"C#\" AutoEventWireup=\"true\" Inherits=\"EbSite.Web.Pages.index\" %>\n\t<%@ Register Assembly=\"EbSite.Control\" Namespace=\"EbSite.Control\" TagPrefix=\"XS\" %>\n\t<%@ Import Namespace=\"EbSite.BLL.GetLink\"%>\n\t<%@ Register Assembly=\"EbSite.Control\" Namespace=\"EbSite.Control.xsPage\" TagPrefix=\"cc1\" %>\n\t<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.0 Transitional//EN\" \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd\">\n\t<html xmlns=\"http://www.w3.org/1999/xhtml\">\n\t<head runat=\"server\">\n\t<meta http-equiv=\"X-UA-Compatible\" content=\"IE=EmulateIE7\"/>\n\t</head>\n\t<body >\n\t\n\t内容\n\t\n\t<%=KeepUserState()%>\n\t</body>\n\t</html>";
        private string MTem_HTML = "<%@ Page Language=\"C#\" AutoEventWireup=\"true\" Inherits=\"EbSite.Web.Pagesm.index\" %>\n\t<%@ Register Assembly=\"EbSite.Control\" Namespace=\"EbSite.Control\" TagPrefix=\"XS\" %>\n\t<!doctype html>\n\t<html>\n\t<head runat=\"server\">\n\t</head>\n\t<body >\n\t\n\t内容\n\t\n\t<%=KeepUserState()%>\n\t</body>\n\t</html>";

        private void BindData()
        {

            drpTemClass.DataTextField = "ClassName";
            drpTemClass.DataValueField = "ClassID";
            drpTemClass.DataSource = TemBll.GetTemClass();// BLL.TemplatesPC.GetTemClass();
            drpTemClass.DataBind();

            //drpClass.DataTextField = "Title";
            //drpClass.DataValueField = "id";
            //drpClass.DataSource = BLL.ClassCustom.Provider.Factory.PageTemp().Fills();
            //drpClass.DataBind();

           //BLL.ClassCustom.Provider.Factory.PageTemp()


            //drpModelClass.DataTextField = "ModelName";
            //drpModelClass.DataValueField = "id";
            //drpModelClass.DataSource = BLL.ClassModel.Instance.ModelClassList;
            //drpModelClass.DataBind();


        }
        protected void cbRandName_CheckedChanged(object sender, EventArgs e)
        {
            txtTemFileName.Visible = !cbRandName.Checked;
        }
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
               if(Equals(SID,null))
               {
                   tlName.Text = "添加模板";
               }
                BindData();
                //InitModify();
            }


        }

        //protected void drpTemClass_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    //<value="0">首页</option>
        //    //<option value="1">分类页</option>
        //    //<option value="2">内容页</option>
        //    //<option value="3">专题页</option>
        //    if (drpTemClass.SelectedValue == "0" || drpTemClass.SelectedValue == "3" || drpTemClass.SelectedValue == "4")
        //    {
        //        //drpModelClass.Visible = false;
        //        drpModel.Visible = false;
        //    }
        //    else if (drpTemClass.SelectedValue == "1")
        //    {
        //        //drpModelClass.Visible = true;
        //        drpModel.Visible = true;
        //        drpModel.Items.Clear();
        //        drpModel.DataTextField = "ModelName";
        //        drpModel.DataValueField = "id";
        //        drpModel.DataSource = BLL.ClassModel.Instance.ModelClassList;
        //        drpModel.DataBind();

        //    }
        //    else
        //    {
        //        drpModel.Visible = true;
        //        drpModel.Items.Clear();
        //        drpModel.DataTextField = "ModelName";
        //        drpModel.DataValueField = "id";
        //        drpModel.DataSource = BLL.WebModel.Instance.ModelClassList;
        //        drpModel.DataBind();
        //    }
        //}
        #region
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
        //        Entity.Templates cm = BLL.Templates.GetModel(id);

        //        txtTemName.Text = cm.TemName;
        //        drpTemClass.SelectedValue = cm.TemType.ToString();
        //        txtTemFileName.Text = cm.TemPath;

        //        btnAdd.Text = "修改模板";

        //    }
        //}


        //protected void btnAdd_Click(object sender, EventArgs e)
        //{


        //    Entity.Templates mdNC = new Templates();

        //    mdNC.TemName = txtTemName.Text.Trim();
        //    mdNC.TemType = int.Parse(drpTemClass.SelectedValue);
        //    mdNC.IsNoSysTem = true;
        //    if (id != Guid.Empty) //修改
        //    {
        //        mdNC.ID = id;
        //        mdNC.TemPath = BLL.Templates.GetModel(id).TemPath;
        //        BLL.Templates.Update(mdNC);  
        //    }

        //    else    //添加
        //    {

        //        //生成模板文件
        //        string sfName = Path.GetRandomFileName();

        //        if (!cbRandName.Checked)
        //        {
        //            sfName = txtTemFileName.Text;
        //        }

        //        sfName = string.Concat("/PageTemps/", sfName, ".aspx");

        //        string sTemPath = Server.MapPath(sfName);

        //        if (!Core.FSO.FObject.IsExist(sTemPath, FsoMethod.File))
        //        {
        //            int iType = int.Parse(drpTemClass.SelectedValue);
        //            string sTemHtml = "";
        //            if (iType == 0) //首页
        //            {

        //                if (!cbDefualtTem.Checked)
        //                {
        //                    sTemHtml = Tem_HTML;
        //                }
        //                else
        //                {
        //                    sTemHtml = BLL.Templates.sDefault_IndexHTML;
        //                }
        //            }
        //            else if (iType == 1) //分类模板
        //            {

        //                if (!cbDefualtTem.Checked)
        //                {
        //                    sTemHtml = Tem_HTML.Replace("EbSite.Pages.index", "EbSite.Pages.list");
        //                }
        //                else
        //                {
        //                    sTemHtml = BLL.Templates.sDefault_ListHTML;
        //                }


        //            }
        //            else if (iType == 2) //内容模板
        //            {
        //                if (!cbDefualtTem.Checked)
        //                {
        //                    sTemHtml = Tem_HTML.Replace("EbSite.Pages.index", "EbSite.Pages.content");
        //                }
        //                else
        //                {
        //                    sTemHtml = BLL.Templates.sDefault_ContentHTML;
        //                }



        //            }
        //            else if (iType == 3) //专题模板
        //            {
        //                if (!cbDefualtTem.Checked)
        //                {
        //                    sTemHtml = Tem_HTML.Replace("EbSite.Pages.index", "EbSite.Pages.special");
        //                }
        //                else
        //                {
        //                    sTemHtml = BLL.Templates.sDefault_SpecialHTML;
        //                }


        //            }

        //            Core.FSO.FObject.WriteFile(sTemPath, sTemHtml);
        //        }
        //        else
        //        {
        //            Core.Strings.cJavascripts.MessageShowBack("已经存在与此名称相同的模板文件");

        //            return;
        //        }
        //        mdNC.TemPath = sfName;
        //        mdNC.ID = Guid.NewGuid();
        //        BLL.Templates.Add(mdNC);
        //        if (cbAddToEdit.Checked)
        //        {
        //            Response.Redirect(string.Concat("Admin_Tem.aspx?t=4&id=", mdNC.ID));
        //        }


        //    }


        //}
        #endregion

    }
}