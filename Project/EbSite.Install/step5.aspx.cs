using System;
using System.Data;
using System.Data.Common;
using System.IO;
using System.Text;
using EbSite.Base.DataProfile;
using EbSite.BLL.User;
using EbSite.Core.FSO;

namespace EbSite.Install
{
    public partial class step5 : SetupBase
    {


        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {


                #region  安装前验证，是否存在ebsite.lock文件，如果存在提示用户，系统已经安装，如果想重新安装系统请删除install目录下的ebsite.lock文件

              
                if (Core.FSO.FObject.IsExist(Server.MapPath(lockfile), FsoMethod.File))
                {
                    this.PanelErr.Visible = true;
                    this.PanelOK.Visible = false;
                }
                else
                {
                    this.PanelErr.Visible = false;
                    this.PanelOK.Visible = true;




                    string sDbType_cms = EbSite.Base.Configs.BaseCinfigs.ConfigsControl.Instance.DataLayerType;
                    string sDbType_user = EbSite.Base.Configs.BaseCinfigs.ConfigsControl.Instance.DataLayerTypeUser;
                    lbDataBaseTypeUser.Text = sDbType_user;
                    lbDataBaseType.Text = sDbType_cms;

                    if (sDbType_cms == "SqlServer")
                    {
                        lbBinInfo.Text = "EbSite.Data.MySql.dll";

                        lbInstallInfo.Text = "1.对数据库中已有的旧版EbSite系统表和存储过程进行删除操作<br>2.创建表和存储过程<br>3.初始化数据";
                    }
                    else if (sDbType_cms == "MySql")
                    {
                        lbBinInfo.Text = "EbSite.Data.SqlServer.dll";
                        //this.cbInstallDemoData.Checked = true;
                        //this.cbInstallDemoData.Enabled = false;
                        lbInstallInfo.Text = "1.对数据库中已有的旧版EbSite系统表和存储过程进行删除操作<br>2.创建表和存储过程<br>3.初始化数据";
                    }
                    lbBinInfo.Text += "<br>";
                    if (sDbType_user == "SqlServer")
                    {
                        lbBinInfo.Text += "EbSite.Data.User.MySql.dll";
                    }
                    else if (sDbType_user == "MySql")
                    {
                        lbBinInfo.Text += "EbSite.Data.User.SqlServer.dll";
                    }
                    /////////////////////////////////////////////////

                    if ((Session["SystemAdminName"] == null))
                    {
                        Core.Strings.cJavascripts.MessageShowBack("Session为空，可能已经被禁用！");
                        Response.Redirect("step3.aspx");
                    }
                    else
                    {
                        ViewState["SystemAdminName"] = Session["SystemAdminName"].ToString();
                        ViewState["SystemAdminPws"] = Session["SystemAdminPws"].ToString();
                        ViewState["SystemAdminEmail"] = Session["SystemAdminEmail"].ToString();
                        if (Session["SysDataBaseName"] != null)
                        {
                            ViewState["SysDataBaseName"] = Session["SysDataBaseName"].ToString();
                        }

                    }
                }
                #endregion
            }

        }

