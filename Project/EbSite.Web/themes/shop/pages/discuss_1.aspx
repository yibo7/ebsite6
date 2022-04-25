<%@ Page Language="C#" AutoEventWireup="true" validateRequest="false"    Inherits="EbSite.Web.Pages.Remark" %>
<!DOCTYPE   html   PUBLIC   "-//W3C//DTD   XHTML   1.0   Transitional//EN "   "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd "> 

<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>����</title>
    
    <style type="text/css" >
        *{padding:0;
            margin-left: 0;
            margin-right: 0; 
            margin-top: 0;
        }
        body{ font-size:12px; }
        h1{font-size:20px;margin:10px 0 15px;}
        input{ border:solid 1px #CBCBCB; height:20px;}
        textarea{ border:solid 1px #CBCBCB; margin-top:10px; }
        #commentHolder{width:99%; height:auto; background:#f8fcff;border:1px solid #aaa; text-align:left}
        .comment{padding:5px 8px;font-size:14px;border-bottom:1px dotted #aaa; margin-bottom:20px;}
        .comment p{padding:5px 0;}
        .comment p.title{color:#1f3a87;font-size:12px;}
        .comment p span{float:right;color:#666}
        .comment div{background:#ffe;padding:3px;border:1px solid #aaa;line-height:140%;margin-bottom:5px;}
        .comment div span{color:#1f3a87;font-size:12px; }
        
        .ParentClass table{background:#fff;}
        .ParentClass td{ width:50px; height:20px; border:solid 1px #ccc;  text-align:center }
        .CurrentPageCoder{ color:#fff; font-weight:bold; background:#1F3A87}
        
        
        </style>
<script type="text/javascript">
 //����iframeʱ������������������ø߶ȣ����Զ���Ӧ
function resizeFrame(){
	
	var xscomment=parent.document.getElementById("xscomment");
        //alert(document.documentElement.scrollHeight);
        xscomment.style.height= document.body.scrollHeight+"px";
        var topPos=location.href.indexOf("#top");
        if(topPos>0)
        {
            location.href=location.href.substring(0,topPos)+"#top1"
        }
      
}

function reply(PID,ip)
{
   var sQuoteContent = document.getElementById("QuoteContent"+PID).innerHTML;
   var sContent = document.getElementById("Content"+PID).innerHTML;
   
   var sNewQuote = "<div>"+sQuoteContent+"<span>����("+ip+")��ԭ����</span><br />"+sContent+"</div>";
      
   document.getElementById("quote").value = sNewQuote;
}

var CurrentOb = null;
function ClientExecutePost(flag,postid,ob)              
{                   
    CurrentOb = ob;
    var Url = IISPath + "ajaxget/ExecutePost.ashx?" + Math.random();
    run_ajax_async(Url, "id=" + postid + "&flg=" + flag, CompCallBackResult);
    CurrentOb.innerHTML = "���ύ"; 
}
function CompCallBackResult(msg) {
    //CurrentOb.innerHTML = "���ύ"; 
}

</script>
</head>
<body onload="resizeFrame()">
    <form id="form1" runat="server">
      
   <h1></h1>

	<div id="commentHolder">
	
	    <div style="border-bottom:1px solid #aaa; height:30px; padding:10px 0px 0px 0px;  ">
        
            <table style="width:100%">            
                <tr >
                    <td style="width:50%;">
                        <b>�����б�:</b>(��<%=iSearchCount %>��)
                     </td>
                    
                    <td style="text-align:right;width:50%;">
                       
                    </td>
                </tr>
            </table>
        
        </div>
	
    <asp:Repeater runat="server" ID="rpComment" EnableViewState="false">       
		<ItemTemplate>
			<div class='comment'>
			   <p class='title'><span><%#Eval("dateandtime")%> ����</span>
			     <%# bool.Parse(Eval("IsNiName").ToString()) ? "��������" : EbSite.Base.Host.Instance.GetUserHomePage(Eval("UserID").ToString())%>(<%#Eval("ip") %>)
			   </p>
	        <span id="QuoteContent<%#Eval("ID") %>">
	                <%#Eval("Quote")%>
	        </span>
	        
	        <p id="Content<%#Eval("ID") %>">
	        
	        <%#Eval("Body") %>
	        
	        </p>        
	        
	        
	         <span style="float:right; margin-top:-15px;">
	            <a href="#AddPost" onclick="reply(<%#Eval("ID") %>,' <%#Eval("ip") %>')">�ظ�</a> 
	            <a href="###" onclick="ClientExecutePost(0,<%#Eval("ID") %>,this,<%#Eval("Support")%>)">֧��[<%#Eval("Support")%>]</a>
	                	               
	            <a href="###" onclick="ClientExecutePost(1,<%#Eval("ID") %>,this,<%#Eval("Discourage")%>)">����</a>[<%#Eval("Discourage")%>]
	             
	            <a href="###" onclick="ClientExecutePost(2,<%#Eval("ID") %>,this,<%#Eval("Information")%>)">�ٱ�</a>[<%#Eval("Information")%>]
	        </span>
		   </div>
		</ItemTemplate>
    </asp:Repeater>
        <div style="width:100%;text-align:right;  height:30px;  margin:10px 10px 10px 0px;  border-bottom:1px solid #aaa;">
            <XS:PagesContrl ID="pgCtr" Linktype="Aspx" runat="server" /> 
            
        </div>
       
        <div  >
            <table style="width:100%; margin-left:10px;">
            
                <tr>
                    <td colspan="5">
                        <% if (string.IsNullOrEmpty(EbSite.Core.AplicationGlobal.UserName))
                           {%>
                        <table style="width:100%; margin-left:10px;">            
                            <tr>
                                <td>�û��ʺ�:</td>
                                <td>
                                    <asp:TextBox ID="txtUserName" Width="80" runat="server"></asp:TextBox>
                                </td>
                                <td>��¼����:</td>
                                <td>
                                    <asp:TextBox ID="txtPass" TextMode="Password" Width="80" runat="server"></asp:TextBox>
                                    <asp:Button ID="btnLogIn" runat="server" Width="50" Height="23" Text="��¼" 
                                        onclick="btnLogIn_Click" />
                                    <a target="_blank" href="/reg.aspx">ע���û�</a>
                                </td>
                            </tr>
                        </table>
                        <%} else{ %>
                        
                        ����,<a target=_blank href="<%=EbSite.Base.Host.Instance.GetUserHomePage()%>"><%=EbSite.Core.AplicationGlobal.UserNiName%></a>
                        
                        <%} %>
                    </td>
                    <td></td>
                    
                </tr>
                <tr>
                    <td colspan="6">
                        <input  type="text"  style="display:none" id="quote" name="quote" />
                    </td>
                </tr>
                <tr>
                    <td colspan="5">
                         <asp:TextBox Width="80%" Height="100" ID="txtContent" TextMode="MultiLine" runat="server"></asp:TextBox>
                    </td>
                    <td style="width:180px; ">
                    
                        <table>
                            <tr id="IsOpenSafeCoder" runat="server">
                                <td>
                                 <asp:Image ID="ImageCheck" runat="server" onClick="this.src+=Math.random()" style="cursor:pointer;" ImageUrl="ValidateCode.ashx?"  HintInfo="ͼƬ�����壿������µõ���֤��,�����ִ�Сд!��ɫ����,��ɫ��ĸ!"></asp:Image>
                                <br />
                                ��֤��: 
                                <XS:TextBox ID="txtSafeCoder" runat="server" Width="80" CanBeNull="����" ></XS:TextBox> 
                                
                               
                                </td>
                            </tr>
                            <tr>
                                <td>
                                  ��������:<asp:CheckBox ID="cbNiName"  Text="��" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Button ID="btnPl" Width="80" Height="23" BorderColor="#000"  
                            runat="server" Text="��Ҫ����" onclick="btnPl_Click" />
                                </td>
                            </tr>
                        </table>
                        
                        
                        
                        
                        
                    </td>
                </tr>
                 <tr>
                    <td style="height:30px; color:ThreeDFace" colspan="5">
                         �������۽������ѱ����˿���������������վͬ����۵��֤ʵ������
                    </td>
                </tr>
            
            </table>
            <a name="AddPost"></a>
        </div>
   </div>
    </form>
</body>
</html>
