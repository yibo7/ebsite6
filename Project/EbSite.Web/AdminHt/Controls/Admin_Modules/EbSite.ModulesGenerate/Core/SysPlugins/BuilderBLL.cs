using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EbSite.Core.DataBase.Entity;
using EbSite.Core.Strings;

using EbSite.ModulesGenerate.Core.IBuilder;

namespace EbSite.ModulesGenerate.Core.SysPlugins
{
    /// <summary>
    /// 业务层代码组件
    /// </summary>
    public class BuilderBLL : IBuilderBLL
    {
        #region 私有变量
        protected string _key = "ID";//默认第一个主键字段		
        protected string _keyType = "int";//默认第一个主键类型
       // NameRule namerule = new NameRule();
        #endregion

        #region 公有属性
        private List<ColumnInfo> _fieldlist;
        private List<ColumnInfo> _keys;
        private string _namespace; //顶级命名空间名
        private string _modelspace;
        private string _modelname;//model类名 
        private string _bllname;//bll类名    
        private string _dalname;//dal类名    
        private string _modelpath;
        private string _bllpath;
        private string _factorypath;
        private string _idalpath;
        private string _iclass;
        private string _dalpath;
        private string _dalspace;
        private bool isHasIdentity;
        private string dbType;

        /// <summary>
        /// 选择的字段集合
        /// </summary>
        public List<ColumnInfo> Fieldlist
        {
            set { _fieldlist = value; }
            get { return _fieldlist; }
        }
        /// <summary>
        /// 主键或条件字段列表 
        /// </summary>
        public List<ColumnInfo> Keys
        {
            set { _keys = value; }
            get { return _keys; }
        }
        /// <summary>
        /// 顶级命名空间名
        /// </summary>
        public string NameSpace
        {
            set { _namespace = value; }
            get { return _namespace; }
        }

        /*============================*/

        /// <summary>
        /// 实体类的命名空间
        /// </summary>
        public string Modelpath
        {
            set { _modelpath = value; }
            get { return _modelpath; }
        }
        /// <summary>
        /// Model类名
        /// </summary>
        public string ModelName
        {
            set { _modelname = value; }
            get { return _modelname; }
        }

        /// <summary>
        /// 实体类的整个命名空间 + 类名，即等于 Modelpath+ModelName
        /// </summary>
        public string ModelSpace
        {//Entity
            //get { return Modelpath + "." +ModelName; }
            get { return "Entity." + ModelName; }
        }

        /*============================*/

        /// <summary>
        /// 业务逻辑层的命名空间
        /// </summary>
        public string BLLpath
        {
            set { _bllpath = value; }
            get { return _bllpath; }
        }
        /// <summary>
        /// BLL类名
        /// </summary>
        public string BLLName
        {
            set { _bllname = value; }
            get { return _bllname; }
        }

        /*============================*/

        /// <summary>
        /// 数据层的命名空间
        /// </summary>
        public string DALpath
        {
            set { _dalpath = value; }
            get { return _dalpath; }
        }
        /// <summary>
        /// DAL类名
        /// </summary>
        public string DALName
        {
            set { _dalname = value; }
            get { return _dalname; }
        }

        /// <summary>
        /// 数据层的命名空间+ 类名，即等于 DALpath + DALName
        /// </summary>
        public string DALSpace
        {
            get { return DALpath + "." + DALName; }
        }

        /*============================*/
        /// <summary>
        /// 工厂类的命名空间
        /// </summary>
        public string Factorypath
        {
            set { _factorypath = value; }
            get { return _factorypath; }
        }
        /// <summary>
        /// 接口的命名空间
        /// </summary>
        public string IDALpath
        {
            set { _idalpath = value; }
            get { return _idalpath; }
        }
        /// <summary>
        /// 接口名
        /// </summary>
        public string IClass
        {
            set { _iclass = value; }
            get { return _iclass; }
        }

        /*============================*/

        /// <summary>
        /// 是否有自动增长标识列
        /// </summary>
        public bool IsHasIdentity
        {
            set { isHasIdentity = value; }
            get { return isHasIdentity; }
        }
        public string DbType
        {
            set { dbType = value; }
            get { return dbType; }
        }
        /// <summary>
        /// 主键标识字段
        /// </summary>
        public string Key
        {
            get
            {
                foreach (ColumnInfo key in _keys)
                {
                    _key = key.ColumnName;
                    _keyType = key.TypeName;
                    if (key.IsIdentity)
                    {
                        _key = key.ColumnName;
                        _keyType = CodeCommon.DbTypeToCS(key.TypeName);
                        break;
                    }
                }
                return _key;
            }
        }
        private string KeysNullTip
        {
            get
            {
                if (_keys.Count == 0)
                {
                    return "//该表无主键信息，请自定义主键/条件字段";
                }
                else
                {
                    return "";
                }
            }
        }
        #endregion

        #region  构造函数
        public BuilderBLL()
        {
        }
        public BuilderBLL(List<ColumnInfo> keys, string modelspace)
        {
            _modelspace = modelspace;
            Keys = keys;
            foreach (ColumnInfo key in _keys)
            {
                _key = key.ColumnName;
                _keyType = key.TypeName;
                if (key.IsIdentity)
                {
                    _key = key.ColumnName;
                    _keyType = CodeCommon.DbTypeToCS(key.TypeName);
                    break;
                }
            }
        }
        #endregion

