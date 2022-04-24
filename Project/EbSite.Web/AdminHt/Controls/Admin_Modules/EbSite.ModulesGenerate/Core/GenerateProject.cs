using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using EbSite.Core.DataBase;
using EbSite.Core.DataBase.Entity;
using EbSite.Core.DataBase.Interface;
using EbSite.Core.Strings;
using EbSite.ModulesGenerate.Core.CodeBuild;

namespace EbSite.ModulesGenerate.Core
{
    public class GenerateProject
    {
        private string strnamespace = "";
        private string _Tabpre;
        private string strfolder = ""; //文件夹
        //private string dbname;
        //private string _AppFrame;
        string ProOutPath = "/Modules/";//输出路径
        private string DalType = "BuilderDAL"; //目前只支持默认数据层插件
        private string BllType = "BuilderBLL";//目前只支持默认数据接口插件
        //private string _ProjectCnName = "";
        //private string _ProjectEnName = "";
        //private List<string> _Tables ;


        private ProjectInfo _PjInfo;


        IDbObject dbobj;//数据库对象
        CodeBuilders cb;//代码生成对象
        DbSettings dbset;//服务器配置     
        /// <summary>
        /// 生成一个项目
        /// </summary>
        /// <param name="PJInfo">项目信息</param>
        public GenerateProject(ProjectInfo PJInfo)
        {
            _PjInfo = PJInfo;

            dbset = DbConfig.GetSetting(_PjInfo.dbtype, _PjInfo.ServerIp, _PjInfo.DbName, _PjInfo.sConn);
            dbobj = DBOMaker.CreateDbObj(dbset.DbType);
            dbobj.DbConnectStr = dbset.ConnectStr;
            cb = new CodeBuilders(dbobj);

            _Tabpre = PJInfo.Tabpre;
            strnamespace = string.Concat("EbSite.Modules.", _PjInfo.ProjectEnName);
            ProOutPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, string.Concat("Modules\\", _PjInfo.ProjectEnName, "\\"));
        }
        private string ReplaceProjName(string sContent)
        {
            return sContent.Replace("EBModulesProjectName", _PjInfo.ProjectEnName);
        }
        /// <summary>
        /// 复制项目模板并做相关替换处理
        /// </summary>
        private void CopyProject()
        {
            string OldPath = string.Concat(GetProjectTempPath, "Vs2010\\");
            string NewPath = ProOutPath;
            EbSite.Core.FSO.FObject.CopyDirectory(OldPath, NewPath);

            //生成项目文件
            string CsProjTem =
                EbSite.Core.FSO.FObject.ReadFile(string.Concat(GetProjectTempPath,
                                                             "EbSite.Modules.EBModulesProjectName.csproj"));

            EbSite.Core.FSO.FObject.WriteFile(GetVsCsprojFilePath, ReplaceProjName(CsProjTem));



            //处理配置文件 setting
            string StPath = string.Concat(ProOutPath, "Setting.ascx");
            string settingInfo = EbSite.Core.FSO.FObject.ReadFile(StPath);
            EbSite.Core.FSO.FObject.WriteFile(StPath, ReplaceProjName(settingInfo));

            StPath = string.Concat(ProOutPath, "Setting.ascx.cs");
            settingInfo = EbSite.Core.FSO.FObject.ReadFile(StPath);
            EbSite.Core.FSO.FObject.WriteFile(StPath, ReplaceProjName(settingInfo));

            StPath = string.Concat(ProOutPath, "Setting.ascx.designer.cs");
            settingInfo = EbSite.Core.FSO.FObject.ReadFile(StPath);
            EbSite.Core.FSO.FObject.WriteFile(StPath, ReplaceProjName(settingInfo));

            //杨欢乐　添加　处理DataStore/Configs/Base.config
            StPath = string.Concat(ProOutPath, "DataStore/Configs/Base.config");
            settingInfo = EbSite.Core.FSO.FObject.ReadFile(StPath);
            settingInfo = settingInfo.Replace("#ConnectionString#", System.Web.HttpContext.Current.Session["Conn"].ToString()).Replace("#Pre#", System.Web.HttpContext.Current.Session["pre"].ToString());
            EbSite.Core.FSO.FObject.WriteFile(StPath, ReplaceProjName(settingInfo));



            ////杨欢乐　添加　菜单
            //StPath = string.Concat(ProOutPath, "DataStore/Menus_Admin.txt");
            //settingInfo = EbSite.Core.FSO.FObject.ReadFile(StPath);
            //settingInfo = settingInfo.Replace("#Menus#", cb.ModelName+"|"+cb.ModelName+".aspx");
            //EbSite.Core.FSO.FObject.WriteFile(StPath, ReplaceProjName(settingInfo));


            //[ModuleAttribute("常用工具", Version = "1.0.0", Author = "小菜", AuthorUrl = "http://www.EbSite.cn", AccessFile = "", SqlScript = "db/sql.txt")]
            //base.IsUserSysConn = true;

            StPath = string.Concat(ProOutPath, "SettingInfo.cs");
            settingInfo = EbSite.Core.FSO.FObject.ReadFile(StPath);
            if (_PjInfo.IsUserSysConn)
            {
                //杨欢乐　修改
                settingInfo = settingInfo.Replace("base.IsUserSysConn = true;", "base.IsUserSysConn = true;");
            }
            else
            {
                settingInfo = settingInfo.Replace("//base.IsUserSysConn = true;", "base.IsUserSysConn = true;");

            }


            settingInfo = settingInfo.Replace("#ModuleSettingInfo#",
                string.Format("[ModuleAttribute(\"{0}\", Version = \"{1}\", Author = \"{2}\", AuthorUrl = \"{3}\", AccessFile = \"db/db.config\", SqlScript = \"db/sql.txt\")]",
                _PjInfo.ProjectCnName, _PjInfo.sVersion, _PjInfo.Author, _PjInfo.AuthorUrl
                )
               );

            EbSite.Core.FSO.FObject.WriteFile(StPath, ReplaceProjName(settingInfo));
        }
        /// <summary>
        /// 向项目添加数据库处理相关类
        /// </summary>
        private void AddDataBaseClassToProject()
        {
            //要处理的文件以下:
            //AccessProvider.cs  acceess数据库
            //SqlServerProvider.cs SqlServer数据库
            //SqlServerProviderCOMM.cs SqlServer数据库处理公共类
            //DBHelper.cs   数据库处理帮助文件
            //BLLBase.cs   业务层基类
            //F3DataProvider.cs

            //AccessProvider.cs
            string sTempFilePath = string.Concat(GetProjectTempPath, "AccessProvider.cs");
            string sContent = EbSite.Core.FSO.FObject.ReadFile(sTempFilePath);
            string vsPath = "ModuleCore\\DAL\\Access\\Sys\\AccessProvider.cs";
            string sSavePath = string.Concat(ProOutPath, vsPath);
            sContent = ReplaceProjName(sContent);
            EbSite.Core.FSO.FObject.WriteFile(sSavePath, sContent);
            AddClassFile(GetVsCsprojFilePath, vsPath, "");
            //SqlServerProvider.cs
            sTempFilePath = string.Concat(GetProjectTempPath, "SqlServerProvider.cs");
            sContent = EbSite.Core.FSO.FObject.ReadFile(sTempFilePath);
            vsPath = "ModuleCore\\DAL\\SqlServer\\Sys\\SqlServerProvider.cs";
            sSavePath = string.Concat(ProOutPath, vsPath);
            sContent = ReplaceProjName(sContent);
            EbSite.Core.FSO.FObject.WriteFile(sSavePath, sContent);
            AddClassFile(GetVsCsprojFilePath, vsPath, "");
            //COMM.cs
            sTempFilePath = string.Concat(GetProjectTempPath, "SqlServerCOMM.cs");
            sContent = EbSite.Core.FSO.FObject.ReadFile(sTempFilePath);
            sContent = ReplaceProjName(sContent);

            vsPath = "ModuleCore\\DAL\\SqlServer\\Sys\\Utils.cs";
            sSavePath = string.Concat(ProOutPath, vsPath);
            EbSite.Core.FSO.FObject.WriteFile(sSavePath, sContent.Replace("#DataBaseType#", "SqlServer"));
            AddClassFile(GetVsCsprojFilePath, vsPath, "");

            vsPath = "ModuleCore\\DAL\\Access\\Sys\\Utils.cs";
            sSavePath = string.Concat(ProOutPath, vsPath);
            EbSite.Core.FSO.FObject.WriteFile(sSavePath, sContent.Replace("#DataBaseType#", "Access"));
            AddClassFile(GetVsCsprojFilePath, vsPath, "");
            //DBHelper.cs
            sTempFilePath = string.Concat(GetProjectTempPath, "DBHelper.cs");
            sContent = EbSite.Core.FSO.FObject.ReadFile(sTempFilePath);
            vsPath = "ModuleCore\\DAL\\DataProfile\\DBHelper.cs";
            sSavePath = string.Concat(ProOutPath, vsPath);
            sContent = ReplaceProjName(sContent);
            StringPlus sp = new StringPlus();
            if (Equals(_PjInfo.AppFrame, "F3"))
            {
                sp.AppendSpaceLine(0, "try");
                sp.AppendSpaceLine(0, "{");
                sp.AppendSpaceLine(2, "m_provider = (IDbProvider)Activator.CreateInstance(Type.GetType(string.Format(\"EbSite.Modules.CustomTools.ModuleCore.DAL.{0}.Sys.{0}Provider\", SettingInfo.Instance.GetBaseConfig.Instance.DataLayerType), false, true));");
                sp.AppendSpaceLine(0, "}");
                sp.AppendSpaceLine(0, "catch");
                sp.AppendSpaceLine(0, "{");
                sp.AppendSpaceLine(2, "throw new Exception(\"请检查Base.config中Dbtype节点数据库类型是否正确，例如：SqlServer、Access、MySql\");");
                sp.AppendSpaceLine(0, "}");



            }
            else
            {
                sp.AppendSpaceLine(0, "m_provider = new SqlServer.Sys.SqlServerProvider();");
            }
            sContent = sContent.Replace(" #DataBaseProvider#", sp.ToString());
            EbSite.Core.FSO.FObject.WriteFile(sSavePath, sContent);
            AddClassFile(GetVsCsprojFilePath, vsPath, "");
            //BLLBase.cs
            sTempFilePath = string.Concat(GetProjectTempPath, "BLLBase.cs");
            sContent = EbSite.Core.FSO.FObject.ReadFile(sTempFilePath);
            vsPath = "ModuleCore\\BLL\\Base\\BLLBase.cs";
            sSavePath = string.Concat(ProOutPath, vsPath);

            sContent = ReplaceProjName(sContent);
            if (Equals(_PjInfo.AppFrame, "F3"))
            {
                sContent = sContent.Replace("#DataProvider#", string.Format("protected ModuleCore.DALInterface.I{0} dalHelper = ModuleCore.DAL.DataProfile.DataProvider.GetInstance();", _PjInfo.ProjectEnName));
            }
            else
            {
                sContent = sContent.Replace("#DataProvider#", string.Format("protected static DAL.{0}.{1} dalHelper = new DAL.{0}.{1}(); ", Equals(_PjInfo.dbtype, "OleDb") ? "Access" : "SqlServer", _PjInfo.ProjectEnName));
            }
            EbSite.Core.FSO.FObject.WriteFile(sSavePath, sContent);
            AddClassFile(GetVsCsprojFilePath, vsPath, "");


            if (Equals(_PjInfo.AppFrame, "F3"))
            {
                //F3DataProvider.cs
                sTempFilePath = string.Concat(GetProjectTempPath, "F3DataProvider.cs");
                sContent = EbSite.Core.FSO.FObject.ReadFile(sTempFilePath);
                vsPath = "ModuleCore\\DAL\\DataProfile\\DataProvider.cs";
                sSavePath = string.Concat(ProOutPath, vsPath);
                sContent = ReplaceProjName(sContent);
                EbSite.Core.FSO.FObject.WriteFile(sSavePath, sContent);
                AddClassFile(GetVsCsprojFilePath, vsPath, "");
            }


        }

