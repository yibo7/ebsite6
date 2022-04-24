using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;

using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using EbSite.Base.ControlPage;
using System.IO;
using System.Text;
using System.Xml;
using System.Text.RegularExpressions;

//EbSite.Base.DataProfile.DbHelperCms.Instance.ExecuteDataset(sql).Tables[0];
namespace EbSite.Web.AdminHt.Controls.Admin_Data
{
    public partial class DataBaseBack : UserControlListBase
    {
        public int iCount = 0;
        public string RoundNum = string.Empty, filename = string.Empty, tmpfilename = string.Empty, tmpnextfilename = string.Empty, strfilenamearr, strtmpname;


        //private string _path = "";
        public string startcheck = string.Empty;
        public string load = string.Empty;

        //public string path
        //{
        //    get { return _path; }
        //    set{ _path = value;}
        //}

        public string path 
        { 
            get { return (string)ViewState["_path"]; } 
            set { ViewState["_path"] = value; } 
        }
        
        #region 权限

        public override string Permission
        {
            get
            {
                return "286";
            }
        }
        /// <summary>
        /// 删除数据的权限ID
        /// </summary>
        public override string PermissionDelID
        {
            get
            {
                return "286";
            }
        }

        #endregion

        override protected string AddUrl
        {
            get
            {
                return "";
            }
        }
        override protected object LoadList(out int iCount)
        {
            iCount = 0;
            BindData();
            return null;
            //return BLL.AppErrLog.FillLogs();
            
        }


        override protected object SearchList(out int iCount)
        {
            iCount = 0;
            return null;
        }
        override protected void Delete(object iID)
        {
            //Guid id = new Guid(iID.ToString());
            //BLL.AppErrLog.DeleteLogs(BLL.AppErrLog.SelectLogs(id));
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            filename = "backup" + DateTime.Now.ToString("yyMMdd") + "_{RoundNum}_{i}.txt";
            
        }
        
        #region 工具栏的初始化
        override protected void BindToolBar()
        {

            base.BindToolBar();
            ucToolBar.AddLine();
            
            string bakdata = "return confirm('确认要备份数据库吗？');";
            ucToolBar.AddBnt("备份数据库", string.Concat(IISPath, "images/Menus/Search.gif"), "bak", true, bakdata, "备份数据库");

            //string deldata = "return confirm('确认要恢复数据库吗？');";
            //ucToolBar.AddBnt("数据库恢复", string.Concat(IISPath, "images/Menus/Search.gif"), "del", true, "", "数据库恢复");

            string restore = "return confirm('确认要修复数据库吗？');";
            ucToolBar.AddBnt("修复数据库", string.Concat(IISPath, "images/Menus/Search.gif"), "res", true, restore, "修复数据库");
        }
        #endregion

        #region 工具栏事件扩展
        protected override void ucToolBar_ItemClick(object source, Control.ItemClickArgs e)
        {
            base.ucToolBar_ItemClick(source, e);
            switch (e.ItemTag)
            {
                case "bak":
                    //备份数据库
                    StartBack();
                    break;
                case "del":
                    //恢复数据库
                    LoadBasicData();
                    BindData();
                    break;
                case "res":
                    //修复数据库
                    RepairData();
                    break;
            }
        }
        #endregion

        //==================恢复数据库====================
        #region 恢复数据库
        private void LoadBasicData()
        {
            load = AccessLoad();
            if (load == "Access")  //判断节点是否为Access()
            {
                //path = Server.MapPath(@"db/");
                path = Server.MapPath(@"../db/dbbak/access/");
            }
            else
            {
                path = Server.MapPath(@"../db/dbbak/sqlserver/");
            }

            //开始统计数据-全部
            if (Request.QueryString["ChcekBakFile"] == "true")
            {
                Response.Write(ChcekBakFile(0, Request.QueryString["filename1"]));
                Response.End();
            }

            //开始统计数据-全部
            if (Request.QueryString["RestoreData"] == "true")
            {
                Response.Write(RestoreData());
                Response.End();
            }
        }

        private string ChcekBakFile(int iCount, string filename1)
        {
            DirectoryInfo dir = new DirectoryInfo(path);
            if (dir.Exists)
            {
                if (File.Exists(path + "/" + filename1))
                {
                    string[] strFline = File.ReadAllLines(path + "/" + filename1);
                    if (strFline.Length > 0)
                    {
                        if (strFline[0].ToString().Trim() == "--@End BackUp Data")
                            return iCount.ToString();
                        else
                        {
                            string strfilename;
                            if (iCount == 0)
                                strfilename = strFline[1].Replace("--@", "");
                            else
                                strfilename = strFline[0].Replace("--@", "");
                            iCount = iCount + 1;
                            return ChcekBakFile(iCount, strfilename);
                        }
                    }
                }
                else
                {
                    iCount = 0;
                    return "0";
                }
            }
            return iCount.ToString();
        }

