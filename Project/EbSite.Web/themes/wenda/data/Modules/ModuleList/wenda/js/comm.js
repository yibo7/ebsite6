/*
公共接口说明:

  ----获取当前模块安装目录相对路径--------
   GetModulePath()   
   返回结果如:如 /Modules/FriendLik/ 

  ---- GET办法运行异步http请求----------- 
   url：请求地址
   postdata:参数
   backfun:回调方法
   run_ajax_async(url, postdata, backfun);  

 ----用Post方法请求当前模块下的Ajaxget/api.asmx里的方法---------
 funname:调用的方法名称
 postobj:方法的参数对像
 backfun:回调方法
 runws(funname,postobj, backfun);
 调用实例:

     function testddd() {
        var pram = {"username":"admin"};
        runws("HelloString", pram, cp_testdddstr);
        runws("HelloJson", pram, cp_testdddjson);
        //无参方法
        runws("UserName", "", cp_testdddpublic);
    }
    function cp_testdddstr(result) {
        alert(result.d);
    }
    function cp_testdddjson(result) {
        alert(result.d.Message + ":" + result.d);
    }

    function cp_testdddpublic(result) {
        alert("调用了公共方法UserName，获取当前登录用户帐号:"+result.d);
    }

*/

jQuery(function ($) {
    
});

