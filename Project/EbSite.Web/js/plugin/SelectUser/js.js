function SelectUser() {
    this.UserNameID = "";
    this.UserNiNameID = "";
    this.UserIDID = "";
    this.UserGroupID = 0;
    this.UserSelType = 1;
    var _this = this; //这样可以让事件在外部调用此实例
    this.Init = function (unid, uninid, uidid, gid, sType) {
        this.UserNameID = unid;
        this.UserNiNameID = uninid;
        this.UserIDID = uidid;
        this.UserGroupID = gid;
        this.UserSelType = sType;
        In.ready('poshytip', function () {
            $('#' + _this.UserNiNameID + '').poshytip(
                    {
                        content: ' <iframe  src="' + SiteConfigs.UrlIISPath + 'js/plugin/SelectUser/usersel.html?obuniname=' + _this.UserNiNameID + '&obuid=' + _this.UserIDID + '&obuname=' + _this.UserNameID + '&gid=' + _this.UserGroupID + '&sType=' + _this.UserSelType + '&rand=' + Math.random() + '" frameborder="0" width="320" height="180" scrolling="yes" >'
                    }
                );

        });
    }
}
