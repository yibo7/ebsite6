<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MakeProgress.aspx.cs" Inherits="EbSite.Web.AdminHt.MakeProgress" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>页面生成进度</title>
    
</head>
<body>

     <script type="text/javascript" language="javascript">
     
     var percenttimer = 0;
     var SPLITTER_RECORD = "{\r\r*\r\r}";
     var aCurrentmusicinfo = null;
    function WriteProcess(full, part)
	{
		var w = parseInt(part*500/full);
		var strHtml = "<center style='font-size:12px;font-family:Arial;'><div style='width:500px; height:23px; border:1px #F7D4D4 solid;font-size:5px;' align='left'>";
		    strHtml +="<div style='width:"+ w +"px;height:23px;background:#4DADF4;'></div></div>"+parseInt(part*100/full) +"%</center>";
		    //progress.innerHTML = strHtml;
		    $("#progress").html(strHtml);
	}

//       function showit() 
//        { 
//            PageMethods.CallbackProgress(suc); 
//        } 
//        function suc(result) 
//        { 
//            
//        } 
        function GetProgressInfo() 
        {
            var Url = "ajaxget/HtmlProgressInfo.ashx?t=<%=GetMakeType%>&mid=<%=ModelID %>&rnd=" + Math.random();
            
            run_ajax_async(Url,"",GetProgressInfo_Comp);
        }
        function GetProgressInfo_Comp(msg)
        {
            aCurrentmusicinfo = msg.split(SPLITTER_RECORD);
            
            WriteProcess(100,aCurrentmusicinfo[1]);
            
            var strCurrentInfo = aCurrentmusicinfo[0];

            $("#currentinfo").html(strCurrentInfo);
        }
       
        percenttimer = setInterval("GetProgressInfo()",2000); 
    
        
	</script>
    <form id="form1" runat="server">

     <br />
       <div  style="text-align:center; height:500px;" >
                <br /><br />
                <div id="progress"></div>
                
                <div style="width:500px;" id="currentinfo"></div>
                <br /><br />
              &nbsp; &nbsp; &nbsp; &nbsp;
               <XS:Button ID="btnAdd" Height="28" Text=" 终 止 " runat="server" 
                                onclick="btClear_Click"  />
        </div>
        <br /><br />
        
    </form>
</body>
</html>
