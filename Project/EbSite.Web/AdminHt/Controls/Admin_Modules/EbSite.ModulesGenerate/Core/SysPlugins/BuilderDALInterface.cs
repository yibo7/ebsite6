using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EbSite.Core.DataBase.Entity;
using EbSite.Core.DataBase.Interface;
using EbSite.Core.Strings;
using EbSite.ModulesGenerate.Core.IBuilder;

namespace EbSite.ModulesGenerate.Core.SysPlugins
{
    public class BuilderDALInterface : IBuilderDALInterface
    {
        #region 公有属性
        IDbObject dbobj;
        public IDbObject DbObject
        {
            set { dbobj = value; }
            get { return dbobj; }
        }
        /// <summary>
        /// 库名
        /// </summary>
        private string _dbname;
        public string DbName
        {
            set { _dbname = value; }
            get { return _dbname; }
        }
        /// <summary>
        /// 表名
        /// </summary>
        private string _tablename;
        public string TableName
        {
            set { _tablename = value; }
            get { return _tablename; }
        }


        /// <summary>
        /// 选择的字段集合
        /// </summary>
        private List<ColumnInfo> _fieldlist;
        public List<ColumnInfo> Fieldlist
        {
            set { _fieldlist = value; }
            get { return _fieldlist; }
        }
        /// <summary>
        /// 主键或条件字段列表
        /// </summary>
        private List<ColumnInfo> _keys;
        public List<ColumnInfo> Keys
        {
            set { _keys = value; }
            get { return _keys; }
        }
        /// <summary>
        /// 顶级命名空间名
        /// </summary>
        private string _namespace;
        public string NameSpace
        {
            set { _namespace = value; }
            get { return _namespace; }
        }

        /// <summary>
        /// 所在文件夹
        /// </summary>
        private string _folder;
        public string Folder
        {
            set { _folder = value; }
            get { return _folder; }
        }

        /// <summary>
        /// 实体类的命名空间
        /// </summary>
        private string _modelpath;
        public string Modelpath
        {
            set { _modelpath = value; }
            get { return _modelpath; }
        }

        /// <summary>
        /// model类名
        /// </summary>
        private string _modelname;
        public string ModelName
        {
            set { _modelname = value; }
            get { return _modelname; }
        }

        /// <summary>
        /// 数据层的命名空间
        /// </summary>
        private string _dalpath;
        public string DALpath
        {
            set { _dalpath = value; }
            get { return _dalpath; }
        }
        /// <summary>
        /// 数据层的类名
        /// </summary>
        private string _dalname;
        public string DALName
        {
            set { _dalname = value; }
            get { return _dalname; }
        }
        /// <summary>
        /// 接口的命名空间
        /// </summary>
        private string _idalpath;
        public string IDALpath
        {
            set { _idalpath = value; }
            get { return _idalpath; }
        }
        /// <summary>
        /// 接口类名
        /// </summary>
        private string _iclass;
        public string IClass
        {
            set { _iclass = value; }
            get { return _iclass; }
        }

        /// <summary>
        /// 数据库访问类名
        /// </summary>
        private string _dbhelpername;
        public string DbHelperName
        {
            set { _dbhelpername = value; }
            get { return _dbhelpername; }
        }
        /// <summary>
        /// 存储过程前缀 
        /// </summary>    
        private string _procperfix;
        public string ProcPrefix
        {
            set { _procperfix = value; }
            get { return _procperfix; }
        }

        /// <summary>
        /// 主键或条件字段中是否有标识列
        /// </summary>
        public bool IsHasIdentity
        {
            get
            {
                bool isid = false;
                if (_keys.Count > 0)
                {
                    foreach (ColumnInfo key in _keys)
                    {
                        if (key.IsIdentity)
                        {
                            isid = true;
                        }
                    }
                }
                return isid;
            }
        }
        /// <summary>
        /// 实体类的整个命名空间 + 类名，即等于 Modelpath+ModelName
        /// </summary>
        public string ModelSpace
        {
            get
            {
                return string.Concat("Entity.", ModelName);
                //return Modelpath + "." + ModelName;
            }
        }
        #endregion

