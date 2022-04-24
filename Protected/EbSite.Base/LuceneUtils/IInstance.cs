using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using Lucene.Net.Analysis;
using Lucene.Net.Analysis.PanGu;
using Lucene.Net.Analysis.Standard;
using Lucene.Net.Documents;
using Lucene.Net.Index;
using Lucene.Net.QueryParsers;
using Lucene.Net.Search;
using Lucene.Net.Store;
using PanGu;
using Directory = Lucene.Net.Store.Directory;

namespace EbSite.Base.LuceneUtils
{

    abstract public class IInstance<T>  
    {
        public IInstance(int _SiteID)
        {

            SiteID = _SiteID;
        }

        protected int SiteID = 1;
        public abstract string KeyFieldName { get; }

        public abstract string IndexStoreFolder { get; }


        public abstract void Add(T model);
        //public abstract void Add(List<T> model);

        public abstract void Delete(string id);

        public abstract void Update(T model);

        public abstract List<T> Query(String KeyWord, int PageSize, int PageIndex, out int recCount, string OrderBy,out long time);

        //public abstract IInstance<T> NewInstance(int _SiteID);

        #region 创建常用对象


            #region IndexWriter 
        private  IndexWriter _indexwriter = null;
        public  int MaxMergeFactor
        {
            get
            {
                if (_indexwriter != null)
                {
                    return _indexwriter.GetMergeFactor();
                }
                else
                {
                    return 0;
                }
            }

            set
            {
                if (_indexwriter != null)
                {
                    _indexwriter.SetMergeFactor(value);
                }
            }
        }

        public  int MaxMergeDocs
        {
            get
            {
                if (_indexwriter != null)
                {
                    return _indexwriter.GetMaxMergeDocs();
                }
                else
                {
                    return 0;
                }
            }

            set
            {
                if (_indexwriter != null)
                {
                    _indexwriter.SetMaxMergeDocs(value);
                }
            }
        }

        public  int MinMergeDocs
        {
            get
            {
                if (_indexwriter != null)
                {
                    return _indexwriter.GetMaxBufferedDocs();
                }
                else
                {
                    return 0;
                }
            }

            set
            {
                if (_indexwriter != null)
                {
                    _indexwriter.SetMaxBufferedDocs(value);
                }
            }
        }
        
        public void CreateIndex()
        {
            try
            {
                _indexwriter = new IndexWriter(GetIndexStorePath, new PanGuAnalyzer(), false);
            }
            catch
            {
                _indexwriter = new IndexWriter(GetIndexStorePath, new PanGuAnalyzer(), true);
            }
            MaxMergeFactor = 301;
            MinMergeDocs = 301;
        }
        /// <summary>
        /// 清理原有索引
        /// </summary>
        public void Rebuild()
        {
            
            _indexwriter = new IndexWriter(GetIndexStorePath, new PanGuAnalyzer(), true);
            _indexwriter.Optimize();
            //_indexwriter.Close();
        }
       
        
        public  void CloseWithoutOptimize()
        {
            _indexwriter.Close();
        }

        public int EndCreate()
        {
           int iCount =  _indexwriter.DocCount();
           _indexwriter.Optimize();//对索引进行优化，优化主要是将多个segment合并到一个，有利于提高索引速度。
            _indexwriter.Close();
            return iCount;
        }
            #endregion
        

        //private static object lockHelper = new object();
        //private IndexWriter _indexwriter;
        //public IndexWriter indexwriter
        //{
        //    get
        //    {
        //        if (_indexwriter == null)
        //        {
        //            lock (lockHelper)
        //            {
        //                if (_indexwriter == null)
        //                {
        //                    _indexwriter = new IndexWriter(GetIndexStorePath, new StandardAnalyzer(), true);

        //                }
        //            }
        //        }
        //        return _indexwriter;
        //    }

        //}

        #region IndexReader
        private static object lockHelper = new object();
        private IndexReader _indexreader;
        public IndexReader indexreader
        {
            get
            {
                if (_indexreader == null)
                {
                    lock (lockHelper)
                    {
                        if (_indexreader == null)
                        {
                            Directory dir = FSDirectory.GetDirectory(GetIndexStorePath, false);
                            _indexreader = IndexReader.Open(dir);

                        }
                    }
                }
                return _indexreader;
            }

        }
        #endregion



        private string GetIndexStorePath
        {
            get
            {
                if (!Equals(HttpContext.Current, null))
                {
                    return HttpContext.Current.Server.MapPath(string.Concat(Host.Instance.IISPath, "Datastore/Lucene/Site", SiteID, "/",IndexStoreFolder, "/"));
                }
                else
                {
                    return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, string.Concat("Datastore\\Lucene\\Site", SiteID, "\\", IndexStoreFolder, "\\"));
                }
               
            }
        }

        #endregion

       

        protected void LuceneAdd(string KeyValue, List<FieldEntity> OrtherFieldConfig)
        {
          
            Document doc = new Document();
            doc.Add(new Field(KeyFieldName, KeyValue, Field.Store.YES, Field.Index.NO));
            foreach (FieldEntity fieldEntity in OrtherFieldConfig)
            {
                doc.Add(new Field(fieldEntity.FieldName, fieldEntity.FieldValue, fieldEntity.FieldStore, fieldEntity.FieldIndex));
            }
            
            _indexwriter.AddDocument(doc);


        }

        protected bool LuceneDelete(string keyvalue)
        {
          
            Term term = new Term(KeyFieldName, keyvalue);
            int rowID = indexreader.DeleteDocuments(term);
            
            return rowID > 0;

        }

        protected void LuceneUpdate(string KeyValue, T model)
        {
           
            Term term = new Term(KeyFieldName,KeyValue);
            indexreader.DeleteDocuments(term);
            //indexreader.Close();
            Add(model);
            

        }
        public List<Document> LuceneSearch(List<KeyWordField> KeyWords , int PageSize, int PageIndex, out int recCount, string OrderBy,out long time)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
          
            IndexSearcher search = new IndexSearcher(GetIndexStorePath);
            BooleanQuery bq = new BooleanQuery();
            string sQ = string.Empty;
            foreach (KeyWordField keyWord in KeyWords)
            {
                sQ = IndexHelp.GetKeyWordsSplitBySpace(keyWord.WordValue, new PanGuTokenizer());
                QueryParser queryParser = new QueryParser(Lucene.Net.Util.Version.LUCENE_29,keyWord.FieldName, new PanGuAnalyzer(true));
                
                Query query = queryParser.Parse(sQ);
                bq.Add(query, BooleanClause.Occur.SHOULD);
            }

            Hits hits = search.Search(bq);

            List<Document> result = new List<Document>();
            recCount = hits.Length();
            int i = (PageIndex - 1) * PageSize;

            while (i < recCount && result.Count < PageSize)
            {
                result.Add(hits.Doc(i));
                i++;
            }

            search.Close();

            sw.Stop();
            time = sw.ElapsedMilliseconds;
            return result;
             

        }


         
    }
}