        public void StartMake()
        {
            cb.DbName = _PjInfo.DbName;
            if (strnamespace != "")
            {
                cb.NameSpace = strnamespace;
            }
            cb.Folder = strfolder;
            cb.ProcPrefix = ""; //存尺过程的前缀
            cb.DbHelperName = "DB";
            //复制项目模板并做相关替换处理
            CopyProject();

            //如果此项目是数据库类的，添加数据库处理相关类
            if (Equals(_PjInfo.AppFrame, "F3") || Equals(_PjInfo.AppFrame, "S3"))
            {
                AddDataBaseClassToProject();
            }

            foreach (string tablename in _PjInfo.Tables)
            {
                cb.TableName = tablename;
                cb.ModelName = tablename;
                //string tabpre = txtTabNamepre.Text.Trim();
                if (!string.IsNullOrEmpty(_Tabpre))
                {
                    if (tablename.StartsWith(_Tabpre))
                    {
                        cb.ModelName = tablename.Substring(_Tabpre.Length);
                    }
                }
                string strmodelname = cb.ModelName;
                //命名规则处理
                cb.ModelName = strmodelname;//namerule.GetModelClass(strmodelname);
                cb.BLLName = strmodelname;//namerule.GetBLLClass(strmodelname);
                cb.DALName = _PjInfo.ProjectEnName;//namerule.GetDALClass(strmodelname);


                DataTable dtkey = dbobj.GetKeyName(_PjInfo.DbName, tablename);
                List<ColumnInfo> dt = dbobj.GetColumnInfoList(_PjInfo.DbName, tablename);
                cb.Fieldlist = dt;
                cb.Keys = CodeCommon.GetColumnInfos(dtkey);

                //复制项目文件

                CreatCS();
            }
        }

