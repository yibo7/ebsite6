UE.registerUI('button', function (editor, uiName)
{
    //注册按钮执行时的command命令，使用命令默认就会带有回退操作
    editor.registerCommand(uiName, {
        execCommand: function () {
            //editor.execCommand('insertHtml', "---page---");
            //当你点击按钮时编辑区域已经失去了焦点，如果直接用getText将不会得到内容，所以要在选回来，然后取得内容
            var range = editor.selection.getRange();
            range.select();
            var ebatext = editor.selection.getText();
             
            if (ebatext.indexOf("[eba]") == -1) { 
                editor.execCommand('insertHtml', "[eba]" + ebatext + ["[/eba]"]);
            }
            else {
                ebatext = ebatext.replace("[eba]", "").replace("[/eba]", "");
                editor.execCommand('insertHtml', ebatext);
            }
        }
    });
     
    var btn = new UE.ui.Button({
        //按钮的名字
        name: uiName,
        //提示
        title: "目录定位",
        //需要添加的额外样式，指定icon图标，这里默认使用一个重复的icon
        cssRules: 'background-position: -540px 0;',
        //点击时执行的命令
        onclick: function () {
            //这里可以不用执行命令,做你自己的操作也可
            editor.execCommand(uiName);
        }
    });

    //当点到编辑内容上时，按钮要做的状态反射
    editor.addListener('selectionchange', function () {
        var state = editor.queryCommandState(uiName);
        if (state == -1) {
            btn.setDisabled(true);
            btn.setChecked(false);
        } else {
            btn.setDisabled(false);
            btn.setChecked(state);
        }
    });
     
    return btn;
});
 
UE.registerUI('dialog', function (editor, uiName) {

    //创建dialog
    var dialog = new UE.ui.Dialog({
        //指定弹出层中页面的路径，这里只能支持页面,因为跟addCustomizeDialog.js相同目录，所以无需加路径
        iframeUrl: SiteConfigs.UrlIISPath + 'js/ueditor/plugins/searchpic/show.html',
        //需要指定当前的编辑器实例
        editor: editor,
        //指定dialog的名字
        name: uiName,
        //dialog的标题
        title: "搜索网络图片",

        //指定dialog的外围样式
        cssRules: "width:800px;height:500px;",

        //如果给出了buttons就代表dialog有确定和取消
        buttons: [
            {
                className: 'edui-cancelbutton',
                label: '取消',
                onclick: function () {
                    dialog.close(false);
                }
            }
        ]
    });

    //参考addCustomizeButton.js
    var btn = new UE.ui.Button({
        name: 'dialogbutton' + uiName,
        title: '搜索网络图片',
        //需要添加的额外样式，指定icon图标，这里默认使用一个重复的icon
        cssRules: 'background-position: -300px 0;',
        onclick: function () {
            //渲染dialog
            dialog.render();
            dialog.open();
        }
    });

    return btn;
});