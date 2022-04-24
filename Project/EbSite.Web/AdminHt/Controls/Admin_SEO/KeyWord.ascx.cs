using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.Configs.ContentSet;
using EbSite.Base.ControlPage;
using EbSite.Base.EntityCustom;

namespace EbSite.Web.AdminHt.Controls.Admin_SEO
{
    public partial class KeyWord : UserControlBaseSave
    {
        public override string Permission
        {
            get
            {
                return "276";
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
            throw new NotImplementedException();
        }
        override protected void SaveModel()
        {
            #region 旧

            //#region seo

            //ConfigsControl.Instance.SeoClassDes = txtSeoClassDes.Text;
            //ConfigsControl.Instance.SeoClassKeyWord = txtSeoClassKeyWord.Text;
            //ConfigsControl.Instance.SeoClassTitle = txtSeoClassTitle.Text;

            //ConfigsControl.Instance.SeoContentDes = txtSeoContentDes.Text;
            //ConfigsControl.Instance.SeoContentKeyWord = txtSeoContentKeyWord.Text;
            //ConfigsControl.Instance.SeoContentTitle = txtSeoContentTitle.Text;

            //ConfigsControl.Instance.SeoSpecialDes = txtSeoSpecialDes.Text;
            //ConfigsControl.Instance.SeoSpecialTitle = txtSeoSpecialTitle.Text;
            //ConfigsControl.Instance.SeoSpecialKeyWord = txtSeoSpecialKeyWord.Text;





            //ConfigsControl.Instance.SeoTagIndexDes = txtSeoTagIndexDes.Text;
            //ConfigsControl.Instance.SeoTagIndexKeyWord = txtSeoTagIndexKeyWord.Text;
            //ConfigsControl.Instance.SeoTagIndexTitle = txtSeoTagIndexTitle.Text;

            //ConfigsControl.Instance.SeoTagListDes = txtSeoTagListDes.Text;
            //ConfigsControl.Instance.SeoTagListTitle = txtSeoTagListTitle.Text;
            //ConfigsControl.Instance.SeoTagListKeyWord = txtSeoTagListKeyWord.Text;

            //ConfigsControl.Instance.SeoSiteIndexDes = txtSeoSiteIndexDes.Text;
            //ConfigsControl.Instance.SeoSiteIndexTitle = txtSeoSiteIndexTitle.Text;
            //ConfigsControl.Instance.SeoSiteIndexKeyWord = txtSeoSiteIndexKeyWord.Text;
            //#endregion
            // ConfigsControl.SaveConfig();
            #endregion

            List<EbSite.Base.EntityCustom.SeoSite> ls = BLL.SeoSites.Instance.FillList();
            int siteid = base.GetSiteID;
            List<EbSite.Base.EntityCustom.SeoSite> mls = (from i in ls where i.SiteID == siteid select i).ToList();

            if(mls.Count>0)
                BLL.SeoSites.Instance.Delete(mls[0].id);


            EbSite.Base.EntityCustom.SeoSite md = new SeoSite();
            md.SeoClassDes = txtSeoClassDes.Text;
            md.SeoClassKeyWord = txtSeoClassKeyWord.Text;
            md.SeoClassTitle = txtSeoClassTitle.Text;

            md.SeoContentDes = txtSeoContentDes.Text;
            md.SeoContentKeyWord = txtSeoContentKeyWord.Text;
            md.SeoContentTitle = txtSeoContentTitle.Text;

            md.SeoSpecialDes = txtSeoSpecialDes.Text;
            md.SeoSpecialTitle = txtSeoSpecialTitle.Text;
            md.SeoSpecialKeyWord = txtSeoSpecialKeyWord.Text;





            md.SeoTagIndexDes = txtSeoTagIndexDes.Text;
            md.SeoTagIndexKeyWord = txtSeoTagIndexKeyWord.Text;
            md.SeoTagIndexTitle = txtSeoTagIndexTitle.Text;

            md.SeoTagListDes = txtSeoTagListDes.Text;
            md.SeoTagListTitle = txtSeoTagListTitle.Text;
            md.SeoTagListKeyWord = txtSeoTagListKeyWord.Text;

            md.SeoSiteIndexDes = txtSeoSiteIndexDes.Text;
            md.SeoSiteIndexTitle = txtSeoSiteIndexTitle.Text;
            md.SeoSiteIndexKeyWord = txtSeoSiteIndexKeyWord.Text;
            md.SiteID = base.GetSiteID;

            EbSite.BLL.SeoSites.Instance.Add(md);
            EbSite.Base.AppStartInit.UpdateInitJs();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {




                #region seo

                //txtSeoClassDes.Text = ConfigsControl.Instance.SeoClassDes;
                //txtSeoClassKeyWord.Text = ConfigsControl.Instance.SeoClassKeyWord;
                //txtSeoClassTitle.Text = ConfigsControl.Instance.SeoClassTitle;

                //txtSeoContentDes.Text = ConfigsControl.Instance.SeoContentDes;
                //txtSeoContentKeyWord.Text = ConfigsControl.Instance.SeoContentKeyWord;
                //txtSeoContentTitle.Text = ConfigsControl.Instance.SeoContentTitle;

                //txtSeoSpecialDes.Text = ConfigsControl.Instance.SeoSpecialDes;
                //txtSeoSpecialTitle.Text = ConfigsControl.Instance.SeoSpecialTitle;
                //txtSeoSpecialKeyWord.Text = ConfigsControl.Instance.SeoSpecialKeyWord;




                //txtSeoTagIndexDes.Text = ConfigsControl.Instance.SeoTagIndexDes;
                //txtSeoTagIndexKeyWord.Text = ConfigsControl.Instance.SeoTagIndexKeyWord;
                //txtSeoTagIndexTitle.Text = ConfigsControl.Instance.SeoTagIndexTitle;

                //txtSeoTagListDes.Text = ConfigsControl.Instance.SeoTagListDes;
                //txtSeoTagListTitle.Text = ConfigsControl.Instance.SeoTagListTitle;
                //txtSeoTagListKeyWord.Text = ConfigsControl.Instance.SeoTagListKeyWord;


                //txtSeoSiteIndexDes.Text = ConfigsControl.Instance.SeoSiteIndexDes;
                //txtSeoSiteIndexTitle.Text = ConfigsControl.Instance.SeoSiteIndexTitle;
                //txtSeoSiteIndexKeyWord.Text = ConfigsControl.Instance.SeoSiteIndexKeyWord;
                #endregion

                List<EbSite.Base.EntityCustom.SeoSite> ls = BLL.SeoSites.Instance.FillList();
                int siteid = base.GetSiteID;
                List<EbSite.Base.EntityCustom.SeoSite> md = (from i in ls where i.SiteID == siteid select i).ToList();
                if (md.Count > 0)
                {
                    txtSeoClassDes.Text = md[0].SeoClassDes;
                    txtSeoClassKeyWord.Text = md[0].SeoClassKeyWord;
                    txtSeoClassTitle.Text = md[0].SeoClassTitle;

                    txtSeoContentDes.Text = md[0].SeoContentDes;
                    txtSeoContentKeyWord.Text = md[0].SeoContentKeyWord;
                    txtSeoContentTitle.Text = md[0].SeoContentTitle;

                    txtSeoSpecialDes.Text = md[0].SeoSpecialDes;
                    txtSeoSpecialTitle.Text = md[0].SeoSpecialTitle;
                    txtSeoSpecialKeyWord.Text = md[0].SeoSpecialKeyWord;




                    txtSeoTagIndexDes.Text = md[0].SeoTagIndexDes;
                    txtSeoTagIndexKeyWord.Text = md[0].SeoTagIndexKeyWord;
                    txtSeoTagIndexTitle.Text = md[0].SeoTagIndexTitle;

                    txtSeoTagListDes.Text = md[0].SeoTagListDes;
                    txtSeoTagListTitle.Text = md[0].SeoTagListTitle;
                    txtSeoTagListKeyWord.Text = md[0].SeoTagListKeyWord;


                    txtSeoSiteIndexDes.Text = md[0].SeoSiteIndexDes;
                    txtSeoSiteIndexTitle.Text = md[0].SeoSiteIndexTitle;
                    txtSeoSiteIndexKeyWord.Text = md[0].SeoSiteIndexKeyWord;
                }
                else
                {
                    lbNoSetInfo.Text = "请注意，您还没有配置关键词，系统将采用默认的关键词";
                }
            }
        }

    }
}