        //架构选择
        private void CreatCS()
        {
            switch (_PjInfo.AppFrame)
            {

                case "xml":
                    CreatCsOne();
                    break;
                case "S3":
                case "F3":
                    CreatCsDataBase();
                    break;
            }
        }

        #region 单类结构
        private void CreatCsOne()
        {
            //string strnamespace = this.txtNamespace.Text.Trim();
            //string strfolder = this.txtFolder.Text.Trim();
            //if (strfolder.Trim() != "")
            //{
            //    cb.NameSpace = strnamespace + "." + strfolder;
            //    cb.Folder = strfolder;
            //}
            //string strCode = cb.GetCodeFrameOne(GetDALType(), true, true, true, true, true, true, true);

            //string TargetFolder = ProOutPath;
            //FolderCheck(TargetFolder);

            //string classFolder = TargetFolder + "\\Class";
            //FolderCheck(classFolder);
            //string filename = classFolder + "\\" + cb.ModelName + ".cs";
            //WriteFile(filename, strCode);
        }
        #endregion

        #region 数据库处理三层
        private void CreatCsDataBase()
        {

            #region Model
            //实体生成存放目录
            string modelFolder = GetEntityPath(true);
            if (cb.Folder != "")
            {
                modelFolder = modelFolder + "\\" + cb.Folder;
            }
            string filemodel = modelFolder + "\\" + cb.ModelName + ".cs";
            string strmodel = cb.GetCodeFrameS3Model();
            EbSite.Core.FSO.FObject.WriteFile(filemodel, strmodel);
            string vsPath = string.Concat(GetEntityPath(false), "\\", cb.ModelName, ".cs");
            AddClassFile(GetVsCsprojFilePath, vsPath, "");

            #endregion

            #region BLL
            string bllFolder = GetBLLPath(true);
            if (cb.Folder != "")
            {
                bllFolder = bllFolder + "\\" + cb.Folder;
            }
            string filebll = bllFolder + "\\" + cb.BLLName + ".cs";

            string strbll = cb.GetCodeFrameF3BLL(BllType, true, true, true, true, true, true, true, true);
            EbSite.Core.FSO.FObject.WriteFile(filebll, strbll);
            vsPath = string.Concat(GetBLLPath(false), "\\", cb.ModelName, ".cs");
            AddClassFile(GetVsCsprojFilePath, vsPath, "");
            #endregion

            #region DAL
            string dalFolder = GetDALPath(true);
            if (cb.Folder != "")
            {
                dalFolder = dalFolder + "\\" + cb.Folder;
            }
            string filedal = dalFolder + "\\" + cb.ModelName + ".cs";
            string strdal = "";
            if (Equals(_PjInfo.AppFrame, "S3"))
            {
                strdal = cb.GetCodeFrameS3DAL(DalType, true, true, true, true, true, true, true);
            }
            else
            {
                strdal = cb.GetCodeFrameF3DAL(DalType, true, true, true, true, true, true, true);
                //生成接口
                string idalFolder = GetIDALPath(true);
                if (cb.Folder != "")
                {
                    idalFolder = idalFolder + "\\" + cb.Folder;
                }
                string fileidal = idalFolder + "\\I" + cb.ModelName + ".cs";
                string stridal = cb.GetCodeFrameF3IDAL(DalType, true, true, true, true, true, true, true);
                EbSite.Core.FSO.FObject.WriteFile(fileidal, stridal);
                vsPath = string.Concat(GetIDALPath(false), "\\I", cb.ModelName, ".cs");
                AddClassFile(GetVsCsprojFilePath, vsPath, "");
            }


            EbSite.Core.FSO.FObject.WriteFile(filedal, strdal);
            vsPath = string.Concat(GetDALPath(false), "\\", cb.ModelName, ".cs");
            AddClassFile(GetVsCsprojFilePath, vsPath, "");
            #endregion

            //#region web生成

            string webtype = "目前不应用插件";
            //_Tabpre
            List<FieldInfo> AddColum = HttpContext.Current.Session["FieldAdd"] as List<FieldInfo>;
            List<FieldInfo> ListColum = HttpContext.Current.Session["FieldList"] as List<FieldInfo>;
            List<FieldInfo> ShowColum = HttpContext.Current.Session["FieldShow"] as List<FieldInfo>;
            List<FieldInfo> SearchColum = HttpContext.Current.Session["FieldSearch"] as List<FieldInfo>;
            List<FieldInfo> SearchAdvColum = HttpContext.Current.Session["FieldSearchAdv"] as List<FieldInfo>;
            AddColum = GetDropPre(AddColum);
            ListColum = GetDropPre(ListColum);
            ShowColum = GetDropPre(ShowColum);
            SearchColum = GetDropPre(SearchColum);
            SearchAdvColum = GetDropPre(SearchAdvColum);
            cb.CreatBuilderWeb(webtype, SearchColum, SearchAdvColum, AddColum, ListColum, ShowColum);

            #region 生成路由页面


            //杨欢乐　添加　菜单
            string StPath = string.Concat(ProOutPath, "DataStore/Menus_Admin.txt");
            string settingInfo = EbSite.Core.FSO.FObject.ReadFile(StPath);
            settingInfo = cb.ModelName + "|" + cb.ModelName + ".aspx" + Environment.NewLine;
            EbSite.Core.FSO.FObject.WriteFile(StPath, settingInfo, true);


            //string fileaspxTemp = string.Concat(GetProjectTempPath, "PagesTemp\\Page\\temp.aspx");
            //string fileaspxcsTemp = string.Concat(GetProjectTempPath, "PagesTemp\\Page\\temp.aspx.cs");
            //string fileaspxdsTemp = string.Concat(GetProjectTempPath, "PagesTemp\\Page\\temp.aspx.designer.cs"); 

            string fileaspx = string.Concat(GetWebPath(true), "\\", cb.ModelName, ".aspx");
            string fileaspxcs = string.Concat(GetWebPath(true), "\\", cb.ModelName, ".aspx.cs");
            //2008 2010 命名规则为 temp.aspx.designer.cs
            string fileaspxds = string.Concat(GetWebPath(true), "\\", cb.ModelName, ".aspx.designer.cs");
            //string TempContent = "";
            string sCoreTemp = "";






            //TempContent = EbSite.Core.FSO.FObject.ReadFile(fileaspxTemp);
            sCoreTemp = cb.GetRouteHTML();
            //TempContent = TempContent.Replace("#CoreTemp#", "");
            EbSite.Core.FSO.FObject.WriteFile(fileaspx, sCoreTemp);
            vsPath = string.Concat(GetWebPath(false), "\\", cb.ModelName, ".aspx");
            vsp.AddAspx2010(GetVsCsprojFilePath, vsPath);

            //TempContent = EbSite.Core.FSO.FObject.ReadFile(fileaspxcsTemp);
            sCoreTemp = cb.GetRouteCS();
            //TempContent = TempContent.Replace("#CoreTemp#", "");
            EbSite.Core.FSO.FObject.WriteFile(fileaspxcs, sCoreTemp);

            //TempContent = EbSite.Core.FSO.FObject.ReadFile(fileaspxdsTemp);
            sCoreTemp = cb.GetRouteDesigner();
            //TempContent = TempContent.Replace("#CoreTemp#", "");
            EbSite.Core.FSO.FObject.WriteFile(fileaspxds, sCoreTemp);


            //if (File.Exists(fileaspxTemp) && File.Exists(fileaspxcsTemp) && File.Exists(fileaspxdsTemp))
            //{
            //    TempContent = EbSite.Core.FSO.FObject.ReadFile(fileaspxTemp);
            //    sCoreTemp = cb.GetAddAspx();
            //    TempContent = TempContent.Replace("#CoreTemp#", "");
            //    EbSite.Core.FSO.FObject.WriteFile(fileaspx, TempContent);
            //    vsPath = string.Concat(GetWebPath(false), "\\", cb.ModelName, ".aspx");
            //    vsp.AddAspx2010(GetVsCsprojFilePath, vsPath);

            //    TempContent = EbSite.Core.FSO.FObject.ReadFile(fileaspxcsTemp);
            //    sCoreTemp = cb.GetAddAspxCs();
            //    TempContent = TempContent.Replace("#CoreTemp#", "");
            //    EbSite.Core.FSO.FObject.WriteFile(fileaspxcs, TempContent);

            //    TempContent = EbSite.Core.FSO.FObject.ReadFile(fileaspxdsTemp);
            //    sCoreTemp = cb.GetAddDesigner();
            //    TempContent = TempContent.Replace("#CoreTemp#", "");
            //    EbSite.Core.FSO.FObject.WriteFile(fileaspxds, TempContent);
            //}
            //else
            //{
            //    throw new Exception("路由页面不存在代码模板文件！");
            //}

            #endregion

            #region 生成控件文件

            //内容列表页
            //fileaspxTemp = string.Concat(GetProjectTempPath, "PagesTemp\\Ctr\\List.ascx");
            //fileaspxcsTemp = string.Concat(GetProjectTempPath, "PagesTemp\\Ctr\\List.ascx.cs");
            //fileaspxdsTemp = string.Concat(GetProjectTempPath, "PagesTemp\\Ctr\\List.ascx.designer.cs");

            fileaspx = string.Concat(GetCtrPath(true), "\\List.ascx");
            fileaspxcs = string.Concat(GetCtrPath(true), "\\List.ascx.cs");
            //2008 2010 命名规则为 temp.aspx.designer.cs
            fileaspxds = string.Concat(GetCtrPath(true), "\\List.ascx.designer.cs");

            //TempContent = EbSite.Core.FSO.FObject.ReadFile(fileaspxTemp);
            sCoreTemp = cb.GetListHTML();
            //TempContent = TempContent.Replace("#CoreTemp#", "");
            EbSite.Core.FSO.FObject.WriteFile(fileaspx, sCoreTemp);
            vsPath = string.Concat(GetCtrPath(false), "\\List.ascx");
            vsp.AddAspx2010(GetVsCsprojFilePath, vsPath);

            //TempContent = EbSite.Core.FSO.FObject.ReadFile(fileaspxcsTemp);
            sCoreTemp = cb.GetListCs();
            //TempContent = TempContent.Replace("#CoreTemp#", "");
            EbSite.Core.FSO.FObject.WriteFile(fileaspxcs, sCoreTemp);

            //TempContent = EbSite.Core.FSO.FObject.ReadFile(fileaspxdsTemp);
            sCoreTemp = cb.GetListDesigner();
            //TempContent = TempContent.Replace("#CoreTemp#", "");
            EbSite.Core.FSO.FObject.WriteFile(fileaspxds, sCoreTemp);

            //if (File.Exists(fileaspxTemp) && File.Exists(fileaspxcsTemp) && File.Exists(fileaspxdsTemp))
            //{
            //    TempContent = EbSite.Core.FSO.FObject.ReadFile(fileaspxTemp);
            //    //sCoreTemp = cb.GetAddAspx();
            //    TempContent = TempContent.Replace("#CoreTemp#", "");
            //    EbSite.Core.FSO.FObject.WriteFile(fileaspx, TempContent);
            //    vsPath = string.Concat(GetCtrPath(false), "\\List.ascx");
            //    vsp.AddAspx2010(GetVsCsprojFilePath, vsPath);

            //    TempContent = EbSite.Core.FSO.FObject.ReadFile(fileaspxcsTemp);
            //    //sCoreTemp = cb.GetAddAspxCs();
            //    TempContent = TempContent.Replace("#CoreTemp#", "");
            //    EbSite.Core.FSO.FObject.WriteFile(fileaspxcs, TempContent);

            //    TempContent = EbSite.Core.FSO.FObject.ReadFile(fileaspxdsTemp);
            //    //sCoreTemp = cb.GetAddDesigner();
            //    TempContent = TempContent.Replace("#CoreTemp#", "");
            //    EbSite.Core.FSO.FObject.WriteFile(fileaspxds, TempContent);
            //}
            //else
            //{
            //    throw new Exception("控件页面不存在代码模板文件！");
            //}


            //内容添加页
            //fileaspxTemp = string.Concat(GetProjectTempPath, "PagesTemp\\Ctr\\Add.ascx");
            //fileaspxcsTemp = string.Concat(GetProjectTempPath, "PagesTemp\\Ctr\\Add.ascx.cs");
            //fileaspxdsTemp = string.Concat(GetProjectTempPath, "PagesTemp\\Ctr\\Add.ascx.designer.cs");

            fileaspx = string.Concat(GetCtrPath(true), "\\Add.ascx");
            fileaspxcs = string.Concat(GetCtrPath(true), "\\Add.ascx.cs");
            //2008 2010 命名规则为 temp.aspx.designer.cs
            fileaspxds = string.Concat(GetCtrPath(true), "\\Add.ascx.designer.cs");

            //TempContent = EbSite.Core.FSO.FObject.ReadFile(fileaspxTemp);
            sCoreTemp = cb.GetAddHTML();
            //TempContent = TempContent.Replace("#CoreTemp#", "");
            EbSite.Core.FSO.FObject.WriteFile(fileaspx, sCoreTemp);
            vsPath = string.Concat(GetCtrPath(false), "\\Add.ascx");
            vsp.AddAspx2010(GetVsCsprojFilePath, vsPath);

            //TempContent = EbSite.Core.FSO.FObject.ReadFile(fileaspxcsTemp);
            sCoreTemp = cb.GetAddCs();
            //TempContent = TempContent.Replace("#CoreTemp#", "");
            EbSite.Core.FSO.FObject.WriteFile(fileaspxcs, sCoreTemp);

            //TempContent = EbSite.Core.FSO.FObject.ReadFile(fileaspxdsTemp);
            sCoreTemp = cb.GetAddDesigner();
            //TempContent = TempContent.Replace("#CoreTemp#", "");
            EbSite.Core.FSO.FObject.WriteFile(fileaspxds, sCoreTemp);

            //if (File.Exists(fileaspxTemp) && File.Exists(fileaspxcsTemp) && File.Exists(fileaspxdsTemp))
            //{
            //    TempContent = EbSite.Core.FSO.FObject.ReadFile(fileaspxTemp);
            //    //sCoreTemp = cb.GetAddAspx();
            //    TempContent = TempContent.Replace("#CoreTemp#", "");
            //    EbSite.Core.FSO.FObject.WriteFile(fileaspx, TempContent);
            //    vsPath = string.Concat(GetCtrPath(false), "\\Add.ascx");
            //    vsp.AddAspx2010(GetVsCsprojFilePath, vsPath);

            //    TempContent = EbSite.Core.FSO.FObject.ReadFile(fileaspxcsTemp);
            //    //sCoreTemp = cb.GetAddAspxCs();
            //    TempContent = TempContent.Replace("#CoreTemp#", "");
            //    EbSite.Core.FSO.FObject.WriteFile(fileaspxcs, TempContent);

            //    TempContent = EbSite.Core.FSO.FObject.ReadFile(fileaspxdsTemp);
            //    //sCoreTemp = cb.GetAddDesigner();
            //    TempContent = TempContent.Replace("#CoreTemp#", "");
            //    EbSite.Core.FSO.FObject.WriteFile(fileaspxds, TempContent);
            //}
            //else
            //{
            //    throw new Exception("控件页面不存在代码模板文件！");
            //}

            //内容添加页
            //fileaspxTemp = string.Concat(GetProjectTempPath, "PagesTemp\\Ctr\\Show.ascx");
            //fileaspxcsTemp = string.Concat(GetProjectTempPath, "PagesTemp\\Ctr\\Show.ascx.cs");
            //fileaspxdsTemp = string.Concat(GetProjectTempPath, "PagesTemp\\Ctr\\Show.ascx.designer.cs");

            fileaspx = string.Concat(GetCtrPath(true), "\\Show.ascx");
            fileaspxcs = string.Concat(GetCtrPath(true), "\\Show.ascx.cs");
            //2008 2010 命名规则为 temp.aspx.designer.cs
            fileaspxds = string.Concat(GetCtrPath(true), "\\Show.ascx.designer.cs");

            //TempContent = EbSite.Core.FSO.FObject.ReadFile(fileaspxTemp);
            sCoreTemp = cb.GetShowHTML();
            //TempContent = TempContent.Replace("#CoreTemp#", "");
            EbSite.Core.FSO.FObject.WriteFile(fileaspx, sCoreTemp);
            vsPath = string.Concat(GetCtrPath(false), "\\Show.ascx");
            vsp.AddAspx2010(GetVsCsprojFilePath, vsPath);

            //TempContent = EbSite.Core.FSO.FObject.ReadFile(fileaspxcsTemp);
            sCoreTemp = cb.GetShowCs();
            //TempContent = TempContent.Replace("#CoreTemp#", "");
            EbSite.Core.FSO.FObject.WriteFile(fileaspxcs, sCoreTemp);

            //TempContent = EbSite.Core.FSO.FObject.ReadFile(fileaspxdsTemp);
            sCoreTemp = cb.GetShowDesigner();
            //TempContent = TempContent.Replace("#CoreTemp#", "");
            EbSite.Core.FSO.FObject.WriteFile(fileaspxds, sCoreTemp);

            //if (File.Exists(fileaspxTemp) && File.Exists(fileaspxcsTemp) && File.Exists(fileaspxdsTemp))
            //{
            //    TempContent = EbSite.Core.FSO.FObject.ReadFile(fileaspxTemp);
            //    //sCoreTemp = cb.GetAddAspx();
            //    TempContent = TempContent.Replace("#CoreTemp#", "");
            //    EbSite.Core.FSO.FObject.WriteFile(fileaspx, TempContent);
            //    vsPath = string.Concat(GetCtrPath(false), "\\Show.ascx");
            //    vsp.AddAspx2010(GetVsCsprojFilePath, vsPath);

            //    TempContent = EbSite.Core.FSO.FObject.ReadFile(fileaspxcsTemp);
            //    //sCoreTemp = cb.GetAddAspxCs();
            //    TempContent = TempContent.Replace("#CoreTemp#", "");
            //    EbSite.Core.FSO.FObject.WriteFile(fileaspxcs, TempContent);

            //    TempContent = EbSite.Core.FSO.FObject.ReadFile(fileaspxdsTemp);
            //    //sCoreTemp = cb.GetAddDesigner();
            //    TempContent = TempContent.Replace("#CoreTemp#", "");
            //    EbSite.Core.FSO.FObject.WriteFile(fileaspxds, TempContent);
            //}
            //else
            //{
            //    throw new Exception("控件页面不存在代码模板文件！");
            //}
            #endregion



        #endregion
        }
        private List<FieldInfo> GetDropPre(List<FieldInfo> list)
        {
            //cb.ModelName
            //_Tabpre
            //取出一个表的记录
            if (!Equals(list, null))
            {
                list = (from li in list
                        where li.TableName == _Tabpre + cb.ModelName
                        select new FieldInfo
                        {
                            FieldName = li.FieldName,
                            ControlId = li.ControlId,
                            Matching = li.Matching,
                            Relevance = li.Relevance
                        }
                  ).ToList();
            }
            return list;
        }