        private string RestoreData()
        {
            string filename = Request.QueryString["filename1"];
            DirectoryInfo dir = new DirectoryInfo(path);
            string strResult = "";
            if (dir.Exists)
            {
                if (File.Exists(path + "/" + filename))
                {
                    string[] strFline = File.ReadAllLines(path + "/" + filename);
                    if (strFline.Length > 0)
                    {
                        string strLen = string.Empty;
                        if (load == "Access")
                        {
                            strLen = (int.Parse(filename.ToLower().Replace(".config", "").Split('_')[2].ToString()) + 1).ToString();
                        }
                        else
                        {
                            strLen = (int.Parse(filename.ToLower().Replace(".txt", "").Split('_')[2].ToString()) + 1).ToString();
                        }
                        if (strFline[0].ToString().Trim() == "--@End BackUp Data")
                        {
                            strResult = "$End$" + strLen;
                        }
                        else
                        {
                            strResult = "$" + strFline[0].Replace("--@", "").Trim() + "$" + strLen;
                            if (strFline[0].ToString().Trim() == "--@Begin BackUp Data")
                            {
                                strResult = "$" + strFline[1].Replace("--@", "").Trim() + "$" + strLen;
                            }
                        }
                        strResult = CreateDateBase(path + "/" + filename) + strResult;
                    }
                }
            }
            return strResult;
        }

        private string CreateDateBase(string sqlpath)
        {
            //读取需要执行的SQL卷
            string SqlPath = sqlpath;
            string SqlContent = File.ReadAllText(SqlPath);
            //按行分组一条一条执行
            string[] SqlArray = Regex.Split(SqlContent, @"\r \n");
            string strExecute = string.Empty;
            
            for (int i = 0; i < SqlArray.Length; i++)
            {
                //执行SQL语句
                strExecute += EbSite.Base.DataProfile.DbHelperCms.Instance.ExecuteNonQuery(SqlArray[i]);
            }
            return strExecute;
        }

        private void BindData()
        {
            LoadBasicData();
            DirectoryInfo dir = new DirectoryInfo(path);
            if (dir.Exists)
            {
                string[] filenames = Directory.GetFiles(path);

                DataTable dt = new DataTable();
                DataColumn column;
                DataRow dr;

                column = new DataColumn("Name", System.Type.GetType("System.String"));
                dt.Columns.Add(column);
                column = new DataColumn("ID", System.Type.GetType("System.String"));
                dt.Columns.Add(column);
                column = new DataColumn("Notice", System.Type.GetType("System.String"));
                dt.Columns.Add(column);
                column = new DataColumn("Date", System.Type.GetType("System.String"));
                dt.Columns.Add(column);
                column = new DataColumn("Size", System.Type.GetType("System.String"));
                dt.Columns.Add(column);


                foreach (string file in filenames)     //查找子目录   
                {
                    dr = dt.NewRow();
                    System.IO.FileInfo objInfo = new System.IO.FileInfo(file);
                    dr["ID"] = Path.GetFileName(file);
                    dr["Name"] = Path.GetFileName(file);
                    string strFline = File.ReadAllLines(Path.GetFullPath(file))[0].ToString().Trim();
                    if (strFline == "--@Begin BackUp Data")
                        dr["Notice"] = "卷头";
                    else if (strFline == "--@End BackUp Data")
                        dr["Notice"] = "卷尾";
                    else
                        if (load == "Access")
                        {
                            dr["Notice"] = "分卷" + Path.GetFileName(file).Replace(".config", "").Split('_')[2].ToString();
                            dr["Date"] = objInfo.CreationTime;
                        }
                        else
                        {
                            dr["Notice"] = "分卷" + Path.GetFileName(file).Replace(".txt", "").Split('_')[2].ToString();
                            dr["Date"] = objInfo.LastWriteTime;
                        }

                    dr["Size"] = objInfo.Length / 1024;
                    dt.Rows.Add(dr);
                }

                DataView dv = dt.DefaultView;
                dv.Sort = "Name , Date DESC";

                //this.gdList.DataSource = dv;
                this.gdList1.DataSource = dv;
                this.gdList1.DataBind();
            }
        }
        #endregion
        //============================================

        //==================备份数据库====================
        #region 备份数据库

        private void StartBack()
        {
            string load = string.Empty;
            load = this.AccessLoad();
            if (load == "Access")
            {
                string filepath = Server.MapPath(@"../db/dbbak/access/");
                bool exist = System.IO.Directory.Exists(filepath);
                if (!exist)
                {
                    System.IO.Directory.CreateDirectory(filepath);
                }
                AccessBaseCopy();
            }
            else
            {
                //this.lblResult.Text = "";
                strtmpname = filename.Replace("{RoundNum}", GetRandNum((int)(DateTime.Now.Second)).ToString());
                backup();
                Notes1.Visible = true;
                //this.lblResult.Visible = true;
                //this.lblResult.Text = this.lblBakText2.Text;
                //string[] strArr = strfilenamearr.Split(',');
                //for (int i = 0; i < strArr.Length; i++)
                //{
                //    this.lblResult.Text = this.lblResult.Text + this.lblBakText.Text.Trim() + i + "：<a href=../databak_fa1fb2/" + strArr[i] + " targe=_blank>" + strArr[i] + "</a><br/>";
                //}
            }
            //链接
            BindData();
        }
        private string GetRandNum(int seed)
        {
            int number;
            char code;
            string checkCode = String.Empty;

            System.Random random = new System.Random((int)(DateTime.Now.Ticks));

            for (int i = 0; i < 9; i++)
            {
                number = random.Next();

                if (number % 2 == 0)
                    code = (char)('0' + (char)((number - seed) % 10));
                else
                    code = (char)('A' + (char)((number - seed) % 26));

                checkCode += code.ToString().ToLower();
            }

            return checkCode;
        }
        
        private string getSqlVersion()
        {
            DataTable dt = EbSite.Base.DataProfile.DbHelperCms.Instance.ExecuteDataset("select @@Version as ver").Tables[0];
            if (dt.Rows.Count > 0)
            {
                return dt.Rows[0]["ver"].ToString();
            }
            else { return ""; }
        }

