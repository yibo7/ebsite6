using System;
using System.Collections.Generic;
using EbSite.Base.Configs.SysConfigs;
using EbSite.BLL;
using EbSite.Core;
using EbSite.Entity;
using NewsClass = EbSite.Entity.NewsClass;

namespace EbSite.Web.AdminHt.Controls.Admin_Class
{
    public partial class SetClassInit : Base.ControlPage.UserControlBaseSave
    {
        public override string Permission
        {
            get
            {
                return "59";
            }
        }
        override protected string KeyColumnName
        {
            get
            {
                throw new NotImplementedException();
            }
        }
        override protected void InitModifyCtr()
        {
            throw new NotImplementedException();
        }
        override protected void SaveModel()
        {
            throw new NotImplementedException();
        }
        protected void Page_Load(object sender, EventArgs e)
        {

            //drpModels.DataSource = drpModels.DataSource = BLL.ClassModel.Instance.ModelClassList;
            //drpModels.DataValueField = "ID";
            //drpModels.DataTextField = "ModelName";
            //drpModels.DataBind();
            if (!IsPostBack)
            {


                this.drpClassFileds.DataSource = this.GetFileds(ClassModel.Instance.aColums);
                this.drpClassFileds.DataBind();
                this.SetClassFileds();
                txtAdminSearchFileds.Text = BLL.DataSettings.Category.Instance.GetConfigCurrent.AdminSearchFileds;




                //cbCEditItems_ClassHtmlRule.Checked = Base.Configs.HideItem.ConfigsControl.Instance.ClassHtmlRule;
                //cbCEditItems_ContentHtmlRule.Checked = Base.Configs.HideItem.ConfigsControl.Instance.ContentHtmlRule;
                //cbCEditItems_Mt.Checked = Base.Configs.HideItem.ConfigsControl.Instance.Mt;
                //cbCEditItems_Mt_CM.Checked = Base.Configs.HideItem.ConfigsControl.Instance.Mt_CM;
                //cbCEditItems_Mt_CMST.Checked = Base.Configs.HideItem.ConfigsControl.Instance.Mt_CMST;
                //cbCEditItems_Mt_CT.Checked = Base.Configs.HideItem.ConfigsControl.Instance.Mt_CT;
                //cbCEditItems_Mt_CTTM.Checked = Base.Configs.HideItem.ConfigsControl.Instance.Mt_CTTM;
                //cbCEditItems_Mt_CTTT.Checked = Base.Configs.HideItem.ConfigsControl.Instance.Mt_CTTT;
                //cbCEditItems_PageNum.Checked = Base.Configs.HideItem.ConfigsControl.Instance.PageNum;
                //cbCEditItems_Sel.Checked = Base.Configs.HideItem.ConfigsControl.Instance.Sel;
                //cbCEditItems_Sel_AddClass.Checked = Base.Configs.HideItem.ConfigsControl.Instance.Sel_AddClass;
                //cbCEditItems_Sel_AddContent.Checked = Base.Configs.HideItem.ConfigsControl.Instance.Sel_AddContent;
                //cbCEditItems_Sel_CModule.Checked = Base.Configs.HideItem.ConfigsControl.Instance.Sel_CModule;
                //cbCEditItems_Sel_DayHits.Checked = Base.Configs.HideItem.ConfigsControl.Instance.Sel_DayHits;
                //cbCEditItems_Sel_Hits.Checked = Base.Configs.HideItem.ConfigsControl.Instance.Sel_Hits;
                //cbCEditItems_Sel_MonthHits.Checked = Base.Configs.HideItem.ConfigsControl.Instance.Sel_MonthHits;
                //cbCEditItems_Sel_OutLink.Checked = Base.Configs.HideItem.ConfigsControl.Instance.Sel_OutLink;
                //cbCEditItems_Sel_WeekHits.Checked = Base.Configs.HideItem.ConfigsControl.Instance.Sel_WeekHits;
                //cbCEditItems_Seo.Checked = Base.Configs.HideItem.ConfigsControl.Instance.Seo;
                //cbCEditItems_Seo_Dis.Checked = Base.Configs.HideItem.ConfigsControl.Instance.Seo_Dis;
                //cbCEditItems_Seo_KW.Checked = Base.Configs.HideItem.ConfigsControl.Instance.Seo_KW;
                //cbCEditItems_Seo_Title.Checked = Base.Configs.HideItem.ConfigsControl.Instance.Seo_Title;
                //cbCEditItems_Sub.Checked = Base.Configs.HideItem.ConfigsControl.Instance.Sub;

            }
         

           
        }
        //protected void btnSvae_Click(object sender, EventArgs e)
        //{
        //    //string sModelID = drpModels.SelectedValue;