        #region 工厂模式三层

        //private void CreatCsF3()
        //{

        //    #region Model
        //    //实体生成存放目录
        //    string modelFolder = GetEntityPath(true);
        //    if (cb.Folder != "")
        //    {
        //        modelFolder = modelFolder + "\\" + cb.Folder;
        //    }
        //    string filemodel = modelFolder + "\\" + cb.ModelName + ".cs";
        //    string strmodel = cb.GetCodeFrameS3Model();
        //    EbSite.Core.FSO.FObject.WriteFile(filemodel, strmodel);
        //    string vsPath = string.Concat(GetEntityPath(false), "\\", cb.ModelName, ".cs");
        //    AddClassFile(GetVsCsprojFilePath, vsPath, "");

        //    #endregion

        //    #region DAL
        //    string dalFolder = GetDALPath(true);
        //    if (cb.Folder != "")
        //    {
        //        dalFolder = dalFolder + "\\" + cb.Folder;
        //    }

        //    string filedal = dalFolder + "\\" + cb.DALName + ".cs";
        //    string strdal = cb.GetCodeFrameF3DAL(DalType, true, true, true, true, true, true, true);
        //    EbSite.Core.FSO.FObject.WriteFile(filedal, strdal);
        //    vsPath = string.Concat(GetDALPath(false), "\\", cb.ModelName, ".cs");
        //    AddClassFile(GetVsCsprojFilePath, vsPath, "");
        //    #endregion

