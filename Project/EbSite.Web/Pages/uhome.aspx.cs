using System;
using System.Text;
using System.Web;
using EbSite.Base.Page;
using EbSite.Core;

namespace EbSite.Web.Pages
{
    public partial class uhome : MPForSpace
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                rpTabs.DataSource = EbSite.BLL.SpaceTabs.Instance.GetTabsByUserID(CurrentUserID);
                rpTabs.DataBind();

                if(llBaseInfo!=null)
                {
                    if(IsMyPlace)
                    {
                        if (IsAllowAddTabGroup)
                        {
                            //加入这个js后，在jquery 1.4.3之后，出现部件错乱
                            //string sJsHtml = "<div id=\"divAddClass\" title=\"添加分类\" style=\" display:none; padding:30px;\"> 分类名称:<input type=\"text\" id=\"txtPlaceClassName\" size=\"15\" /> <input type=\"hidden\" id=\"CustomValueHidden\" /></div><style> .widget-place { border:1px dotted #ccc;margin:1px;}.modifytab { width:80px; padding-top:20px;} .modifytab div{ padding:3px; border:1px solid #ccc; margin:5px; cursor:pointer;}</style><script>$(document).ready(function () { $(\".widgetmain\").find(\".widget-place\").each(function (i) { var iwidth = parseInt($(this).css(\"width\")); iwidth = iwidth - 1; $(this).css(\"width\", iwidth + \"%\"); }); }); </script>";
                            string sJsHtml =
                                "<div id=\"divAddClass\" title=\"添加分类\" style=\" display:none; padding:30px;\"> 分类名称:<input type=\"text\" id=\"txtPlaceClassName\" size=\"15\" /> <input type=\"hidden\" id=\"CustomValueHidden\" /></div><style> .widget-place { border:1px dotted #ccc;margin:1px;}.modifytab { width:80px; padding-top:20px;} .modifytab div{ padding:3px; border:1px solid #ccc; margin:5px; cursor:pointer;}</style>";
                            llBaseInfo.Text = sJsHtml;
                        }
                    }
                    
                }
                else
                {
                    Tips("模板出错了", "模块底部缺少llBaseInfo控件,请加入此控件后再做偿试");
                }
            }
        }
        #region 杨欢乐添加 判断用户级别   允许添加空间菜单的用户级别
        private bool IsAllowAddTabGroup
        {
            get
            {
                bool k = true;
                //int level = int.Parse(EbSite. SettingInfo.Instance.GetSysConfig.Instance.ModifyDefaultTabGroup);
                //if (EbSite.Base.Host.Instance.UserLevel >= level)
                //{
                //    k = true;
                //}
                return k; 
            }
           
        }
        #endregion
        #region 杨欢乐添加 判断用户级别   允许操作默认空间菜单的用户级别
        private bool IsModifyDefaultTabGroup
        {
            get
            {
                bool k = true;
                //int level = int.Parse(EbSite. SettingInfo.Instance.GetSysConfig.Instance.ModifyDefaultTabGroup);
                //if (EbSite.Base.Host.Instance.UserLevel >= level)
                //{
                //    k = true;
                //}
                return k;
            }
            
        }
        #endregion
        protected string GetManageLink(object id,object TabName)
        {
            if (IsMyPlace)
            {
                if (IsModifyDefaultTabGroup)
                {
                    return string.Concat("onmouseover=\"TipsClickClose(this,'<div class=modifytab><div title=", TabName,
                                         " onclick=AddSpaceTab(this,", id, ")> 修 改 </div><div onclick=DeleteTab(", id,
                                         ")> 删 除 </div><div onclick=AddSpaceTabSub(this,", id,
                                         ")> 添加(子) </div></div>')\"");
                }
                else
                {
                    return string.Empty;
                }
            }
            else
            {
                return string.Empty;
            }
            
        }
        protected string ToolBarFloatTop()
        {
            StringBuilder  sbHtml = new StringBuilder();
            if(IsMyPlace)
            {
                sbHtml.Append("<table  id=\"float-toptools\"><tr><td>");
                sbHtml.AppendFormat("<input type=\"button\" onclick=\"window.open('{0}')\" value=\"预览效果\" />",GetViewUrl);
                sbHtml.Append("<input type=\"button\" onclick=\"OpenTheme()\" value=\"更换皮肤\" />");
                sbHtml.Append("<input type=\"button\" onclick=\"OpenLayout()\" value=\"更换版式\" />");
                sbHtml.Append("<input type=\"button\" onclick=\"OpenWidgets()\" value=\"添加部件\" />");
                sbHtml.Append("<input type=\"button\" onclick=\"EditTheme()\" value=\"编辑皮肤\" />");
                sbHtml.Append("</div>");
                sbHtml.Append("<script type=\"text/javascript\">");
                sbHtml.Append("ToolsBarFloatTop();");
                sbHtml.Append("</script></td></tr></table>");

            }
            return sbHtml.ToString();
        }
        protected string GetViewUrl
        {
            get
            {
                return string.Concat("?tab=", CurrentTabID, "&uid=", CurrentUserID, "&v=1");
            }
            
        }
        protected string GetTabUrl(object tabid)
        {
            if (Request.QueryString["v"] != "1")
            {
                return string.Concat("?tab=", tabid, "&uid=", CurrentUserID);
            }
            else
            {
                return string.Concat("?tab=", tabid, "&uid=", CurrentUserID,"&v=1");
            }

            
        }
        protected string GetCurrentCss(object tabid)
        {
            return GetCurrentCss(tabid, "selectedtab");
        }

        protected string GetCurrentCss(object tabid,string cssname)
        {
            int iTabID = int.Parse(tabid.ToString());
            if (CurrentTabID == iTabID)
            {
                return cssname;
            }
            else
            {
                return "";
            }
        }
    }
}