        protected void bntStarInstall_Click(object sender, EventArgs e)
        {
            string dbtype_cms = EbSite.Base.Configs.BaseCinfigs.ConfigsControl.Instance.DataLayerType.ToLower();
            string dbtype_user = EbSite.Base.Configs.BaseCinfigs.ConfigsControl.Instance.DataLayerTypeUser.ToLower();
            try
            {
                //安装用户数据库库
                if (dbtype_cms == "sqlserver")
                {
                    DeleteSqlserverTableAndSP_CMS();
                    CreateSqlserverTableAndSP_CMS();
                    InstallDemoData();

                }
                else if (dbtype_cms == "mysql")
                {
                    // InitAccess_Cms();
                    DeleteMySqlTableAndSP_CMS();
                    CreateMySqlTableAndSP_CMS();
                    InstallDemoData();

                }

                //安装用户信息数据库库
                if (dbtype_user == "sqlserver")
                {
                    DeleteSqlserverTableAndSP_User();
                    CreateSqlserverTableAndSP_User();
                    AddSqlserverManagerUser();
                }
                else if (dbtype_user == "mysql")
                {
                    //InitAccess_User();
                    DeleteMySqlTableAndSP_User();
                    CreateMySqlTableAndSP_User();
                    AddMySqlManagerUser();
                }

                DeleteDLLAndSetWebConfig();
            }
            catch (DbException ex)
            {
                string message = ex.Message.Replace("'", " ");
                message = message.Replace("\\", "/");
                message = message.Replace("\r\n", "\\r\\n");
                message = message.Replace("\r", "\\r");
                message = message.Replace("\n", "\\n");

                Core.Strings.cJavascripts.MessageShowMyreturn("您的数据库登陆或权限存在问题,请确保信息正确后再运行安装:" + message, "step3.aspx");

                return;
            }

            Response.Redirect("succeed.aspx");

        }
        private void DeleteDLLAndSetWebConfig()
        {
            string dbtype_cms = EbSite.Base.Configs.BaseCinfigs.ConfigsControl.Instance.DataLayerType.ToLower();
            string dbtype_user = EbSite.Base.Configs.BaseCinfigs.ConfigsControl.Instance.DataLayerTypeUser.ToLower();
            try
            {

                string sBinPath = Server.MapPath("../bin");
                string sWebConfigPath = Server.MapPath("../Web.config");

                string sConfigs = Core.FSO.FObject.ReadFile(sWebConfigPath);
                if (dbtype_cms == "sqlserver")
                {
                    Core.FSO.FObject.Delete(string.Concat(sBinPath, "\\EbSite.Data.MySql.dll"), FsoMethod.File);



                    sConfigs = sConfigs.Replace("EbSite.Data.MySql", "EbSite.Data.SqlServer");

                }
                else if (dbtype_cms == "mysql")
                {
                    Core.FSO.FObject.Delete(string.Concat(sBinPath, "\\EbSite.Data.SqlServer.dll"), FsoMethod.File);
                    sConfigs = sConfigs.Replace("EbSite.Data.SqlServer", "EbSite.Data.MySql");
                }


                if (dbtype_user == "sqlserver")
                {
                    Core.FSO.FObject.Delete(string.Concat(sBinPath, "\\EbSite.Data.User.MySql.dll"), FsoMethod.File);

                    sConfigs = sConfigs.Replace("EbSite.Data.User.MySql", "EbSite.Data.User.SqlServer");
                }
                else if (dbtype_user == "mysql")
                {
                    Core.FSO.FObject.Delete(string.Concat(sBinPath, "\\EbSite.Data.User.SqlServer.dll"), FsoMethod.File);
                    sConfigs = sConfigs.Replace("EbSite.Data.User.SqlServer", "EbSite.Data.User.MySql");
                }

                Core.FSO.FObject.WriteFile(sWebConfigPath, sConfigs);

            }
            catch (DbException ex)
            {

                Core.Strings.cJavascripts.MessageShowMyreturn("删除.DLL文件出错:" + ex.Message, "step3.aspx");

                return;
            }
        }
        /// <summary>
        /// 安装演示数据
        /// </summary>
        private void InstallDemoData()
        {
            string dbtype_cms = EbSite.Base.Configs.BaseCinfigs.ConfigsControl.Instance.DataLayerType.ToLower();
            if (cbInstallDemoData.Checked)
            {
                if (dbtype_cms == "sqlserver")
                {
                    string dbscriptpath = Server.MapPath(@"sql\InsertDemoSqlServerData.sql");
                    string tableprefix = EbSite.Base.Configs.BaseCinfigs.ConfigsControl.Instance.TablePrefix;
                    string sql = string.Empty;
                    /*
                     要替换
                    #ManagerUserName# 管理员帐号
                     */
                    //初始化用户数据表
                    StringBuilder sb = new StringBuilder();
                    using (StreamReader objReader = new StreamReader(dbscriptpath, Encoding.UTF8))
                    {
                        sb.Append(objReader.ReadToEnd());
                        objReader.Close();
                    }
                    string UserName = ViewState["SystemAdminName"].ToString();
                    string DataBase = ViewState["SysDataBaseName"].ToString();

                    sql = sb.ToString().Replace("#ManagerUserName#", UserName).Replace("#DataBase#", DataBase);
                    if (string.IsNullOrEmpty(sql.Trim())) return;
                    if (tableprefix.ToLower() == "eb_")
                    {
                        DbHelperCms.Instance.ExecuteCommandWithSplitter(sql);
                    }
                    else
                    {
                        sql = sql.Replace("EB_", tableprefix);
                        DbHelperCms.Instance.ExecuteCommandWithSplitter(sql);
                    }
                }
                else if (dbtype_cms == "mysql")
                {
                    string dbscriptpath = Server.MapPath(@"sql\InsertDemoMySqlData.sql");
                    string tableprefix = EbSite.Base.Configs.BaseCinfigs.ConfigsControl.Instance.TablePrefix;
                    string sql = string.Empty;
                    /*
                     要替换
                    #ManagerUserName# 管理员帐号
                     */
                    //初始化用户数据表
                    StringBuilder sb = new StringBuilder();
                    using (StreamReader objReader = new StreamReader(dbscriptpath, Encoding.UTF8))
                    {
                        sb.Append(objReader.ReadToEnd());
                        objReader.Close();
                    }
                    string UserName = ViewState["SystemAdminName"].ToString();
                    string DataBase = ViewState["SysDataBaseName"].ToString();

                    sql = sb.ToString().Replace("#ManagerUserName#", UserName).Replace("#DataBase#", DataBase);
                    if (string.IsNullOrEmpty(sql.Trim())) return;
                    if (tableprefix.ToLower() == "eb_")
                    {
                        DbHelperCms.Instance.ExecuteCommandWithSplitter(sql);
                    }
                    else
                    {
                        sql = sql.Replace("EB_", tableprefix).Replace("eb_", tableprefix);
                        DbHelperCms.Instance.ExecuteCommandWithSplitter(sql);
                    }
                }

            }
        }


