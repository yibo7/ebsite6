using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base;
using EbSite.Base.BLL;
using EbSite.Base.ControlPage;
using EbSite.BLL;
using EbSite.Core.FSO;
using Sites = EbSite.Entity.Sites;

namespace EbSite.Web.AdminHt.Controls.Admin_Sites
{
    public partial class SiteAdd : UserControlBaseSave
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        protected override void OnBasePageLoading()
        {
            if(!IsPostBack)
            {
                if (string.IsNullOrEmpty(SID))
                {
                    if (ThemesPC.Instance.GetThemeNoUsed.Count==0)
                    {
                        Tips("不能创建站点","没有可用的皮肤创建站点，请到皮肤里复制后再创建","");
                    }
                    else
                    {
                        BindSiteDrpList();// 父级站点
                        BindTempletDrpList();//首页采用模板
                        BindThemeList();//皮肤:前台 后台 手机
                    }

                   
                }
                else
                {
                    //PageTheme.Enabled = false;
                    Sites siteSelect = BLL.Sites.Instance.GetEntity(int.Parse(SID));

                    List<Sites> s = BLL.Sites.Instance.GetSitesTree(0);
                    ParentID.DataSource = s;
                    ParentID.DataTextField = "SiteName";
                    ParentID.DataValueField = "id";
                    if (SID == "1")
                    {
                        ParentID.SelectedValue = "1";
                        SiteFolder.Enabled = false;
                        ParentID.Enabled = false;
                    }
                    else
                    {
                        ParentID.SelectedValue = siteSelect.ParentID.ToString();
                    }
                    ParentID.DataBind();

                    //前台皮肤
                    ThemesPC pc = new ThemesPC();
                    List<Entity.Themes> pcList = pc.FillList();//

                    PageTheme.DataValueField = "ThemePath";
                    PageTheme.DataTextField = "ThemePath";
                    this.PageTheme.DataSource = pcList;
                    this.PageTheme.DataBind();
                    this.PageTheme.SelectedValue = siteSelect.PageTheme;

                    //手机皮肤
                    ThemesMobile mobile = new ThemesMobile();
                    List<Entity.Themes> mobileList = mobile.FillList();
                    MobileTheme.DataValueField = "ThemePath";
                    MobileTheme.DataTextField = "ThemePath";
                    this.MobileTheme.DataSource = mobileList;
                    this.MobileTheme.DataBind();
                    this.MobileTheme.SelectedValue = siteSelect.MobileTheme;

                    //网站后台皮肤
                    ThemesAdmin admin = new ThemesAdmin();
                    List<Entity.Themes> adminList = admin.FillList();
                    AdminTheme.DataValueField = "ThemePath";
                    AdminTheme.DataTextField = "ThemePath";
                    this.AdminTheme.DataSource = adminList;
                    this.AdminTheme.DataBind();//
                    this.AdminTheme.SelectedValue = siteSelect.AdminTheme;


                    IndexTemID.DataValueField = "ID";
                    IndexTemID.DataTextField = "TemName";
                    IndexTemID.DataSource = TempFactory.GetInstance(this.PageTheme.SelectedValue).GetListByType(0);
                    IndexTemID.DataBind();

                }
            }

            
        }
        protected void PageTheme_SelectedIndexChanged(object sender, EventArgs e)
        {
            IndexTemID.DataValueField = "ID";
            IndexTemID.DataTextField = "TemName";
            IndexTemID.DataSource = TempFactory.GetInstance(this.PageTheme.SelectedValue).GetListByType(0);
            IndexTemID.DataBind();
        }
        /// <summary>
        /// 父级站点
        /// </summary>
        private void BindSiteDrpList()
        {
            List<EbSite.Entity.Sites> s = EbSite.BLL.Sites.Instance.GetSitesTree(0);
            ParentID.DataSource = s;
            ParentID.DataTextField = "SiteName";
            ParentID.DataValueField = "id";
            ParentID.DataBind();
        }
        /// <summary>
        /// 首页采用模板
        /// </summary>
        private void BindTempletDrpList()
        {
            IndexTemID.DataValueField = "ID";
            IndexTemID.DataTextField = "TemName";
            IndexTemID.DataSource = TempFactory.Instance.GetListByType(0);
            IndexTemID.DataBind();
        }
        //皮肤
        private void BindThemeList()
        { 
            //前台皮肤
            ThemesPC pc = new ThemesPC();
            //List<Entity.Themes> pcList = pc.FillList();//

            PageTheme.DataValueField = "ThemePath";
            PageTheme.DataTextField = "ThemePath";
            this.PageTheme.DataSource = ThemesPC.Instance.GetThemeNoUsed;
            this.PageTheme.DataBind();//MobileTheme


            //手机皮肤
            ThemesMobile mobile = new ThemesMobile();
            List<Entity.Themes> mobileList = mobile.FillList();
            MobileTheme.DataValueField = "ThemePath";
            MobileTheme.DataTextField = "ThemePath";
            this.MobileTheme.DataSource = mobileList;
            this.MobileTheme.DataBind();//AdminTheme

            //网站后台皮肤
            ThemesAdmin admin = new ThemesAdmin();
            List<Entity.Themes> adminList =  admin.FillList();
            AdminTheme.DataValueField = "ThemePath";
            AdminTheme.DataTextField = "ThemePath";
            this.AdminTheme.DataSource = adminList;
            this.AdminTheme.DataBind();//
        }
        
