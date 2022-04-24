using System;
using System.Collections.Generic;
using System.Web;
using EbSite.Base.Modules;

namespace EbSite.Modules.BBS
{
    /// <summary>
    /// 类SettingInfo:系统配置实体，在这里可以添加相关配置属性，调用方法(可参考Setting.ascx):SettingInfo.Instance.CF
    /// 属性ModuleAttribute:是模块的重要信息，请认真填写
    /// </summary>
    [ModuleAttribute("官方论坛", Version = "1.5.0", Author = "eBSite", AuthorUrl = "www.ebsite.net")]
    public class SettingInfo : EbSite.Base.Modules.Configs.Configs//<SettingInfo>
    {
        public static readonly SettingInfo Instance = new SettingInfo();
        override public Guid CurrentModelID
        {
            get
            {
                return new Guid("b3eef4b1-6c2c-4528-9e15-ad33716238ce");
            }
        }


        public SettingInfo()
        {
            //数据库连接及表前缘与系统相同
            //base.IsUserSysConn = true;
        }

		//#region 扩展属性
		////在这里写自定义配置属性
  //      public string TestTitle { get; set; }
	 //   #endregion

    }
}