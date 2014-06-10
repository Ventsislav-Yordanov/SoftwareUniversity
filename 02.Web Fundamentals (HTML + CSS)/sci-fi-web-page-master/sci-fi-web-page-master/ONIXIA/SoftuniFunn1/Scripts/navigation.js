
 
    function changeImage( k)
    {
	switch(k){
	case 1:
     var img = document.getElementById("imgBoss");
	 var txtName = document.getElementById("imgBoss");
	 var txtText = document.getElementById("captionWhat");
     img.style.background=" url(design/Gard.png) no-repeat";
	 img.style.backgroundSize="100%";
	 img.style.backgroundColor="rgba(50,40,40,0.1)";
	 txtName.innerHTML="Gard of Gate";
	 txtText.innerHTML="Gard of Gate is the most strongest monster in univers. His ability is to be nice but strong........";
	 break;
	 
	 case 2:
     var img = document.getElementById("imgBoss");
	 var txtName = document.getElementById("imgBoss");
	 var txtText = document.getElementById("captionWhat");
     img.style.background=" url(design/Shadow.png) no-repeat";
	 img.style.backgroundSize="100%";
	 img.style.backgroundColor="rgba(50,40,40,0.1)";
	 txtName.innerHTML="The Shadow";
	 txtText.innerHTML="The hiden Shadow. Nobody knows him, and nobody have ever seen him. The Dark secrete  is here......... " 
	 break;
	 
	 case 3:
     var img = document.getElementById("imgBoss");
	 var txtName = document.getElementById("imgBoss");
	 var txtText = document.getElementById("captionWhat");
     img.style.background=" url(design/Mahatma.png) no-repeat";
	 img.style.backgroundSize="100%";
	 img.style.backgroundColor="rgba(50,40,40,0.1)"; 
	 txtName.innerHTML="Mahatma";
	 txtText.innerHTML="MAHATMA the priest. His ability is to predict uncknowlige in society........  "
	 break;
	 
	  
	 case 4:
     var img = document.getElementById("imgBoss");
	 var txtName = document.getElementById("imgBoss");
	 var txtText = document.getElementById("captionWhat");
     img.style.background=" url(design/Boss.png) no-repeat";
	 img.style.backgroundSize="100%";
	 img.style.backgroundColor="rgba(50,40,40,0.1)";
	 txtName.innerHTML="The Boss";
	 txtText.innerHTML=" <span style='color:white'>SNAKS</span> is the Boss. His ability is to seek unacknowledged pupil and punish him if they dont know nothing............";
	 break;
	 
	 }
	 return false;
    }
	

	function createCookie(name,value,days) {
	if (days) {
		var date = new Date();
		date.setTime(date.getTime()+(days*24*60*60*1000));
		var expires = "expires="+date.toGMTString();
	}
	else var expires = "";
	document.cookie = name+"="+value+" ; "+expires+" ; path=/";
     }
	
	function readCookie(name) {
	var nameEQ = name + "=";
	var ca = document.cookie.split(';');
	for(var i=0;i < ca.length;i++) {
		var c = ca[i];
		while (c.charAt(0)==' ') c = c.substring(1,c.length);
		if (c.indexOf(nameEQ) == 0) return c.substring(nameEQ.length,c.length);
	}
	return null;
    }
	
	
	function setCookie(cname, cvalue, exdays) {
    var d = new Date();
    d.setTime(d.getTime() + (exdays*24*60*60*1000));
    var expires = "expires="+d.toGMTString();
    document.cookie = cname + "=" + cvalue + "; " + expires;
}

   function getCookie(cname) {
    var name = cname + "=";
    var ca = document.cookie.split(';');
    for(var i=0; i<ca.length; i++) {
        var c = ca[i].trim();
        if (c.indexOf(name) == 0) return c.substring(name.length, c.length);
    }
    return null;
    }
	
	function checkCookie(cname,cvalue) {
    
	  if(getCookie(cname)==null){setCookie(cname,cvalue,1);}
	
	
    }
	
	