        public override string Permission
        {
            get
            {
                return "318";
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
            BLL.Sites.Instance.InitModifyCtr(int.Parse(SID), phCtrList);
            SiteFolder.Enabled = false;
        }
        
        override protected void SaveModel()
        {
            string message = "";
            if (!ValidateData(out message))
            {
                base.TipsAlert(message);
                return;
            }
            Base.BLL.OtherColumn cRealname;
            if (SID == "1")
            {
                cRealname = new OtherColumn("ParentID", "0");
                lstOtherColumn.Add(cRealname);
                cRealname = new OtherColumn("IsNoSys", "false");
                lstOtherColumn.Add(cRealname);
            }
            else
            {
                cRealname = new OtherColumn("IsNoSys", "true");
                lstOtherColumn.Add(cRealname);
            }
            
           int sid =  BLL.Sites.Instance.SaveEntityFromCtr(phCtrList, lstOtherColumn);
           //如果创建成功，将一些与站点ID相关的数据修改过来，因为所选皮肤有可能是从其他站点导出来的，记录着其他站点的ID
           if (sid < 1) sid = int.Parse(SID);
            if (sid>0)
            {
                List<EbSite.Entity.Sites> lst = EbSite.BLL.Sites.Instance.FillList();

                foreach (Sites mdsites in lst)
                {
                    if (!AppStartInit.Sites.ContainsKey(mdsites.id))
                        AppStartInit.Sites.Add(mdsites.id, mdsites);
                }
                

                BLL.ThemesPC.Instance.ResetSiteID(sid, PageTheme.SelectedValue);
                WebModel objWM = new WebModel(sid);
                objWM.ResetSiteID();

                ClassModel objCM = new ClassModel(sid);
                objCM.ResetSiteID();

                FormModel objFM = new FormModel(sid);
                objFM.ResetSiteID();

                //EbSite.BLL.WebModel.Instance.ResetSiteID(sid);
                //EbSite.BLL.ClassModel.Instance.ResetSiteID(sid);
                //EbSite.BLL.FormModel.Instance.ResetSiteID(sid);
            }
            
            Core.Utils.AppRestart();

        }

        private bool ValidateData(out string msg)
        {
            msg = "";
            bool isValidate = true;
            if (string.IsNullOrEmpty(SiteName.Text.Trim()))
            {
                isValidate = false;
                msg += "站点名称不能为空; ";
            }
            if (string.IsNullOrEmpty(ParentID.SelectedValue))
            {
                isValidate = false;
                msg += "父级站点不能为空; ";
            }
            if (string.IsNullOrEmpty(PageTheme.SelectedValue))
            {
                isValidate = false;
                msg += "站点前台皮肤不能为空;";
            }
            if (string.IsNullOrEmpty(AdminTheme.SelectedValue))
            {
                isValidate = false;
                msg += "站点后台皮肤不能为空;";
            }
            if (string.IsNullOrEmpty(MobileTheme.SelectedValue))
            {
                isValidate = false;
                msg += "手机皮肤不能为空;";
            }
            if (string.IsNullOrEmpty(IndexTemID.SelectedValue))
            {
                isValidate = false;
                msg += "首页采用模板不能为空;";
            }
            
            if (!string.IsNullOrEmpty(SID))
            {
                if(SID=="1")
                {
                    
                }
                else
                {
                    if (!string.IsNullOrEmpty(ParentID.SelectedValue))
                    {
                        int pid = int.Parse(ParentID.Text.Trim());
                        if (pid == int.Parse(SID))
                        {
                            isValidate = false;
                            msg += "自己的ID不能和父ID一样;";
                        }
                    }
                }
               
            }
            if (SID != "1")
            {
                if (string.IsNullOrEmpty(SiteFolder.Text.Trim()))
                {
                    isValidate = false;
                    msg += "上传文件目录不能为空;";
                }
                if (string.IsNullOrEmpty(SID))
                {
                    //判断上传文件目录是否存在
                    string FileUrl = Server.MapPath("/" + SiteFolder.Text.Trim());
                    if (Core.FSO.FObject.IsExist(FileUrl, FsoMethod.Folder))
                    {
                        isValidate = false;
                        msg += "上传文件目录已经存在，不能重名！;";
                    }
                }
            }
            return isValidate;
        }

    }
}