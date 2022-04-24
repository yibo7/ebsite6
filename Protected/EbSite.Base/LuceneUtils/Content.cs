using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using EbSite.Entity;
using Lucene.Net.Documents;
using PanGu;
using EbSite.Base.LuceneUtils.FieldConfig;

namespace EbSite.Base.LuceneUtils
{
    public class Content : IInstance<EbSite.Entity.NewsContent>
    {
        private List<FieldConfig.CreateEntity> lstFieldConfig;
        private List<FieldConfig.SearchEntity> lstSearchField;
        public Content(int _SitID) : base(_SitID)
        {
            FieldConfig.CreateBLL bll = new FieldConfig.CreateBLL(_SitID);
            lstFieldConfig = bll.FillList();
            //ClassID必选，所以这里加上
            lstFieldConfig.Add(new CreateEntity() { FieldName = "ClassID", FieldType = "System.Int32", SearchType = 3, SearchTypeName = "不可搜索但能存取,如Url" });

            FieldConfig.SearchBLL bllSearchField = new FieldConfig.SearchBLL(_SitID);
            lstSearchField = bllSearchField.FillList();
        }
        public override string KeyFieldName
        {
            get { return "id"; }
        }

        public override string IndexStoreFolder
        {
            get
            {
                return  "content";
            }
        }