        //    #region DALFactory
        //    //string factoryFolder = TargetFolder + "\\DALFactory";
        //    //string strdalfac = cb.GetCodeFrameF3DALFactory();
        //    //string filedalfac = factoryFolder + "\\DataAccess.cs";
        //    ////已经存在，并且有内容，则追加
        //    //if (File.Exists(filedalfac))
        //    //{
        //    //    string temp = File.ReadAllText(filedalfac, Encoding.Default);
        //    //    if (temp.IndexOf("class DataAccess") > 0)
        //    //    {
        //    //        strdalfac = cb.GetCodeFrameF3DALFactoryMethod();
        //    //        //vsp.AddMethodToClass(filedalfac, strdalfac);
        //    //    }
        //    //    else
        //    //    {
        //    //        strdalfac = cb.GetCodeFrameF3DALFactory();
        //    //        StreamWriter sw = new StreamWriter(filedalfac, true, Encoding.Default);
        //    //        sw.Write(strdalfac);
        //    //        sw.Flush();
        //    //        sw.Close();
        //    //    }
        //    //}
        //    //else//否则，新建该文件
        //    //{
        //    //    strdalfac = cb.GetCodeFrameF3DALFactory();
        //    //    //WriteFile(filedalfac, strdalfac);
        //    //}

