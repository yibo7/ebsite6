<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EditFormTem.ascx.cs" Inherits="EbSite.Web.AdminHt.Controls.Admin_Model.EditFormTem" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<%@ Register TagPrefix="XSD" Namespace="EbSite.ControlData" Assembly="EbSite.ControlData" %>
<link rel=stylesheet href="<%=IISPath%>js/codemirror/lib/codemirror.css">
<script src="<%=IISPath%>js/codemirror/lib/codemirror.js"></script>
<script src="<%=IISPath%>js/codemirror/xml.js"></script>
<script src="<%=IISPath%>js/codemirror/javascript.js"></script>
<script src="<%=IISPath%>js/codemirror/css.js"></script>
<script src="<%=IISPath%>js/codemirror/htmlmixed.js"></script> 


<div class="row cbrowbox">
    <div class="col-sm-12 col-md-12 ">
        <div class="boxheader headertips">
                <h3>插入可引用字段</h3>
            将光标放到指定位置，点击可插入
            </div>
            <div class="eb-content">
				 <asp:Repeater ID="rpGetExtList" runat="server">
                    <ItemTemplate>
                         
                            <a class="btn btn-primary" href="#" name='<%#ExtntsionStr(Eval("ColumFiledName").ToString(),Eval("FieldControlTypeID").ToString(),Eval(" ColumShowName").ToString()) %>' onclick="InserField(name)">
                                <%#Eval("ColumShowName")%>
                            </a>
                      
                    </ItemTemplate>
                </asp:Repeater>
                <br />
                <br />
                <asp:TextBox ID="txtTem"   TextMode="MultiLine" runat="server"/> 
            </div>
    </div>
</div>

<div class="text-center mt10">    
    <XS:Button ID="bntSave" Text=" <%$Resources:lang,EBSave%> " runat="server" />
</div>
 
<script>
     var editor = CodeMirror.fromTextArea(document.getElementById("<%=txtTem.ClientID%>"), {
        lineNumbers: true,
        mode: "text/html"
    });
    function InserField(ob) {
        editor.replaceSelection(ob);
        //InserFieldToBox(ob, "<%=txtTem.ClientID %>");
    }
</script>
