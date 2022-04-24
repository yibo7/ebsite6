using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web.UI.WebControls;
using EbSite.Base.Configs.SysConfigs;
using EbSite.BLL;
using EbSite.Core;
using NewsContent = EbSite.Entity.NewsContent;

namespace EbSite.Web.AdminHt.Controls.Admin_Content
{
    public partial class DataInit : EbSite.Base.ControlPage.UserControlBaseSave
    {
        public override string Permission
        {
            get
            {
                return "65";
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

        }

        override protected void SaveModel()
        {

        }

        protected void bntClearOutSiteContent_Click(object sender, EventArgs e)
        {
            //EbSite.BLL.NewsContent.Delete();
        }

        protected void bntSaveAdminSearchFileds_Click(object sender, EventArgs e)
        {
            Entity.DataSettingInfoForContent cf = BLL.DataSettings.Content.Instance.GetConfigCurrent;
            cf.AdminSearchFileds = txtAdminSearchFileds.Text.Trim();
            BLL.DataSettings.Content.Instance.Update(cf);

            //ConfigsControl.Instance.AdminSearchContentFileds = txtAdminSearchFileds.Text.Trim();
            //ConfigsControl.SaveConfig();
        }

        protected void bntContentInitNum_Click(object sender, EventArgs e)
        {

            foreach (var tb in GetModelTable())
            {
                NewsContentSplitTable NewsContentInst = EbSite.Base.AppStartInit.GetNewsContentInst(tb);
                NewsContentInst.ContentInitNum(int.Parse(this.drpContentNumType.SelectedValue), base.GetSiteID);

            }


        }

        //protected void bntContentToDefault_Click(object sender, EventArgs e)
        //{
        //    BLL.NewsContent.ContentToDefault();
        //}
        protected void bntUpdateClassName_Click(object sender, EventArgs e)
        {
            foreach (var tb in GetModelTable())
            {
                NewsContentSplitTable NewsContentInst = EbSite.Base.AppStartInit.GetNewsContentInst(tb);
                NewsContentInst.ContentInitClassName(base.GetSiteID);
            }
        }
        protected void bntUpdateClassForClassName_Click(object sender, EventArgs e)
        {
            foreach (var tb in GetModelTable())
            {
                NewsContentSplitTable NewsContentInst = EbSite.Base.AppStartInit.GetNewsContentInst(tb);

                NewsContentInst.AddClassFormClassName(base.GetSiteID);
            }
        }
        protected void bntResetGood_Click(object sender, EventArgs e)
        {
            foreach (var tb in GetModelTable())
            {
                NewsContentSplitTable NewsContentInst = EbSite.Base.AppStartInit.GetNewsContentInst(tb);

                NewsContentInst.ContentInitNum(100, base.GetSiteID);
            }
        }
        //protected void bntReSetContentConfigs_Click(object sender, EventArgs e)
        //{
        //    string sClassID = this.txtClassID2.Text.Trim();
        //    int iClassID = 0;
        //    if (!string.IsNullOrEmpty(sClassID))
        //    {
        //        iClassID = int.Parse(sClassID);
        //    }
        //    else
        //    {
        //        sClassID = this.mcClassList2.CtrlValue;
        //        if (!string.IsNullOrEmpty(sClassID))
        //        {
        //            iClassID = int.Parse(sClassID);
        //        }
        //    }

        //    //后来发布，内容不存在模型ID，只读取其分类设置里的模型ID
        //    //Guid ContentModelID = string.IsNullOrEmpty(this.mcContentModel2.CtrlValue.Trim()) ? Guid.Empty : new Guid(this.mcContentModel2.CtrlValue);


        //    Guid ContentTemID = string.IsNullOrEmpty(this.mcContentTem2.CtrlValue.Trim()) ? Guid.Empty : new Guid(this.mcContentTem2.CtrlValue);

        //    BLL.NewsContent.UpdateConfigsofContent(iClassID, Guid.Empty, ContentTemID, this.cbContentSubClass.Checked, base.GetSiteID);
        //}

        private void BindFiledsOfContentType()
        {
            string sv = string.Empty;
            int iIndex = int.Parse(this.drpContentType.SelectedValue);
            this.drpContentFileds.DataSource = this.GetFileds(WebModel.Instance.aColums);
            this.drpContentFileds.DataBind();
            switch (iIndex)
            {
                case 0:
                    sv = BLL.DataSettings.Content.Instance.GetConfigCurrent.SearchFileds_Widget;

                    break;

                case 1:
                    sv = BLL.DataSettings.Content.Instance.GetConfigCurrent.SearchFileds_So;//ConfigsControl.Instance.ContentFileds_So;
                    break;

                case 2:
                    sv = BLL.DataSettings.Content.Instance.GetConfigCurrent.SearchFileds_Tagv;// ConfigsControl.Instance.ContentFileds_Tagv; 
                    break;


            }
            ControlManage.SetItemsList(this.drpContentFileds.Items, sv);
        }



        protected void bntSaveContentFileds_Click(object sender, EventArgs e)
        {
            string sFileds = this.GetContentFileds();

            Entity.DataSettingInfoForContent cf = BLL.DataSettings.Content.Instance.GetConfigCurrent;
            cf.AdminSearchFileds = txtAdminSearchFileds.Text.Trim();


            switch (int.Parse(this.drpContentType.SelectedValue))
            {
                case 0:
                    //ConfigsControl.Instance.ContentFileds_Widget = sFileds;
                    cf.SearchFileds_Widget = sFileds;
                    break;

                case 1:
                    //ConfigsControl.Instance.ContentFileds_So = sFileds;
                    cf.SearchFileds_So = sFileds;
                    break;

                case 2:
                    //ConfigsControl.Instance.ContentFileds_Tagv = sFileds;
                    cf.SearchFileds_Tagv = sFileds;
                    break;

            }
            BLL.DataSettings.Content.Instance.Update(cf);
            //ConfigsControl.SaveConfig();
        }
        protected void drpContentType_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.BindFiledsOfContentType();
        }
        private string GetContentFileds()
        {
            return ControlManage.GetItemsListOfString(this.drpContentFileds.Items);
        }