        #region Sqlserver 表处理
        /// <summary>
        /// 添加系统管理员
        /// </summary>
        private void AddSqlserverManagerUser()
        {
            string dbscriptpath = Server.MapPath(@"sql\sqlserver\InitData_User.sql");
            string tableprefix = EbSite.Base.Configs.BaseCinfigs.ConfigsControl.Instance.TablePrefixUser;
            string UserName = ViewState["SystemAdminName"].ToString();
            string PassWord = UserIdentity.PassWordEncode(ViewState["SystemAdminPws"].ToString());
            string Email = ViewState["SystemAdminEmail"].ToString();
            string sql = string.Empty;
            /*
             要替换
             #UserName#   #UserPass#   #UserEmail#
             
             */
            //初始化用户数据表
            StringBuilder sb = new StringBuilder();
            using (StreamReader objReader = new StreamReader(dbscriptpath, Encoding.UTF8))
            {
                sb.Append(objReader.ReadToEnd());
                objReader.Close();
            }
            sql = sb.ToString().Replace("#UserName#", UserName).Replace("#UserPass#", PassWord).Replace("#UserEmail#", Email);
            if (string.IsNullOrEmpty(sql.Trim())) return;
            if (tableprefix.ToLower() == "eb_")
            {
                DbHelperUser.Instance.ExecuteCommandWithSplitter(sql);
            }
            else
            {
                sql = sql.Replace("EB_", tableprefix).Replace("eb", tableprefix);
                DbHelperUser.Instance.ExecuteCommandWithSplitter(sql);
            }
            //初始化核心系统数据

            sb.Remove(0, sb.Length);
            dbscriptpath = Server.MapPath(@"sql\sqlserver\InitData_Cms.sql");
            tableprefix = EbSite.Base.Configs.BaseCinfigs.ConfigsControl.Instance.TablePrefix;

            using (StreamReader objReader = new StreamReader(dbscriptpath, Encoding.UTF8))
            {
                sb.Append(objReader.ReadToEnd());
                objReader.Close();
            }
            if (string.IsNullOrEmpty(sql.Trim())) return;
            sql = sb.ToString().Replace("#UserName#", UserName);

            if (tableprefix.ToLower() == "eb_")
            {
                DbHelperCms.Instance.ExecuteCommandWithSplitter(sql);
            }
            else
            {
                DbHelperCms.Instance.ExecuteCommandWithSplitter(sql.Replace("EB_", tableprefix).Replace("eb", tableprefix));
            }

        }