        private FieldEntity GetFieldEntity(FieldConfig.CreateEntity fc, NewsContent model)
        {
            FieldEntity mdFieldEntity = new FieldEntity();
            mdFieldEntity.FieldName = fc.FieldName;
            

            switch (fc.SearchType)
            {
                case 1://分词搜索且能存取
                    mdFieldEntity.FieldIndex = Field.Index.TOKENIZED;
                    mdFieldEntity.FieldStore = Field.Store.YES;
                    break;
                case 2://分词搜索但不能存取
                    mdFieldEntity.FieldIndex = Field.Index.TOKENIZED;
                    mdFieldEntity.FieldStore = Field.Store.NO;
                    break;
                case 3://不可搜索但能存取,如Url
                    mdFieldEntity.FieldIndex = Field.Index.NO;
                    mdFieldEntity.FieldStore = Field.Store.YES;
                    break;
                case 4://整词搜索且能存取
                    mdFieldEntity.FieldIndex = Field.Index.UN_TOKENIZED;
                    mdFieldEntity.FieldStore = Field.Store.YES;
                    break;
                case 5://整词搜索但不能存取
                    mdFieldEntity.FieldIndex = Field.Index.UN_TOKENIZED;
                    mdFieldEntity.FieldStore = Field.Store.NO;
                    break;
                default:
                    mdFieldEntity.FieldIndex = Field.Index.TOKENIZED;
                    mdFieldEntity.FieldStore = Field.Store.YES;
                    break;

            }

            #region 设置字段值

            switch (fc.FieldName)
            {
                case "SiteID":
                    mdFieldEntity.FieldValue = model.SiteID.ToString();
                    break;
                case "UserID":
                    mdFieldEntity.FieldValue = model.UserID.ToString();
                    break;
                case "UserNiName":
                    mdFieldEntity.FieldValue = model.UserNiName;
                    break;
                case "Advs":
                    mdFieldEntity.FieldValue = model.Advs.ToString();
                    break;
                case "IsAuditing":
                    mdFieldEntity.FieldValue = model.IsAuditing.ToString();
                    break;
                case "ClassName":
                    mdFieldEntity.FieldValue = model.ClassName;
                    break;
                case "SmallPic":
                    mdFieldEntity.FieldValue = model.SmallPic;
                    break;
                case "NewsTitle":
                    mdFieldEntity.FieldValue = model.NewsTitle;
                    break;
                case "TitleStyle":
                    mdFieldEntity.FieldValue = model.TitleStyle;
                    break;
                case "ClassID":
                    mdFieldEntity.FieldValue = model.ClassID.ToString();
                    break;
                case "hits":
                    mdFieldEntity.FieldValue = model.hits.ToString();
                    break;
                case "IsGood":
                    mdFieldEntity.FieldValue = model.IsGood.ToString();
                    break;
                case "ContentInfo":
                    mdFieldEntity.FieldValue = model.ContentInfo;
                    break;
                case "dayHits":
                    mdFieldEntity.FieldValue = model.dayHits.ToString();
                    break;
                case "weekHits":
                    mdFieldEntity.FieldValue = model.weekHits.ToString();
                    break;
                case "monthhits":
                    mdFieldEntity.FieldValue = model.monthhits.ToString();
                    break;
                case "lasthitstime":
                    mdFieldEntity.FieldValue = model.lasthitstime.ToString();
                    break;
                case "TagIDs":
                    mdFieldEntity.FieldValue = model.TagIDs;
                    break;
                case "OrderID":
                    mdFieldEntity.FieldValue = model.OrderID.ToString();
                    break;
                case "HtmlName":
                    mdFieldEntity.FieldValue = model.HtmlName;
                    break;
                //case "ContentTemID":
                //    mdFieldEntity.FieldValue = model.ContentTemID.ToString();
                //    break;
                case "ContentHtmlNameRule":
                    mdFieldEntity.FieldValue = model.ContentHtmlNameRule;
                    break;
                case "MarkIsMakeHtml":
                    mdFieldEntity.FieldValue = model.MarkIsMakeHtml.ToString();
                    break;
                case "IsComment":
                    mdFieldEntity.FieldValue = model.IsComment.ToString();
                    break;
                case "AddTime":
                    mdFieldEntity.FieldValue = model.AddTime.ToString();
                    break;
                case "UserName":
                    mdFieldEntity.FieldValue = model.UserName;
                    break;
                case "Annex1":
                    mdFieldEntity.FieldValue = model.Annex1;
                    break;
                case "Annex2":
                    mdFieldEntity.FieldValue = model.Annex2;
                    break;
                case "Annex3":
                    mdFieldEntity.FieldValue = model.Annex3;
                    break;
                case "Annex4":
                    mdFieldEntity.FieldValue = model.Annex4;
                    break;
                case "Annex5":
                    mdFieldEntity.FieldValue = model.Annex5;
                    break;
                case "Annex6":
                    mdFieldEntity.FieldValue = model.Annex6;
                    break;
                case "Annex7":
                    mdFieldEntity.FieldValue = model.Annex7;
                    break;
                case "Annex8":
                    mdFieldEntity.FieldValue = model.Annex8;
                    break;
                case "Annex9":
                    mdFieldEntity.FieldValue = model.Annex9;
                    break;
                case "Annex10":
                    mdFieldEntity.FieldValue = model.Annex10;
                    break;
                case "Annex11":

                    mdFieldEntity.FieldValue = model.Annex11.ToString();
                    break;
                case "Annex12":
                    mdFieldEntity.FieldValue = model.Annex12.ToString();
                    break;
                case "Annex13":
                    mdFieldEntity.FieldValue = model.Annex13.ToString();
                    break;
                case "Annex14":
                    mdFieldEntity.FieldValue = model.Annex14.ToString();
                    break;
                case "Annex15":
                    mdFieldEntity.FieldValue = model.Annex15.ToString();
                    break;
                case "Annex16":
                    mdFieldEntity.FieldValue = model.Annex16.ToString();
                    break;
                case "Annex17":
                    mdFieldEntity.FieldValue = model.Annex17.ToString();
                    break;
                case "Annex18":
                    mdFieldEntity.FieldValue = model.Annex18.ToString();
                    break;
                case "Annex19":
                    mdFieldEntity.FieldValue = model.Annex19.ToString();
                    break;
                case "Annex20":
                    mdFieldEntity.FieldValue = model.Annex20.ToString();
                    break;

                case "Annex21":

                    mdFieldEntity.FieldValue = model.Annex21.ToString();
                    break;
                case "Annex22":
                    mdFieldEntity.FieldValue = model.Annex22.ToString();
                    break;
                case "Annex23":
                    mdFieldEntity.FieldValue = model.Annex23.ToString();
                    break;
                case "Annex24":
                    mdFieldEntity.FieldValue = model.Annex24.ToString();
                    break;
                case "Annex25":
                    mdFieldEntity.FieldValue = model.Annex25.ToString();
                    break;

                case "CommentNum":
                    mdFieldEntity.FieldValue = model.CommentNum.ToString();
                    break;
                case "FavorableNum":
                    mdFieldEntity.FieldValue = model.FavorableNum.ToString();
                    break;

            }
            #endregion


            return mdFieldEntity;
        }