        public string GetDALCode(bool Maxid, bool Exists, bool Add, bool Update, bool Delete, bool GetModel, bool List)
        {
            StringPlus strclass = new StringPlus();
            strclass.AppendLine("using System;");
            strclass.AppendLine("using System.Collections.Generic;");
            strclass.AppendLine("using System.Data;");
            strclass.AppendSpaceLine(2, "");

            strclass.AppendLine("namespace " + string.Concat(_namespace, ".ModuleCore.DALInterface"));
            strclass.AppendLine("{");
            strclass.AppendSpaceLine(1, "/// <summary>");
            strclass.AppendSpaceLine(1, "/// 数据访问类" + DALName + "。");
            strclass.AppendSpaceLine(1, "/// </summary>");
            //strclass.AppendSpaceLine(1, "public partial interface I" + DALName + "" + Comm.sInterfaceName);
            strclass.AppendSpaceLine(1, "public partial interface I" + DALName + "");

            strclass.AppendSpaceLine(1, "{");

            strclass.AppendSpaceLine(2, "#region  成员方法");




            #region  方法代码
            if (Maxid)
            {
                strclass.AppendLine(CreatGetMaxID());
            }
            if (Exists)
            {
                strclass.AppendLine(CreatExists());
            }
            if (Add)
            {
                strclass.AppendLine(CreatAdd());
            }
            if (Update)
            {
                strclass.AppendLine(CreatUpdate());
            }
            if (Delete)
            {
                strclass.AppendLine(CreatDelete());
            }
            if (GetModel)
            {
                strclass.AppendLine(CreatGetModel());
            }
            if(List)
            {
                strclass.AppendLine(CreatGetList());

                strclass.AppendLine(CreatGetListArray());

                strclass.AppendLine(CreatGetListPages());
                  
                strclass.AppendLine(CreatReaderBind());
            }
           
            #endregion

            strclass.AppendSpaceLine(2, "#endregion  成员方法");
            strclass.AppendSpaceLine(1, "}");
            strclass.AppendLine("}");
            strclass.AppendLine("");
            return strclass.ToString();
        }

