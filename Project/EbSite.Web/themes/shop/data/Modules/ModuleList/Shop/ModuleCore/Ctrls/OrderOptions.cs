using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Modules.Shop.ModuleCore.Entity;
using DropDownList = EbSite.Control.DropDownList;
using RadioButtonList = EbSite.Control.RadioButtonList;

namespace EbSite.Modules.Shop.ModuleCore.Ctrls
{
    public enum ShowType
    {
        下拉列表=0,
        列表选择=1
    }
     [DefaultEvent("Click"), DefaultProperty("Text"), ToolboxData("<{0}:OrderOptions runat=server></{0}:OrderOptions>")]
    public class OrderOptions :UserControl
    {
         public ShowType _ST = ShowType.下拉列表;
         public ShowType ST
         {
             get
             {
                 return _ST;
             }
             set
             {
                 _ST = value;
             }
         }
         public List<EbSite.Entity.OrderOptionItems> Datasource { get; set; }
         private string GetItemName(EbSite.Entity.OrderOptionItems optionItem)
         {

             string sname = optionItem.ItemName;
             if(optionItem.AppendMoney>0)
             {
                 if(optionItem.CalculateMode==0)  //固定金额
                 {
                     sname = string.Concat(sname, "(+", optionItem.AppendMoney, "元)");
                 }
                 else //百分比
                 {
                     sname = string.Concat(sname, "(+", optionItem.AppendMoney, "%)");
                 }
             }
             return sname;
         }
         public string CtrClientID { get; set; }
         protected override void Render(HtmlTextWriter output)
         {
            

             if (ST == ShowType.下拉列表)
             {
                 output.Write("<select name=\"" + this.CtrClientID + "\" id=\"" + this.CtrClientID + "\" onchange=\"On_OrderOptionItem1(this)\">");
	              output.Write("<option selected=\"selected\" value=\"\">请选择</option>");
	              

                  foreach (EbSite.Entity.OrderOptionItems optionItem in Datasource)
                  {
                      output.Write(string.Concat("<option percent=\"", optionItem.CalculateMode, "\" appendmoney=\"", optionItem.AppendMoney, "\" value=\"", optionItem.id, "\" isinput=\"", ((optionItem.IsUserInputRequired) ? "true" : "false"), "\">", GetItemName(optionItem), "</option>"));
                  }

                  output.Write("</select>");

             }
             else
             {
                 output.Write("<table  cellpadding=\"0\" cellspacing=\"0\">");
                 output.Write("<tr>");

                 output.Write("<td>");
                 output.Write(string.Concat("<input  type=\"radio\" percent=\"0\" appendmoney=\"0\" id=\"", this.CtrClientID, "0\" name=\"", this.CtrClientID, "\" value=\"0\" onclick=\"On_OrderOptionItem2(this);\" isinput=\"false\" /><label for=\"", this.CtrClientID,  "0\">无(+0元)</label>"));
                 output.Write("</td>");
                 int index = 1;

                 foreach (EbSite.Entity.OrderOptionItems optionItem in Datasource)
                 {
                     output.Write("<td>");
                     output.Write(string.Concat("<input  type=\"radio\" percent=\"", optionItem.CalculateMode, "\" appendmoney=\"", optionItem.AppendMoney, "\" id=\"", this.CtrClientID, index, "\" name=\"", this.CtrClientID, "\" value=\"", optionItem.id, "\" onclick=\"On_OrderOptionItem2(this);\" isinput=\"", ((optionItem.IsUserInputRequired) ? "true" : "false"), "\" /><label for=\"", this.CtrClientID, index, "\">", GetItemName(optionItem), "</label>"));
                     output.Write("</td>");
                     index++;
                 }
               

                 output.Write("</tr>");
                 output.Write("</table>");
                
             }
         }

         public OrderOptions()
        {
            
        }
    }
}