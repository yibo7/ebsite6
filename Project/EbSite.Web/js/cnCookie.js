﻿function CookieClass(){ 

this.expires = 0 ; //有效时间,以分钟为单位 
this.path = "/"; //设置访问路径 
this.domain = ""; //设置访问主机 
this.secure = false; //设置安全性 

this.setCookie = function(name,value){ 
var str = name+"="+escape(value); 
if (this.expires>0){ //如果设置了过期时间 
var date=new Date(); 
var ms=this.expires * 60 * 1000; //每分钟有60秒，每秒1000毫秒 
date.setTime(date.getTime()+ms); 
str+="; expires="+date.toGMTString(); 
} 
if(this.path!="")str+="; path="+this.path; //设置访问路径 
if(this.domain!="")str+="; domain="+this.domain; //设置访问主机 
if(this.secure!="")str+="; true"; //设置安全性 

document.cookie=str; 
} 

this.getCookie=function(name){ 
var cookieArray=document.cookie.split("; "); //得到分割的cookie名值对 
var cookie=new Object(); 
for(var i=0;i<cookieArray.length;i++){ 
var arr=cookieArray[i].split("="); //将名和值分开 
if(arr[0]==name)return unescape(arr[1]); //如果是指定的cookie，则返回它的值 
} 
return ""; 
}

this.deleteCookie = function(name) {
    
var date=new Date(); 
var ms= 1 * 1000; 
date.setTime(date.getTime() - ms); 
var str = name+"=no; expires=" + date.toGMTString(); //将过期时间设置为过去来删除一个cookie 
document.cookie=str; 
} 

this.showCookie=function(){ 
alert(unescape(document.cookie)); 
} 

}
//var ebCookie = new CookieClass();

//ebCookie.setCookie("cookie名称", "cookie值");
//ebCookie.getCookie("cookie名称");