        private DataTable GetAllTable()
        {
            string sql;
            if (getSqlVersion().IndexOf("2005") != -1)
            { sql = "SELECT name FROM sysobjects WHERE (type = 'U') AND name <> 'sysdiagrams'"; }
            else
            { sql = "select name from sysobjects where xtype='u' and status>=0"; }

            return EbSite.Base.DataProfile.DbHelperCms.Instance.ExecuteDataset(sql).Tables[0];
        }

        private DataTable GetFieldByTableName(string tablename)
        {
            string sql;
            if (getSqlVersion().IndexOf("2005") != -1)
            {
                sql = "SELECT     col.name, col.column_id, st.name AS type, col.max_length AS length, col.is_nullable,col.[precision], col.scale, col.is_identity, defCst.definition";
                sql += " FROM         sys.columns AS col LEFT OUTER JOIN";
                sql += " sys.types AS st ON st.user_type_id = col.user_type_id LEFT OUTER JOIN";
                sql += " sys.types AS bt ON bt.user_type_id = col.system_type_id LEFT OUTER JOIN";
                sql += " sys.objects AS robj ON robj.object_id = col.rule_object_id AND robj.type = 'R' LEFT OUTER JOIN";
                sql += " sys.objects AS dobj ON dobj.object_id = col.default_object_id AND dobj.type = 'D' LEFT OUTER JOIN";
                sql += " sys.default_constraints AS defCst ON defCst.parent_object_id = col.object_id AND defCst.parent_column_id = col.column_id LEFT OUTER JOIN";
                sql += " sys.identity_columns AS idc ON idc.object_id = col.object_id AND idc.column_id = col.column_id LEFT OUTER JOIN";
                sql += " sys.computed_columns AS cmc ON cmc.object_id = col.object_id AND cmc.column_id = col.column_id LEFT OUTER JOIN";
                sql += " sys.fulltext_index_columns AS ftc ON ftc.object_id = col.object_id AND ftc.column_id = col.column_id LEFT OUTER JOIN";
                sql += " sys.xml_schema_collections AS xmlcoll ON xmlcoll.xml_collection_id = col.xml_collection_id";
                sql += " WHERE     (col.object_id = OBJECT_ID(N'dbo." + tablename + "'))";
                sql += " ORDER BY col.column_id";
            }
            else
            {
                sql = "SELECT a.name,a.colorder,b.name as type,a.length,a.isnullable as is_nullable,COLUMNPROPERTY(a.id,a.name,'PRECISION') as [precision],COLUMNPROPERTY(a.id,a.name,'Scale') as scale,COLUMNPROPERTY(   a.id,a.name,'IsIdentity') as is_identity,e.text as definition  ";
                sql += "FROM   syscolumns   a   ";
                sql += "left   join   systypes   b   on   a.xtype=b.xusertype   ";
                sql += "inner   join   sysobjects   d   on   a.id=d.id     and   d.xtype='U'   and     d.name<>'dtproperties'   ";
                sql += "left   join   syscomments   e   on   a.cdefault=e.id   ";
                //sql += "left   join   sysproperties   g   on   a.id=g.id   and   a.colid=g.smallid       ";
                //sql += "left   join   sysproperties   f   on   d.id=f.id   and   f.smallid=0   ";
                sql += "where   d.name='" + tablename + "' ";
                sql += "order by a.colorder";
            }

            return EbSite.Base.DataProfile.DbHelperCms.Instance.ExecuteDataset(sql).Tables[0];
        }

        private DataTable GetAllDataByTableName(string tablename)
        {
            string sql = "SELECT * FROM " + tablename;

            return EbSite.Base.DataProfile.DbHelperCms.Instance.ExecuteDataset(sql).Tables[0];
        }

