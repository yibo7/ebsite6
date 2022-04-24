
			var adtime = setTimeout('displayswf()', 1000);
			var nflag=0;
			var t =0;
		    function displayswf()
			{
  					if(window.navigator.userAgent.indexOf("Firefox")>=1) 
                   {
 				          document.getElementById("AdDiv").style.display='none';
						   document.getElementById("flashswf").style.display='block';
				   }
				   else
				   {
							var  nPercentLoaded = Math.abs(movie.PercentLoaded());
			 
							if(nPercentLoaded ==100)
							{
			 
							   document.getElementById("AdDiv").style.display='none';
							   document.getElementById("flashswf").style.display='block';
							    clearTimeout(t);
							}
							else
							{
							 t= setTimeout('displayswf()', 2000); 
				            }
				 }
 			   	clearTimeout(adtime);
			}
			downProgressWidth=478;
			movie = document.getElementById("flashgame");
		    var nTimeoutId = setTimeout('refreshProgress()',0);
			function refreshProgress()
			{
			    
				var nPercentLoaded = Math.abs(movie.PercentLoaded());
				
				bar.style.width=Math.ceil((downProgressWidth-2)*nPercentLoaded/100)+"px";
                 bar.innerHTML= nPercentLoaded+"%";
				if(nPercentLoaded==100)
				{
					clearTimeout(nTimeoutId);
					bar.style.width=(downProgressWidth-2)+"px";
					bar.innerHTML= "100%";
					downStatus.innerHTML="下载完毕";
					document.getElementById("pgbar").style.display='none';
 				  }
				  else
				  {
					   nTimeoutId = setTimeout('refreshProgress()',300);
 				  }
				}
				
				
   			var bar = document.getElementById("bar");
		