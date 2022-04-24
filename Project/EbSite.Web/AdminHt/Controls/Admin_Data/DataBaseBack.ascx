<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DataBaseBack.ascx.cs" Inherits="EbSite.Web.AdminHt.Controls.Admin_Data.DataBaseBack" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>

<script language="javascript" type="text/javascript">
    var isfirst=true;
/*以下检测当前是否发布*/
function CheckBakFile()
{
    $('wait1').style.display="";
    HiddenControl();
    var url = 'Admin_Data.aspx?ChcekBakFile=true&d='+Date()+'&filename='+$('filename1').value;
    var Action = '';
    setTimeout('WaitPreData()',1000);
    var wAjax = new Ajax.Request(url,{method:'get',parameters:Action,onComplete:ShowCheckTimeOut});
}

function ShowCheckTimeOut(OriginalRequest)
{
     var originalrequest = OriginalRequest.responseText;
     setTimeout("ShowCheck("+originalrequest+")",1000);
}

function ShowCheck(originalrequest)
{
    $("wait1").innerHTML="1";
    $("wait1").style.display="none";
    $("totalcount").value=originalrequest;
    if(originalrequest !="0")
    {
        $("CheckBakFile").innerHTML="备份卷检测完成，共有"+originalrequest+"卷备份卷。可以进行数据恢复。"
        ShowControl();
    }
    else
    {
        $("CheckBakFile").innerHTML="检测完毕，备份卷不完整，您无法恢复数据。"
        $('btnReturn').disabled=false;
    }
}
/*检测发布结束*/

/*控件状态改变*/
function ShowControl()
{
    $('btnBeginRestore').disabled=false;
    $('btnReturn').disabled=false;
}

function HiddenControl()
{
    $('btnBeginRestore').disabled=true;
    $('btnReturn').disabled=true;
}
/*控件状态改变*/

<%=startcheck %>

/*以下是进度条脚本.*/
    function ShowWaitStatus(index){
    var id = "wait" + index;
    $(id).innerHTML = $(id).innerHTML + ".";
    if($(id).innerHTML == "............"){
        $(id).innerHTML = ".";
    }
}
function WaitPreData(){
    if($("wait1").innerHTML=="1")
    {
        return;
    }
    ShowWaitStatus(1);
    setTimeout('WaitPreData()', 1000);
}

/*显示统计结果，开始发布页面*/
function RestoreData()
{
   HiddenControl();
   $('CheckBakFile').style.display="none";
   $('schedule').style.display="";
   $('wait1').style.display="";
   $("wait1").innerHTML=".";
   setTimeout('WaitPreData()',1000);   
   StartCount($('filename1').value);
}

/*开始统计进度*/
function StartCount(filename1)
{
    if(isfirst){
        $('schedule').innerHTML= " 共有" + $('totalcount').value + "备份卷需要恢复.正在恢复卷头";
    }

    var url = 'Admin_Data.aspx?RestoreData=true&d='+Date()+'&filename='+filename1;
    var Action = '';
    var wAjax = new Ajax.Request(url,{method:'get',parameters:Action,onComplete:IsOver});
 
}

/*进度计算并显示*/
function IsOver(OriginalRequest)
{
    isfirst=false;
    var strRefreshLen=OriginalRequest.responseText.split("$")[2];
    var strFileName=OriginalRequest.responseText.split("$")[1];
    var strErr=OriginalRequest.responseText.split("$")[0];
    if(strRefreshLen==$('totalcount').value)
    {
        $('wait1').style.display="none";
        $("wait1").innerHTML="1";
		$("RefreshLen").style.width ="100%";
		$("RefreshLen").innerHTML="&nbsp;<span class=\"xingmu\">100%</span>";
        $('schedule').innerHTML= " 共有" + $('totalcount').value + "备份卷需要恢复.已经恢复" + strRefreshLen + "个备份卷.恢复完成";
        $('btnReturn').disabled=false;
        return;
    }
    else if(strErr!="")
    {
        $('wait1').style.display="none";
        $("wait1").innerHTML="1";
        $('schedule').innerHTML= " 数据恢复失败，请与管理员联系。错误描述如下："+strErr;
        $('btnReturn').disabled=false;
        return;
    }
    else
    {
    	var percent=(strRefreshLen/$('totalcount').value)*100;
		percent=Math.round(percent);
		$("RefreshLen").style.width =percent+"%";
		$("RefreshLen").innerHTML="&nbsp;<span class=\"xingmu\">"+percent+"%</span>";
        $('schedule').innerHTML= " 共有" + $('totalcount').value + "备份卷需要恢复.正在恢复" + strRefreshLen + "个备份卷";
        StartCount(strFileName);
    }
}

</script>