        /// <summary>
        /// 得到GetMaxID()的方法代码
        /// </summary>
        public string CreatGetMaxID()
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
                            strclass.AppendSpaceLine(2, "int " + ModelName + "_GetMaxId();");
                            break;
                        }
                    }
                }
            }
            return strclass.ToString();
        }

        /// <summary>
        /// 得到Exists()方法的代码
        /// </summary>
        public string CreatExists()
        {
            StringPlus strclass = new StringPlus();
            strclass.AppendSpaceLine(2, "/// <summary>");
            strclass.AppendSpaceLine(2, "/// 是否存在该记录");
            strclass.AppendSpaceLine(2, "/// </summary>");
            strclass.AppendSpaceLine(2, "bool " + ModelName + "_Exists(" + CodeCommon.GetInParameter(Keys) + ");");

            return strclass.ToString();
        }

        /// <summary>
        /// 得到Add()的代码
        /// </summary>
        public string CreatAdd()
        {
            StringPlus strclass = new StringPlus();
            strclass.AppendSpaceLine(2, "/// <summary>");
            strclass.AppendSpaceLine(2, "/// 增加一条数据");
            strclass.AppendSpaceLine(2, "/// </summary>");

           // string strretu = "void";
            //if ((dbobj.DbType == "SQL2000" || dbobj.DbType == "SQL2005" || dbobj.DbType == "SQL2008") && (IsHasIdentity))
            //{
            //    strretu = "int";
            //}
            string  strretu = "int";
            strclass.AppendSpaceLine(2, strretu + " " + ModelName + "_Add(" + ModelSpace + " model);");

            return strclass.ToString();
        }

        /// <summary>
        /// 得到Update()的代码
        /// </summary>        
        public string CreatUpdate()
        {
            StringPlus strclass = new StringPlus();
            strclass.AppendSpaceLine(2, "/// <summary>");
            strclass.AppendSpaceLine(2, "/// 更新一条数据");
            strclass.AppendSpaceLine(2, "/// </summary>");
            strclass.AppendSpaceLine(2, "void " + ModelName + "_Update(" + ModelSpace + " model);");

            strclass.AppendSpaceLine(2, "");
            
            strclass.AppendSpaceLine(2, "/// <summary>");
            strclass.AppendSpaceLine(2, "/// 获取统计");
            strclass.AppendSpaceLine(2, "/// </summary>");
            strclass.AppendSpaceLine(2, "int "+ModelName+"_GetCount(string strWhere);");

            return strclass.ToString();
        }

        /// <summary>
        /// 得到Delete()的代码
        /// </summary>
        public string CreatDelete()
        {
            StringPlus strclass = new StringPlus();
            strclass.AppendSpaceLine(2, "/// <summary>");
            strclass.AppendSpaceLine(2, "/// 删除一条数据");
            strclass.AppendSpaceLine(2, "/// </summary>");
            strclass.AppendSpaceLine(2, "void " + ModelName + "_Delete(" + CodeCommon.GetInParameter(Keys) + ");");

            return strclass.ToString();
        }

        /// <summary>
        /// 得到GetModel()的代码
        /// </summary>
        public string CreatGetModel()
        {
            StringPlus strclass = new StringPlus();
            strclass.AppendSpaceLine(2, "/// <summary>");
            strclass.AppendSpaceLine(2, "/// 得到一个对象实体");
            strclass.AppendSpaceLine(2, "/// </summary>");
            strclass.AppendSpaceLine(2, "" + ModelSpace + " " + ModelName + "_GetEntity(" + CodeCommon.GetInParameter(Keys) + ");");

            return strclass.ToString();
        }

        /// <summary>
        /// 得到GetList()的代码
        /// </summary> 
        public string CreatGetList()
        {
            StringPlus strclass = new StringPlus();
            

            strclass.AppendSpaceLine(2, "/// <summary>");
            strclass.AppendSpaceLine(2, "/// 获得数据列表（比DataSet效率高，推荐使用）");
            strclass.AppendSpaceLine(2, "/// </summary>");
            strclass.AppendSpaceLine(2, "List<" + ModelSpace + "> " + ModelName + "_GetListArray(string strWhere);");

            
            return strclass.ToString();
        }

        /// <summary>
        /// 得到GetList()的代码
        /// </summary> 
        public string CreatGetListArray()
        {

            StringPlus strclass = new StringPlus();

            strclass.AppendSpaceLine(2, "/// <summary>");
            strclass.AppendSpaceLine(2, "/// 获得前几行数据");
            strclass.AppendSpaceLine(2, "/// </summary>");
            strclass.AppendSpaceLine(2, "DataSet " + ModelName + "_GetList(int Top,string strWhere,string filedOrder);");

            strclass.AppendSpaceLine(2, "");
            strclass.AppendSpaceLine(2, "/// <summary>");
            strclass.AppendSpaceLine(2, "/// 获得前几行数据");
            strclass.AppendSpaceLine(2, "/// </summary>");
            strclass.AppendSpaceLine(2, "List<" + ModelSpace + "> " + ModelName + "_GetListArray(int Top,string strWhere,string filedOrder);");


            return strclass.ToString();
        }

        /// <summary>
        /// 获得分页数据
        /// </summary> 
        public string CreatGetListPages()
        {
            StringPlus strclass = new StringPlus();
            strclass.AppendSpaceLine(2, "/// <summary>");
            strclass.AppendSpaceLine(2, "/// 获得分页数据");
            strclass.AppendSpaceLine(2, "/// </summary>");
            strclass.AppendSpaceLine(2, "List<" + ModelSpace + "> " + ModelName + "_GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby,out int RecordCount);");


            return strclass.ToString();
        }

        /// <summary>
        /// 对象实体绑定数据
        /// </summary> 
        public string CreatReaderBind()
        {
            StringPlus strclass = new StringPlus();
            strclass.AppendSpaceLine(2, "/// <summary>");
            strclass.AppendSpaceLine(2, "/// 对象实体绑定数据");
            strclass.AppendSpaceLine(2, "/// </summary>");
            strclass.AppendSpaceLine(2, "Entity."+ModelName+" "+ModelName+"_ReaderBind(IDataReader dataReader);");


            return strclass.ToString();
        }
    }
}