        //    #endregion

        //    #region IDAL
        //    string idalFolder = GetIDALPath(true);
        //    if (cb.Folder != "")
        //    {
        //        idalFolder = idalFolder + "\\" + cb.Folder;
        //    }
        //    string fileidal = idalFolder + "\\I" + cb.DALName + ".cs";
        //    string stridal = cb.GetCodeFrameF3IDAL(true, true, true, true, true, true, true, true);
        //    EbSite.Core.FSO.FObject.WriteFile(fileidal, stridal);
        //    vsPath = string.Concat(GetIDALPath(false), "\\I", cb.ModelName, ".cs");
        //    AddClassFile(GetVsCsprojFilePath, vsPath, "");
        //    #endregion

        //    #region BLL
        //    string bllFolder = GetBLLPath(true);
        //    if (cb.Folder != "")
        //    {
        //        bllFolder = bllFolder + "\\" + cb.Folder;
        //    }
        //    string filebll = bllFolder + "\\" + cb.BLLName + ".cs";

        //    string strbll = cb.GetCodeFrameF3BLL(BllType, true, true, true, true, true, true, true, true);
        //    EbSite.Core.FSO.FObject.WriteFile(filebll, strbll);
        //    vsPath = string.Concat(GetBLLPath(false), "\\", cb.ModelName, ".cs");
        //    AddClassFile(GetVsCsprojFilePath, vsPath, "");
        //    #endregion