        //建表和存储过程-核心系统
        private void CreateSqlserverTableAndSP_CMS()
        {
            //string connectstring = EbSite.Base.Configs.BaseCinfigs.ConfigsControl.Instance.ConnectionStringSysCms;
            string tableprefix = EbSite.Base.Configs.BaseCinfigs.ConfigsControl.Instance.TablePrefix;
            string dbscriptpath = Server.MapPath(@"sql\sqlserver\CreateTable_Cms.sql");
            #region 建表
            StringBuilder sb = new StringBuilder();
            using (StreamReader objReader = new StreamReader(dbscriptpath, Encoding.UTF8))
            {
                sb.Append(objReader.ReadToEnd());
                objReader.Close();
            }

            if (tableprefix.ToLower() == "eb_")
            {

                DbHelperCms.Instance.ExecuteCommandWithSplitter(sb.ToString());
            }
            else
            {
                DbHelperCms.Instance.ExecuteCommandWithSplitter(sb.ToString().Replace("EB_", tableprefix));
            }
            #endregion

            #region 建存储过程
            sb.Remove(0, sb.Length);

            string sqlServerVersion = DbHelperCms.Instance.ExecuteScalar(CommandType.Text, "SELECT @@VERSION").ToString().Substring(20, 24).Trim();
            if (sqlServerVersion.IndexOf("2000") >= 0)
            {
                dbscriptpath = Server.MapPath(@"sql\sqlserver\CreateSP2000_Cms.sql");
                using (StreamReader objReader = new StreamReader(dbscriptpath, Encoding.UTF8))
                {
                    sb.Append(objReader.ReadToEnd());
                    objReader.Close();
                }
            }
            else
            {
                dbscriptpath = Server.MapPath(@"sql\sqlserver\CreateSP2005_Cms.sql");
                using (StreamReader objReader = new StreamReader(dbscriptpath, Encoding.UTF8))
                {
                    sb.Append(objReader.ReadToEnd());
                    objReader.Close();
                }
            }

            if (tableprefix.ToLower() == "eb_")
            {
                DbHelperCms.Instance.ExecuteCommandWithSplitter(sb.ToString().Trim().Replace("\"", "'"));
            }
            else
            {
                DbHelperCms.Instance.ExecuteCommandWithSplitter(sb.ToString().Trim().Replace("\"", "'").Replace("EB_", tableprefix));
            }

            #endregion

            #region 建全文索引

            //try
            //{
            //    #region 建全文索引
            //    sb.Remove(0, sb.Length);
            //    sb.Append("USE [" + ViewState["dbname"].ToString() + "] \r\n");
            //    sb.Append("execute sp_fulltext_database 'enable';");
            //    DbHelper.ExecuteNonQuery(CommandType.Text, sb.ToString());

            //    sb.Remove(0, sb.Length);
            //    using (System.IO.StreamReader objReader = new System.IO.StreamReader(Server.MapPath(ViewState["dbscriptpath"].ToString() + "setup2.3.sql"), Encoding.UTF8))
            //    {
            //        sb.Append(objReader.ReadToEnd());
            //        objReader.Close();
            //    }

            //    if (tableprefix.ToLower() == "dnt_")
            //    {
            //        DbHelper.ExecuteNonQuery(CommandType.Text, sb.ToString());
            //    }
            //    else
            //    {
            //        string sql = sb.ToString().Replace("databaseproperty('dnt'", "databaseproperty('" + ViewState["dbname"].ToString() + "'");
            //        DbHelper.ExecuteNonQuery(CommandType.Text, sql.Replace("dnt_", tableprefix));
            //    }



            //    #endregion
            //}
            //catch (Exception ex)
            //{
            //    string message = ex.Message.Replace("'", " ");
            //    message = message.Replace("\\", "/");
            //    message = message.Replace("\r\n", "\\r\\n");
            //    message = message.Replace("\r", "\\r");
            //    message = message.Replace("\n", "\\n");

            //    Core.Strings.cJavascripts.MessageShowRBack(message);
            //}
            #endregion
        }

        //建表和存储过程-核心系统
        private void CreateSqlserverTableAndSP_User()
        {
            string tableprefix = EbSite.Base.Configs.BaseCinfigs.ConfigsControl.Instance.TablePrefixUser;
            string dbscriptpath = Server.MapPath(@"sql\sqlserver\CreateTable_User.sql");
            #region 建表
            StringBuilder sb = new StringBuilder();
            using (StreamReader objReader = new StreamReader(dbscriptpath, Encoding.UTF8))
            {
                sb.Append(objReader.ReadToEnd());
                objReader.Close();
            }

            if (tableprefix.ToLower() == "eb_")
            {
                DbHelperUser.Instance.ExecuteCommandWithSplitter(sb.ToString());
            }
            else
            {
                DbHelperUser.Instance.ExecuteCommandWithSplitter(sb.ToString().Replace("EB_", tableprefix));
            }
            #endregion

            #region 建存储过程
            sb.Remove(0, sb.Length);

            string sqlServerVersion = DbHelperUser.Instance.ExecuteScalar(CommandType.Text, "SELECT @@VERSION").ToString().Substring(20, 24).Trim();
            if (sqlServerVersion.IndexOf("2000") >= 0)
            {
                dbscriptpath = Server.MapPath(@"sql\sqlserver\CreateSP2000_User.sql");
                using (StreamReader objReader = new StreamReader(dbscriptpath, Encoding.UTF8))
                {
                    sb.Append(objReader.ReadToEnd());
                    objReader.Close();
                }
            }
            else
            {
                dbscriptpath = Server.MapPath(@"sql\sqlserver\CreateSP2005_User.sql");
                using (StreamReader objReader = new StreamReader(dbscriptpath, Encoding.UTF8))
                {
                    sb.Append(objReader.ReadToEnd());
                    objReader.Close();
                }
            }

            if (tableprefix.ToLower() == "eb_")
            {
                DbHelperUser.Instance.ExecuteCommandWithSplitter(sb.ToString().Trim().Replace("\"", "'"));
            }
            else
            {
                DbHelperUser.Instance.ExecuteCommandWithSplitter(sb.ToString().Trim().Replace("\"", "'").Replace("EB_", tableprefix));
            }

            #endregion

        }
        //删除数据库中原有的表和存储过程
        private void DeleteSqlserverTableAndSP_User()
        {
        }
        //删除数据库中原有的表和存储过程
        private void DeleteSqlserverTableAndSP_CMS()
        {
            //删除表和存储过程
            //connectstring = ViewState["Dbconnectstring"].ToString();
            //tableprefix = ViewState["Tableprefix"].ToString();

            //StringBuilder sb = new StringBuilder();
            //using (StreamReader objReader = new StreamReader(Server.MapPath(ViewState["dbscriptpath"].ToString() + "setup1.sql"), Encoding.UTF8))
            //{
            //    sb.Append(objReader.ReadToEnd());
            //    objReader.Close();
            //}

            //if (tableprefix.ToLower() == "dnt_")
            //{
            //    DbHelperCms.Instance.ExecuteNonQuery(CommandType.Text, sb.ToString());
            //}
            //else
            //{
            //    DbHelperCms.Instance.ExecuteNonQuery(CommandType.Text, sb.ToString().Replace("dnt_", tableprefix));
            //}
        }