        #region 业务层方法
        /// <summary>
        /// 得到整个类的代码
        /// </summary>      
        public string GetBLLCode(bool Maxid, bool Exists, bool Add, bool Update, bool Delete, bool GetModel, bool GetModelByCache, bool List)
        {
            StringPlus strclass = new StringPlus();
            strclass.AppendLine("using System;");
            strclass.AppendLine("using System.Data;");
            strclass.AppendLine("using System.Collections.Generic;");
            strclass.AppendLine("using System.Web.UI.WebControls;");
            //strclass.AppendLine("using " + _namespace + ".Core;");
           // strclass.AppendLine("using System.Web.UI.WebControls;");
            //strclass.AppendLine("using  EbSite.Base;");
           


            //if (GetModelByCache)
            //{
            //    strclass.AppendLine("using LTP.Common;");
            //}
            //strclass.AppendLine("using " + Modelpath + ";");
            //if ((Factorypath != "")&&(Factorypath !=null))
            //{
            //    strclass.AppendLine("using " + Factorypath + ";");
            //}
            //if ((IDALpath != "")&&(IDALpath !=null))
            //{
            //    strclass.AppendLine("using " + IDALpath + ";");
            //}
            strclass.AppendLine("namespace " + BLLpath);
            strclass.AppendLine("{");
            strclass.AppendSpaceLine(1, "/// <summary>");
            strclass.AppendSpaceLine(1, "/// 业务逻辑类" + BLLName + " 的摘要说明。");
            strclass.AppendSpaceLine(1, "/// </summary>");
            string sKeyTypeName = "int";
            if (Keys.Count > 0) sKeyTypeName = CodeCommon.DbTypeToCS(Keys[0].TypeName);
            strclass.AppendSpaceLine(1, "public class " + BLLName + ": Base.BLLBase<" + ModelSpace + ", " + sKeyTypeName + "> ");
            strclass.AppendSpaceLine(1, "{");
            strclass.AppendSpaceLine(2, "public static readonly " + BLLName + " Instance = new " + BLLName + "();");
            //strclass.AppendSpaceLine(2, "const double CacheDuration = 60.0;");
            //strclass.AppendSpaceLine(2, "private static readonly string[] MasterCacheKeyArray = { \""+BLLName+"\" };");
            //strclass.AppendSpaceLine(2, "private static CacheManager bllCache;");

            //strclass.AppendSpaceLine(2, "private static Data.Interface.IDataProviderOA dal = Data.Interface.DataProviderOA.GetInstance();");




            //if ((IClass != "") && (IClass != null))
            //{
            //    strclass.AppendSpaceLine(2, "private readonly " + IClass + " dal=" + "DataAccess.Create" + DALName + "();");
            //}
            //else
            //{
            //    strclass.AppendSpaceLine(2, "private readonly " + DALSpace + " dal=" + "new " + DALSpace + "();");
            //}
            strclass.AppendSpaceLine(2, "private  " + BLLName + "()");
            strclass.AppendSpaceLine(2, "{");
            //2010-11-22　杨欢乐
            // strclass.AppendSpaceLine(3, "base.MasterCacheKeyArray[0] = \"" + BLLName + "\";");
            strclass.AppendSpaceLine(2, "}");

            strclass.AppendSpaceLine(2, "#region  成员方法");

            #region  方法代码
            if (Maxid)
            {
                if (Keys.Count > 0)
                {
                    foreach (ColumnInfo obj in Keys)
                    {
                        if (CodeCommon.DbTypeToCS(obj.TypeName) == "int" || CodeCommon.DbTypeToCS(obj.TypeName) == "long")
                        {
                            if (obj.IsPK)
                            {
                                strclass.AppendLine(CreatBLLGetMaxID());
                                break;
                            }
                        }
                    }
                }
            }
            if (Exists)
            {
                strclass.AppendLine(CreatBLLExists());
            }
            if (Add)
            {
                strclass.AppendLine(CreatBLLADD());
            }
            if (Update)
            {
                strclass.AppendLine(CreatBLLUpdate());
            }
            if (Delete)
            {
                strclass.AppendLine(CreatBLLDelete());
            }
            if (GetModel)
            {
                strclass.AppendLine(CreatBLLGetModel());
            }
            if (GetModelByCache)
            {
                //strclass.AppendLine(CreatBLLGetModelByCache(ModelName) );
            }
            if (List)
            {
                strclass.AppendLine(CreatBLLGetList());
                //strclass.AppendLine(CreatBLLGetAllList() );
                //strclass.AppendLine(CreatBLLGetListByPage() );
            }

            #endregion
            strclass.AppendSpaceLine(2, "#endregion  成员方法");
            strclass.AppendSpaceLine(2, "");
            strclass.AppendSpaceLine(2, "#region  自定义方法");
            strclass.AppendSpaceLine(2, "");
            strclass.AppendSpaceLine(2, "#endregion  自定义方法");


            strclass.AppendSpaceLine(1, "}");
            strclass.AppendLine("}");
            strclass.AppendLine("");

            return strclass.ToString();
        }

        #endregion

        #region 具体方法代码

