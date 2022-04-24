using System;
using System.Collections.Generic;
using System.Web;
using EbSite.Base.Modules;

namespace EbSite.Modules.CQ
{
    /// <summary>
    /// 类SettingInfo:系统配置实体，在这里可以添加相关配置属性，调用方法(可参考Setting.ascx):SettingInfo.Instance.CF
    /// 属性ModuleAttribute:是模块的重要信息，请认真填写
    /// </summary>
    [ModuleAttribute("订单宝CQ", Version = "1.0.0", Author = "小菜菜", AuthorUrl = "http://www.ebsite.net")]
    public class SettingInfo : EbSite.Base.Modules.Configs.Configs<SettingInfo>
    {
        override public Guid CurrentModelID
        {
            get
            {
                return new Guid("b456beef-6b3e-4caf-b282-fd17fc4c8684");
            }
        }
        public static readonly SettingInfo Instance = new SettingInfo();
        public SettingInfo()
        {
            //数据库连接及表前缘与系统相同
            //base.IsUserSysConn = true;
        }

		#region 扩展属性
		//在这里写自定义配置属性

	    #endregion

    }
}