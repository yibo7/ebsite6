<%@ Page Language="C#" AutoEventWireup="true"  Inherits="EbSite.Web.Pages.AskRemark" %>
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
        .comment{padding:5px 8px;font-size:14px; margin-bottom:20px;}
        .comment p{padding:5px 0;}
        .comment p.title{color:#1f3a87;font-size:12px;}
        .comment p span{float:right;color:#666}
        .comment div{background:#ffe;padding:3px;border:1px solid #aaa;line-height:140%;margin-bottom:5px;}
        .comment div span{color:#1f3a87;font-size:12px; }
        
        .ParentClass table{background:#fff;}
        .ParentClass td{padding-left: 10px;padding-right: 10px; height:20px; border:solid 1px #ccc;  text-align:center }
        .CurrentPageCoder{ color:#fff; font-weight:bold; background:#1F3A87}
        .replaycontent{ padding: 10px;background: #fff;}
        
        </style>
<script type="text/javascript">
    //����iframeʱ������������������ø߶ȣ����Զ���Ӧ
    function resizeFrame() {

        var xscomment = parent.document.getElementById("win");
        //alert(document.documentElement.scrollHeight);
        xscomment.style.height = document.body.scrollHeight + "px";
        var topPos = location.href.indexOf("#top");
        if (topPos > 0) {
            location.href = location.href.substring(0, topPos) + "#top1";
        }

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
                        <b>�û���ѯ:</b>(��<%=iSearchCount %>��)
                     </td>
                    
                    <td style="text-align:right;width:50%;">
                       
                    </td>
                </tr>
            </table>
        
        </div>
	
    <asp:Repeater runat="server" ID="rpComment" EnableViewState="false">       
		<ItemTemplate>
			<div class='comment'>
			   <p class='title'><span><%#Eval("dateandtime")%> </span>
			     <%# bool.Parse(Eval("IsNiName").ToString()) ? "��������" : string.Format("<a target=_blank href='{0}'>{1}</a>",HostApi.GetUserSiteUrl(Eval("UserId")),Eval("UserNiName"))%>(<%#Eval("ip") %>)�ʣ�
			   </p>
	        <p id="Content<%#Eval("ID") %>">
	        
	        <%#Eval("Body") %>
	        
	        </p> 
             <div>
               <%#GetRepStr(Eval("Quote"))%>
            </div> 
		   </div>
           
		</ItemTemplate>
    </asp:Repeater>
         <XS:PagesContrl ID="pgCtr" Linktype="Aspx" runat="server" /> 
        <div  >
            <table style="width:100%; margin-left:10px;">
                 
                <tr>
                    <td colspan="5">
                         <asp:TextBox Width="80%" Height="100" ID="txtContent" TextMode="MultiLine" runat="server"></asp:TextBox>
                    </td>
                    <td style="width:180px; ">
                    
                        <table>
                            <tr id="IsOpenSafeCoder" runat="server">
                                <td>
                                 <asp:Image ID="ImageCheck" runat="server" onClick="this.src+=Math.random()" style="cursor:pointer;" ImageUrl="ValidateCode.ashx?"  ToolTip="ͼƬ�����壿������µõ���֤��,�����ִ�Сд!��ɫ����,��ɫ��ĸ!"></asp:Image>
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