        public override void Add(EbSite.Entity.NewsContent model)
        {
            List<FieldEntity> fieldList = new List<FieldEntity>();


            foreach (FieldConfig.CreateEntity fc in lstFieldConfig)
            {
                fieldList.Add(GetFieldEntity(fc, model));
            }
          
            LuceneAdd(model.ID.ToString(), fieldList);
        }

        public override void Delete(string id)
        {
            LuceneDelete(id);
        }

        public override void Update(EbSite.Entity.NewsContent model)
        {
            LuceneUpdate(model.ID.ToString(), model);
        }

        private void SetValue(NewsContent model, string value,string fieldname)
        {
            
            switch (fieldname)
            {
                case "SiteID":
                    model.SiteID = int.Parse(value);
                    break;
                case "UserID":
                    model.UserID = int.Parse(value);
                    break;
                case "UserNiName":
                    model.UserNiName = value;
                    break;
                case "Advs":
                    model.Advs = int.Parse(value);
                    break;
                case "IsAuditing":
                    model.IsAuditing = bool.Parse(value);
                    break;
                case "ClassName":
                    model.ClassName= value;;
                    break;
                case "SmallPic":
                    model.SmallPic= value;;
                    break;
                case "NewsTitle":
                    model.NewsTitle= value;
                    break;
                case "TitleStyle":
                    model.TitleStyle= value;
                    break;
                case "ClassID":
                    model.ClassID = int.Parse(value);
                    break;
                case "hits":
                    model.hits = int.Parse(value);
                    break;
                case "IsGood":
                    model.IsGood = bool.Parse(value);
                    break;
                case "ContentInfo":
                    model.ContentInfo= value;
                    break;
                case "dayHits":
                    model.dayHits = int.Parse(value);
                    break;
                case "weekHits":
                    model.weekHits = int.Parse(value);
                    break;
                case "monthhits":
                    model.monthhits = int.Parse(value);
                    break;
                case "lasthitstime":
                    model.lasthitstime = DateTime.Parse(value);
                    break;
                case "TagIDs":
                    model.TagIDs = value;
                    break;
                case "OrderID":
                    model.OrderID = int.Parse(value);
                    break;
                case "HtmlName":
                    model.HtmlName = value;
                    break;
                //case "ContentTemID":
                //    model.ContentTemID = new Guid(value);
                //    break;
                case "ContentHtmlNameRule":
                    model.ContentHtmlNameRule = value;
                    break;
                case "MarkIsMakeHtml":
                    model.MarkIsMakeHtml = bool.Parse(value);
                    break;
                case "IsComment":
                    model.IsComment = bool.Parse(value);
                    break;
                case "AddTime":
                    model.AddTime = DateTime.Parse(value);
                    break;
                case "UserName":
                    model.UserName = value;
                    break;
                case "Annex1":
                    model.Annex1 = value;
                    break;
                case "Annex2":
                    model.Annex2 = value;
                    break;
                case "Annex3":
                    model.Annex3 = value;
                    break;
                case "Annex4":
                    model.Annex4 = value;
                    break;
                case "Annex5":
                    model.Annex5 = value;
                    break;
                case "Annex6":
                    model.Annex6 = value;
                    break;
                case "Annex7":
                    model.Annex7 = value;
                    break;
                case "Annex8":
                    model.Annex8 = value;
                    break;
                case "Annex9":
                    model.Annex9 = value;
                    break;
                case "Annex10":
                    model.Annex10 = value;
                    break;
                case "Annex11":

                    model.Annex11 = int.Parse(value);
                    break;
                case "Annex12":
                    model.Annex12 = int.Parse(value);
                    break;
                case "Annex13":
                    model.Annex13 = int.Parse(value);
                    break;
                case "Annex14":
                    model.Annex14 = int.Parse(value);
                    break;
                case "Annex15":
                    model.Annex15 = int.Parse(value);
                    break;
                case "Annex16":
                    model.Annex16 = decimal.Parse(value);
                    break;
                case "Annex17":
                    model.Annex17 = decimal.Parse(value);
                    break;
                case "Annex18":
                    model.Annex18 = decimal.Parse(value);
                    break;
                case "Annex19":
                    model.Annex19 = float.Parse(value);
                    break;
                case "Annex20":
                    model.Annex20 = float.Parse(value);
                    break;

                case "Annex21":

                    model.Annex21 = int.Parse(value);
                    break;
                case "Annex22":
                    model.Annex22 = int.Parse(value);
                    break;
                case "Annex23":
                    model.Annex23 = int.Parse(value);
                    break;
                case "Annex24":
                    model.Annex24 = int.Parse(value);
                    break;
                case "Annex25":
                    model.Annex25 = int.Parse(value);
                    break;

                case "CommentNum":
                    model.CommentNum = int.Parse(value);
                    break;
                case "FavorableNum":
                    model.FavorableNum = int.Parse(value);
                    break;

            }

        }

