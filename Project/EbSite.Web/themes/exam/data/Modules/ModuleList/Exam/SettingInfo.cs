using System;
using System.Collections.Generic;
using System.Web;
using EbSite.Base.Modules;

namespace EbSite.Modules.Exam
{
    /// <summary>
    /// 类SettingInfo:系统配置实体，在这里可以添加相关配置属性，调用方法(可参考Setting.ascx):SettingInfo.Instance.CF
    /// 属性ModuleAttribute:是模块的重要信息，请认真填写
    /// </summary>
    [ModuleAttribute("考试系统", Version = "1.0.0", Author = "eBSite模块开发组", AuthorUrl = "http://www.ebsite.net")]
    public class SettingInfo : EbSite.Base.Modules.Configs.Configs<SettingInfo>
    {
        override public Guid CurrentModelID
        {
            get
            {

                return new Guid("5a2d821b-586c-4ac4-bdac-1567d5d1a515");
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