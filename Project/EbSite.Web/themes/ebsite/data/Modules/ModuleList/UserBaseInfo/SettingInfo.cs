using System;
using System.Collections.Generic;
using System.Web;
using EbSite.Base.Modules;

namespace EbSite.Modules.UserBaseInfo
{
    /// <summary>
    /// 类SettingInfo:系统配置实体，在这里可以添加相关配置属性，调用方法(可参考Setting.ascx):SettingInfo.Instance.CF
    /// 属性ModuleAttribute:是模块的重要信息，请认真填写
    /// </summary>
    [Module("eBSite用户中心", Version = "1.0.0", Author = "小菜", AuthorUrl = "http://www.ebsite.net")]
    public class SettingInfo : Base.Modules.Configs.Configs//<SettingInfo>
    {
        public static readonly SettingInfo Instance = new SettingInfo();
        override public Guid CurrentModelID
        {
            get
            {
                
                return new Guid("8961c5b2-43f2-4298-8145-f0965aff70a0");
            }
        }

        //public SettingInfo()
        //{
        //    //数据库连接及表前缘与系统相同
        //    //base.IsUserSysConn = false;
           
        //}
        //private string _FavoriteName = "收藏夹";
        ///// <summary>
        ///// 收藏名称
        ///// </summary>
        //public string FavoriteName
        //{
        //    get
        //    {
        //        return _FavoriteName;
        //    }
        //    set
        //    {
        //        _FavoriteName = value;
        //    }
        //}


        //private string _UseMyDemainGroup = "-1";
        ///// <summary>
        ///// 可以使用个性域名的用户级别
        ///// </summary>
        //public string UseMyDemainGroup
        //{
        //    get
        //    {
        //        return _UseMyDemainGroup;
        //    }
        //    set
        //    {
        //        _UseMyDemainGroup = value;
        //    }
        //}



        //private string _AllowModifyDefaultTabGroup = "-1";
        ///// <summary>
        ///// 允许操作默认空间菜单的用户级别
        ///// </summary>
        //public string AllowModifyDefaultTabGroup
        //{
        //    get
        //    {
        //        return _AllowModifyDefaultTabGroup;
        //    }
        //    set
        //    {
        //        _AllowModifyDefaultTabGroup = value;
        //    }
        //}



        //private string _AllowModifyTabGroup = "-1";
        ///// <summary>
        ///// 允许修改空间菜单的用户级别
        ///// </summary>
        //public string AllowModifyTabGroup
        //{
        //    get
        //    {
        //        return _AllowModifyTabGroup;
        //    }
        //    set
        //    {
        //        _AllowModifyTabGroup = value;
        //    }
        //}



        //private string _AllowAddTabGroup = "-1";
        ///// <summary>
        ///// 允许添加空间菜单的用户级别
        ///// </summary>
        //public string AllowAddTabGroup
        //{
        //    get
        //    {
        //        return _AllowAddTabGroup;
        //    }
        //    set
        //    {
        //        _AllowAddTabGroup = value;
        //    }
        //}



        //private string _AllowOrderTabGroup = "-1";
        ///// <summary>
        ///// 允许排序空间菜单的用户级别
        ///// </summary>
        //public string AllowOrderTabGroup
        //{
        //    get
        //    {
        //        return _AllowOrderTabGroup;
        //    }
        //    set
        //    {
        //        _AllowOrderTabGroup = value;
        //    }
        //}



        //private string _UseThemeGroup = "-1";
        ///// <summary>
        ///// 允许更换皮肤的用户级别
        ///// </summary>
        //public string UseThemeGroup
        //{
        //    get
        //    {
        //        return _UseThemeGroup;
        //    }
        //    set
        //    {
        //        _UseThemeGroup = value;
        //    }
        //}



        //private string _UseLayout = "-1";
        ///// <summary>
        ///// 允许更换版式的用户级别
        ///// </summary>
        //public string UseLayout
        //{
        //    get
        //    {
        //        return _UseLayout;
        //    }
        //    set
        //    {
        //        _UseLayout = value;
        //    }
        //}



        //private string _UseWidgets = "-1";
        ///// <summary>
        ///// 允许更换部件的用户级别
        ///// </summary>
        //public string UseWidgets
        //{
        //    get
        //    {
        //        return _UseWidgets;
        //    }
        //    set
        //    {
        //        _UseWidgets = value;
        //    }
        //}

        //private string _AllowOpenSiteGroup = "-1";
        ///// <summary>
        ///// 允许开通个人空间的用户级别
        ///// </summary>
        //public string AllowOpenSiteGroup
        //{
        //    get
        //    {
        //        return _AllowOpenSiteGroup;
        //    }
        //    set
        //    {
        //        _AllowOpenSiteGroup = value;
        //    }
        //}

    }
}