        public override List<EbSite.Entity.NewsContent> Query(String KeyWord, int PageSize, int PageIndex, out int recCount, string OrderBy,out long time)
        {
            List<EbSite.Entity.NewsContent> result = new List<NewsContent>();
            List<KeyWordField> kwf = new List<KeyWordField>();

            foreach (SearchEntity entity in lstSearchField)
            {
                kwf.Add(new KeyWordField(entity.FieldName, KeyWord));
            }

            List<Document> lst = LuceneSearch(kwf, PageSize, PageIndex, out recCount, OrderBy,out time);

            foreach (Document dc in lst)
            {
                EbSite.Entity.NewsContent md = new NewsContent();

                try
                {
                    md.ID = Core.Utils.StrToInt(dc.Get("id"),0);
                    foreach (FieldConfig.CreateEntity fc in lstFieldConfig)
                    {
                        SetValue(md, dc.Get(fc.FieldName), fc.FieldName);
                    }

                    
                    PanGu.HighLight.SimpleHTMLFormatter simpleHTMLFormatter = new PanGu.HighLight.SimpleHTMLFormatter("<font color=\"red\">", "</font>");
                    PanGu.HighLight.Highlighter highlighter =new PanGu.HighLight.Highlighter(simpleHTMLFormatter,new Segment());
                    highlighter.FragmentSize = 50;

                    foreach (SearchEntity entity in lstSearchField)
                    {
                        string svalue = dc.Get(entity.FieldName);
                        
                        svalue = highlighter.GetBestFragment(KeyWord, svalue);
                        if (!string.IsNullOrEmpty(svalue))
                            SetValue(md, svalue, entity.FieldName);
                    }

                    

                    // 高亮显示设置
                    ////TermQuery tQuery = new TermQuery(new Term("contents", q));

                    //SimpleHTMLFormatter simpleHTMLFormatter = new SimpleHTMLFormatter("<font color=\"red\">", "</font>");
                    //Highlighter highlighter = new Highlighter(simpleHTMLFormatter, new QueryScorer(query));
                    ////关键内容显示大小设置 
                    //highlighter.SetTextFragmenter(new SimpleFragmenter(50));
                    ////取出高亮显示内容
                    //Lucene.Net.Analysis.KTDictSeg.KTDictSegAnalyzer analyzer = new Lucene.Net.Analysis.KTDictSeg.KTDictSegAnalyzer();
                    //TokenStream tokenStream = analyzer.TokenStream("contents", new StringReader(news.Content));
                    //news.Abstract = highlighter.GetBestFragment(tokenStream, news.Content);

                }
                catch (Exception e)
                {
                    string sUrl = string.Empty;
                    string referer = "";
                    if (HttpContext.Current != null )
                    {
                        sUrl = HttpContext.Current.Request.RawUrl;
                        referer = HttpContext.Current.Request.ServerVariables["HTTP_REFERER"];
                    }
                    Log.Factory.GetInstance().ErrorLog(string.Concat("lucene查询出错:", e.Message, " 来源：", sUrl, " 来路：", referer));
                    //Host.Instance.InsertLog();
                }
                finally
                {
                    result.Add(md);
                    
                }
            }
            return result;
        }
    }
}
