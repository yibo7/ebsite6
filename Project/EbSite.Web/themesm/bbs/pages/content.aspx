<%@ Page Language="C#" AutoEventWireup="true" Inherits="EbSite.Web.Pagesm.content" %>
<%@ Import Namespace="EbSite.BLL.GetLink"%>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<!doctype html>
<html>
<head runat="server">
    <title></title>
</head>
<script  runat="server">

    new protected void Page_Load(object sender, EventArgs e)
    {
        base.Page_Load( sender,  e);
        string FirstPageUrl  = HostApi.MGetContentLink(iRequestID, GetSiteID);
        pgCtr1.ReWritePatchUrl = string.Concat(FirstPageUrl, "?p={0}");
        pgCtr1.FirstPageUrl = FirstPageUrl;

       
        pgCtr2.ReWritePatchUrl = string.Concat(FirstPageUrl, "?p={0}");
        pgCtr2.FirstPageUrl = FirstPageUrl;
    }

    EbSite.Base.EntityAPI.MembershipUserEb mdUser(object uid)
    {

        return EbSite.Base.Host.Instance.GetUserByID(int.Parse(uid.ToString()));
        
    }
    string GetReference(string Reference)
    {
        if(!string.IsNullOrEmpty(Reference))
        {
            return string.Concat("<div class='reference'>���ã�", Reference,"</div>");
        }
        return string.Empty;
    }
    string GetReplyContent(object ReplyContent,object IsDel)
    {
        if (Equals(IsDel.ToString(), "0"))
        {
            return EbSite.Core.UBB.UBBToHtml(ReplyContent.ToString());
        }
        else
        {
            return "�������ѱ�����Աɾ��";
        }
        
        
    }
    string ShowCode(string html)
    {
        string strRule = @"\[code\s*(?:=\s*((?:(?!"")[\s\S])+?)(?:""[\s\S]*?)?)?\]([\s\S]*?)\[\/code\]";
        Match mc = Regex.Match(html, strRule);
        if (mc.Success)
        {
            string tem =  mc.Groups[1].Value;
            string stype =  mc.Groups[2].Value;
            string code = mc.Groups[3].Value;
            string newcde = "";
            code = EbSite.Core.Strings.GetString.RegexReplace(code, "/</", "&lt;");
            code = EbSite.Core.Strings.GetString.RegexReplace(code, "/>/", "&gt;");
            newcde = string.Concat("<pre class=\"prettyprint lang-", stype, ">", code, "</pre>");
            return html.Replace(tem,newcde) ;
        }
        return html;
    }
   

</script>
<body >
<!--#include file="header.inc" -->
<div class="cnav">
    <a href="<%=HostApi.MGetIndexHref() %>">��ҳ</a>-<a href="<%=HostApi.MGetClassHref(Model.ClassID,1)%>"><%=Model.ClassName %></a>
</div>
<div class="post-title">
<%=Model.NewsTitle %>
</div>
 <XS:PagesContrl ID="pgCtr2" PageSize="5"   runat="server" /> 
    <asp:PlaceHolder ID="phMainModel" runat="server">
        <div class="itembox">
              <div id="posttipsfirst" class="posttips">
                <span id="fontbig">�����С</span>&nbsp;<span><%=Model.UserNiName %>д��<%=Model.AddTime %></span><span id="push-right">�½�(<%=rpPageInfo.Items.Count %>)</span>
                
            </div>
        <div class="post-box">
            <br/><br/>
            <%=ShowInfo%>
            
            <br/>
        </div>
           <% if (!Equals(CPINext, null)){ %><div>��һ��:<a href="<%=CPINext.Href %>"><%=CPINext.Title %></a> </div><% } %>
        <div style="color:#ccc; padding: 10px;"><%=Model.Annex10%> </div>
        </div>
 </asp:PlaceHolder>
 <XS:Repeater ID="rpTopicReplies"    runat="server">
            <ItemTemplate>
                <div class="itembox">
                     <div class="posttips2"><span>ʱ��<%#Eval("CreatedTime")%></span><span>����:<a target="_blank" href="<%#HostApi.GetUserSiteUrl(Eval("UserID"))%>"><%#mdUser(Eval("UserID")).NiName%></a></span><span></span></div>
                                    <div >
                                        <%#GetReference(Eval("ReferenceContent").ToString())%>
                                    </div>
                                    <div class="post-box">
                                        <%#GetReplyContent(Eval("ReplyContent"), Eval("DeleteFlag"))%>
                                        
                                        <br/>
                                        <span style="color:#ccc"><%#Equals(Eval("CreatedTime"), Eval("UpdatedTime")) ? "" : string.Format("�������༭��{0}", Eval("UpdatedTime"))%></span>
                                    </div> 
                </div>      
            </ItemTemplate>
</XS:Repeater>

    <div style="margin-top: 8px;margin-bottom: 8px;" >
        <div class="w-home-search"> 
            <input type="submit" id="btnSavePost" value=" �ظ� " alog-alias="search">
            <div class="input">
                <div class="ui-input-mask" style="height: 45px;">
                    <input id="edtContentInfo_ID" type="text" autocomplete="off" autocorrect="off" maxlength="100"
                        placeholder="����˵һ��" style="position: absolute; top: 0px; left: 0px; width: auto;
                        right: 40px;">

                </div>
            </div> 
        </div>
    </div>

 <XS:PagesContrl ID="pgCtr1" PageSize="5"   runat="server" /> 
 <!--#include file="foot.inc" -->   
   	 <div class="panel">
            <h2> ѡ���½�</h2>
            <ul class="panel-dir"> 
                <asp:Repeater ID="rpPageInfo"   runat="server"  >
                       <ItemTemplate>  
                            <li><a href="<%#Eval("Href")%>"><%#Eval("Title")%></a> </li>       
                       </ItemTemplate>
                    </asp:Repeater>
            </ul>
        </div>

	<script>
	    var postid = <%=iRequestID%>;
	    var pAllCount = <%=pgCtr1.AllCount %>;
	    var pPageSize = <%=pgCtr1.PageSize %>;
	    var SiteID = <%=GetSiteID %>;
        var ClassID = <%=Model.ClassID %>;
        var IsReSendEmail =  <%=Model.Annex21 %>;
        var ModelUserID = <%=Model.UserID %>;
	    var CurrentUserId = <%=UserID %>;
	</script>

    <script type="text/javascript" src="<%=MThemePage %>content.js"></script>  
                                   
</body>
</html>