        //    Entity.DataSettingInfoForClass cf = BLL.DataSettings.Category.Instance.GetConfigCurrent;
        //    cf.DefaultModelID = sModelID;
        //    BLL.DataSettings.Category.Instance.Update(cf);

        //}
        protected void bntSaveAdminSearchFileds_Click(object sender, EventArgs e)
        {
            Entity.DataSettingInfoForClass cf = BLL.DataSettings.Category.Instance.GetConfigCurrent;
            cf.AdminSearchFileds = txtAdminSearchFileds.Text.Trim();
            BLL.DataSettings.Category.Instance.Update(cf);
            
        }

        //protected void bntSetClassEditItems_Click(object sender, EventArgs e)
        //{

            //Base.Configs.HideItem.ConfigsControl.Instance.ClassHtmlRule = cbCEditItems_ClassHtmlRule.Checked;

            //Base.Configs.HideItem.ConfigsControl.Instance.ContentHtmlRule = cbCEditItems_ContentHtmlRule.Checked;

            //Base.Configs.HideItem.ConfigsControl.Instance.Mt = cbCEditItems_Mt.Checked;
            //Base.Configs.HideItem.ConfigsControl.Instance.Mt_CM = cbCEditItems_Mt_CM.Checked;
            //Base.Configs.HideItem.ConfigsControl.Instance.Mt_CMST = cbCEditItems_Mt_CMST.Checked;
            //Base.Configs.HideItem.ConfigsControl.Instance.Mt_CT = cbCEditItems_Mt_CT.Checked;
            //Base.Configs.HideItem.ConfigsControl.Instance.Mt_CTTM = cbCEditItems_Mt_CTTM.Checked;
            //Base.Configs.HideItem.ConfigsControl.Instance.Mt_CTTT = cbCEditItems_Mt_CTTT.Checked;
            //Base.Configs.HideItem.ConfigsControl.Instance.PageNum = cbCEditItems_PageNum.Checked;
            
            //Base.Configs.HideItem.ConfigsControl.Instance.Sel_AddClass = cbCEditItems_Sel_AddClass.Checked;
            //Base.Configs.HideItem.ConfigsControl.Instance.Sel_AddContent = cbCEditItems_Sel_AddContent.Checked;
            //Base.Configs.HideItem.ConfigsControl.Instance.Sel_CModule = cbCEditItems_Sel_CModule.Checked;
            //Base.Configs.HideItem.ConfigsControl.Instance.Sel_DayHits = cbCEditItems_Sel_DayHits.Checked;
            //Base.Configs.HideItem.ConfigsControl.Instance.Sel_Hits = cbCEditItems_Sel_Hits.Checked;
            //Base.Configs.HideItem.ConfigsControl.Instance.Sel_MonthHits = cbCEditItems_Sel_MonthHits.Checked;
            //Base.Configs.HideItem.ConfigsControl.Instance.Sel_OutLink = cbCEditItems_Sel_OutLink.Checked;
            //Base.Configs.HideItem.ConfigsControl.Instance.Sel_WeekHits = cbCEditItems_Sel_WeekHits.Checked;
            
            //Base.Configs.HideItem.ConfigsControl.Instance.Seo_Dis = cbCEditItems_Seo_Dis.Checked;
            //Base.Configs.HideItem.ConfigsControl.Instance.Seo_KW = cbCEditItems_Seo_KW.Checked;
            //Base.Configs.HideItem.ConfigsControl.Instance.Seo_Title = cbCEditItems_Seo_Title.Checked;
            //Base.Configs.HideItem.ConfigsControl.Instance.Sub = cbCEditItems_Sub.Checked;

            //Base.Configs.HideItem.ConfigsControl.Instance.Seo = cbCEditItems_Seo.Checked;
            //Base.Configs.HideItem.ConfigsControl.Instance.Sel = cbCEditItems_Sel.Checked;
            //Base.Configs.HideItem.ConfigsControl.SaveConfig();
            
        //}
        
       
        private List<string> GetFileds(string[] afileds)
        {
            string[] alst = afileds;
            List<string> lst = new List<string>();
            foreach (string s in alst)
            {
                string[] aCr = s.Split(new char[] { '|' });
                lst.Add(aCr[0]);
            }
            return lst;
        }
        protected void bntSaveClassFileds_Click(object sender, EventArgs e)
        {
            Entity.DataSettingInfoForClass cf = BLL.DataSettings.Category.Instance.GetConfigCurrent;
            cf.SearchFileds = this.GetClassFileds();
            BLL.DataSettings.Category.Instance.Update(cf);

            //ConfigsControl.Instance.ClassFileds = this.GetClassFileds();
            //ConfigsControl.SaveConfig();
        }
        private string GetClassFileds()
        {
            return ControlManage.GetItemsListOfString(this.drpClassFileds.Items);
        }
        private void SetClassFileds()
        {
            string sv = BLL.DataSettings.Category.Instance.GetConfigCurrent.SearchFileds;
            ControlManage.SetItemsList(this.drpClassFileds.Items, sv);
           
        }
        
