<%@ Page Language="C#" AutoEventWireup="true" Inherits="EbSite.Web.Pagesm.content" %>
<%@ Import Namespace="EbSite.BLL.GetLink"%>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<!doctype html>
<html>
<head runat="server">
    <title></title>
</head>

<body >
<!--#include file="header.inc" -->
<div class="cnav">
    <a href="<%=HostApi.MGetIndexHref() %>">首页</a>-<a href="<%=HostApi.MGetClassHref(Model.ClassID,1)%>"><%=Model.ClassName %></a>
</div>
<div class="post-title">
<%=Model.NewsTitle %>
</div>

    <div class="itembox">
              <div id="posttipsfirst" class="posttips">
                <span id="fontbig">字体大小</span>&nbsp;<span>阅读(<%=Model.hits+6000 %>)</span><span id="push-right">章节(<%=rpPageInfo.Items.Count %>)</span>
                
            </div>
        <div class="post-box">
            <br/><br/>
            <%=ShowInfo%>
            
            <br/>
            
               <div>
            <% if (!Equals(CPINext, null)){ %><div>下一节:<a href="<%=CPINext.Href %>"><%=CPINext.Title %></a> </div><% } %>
        </div>
            <br/><br/>
            <div style="text-align: center; font-weight: bold;padding-top: 10px;  border: solid 1px #ccc;">
              <a href="http://m.beimai.com">  迈氏<font size="5" color="#9ACE04">同质</font>配件+迈氏<font size="5" color="#9ACE04">安装</font>服务<br/>为车主提供<font size="5" color="#ff000">一站式</font>解决方案>></a><br/><br/>
            
        </div> 
            <div  id="showcode">
                <img style="width: 100%" src="http://file.beimai.com/uploadfile/weixin.png"/>
            </div>
        </div>
      
</div>



 <!--#include file="foot.inc" -->   
   	 <div class="panel">
            <h2> 选择章节</h2>
            <ul class="panel-dir"> 
                <asp:Repeater ID="rpPageInfo"   runat="server"  >
                       <ItemTemplate>  
                            <li><a href="<%#Eval("Href")%>"><%#Eval("Title")%></a> </li>       
                       </ItemTemplate>
                    </asp:Repeater>
            </ul>
        </div>

     <script type="text/C#" runat="server">

         public string appId = "wxa6b8aedf778b5efb";
         public string appSecret = "360b618f8616067b53d59db1d3a48051";
         public string timestamp = "";
         public string nonceStr = "";
         public string signature = "";
         public string url = "";
         public string shareImgUrl = "http://file.beimai.com/UploadFile/logo.png";
         new protected void Page_Load(object sender, EventArgs e)
         {
             base.Page_Load(sender, e);
             url = string.Concat(DomainName,Request.RawUrl);
             Dictionary<string,string> keys = EbSite.Core.WeiXinJS.GetSignature(appId, appSecret,ref url);
             if (!Equals(keys, null)&&keys.Count>0)
             {
                 if (keys.ContainsKey("noncestr"))
                     nonceStr = keys["noncestr"];
                 if (keys.ContainsKey("timestamp"))
                     timestamp = keys["timestamp"];
                 if (keys.ContainsKey("sign"))
                     signature = keys["sign"];
             }

             if (!string.IsNullOrEmpty(Model.SmallPic))
             {
                 shareImgUrl =  string.Concat(DomainName,Model.SmallPic);
             }
         }
    </script>

    <script type="text/javascript" src="<%=MThemePage %>content.js?v=1.10"></script>  
    
    <script type="text/javascript" src="http://res.wx.qq.com/open/js/jweixin-1.0.0.js"></script>
<script language="javascript" type="text/javascript">

    var sappId = '<%=appId%>';
       var stimestamp = '<%=timestamp%>';
       var snonceStr = '<%=nonceStr%>';
    var ssignature = '<%=signature%>';

       var sharelink = "<%=url%>";
    var shareImgUrl = "<%=shareImgUrl%>";
    var shareTitle = "<%=Model.NewsTitle%>";
    var shareDesc = "分享自公众号：北迈网";

       
</script>

    <%=KeepUserState() %>
                                   
</body>
</html>