        #endregion

        #region Access
        //private void InitAccess_User()
        //{
        //    string UserName = ViewState["SystemAdminName"].ToString();
        //    string PassWord = UserIdentity.PassWordEncode(ViewState["SystemAdminPws"].ToString());
        //    string Email = ViewState["SystemAdminEmail"].ToString();

        //    string sql =
        //        string.Format(
        //            "UPDATE EB_Users SET [UserName] = '{0}' ,[Password] = '{1}' ,[emailAddress] = '{2}', [NiName] = '{0}' WHERE UserID=1", UserName, PassWord, Email);

        //    DbHelperUser.Instance.ExecuteNonQuery(CommandType.Text, sql);

        //    //sql =
        //    //  string.Format(
        //    //      "UPDATE EB_UserCustomField SET [UserName] ='{0}' ,[NiName] = '{0}' WHERE ID=1", UserName);

        //    //DbHelperUser.Instance.ExecuteNonQuery(CommandType.Text, sql);

        //    sql =
        //      string.Format(
        //          "UPDATE EB_Admin_User SET [UserName] ='{0}'  WHERE UserID=1", UserName);

        //    DbHelperUser.Instance.ExecuteNonQuery(CommandType.Text, sql);



        //}

        //private void InitAccess_Cms()
        //{

        //}

        #endregion