        public string CreatBLLGetMaxID()
        {
            StringPlus strclass = new StringPlus();
            if (_keys.Count > 0)
            {
                string keyname = "";
                foreach (ColumnInfo obj in _keys)
                {
                    if (CodeCommon.DbTypeToCS(obj.TypeName) == "int" || CodeCommon.DbTypeToCS(obj.TypeName) == "long")
                    {
                        keyname = obj.ColumnName;
                        if (obj.IsPK)
                        {
                            strclass.AppendLine("");
                            strclass.AppendSpaceLine(2, "/// <summary>");
                            strclass.AppendSpaceLine(2, "/// 得到最大ID");
                            strclass.AppendSpaceLine(2, "/// </summary>");
                            strclass.AppendSpaceLine(2, "public int GetMaxId()");
                            strclass.AppendSpaceLine(2, "{");
                            strclass.AppendSpaceLine(3, "return dalHelper." + ModelName + "_GetMaxId();");
                            strclass.AppendSpaceLine(2, "}");
                            break;
                        }
                    }
                }
            }


            return strclass.ToString();
        }
        public string CreatBLLExists()
        {
            StringPlus strclass = new StringPlus();
            if (_keys.Count > 0)
            {
                strclass.AppendSpaceLine(2, "/// <summary>");
                strclass.AppendSpaceLine(2, "/// 是否存在该记录");
                strclass.AppendSpaceLine(2, "/// </summary>");
                strclass.AppendSpaceLine(2, "public bool Exists(" + CodeCommon.GetInParameter(Keys) + ")");
                strclass.AppendSpaceLine(2, "{");
                strclass.AppendSpaceLine(3, "return dalHelper." + ModelName + "_Exists(" + CodeCommon.GetFieldstrlist(Keys) + ");");
                strclass.AppendSpaceLine(2, "}");
            }
            return strclass.ToString();
        }
        public string CreatBLLADD()
        {
            StringPlus strclass = new StringPlus();
            strclass.AppendSpaceLine(2, "/// <summary>");
            strclass.AppendSpaceLine(2, "/// 增加一条数据");
            strclass.AppendSpaceLine(2, "/// </summary>");
            string strretu = "void";
            if ((DbType == "SQL2000" || DbType == "SQL2005") && (IsHasIdentity))
            {
                //strretu = "int ";
                //2010-11-22 
                string sKeyTypeName = "int";
                if (Keys.Count > 0) sKeyTypeName = CodeCommon.DbTypeToCS(Keys[0].TypeName);
                strretu = sKeyTypeName;
            }
            strclass.AppendSpaceLine(2, "override public " + strretu + " Add(" + ModelSpace + " model)");
            strclass.AppendSpaceLine(2, "{");
            strclass.AppendSpaceLine(3, "base.InvalidateCache();");
            if (strretu == "void")
            {
                strclass.AppendSpaceLine(3, "dalHelper." + DALName + "_Add(model);");
            }
            else
            {
                strclass.AppendSpaceLine(3, "return dalHelper." + ModelName + "_Add(model);");
            }

            strclass.AppendSpaceLine(2, "}");
            return strclass.ToString();
        }
        public string CreatBLLUpdate()
        {
            StringPlus strclass = new StringPlus();
            strclass.AppendSpaceLine(2, "/// <summary>");
            strclass.AppendSpaceLine(2, "/// 更新一条数据");
            strclass.AppendSpaceLine(2, "/// </summary>");
            strclass.AppendSpaceLine(2, "override public void Update(" + ModelSpace + " model)");
            strclass.AppendSpaceLine(2, "{");
            strclass.AppendSpaceLine(3, "base.InvalidateCache();");
            strclass.AppendSpaceLine(3, "dalHelper." + ModelName + "_Update(model);");
            strclass.AppendSpaceLine(2, "}");
            return strclass.ToString();
        }
        public string CreatBLLDelete()
        {
            StringPlus strclass = new StringPlus();
            strclass.AppendSpaceLine(2, "/// <summary>");
            strclass.AppendSpaceLine(2, "/// 删除一条数据");
            strclass.AppendSpaceLine(2, "/// </summary>");
            strclass.AppendSpaceLine(2, "override public void Delete(" + CodeCommon.GetInParameter(Keys) + ")");
            strclass.AppendSpaceLine(2, "{");
            strclass.AppendSpaceLine(3, "base.InvalidateCache();");
            strclass.AppendSpaceLine(3, KeysNullTip);
            strclass.AppendSpaceLine(3, "dalHelper." + ModelName + "_Delete(" + CodeCommon.GetFieldstrlist(Keys) + ");");
            strclass.AppendSpaceLine(2, "}");
            return strclass.ToString();
        }
        public string CreatBLLGetModel()
        {
            StringPlus strclass = new StringPlus();
            strclass.AppendSpaceLine(2, "/// <summary>");
            strclass.AppendSpaceLine(2, "/// 得到一个对象实体");
            strclass.AppendSpaceLine(2, "/// </summary>");
            strclass.AppendSpaceLine(2, "override public " + ModelSpace + " GetEntity(" + CodeCommon.GetInParameter(Keys) + ")");
            strclass.AppendSpaceLine(2, "{");
            strclass.AppendSpaceLine(3, KeysNullTip);
            if (Keys.Count > 0)
            {
                strclass.AppendSpaceLine(3, "string rawKey = string.Concat(\"GetEntity-\", " + Keys[0].ColumnName + ");");

                strclass.AppendSpaceLine(3, ModelSpace + " etEntity = base.GetCacheItem(rawKey) as " + ModelSpace + ";");
                strclass.AppendSpaceLine(3, "if (Equals(etEntity,null))");
                strclass.AppendSpaceLine(3, "{");
                strclass.AppendSpaceLine(4, "etEntity = dalHelper." + ModelName + "_GetEntity(" + CodeCommon.GetFieldstrlist(Keys) + ");");
                strclass.AppendSpaceLine(4, "if (!Equals(etEntity,null))");
                strclass.AppendSpaceLine(5, "base.AddCacheItem(rawKey, etEntity);");
                strclass.AppendSpaceLine(3, "}");
            }
            if (!string.IsNullOrEmpty(CodeCommon.GetInParameter(Keys).Trim()))
            {
                strclass.AppendSpaceLine(3, "return etEntity;");
            }
            else
            {
                strclass.AppendSpaceLine(3, "return null;");
            }



            //strclass.AppendSpaceLine(3, "return dal." + DALName + "_GetEntity(" + CodeCommon.GetFieldstrlist(Keys) + ");");
            strclass.AppendSpaceLine(2, "}");
            return strclass.ToString();

        }

