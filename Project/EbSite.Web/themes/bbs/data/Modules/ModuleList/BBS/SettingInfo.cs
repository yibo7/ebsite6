using System;
using System.Collections.Generic;
using System.Web;
using EbSite.Base.Modules;

namespace EbSite.Modules.BBS
{
    /// <summary>
    /// ��SettingInfo:ϵͳ����ʵ�壬����������������������ԣ����÷���(�ɲο�Setting.ascx):SettingInfo.Instance.CF
    /// ����ModuleAttribute:��ģ�����Ҫ��Ϣ����������д
    /// </summary>
    [ModuleAttribute("�ٷ���̳", Version = "1.5.0", Author = "eBSite", AuthorUrl = "www.ebsite.net")]
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
            //���ݿ����Ӽ���ǰԵ��ϵͳ��ͬ
            //base.IsUserSysConn = true;
        }

		//#region ��չ����
		////������д�Զ�����������
  //      public string TestTitle { get; set; }
	 //   #endregion

    }
}