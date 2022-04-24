using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using EbSite.Core.DataBase;
using EbSite.Core.DataBase.Interface;
using EbSite.Entity;
using EbSite.ModulesGenerate.Core;

namespace EbSite.ModulesGenerate
{
    public partial class Make : EbSite.Base.ControlPage.UserControlBase
    {
        public override string Permission
        {
            get
            {
                return "1";
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            HiddenField1.Value = "1";
        }
        protected void bntMake_Click(object sender, EventArgs e)
        {

        }

        protected void wdMake_FinishButtonClick(object sender, WizardNavigationEventArgs e)
        {
            string dbtype = drpDbType.SelectedValue;
            string ServerIp = txtServer.Text.Trim();
            string DbName = drpDataBase.SelectedValue;
            string sConn = GetConn();
            List<string> Tables = new List<string>();
            foreach (ListItem li in lbTables.Items)
            {
                if (li.Selected)
                    Tables.Add(li.Value);
            }
            string AppFrame = droType.SelectedValue;
            string ProjectCnName = txtCnTitle.Text.Trim();
            string ProjectEnName = txtEnTitle.Text.Trim();
            string Tabpre = txtTabpre.Text;
            if (Tables.Count > 0)
            {
                ProjectInfo pjInfo = new ProjectInfo();
                pjInfo.dbtype = dbtype;
                pjInfo.ServerIp = ServerIp;
                pjInfo.DbName = DbName;
                pjInfo.sConn = sConn;
                pjInfo.Tables = Tables;
                pjInfo.AppFrame = AppFrame;
                pjInfo.ProjectCnName = ProjectCnName;
                pjInfo.ProjectEnName = ProjectEnName;
                pjInfo.Tabpre = Tabpre;
                pjInfo.Author = Author.Text.Trim();
                pjInfo.AuthorUrl = AuthorUrl.Text.Trim();
                pjInfo.sVersion = Version.Text.Trim();
                GenerateProject gp = new GenerateProject(pjInfo);

                //把表前辍写入Session 作用是：在大Session 中查 每个表的字段。ModelName 是表名，但没有表前辍了。
                if(string.IsNullOrEmpty(Tabpre))
                {
                    Session["pre"] = "";
                }
                else
                {
                    Session["pre"] = Tabpre;
                }
                

                gp.StartMake();

               


                //生成完成，往模块列表里加入模块数据
                Entity.ModuleInfo mdif = new ModuleInfo();
                mdif.ModuleName = pjInfo.ProjectCnName;
                mdif.Author = pjInfo.Author;
                mdif.AuthorUrl = pjInfo.AuthorUrl;
                string sSetupPathAll = string.Concat(IISPath, "Modules/", pjInfo.ProjectEnName, "/");
                mdif.SetupPath = sSetupPathAll;
                mdif.Version = pjInfo.sVersion;
                mdif.AccessFile = "";
                mdif.LastVersionUrl = "";
                mdif.IsClose = false;
                mdif.Demo = "";
                mdif.AccessFile = "";
                mdif.SqlScript = "";
                mdif.UpdateUrl = "";
                mdif.id = Guid.NewGuid(); //模块ID
                
                EbSite.BLL.ModulesBll.Modules.Instance.Add(mdif);

              
            }
            else
            {
                TipsAlert("请选择表!");
            }

            //释放Session　
            Session["FieldAdd"] = "";
            Session["FieldList"] = "";
            Session["FieldSearch"] = "";
            Session["FieldShow"] = "";
            Session["FieldSearchAdv"] = "";
            Session["Conn"] = "";
            Session["pre"] = "";

            //TipsAlert(txtCnTitle.Text+"生成完成。");

        }

        public string DbName;
        protected void wdMake_ActiveStepChanged(object sender, EventArgs e)
        {
            string dbtype = drpDbType.SelectedValue;
            if (wdMake.ActiveStepIndex == 1) //选择表
            {
                if (Equals(dbtype, "OleDb"))
                {
                    dbconfigs.Visible = false;
                    dbconfiga.Visible = true;
                }
                else
                {
                    dbconfigs.Visible = true;
                    dbconfiga.Visible = false;
                }
            }
            else if (wdMake.ActiveStepIndex == 2) //选择表
            {


                string ServerIp = txtServer.Text.Trim();
                DbName = drpDataBase.SelectedValue;

                string sConn = GetConn();



                IDbObject dbobj = DBOMaker.CreateDbObj(dbtype);
                DbSettings dbset = DbConfig.GetSetting(dbtype, ServerIp, DbName, sConn);

                dbobj.DbConnectStr = dbset.ConnectStr;

                lbTables.DataSource = dbobj.GetTables(DbName);
                lbTables.DataBind();


                Session["dbobj"] = dbobj;


            }
            else if (wdMake.ActiveStepIndex == 3) //选择字段
            {
                List<ListItem> Tables = new List<ListItem>();
                foreach (ListItem li in lbTables.Items)
                {
                    if (li.Selected)
                        Tables.Add(li);
                }
                gdList.DataSource = Tables;
                gdList.DataBind();
            }
        }
        #region 获取数据库连接
        private string GetConn()
        {
            string dbtype = drpDbType.SelectedValue;
            if (Equals(dbtype, "OleDb"))
            {

                return GetAccessConn();

            }
            else
            {

                return GetSqlServerConn();

            }
        }
        private string GetAccessConn()
        {
            string sConn;
            if (string.IsNullOrEmpty(txtDBPath.Text.Trim()))
                TipsAlert("请输入access数据库文件的相对路径");
            string sDbAccess = Server.MapPath(txtDBPath.Text);
            sConn = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + sDbAccess + ";Persist Security Info=False";
            return sConn;
        }
        private string GetSqlServerConn()
        {
            string ServerIp = txtServer.Text.Trim();
            string Pass = txtDBPass.Text.Trim();
            string sUser = txtDBUser.Text.Trim();

            if (string.IsNullOrEmpty(ServerIp))
                TipsAlert("请输入服务器地址！");
            string constr = "";
            if (drpVlType.SelectedValue == "0")
            {

                constr = "Integrated Security=SSPI;Data Source=" + ServerIp + ";Initial Catalog=master";
            }
            else
            {
                if (string.IsNullOrEmpty(sUser))
                    TipsAlert("登录用户不能为空！");
                if (Pass == "")
                {
                    constr = "user id=" + sUser + ";initial catalog=master;data source=" + ServerIp;
                }
                else
                {
                    constr = "user id=" + sUser + ";password=" + Pass + ";initial catalog=master;data source=" + ServerIp;
                }
            }

            return constr;

        }
        #endregion

        protected void wdMake_NextButtonClick(object sender, WizardNavigationEventArgs e)
        {

            //判断是本系统数据库，还是第三方数据库
            if (this.HiddenField1.Value == "1")
            {
                //说明是第三方，就不用初使化连接串  
            }
            else
            {
                //是本系统要初使化
                //server=10.140.1.200;database=EbSite;uid=sa;password=Zcom:ComSqlCqs263@163.Com 
                string Conn = Base.Configs.BaseCinfigs.ConfigsControl.Instance.GetConnectionStringSysCms();
                Session["Conn"] = Conn;
                string[] arry = EbSite.Core.Strings.cConvert.SplitArray(Conn, ';');
                txtServer.Text = arry[0].Substring(7);//服务器
                txtDBUser.Text = arry[2].Substring(4);//登录帐号
                txtDBPass.Text = arry[3].Substring(9);//密码
                string dbtype = drpDbType.SelectedValue;
                ConnDataBase();
                drpDataBase.SelectedValue = arry[1].Substring(9);//数据库

            }
        }

        private void ConnDataBase()
        {
            try
            {

                string dbtype = drpDbType.SelectedValue;
                IDbObject dbobj = DBOMaker.CreateDbObj(dbtype);
                dbobj.DbConnectStr = GetSqlServerConn();
                drpDataBase.DataSource = dbobj.GetDBList();
                drpDataBase.DataBind();
            }
            catch (Exception ex)
            {

                TipsAlert(ex.Message);
            }
        }
        protected void bntConn_Click(object sender, EventArgs e)
        {

            ConnDataBase();
        }


    }
}