        private List<string> GetFileds(string[] afileds)
        {
            List<string> lst = new List<string>();

            EbSite.Entity.NewsContent md = new NewsContent();

            //List<PropertyInfo> list = new List<PropertyInfo>();
            PropertyInfo[] properties = md.GetType().GetProperties();
            foreach (PropertyInfo info in properties)
            {
                if (info.Name != "ID" && info.Name != "Fileds")
                    lst.Add(info.Name);
            }
            return lst;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!base.IsPostBack)
            {

                InitContentTables();
                this.BindFiledsOfContentType();
                BindContentTables();
                txtAdminSearchFileds.Text = BLL.DataSettings.Content.Instance.GetConfigCurrent.AdminSearchFileds;// ConfigsControl.Instance.AdminSearchContentFileds;

            }
        }
        /// <summary>
        /// 清理  内容
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnClearData_Click(object sender, EventArgs e)
        {

            string StrSiteIds = "";
            List<Entity.Sites> ls = BLL.Sites.Instance.FillList();
            foreach (var site in ls)
            {
                StrSiteIds += site.id + ",";
            }
            if (StrSiteIds.Length > 0)
                StrSiteIds = StrSiteIds.Remove(StrSiteIds.Length - 1, 1);

            foreach (var tb in GetModelTable())
            {
                NewsContentSplitTable NewsContentInst = EbSite.Base.AppStartInit.GetNewsContentInst(tb);
                NewsContentInst.DeleteOutSiteData(StrSiteIds);
            }


            base.TipsAlert("清理完成！");
        }
        private void InitContentTables()
        {

            // WebModel wm = new WebModel();
            List<Entity.ModelClass> ls = EbSite.BLL.WebModel.Instance.ModelClassList; //wm.ModelClassList;
            List<Entity.ModelClass> nls = (from i in ls where (i.TableName != null && i.TableName.ToLower() != "newscontent") select i).ToList();
            drpContentTables.DataTextField = "TableName";
            drpContentTables.DataValueField = "TableName";

            if (nls.Count > 0)
            {
                drpContentTables.DataSource = nls;
                drpContentTables.DataBind();
            }

            drpContentTables.Items.Insert(0, new ListItem("NewsContent", "NewsContent"));
        }



        private void BindContentTables()
        {
            string sv = string.Empty;
            sv = BLL.DataSettings.Content.Instance.GetConfigCurrent.ContentTables;
            if (!string.IsNullOrEmpty(sv))
                ControlManage.SetItemsList(this.drpContentTables.Items, sv);
        }
        //选择NewsContent以外的分表作为 搜索和排行的数据源
        protected void bntSaveContentTables_Click(object sender, EventArgs e)
        {
            string sTable = ControlManage.GetItemsListOfString(this.drpContentTables.Items);

            if (!string.IsNullOrEmpty(sTable))
            {
                Entity.DataSettingInfoForContent cf = BLL.DataSettings.Content.Instance.GetConfigCurrent;
                cf.ContentTables = sTable;
                BLL.DataSettings.Content.Instance.Update(cf);
            }
            else
            {
                base.TipsAlert("请选择表！");
            }
        }
        //YHL 2014-2-11 得到当前站点下的 模型中所有表的名称 做为 清理，规零，分类名称对应。
        private List<string> GetModelTable()
        {
            List<EbSite.Entity.ModelClass> ls = EbSite.BLL.WebModel.Instance.ModelClassList;
            List<string> nls = new List<string>();
            foreach (var li in ls)
            {
                if (string.IsNullOrEmpty(li.TableName))
                {
                    li.TableName = "newscontent"; //默认为 系统的
                }
                int icount = (from i in nls select i == "newscontent").Count();
                if (icount == 0)
                    nls.Add(li.TableName);
            }

            return nls;
        }
    }
}