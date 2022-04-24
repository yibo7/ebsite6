<!--
function WriteQqStr()
{
	document.write('<DIV id="divCS" style="'+sFloat+': 0px; OVERFLOW: visible; POSITION: absolute; TOP: 130px">');
	document.write('<table border="0" cellpadding="0" cellspacing="0" width="72">');
	document.write('<tr><td><a href="javascript:close_float_left();void(0);" title="关闭本浮动条"><IMG src="'+themes+'01.gif" border=0></a></td></tr>');
	document.write('<tr><td><IMG src="'+themes+'02.gif" border=0></A></td></tr>');
	document.write(qqs);	
	document.write('<tr><td><IMG src="'+themes+'07.gif" border=0></td></tr>');
    document.write(wws);
	document.write('<tr><td><A href="#" onclick="javascript:OpenChatonline(\''+sChatonline+'\');return false"  target=_blank><IMG src="'+themes+'05-1.gif" border=0></A></td></tr>');
	document.write('</table>');
	document.write('</DIV>');
}
function OpenChatonline(url)
{
    window.open(url);
}
function close_float_left()
{
	divCS.style.visibility='hidden';
}



lastScrollY=0;
function heartBeat(){ 
var diffY;
if (document.documentElement && document.documentElement.scrollTop)
    diffY = document.documentElement.scrollTop;
else if (document.body)
    diffY = document.body.scrollTop
else
    {/*Netscape stuff*/}

percent=.1*(diffY-lastScrollY); 
if(percent>0)percent=Math.ceil(percent); 
else percent=Math.floor(percent); 
document.getElementById("divCS").style.top=parseInt(document.getElementById("divCS").style.top)+percent+"px";

lastScrollY=lastScrollY+percent; 
} 

if (!document.layers) 
{
	WriteQqStr();
	window.setInterval("heartBeat()",1); 
}
//-->