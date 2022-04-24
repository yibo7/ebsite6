
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Text;
using EbSite.Base.ExtWidgets.WidgetsManage;

namespace EbSite.Widgets.FlashPic
{
    public partial class widget : WidgetBase
    {
        public override void LoadData()
        {
            if (!base.IsPostBack)
            {
                
                
            }
        }
        protected string GetFlashInfo()
        {
            StringBuilder sb = new StringBuilder();
            string ranID = Core.Strings.GetString.RandomNUM(3);
            sb.Append("var linkarr#ID# = new Array();var picarr#ID# = new Array();var textarr#ID# = new Array();");

            StringDictionary settings = GetSettings();
            if (settings.ContainsKey("width"))
            {
                sb.AppendFormat("var swf_width#ID# = {0};", settings["width"]);

            }

            if (settings.ContainsKey("heith"))
            {
                sb.AppendFormat(" var swf_height#ID# = {0};\n\t", settings["heith"]);
            }

            sb.Append("var files#ID# = '';var links#ID# = ''; var texts#ID# = '';");

            DataTable dt = GetSettingsTable();
            
            if (!Equals(dt, null))
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    sb.AppendFormat("linkarr#ID#[{0}] = \"{1}\";", i + 1, dt.Rows[i]["url"]);
                    sb.AppendFormat("picarr#ID#[{0}] = \"{1}\";", i + 1, dt.Rows[i]["flashpath"]);
                }
            }
            string sFun =
             "for (i = 1; i < picarr#ID#.length; i++) {if (files#ID# == '') {files#ID# = picarr#ID#[i];}else {files#ID# += '|' + picarr#ID#[i];}};for (i = 1; i < linkarr#ID#.length; i++) {if (links#ID# == '') {links#ID# = linkarr#ID#[i];}else {links#ID# += '|' + linkarr#ID#[i];}};for (i = 1; i < textarr#ID#.length; i++) {if (texts#ID# == '') {texts#ID# = textarr[i];}else {texts#ID# += '|' + textarr#ID#[i];}};";
            sb.Append(sFun);


            sb.Append("document.write('<object style=\" margin-left:6px;\" classid=\"clsid:d27cdb6e-ae6d-11cf-96b8-444553540000\" codebase=\"http://fpdownload.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=6,0,0,0\" width=\"' + swf_width#ID# + '\" height=\"' + swf_height#ID# + '\">');");
            sb.Append("document.write('<param name=\"movie\" value=\"#IISPATH#flash/flash.swf\"><param name=\"quality\" value=\"high\">');");
            sb.Append("document.write('<param name=\"menu\" value=\"false\"><param name=wmode value=\"opaque\">');");
            sb.Append("document.write('<param name=\"FlashVars\" value=\"bcastr_file=' + files#ID# + '&bcastr_link=' + links#ID# + '&bcastr_config=0xffffff|2|0x8CA2AD|60|0xffffff|0xff9900|0x000033|2|3|1|_blank\">');");
            sb.Append("document.write('<embed src=\"#IISPATH#flash/flash.swf\" wmode=\"opaque\" FlashVars=\"bcastr_file=' + files#ID# + '&bcastr_link=' + links#ID# + '&bcastr_title=' + texts#ID# + '& menu=\"false\" quality=\"high\" width=\"' + swf_width#ID# + '\" height=\"' + swf_height#ID# + '\" type=\"application/x-shockwave-flash\" pluginspage=\"http://www.macromedia.com/go/getflashplayer\" />');");
            sb.Append("document.write('</object>'); ");

            return sb.ToString().Replace("#ID#", ranID).Replace("#IISPATH#",Base.AppStartInit.IISPath);
        }
        public override List<string> InitColumns()
        {
            List<string> lst = new List<string>();
            lst.Add("flashpath");
            lst.Add("url");
            return lst;
        }
        public override string Name
        {
            get { return "FlashPic"; }
        }

        public override bool IsEditable
        {
            get { return true; }
        }
        
    }
}