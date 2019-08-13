window.onload = function () {
    var u = navigator.userAgent;
    if (!!u.match(/AppleWebKit.*Mobile.*/)) {
        alert("暂未对手机浏览器进行适配，为了给您更好的体验，请使用电脑浏览器访问！")
        return false;
    }
    var Os=BrowserType();
    if (Os == "0") {
        window.location = "/Home/UpdateBrowser";
    }
};


//判断当前浏览类型
function BrowserType() {
    var userAgent = navigator.userAgent; //取得浏览器的userAgent字符串
    var isOpera = userAgent.indexOf("Opera") > -1; //判断是否Opera浏览器
    var isIE = userAgent.indexOf("compatible") > -1 && userAgent.indexOf("MSIE") > -1 && !isOpera; //判断是否IE浏览器
    var isIE11;
    if (!!window.ActiveXObject || "ActiveXObject" in window)
        isIE11 = userAgent.search(/Trident/i) > -1;
    else
        isIE11 = false;
    var isEdge = userAgent.indexOf("Edge") > -1; //判断是否IE的Edge浏览器
    var isFF = userAgent.indexOf("Firefox") > -1; //判断是否Firefox浏览器
    var isSafari = userAgent.indexOf("Safari") > -1 && userAgent.indexOf("Chrome") == -1; //判断是否Safari浏览器
    var isChrome = userAgent.indexOf("Chrome") > -1 && userAgent.indexOf("Safari") > -1; //判断Chrome浏览器

    if (isIE) {
        var reIE = new RegExp("MSIE (\\d+\\.\\d+);");
        reIE.test(userAgent);
        var fIEVersion = parseFloat(RegExp["$1"]);
        //if (fIEVersion == 7)
        //{ return "IE7"; }
        //else if (fIEVersion == 8)
        //{ return "IE8"; }
        //else  if (fIEVersion == 9)
        //{ return "IE9"; }
        //else 
        if (fIEVersion == 10)
        { return "IE10"; }
        else
        { return "0" }//IE版本过低
    }//isIE end
    if (isIE11) { return "isIE11"; }
    if (isFF) { return "FF"; }
    if (isOpera) { return "Opera"; }
    if (isSafari) { return "Safari"; }
    if (isChrome) { return "Chrome"; }
    if (isEdge) { return "Edge"; }
}





var browser = {

    versions: function () {

        var u = navigator.userAgent, app = navigator.appVersion;

        return {//移动终端浏览器版本信息  

            trident: u.indexOf("Trident") > -1, //IE内核 

            presto: u.indexOf("Presto") > -1, //opera内核 

            webKit: u.indexOf("AppleWebKit") > -1, //苹果、谷歌内核 

            gecko: u.indexOf("Gecko") > -1 && u.indexOf("KHTML") == -1, //火狐内核 

            mobile: !!u.match(/AppleWebKit.*Mobile.*/), //是否为移动终端 

            ios: !!u.match(/\(i[^;]+;( U;)? CPU.+Mac OS X/), //ios终端 

            android: u.indexOf("Android") > -1 || u.indexOf("Linux") > -1, //android终端或者uc浏览器 

            iPhone: u.indexOf("iPhone") > -1, //是否为iPhone或者QQHD浏览器 

            iPad: u.indexOf("iPad") > -1, //是否iPad 

            webApp: u.indexOf("Safari") == -1 //是否web应该程序，没有头部与底部 

        };

    }(),

    language: (navigator.browserLanguage || navigator.language).toLowerCase()

}

