using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using EbSite.Base.Extension;
using EbSite.Base.Extension.Manager;

namespace Plugins
{

    /// <summary>
    /// Converts BBCode to XHTML in the comments.
    /// </summary>
    [Extension("可以给网站添加一些小公告", "1.0", "<a href=\"http://www.ebsite.net\">小菜菜</a>")]
    public class Bulletin
    {

        static protected ExtensionSettings _settings = null;
      
        /// <summary>
        /// Hooks up an event handler to the Post.Serving event.
        /// </summary>
        static Bulletin()
        {
            //Post.Serving += new EventHandler<ServingEventArgs>(Post_Serving);

            //ExtensionManager.SetAdminPage("查看公告", "/Bulletin.aspx");


            //(注意，注意)要与类名相同,否则无法生成相关配置
            string sSettingsName = "Bulletin";          

            ExtensionSettings settings = new ExtensionSettings(sSettingsName);            
            settings.AddParameter("Title", "公告标题", 20, true, true); 
            //ParameterType 内容控件类别
            settings.AddParameter("Description", "公告内容", 300, true, false, ParameterType.StringHtml);
            //测试上传图片
            settings.AddParameter("UploadImg", "上传图片", 200, true, false, ParameterType.Upload); 
            //settings.IsScalar = true; //注意，这里不能启用这个属性，因为是多条数据展示，默认不将settings.IsScalar = true的配置将以数据列表保存

            ExtensionManager.Instance.ImportSettings(settings);

            _settings = ExtensionManager.Instance.GetSettings(sSettingsName);

        }

        /**/
        /// <summary>
        /// 获取公告列表
        /// </summary>
        public static DataTable GetBulletinList()
        {
            
            return _settings.GetDataTable();
        }
        public static DataRow GetBulletinByID(string ID)
        {
            return _settings.GetRowByID(ID);
        }

    }

}
