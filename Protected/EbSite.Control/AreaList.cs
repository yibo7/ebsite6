using System;
using System.Collections;
using System.Data;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.ComponentModel;

namespace EbSite.Control
{
    /// <summary>
    /// 编辑器
    /// </summary>
    [DefaultEvent("Click"), DefaultProperty("Text"), ToolboxData("<{0}:AreaList runat=server></{0}:AreaList>")]
    public class AreaList : DropDownListMore
    {

        public AreaList()
        {
            base.ApiName = ServiceApiName.wcf;//设置控件调用的方式
            base.ApiFunctionName = "GetAlear";
        }

        public string Address
        {
            get
            {
                if (!string.IsNullOrEmpty(hfValue.Value))
                {
                    BLL.AreaInfo.Instance.GetAddressByID(int.Parse(hfValue.Value));
                }
                return "";
            }

        }
        override public string GetModifyParentIDs()
        {
            if (!string.IsNullOrEmpty(Value))
            {
                int cityid = 0;
                string cityname = "";
                int provinceid = 0;
                string provincename = "";
                return EbSite.BLL.AreaInfo.Instance.GetListParentIDs(int.Parse(Value), out  cityid, out  cityname, out   provinceid, out  provincename);
            }
            return "";
        }
    }





}
