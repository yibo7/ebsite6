using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EbSite.Core.DataBase.Entity;
using EbSite.Core.Strings;

namespace EbSite.ModulesGenerate.Core.SysPlugins
{
    /// <summary>
    /// Model代码生成组件
    /// </summary>
    public class BuilderModel : IBuilder.IBuilderModel
    {
        #region 公有属性
        protected string _modelname = ""; //model类名
        protected string _namespace = "Maticsoft"; //顶级命名空间名
        protected string _modelpath = "";//实体类的命名空间
        protected List<ColumnInfo> _fieldlist;

        /// <summary>
        /// 顶级命名空间名 
        /// </summary>        
        public string NameSpace
        {
            set { _namespace = value; }
            get { return _namespace; }
        }
        /// <summary>
        /// 实体类的命名空间
        /// </summary>
        public string Modelpath
        {
            set { _modelpath = value; }
            get { return _modelpath; }
        }
        /// <summary>
        /// model类名
        /// </summary>
        public string ModelName
        {
            set { _modelname = value; }
            get { return _modelname; }
        }
        /// <summary>
        /// 选择的字段集合
        /// </summary>
        public List<ColumnInfo> Fieldlist
        {
            set { _fieldlist = value; }
            get { return _fieldlist; }
        }

        #endregion

        public BuilderModel()
        {
        }

        #region 生成完整Model类
        /// <summary>
        /// 生成完整sModel类
        /// </summary>		
        public string CreatModel()
        {
            string modeltype = CodeCommon.DbTypeToCS(Fieldlist[0].TypeName);
            StringPlus strclass = new StringPlus();
            strclass.AppendLine("using System;");
            strclass.AppendLine("namespace " + Modelpath);
            strclass.AppendLine("{");
            strclass.AppendSpaceLine(1, "/// <summary>");
            strclass.AppendSpaceLine(1, "/// 实体类" + _modelname + " 。(属性说明自动提取数据库字段的描述信息)");
            strclass.AppendSpaceLine(1, "/// </summary>");
            //strclass.AppendSpaceLine(1, "[Serializable]");
            //strclass.AppendSpaceLine(1, "public class " + _modelname);
            //strclass.AppendSpaceLine(1, "{");
            //strclass.AppendSpaceLine(2, "public " + _modelname + "()");
            //strclass.AppendSpaceLine(2, "{}");

            strclass.AppendSpaceLine(1, "[Serializable]");
            strclass.AppendSpaceLine(1, "public class " + _modelname + ": Base.Entity.EntityBase<" + _modelname + "," + modeltype + ">");
            strclass.AppendSpaceLine(1, "{");
            strclass.AppendSpaceLine(2, "public " + _modelname + "()");
            //2010-11-22 杨欢乐　修改成充血型
            strclass.AppendSpaceLine(2, "{");
            strclass.AppendSpaceLine(3, "base.CurrentModel = this;");
            strclass.AppendSpaceLine(2, "}");
            strclass.AppendSpaceLine(2, "public " + _modelname + "(" + modeltype + " ID)");
            strclass.AppendSpaceLine(2, "{");
            strclass.AppendSpaceLine(3, "base.id = ID;");
            strclass.AppendSpaceLine(3, "base.InitData(this);");
            strclass.AppendSpaceLine(3, "base.CurrentModel = this;");
            strclass.AppendSpaceLine(2, "}");
            strclass.AppendSpaceLine(2, "protected override EbSite.Base.BLL.BllBase<" + _modelname + ", " + modeltype + "> Bll");
            strclass.AppendSpaceLine(2, "{");
            strclass.AppendSpaceLine(3, "get");
            strclass.AppendSpaceLine(3, "{");
            strclass.AppendSpaceLine(4, "return BLL." + _modelname + ".Instance;");
            strclass.AppendSpaceLine(3, "}");
            strclass.AppendSpaceLine(2, "}");


            strclass.AppendLine(CreatModelMethod());
            strclass.AppendSpaceLine(1, "}");
            strclass.AppendLine("}");
            strclass.AppendLine("");

            return strclass.ToString();
        }
        #endregion

        #region 生成Model属性部分
        /// <summary>
        /// 生成实体类的属性
        /// </summary>
        /// <returns></returns>
        public string CreatModelMethod()
        {

            StringPlus strclass = new StringPlus();
            StringPlus strclass1 = new StringPlus();
            StringPlus strclass2 = new StringPlus();
            strclass.AppendSpaceLine(2, "#region Model");
            int j = 0;
            foreach (ColumnInfo field in Fieldlist)
            {
                string columnName = field.ColumnName;
                string columnType = field.TypeName;
                bool IsIdentity = field.IsIdentity;
                bool ispk = field.IsPK;
                bool cisnull = field.cisNull;
                string deText = field.DeText;
                columnType = CodeCommon.DbTypeToCS(columnType);
                string isnull = "";
                if (CodeCommon.isValueType(columnType))
                {
                    if ((!IsIdentity) && (!ispk) && (cisnull))
                    {
                        isnull = "?"; //代表可空类型
                    }
                }
                //2010-11-22 欢乐 充血模式　去了
                //public long id
                //{
                //    set{ _id=value;}
                //    get{return _id;}
                //}
                if (j == 0)
                {
                    j++;
                    continue;

                }
                else
                {
                    strclass1.AppendSpaceLine(2, "private " + columnType + isnull + " _" + columnName.ToLower() + ";");
                        //私有变量
                    strclass2.AppendSpaceLine(2, "/// <summary>");
                    strclass2.AppendSpaceLine(2, "/// " + deText);
                    strclass2.AppendSpaceLine(2, "/// </summary>");
                    strclass2.AppendSpaceLine(2, "public " + columnType + isnull + " " + columnName); //属性
                    strclass2.AppendSpaceLine(2, "{");
                    strclass2.AppendSpaceLine(3, "set{" + " _" + columnName.ToLower() + "=value;}");
                    strclass2.AppendSpaceLine(3, "get{return " + "_" + columnName.ToLower() + ";}");
                    strclass2.AppendSpaceLine(2, "}");
                }
            }
            strclass.Append(strclass1.Value);
            strclass.Append(strclass2.Value);
            strclass.AppendSpaceLine(2, "#endregion Model");

            return strclass.ToString();
        }

        #endregion
    }
}