        public string CreatBLLGetList()
        {
            StringPlus strclass = new StringPlus();

            strclass.AppendSpaceLine(2, "/// <summary>");
            strclass.AppendSpaceLine(2, "/// 获得数据列表");
            strclass.AppendSpaceLine(2, "/// </summary>");
            strclass.AppendSpaceLine(2, "public int GetCount(string strWhere)");
            strclass.AppendSpaceLine(2, "{");
            strclass.AppendSpaceLine(3, "return dalHelper." + ModelName + "_GetCount(strWhere);");
            strclass.AppendSpaceLine(2, "}");

            strclass.AppendSpaceLine(2, "/// <summary>");
            strclass.AppendSpaceLine(2, "/// 获得数据列表");
            strclass.AppendSpaceLine(2, "/// </summary>");
            strclass.AppendSpaceLine(2, "public int GetCountCache(string strWhere)");
            strclass.AppendSpaceLine(2, "{");

            strclass.AppendSpaceLine(3, "string rawKey = string.Concat(\"GetCount-\", strWhere);");

            strclass.AppendSpaceLine(3, " string sCount = base.GetCacheItem(rawKey) as string;");
            strclass.AppendSpaceLine(3, "if (string.IsNullOrEmpty(sCount))");
            strclass.AppendSpaceLine(3, "{");
            strclass.AppendSpaceLine(4, "sCount = GetCountCache(strWhere).ToString();");
            strclass.AppendSpaceLine(4, "if (!string.IsNullOrEmpty(sCount))");
            strclass.AppendSpaceLine(5, "base.AddCacheItem(rawKey, sCount);");
            strclass.AppendSpaceLine(3, "}");

            strclass.AppendSpaceLine(3, "if (!string.IsNullOrEmpty(sCount))");
            strclass.AppendSpaceLine(3, "{");
            strclass.AppendSpaceLine(4, "return int.Parse(sCount);");
            strclass.AppendSpaceLine(3, "}");
            strclass.AppendSpaceLine(3, "return 0;");



            strclass.AppendSpaceLine(2, "}");

            strclass.AppendSpaceLine(2, "/// <summary>");
            strclass.AppendSpaceLine(2, "/// 获得数据列表");
            strclass.AppendSpaceLine(2, "/// </summary>");
            strclass.AppendSpaceLine(2, "public int GetCount()");
            strclass.AppendSpaceLine(2, "{");
            strclass.AppendSpaceLine(3, "return GetCountCache(\"\");");
            strclass.AppendSpaceLine(2, "}");


            strclass.AppendSpaceLine(2, "/// <summary>");
            strclass.AppendSpaceLine(2, "/// 获得数据列表");
            strclass.AppendSpaceLine(2, "/// </summary>");
            strclass.AppendSpaceLine(2, "public DataSet GetList(string strWhere)");
            strclass.AppendSpaceLine(2, "{");
            strclass.AppendSpaceLine(3, "return GetListCache(0,strWhere,\"\");");
            strclass.AppendSpaceLine(2, "}");



            strclass.AppendSpaceLine(2, "/// <summary>");
            strclass.AppendSpaceLine(2, "/// 获得数据列表");
            strclass.AppendSpaceLine(2, "/// </summary>");
            strclass.AppendSpaceLine(2, "public DataSet GetList()");
            strclass.AppendSpaceLine(2, "{");
            strclass.AppendSpaceLine(3, "return GetList(\"\");");
            strclass.AppendSpaceLine(2, "}");


            strclass.AppendSpaceLine(2, "/// <summary>");
            strclass.AppendSpaceLine(2, "/// 获得数据列表");
            strclass.AppendSpaceLine(2, "/// </summary>");
            strclass.AppendSpaceLine(2, "public DataSet GetList(int Top, string strWhere, string filedOrder)");
            strclass.AppendSpaceLine(2, "{");
            strclass.AppendSpaceLine(3, "return dalHelper." + ModelName + "_GetList( Top,  strWhere,  filedOrder);");
            strclass.AppendSpaceLine(2, "}");

            strclass.AppendSpaceLine(2, "/// <summary>");
            strclass.AppendSpaceLine(2, "/// 获得数据列表");
            strclass.AppendSpaceLine(2, "/// </summary>");
            strclass.AppendSpaceLine(2, "public DataSet GetListCache(int Top, string strWhere, string filedOrder)");
            strclass.AppendSpaceLine(2, "{");

            strclass.AppendSpaceLine(3, "string rawKey = string.Concat(\"GetList-\", strWhere,Top,filedOrder);");
            strclass.AppendSpaceLine(3, " DataSet lstData = base.GetCacheItem(rawKey) as DataSet;");
            strclass.AppendSpaceLine(3, "if (Equals(lstData,null))");
            strclass.AppendSpaceLine(3, "{");
            strclass.AppendSpaceLine(4, "lstData = GetList( Top,  strWhere,  filedOrder);");
            strclass.AppendSpaceLine(4, "if (!Equals(lstData,null))");
            strclass.AppendSpaceLine(5, "base.AddCacheItem(rawKey, lstData);");
            strclass.AppendSpaceLine(3, "}");
            strclass.AppendSpaceLine(3, "return lstData;");


            strclass.AppendSpaceLine(2, "}");



            strclass.AppendSpaceLine(2, "/// <summary>");
            strclass.AppendSpaceLine(2, "/// 获得数据列表");
            strclass.AppendSpaceLine(2, "/// </summary>");
            strclass.AppendSpaceLine(2, "override public List<" + ModelSpace + "> GetListArray(int Top, string strWhere, string filedOrder)");
            strclass.AppendSpaceLine(2, "{");
            strclass.AppendSpaceLine(3, "return dalHelper." + ModelName + "_GetListArray( Top,  strWhere,  filedOrder);");
            strclass.AppendSpaceLine(2, "}");

            strclass.AppendSpaceLine(2, "/// <summary>");
            strclass.AppendSpaceLine(2, "/// 获得数据列表");
            strclass.AppendSpaceLine(2, "/// </summary>");
            strclass.AppendSpaceLine(2, "public List<" + ModelSpace + "> GetListArrayCache(int Top, string strWhere, string filedOrder)");
            strclass.AppendSpaceLine(2, "{");

            strclass.AppendSpaceLine(3, "string rawKey = string.Concat(\"GetListArray-\", strWhere,Top,filedOrder);");
            strclass.AppendSpaceLine(3, " List<" + ModelSpace + "> lstData = base.GetCacheItem(rawKey) as List<" + ModelSpace + ">;");
            strclass.AppendSpaceLine(3, "if (Equals(lstData,null))");
            strclass.AppendSpaceLine(3, "{");
            strclass.AppendSpaceLine(4, "//从基类调用，激活事件");
            strclass.AppendSpaceLine(4, "lstData = base.GetListArrayEv( Top,  strWhere,  filedOrder);");
            strclass.AppendSpaceLine(4, "if (!Equals(lstData,null))");
            strclass.AppendSpaceLine(5, "base.AddCacheItem(rawKey, lstData);");
            strclass.AppendSpaceLine(3, "}");
            strclass.AppendSpaceLine(3, "return lstData;");

            strclass.AppendSpaceLine(2, "}");

            strclass.AppendSpaceLine(2, "/// <summary>");
            strclass.AppendSpaceLine(2, "/// 获得数据列表");
            strclass.AppendSpaceLine(2, "/// </summary>");
            strclass.AppendSpaceLine(2, "public List<" + ModelSpace + "> GetListArray(int Top,  string filedOrder)");
            strclass.AppendSpaceLine(2, "{");
            strclass.AppendSpaceLine(3, "return GetListArrayCache( Top,  \"\",  filedOrder);");
            strclass.AppendSpaceLine(2, "}");

            strclass.AppendSpaceLine(2, "/// <summary>");
            strclass.AppendSpaceLine(2, "/// 获得数据列表");
            strclass.AppendSpaceLine(2, "/// </summary>");
            strclass.AppendSpaceLine(2, "public List<" + ModelSpace + "> GetListArray(string strWhere)");
            strclass.AppendSpaceLine(2, "{");
            strclass.AppendSpaceLine(3, "return GetListArrayCache( 0,  strWhere,  \"\");");
            strclass.AppendSpaceLine(2, "}");


            strclass.AppendSpaceLine(2, "/// <summary>");
            strclass.AppendSpaceLine(2, "/// 获得数据列表");
            strclass.AppendSpaceLine(2, "/// </summary>");
            strclass.AppendSpaceLine(2, "override public List<" + ModelSpace + "> GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds,string oderby, out int RecordCount)");
            strclass.AppendSpaceLine(2, "{");
            strclass.AppendSpaceLine(3, "return dalHelper." + ModelName + "_GetListPages( PageIndex,  PageSize,  strWhere,  Fileds, oderby, out  RecordCount);");
            strclass.AppendSpaceLine(2, "}");

            strclass.AppendSpaceLine(2, "/// <summary>");
            strclass.AppendSpaceLine(2, "/// 获得数据列表");
            strclass.AppendSpaceLine(2, "/// </summary>");
            strclass.AppendSpaceLine(2, "public List<" + ModelSpace + "> GetListPagesCache(int PageIndex, int PageSize, string strWhere, string Fileds,string oderby, out int RecordCount)");
            strclass.AppendSpaceLine(2, "{");


            strclass.AppendSpaceLine(3, "string rawKey = string.Concat(\"GlPages-\", PageIndex,PageSize,strWhere,Fileds,oderby);");
            strclass.AppendSpaceLine(3, "string rawKeyCount = string.Concat(\"C-\", rawKey);");
            strclass.AppendSpaceLine(3, " List<" + ModelSpace + "> lstData = base.GetCacheItem(rawKey) as List<" + ModelSpace + ">;");
            strclass.AppendSpaceLine(3, "int iRecordCount = -1;");
            strclass.AppendSpaceLine(3, "if (Equals(lstData,null))");
            strclass.AppendSpaceLine(3, "{");
            strclass.AppendSpaceLine(4, "//从基类调用，激活事件");
            strclass.AppendSpaceLine(4, "lstData = base.GetListPagesEv(  PageIndex,  PageSize,  strWhere,  Fileds, oderby, out  RecordCount);");
            strclass.AppendSpaceLine(4, "if (!Equals(lstData,null))");
            strclass.AppendSpaceLine(4, "{");
            strclass.AppendSpaceLine(5, "base.AddCacheItem(rawKey, lstData);");
            strclass.AppendSpaceLine(5, "base.AddCacheItem(rawKeyCount, RecordCount.ToString());");
            strclass.AppendSpaceLine(4, "}");
            strclass.AppendSpaceLine(3, "}");


            strclass.AppendSpaceLine(3, "if(iRecordCount==-1)");
            strclass.AppendSpaceLine(3, "{");
            strclass.AppendSpaceLine(4, "string sCount = base.GetCacheItem(rawKeyCount) as string;");
            strclass.AppendSpaceLine(4, "if (!string.IsNullOrEmpty(sCount))");
            strclass.AppendSpaceLine(4, "{");
            strclass.AppendSpaceLine(5, "RecordCount = int.Parse(sCount);");
            strclass.AppendSpaceLine(4, "}");
            strclass.AppendSpaceLine(4, "else");
            strclass.AppendSpaceLine(4, "{");
            strclass.AppendSpaceLine(5, "RecordCount = GetCountCache(strWhere);");
            strclass.AppendSpaceLine(4, "}");
            strclass.AppendSpaceLine(3, "}");
            strclass.AppendSpaceLine(3, "else");
            strclass.AppendSpaceLine(3, "{");
            strclass.AppendSpaceLine(4, "RecordCount = iRecordCount;");
            strclass.AppendSpaceLine(3, "}");


            strclass.AppendSpaceLine(3, "return lstData;");


            strclass.AppendSpaceLine(2, "}");

            strclass.AppendSpaceLine(2, "/// <summary>");
            strclass.AppendSpaceLine(2, "/// 获得数据列表-分页");
            strclass.AppendSpaceLine(2, "/// </summary>");
            strclass.AppendSpaceLine(2, "public List<" + ModelSpace + "> GetListPages(int PageIndex, int PageSize, out int RecordCount)");
            strclass.AppendSpaceLine(2, "{");
            strclass.AppendSpaceLine(3, "return GetListPagesCache( PageIndex,  PageSize,  \"\",  \"\", \"\", out  RecordCount);");
            strclass.AppendSpaceLine(2, "}");

            strclass.AppendSpaceLine(2, "/// <summary>");
            strclass.AppendSpaceLine(2, "/// 获得数据列表-分页");
            strclass.AppendSpaceLine(2, "/// </summary>");
            strclass.AppendSpaceLine(2, "public List<" + ModelSpace + "> GetListPages(int PageIndex, int PageSize, string strWhere, string oderby, out int RecordCount)");
            strclass.AppendSpaceLine(2, "{");
            strclass.AppendSpaceLine(3, "return GetListPagesCache( PageIndex,  PageSize,  strWhere,  \"\", oderby, out  RecordCount);");
            strclass.AppendSpaceLine(2, "}");

            strclass.AppendSpaceLine(2, "/// <summary>");
            strclass.AppendSpaceLine(2, "/// 获得数据列表-分页");
            strclass.AppendSpaceLine(2, "/// </summary>");
            strclass.AppendSpaceLine(2, "public List<" + ModelSpace + "> GetListPages(int PageIndex, int PageSize, string strWhere, string oderby)");
            strclass.AppendSpaceLine(2, "{");
            strclass.AppendSpaceLine(3, "int iCount = 0;");
            strclass.AppendSpaceLine(3, "return GetListPagesCache(PageIndex, PageSize, strWhere, \"\", oderby, out iCount);");
            strclass.AppendSpaceLine(2, "}");

            strclass.AppendSpaceLine(2, "/// <summary>");
            strclass.AppendSpaceLine(2, "/// 搜索-分页");
            strclass.AppendSpaceLine(2, "/// </summary>");
            strclass.AppendSpaceLine(2, "public List<" + ModelSpace + "> SearchLike(int PageIndex, int PageSize, string oderby, out int RecordCount, string sKeyWord, string ColumnName)");
            strclass.AppendSpaceLine(2, "{");
            strclass.AppendSpaceLine(3, "string strWhere = \"\";");
            strclass.AppendSpaceLine(3, "if (!string.IsNullOrEmpty(sKeyWord)) strWhere = string.Format(\"{0} like '%{1}%'\", ColumnName, sKeyWord);");
            strclass.AppendSpaceLine(3, "if (string.IsNullOrEmpty(strWhere))");
            strclass.AppendSpaceLine(3, "{");
            strclass.AppendSpaceLine(3, "RecordCount = 0;");
            strclass.AppendSpaceLine(3, "return null;");
            strclass.AppendSpaceLine(3, "}");
            strclass.AppendSpaceLine(3, "return GetListPagesCache(PageIndex, PageSize, strWhere, \"\", oderby, out  RecordCount);");

            strclass.AppendSpaceLine(2, "}");

            /////////////////////////////////////
            strclass.AppendSpaceLine(2, "/// <summary>");
            strclass.AppendSpaceLine(2, "/// 修改时获取当前实例，并载入控件到PlaceHolder");
            strclass.AppendSpaceLine(2, "/// </summary>");
            strclass.AppendSpaceLine(2, "public void InitModifyCtr(string id, PlaceHolder ph)");
            strclass.AppendSpaceLine(2, "{");
            strclass.AppendSpaceLine(3, "if (!string.IsNullOrEmpty(id))");
            strclass.AppendSpaceLine(3, "{");
            strclass.AppendSpaceLine(4, GetKeyType + " ThisId = " + GetKeyType + ".Parse(id);");
            strclass.AppendSpaceLine(4, ModelSpace + " mdEt = GetEntity(ThisId);");
            strclass.AppendSpaceLine(4, "foreach (System.Web.UI.Control uc in ph.Controls)");
            //strclass.AppendSpaceLine(4, "if (Equals(uc.ID, null)) ");
            strclass.AppendSpaceLine(4, "{");

            strclass.AppendSpaceLine(5, "if (Equals(uc.ID, null)) continue;");
            strclass.AppendSpaceLine(5, "string sValue = \"\";");

            int iforcount = 0;
            #region 字段赋值
            foreach (ColumnInfo field in Fieldlist)
            {
                string columnName = field.ColumnName;
                string columnType = field.TypeName;
                string sIf = (iforcount > 0) ? "else if" : "if";
                strclass.AppendSpaceLine(5, sIf + " (Equals(uc.ID.ToLower(), \"" + columnName + "\".ToLower()))");
                strclass.AppendSpaceLine(5, "{");
                if(columnName=="ID")
                {
                    columnName = columnName.ToLower();
                }
                strclass.AppendSpaceLine(6, "sValue = mdEt." + columnName + ".ToString();");
                //strclass.AppendSpaceLine(6, "continue;");
                strclass.AppendSpaceLine(5, "}");

                iforcount++;
            }
            #endregion
            strclass.AppendSpaceLine(4, "SetValueFromControl(uc, sValue);");
            strclass.AppendSpaceLine(4, "}");
            strclass.AppendSpaceLine(3, "}");
            strclass.AppendSpaceLine(2, "}");
            //////////////////////
            strclass.AppendSpaceLine(2, "/// <summary>");
            strclass.AppendSpaceLine(2, "/// 获取控件里的数据映射到一个实体，接着保存这个实例到数据");
            strclass.AppendSpaceLine(2, "/// </summary>");
            strclass.AppendSpaceLine(2, "public void SaveEntityFromCtr(PlaceHolder ph)");
            strclass.AppendSpaceLine(2, "{");
            strclass.AppendSpaceLine(4, "SaveEntityFromCtr(ph,null);");
            strclass.AppendSpaceLine(2, "}");


            ////////////////////////////////////////
            strclass.AppendSpaceLine(2, "/// <summary>");
            strclass.AppendSpaceLine(2, "/// 获取控件里的数据映射到一个实体，接着保存这个实例到数据");
            strclass.AppendSpaceLine(2, "/// </summary>");
            strclass.AppendSpaceLine(2, "public void SaveEntityFromCtr(PlaceHolder ph, List<EbSite.Base.BLL.OtherColumn> lstOtherColumn)");
            strclass.AppendSpaceLine(2, "{");
            strclass.AppendSpaceLine(3, ModelSpace + " mdEntity = GetEntityFromCtr(ph);");
            strclass.AppendSpaceLine(3, "if(!Equals(lstOtherColumn,null) && lstOtherColumn.Count>0)");
            strclass.AppendSpaceLine(3, "{");
            strclass.AppendSpaceLine(4, "foreach (EbSite.Base.BLL.OtherColumn column in lstOtherColumn)");
            strclass.AppendSpaceLine(4, "{");

            #region 字段赋值
            iforcount = 0;
            foreach (ColumnInfo field in Fieldlist)
            {
                string columnName = field.ColumnName;
                string columnType = field.TypeName;
                string sIf = (iforcount > 0) ? "else if" : "if";
                strclass.AppendSpaceLine(5, sIf + "(Equals(column.ColumnName.ToLower(), \"" + columnName + "\".ToLower()))");
                strclass.AppendSpaceLine(5, "{");
                iforcount++;
                switch (CodeCommon.DbTypeToCS(columnType))
                {
                    case "int":
                        {
                            if (columnName == "ID")
                            {
                                columnName = columnName.ToLower();
                            }
                            strclass.AppendSpaceLine(6, "mdEntity." + columnName + " = int.Parse(column.ColumnValue);");
                        }
                        break;
                    case "long":
                        {
                            if (columnName == "ID")
                            {
                                columnName = columnName.ToLower();
                            }
                            strclass.AppendSpaceLine(6, "mdEntity." + columnName + " = long.Parse(column.ColumnValue);");
                        }
                        break;
                    case "decimal":
                        {
                            strclass.AppendSpaceLine(6, "mdEntity." + columnName + " = decimal.Parse(column.ColumnValue);");
                        }
                        break;
                    case "float":
                        {
                            strclass.AppendSpaceLine(6, "mdEntity." + columnName + " = float.Parse(column.ColumnValue);");
                        }
                        break;
                    case "DateTime":
                        {
                            strclass.AppendSpaceLine(6, "mdEntity." + columnName + " = DateTime.Parse(column.ColumnValue);");
                        }
                        break;
                    case "string":
                        {
                            strclass.AppendSpaceLine(6, "mdEntity." + columnName + " = column.ColumnValue;");
                        }
                        break;
                    case "bool":
                        {
                            strclass.AppendSpaceLine(6, "mdEntity." + columnName + " = bool.Parse(column.ColumnValue);");
                        }
                        break;
                    case "byte[]":
                        {
                            strclass.AppendSpaceLine(6, "mdEntity." + columnName + " = (byte[])column.ColumnValue;");
                        }
                        break;
                    case "Guid":
                        {

                            strclass.AppendSpaceLine(6, "mdEntity." + columnName + " = new Guid(column.ColumnValue);");
                        }
                        break;
                    default:
                        strclass.AppendSpaceLine(6, "mdEntity." + columnName + " = column.ColumnValue;");
                        break;
                }

                //strclass.AppendSpaceLine(6, "continue;");
                strclass.AppendSpaceLine(5, "}");
            }
            #endregion

            strclass.AppendSpaceLine(4, "}");

            strclass.AppendSpaceLine(3, "}");

            switch (GetKeyType)
            {
                case "int":
                    {
                        strclass.AppendSpaceLine(3, "if (mdEntity.id>0)");
                    }
                    break;
                case "long":
                    {
                        strclass.AppendSpaceLine(3, "if (mdEntity.id>0)");
                    }
                    break;
                case "string":
                    {
                        strclass.AppendSpaceLine(3, "if (!string.IsNullOrEmpty(mdEntity.id))");
                    }
                    break;
                case "Guid":
                    {

                        strclass.AppendSpaceLine(6, "f (!Equals(mdEntity.id,Guid.Empty))");
                    }
                    break;
                default:
                    strclass.AppendSpaceLine(3, "if (mdEntity." + GetKeyName + ">0)");
                    break;
            }



            strclass.AppendSpaceLine(3, "{");
            strclass.AppendSpaceLine(4, "Update(mdEntity);");
            strclass.AppendSpaceLine(3, "}else{");

            strclass.AppendSpaceLine(4, " Add(mdEntity);");
            strclass.AppendSpaceLine(3, "}");
            strclass.AppendSpaceLine(2, "}");

            ////////////////////////////////////////////////

            strclass.AppendSpaceLine(2, "/// <summary>");
            strclass.AppendSpaceLine(2, "/// 从PlaceHolder中获取一个实例");
            strclass.AppendSpaceLine(2, "/// </summary>");
            strclass.AppendSpaceLine(2, "public " + ModelSpace + " GetEntityFromCtr(PlaceHolder ph)");
            strclass.AppendSpaceLine(2, "{");
            strclass.AppendSpaceLine(3, ModelSpace + " mdEt = new " + ModelSpace + "();");
            //2010-08-31

            //2010-11-29 long int 取到主健的数据类型
            string sKeyTypeName = "int";
            if (Keys.Count > 0) sKeyTypeName = CodeCommon.DbTypeToCS(Keys[0].TypeName);
            string strretu = sKeyTypeName;

            strclass.AppendSpaceLine(3, "string sKeyID;");
            strclass.AppendSpaceLine(3, "if (GetIDFromCtr(ph, out sKeyID))");
            strclass.AppendSpaceLine(3, "{");
            strclass.AppendSpaceLine(4, "mdEt = GetEntity(" + strretu + ".Parse(sKeyID));");
            strclass.AppendSpaceLine(3, "}");
            ////
            strclass.AppendSpaceLine(3, "foreach (System.Web.UI.Control uc in ph.Controls)");
            strclass.AppendSpaceLine(3, "{");
            strclass.AppendSpaceLine(4, "if (Equals(uc.ID, null)) continue;");
            strclass.AppendSpaceLine(4, "string sValue = GetValueFromControl(uc);");

            #region 字段赋值
            iforcount = 0;
            foreach (ColumnInfo field in Fieldlist)
            {
                string columnName = field.ColumnName;
                string columnType = field.TypeName;
                string sIf = (iforcount > 0) ? "else if" : "if";
                strclass.AppendSpaceLine(5, sIf + "(Equals(uc.ID.ToLower(),\"" + columnName + "\".ToLower()))");
                strclass.AppendSpaceLine(5, "{");
                iforcount++;
                switch (CodeCommon.DbTypeToCS(columnType))
                {
                    case "int":
                        {
                            if (columnName == "ID")
                            {
                                columnName = columnName.ToLower();
                            }
                            strclass.AppendSpaceLine(6, "mdEt." + columnName + " = int.Parse(sValue);");
                        }
                        break;
                    case "long":
                        {
                            if (columnName == "ID")
                            {
                                columnName = columnName.ToLower();
                            }
                            strclass.AppendSpaceLine(6, "mdEt." + columnName + " = long.Parse(sValue);");
                        }
                        break;
                    case "decimal":
                        {
                            strclass.AppendSpaceLine(6, "mdEt." + columnName + " = decimal.Parse(sValue);");
                        }
                        break;
                    case "float":
                        {
                            strclass.AppendSpaceLine(6, "mdEt." + columnName + " = float.Parse(sValue);");
                        }
                        break;
                    case "DateTime":
                        {
                            strclass.AppendSpaceLine(6, "mdEt." + columnName + " = DateTime.Parse(sValue);");
                        }
                        break;
                    case "string":
                        {
                            strclass.AppendSpaceLine(6, "mdEt." + columnName + " = sValue;");
                        }
                        break;
                    case "bool":
                        {
                            strclass.AppendSpaceLine(6, "mdEt." + columnName + " = bool.Parse(sValue);");
                        }
                        break;
                    case "byte[]":
                        {
                            strclass.AppendSpaceLine(6, "mdEt." + columnName + " = (byte[])sValue;");
                        }
                        break;
                    case "Guid":
                        {
                            strclass.AppendSpaceLine(6, "mdEt." + columnName + " = new Guid(sValue);");
                        }
                        break;
                    default:
                        strclass.AppendSpaceLine(6, "mdEt." + columnName + " = sValue;");
                        break;
                }

                //strclass.AppendSpaceLine(6, "continue;");
                strclass.AppendSpaceLine(5, "}");
            }
            #endregion


            strclass.AppendSpaceLine(3, "}");
            strclass.AppendSpaceLine(2, "return mdEt;");
            strclass.AppendSpaceLine(2, "}");






            return strclass.ToString();
        }
        /// <summary>
        /// 多键只取第一个
        /// </summary>
        public string GetKeyName
        {
            get
            {
                string str = "ID";
                if (_keys.Count > 0)
                    str = _keys[0].ColumnName;

                return str;
            }
        }
        /// <summary>
        /// 多键只取第一个
        /// </summary>
        public string GetKeyType
        {
            get
            {
                string str = "int";
                if (_keys.Count > 0)
                    str = CodeCommon.DbTypeToCS(_keys[0].TypeName);


                //if (_keys.Count > 0)
                //{
                //    ColumnInfo objKey = _keys[0];
                //    if (CodeCommon.DbTypeToCS(objKey.TypeName) == "int")
                //    {
                //        str = "int.Parse";
                //    }
                //    else if (CodeCommon.DbTypeToCS(objKey.TypeName) == "long")
                //    {
                //        str = "long.Parse";
                //    }
                //}
                return str;
            }

        }


        #endregion


    }
}
