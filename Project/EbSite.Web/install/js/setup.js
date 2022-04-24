function disableOtherSubmit()
{           var objs = document.getElementsByTagName('INPUT');
            for(var i=0; i<objs.length; i++)
            {
                if(objs[i].type.toLowerCase() == 'submit')
                {
                    objs[i].disabled = true;
                }
            } 
}
            
      
var n = 0;

	
function HighlightAll(obj) {
	obj.focus();
	obj.select();
	if (document.getElementById("TextBox1")) {
		obj.createTextRange().execCommand("Copy");
		window.status = "将模板内容复制到剪贴板";
		setTimeout("window.status=''", 1800);
	}
}




var PasswordStrength ={
Level : ["极佳","一般","较弱","太短"],
LevelValue : [15,10,5,0],//强度值
Factor : [1,2,5],//字符加数,分别为字母,数字,其它
KindFactor : [0,0,10,20],//密码含几种组成的加数 
Regex : [/[a-zA-Z]/g,/\d/g,/[^a-zA-Z0-9]/g] //字符正则数字正则其它正则
}
            
PasswordStrength.StrengthValue = function(pwd)
{
    var strengthValue = 0;
    var ComposedKind = 0;
    for(var i = 0 ; i < this.Regex.length;i++)
    {
        var chars = pwd.match(this.Regex[i]);
        if(chars != null)
        {
            strengthValue += chars.length * this.Factor[i];
            ComposedKind ++;
        }
    }
    strengthValue += this.KindFactor[ComposedKind];
    return strengthValue;
} 
        
PasswordStrength.StrengthLevel = function(pwd)
{
    var value = this.StrengthValue(pwd);
    for(var i = 0 ; i < this.LevelValue.length ; i ++)
    {
        if(value >= this.LevelValue[i] )
             return this.Level[i];
    }
}
     
function loadinputcontext(o)
{
    var showmsg = PasswordStrength.StrengthLevel(o.value);
   
    switch(showmsg)
    {
         case "太短": showmsg+=" <img src=../images/level/1.gif width=88 height=10>";break;
         case "较弱": showmsg+=" <img src=../images/level/2.gif width=88 height=10>";break;
         case "一般": showmsg+=" <img src=../images/level/3.gif width=88 height=10>";break;
         case "极佳": showmsg+=" <img src=../images/level/4.gif width=88 height=10>";break;
    }
           
    document.getElementById('showmsg').innerHTML =showmsg;
}



function isempty(id) {

    var ob = document.getElementById(id);
    if (ob == null || ob == undefined) return false;
    if (ob.value.length == 0)
        return true;
    else
        return false;
}

function CheckDataBaseConfig() {
    
//    if (document.getElementById("ddlDbType").value == 'Access') {
//        document.getElementById("txtTableprefix").value = "EB_";
//        if (!isempty('txtDbFileName'))
//            document.Form1.submit();
//        else
//            return false;
//    }
     if (document.getElementById("ddlDbType").value == 'SqlServer') {
        if (!isempty('txtDatasource') && !isempty('txtDataBaseName') && !isempty('txtDataBaseUser'))
            document.Form1.submit();
        else
            return false;
    } else {
        if (!isempty('txtMySqlDatasource') && !isempty('txtMySqlDataBaseName') && !isempty('txtMySqlDataBaseUser'))
            document.Form1.submit();
        else
            return false;
     }

}

function CheckAdmin() {

    if (document.getElementById("txtManagerPass").value == "" || document.getElementById("txtManagerPass").value.length < 6) {
        alert("系统管理员密码不能少于6位");
        document.getElementById("txtManagerPass").focus();
        return false;
    }
    if (document.getElementById("repwd").value == "") {
        alert("确认密码不能为空");
        document.getElementById("repwd").focus();
        return false;
    }
    if (document.getElementById("txtManagerPass").value != document.getElementById("repwd").value) {
        alert("系统管理员密码两次输入不同,请重新输入");
        document.getElementById("txtManagerPass").focus();
        document.getElementById("txtManagerPass").value = "";
        document.getElementById("repwd").value = "";
        return false;
    }

}

function checkid(obj, id) {
    var v = obj.value;

    if (v.length == 0) {
        document.getElementById('msg' + id).innerHTML = '<span style=\'color:#ff0000\'>此处不能为空！</span>';
        ok = false;
    }
    else {
        document.getElementById('msg' + id).innerHTML = '';
        ok = true;
    }
}

function SelectChange(ob) {


    switch (ob.value) {

        case "SqlServer":
            document.getElementById("SqlServer").style.display = "";
            document.getElementById("MySql").style.display = "none";
            break;
        case "MySql":
            document.getElementById("SqlServer").style.display = "none";
            document.getElementById("MySql").style.display = "";
            break;
        default:
            document.getElementById("SqlServer").style.display = "none";
            document.getElementById("MySql").style.display = "none";
            break;
    }


}
//关闭一个距于页面中间的提示框
function CloseTipsToCenter() {

    document.getElementById('success').style.display = 'none';
}
////打开一个距于页面中间的提示框
//function OpenTipsToCenter(msg) {

//    var str = "";
//    
//    str +='<div id="success" style="position:absolute;z-index:300;height:120px;width:284px;left:50%;top:50%;margin-left:-150px;margin-top:-80px;">';
//	 str   +='<div id="Layer2" style="position:absolute;z-index:300;width:270px;height:90px;background-color: #FFFFFF;border:solid #000000 1px;font-size:14px;">';
//		str    +='<div id="Layer4" style="height:26px;background:#333333;line-height:26px;padding:0px 3px 0px 3px;font-weight:bolder;color:#fff ">';
//		  str      +='操作提示';
//		  str  +='</div>';
//		   str +='<div id="Layer5" style="height:64px;line-height:150%;padding:0px 3px 0px 3px;" align="center">';
//		    str    +='<br />'+msg+'';
//		    str+='</div>';
//       str +='</div>';
//		str+='<div id="Layer3" style="position:absolute;width:270px;height:90px;z-index:299;left:4px;top:5px;background-color: #cccccc;"></div>';
//		str += '</div>';

//		var span = document.createElement("span");
//		span.innerHTML = str;
//		
//		document.body.appendChild(span);
//}