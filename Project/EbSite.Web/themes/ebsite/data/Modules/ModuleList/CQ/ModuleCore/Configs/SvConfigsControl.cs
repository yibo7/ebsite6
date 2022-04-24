using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Web;
using EbSite.Base.Configs.ConfigsBase;

namespace EbSite.Modules.CQ.ModuleCore.Configs
{
    public class SvConfigsControl
    {

        private static ConfigsManager<SvConfigsInfo> BaseInstance;
        private static object _SyncRoot = new object();
        private static SvConfigsInfo _ConfigsEntity;
        static public SvConfigsInfo Instance
        {
            get 
            {
                if (_ConfigsEntity == null)
                {
                    lock (_SyncRoot)
                    {
                        if (_ConfigsEntity == null)
                        {
                            _ConfigsEntity = BaseInstance.LoadConfig();
                        }
                    }
                }

                return _ConfigsEntity;
            }
        }
        public static void SaveConfig()
        {
            BaseInstance.Save(Instance);
        }
        public static void SaveConfig(SvConfigsInfo Configs)
        {
            
            BaseInstance.Save(Configs);
        }
        static SvConfigsControl()
        {
            if (BaseInstance == null)
                BaseInstance = new ConfigsManager<SvConfigsInfo>(GetBaseConfigsPath);
        }
        private static string filename = null;
        static private string GetBaseConfigsPath
        {
            get
            {
                if (filename == null)
                {

                    string sP = string.Concat(Base.Host.Instance.GetModulePath(new Guid("b456beef-6b3e-4caf-b282-fd17fc4c8684")), "Datastore/Configs/");
                    HttpContext context = HttpContext.Current;
                    if (context != null)
                    {
                        filename = context.Server.MapPath(sP+"SvConfigs.config");
                        if (!File.Exists(filename))
                        {
                            filename = context.Server.MapPath(sP + "SvConfigs.config");
                        }
                    }
                    else
                    {
                        filename = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Base.config");

                        //AppDomain.CurrentDomain.BaseDirectory 如: E:\\myweb\\EbSite\\EbSite\\project\\web\\
                    }

                    if (!File.Exists(filename))
                    {
                        throw new Exception("发生错误: 虚拟目录或网站根目录下没有正确的Base.config文件");
                    }
                }
                return filename;
            }
        }

       static public void UpdateSettingJs()
        {
            string sPath = HttpContext.Current.Server.MapPath("../js/chatsetting.js");
            StringBuilder sb = new StringBuilder("var chatsetting = { ");
            sb.AppendFormat(" fx: \"{0}\", title: \"{1}\", showclose: {2},DemoModel:{3},ChatModel:{4},FloatListModel:{5},FloatPlaceModel:{6},Demo:\"{7}\",isfull:{8},top:{9},showmore: {10},outlink:'{11}',maxnum:{12},isoutlink:{13},welcome:'{14}',TimeSpan:{15},TimeSpanToAuto:{16},TimeSpanToAutoModel:{17},MaxReceive:{18},IsOpenAppraise:{19},IsOpenInvite:{20},InviteTimeSpan:{21},InviteInfo:'{22}',InviteModel:{23}",
                Instance.FloatPlaceModel == 1 ? "r" : "l",
                Instance.Title,
                Instance.IsShowClose == 1 ? "false" : "true",
                Instance.DemoModel,
                Instance.ChatModel,
                Instance.FloatListModel,
                Instance.FloatPlaceModel,
                Instance.Demo,
                (Instance.IsFull)?"true":"false",
                Instance.Top,
                Instance.IsShowMore == 1 ? "false" : "true",
                Instance.FloatServiceLink,
                Instance.FloatServiceMaxNum,
                Instance.IsServicerOutLink?"true":"false",
                Instance.WelcomeInfo,
                Instance.TimeSpan,
                Instance.TimeSpanToAuto,
                Instance.TimeSpanToAutoModel,
                Instance.MaxReceive,
                Instance.IsOpenAppraise.ToString().ToLower(),
                Instance.IsOpenInvite.ToString().ToLower(),
                Instance.InviteTimeSpan,
                Instance.InviteInfo,
                Instance.InviteModel
                );
            sb.Append(" };");


            Core.FSO.FObject.WriteFileUtf8(sPath, sb.ToString());
        }

    }
}
