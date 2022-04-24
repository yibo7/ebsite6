using System;
using System.Collections.Generic;
using EbSite.Base.Entity;

namespace EbSite.Entity
{
    [Serializable]
    public class ListItemModels
    {
        public List<ListItemModel> Items = new List<ListItemModel>();
        public string CtrID;
        private string _CtrName = "";
        public string CtrName
        {
            set { _CtrName = value; }
            get { return _CtrName; }
        }
    }
	/// <summary>
	/// 实体类Website 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
    public class WidgetBoxStyle : XmlEntityBase<Guid>
    {
	    public string CtrColorName(string ctrIndex)
	    {
            return string.Concat("wdColor", ctrIndex);
	    }
        //public string CtrCssName(string ctrIndex)
        //{
        //    return string.Concat("wdCSS", ctrIndex);
        //}
        public string GetOneCustomColorValue(int iIndex, string CustomColors)
        {
            string[] aColor = CustomColors.Split(',');
            if (aColor.Length > iIndex)
                return aColor[iIndex];
            return "";
        }
        public string GetOneCustomTextBoxValue(int iIndex, string CustomTextBoxValues)
        {
            string[] aValue = CustomTextBoxValues.Split('^');
            if (aValue.Length > iIndex)
                return aValue[iIndex];
            return "";
        }
        public string GetOneCustomDrpValue(int iIndex, string DrpValues)
        {
            string[] aDrpItemValues = DrpValues.Split('^');
            if (aDrpItemValues.Length > iIndex)
                return aDrpItemValues[iIndex];
            return "";
        }
	    private string _StyleName;
        private string _StyleTemp;
	    private int _ThemeID = 0; //适应皮肤
        private int _StyleClass = 0; //类别，边框的适用类型，0代表EbSite，1代表个空间

	    private string _StyleColorPram = "";
        /// <summary>
        /// 这是一个高级选项，颜色参数，参数格式为 显示标题1|显示标题2
        /// 如 边框颜色|标题背景色|内容背景色
        /// 在模板里这样获取对应的颜色 {边框颜色} {标题背景色} {内容背景色}
        /// </summary>
        public string StyleColorPram
        {
            set { _StyleColorPram = value; }
            get { return _StyleColorPram; }
        }

        private string _CustomDropDownListPram = "";
        /// <summary>
        /// 这是一个高级选项(由于用图片做成的样式，不能用颜色替换，所以可以采用这个参数来判断)，
        /// 参数格式为 风格=列表项名称1&列表项值1,列表项名称2&列表项值2|渐变方向=列表项名称1&列表项值1,列表项名称2&列表项值2
        /// 在模板里这样获取对应的选项值 {风格} {渐变方向}
        /// </summary>
        public string CustomDropDownListPram
        {
            set { _CustomDropDownListPram = value; }
            get { return _CustomDropDownListPram; }
        }

        private string _CustomTextBoxPram = "";
        /// <summary>
        /// 这是一个高级选项(文件输入框)，
        /// 参数格式为 显示标题1=模式*高*宽*说明|显示标题2=模式*高*宽*说明
        /// 在模板里这样获取对应的选项值 {显示标题1} {显示标题2}，说明可以不填写
        /// 其中有模式 0代表单行文本框，1代表多行文件框 
        /// </summary>
        public string CustomTextBoxPram
        {
            set { _CustomTextBoxPram = value; }
            get { return _CustomTextBoxPram; }
        }
       

	    public List<ListItemModels> CustomDropDownListPramList()
        {

           
                //List<ListItemModel> lst = new List<ListItemModel>();

                List<ListItemModels> lst = new List<ListItemModels>();

                string[] sList = CustomDropDownListPram.Split('|');
                for (int i = 0; i < sList.Length; i++)
                {

                    string[] oneitem = sList[i].Split('=');
                    if (oneitem.Length == 2)
                    {
                        ListItemModels mds = new ListItemModels();
                        mds.CtrName = oneitem[0];
                        mds.CtrID = string.Concat("wdDrp",i);
                        string[] subitems = oneitem[1].Split(',');

                        for (int j = 0; j < subitems.Length; j++)
                        {
                            string[] subitem = subitems[j].Split('&');
                            if (subitem.Length == 2)
                                mds.Items.Add(new ListItemModel(subitem[0], subitem[1]));
                        }

                        lst.Add(mds);
                     
                    }

                    //string[] oneitem = sList[i].Split('&');
                    //if (oneitem.Length==2)
                    //    lst.Add(new ListItemModel(oneitem[0], oneitem[1]));
                }
                return lst;
            
        }

        /// <summary>
        /// 样式名称
        /// </summary>
        public string StyleName
        {
            set { _StyleName = value; }
            get { return _StyleName; }
        }
        /// <summary>
        /// 样式模板 #WidgetTitle# #WidgetContent#
        /// </summary>
        public string StyleTemp
        {
            set { _StyleTemp = value; }
            get { return _StyleTemp; }
        }
        /// <summary>
        /// 适用皮肤,0为适用所有
        /// </summary>
        public int ThemeID
        {
            set { _ThemeID = value; }
            get { return _ThemeID; }
        }
        /// <summary>
        /// 边框的适用类型，0代表EbSite，1代表个空间
        /// </summary>
        public int StyleClass
        {
            set { _StyleClass = value; }
            get { return _StyleClass; }
        }

	}
}