        //    //#region web生成
        //    //string webtype = GetWebType();
        //    //cb.CreatBuilderWeb(webtype);

        //    //string webFolder = TargetFolder + "\\Web";
        //    //if (cb.Folder != "")
        //    //{
        //    //    webFolder = webFolder + "\\" + cb.Folder;
        //    //}
        //    ////FolderCheck(webFolder);
        //    ////FolderCheck(webFolder + "\\" + cb.ModelName);
        //    //string tempstr = "";

        //    //#region ADD
        //    //string fileaspx = webFolder + "\\" + cb.ModelName + "\\Add.aspx";
        //    //string fileaspxcs = webFolder + "\\" + cb.ModelName + "\\Add.aspx.cs";
        //    //string fileaspxds = webFolder + "\\" + cb.ModelName + "\\Add.aspx.designer.cs";

        //    //string tempaspx = @"\Template\web\Add.aspx";
        //    //string tempaspxcs = @"\Template\web\Add.aspx.cs";
        //    //string tempaspxds = @"\Template\web\Add.aspx.designer.cs";
        //    //if (File.Exists(tempaspx))
        //    //{
        //    //    using (StreamReader sr = new StreamReader(tempaspx, Encoding.Default))
        //    //    {
        //    //        string s = cb.GetAddAspx();
        //    //        tempstr = sr.ReadToEnd().Replace(".Demo.Add", "." + cb.ModelName + ".Add").Replace("<$$AddAspx$$>", s);
        //    //        sr.Close();
        //    //    }
        //    //    //WriteFile(fileaspx, tempstr);
        //    //}
        //    //if (File.Exists(tempaspxcs))
        //    //{
        //    //    using (StreamReader sr = new StreamReader(tempaspxcs, Encoding.Default))
        //    //    {
        //    //        string s = cb.GetAddAspxCs();
        //    //        tempstr = sr.ReadToEnd().Replace(".Demo", "." + cb.ModelName).Replace("<$$AddAspxCs$$>", s);
        //    //        sr.Close();
        //    //    }
        //    //    WriteFile(fileaspxcs, tempstr);
        //    //}
        //    //if (File.Exists(tempaspxds))
        //    //{
        //    //    using (StreamReader sr = new StreamReader(tempaspxds, Encoding.Default))
        //    //    {
        //    //        string s = cb.GetAddDesigner();
        //    //        tempstr = sr.ReadToEnd().Replace(".Demo", "." + cb.ModelName).Replace("<$$AddDesigner$$>", s);
        //    //        sr.Close();
        //    //    }
        //    //    WriteFile(fileaspxds, tempstr);
        //    //}
        //    ////AddClassFile(webFolder + "\\Web.csproj", cb.ModelName + "\\Add.aspx", "2005");
        //    ////AddClassFile(webFolder + "\\Web.csproj", cb.ModelName + "\\Add.aspx.cs", "2005");
        //    ////AddClassFile(webFolder + "\\Web.csproj", cb.ModelName + "\\Add.aspx.designer.cs", "2005");
        //    //#endregion


