using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.BLL;
using EbSite.Base;
using EbSite.Base.ControlPage;
using EbSite.Control.xsPage;
using NewsContent = EbSite.Entity.NewsContent;

namespace EbSite.Web.AdminHt.Controls.Admin_Lucene
{
    public partial class IndexManager : UserControlListBase
    {
        private Base.LuceneUtils.FieldConfig.CreateBLL bll;
        private Base.LuceneUtils.FieldConfig.SearchBLL bllSearch;
        public IndexManager()
        {
            bll = new Base.LuceneUtils.FieldConfig.CreateBLL(GetSiteID);
            bllSearch = new Base.LuceneUtils.FieldConfig.SearchBLL(GetSiteID);
        }
        public override string Permission
        {
            get
            {
                return "304";
            }
        }
        public override string PermissionDelID
        {
            get
            {
                return "304";
            }
        }
        override protected string AddUrl
        {
            get { throw new NotImplementedException(); }
        }
        override protected object LoadList(out int iCount)
        {
            iCount = 0;
            return bll.FillList();
        }
        override protected object SearchList(out int iCount)
        {
            throw new NotImplementedException();
        }
        override protected void Delete(object iID)
        {
            bll.Delete(int.Parse(iID.ToString()));

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!base.IsPostBack)
            {
                this.GetFileds();
                BindSearchField();
            }
        }
        private void BindSearchField()
        {
            lsbSearchFields.DataTextField = "FieldName";
            lsbSearchFields.DataValueField = "id";
            lsbSearchFields.DataSource = bllSearch.FillList();
            lsbSearchFields.DataBind();
        }
        private void GetFileds()
        {
           
            EbSite.Entity.NewsContent md = new NewsContent();

            PropertyInfo[] properties = md.GetType().GetProperties();
            foreach (PropertyInfo info in properties)
            {
                if (info.Name != "ID" && info.Name != "Fileds" && info.Name != "ClassID")
                {
                    //lst.Add(new ListItem(info.Name, info.PropertyType.ToString()));
                    drpContentFileds.Items.Add(new ListItem(info.Name, string.Concat(info.PropertyType.ToString(), "-", info.Name)));
                    drpContentFileds2.Items.Add(new ListItem(info.Name, string.Concat(info.PropertyType.ToString(), "-", info.Name)));
                }
                    
            }
           
        }
     
        protected void bntSave_Click(object sender, EventArgs e)
        {
            EbSite.Base.LuceneUtils.IInstance<EbSite.Entity.NewsContent> LuceneContent = new EbSite.Base.LuceneUtils.Content(GetSiteID);

            LuceneContent.Rebuild();//清理原有索引

            LuceneContent.CreateIndex();

            //YHL 2014-2-11 遍历在 内容管理=》数据调整=》所选择的 专题的表 做为 批量添加专题的数据源
            string sv = string.Empty;
            sv = EbSite.BLL.DataSettings.Content.Instance.GetConfigCurrent.ContentTables;
            if (!string.IsNullOrEmpty(sv))
            {
                string[] arryTb = sv.Split(',');
                foreach (string TableName in arryTb)
                {
                    EbSite.BLL.NewsContentSplitTable NewsContentInst = AppStartInit.GetNewsContentInst(TableName);

                    int icount = NewsContentInst.GetCount("", GetSiteID);
                    int iPageSite = 500;
                    int iPageCount = Core.Utils.GetPageCount(icount, iPageSite);
                    for (int i = 1; i <= iPageCount; i++)
                    {
                        List<EbSite.Entity.NewsContent> lst = NewsContentInst.GetListPages(i, iPageSite, out icount,
                                                                                           GetSiteID);
                        foreach (NewsContent newsContent in lst)
                        {
                            newsContent.ContentInfo = Core.Strings.GetString.ClearHtml(newsContent.ContentInfo);
                            LuceneContent.Add(newsContent);
                        }
                    }
                    int iCount = LuceneContent.EndCreate();

                    lbTips.Text = string.Format("生成成功,一共生成记录{0}条", iCount);
                }
            }
        }

        protected void bntAddFiled_Click(object sender, EventArgs e)
        {
            Base.LuceneUtils.FieldConfig.CreateEntity md = new Base.LuceneUtils.FieldConfig.CreateEntity();
            md.FieldName = drpContentFileds.SelectedItem.Text;
            md.FieldType = drpContentFileds.SelectedValue.Replace(string.Concat("-", md.FieldName), "");//drpContentFileds这样的控件value相同时有点bug
            if (!string.IsNullOrEmpty(md.FieldName))
            {

                md.SearchTypeName = drpSearchType.SelectedItem.Text;
                md.SearchType = int.Parse(drpSearchType.SelectedValue);

                bll.Add(md);
                base.gdList_Bind();
            }

           
        }

        protected void bntAddFiledForSearch_Click(object sender, EventArgs e)
        {
            Base.LuceneUtils.FieldConfig.SearchEntity md = new Base.LuceneUtils.FieldConfig.SearchEntity();
            md.FieldName = drpContentFileds2.SelectedItem.Text;
            md.FieldType = drpContentFileds2.SelectedValue.Replace(string.Concat("-", md.FieldName), "");//drpContentFileds这样的控件value相同时有点bug
            bllSearch.Add(md);
            BindSearchField();
        }

        protected void bntDelSearchField_Click(object sender, EventArgs e)
        {
            foreach (ListItem item in lsbSearchFields.Items)
            {
                if (item.Selected)
                {
                    bllSearch.Delete(int.Parse(item.Value));
                }
            }
            BindSearchField();
        }
    }
}