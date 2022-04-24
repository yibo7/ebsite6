using System;
using System.Text.RegularExpressions;
using EbSite.Core;
using EbSite.Core.FSO;
using EbSite.Install;

namespace EbSite.Install
{
    public partial class step3 : SetupBase
    {
        private bool IsUserOut
        {
            get
            {
                if (!string.IsNullOrEmpty(Request["uo"]))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

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
                #endregion
                else
                {
                    this.PanelErr.Visible = false;
                    this.PanelOK.Visible = true;

                    cbIsOutOfUser.Enabled = !IsUserOut;

                    if (!IsUserOut)
                    {
                        llTitle.Text = "数据库配置";
                        txtTableprefix.Text = EbSite.Base.Configs.BaseCinfigs.ConfigsControl.Instance.TablePrefix;

                        InitDataBaseConfigs(EbSite.Base.Configs.BaseCinfigs.ConfigsControl.Instance.ConnectionStringSysCms);

                    }
                    else
                    {
                        llTitle.Text = "用户数据库配置";
                        InitDataBaseConfigs(EbSite.Base.Configs.BaseCinfigs.ConfigsControl.Instance.ConnectionStringSysUser);
                        txtTableprefix.Text = EbSite.Base.Configs.BaseCinfigs.ConfigsControl.Instance.TablePrefixUser;

                    }
                }
            }

        }
        private void InitDataBaseConfigs(string connectionstring)
        {
            foreach (string info in connectionstring.Split(';'))
            {
                #region MySql
                if (info.ToLower().IndexOf("data source") >= 0)
                {
                    txtMySqlDatasource.Text = info.Split('=')[1].Trim();
                    continue;
                }
                if (info.ToLower().IndexOf("database") >= 0)
                {
                    txtMySqlDataBaseName.Text = info.Split('=')[1].Trim();
                    continue;
                }
                if (info.ToLower().IndexOf("userid") >= 0)
                {
                    txtMySqlDataBaseUser.Text = info.Split('=')[1].Trim();
                    continue;
                }
                if (info.ToLower().IndexOf("password") >= 0)
                {
                    string spass = info.Split('=')[1].Trim();
                    txtMySqlDataBasePass.Attributes.Add("value", spass);
                    continue;
                }
                if (info.ToLower().IndexOf("port") >= 0)
                {
                    txtSport.Text = info.Split('=')[1].Trim();
                    continue;
                }
                #endregion

                #region SQL
                if (info.ToLower().IndexOf("data source") >= 0)
                {
                    txtDatasource.Text = info.Split('=')[1].Trim();
                    continue;
                }
                if (info.ToLower().IndexOf("initial catalog") >= 0)
                {
                    txtDataBaseName.Text = info.Split('=')[1].Trim();
                    continue;
                }
                if (info.ToLower().IndexOf("user id") >= 0)
                {
                    txtDataBaseUser.Text = info.Split('=')[1].Trim();
                    continue;
                }
                if (info.ToLower().IndexOf("password") >= 0)
                {
                    string spass = info.Split('=')[1].Trim();
                    txtDataBasePass.Attributes.Add("value", spass);

                    continue;
                }
                #endregion
            }
        }
        protected void bntStarInstall_Click(object sender, EventArgs e)
        {
            //判断数据库类型，填充数据库字符串
            string selectDbType = ddlDbType.SelectedValue;
            string connectionString = string.Empty;
            string tablePrefix = "";
            //验证必须选择数据库类型
            if (ddlDbType.SelectedIndex == 0)
            {

                Core.Strings.cJavascripts.MessageShow("请选择数据库类型");

                return;
            }
            //access文件路径
            // string path = string.Concat(Utils.GetIISPath + "db/" + txtAccessFileName.Text);//Utils.GetMapPath(Utils.GetIISPath + "db/" + txtAccessFileName.Text);
            switch (selectDbType)
            {
                case "SqlServer":


                    #region 验证输入

                    //验证数据库名为空
                    if (txtDataBaseName.Text.Length == 0)
                    {
                        Core.Strings.cJavascripts.MessageShowBack("数据库名不能为空");
                        return;
                    }

                    //验证数据库表前缀不能为数字开头
                    if (!Regex.IsMatch(txtTableprefix.Text, "^[a-zA-Z_](.*)", RegexOptions.IgnoreCase))
                    {
                        Core.Strings.cJavascripts.MessageShowBack("数据库表前缀必须以字母开头");

                        return;
                    }


                    #endregion


                    connectionString =
                        string.Format(@"Data Source={0};User ID={1};Password={2};Initial Catalog={3};Pooling=true",
                                      txtDatasource.Text, txtDataBaseUser.Text, txtDataBasePass.Text, txtDataBaseName.Text);
                    Session["SysDataBaseName"] = txtDataBaseName.Text;

                    tablePrefix = txtTableprefix.Text;
                    break;
                case "MySql":

                    #region 验证输入

                    //验证数据库名为空
                    if (txtMySqlDatasource.Text.Length == 0)
                    {
                        Core.Strings.cJavascripts.MessageShowBack("数据库名不能为空");
                        return;
                    }

                    //验证数据库表前缀不能为数字开头
                    if (!Regex.IsMatch(txtMySqlTableprefix.Text, "^[a-zA-Z_](.*)", RegexOptions.IgnoreCase))
                    {
                        Core.Strings.cJavascripts.MessageShowBack("数据库表前缀必须以字母开头");

                        return;
                    }

                    #endregion

                    connectionString = string.Format("Data Source={0};UserId={1}; Port={2};Password={3}; database={4}; charset=utf8;Allow User Variables=True", txtMySqlDatasource.Text, txtMySqlDataBaseUser.Text, txtSport.Text, txtMySqlDataBasePass.Text, txtMySqlDataBaseName.Text);
                    Session["SysDataBaseName"] = txtMySqlDataBaseName.Text;
                    tablePrefix = txtMySqlTableprefix.Text;
                    break;
            }

            if (!IsUserOut)
            {
                SetCmsDataConfigs(connectionString, selectDbType, tablePrefix);
            }
            else
            {
                SetUserDataConfigs(connectionString, selectDbType);
            }


        }
        private void SetUserDataConfigs(string connectionString, string selectDbType)
        {
            EbSite.Base.Configs.BaseCinfigs.ConfigsControl.Instance.ConnectionStringSysUser = connectionString;
            EbSite.Base.Configs.BaseCinfigs.ConfigsControl.Instance.DataLayerTypeUser = selectDbType;
            EbSite.Base.Configs.BaseCinfigs.ConfigsControl.Instance.TablePrefixUser = txtTableprefix.Text;
            EbSite.Base.Configs.BaseCinfigs.ConfigsControl.SaveConfig();

            Base.DataProfile.DbHelperUser.Instance.ResetDbProvider();

            if (!CheckConnectionUser())
            {

                Core.Strings.cJavascripts.MessageShowBack("用户数据库连接失败,请检查您填写的数据库信息");
                return;
            }
            else
            {

                Response.Redirect(Utils.HtmlEncode("step4.aspx"));
            }
        }
        private void SetCmsDataConfigs(string connectionString, string selectDbType, string tablePrefix)
        {



            if (!cbIsOutOfUser.Checked) //不分离用户数据库
            {
                EbSite.Base.Configs.BaseCinfigs.ConfigsControl.Instance.ConnectionStringSysCms = connectionString;
                EbSite.Base.Configs.BaseCinfigs.ConfigsControl.Instance.ConnectionStringSysUser = connectionString;
                EbSite.Base.Configs.BaseCinfigs.ConfigsControl.Instance.DataLayerType = selectDbType;
                EbSite.Base.Configs.BaseCinfigs.ConfigsControl.Instance.DataLayerTypeUser = selectDbType;
                EbSite.Base.Configs.BaseCinfigs.ConfigsControl.Instance.TablePrefix = tablePrefix;
                EbSite.Base.Configs.BaseCinfigs.ConfigsControl.Instance.TablePrefixUser = tablePrefix;
                EbSite.Base.Configs.BaseCinfigs.ConfigsControl.SaveConfig();

                EbSite.Base.DataProfile.DbHelperCms.Instance.ResetDbProvider();

                if (!CheckConnectionCms())
                {

                    Core.Strings.cJavascripts.MessageShowBack("连接数据库失败,请检查您填写的数据库信息");
                    return;
                }
                else
                {

                    Response.Redirect(Utils.HtmlEncode("step4.aspx"));
                }
            }
            else  //分离用户数据库
            {
                EbSite.Base.Configs.BaseCinfigs.ConfigsControl.Instance.ConnectionStringSysCms = connectionString;
                EbSite.Base.Configs.BaseCinfigs.ConfigsControl.Instance.DataLayerType = selectDbType;
                EbSite.Base.Configs.BaseCinfigs.ConfigsControl.Instance.TablePrefix = tablePrefix;
                EbSite.Base.Configs.BaseCinfigs.ConfigsControl.SaveConfig();

                Base.DataProfile.DbHelperCms.Instance.ResetDbProvider();

                if (!CheckConnectionCms())
                {

                    Core.Strings.cJavascripts.MessageShowBack("连接数据库失败,请检查您填写的数据库信息");
                    return;
                }
                else
                {

                    Response.Redirect(Utils.HtmlEncode("step3.aspx?uo=1"));
                }
            }
        }

        private bool CheckConnectionCms()
        {
            try
            {

                Base.DataProfile.DbHelperCms.Instance.ExecuteNonQuery("SELECT 1");
                return true;
            }
            catch
            {
                return false;
            }
        }

        private bool CheckConnectionUser()
        {
            try
            {

                Base.DataProfile.DbHelperUser.Instance.ExecuteNonQuery("SELECT 1");
                return true;
            }
            catch
            {
                return false;
            }
        }

    }
}
