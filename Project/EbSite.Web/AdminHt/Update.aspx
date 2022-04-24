<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Update.aspx.cs" Inherits="EbSite.Web.AdminHt.Update" %>

<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<asp:Content ID="Content1"  ContentPlaceHolderID="ctphBody"  Runat="Server">
<XS:CustomTags ID="ucPageTags" CssClass="CustomPageTag" runat="server"></XS:CustomTags>

    <div style=" width:100%;" class="txt-c">
       <div class="loginbox-p">            
                            <div  class="loginbox-s"> 
                            <div class="loginbox-title"  >升级向导</div>
                                <div class="loginbox-content" style="padding-left:20px; height:250px; font-weight:normal;  " >
                                    <div id="compupdate" runat="server" ><br>
                                           <div id="updateinfo" runat="server"></div>
                                            <asp:CheckBox ID="cbIsBak" Text="是的，我要先备份后升级" checked=true runat="server"></asp:CheckBox>
                                             <br> <br>
                                        <XS:Button  ID="btnUpdate"  OnClientClick="updatesys(this);return false;" runat="server" Text="开始升级"></XS:Button>
                                    </div><br>
                                    <div style=" color:Red" id="divInfo">
                                       
                                    </div>
                                    <div style=" padding-right:10px;">
                                        <br />
                                        <div id="progressbar"></div>
                                    </div>
                                    				    
                		
                           </div>
                </div>
    </div>
    
	<script>
	    var iTimer = 0;
	    function UpdateBad(msg) {
	        $("#<%=compupdate.ClientID %>").html(msg);
	        $("#divInfo").html("");
	    }
	    function toUpdate() {
            
	        runwspg("ToUpdate", null, cp_updatesys);
        }
       
        function updatesys(ob) {
            $("#divInfo").html("正在下载升级包");
            iTimer = setInterval(toUpdate, 1000);
            $(ob).attr("disabled", "false");
            $("#<%=cbIsBak.ClientID %>").attr("disabled", "false");
        }
        var SleepPeo = 0;
        function Sleep() {
            SleepPeo += 5;
            if (SleepPeo > 90) {
                StarUpdate();
                clearInterval(iTimer);
            }
            else { $("#progressbar").progressbar({ value: SleepPeo }); }

        }
       
	    function cp_updatesys(result) {
	        var CurrentPro = parseInt(result.d.Message);
	        
	        if (CurrentPro >= 99) {

	            clearInterval(iTimer);
	            $("#divInfo").html("升级中，请不要关闭页面..");
	            iTimer = setInterval(Sleep, 500);
	            
	        }
	        else {
	            $("#progressbar").progressbar({ value: CurrentPro });
            }
	    }

	    function StarUpdate() {
	        if ($("#<%=cbIsBak.ClientID %>").prop("checked")) { //要备份
	            //Cp_BakFile
	            runwspg("UpdateSys", null, Cp_StarUpdate);
	        }
	        else {//不备份
	            runwspg("UpdateSys", null, Cp_BakFile);
	        }

	    }
        /////////////////////////////////////////////////////
	    function Cp_StarUpdate(result) {

	        if (result.d.Success) {
	            $("#divInfo").html("正在处理备份文件!");
	            $("#progressbar").progressbar({ value: 0 });
	            SleepPeo = 0;
	            iTimer = setInterval(Sleep2, 50);
	        }
	        else {
	            UpdateBad(result.d.Message);
            
            }
	      
	    }
	    function Sleep2() {
	        SleepPeo += 5;
	        if (SleepPeo > 90) {
	            runwspg("BakFile", null, Cp_BakFile);
	            clearInterval(iTimer);
	        }
	        else { $("#progressbar").progressbar({ value: SleepPeo }); }

	    }
	    function Cp_BakFile(result) {
	        if (result.d.Success) {
	            $("#divInfo").html("正在升级数据库!");
	            $("#progressbar").progressbar({ value: 0 });
	            SleepPeo = 0;
	            iTimer = setInterval(Sleep3, 500);
	        } else {
	            UpdateBad(result.d.Message);

	        }
	       
	    }
//////////////////////////////////////////////////////////////////////////////
        function Sleep3() {
	        SleepPeo += 5;
	        if (SleepPeo > 90) {
	            runwspg("RunScript", null, Cp_RunScript);
	            clearInterval(iTimer);
	        }
	        else { $("#progressbar").progressbar({ value: SleepPeo }); }

	    }
	    function Cp_RunScript(result) {
	        if (result.d.Success) {
	            $("#divInfo").html("清理垃圾文件!");
	            $("#progressbar").progressbar({ value: 0 });
	            SleepPeo = 0;
	            iTimer = setInterval(Sleep4, 50);
	        } else {
	            UpdateBad(result.d.Message);

	        }
	        
	    }
/////////////////////////////////////////
	    function Sleep4() {
	        SleepPeo += 5;
	        if (SleepPeo > 90) {
	            runwspg("CopyZip", null, Cp_UpdateComp);
	            clearInterval(iTimer);
	        }
	        else { $("#progressbar").progressbar({ value: SleepPeo }); }

	    }


	    function Cp_UpdateComp(result) {
	        if (result.d.Success) { 
             	$("#<%=compupdate.ClientID %>").html(result.d.Message);
	            $("#divInfo").html("");
	            $("#progressbar").progressbar({ value: 100 });
            }else {
	            UpdateBad(result.d.Message);

	        }
	      
	    }
	</script>

</asp:Content>
   