        public void backup()
        {
            StringBuilder sql = new StringBuilder();
            StringBuilder tmpsql = new StringBuilder();
            StringBuilder tmpfield = new StringBuilder();
            StringBuilder defaultsql = new StringBuilder();
            StringBuilder tmpdefaultsql = new StringBuilder();
            StringBuilder modifysql = new StringBuilder();

            bool is_identity = false;

            DataTable dt = null;
            DataTable dt1 = null;
            DataTable dt2 = null;

            int i = 0;
            int j = 0;
            int maxcount = 0;

            dt = GetAllTable();

            foreach (DataRow dr in dt.Rows)
            {
                is_identity = false;
                tmpsql.Remove(0, tmpsql.Length);
                tmpfield.Remove(0, tmpfield.Length);
                defaultsql.Remove(0, defaultsql.Length);
                tmpdefaultsql.Remove(0, tmpdefaultsql.Length);

                //如果表存在的话先删除旧表，然后创建新表
                
                sql.Append("IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[dbo].[" + dr["name"].ToString() + "]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1) DROP TABLE [dbo].[" + dr["name"].ToString() + "] \r \n");
                //获取表名及数据总数
                dt1 = GetFieldByTableName(dr["name"].ToString());
                maxcount = dt1.Rows.Count;
                i = 0;
                //构造创建新表的语句
                sql.Append("CREATE TABLE dbo." + dr["name"].ToString() + "(");
                //为修改自增量建立临时表

                tmpsql.Append("CREATE TABLE dbo.Tmp_" + dr["name"].ToString() + "(");
                foreach (DataRow dr1 in dt1.Rows)
                {
                    if (dr1["type"].ToString() == "nvarchar" || dr1["type"].ToString() == "nchar")
                    {
                        if (int.Parse(dr1["length"].ToString()) == -1)
                        {
                            sql.Append("[" + dr1["name"] + "] [" + dr1["type"] + "] (MAX) ");
                            tmpsql.Append("[" + dr1["name"] + "] [" + dr1["type"] + "] (MAX) ");
                        }
                        else
                        {
                            sql.Append("[" + dr1["name"] + "] [" + dr1["type"] + "] (" + int.Parse(dr1["length"].ToString()) / 2 + ") ");
                            tmpsql.Append("[" + dr1["name"] + "] [" + dr1["type"] + "] (" + int.Parse(dr1["length"].ToString()) / 2 + ") ");
                        }
                    }
                    else
                    {
                        if (dr1["type"].ToString() == "varchar" || dr1["type"].ToString() == "char")
                        {
                            sql.Append("[" + dr1["name"] + "] [" + dr1["type"] + "] (" + dr1["length"] + ")");
                            tmpsql.Append("[" + dr1["name"] + "] [" + dr1["type"] + "] (" + dr1["length"] + ")");
                        }
                        else
                        {
                            sql.Append("[" + dr1["name"] + "] [" + dr1["type"] + "] ");
                            tmpsql.Append("[" + dr1["name"] + "] [" + dr1["type"] + "] ");
                        }
                    }

                    tmpfield.Append("[" + dr1["name"] + "]");

                    //判断是否为DECIMAL型
                    if (dr1["type"].ToString() == "decimal")
                    {
                        sql.Append(" (" + dr1["precision"].ToString() + "," + dr1["scale"].ToString() + ")");
                        tmpsql.Append(" (" + dr1["precision"].ToString() + "," + dr1["scale"].ToString() + ")");
                    }

                    //判断是否为空
                    if (Convert.ToBoolean(dr1["is_nullable"]))
                    {
                        sql.Append(" NULL");
                        tmpsql.Append(" NULL");
                    }
                    else
                    {
                        sql.Append(" NOT NULL");
                        tmpsql.Append(" NOT NULL");
                    }

                    //判断是否为自增量
                    if (Convert.ToBoolean(dr1["is_identity"]))
                    {
                        is_identity = true;
                        
                        tmpsql.Append(" IDENTITY (1, 1)");
                    }

                    i++;

                    if (i != maxcount)
                    {
                        sql.Append(",");
                        tmpsql.Append(",");
                        tmpfield.Append(",");
                    }

                    if (dr1["definition"] != DBNull.Value)
                    {
                        defaultsql.Append("ALTER TABLE dbo." + dr["name"].ToString() + " ADD CONSTRAINT DF_" + dr["name"].ToString() + "_" + dr1["name"] + " DEFAULT " + dr1["definition"].ToString() + " FOR [" + dr1["name"] + "]\r \n");
                        tmpdefaultsql.Append("ALTER TABLE dbo.Tmp_" + dr["name"].ToString() + " ADD CONSTRAINT DF_Tmp_" + dr["name"].ToString() + "_" + dr1["name"] + " DEFAULT " + dr1["definition"].ToString() + " FOR [" + dr1["name"] + "]\r \n");
                        
                    }

                }
                sql.Append(")  ON [PRIMARY] \r \n");
                tmpsql.Append(")  ON [PRIMARY] \r \n");

                //建立默认值
                sql.Append(defaultsql.ToString());
                //插入数据的语句
                dt2 = GetAllDataByTableName(dr["name"].ToString());

                maxcount = dt1.Rows.Count;
                foreach (DataRow dr2 in dt2.Rows)
                {
                    //mh更改
                    //if (is_identity)
                    //{
                    //    sql.Append("SET IDENTITY_INSERT dbo." + dr["name"].ToString() + " ON\r \n");
                    //}

                    sql.Append("INSERT INTO " + dr["name"].ToString());
                    
                    //mh新增
                    sql.Append(" (" + tmpfield.ToString() + ")");

                    
                    sql.Append(" VALUES (");
                    j = 0;
                    foreach (DataRow dr1 in dt1.Rows)
                    {
                        j++;
                        if (j != maxcount)
                        {
                            if (dr2[dr1["name"].ToString()] == DBNull.Value)
                            {
                                sql.Append("NULL,");
                            }
                            else
                            {
                                sql.Append("'" + dr2[dr1["name"].ToString()].ToString().Replace("'", "''") + "',");
                            }
                        }
                        else
                        {
                            if (dr2[dr1["name"].ToString()] == DBNull.Value)
                            {
                                sql.Append("NULL");
                            }
                            else
                            {
                                sql.Append("'" + dr2[dr1["name"].ToString()].ToString().Replace("'", "''") + "'");
                            }
                        }
                    }
                    sql.Append(")\r \n");
//                    if (sql.Length > 200000)
                    if (sql.Length > 100000)
                    {
                        string strname = tmpfilename;
                        string strname2 = tmpnextfilename;
                        tmpfilename = strtmpname.Replace("{i}", (iCount).ToString());
                        tmpnextfilename = strtmpname.Replace("{i}", (iCount + 1).ToString());

                        if (iCount == 0)
                        {
                            string strcontent = "--@" + tmpnextfilename + "\n" + sql.ToString();
                            strcontent = "--@Begin BackUp Data" + "\n" + strcontent;
                            File.WriteAllText(HttpContext.Current.Server.MapPath("../db/dbbak/sqlserver/" + tmpfilename), strcontent);
                            sql = new StringBuilder();
                            strfilenamearr = tmpfilename + "," + tmpnextfilename;
                        }
                        else
                        {
                            strfilenamearr = strfilenamearr + "," + tmpnextfilename;
                            string strcontent = "--@" + tmpnextfilename + "\n" + sql.ToString();
                            File.WriteAllText(HttpContext.Current.Server.MapPath("../db/dbbak/sqlserver/" + strname2), strcontent);
                            sql = new StringBuilder();
                        }
                        iCount = iCount + 1;
                    }
                }

                //建立自增量
                if (is_identity)
                {
                    sql.Append(tmpsql.ToString());
                    sql.Append(tmpdefaultsql.ToString());
                    sql.Append("SET IDENTITY_INSERT dbo.Tmp_" + dr["name"].ToString() + " ON\r \n");
                    sql.Append("IF EXISTS(SELECT * FROM dbo." + dr["name"].ToString() + ") EXEC('INSERT INTO dbo.Tmp_" + dr["name"].ToString() + " (" + tmpfield.ToString() + ") SELECT " + tmpfield.ToString() + " FROM dbo." + dr["name"].ToString() + " WITH (HOLDLOCK TABLOCKX)')\r \n");
                    sql.Append("SET IDENTITY_INSERT dbo.Tmp_" + dr["name"].ToString() + " OFF\r \n");
                    sql.Append("DROP TABLE dbo." + dr["name"].ToString() + "\r \n");
                    sql.Append("EXECUTE sp_rename N'dbo.Tmp_" + dr["name"].ToString() + "', N'" + dr["name"].ToString() + "', 'OBJECT' \r \n");
                }

                sql.Append("\r \n\r \n");
            }
            string strcontent2 = "--@End BackUp Data" + "\n" + sql.ToString();
            File.WriteAllText(HttpContext.Current.Server.MapPath("../db/dbbak/sqlserver/" + tmpnextfilename), strcontent2);
            //File.WriteAllText(HttpContext.Current.Server.MapPath("db" + tmpnextfilename), strcontent2);
            //File.WriteAllText(HttpContext.Current.Server.MapPath(@"c:\temp\a.txt" + tmpnextfilename), strcontent2);
            sql = null;
            tmpsql = null;
            tmpfield = null;
            defaultsql = null;
            tmpdefaultsql = null;

            GC.Collect();
            //BindData();
            return;
        }

