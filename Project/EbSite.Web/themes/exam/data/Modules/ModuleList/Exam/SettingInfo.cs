using System;
using System.Collections.Generic;
using System.Web;
using EbSite.Base.Modules;

namespace EbSite.Modules.Exam
{
    /// <summary>
    /// ��SettingInfo:ϵͳ����ʵ�壬����������������������ԣ����÷���(�ɲο�Setting.ascx):SettingInfo.Instance.CF
    /// ����ModuleAttribute:��ģ�����Ҫ��Ϣ����������д
    /// </summary>
    [ModuleAttribute("����ϵͳ", Version = "1.0.0", Author = "eBSiteģ�鿪����", AuthorUrl = "http://www.ebsite.net")]
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
            //���ݿ����Ӽ���ǰԵ��ϵͳ��ͬ
            //base.IsUserSysConn = true;
        }

		#region ��չ����
		//������д�Զ�����������

	    #endregion

    }
}