        protected void bntClassInitNum_Click(object sender, EventArgs e)
        {
           BLL.NewsClass.ClassInitNum(int.Parse(this.drpClassNumType.SelectedValue));
        }
        //protected void bntClassToDefault_Click(object sender, EventArgs e)
        //{
        //    BLL.NewsClass.ClassToDefault(GetSiteID);
        //}
        protected void bntClassResetOrderID_Click(object sender, EventArgs e)
        {
            BLL.NewsClass.ResetOrderID_Start(base.GetSiteID);
        }

        //protected void bntReSetClassConfigs_Click(object sender, EventArgs e)
        //{
        //    string sClassID = this.txtClassID1.Text.Trim();
        //    int iClassID = 0;
        //    if (!string.IsNullOrEmpty(sClassID))
        //    {
        //        iClassID = int.Parse(sClassID);
        //    }
        //    else
        //    {
        //        sClassID = this.mcClassList1.CtrlValue;
        //        if (!string.IsNullOrEmpty(sClassID))
        //        {
        //            iClassID = int.Parse(sClassID);
        //        }
        //    }
        //    Guid ClassTempID = string.IsNullOrEmpty(this.mcClassTem.CtrlValue.Trim()) ? Guid.Empty : new Guid(this.mcClassTem.CtrlValue);
        //    Guid ClassModelID = string.IsNullOrEmpty(this.mcClassModel.CtrlValue.Trim()) ? Guid.Empty : new Guid(this.mcClassModel.CtrlValue);
        //    Guid ContentModelID = string.IsNullOrEmpty(this.mcContentModel1.CtrlValue.Trim()) ? Guid.Empty : new Guid(this.mcContentModel1.CtrlValue);
        //    Guid ContentTemID = string.IsNullOrEmpty(this.mcContentTem1.CtrlValue.Trim()) ? Guid.Empty : new Guid(this.mcContentTem1.CtrlValue);
        //    BLL.NewsClass.UpdateConfigsofClassAndSub(iClassID, ClassTempID, ClassModelID, ContentModelID, ContentTemID, this.cbClassSubClass.Checked,base.GetSiteID);
        //}
        /// <summary>
        /// 清理 分类
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

            BLL.NewsClass.DeleteOutSiteData(StrSiteIds);

            base.TipsAlert("清理完成！");
        }

        protected void btnClearClassConfig_Click(object sender, EventArgs e)
        {
            Entity.ClassConfigs mdDefaultConfigs = BLL.ClassConfigs.Instance.GetClassConfigs(GetSiteID);
            List<Entity.NewsClass> lst = BLL.NewsClass.GetNotConfigParent(GetSiteID);
            foreach (var model in lst)
            {
                Entity.ClassSetConfig setConfig = new Entity.ClassSetConfig();
                setConfig.ClassId = model.ID;
                setConfig.ConfigId = mdDefaultConfigs.id;
                BLL.ClassSetConfig.Instance.Add(setConfig);
            }

            List<Entity.NewsClass> lstP = BLL.NewsClass.GetParentList(GetSiteID);

            foreach (var mdParent in lstP)
            {
                string Ids = BLL.NewsClass.GetSubIDs(mdParent.ID, GetSiteID);
                if (!string.IsNullOrEmpty(Ids))
                {
                    List<Entity.NewsClass> lstSubs = BLL.NewsClass.GetNotConfigIds(Ids);
                    foreach (var mdSub in lstSubs)
                    {
                        List<Entity.ClassSetConfig> pcfs = BLL.ClassSetConfig.Instance.GetListArray(1, "ClassId=" + mdParent.ID, "");
                        if (pcfs.Count > 0)
                        {
                            Entity.ClassSetConfig pcf = pcfs[0];
                            pcf.ClassId = mdSub.ID;
                            pcf.id = 0;
                            BLL.ClassSetConfig.Instance.Add(pcf);

                        }
                    }
                }
                
            }

           




            //EbSite.BLL.ClassConfigs.Instance.DeleteByClassIDBySite(GetSiteID);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnClassSort_Click(object sender, EventArgs e)
        {
            List<Entity.NewsClass> ls = BLL.NewsClass.GetListArr(base.GetSiteID);
            foreach (var newsClass in ls)
            {
                string pis = "";
                if (newsClass.ParentID != 0)
                {
                    List<Entity.NewsClass> lsParent = BLL.NewsClass.GetParents(newsClass.ID);
                    foreach (var @class in lsParent)
                    {
                        pis += @class.ID + ",";
                    }
                }
                newsClass.ParentIDs = pis;
                BLL.NewsClass.Update(newsClass);
            }
        }
    }
}