        private string AccessLoad()
        {
            string xmlname = Server.MapPath("../Base.config");
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(xmlname);
            XmlNode root = null;
            root = xmlDoc.SelectSingleNode("ConfigsInfo/DataLayerType");
            string rot = root.InnerText;
            return rot;
        }

        private void AccessBaseCopy()
        {
            //获取四位随即数
            Random ran = new Random();
            int num = ran.Next(1000, 9999);
            //生成背份数据库的名称
            string fileName = "Access_" + DateTime.Now.ToString("yyyyMMdd") + "_" + num + ".config";
            //需要背份数据库的文件
            string oldFile = Server.MapPath("../db/EbSite.config");/////////////////////////////////////////////////////////////////////
            //将背份名称存入
            string newFile = Server.MapPath("../db/dbbak/access/") + fileName;

            File.Copy(oldFile, newFile, true);
        }
        #endregion
        //============================================

        //==================修复数据库====================
        #region 修复数据库
        /// <summary>
        /// 数据修复压缩方法
        /// </summary>
        public void CompactAccessDB()
        {
            string connectionString, databasePath, tempPath = string.Empty;
            databasePath = Server.MapPath("../refixdb/xxx.config");
            tempPath = Server.MapPath("../refixdb/xxx.db");
            connectionString = @"Provider = Microsoft.Jet.OLEDB.4.0 ; Data Source = " + databasePath;
            object[] oParams;

            //create an inctance of a Jet Replication Object
            object objJRO =
            Activator.CreateInstance(Type.GetTypeFromProgID("JRO.JetEngine"));

            oParams = new object[] { connectionString, "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + tempPath + ";Jet OLEDB:Engine Type=5" };

            objJRO.GetType().InvokeMember("CompactDatabase", System.Reflection.BindingFlags.InvokeMethod, null, objJRO, oParams);

            System.IO.File.Delete(databasePath);
            System.IO.File.Move(tempPath, databasePath);
            
            System.Runtime.InteropServices.Marshal.ReleaseComObject(objJRO);
            objJRO = null;
        }

        /// <summary>
        /// 为表增加自增量
        /// </summary>
        /// <param name="name">表名</param>
        /// <param name="column">自增量字段名</param>
        private void AddIdentity(string name, string column)
        {
            StringBuilder sql = new StringBuilder();
            StringBuilder tmpsql = new StringBuilder();
            StringBuilder tmpfield = new StringBuilder();
            StringBuilder defaultsql = new StringBuilder();
            StringBuilder tmpdefaultsql = new StringBuilder();
            StringBuilder modifysql = new StringBuilder();

            bool is_identity = false;

            DataTable dt = null;
            DataTable dt1 = null;
            DataTable dt2 = null;

            int i = 0;
            int j = 0;
            int maxcount = 0;

            is_identity = false;
            tmpsql.Remove(0, tmpsql.Length);
            tmpfield.Remove(0, tmpfield.Length);
            defaultsql.Remove(0, defaultsql.Length);
            tmpdefaultsql.Remove(0, tmpdefaultsql.Length);

            tmpsql.Append("IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[dbo].[Tmp_" + name + "]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1) DROP TABLE [dbo].[Tmp_" + name + "] \r \n");
            //获取表名及数据总数
            dt1 = GetFieldByTableName(name);
            maxcount = dt1.Rows.Count;
            i = 0;
            //构造创建新表的语句
            sql.Append("CREATE TABLE dbo." + name + "(");
            //为修改自增量建立临时表
            tmpsql.Append("CREATE TABLE dbo.Tmp_" + name + "(");
            foreach (DataRow dr1 in dt1.Rows)
            {
                //if (dr1["type"].ToString() == "int" || dr1["type"].ToString() == "datetime" || dr1["type"].ToString() == "bit" || dr1["type"].ToString() == "ntext" || dr1["type"].ToString() == "float" || dr1["type"].ToString() == "uniqueidentifier" || dr1["type"].ToString() == "real" || dr1["type"].ToString() == "text")
                if (dr1["type"].ToString() != "char" && dr1["type"].ToString() != "varchar" && dr1["type"].ToString() != "nvarchar" && dr1["type"].ToString() != "nchar")
                {
                    sql.Append("[" + dr1["name"] + "] [" + dr1["type"] + "]");
                    tmpsql.Append("[" + dr1["name"] + "] [" + dr1["type"] + "]");
                }
                else
                {
                    //HttpContext.Current.Response.Write(dr1["length"].ToString() + "<br>");

                    if (int.Parse(dr1["length"].ToString()) == -1)
                    {
                        sql.Append("[" + dr1["name"] + "] [" + dr1["type"] + "] (MAX) ");
                        tmpsql.Append("[" + dr1["name"] + "] [" + dr1["type"] + "] (MAX) ");
                    }
                    else
                    {
                        sql.Append("[" + dr1["name"] + "] [" + dr1["type"] + "] (" + int.Parse(dr1["length"].ToString()) / 2 + ") ");
                        tmpsql.Append("[" + dr1["name"] + "] [" + dr1["type"] + "] (" + int.Parse(dr1["length"].ToString()) / 2 + ") ");
                    }
                }

                tmpfield.Append("[" + dr1["name"] + "]");

                //判断是否为DECIMAL型
                if (dr1["type"].ToString() == "decimal")
                {
                    sql.Append(" (" + dr1["precision"].ToString() + "," + dr1["scale"].ToString() + ")");
                    tmpsql.Append(" (" + dr1["precision"].ToString() + "," + dr1["scale"].ToString() + ")");
                }

                //判断是否为空
                if (dr1["is_nullable"].ToString() == "True")
                {
                    sql.Append(" NULL");
                    tmpsql.Append(" NULL");
                }
                else
                {
                    sql.Append(" NOT NULL");
                    tmpsql.Append(" NOT NULL");
                }

                //判断是否为自增量
                if (dr1["is_identity"].ToString() == "True" || dr1["name"].ToString() == column)
                {
                    is_identity = true;
                    //sql += " IDENTITY (1, 1)";
                    tmpsql.Append(" IDENTITY (1, 1)");
                }

                i++;

                if (i != maxcount)
                {
                    sql.Append(",");
                    tmpsql.Append(",");
                    tmpfield.Append(",");
                }

                if (dr1["definition"] != DBNull.Value)
                {
                    defaultsql.Append("ALTER TABLE dbo." + name + " ADD CONSTRAINT DF_" + name + "_" + dr1["name"] + " DEFAULT " + dr1["definition"].ToString() + " FOR [" + dr1["name"] + "]\r \n");
                    tmpdefaultsql.Append("ALTER TABLE dbo.Tmp_" + name + " ADD CONSTRAINT DF_Tmp_" + name + "_" + dr1["name"] + " DEFAULT " + dr1["definition"].ToString() + " FOR [" + dr1["name"] + "]\r \n");
                }
            }

            sql.Append(")  ON [PRIMARY] \r \n");
            tmpsql.Append(")  ON [PRIMARY] \r \n");

            //建立默认值
            sql.Append(defaultsql.ToString());
            //插入数据的语句
            dt2 = GetAllDataByTableName(name);

            maxcount = dt1.Rows.Count;
            foreach (DataRow dr2 in dt2.Rows)
            {
                sql.Append("INSERT INTO " + name);
                sql.Append(" VALUES (");
                j = 0;
                foreach (DataRow dr1 in dt1.Rows)
                {
                    j++;
                    if (j != maxcount)
                    {
                        if (dr2[dr1["name"].ToString()] == DBNull.Value)
                        {
                            sql.Append("NULL,");
                        }
                        else
                        {
                            sql.Append("'" + dr2[dr1["name"].ToString()].ToString().Replace("'", "''") + "',");
                        }
                    }
                    else
                    {
                        if (dr2[dr1["name"].ToString()] == DBNull.Value)
                        {
                            sql.Append("NULL");
                        }
                        else
                        {
                            sql.Append("'" + dr2[dr1["name"].ToString()].ToString().Replace("'", "''") + "'");
                        }
                    }
                }
                sql.Append(")\r \n");
            }

            //建立自增量
            //if (is_identity)
            //{
            sql.Append(tmpsql.ToString());
            sql.Append(tmpdefaultsql.ToString());
            tmpsql.Append("SET IDENTITY_INSERT dbo.Tmp_" + name + " ON ");
            tmpsql.Append("IF EXISTS(SELECT * FROM dbo." + name + ") EXEC('INSERT INTO dbo.Tmp_" + name + " (" + tmpfield.ToString() + ") SELECT " + tmpfield.ToString() + " FROM dbo." + name + " WITH (HOLDLOCK TABLOCKX)')\r \n");
            tmpsql.Append("SET IDENTITY_INSERT dbo.Tmp_" + name + " OFF\r \n");
            tmpsql.Append("DROP TABLE dbo." + name + "\r \n");
            tmpsql.Append("EXECUTE sp_rename N'dbo.Tmp_" + name + "', N'" + name + "', 'OBJECT'");
            //}

            sql.Append("\r \n\r \n");

            //Response.Write("修复了" + name + "表的自增量问题<br>");

            string[] SqlArray = Regex.Split(tmpsql.ToString(), @"\r \n");
            for (int k = 0; k < SqlArray.Length; k++)
            {
                EbSite.Base.DataProfile.DbHelperCms.Instance.ExecuteNonQuery(SqlArray[k]);
                //DbHelper.ExecuteNonQuery(SqlArray[k]);
            }
        }

        /// <summary>
        /// 为表增加主键
        /// </summary>
        /// <param name="name">表名</param>
        /// <param name="column">自增量字段名</param>
        private void AddTablePK(string name, string column)
        {
            string sql = string.Empty;

            sql = "ALTER TABLE " + name + " ADD CONSTRAINT PK_" + name + " PRIMARY KEY (" + column + ")";
            EbSite.Base.DataProfile.DbHelperCms.Instance.ExecuteNonQuery(sql);
        }

        private void RepairData()
        {
            //如果是ACCESS数据库修复
            if (AccessLoad() == "Access")
            {
                //////////////////////////////////////////////////没有 access
                //CompactAccessDB();
                //this.lblRepair.Text = "数据库修复成功！";
                return;
            }

            string sql, identity, name, column, xmlname, length = string.Empty;
            int repairCount = 0;
            XmlNode root;

            XmlDocument xmlDoc = new XmlDocument();
            xmlname = Server.MapPath("../refixdb/RepairList.config");
            xmlDoc.Load(xmlname);
            //如果文件不存在直接返回
            if (xmlDoc == null)
            {
                return;
            }
            //判断下列表是否有自增量
            root = xmlDoc.SelectSingleNode("EbSite2.0/Primary");
            foreach (XmlNode rootChild in root.ChildNodes)
            {
                if (rootChild.Attributes["Name"] != null && rootChild.Attributes["Column"] != null)
                {
                    name = rootChild.Attributes["Name"].Value;
                    column = rootChild.Attributes["Column"].Value;

                    if (getSqlVersion().IndexOf("2005") != -1)
                    {
                        sql = "  SELECT     COUNT(*) ";
                        sql += " FROM       sys.columns ";
                        sql += " WHERE      object_id = object_id('" + name + "') AND name = '" + column + "' AND is_identity = 1";
                    }
                    else
                    {
                        sql = "select count(*) from syscolumns where id=object_id(N'" + name + "') and status=0x80 and name='" + column + "'";
                    }
                    identity = EbSite.Base.DataProfile.DbHelperCms.Instance.ExecuteScalar(CommandType.Text,sql).ToString();
                    //identity = DbHelper.ExecuteString(sql);

                    //如果没有自增量
                    if (identity == "0")
                    {
                        //用SQL语句增加自增量
                        AddIdentity(name, column);
                        repairCount++;
                    }
                }
            }

            //判断下列表的字段是否有主键
            root = xmlDoc.SelectSingleNode("EbSite2.0/Key");
            foreach (XmlNode rootChild in root.ChildNodes)
            {
                if (rootChild.Attributes["Name"] != null && rootChild.Attributes["Column"] != null)
                {
                    name = rootChild.Attributes["Name"].Value;
                    column = rootChild.Attributes["Column"].Value;
                    if (getSqlVersion().IndexOf("2005") != -1)
                    { sql = " SELECT COUNT(*) FROM sys.all_objects WHERE type='pk' AND [name] = N'PK_" + name + "'"; }
                    else
                    { sql = "select count(*) from sysobjects where xtype='PK' and parent_obj=object_id(N'" + name + "')"; }

                    identity = EbSite.Base.DataProfile.DbHelperCms.Instance.ExecuteScalar(CommandType.Text, sql).ToString();

                    //如果没有自增量
                    if (identity == "0")
                    {
                        //用SQL语句增加主键
                        AddTablePK(name, column);
                        repairCount++;
                    }
                }
            }

            string message = "修复成功";
            Notes2.Visible = true;
            
            //if (repairCount != 0)
            //{
            //    //this.lblRepair.Text = "数据库修复成功，共修复了" + repairCount + "个错误！";
            //    string message = "修复成功";
            //}
            //else
            //{
            //    //this.lblRepair.Text = "数据库修复成功，没有检查到错误！";
            //}
        }
        #endregion
        //============================================
        private void GetCheckID()
        {
            foreach (GridViewRow row in gdList1.Rows)
            {
                CheckBox cb = (CheckBox)row.FindControl("Selector");//循环找到单选框控件
                if (cb.Checked)//判断是否选择
                {
                    string theid = row.Cells[1].Text;
                    CheckedIDS += theid + ",";
                }
            }
            if(CheckedIDS.Length >0)
            {
                CheckedIDS = CheckedIDS.Substring(0, CheckedIDS.Length - 1);
            }
        }

        private string CheckedIDS = "";

        protected void restoreButton_Click(object sender, EventArgs e)
        {
            GetCheckID();
            string[] strFline = null;

            if(string.IsNullOrEmpty( CheckedIDS))
            {
                base.TipsAlert("请选择一项要恢复的数据");
                return;
            }
            string[] st = CheckedIDS.Split(',');
            if (st.Length > 1 || st.Length <= 0)
            {
                base.TipsAlert("请选择一项要恢复的数据");
                return;
            }
            string fileid = this.CheckedIDS;

            load = AccessLoad();

            if (load == "Access")
            {
                strFline = File.ReadAllLines(Server.MapPath("../db/dbbak/access/" + fileid));
            }
            else
            {
                strFline = File.ReadAllLines(Server.MapPath("../db/dbbak/sqlserver/" + fileid));
            }
            if (strFline.Length > 0)
            {
                if (load == "Access")
                {
                    //当节点为ACCESS时将backup中选择的覆盖DB.mdb
                    string oldFile = Server.MapPath("../db/EbSite.config");
                    string newFile = Server.MapPath("../db/dbbak/access/" + fileid);
                    File.Copy(newFile, oldFile, true);
                    //成功
                    //utils.ShowSuccess(new string[2] {
                    //Resources.Resource.ReturnList, "Data_DataBase_Restore.aspx" }
                    //);
                    base.TipsAlert("Access数据库成功恢复");
                }
                else
                {
                    if (strFline[0] == "--@Begin BackUp Data")
                    {
                        #region 不用
                        //this.filename1.Value = fileid;
                        //this.ShowRestore.Visible = true;
                        //this.gdList.Visible = false;
                        ////this.search.Visible = false;
                        //startcheck = "CheckBakFile()";
                        #endregion

                        //用C#代码去一个一个的执行
                        string firstStr = fileid;
                        firstStr = firstStr.Substring(0, firstStr.Length - 4);
                        string[] firstArray = firstStr.Split('_');

                        //根据路径查找所有的文件
                        DirectoryInfo dir = new DirectoryInfo(path);

                        List<string> array=new List<string>();
                        
                        if (dir.Exists)
                        {
                            string[] filenames = Directory.GetFiles(path);

                            foreach (string file in filenames)     //查找子目录   
                            {
                                string[] items = file.Substring(0, file.Length - 4).Split('_');
                                if(items[1] == firstArray[1])
                                {
                                    string temp = Path.GetFileName(file);
                                    array.Add(temp);
                                }
                            }

                            string [] sameS = new string[array.Count];
                            int i1 = 0;
                            foreach (var item in array)
                            {
                                sameS[i1] = item;
                                i1++;
                            }

                            for (int i = 0; i < sameS.Length; i++)
                            {
                                for (int j = i; j < sameS.Length; j++)
                                {
                                    string stI = sameS[i];
                                    string stJ = sameS[j];
                                    int stLastI = int.Parse(stI.Substring(0, stI.Length - 4).Split('_')[2]);
                                    int stLastJ = int.Parse(stJ.Substring(0, stJ.Length - 4).Split('_')[2]);

                                    if(stLastI>stLastJ)
                                    {
                                        string temp = sameS[i];
                                        sameS[i] = sameS[j];
                                        sameS[j] = temp;
                                    }
                                }
                            }

                            //判断一下最后一个文件是不是结束文件
                            string[] lastfile = File.ReadAllLines(Server.MapPath("../db/dbbak/sqlserver/" + sameS[sameS.Length-1]));
                            if (lastfile[0] == "--@End BackUp Data")
                            {
                                bool isSuccess = ExecuteStoreForSql(sameS);
                                if(isSuccess)
                                {
                                    string message = "成功";
                                    Notes3.Visible = true;
                                    base.TipsAlert("Sql Server数据库备份成功");
                                }
                                else
                                {
                                    string message = "失败";
                                    Notes4.Visible = true;
                                    base.TipsAlert("Sql Server数据库备份失败");
                                }
                            }
                            else
                            {
                                //不是卷尾
                                int a = 0;
                                //utils.JsAlert("该备份卷不是卷尾，无法恢复");
                                base.TipsAlert("该备份卷无卷尾，无法恢复");
                            }
                        }
                    }
                    else
                    {
                        //不是卷头
                        int a = 0;
                        //utils.JsAlert("该备份卷不是卷头，无法恢复");
                        base.TipsAlert("该备份卷不是卷头，Sql Server恢复,请选择卷头");
                    }
                }
            }
            else
            {
                int a = 0;
                //utils.JsAlert("文件内容为空!");
                base.TipsAlert("文件内容为空，无法恢复");
            }
        }

        private  bool ExecuteStoreForSql(string[] str)
        {
            bool isSuccessed = true;
            string[] point = null;
            try
            {
                foreach (var item in str)
                {
                    //string[] st = File.ReadAllLines(Server.MapPath("../db/dbbak/sqlserver/" + item));
                    string st = File.ReadAllText(Server.MapPath("../db/dbbak/sqlserver/" + item));
                    
                    //point = st;
                    ExecuteSql(st);
                }
            }
            catch
            {
                isSuccessed = false;
            }
            return isSuccessed;
        }

        private void ExecuteSql(string str)
        {
            //string ss = "";
            //foreach (var s in str)
            //{
            //    ss += s;
            //    ss += "\r \n\r \n";
            //}
            EbSite.Base.DataProfile.DbHelperCms.Instance.ExecuteNonQuery(str);
        }

        protected void delButton_Click(object sender, EventArgs e)
        {
            GetCheckID();
            string[] fileids = this.CheckedIDS.Split(',');
            for (int i = 0; i < fileids.Length; i++)
            {
                File.Delete(path + "\\" + fileids[i].Trim());
            }
            BindData();
        }
        
    }
}