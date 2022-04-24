
function InitAreaList(CtrID, LevelLenght, ValueID, ApiName, ApiFunctionName, ModuleID, Size, iSiteID, BackFun) 
{
    var ctrArea = new AreaList();
    ctrArea.CtrID = CtrID;
    ctrArea.LevelLenght = LevelLenght;
    ctrArea.ValueID = ValueID;
    ctrArea.ApiName = ApiName; //  "wcf";
    ctrArea.ApiFunctionName = ApiFunctionName; //  "GetAlear";
    ctrArea.ModuleID = ModuleID;
    ctrArea.Size = Size;
    if (arguments.length >= 8) 
    { //有指定站点的参数

        ctrArea.SiteID = iSiteID;
        ctrArea.Fun = BackFun;
    } 
    ctrArea.Init();
    return ctrArea;
}

function AreaList() {
    this.Fun = null; //返回当前选项
    this.CtrID = "";
    this.Lavel = 1; //当前所选深度
    this.LevelLenght = 10; //总级长度默认为10级
    this.ValueID = "";
    this.ApiName = ""; //为wcf 为主站接口，ws为模块接口
    this.ApiFunctionName = "GetAlear"; //调用接口名称
    this.ModuleID = "";
    this.Size = 1; //控件类型
    this.SiteID = 0;//站点ID,如果大于0,将加入参数 siteid
    this.ModifyValue = 0;
    this.ModifyParentIDs=[];
    var _this = this; //这样可以让事件在外部调用此实例
    this.Init = function () {

        
        for (var i = 1; i <= this.LevelLenght; i++) {
            var show = "style='display:none'";
            if (i == 1) show = "";
            var html = " <select   size=" + this.Size + " " + show + " lv=" + i + "   id='" + this.GetID(i) + "'><option selected='selected' value='-1'>请选择</option></select>";
            
            var selectbox = $($.parseHTML(html)).appendTo("#" + this.CtrID);
           
            if (i < this.LevelLenght) {
              
                $("#" + this.GetID(i)).change(function () {
                    _this.ModifyParentIDs.length = 0;
                    _this.Lavel = parseInt($(this).attr("lv"));
                    
                    var pidParentID = get_selected_value(this);
                
                    if (_this.ApiName == 'wcf') {
                        if (_this.SiteID == 0) {
                            //                            runebws(_this.ApiFunctionName, { pid: pidParentID }, _this.InitDroCtr);

                            runebws(_this.ApiFunctionName, { pid: pidParentID }, _this.InitDroCtr);
                        }
                        else {

                            runebws(_this.ApiFunctionName, { pid: pidParentID, sid: _this.SiteID }, _this.InitDroCtr);
                        }
                    }
                    else {
                        if (_this.ModuleID == "") {
                            runws(_this.ApiFunctionName, { pid: pidParentID, sid: _this.SiteID }, _this.InitDroCtr);
                        }
                        else {
                            runws(_this.ModuleID, _this.ApiFunctionName, { pid: pidParentID, sid: _this.SiteID }, _this.InitDroCtr);
                        }

                    }


                    $("#" + _this.ValueID).val(pidParentID);
                    if (_this.Fun != null)
                        _this.Fun(this);
                });
            }
            else {
                $("#" + this.GetID(i)).change(function () {
                    _this.ModifyParentIDs.length = 0;
                    var pidParentID = get_selected_value(this);
                    $("#" + _this.ValueID).val(pidParentID);
                });
            }

        }

        var MValue = $("#" + this.ValueID).val();
        if (MValue != "") {
            this.ModifyValue = parseInt(MValue);
            this.BindModify();
        }
        else {

            //初始第一个选项的的下拉列表
            this.Lavel = 0;
            var typedrpdatalist = typeof(ebdrpdatalist);
            if (typedrpdatalist == "undefined" ) {
                this.BindCtrData("0");
            } else {
                this.InitDroCtr2(ebdrpdatalist);
            } 
        }


    },
    this.GetID = function (Level) {
        return this.CtrID + Level + "Select";
    },
     this.BindCtrData = function (spid) {

         if (_this.ApiName == 'wcf') {

             if (_this.SiteID == 0) {
                 runebws(_this.ApiFunctionName, { pid: spid }, _this.InitDroCtr);
             }
             else {

                 runebws(_this.ApiFunctionName, { pid: spid, sid: _this.SiteID }, _this.InitDroCtr);

             }
         }
         else {
             if (_this.ModuleID == "") {
                 runws(_this.ApiFunctionName, { pid: spid, sid: _this.SiteID }, _this.InitDroCtr);
             }
             else {

                 runws(_this.ModuleID, _this.ApiFunctionName, { pid: spid, sid: _this.SiteID }, _this.InitDroCtr);
             }

         }
     },
    this.BindModify = function () {
        
        var ids = $("#" + this.ValueID + "P").val();
        
        this.ModifyParentIDs = ids.split(",");
        
        this.Lavel = 0;
        this.BindCtrData("0");

        //        for (var i = this.ModifyParentIDs.length; i > 0; i--) {

        //            var currentid = this.ModifyParentIDs[i - 1];
        //            this.BindCtrData(currentid);
        //           
        //        }
    },
    this.InitDroCtr = function (dMsgOrObj) {

//        var MsgOrObj = dMsgOrObj.d;
        //        if (_this.ApiName == "wcf") {
        //            MsgOrObj = dMsgOrObj;
        //        }
        //        else {
        //            MsgOrObj = dMsgOrObj.d;
        //        }

        _this.InitDroCtr2(dMsgOrObj.d);

    },
    this.InitDroCtr2 = function (MsgOrObj) {
        if (MsgOrObj.length > 0) {
            $("#" + _this.GetID(_this.Lavel + 1)).show();
            delete_selecte_option(_this.GetID(_this.Lavel + 1), 0);
            _this.BindData(_this.GetID(_this.Lavel + 1), MsgOrObj);
        }
        else {
            $("#" + _this.GetID(_this.Lavel + 1)).hide();
        }

        for (var j = _this.Lavel + 2; j <= _this.LevelLenght; j++) {
            $("#" + _this.GetID(j)).hide();
        }
        //配合修改数据时设置的,由于在this.BindModify里异步无法指定_this.Lavel
        if (_this.ModifyParentIDs.length > 0 && _this.Lavel < _this.ModifyParentIDs.length) {
            _this.Lavel += 1;

            var currentid = _this.ModifyParentIDs[_this.ModifyParentIDs.length - _this.Lavel];

            _this.BindCtrData(currentid);
        }
    },
    this.BindData = function (slObjID, ListData) {

        for (var i = 0; i < ListData.length; i++) {
            var objModel = ListData[i];
            var svalue = objModel.id;
            var stext = objModel.Name;
            var sOrtherPram = objModel.OrtherPram;
            add_selecte_option(slObjID, svalue, stext, sOrtherPram);

        }
        //配合修改数据时设置的,由于在this.BindModify里异步无法指定_this.Lavel
        if (_this.ModifyParentIDs.length > 0) {
            var currentid = 0;
            if (_this.Lavel < _this.ModifyParentIDs.length)
                currentid = _this.ModifyParentIDs[_this.ModifyParentIDs.length - (_this.Lavel + 1)];
            else
                currentid = $("#" + _this.ValueID).val();
            set_selected_value($("#" + slObjID), currentid);
        }
        

    }


}


