using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ComponentModel;




namespace EbSite.Control
{
	/// <summary>
	/// DataList 控件。
	/// </summary>
	[DefaultProperty("Text"),ToolboxData("<{0}:DataList runat=server></{0}:DataList>")]
	public class DataList : System.Web.UI.WebControls.DataList
	{
        /// <summary>
        /// 构造函数
        /// </summary>
		public DataList(): base()
		{
			this.Height=30; 
			this.BorderStyle=BorderStyle.Dotted; 
			this.BorderWidth=0; 
		}

       


	
	}
}