        //    //#region Show
        //    //fileaspx = webFolder + "\\" + cb.ModelName + "\\Show.aspx";
        //    //fileaspxcs = webFolder + "\\" + cb.ModelName + "\\Show.aspx.cs";
        //    //fileaspxds = webFolder + "\\" + cb.ModelName + "\\Show.aspx.designer.cs";

        //    //tempaspx = @"\Template\web\Show.aspx";
        //    //tempaspxcs = @"\Template\web\Show.aspx.cs";
        //    //tempaspxds = @"\Template\web\Show.aspx.designer.cs";
        //    //if (File.Exists(tempaspx))
        //    //{
        //    //    using (StreamReader sr = new StreamReader(tempaspx, Encoding.Default))
        //    //    {
        //    //        string s = cb.GetShowAspx();
        //    //        tempstr = sr.ReadToEnd().Replace(".Demo.Show", "." + cb.ModelName + ".Show").Replace("<$$ShowAspx$$>", s);
        //    //        sr.Close();
        //    //    }
        //    //    WriteFile(fileaspx, tempstr);
        //    //}
        //    //if (File.Exists(tempaspxcs))
        //    //{
        //    //    using (StreamReader sr = new StreamReader(tempaspxcs, Encoding.Default))
        //    //    {
        //    //        string s = cb.GetShowAspxCs();
        //    //        tempstr = sr.ReadToEnd().Replace(".Demo", "." + cb.ModelName).Replace("<$$ShowAspxCs$$>", s);
        //    //        sr.Close();
        //    //    }
        //    //    WriteFile(fileaspxcs, tempstr);
        //    //}
        //    //if (File.Exists(tempaspxds))
        //    //{
        //    //    using (StreamReader sr = new StreamReader(tempaspxds, Encoding.Default))
        //    //    {
        //    //        string s = cb.GetShowDesigner();
        //    //        tempstr = sr.ReadToEnd().Replace(".Demo", "." + cb.ModelName).Replace("<$$ShowDesigner$$>", s);
        //    //        sr.Close();
        //    //    }
        //    //    WriteFile(fileaspxds, tempstr);
        //    //}
        //    //#endregion

        //    //#endregion

        //    //CheckDirectory(TargetFolder);
        //}

        #endregion

        #region 公共方法

        private string GetProjectTempPath
        {
            get
            {
                return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "SystemManage\\Controls\\Admin_Modules\\EbSite.ModulesGenerate\\Template\\");

            }


        }

        private string GetVsCsprojFilePath
        {
            get
            {
                return string.Concat(ProOutPath, string.Format("EbSite.Modules.{0}.csproj", _PjInfo.ProjectEnName));
            }
        }
        private string GetWebPath(bool IsAllPath)
        {
            string sp = "Pages";
            if (IsAllPath) sp = string.Concat(ProOutPath, sp);
            return sp;

        }
        private string GetCtrPath(bool IsAllPath)
        {
            string sp = string.Concat("Pages\\Controls\\", cb.ModelName);
            if (IsAllPath) sp = string.Concat(ProOutPath, sp);
            return sp;

        }
        private string GetEntityPath(bool IsAllPath)
        {
            string sp = "ModuleCore\\Entity";
            if (IsAllPath) sp = string.Concat(ProOutPath, sp);
            return sp;

        }
        private string GetBLLPath(bool IsAllPath)
        {
            string sp = "ModuleCore\\BLL";
            if (IsAllPath) sp = string.Concat(ProOutPath, sp);
            return sp;


        }
        private string GetDALPath(bool IsAllPath)
        {

            string strdbtype = dbobj.DbType;
            if (dbobj.DbType == "SQL2000" || dbobj.DbType == "SQL2005")
            {
                strdbtype = "SqlServer";
            }
            else if (dbobj.DbType == "OleDb")
            {
                strdbtype = "Access";
            }

            if (IsAllPath)
            {
                return string.Concat(ProOutPath, "ModuleCore\\DAL\\", strdbtype);
            }
            else
            {
                return string.Concat("ModuleCore\\DAL\\", strdbtype);
            }


        }
        private string GetIDALPath(bool IsAllPath)
        {
            string sp = "ModuleCore\\DALInterface";
            if (IsAllPath) sp = string.Concat(ProOutPath, sp);
            return sp;

        }
        VSManage vsp = new VSManage();
        /// <summary>
        ///  修改项目文件
        /// </summary>
        /// <param name="ProjectFile">项目文件名</param>
        /// <param name="classFileName">类文件名</param>
        /// <param name="ProType">项目类型</param>
        private void AddClassFile(string ProjectFile, string classFileName, string ProType)
        {
            if (File.Exists(ProjectFile))
            {
                switch (ProType)
                {
                    case "2003":
                        vsp.AddClass2003(ProjectFile, classFileName);
                        break;
                    case "2005":
                        vsp.AddClass2005(ProjectFile, classFileName);
                        break;
                    default:
                        vsp.AddClass(ProjectFile, classFileName);
                        break;
                }
            }
        }

        #endregion
    }
}