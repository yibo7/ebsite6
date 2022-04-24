<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PgSelectUsers.aspx.cs" Inherits="EbSite.Modules.BBS.ExtensionsCtrls.PgSelectUsers" %>

<html >
<head id="Head1" runat="server">
</head>
<body >
<style>
    .TreeList span{ cursor:pointer}
</style>
    <form id="form1" runat="server">
    <div id="UserList">
       <asp:TreeView ID="ListTreeView" CssClass="TreeList" runat="server" CollapseImageUrl="~/images/tree/w2.gif"
                                    ExpandImageUrl="~/images/tree/w1.gif" NodeIndent="10" ShowLines="True">
                                </asp:TreeView>
    </div>
               
    </form>

    <script>
        var sSplit = ",";
        var obUserNameBox = parent.$("#" + GetUrlParams("un"));
        var obRealNameBox = parent.$("#" + GetUrlParams("rn"));
        var obUserIDsBox = parent.$("#" + GetUrlParams("ids"));


        function CheckUser(obj) {


            var bType = $(obj).attr("type");


            if (bType == "radio") {

                var sValue = $(obj).val();

                var UserData = sValue.split(sSplit);
                var UserID = UserData[0];
                var UserName = UserData[1];
                var RealName = UserData[2];

                obRealNameBox.val(RealName);
                obUserNameBox.val(UserName);
                obUserIDsBox.val(UserID);
            }
            else {

                var aUserIDs = [];
                var aUserNames = [];
                var aRealNames = [];

                $("#UserList").find("input[type=checkbox]").each(
		                function (i) {
		                    if (this.checked) {
		                        var UserData = this.value.split(sSplit);
		                        var UserID = UserData[0];
		                        var UserName = UserData[1];
		                        var RealName = UserData[2];
		                        aUserIDs.push(UserID);
		                        aUserNames.push(UserName);
		                        aRealNames.push(RealName);


		                    }
		                }
		            );
                obRealNameBox.text(aRealNames.join(","));
                obUserNameBox.val(aUserNames.join(","));
                obUserIDsBox.val(aUserIDs.join(","));

            }



        }

        function DataInit() {

            var aUserIDs = [];
            var aUserNames = [];
            var aRealNames = [];

            var sUserIDs = obUserIDsBox.val();
            var sUserNames = obUserNameBox.val();
            var sRealNames = obRealNameBox.val();

            var aDatas = [];
            if (sUserIDs != "") {
                aDatas = sUserIDs.split(sSplit);
            }
            else if (sUserNames != "") {
                aDatas = sUserNames.split(sSplit);
            }
            else if (sRealNames != "") {
                aDatas = sRealNames.split(sSplit);
            }


            $("#UserList").find("input[type=checkbox]").each(
		                function (i) {
		                    var UserData = this.value.split(sSplit);
		                    var UserID = UserData[0];
		                    var UserName = UserData[1];
		                    var RealName = UserData[2];

		                    if (sUserIDs != "") {
		                        if (aDatas.Contains(UserID)) {
		                            aUserIDs.push(UserID);
		                            aUserNames.push(UserName);
		                            aRealNames.push(RealName);
		                            this.checked = true;
		                        }
		                    }
		                    else if (sUserNames != "") {

		                        if (aDatas.Contains(UserName)) {
		                            aUserIDs.push(UserID);
		                            aUserNames.push(UserName);
		                            aRealNames.push(RealName);
		                            this.checked = true;
		                        }
		                    }
		                    else if (sRealNames != "") {
		                        if (aDatas.Contains(RealName)) {

		                            aUserIDs.push(UserID);
		                            aUserNames.push(UserName);
		                            aRealNames.push(RealName);
		                            this.checked = true;
		                        }
		                    }


		                }
		            );

            //		                obRealNameBox.text(aRealNames.join(","));
            //		                obUserNameBox.val(aUserNames.join(","));
            //		                obUserIDsBox.val(aUserIDs.join(","));

        }



        $(function () {
            DataInit();
        });
        
    </script>
</body>
</html>