        #region MySql 表处理
        /// <summary>
        /// 添加系统管理员
        /// </summary>
        private void AddMySqlManagerUser()
        {
            string dbscriptpath = Server.MapPath(@"sql\mysql\InitData_User.sql");
            string tableprefix = EbSite.Base.Configs.BaseCinfigs.ConfigsControl.Instance.TablePrefixUser;
            string UserName = ViewState["SystemAdminName"].ToString();
            string PassWord = UserIdentity.PassWordEncode(ViewState["SystemAdminPws"].ToString());
            string Email = ViewState["SystemAdminEmail"].ToString();
            string sql = string.Empty;
            /*
             要替换
             #UserName#   #UserPass#   #UserEmail#
             
             */
            //初始化用户数据表
            StringBuilder sb = new StringBuilder();
            using (StreamReader objReader = new StreamReader(dbscriptpath, Encoding.UTF8))
            {
                sb.Append(objReader.ReadToEnd());
                objReader.Close();
            }
            sql = sb.ToString().Replace("#UserName#", UserName).Replace("#UserPass#", PassWord).Replace("#UserEmail#", Email);
            if (string.IsNullOrEmpty(sql.Trim())) return;
            if (tableprefix.ToLower() == "eb_")
            {
                DbHelperUser.Instance.ExecuteCommandWithSplitter(sql);
            }
            else
            {
                sql = sql.Replace("EB_", tableprefix).Replace("eb_", tableprefix);
                DbHelperUser.Instance.ExecuteCommandWithSplitter(sql);
            }
            //初始化核心系统数据

            sb.Remove(0, sb.Length);
            dbscriptpath = Server.MapPath(@"sql\mysql\InitData_Cms.sql");
            tableprefix = EbSite.Base.Configs.BaseCinfigs.ConfigsControl.Instance.TablePrefix;

            using (StreamReader objReader = new StreamReader(dbscriptpath, Encoding.UTF8))
            {
                sb.Append(objReader.ReadToEnd());
                objReader.Close();
            }
            if (string.IsNullOrEmpty(sql.Trim())) return;
            sql = sb.ToString().Replace("#UserName#", UserName);

            if (tableprefix.ToLower() == "eb_")
            {
                DbHelperCms.Instance.ExecuteCommandWithSplitter(sql);
            }
            else
            {
                DbHelperCms.Instance.ExecuteCommandWithSplitter(sql.Replace("eb_", tableprefix).Replace("EB_", tableprefix));
            }
            //初始化核心系统数据

            sb.Remove(0, sb.Length);
            dbscriptpath = Server.MapPath(@"sql\mysql\InitData_Cms1.sql");
            tableprefix = EbSite.Base.Configs.BaseCinfigs.ConfigsControl.Instance.TablePrefix;

            using (StreamReader objReader = new StreamReader(dbscriptpath, Encoding.UTF8))
            {
                sb.Append(objReader.ReadToEnd());
                objReader.Close();
            }
            if (string.IsNullOrEmpty(sql.Trim())) return;
            sql = sb.ToString().Replace("#UserName#", UserName);

            if (tableprefix.ToLower() == "eb_")
            {
                DbHelperCms.Instance.ExecuteCommandWithSplitter(sql);
            }
            else
            {
                DbHelperCms.Instance.ExecuteCommandWithSplitter(sql.Replace("eb_", tableprefix).Replace("EB_", tableprefix));
            }
            ////初始化核心系统数据

            //sb.Remove(0, sb.Length);
            //dbscriptpath = Server.MapPath(@"sql\mysql\InitData_Cms2.sql");
            //tableprefix = EbSite.Base.Configs.BaseCinfigs.ConfigsControl.Instance.TablePrefix;

            //using (StreamReader objReader = new StreamReader(dbscriptpath, Encoding.UTF8))
            //{
            //    sb.Append(objReader.ReadToEnd());
            //    objReader.Close();
            //}
            //if (string.IsNullOrEmpty(sql.Trim())) return;
            //sql = sb.ToString().Replace("#UserName#", UserName);

            //if (tableprefix.ToLower() == "eb_")
            //{
            //    DbHelperCms.Instance.ExecuteCommandWithSplitter(sql);
            //}
            //else
            //{
            //    DbHelperCms.Instance.ExecuteCommandWithSplitter(sql.Replace("eb_", tableprefix).Replace("EB_", tableprefix));
            //}
            ////初始化核心系统数据

            //sb.Remove(0, sb.Length);
            //dbscriptpath = Server.MapPath(@"sql\mysql\InitData_Cms3.sql");
            //tableprefix = EbSite.Base.Configs.BaseCinfigs.ConfigsControl.Instance.TablePrefix;

            //using (StreamReader objReader = new StreamReader(dbscriptpath, Encoding.UTF8))
            //{
            //    sb.Append(objReader.ReadToEnd());
            //    objReader.Close();
            //}
            //if (string.IsNullOrEmpty(sql.Trim())) return;
            //sql = sb.ToString().Replace("#UserName#", UserName);

            //if (tableprefix.ToLower() == "eb_")
            //{
            //    DbHelperCms.Instance.ExecuteCommandWithSplitter(sql);
            //}
            //else
            //{
            //    DbHelperCms.Instance.ExecuteCommandWithSplitter(sql.Replace("eb_", tableprefix).Replace("EB_", tableprefix));
            //}
            ////初始化核心系统数据

            //sb.Remove(0, sb.Length);
            //dbscriptpath = Server.MapPath(@"sql\mysql\InitData_Cms4.sql");
            //tableprefix = EbSite.Base.Configs.BaseCinfigs.ConfigsControl.Instance.TablePrefix;

            //using (StreamReader objReader = new StreamReader(dbscriptpath, Encoding.UTF8))
            //{
            //    sb.Append(objReader.ReadToEnd());
            //    objReader.Close();
            //}
            //if (string.IsNullOrEmpty(sql.Trim())) return;
            //sql = sb.ToString().Replace("#UserName#", UserName);

            //if (tableprefix.ToLower() == "eb_")
            //{
            //    DbHelperCms.Instance.ExecuteCommandWithSplitter(sql);
            //}
            //else
            //{
            //    DbHelperCms.Instance.ExecuteCommandWithSplitter(sql.Replace("eb_", tableprefix).Replace("EB_", tableprefix));
            //}
            ////初始化核心系统数据

            //sb.Remove(0, sb.Length);
            //dbscriptpath = Server.MapPath(@"sql\mysql\InitData_Cms5.sql");
            //tableprefix = EbSite.Base.Configs.BaseCinfigs.ConfigsControl.Instance.TablePrefix;

            //using (StreamReader objReader = new StreamReader(dbscriptpath, Encoding.UTF8))
            //{
            //    sb.Append(objReader.ReadToEnd());
            //    objReader.Close();
            //}
            //if (string.IsNullOrEmpty(sql.Trim())) return;
            //sql = sb.ToString().Replace("#UserName#", UserName);

            //if (tableprefix.ToLower() == "eb_")
            //{
            //    DbHelperCms.Instance.ExecuteCommandWithSplitter(sql);
            //}
            //else
            //{
            //    DbHelperCms.Instance.ExecuteCommandWithSplitter(sql.Replace("eb_", tableprefix).Replace("EB_", tableprefix));
            //}
            ////初始化核心系统数据

            //sb.Remove(0, sb.Length);
            //dbscriptpath = Server.MapPath(@"sql\mysql\InitData_Cms6.sql");
            //tableprefix = EbSite.Base.Configs.BaseCinfigs.ConfigsControl.Instance.TablePrefix;

            //using (StreamReader objReader = new StreamReader(dbscriptpath, Encoding.UTF8))
            //{
            //    sb.Append(objReader.ReadToEnd());
            //    objReader.Close();
            //}
            //if (string.IsNullOrEmpty(sql.Trim())) return;
            //sql = sb.ToString().Replace("#UserName#", UserName);

            //if (tableprefix.ToLower() == "eb_")
            //{
            //    DbHelperCms.Instance.ExecuteCommandWithSplitter(sql);
            //}
            //else
            //{
            //    DbHelperCms.Instance.ExecuteCommandWithSplitter(sql.Replace("eb_", tableprefix).Replace("EB_", tableprefix));
            //}

        }

