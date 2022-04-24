

/*

js中的分页类，如在ajax中分页使用，使用办法如下:
var mypages = 	new cnPages();		
    mypages.RecordCount = 100;//记录总数
    mypages.PageSize = 15;//每页显示记录数
var current_page = 0;  //当前页码
function InitPages()
	{		
		mypages.initPage(current_page);
		var pagesHTML = mypages.showpages();		
		PagesInfo.innerHTML =  pagesHTML;
	}

    function onc_chnage_page(thispage)
	{
		current_page = thispage;
		//执行ajax请求         
		ajaxallinfo(当前页码,每页显示记录数);//异步执行完毕后的回调办法里执行 InitPages
		
	}

*/



function cnPages()
{
		var iCurrentPage = 0;

        var iPageNum = 0;
		var thisObj = this;
        var  arrCurrentShowCout = [];
		//var strURL = "";
        this.PagesHTML = "";
        this.RecordCount = 0;
        this.PageSize = 15;
        this.UrlWeb="";
		this.initPage = function(_iCurrentPage)
		{
			iCurrentPage = _iCurrentPage;
			iPageNum = Math.ceil(this.RecordCount / this.PageSize);
			
            //strURL = _strURL;
            thisObj.intiCurrentShowCout();
         
		};
		this.intiCurrentShowCout = function()
        {
			arrCurrentShowCout.length = 0;
            for (var k = iCurrentPage - 5; k <= iCurrentPage + 5; k++)
            {
                if (k < 0) continue;
                if (k >= iPageNum) break;

                arrCurrentShowCout.push(k);
            }
        };
		this.showpages = function()
        {
            var sb = "";
            if (iCurrentPage > 1) sb += "<a onclick=\"onc_chnage_page(" + (iCurrentPage - 1) + ");return false\" href=\"" + this.UrlWeb + "\">上一页</a>&nbsp;";
		
			for(var i=0;i<arrCurrentShowCout.length;i++)
			{
				var thisPage = arrCurrentShowCout[i];

				sb += (((thisPage + 1) == iCurrentPage) ? "<b>" + (arrCurrentShowCout[i] + 1) + "</b>&nbsp;" : "<a onclick=\"onc_chnage_page(" + (thisPage + 1) + ");return false\" href=\"" + this.UrlWeb + "\">[" + (thisPage + 1) + "]</a>&nbsp;");
			}
	if (iCurrentPage < iPageNum) sb += "<a onclick=\"onc_chnage_page(" + (iCurrentPage + 1) + ");return false\" href=\"" + this.UrlWeb + "\">下一页</a>";
			
			return sb;		
           
        }
}
		
        