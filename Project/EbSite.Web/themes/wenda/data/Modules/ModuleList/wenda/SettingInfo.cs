 using System;
using System.Collections.Generic;
using System.Web;
using EbSite.Base.Modules;

namespace EbSite.Modules.Wenda
{
    /// <summary>
    /// 类SettingInfo:系统配置实体，在这里可以添加相关配置属性，调用方法(可参考Setting.ascx):SettingInfo.Instance.CF
    /// 属性ModuleAttribute:是模块的重要信息，请认真填写
    /// </summary>
   [ModuleAttribute("问答", Version = "1.0.0", Author = "ebsite", AuthorUrl = "www.ebsite.net")]

    public class SettingInfo : Base.Modules.Configs.Configs//<SettingInfo>
    {

        public static readonly SettingInfo Instance = new SettingInfo();
        public SettingInfo()
        {

        }

        public override Guid CurrentModelID
        {
            get
            {
                return new Guid("4e0edb7e-1b30-41ad-9f74-d63c80458c35");
            }
        }
       // private bool _IsAllowUserAdd = false;
       // /// <summary>
       // /// 是否允许申请友情连接
       // /// </summary>
       // public bool IsAllowUserAdd
       // {
       //     get
       //     {
       //         return _IsAllowUserAdd;
       //     }
       //     set
       //     {
       //         _IsAllowUserAdd = value;
       //     }
       // }

       // private string _HaveOtherPrice = "a";
       // public string HaveOtherPrice
       // {
       //     get { return _HaveOtherPrice; }
       //     set { _HaveOtherPrice = value; }
       // }

       // private string _txtCatalog = "qft.ashx";
       ///// <summary>
       ///// 快速发帖子
       ///// </summary>
       // public string txtCatalog
       // {
       //     get { return _txtCatalog; }
       //     set { _txtCatalog = value; }
       // }


       // private string _contentpath;
       ///// <summary>
       ///// 内容显示连接地址相对
       ///// </summary>
       // public string  ContentPath
       // {
       //     get { return _contentpath; }
       //     set { _contentpath = value; }
       // }

       // private string _txtReplay = "qht.ashx";
       ///// <summary>
       ///// 快速回帖子
       ///// </summary>
       // public string txtReplay
       // {
       //     get { return _txtReplay; }
       //     set { _txtReplay = value; }
       // }

       

    }
}