        //建表和存储过程-核心系统
        private void CreateMySqlTableAndSP_CMS()
        {
            string connectstring = EbSite.Base.Configs.BaseCinfigs.ConfigsControl.Instance.ConnectionStringSysCms;
            string tableprefix = EbSite.Base.Configs.BaseCinfigs.ConfigsControl.Instance.TablePrefix;
            // string userid = "";
            //foreach (string info in connectstring.Split(';'))
            //{
            //    if (info.ToLower().IndexOf("userid") >= 0)
            //    {
            //        userid = info.Split('=')[1].Trim();
            //        break;
            //    }
            //}

            string dbscriptpath = Server.MapPath(@"sql\mysql\CreateTable_Cms.sql");
            #region 建表
            StringBuilder sb = new StringBuilder();
            using (StreamReader objReader = new StreamReader(dbscriptpath, Encoding.UTF8))
            {
                sb.Append(objReader.ReadToEnd());
                objReader.Close();
            }

            if (tableprefix.ToLower() == "eb_")
            {

                DbHelperCms.Instance.ExecuteCommandWithSplitter(sb.ToString());
            }
            else
            {
                DbHelperCms.Instance.ExecuteCommandWithSplitter(sb.ToString().Replace("eb_", tableprefix).Replace("EB_", tableprefix));
            }
            #endregion

            #region 建存储过程
            sb.Remove(0, sb.Length);

            //string sqlServerVersion = DbHelperCms.Instance.ExecuteScalar(CommandType.Text, "SELECT @@VERSION").ToString().Substring(20, 24).Trim();
            dbscriptpath = Server.MapPath(@"sql\mysql\CreateSP_Cms.sql");
            using (StreamReader objReader = new StreamReader(dbscriptpath, Encoding.UTF8))
            {
                sb.Append(objReader.ReadToEnd());
                objReader.Close();
            }

            if (tableprefix.ToLower() == "eb_")
            {
                DbHelperCms.Instance.ExecuteCommandWithSplitter(sb.ToString().Trim().Replace("\"", "'"));
            }
            else
            {
                DbHelperCms.Instance.ExecuteCommandWithSplitter(sb.ToString().Trim().Replace("\"", "'").Replace("eb_", tableprefix).Replace("EB_", tableprefix));
            }

            #endregion

            #region 建全文索引

            //try
            //{
            //    #region 建全文索引
            //    sb.Remove(0, sb.Length);
            //    sb.Append("USE [" + ViewState["dbname"].ToString() + "] \r\n");
            //    sb.Append("execute sp_fulltext_database 'enable';");
            //    DbHelper.ExecuteNonQuery(CommandType.Text, sb.ToString());

            //    sb.Remove(0, sb.Length);
            //    using (System.IO.StreamReader objReader = new System.IO.StreamReader(Server.MapPath(ViewState["dbscriptpath"].ToString() + "setup2.3.sql"), Encoding.UTF8))
            //    {
            //        sb.Append(objReader.ReadToEnd());
            //        objReader.Close();
            //    }

            //    if (tableprefix.ToLower() == "dnt_")
            //    {
            //        DbHelper.ExecuteNonQuery(CommandType.Text, sb.ToString());
            //    }
            //    else
            //    {
            //        string sql = sb.ToString().Replace("databaseproperty('dnt'", "databaseproperty('" + ViewState["dbname"].ToString() + "'");
            //        DbHelper.ExecuteNonQuery(CommandType.Text, sql.Replace("dnt_", tableprefix));
            //    }



            //    #endregion
            //}
            //catch (Exception ex)
            //{
            //    string message = ex.Message.Replace("'", " ");
            //    message = message.Replace("\\", "/");
            //    message = message.Replace("\r\n", "\\r\\n");
            //    message = message.Replace("\r", "\\r");
            //    message = message.Replace("\n", "\\n");

            //    Core.Strings.cJavascripts.MessageShowRBack(message);
            //}
            #endregion
        }

