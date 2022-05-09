using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Web.UI;
using EbSite.Control;

namespace EbSite.ControlData
{
    [DefaultProperty("Text"), ToolboxData("<{0}:SelTempFields runat=server></{0}:SelTempFields>")]
    public class SelTempFields : EasyuiDialog
    {
        private SelTempFieldType _FieldType = SelTempFieldType.部件;
        public SelTempFieldType FieldType
        {
            get { return _FieldType; }
            set { _FieldType = value; }
        }
        public SelTempFields()
        {
            
            this.Load += SelTempFields_Load;
            this.IsDialog = true;//2022-5-9
            //this.IsModal = false;
            //this.IsFull = false;
        }

        private int _theretype;
        /// <summary>
        /// 来自的皮肤类型,1为pc,2这移动
        /// </summary>
        public int ThemesType
        {
            get
            {
                if (_theretype>0)
                {
                    return _theretype;
                }
                return 1;
            }
            set { _theretype = value; }
        }

        private string _therename;
        /// <summary>
        /// 当前站点皮肤
        /// </summary>
        public string CurrentThemeName
        {
            get { return _therename; }
            set { _therename = value; }
        }
        private void SelTempFields_Load(object sender,EventArgs e)
        {
            
            this.Href = string.Concat(EbSite.Base.AppStartInit.AdminPath, string.Format( "dialog/seltempfields.aspx?t={0}&tt={1}&theme={2}", (int)FieldType,ThemesType,CurrentThemeName )); 
        }
    }

    public enum SelTempFieldType
    {
        部件,
        分类字段,
        内容字段,
        专题字段,
        用户字段,
        常用变量,
        函数,
        连接,
        inclue代码
    }
   


}