<div class="row cbrowbox">
    <div class="col-sm-12 col-md-12 ">
        <div>
                <h3>数据库备份</h3>
            </div>
            <div class="content">				
                <XS:ToolBar ID="ucToolBar" runat="server"></XS:ToolBar>
                 <div class="table-responsive" id="PagesMain">

                <XS:GridView ID="gdList1" runat="server" AutoGenerateColumns="False"
                    DataKeyNames="ID" CssClass="GridView" EnableModelValidation="True">
                    <AlternatingRowStyle BorderWidth="0px" CssClass="AlternatingRow"></AlternatingRowStyle>
                    <Columns>
                        <asp:TemplateField HeaderText="<input id='chAll' onclick='on_check(this)'  type=checkbox />">
                            <ItemTemplate>
                                <asp:CheckBox ID="Selector" runat="server" />
                            </ItemTemplate>
                            <ItemStyle Width="25px" HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:BoundField HeaderText="ID" ReadOnly="true"
                            DataField="ID" Visible="False"></asp:BoundField>

                        <asp:BoundField HeaderText="名称" ReadOnly="true"
                            DataField="Name"></asp:BoundField>
                        <asp:BoundField HeaderText="分卷" ReadOnly="true"
                            DataField="Notice"></asp:BoundField>
                        <asp:BoundField DataField="Size" HeaderText="大小" />
                        <asp:BoundField DataField="Date" HeaderText="创建日期" />
                    </Columns>
                    <EmptyDataTemplate>
                        <asp:Label runat="server" ForeColor="Red">没有相关数据!</asp:Label>
                    </EmptyDataTemplate>

                    <HeaderStyle CssClass="GridViewHeader"></HeaderStyle>
                </XS:GridView>
                <div style="text-align: right">
                    <asp:Button ID="restoreButton" runat="server" Text="恢复"
                        OnClick="restoreButton_Click" />
                    <asp:Button ID="delButton" runat="server" Text="删除" OnClick="delButton_Click" />
                </div>
                <div class="listborder" runat="server" visible="false" id="ShowRestore">
                    <table id="OperateTable" width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                        <tr>
                            <td align="center" colspan="2" style="padding: 30px 0 20px">
                                <div id="RefreshSchedule">
                                    <div class="processline" align="left" style="width: 400px;">
                                        <div id="RefreshLen" class="xingmu" style="width: 0px;">
                                            <span class="xingmu">0%</span>
                                        </div>
                                    </div>
                                    <span id="CheckBakFile" align="left" style="color: #009900">正在检测当前备份卷是否完整</span>
                                    <span id="schedule" align="left" style="display: none">共有{$totalcount}卷需要恢复.</span>
                                    <span id="wait1" style="display: none">.</span>
                                    <span id="totalcount" align="center" style="display: none"></span>
                                    <br />
                                    <br />
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td height="30" align="center" colspan="2">
                                <input type="hidden" id="filename1" value='' runat="server" />
                                <input type="button" id="btnBeginRestore" value="开始恢复" onclick="RestoreData()" runat="server" class="button" />
                                <input type="hidden" id="btnReturn" value="返回列表" onclick="window.location.href='Admin_Data.aspx'" class="button" />
                            </td>
                        </tr>
                    </table>
                </div>

            </div>
            <XS:PagesContrl ID="pcPage" runat="server"></XS:PagesContrl>
            <div class="table-responsive">
                <XS:GridView ID="gdList" Visible="false" runat="server" AutoGenerateColumns="False"
                    DataKeyNames="ID" CssClass="GridView" EnableModelValidation="True">
                    <AlternatingRowStyle BorderWidth="0px" CssClass="AlternatingRow"></AlternatingRowStyle>
                    <Columns>
                        <asp:TemplateField HeaderText="<input id='chAll' onclick='on_check(this)'  type=checkbox />">
                            <ItemTemplate>
                                <asp:CheckBox ID="Selector" runat="server" />
                            </ItemTemplate>
                            <ItemStyle Width="100px" />
                        </asp:TemplateField>
                        <asp:BoundField HeaderText="ID" ReadOnly="true"
                            DataField="ID"></asp:BoundField>

                        <asp:BoundField HeaderText="名称" ReadOnly="true"
                            DataField="Name"></asp:BoundField>
                        <asp:BoundField HeaderText="分卷" ReadOnly="true"
                            DataField="Notice"></asp:BoundField>
                        <asp:BoundField DataField="Size" HeaderText="大小" />
                        <asp:BoundField DataField="Date" HeaderText="创建日期" />
                    </Columns>
                    <EmptyDataTemplate>
                    </EmptyDataTemplate>

                    <HeaderStyle CssClass="GridViewHeader"></HeaderStyle>
                </XS:GridView>
            </div>
            </div>
    </div>
</div>
 

<XS:Notes ID="Notes1" Text="备份成功" runat="server" Visible="false" />
<XS:Notes ID="Notes3" Text="恢复成功" runat="server" Visible="false" />
<XS:Notes ID="Notes4" Text="恢复失败" runat="server" Visible="false" />
<XS:Notes ID="Notes2" Text="修复成功" runat="server" Visible="false" />