        //建表和存储过程-核心系统
        private void CreateMySqlTableAndSP_User()
        {
            string tableprefix = EbSite.Base.Configs.BaseCinfigs.ConfigsControl.Instance.TablePrefixUser;
            string dbscriptpath = Server.MapPath(@"sql\mysql\CreateTable_User.sql");
            string connectstring = EbSite.Base.Configs.BaseCinfigs.ConfigsControl.Instance.ConnectionStringSysCms;

            #region 建表
            StringBuilder sb = new StringBuilder();
            using (StreamReader objReader = new StreamReader(dbscriptpath, Encoding.UTF8))
            {
                sb.Append(objReader.ReadToEnd());
                objReader.Close();
            }

            if (tableprefix.ToLower() == "eb_")
            {
                DbHelperUser.Instance.ExecuteCommandWithSplitter(sb.ToString());
            }
            else
            {
                DbHelperUser.Instance.ExecuteCommandWithSplitter(sb.ToString().Replace("eb_", tableprefix).Replace("EB_", tableprefix));
            }
            #endregion

            #region 建存储过程
            sb.Remove(0, sb.Length);

            // string sqlServerVersion = DbHelperUser.Instance.ExecuteScalar(CommandType.Text, "SELECT @@VERSION").ToString().Substring(20, 24).Trim();
            dbscriptpath = Server.MapPath(@"sql\mysql\CreateSP_User.sql");
            using (StreamReader objReader = new StreamReader(dbscriptpath, Encoding.UTF8))
            {
                sb.Append(objReader.ReadToEnd());
                objReader.Close();
            }

            if (tableprefix.ToLower() == "eb_")
            {
                DbHelperUser.Instance.ExecuteCommandWithSplitter(sb.ToString().Trim().Replace("\"", "'"));
            }
            else
            {
                DbHelperUser.Instance.ExecuteCommandWithSplitter(sb.ToString().Trim().Replace("\"", "'").Replace("eb_", tableprefix).Replace("EB_", tableprefix));
            }

            #endregion

        }
        //删除数据库中原有的表和存储过程
        private void DeleteMySqlTableAndSP_User()
        {
        }
        //删除数据库中原有的表和存储过程
        private void DeleteMySqlTableAndSP_CMS()
        {
            //删除表和存储过程
            //connectstring = ViewState["Dbconnectstring"].ToString();
            //tableprefix = ViewState["Tableprefix"].ToString();

            //StringBuilder sb = new StringBuilder();
            //using (StreamReader objReader = new StreamReader(Server.MapPath(ViewState["dbscriptpath"].ToString() + "setup1.sql"), Encoding.UTF8))
            //{
            //    sb.Append(objReader.ReadToEnd());
            //    objReader.Close();
            //}

            //if (tableprefix.ToLower() == "dnt_")
            //{
            //    DbHelperCms.Instance.ExecuteNonQuery(CommandType.Text, sb.ToString());
            //}
            //else
            //{
            //    DbHelperCms.Instance.ExecuteNonQuery(CommandType.Text, sb.ToString().Replace("dnt_", tableprefix));
            //}
        }

        #endregion
    }
}
