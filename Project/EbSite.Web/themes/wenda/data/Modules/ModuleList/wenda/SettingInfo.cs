 using System;
using System.Collections.Generic;
using System.Web;
using EbSite.Base.Modules;

namespace EbSite.Modules.Wenda
{
    /// <summary>
    /// ��SettingInfo:ϵͳ����ʵ�壬����������������������ԣ����÷���(�ɲο�Setting.ascx):SettingInfo.Instance.CF
    /// ����ModuleAttribute:��ģ�����Ҫ��Ϣ����������д
    /// </summary>
   [ModuleAttribute("�ʴ�", Version = "1.0.0", Author = "ebsite", AuthorUrl = "www.ebsite.net")]

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
       // /// �Ƿ�����������������
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
       ///// ���ٷ�����
       ///// </summary>
       // public string txtCatalog
       // {
       //     get { return _txtCatalog; }
       //     set { _txtCatalog = value; }
       // }


       // private string _contentpath;
       ///// <summary>
       ///// ������ʾ���ӵ�ַ���
       ///// </summary>
       // public string  ContentPath
       // {
       //     get { return _contentpath; }
       //     set { _contentpath = value; }
       // }

       // private string _txtReplay = "qht.ashx";
       ///// <summary>
       ///// ���ٻ�����
       ///// </summary>
       // public string txtReplay
       // {
       //     get { return _txtReplay; }
       //     set { _txtReplay = value; }
       // }

       

    }
}

