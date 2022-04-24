using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using EbSite.Base.DataProfile;
using EbSite.Control;
using EbSite.Core;
using EbSite.Entity;

namespace EbSite.BLL
{
    public class ReportConfigBll
    {
        public List<EbSite.Core.JsonFile<Entity.ReportConfig>> configsJsonFiles = new List<JsonFile<ReportConfig>>();
        //public List<Entity.ReportConfig> Configs = new List<Entity.ReportConfig>();
        public ReportConfigBll()
        {
            string sPath = string.Concat(EbSite.Base.Host.Instance.IISPath, "Datastore/ReportConfigs/");
            FileInfo[] fs = Core.FSO.FObject.GetFileListByType(sPath, "json");
            foreach ( FileInfo md in fs)
            {
                JsonFile<Entity.ReportConfig> jsonFile = new JsonFile<Entity.ReportConfig>(md.FullName);
                configsJsonFiles.Add(jsonFile);
                //Configs.Add(jsonFile.Model);
            }
        }

        public Entity.ReportConfig GetConfigById(string configid)
        {
            foreach (EbSite.Core.JsonFile <Entity.ReportConfig> md in configsJsonFiles)
            {
                if (md.Id.Equals(configid))
                    return md.Model;
            }

            return null;
        }

        public DataSet GetDefaultData(string configid)
        {
            Entity.ReportConfig model = GetConfigById(configid);
            return RunSql(model);
            //return DbHelperCms.Instance.ExecuteDataset(CommandType.Text, model.DefaultSql);

        }

        public DataSet RunQuery(string configid,List<ExtensionsCtrls> Ctrs)
        {
            //构建sql语句
            Entity.ReportConfig mdConfig = GetConfigById(configid);
            string sql = mdConfig.QuerySql;
            foreach (var ctrModel in Ctrs)
            {
                sql = sql.Replace(ctrModel.ID, ctrModel.CtrlValue);
            }
            return RunSql(mdConfig, sql);
            //return DbHelperCms.Instance.ExecuteDataset(CommandType.Text, sql);

        }

        private DataSet RunSql(Entity.ReportConfig mdConfig)
        {
            return RunSql(mdConfig, mdConfig.DefaultSql);
        }

        private DataSet RunSql(Entity.ReportConfig mdConfig,string sql)
        {
            if (EbSite.Base.Configs.SysConfigs.ConfigsControl.Instance.IsOpenSql)
            {
                HttpContext.Current.Response.Write(string.Format("当前执行的SQL:{0}", sql));
            }
            if (string.IsNullOrEmpty(sql))
                return null;
            if (mdConfig.DalType == 1)
            {
                return DbHelperUser.Instance.ExecuteDataset(CommandType.Text, sql);
            }
            else
            {
                return DbHelperCms.Instance.ExecuteDataset(CommandType.Text, sql);
            }
        }

    }
}
