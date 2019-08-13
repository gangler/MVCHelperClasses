/**
 * 取随机数
 */
function randomNum(Min,Max){   
	var Range = Max - Min;   
	var Rand = Math.random();   
	return(Min + Math.round(Rand * Range));   
}   
/**
 * 用途：将checkbox全选或取消
 */
function doAllChecked(){
	var isChecked;
	isChecked = document.getElementById("allbox").checked;
	var chkEls = document.getElementsByName("chkElement");
    for(var i=0;i<chkEls.length;i++){
    	if(chkEls[i].disabled == false)
          chkEls[i].checked = isChecked;
    }
}

/**
 * 用途：获取所有指定名称Checkbox并被选中上的值.
 * 输入：控件名称
 */
function getChkValueArray(elemName){
    var ids = new Array();
    var chkEls = document.getElementsByName(elemName);
    for(var i=0;i<chkEls.length;i++){
        if(chkEls.item(i).checked){
          ids[ids.length] = chkEls.item(i).value;
        }
    }
	return ids;
}

/**
 * 用途：提交表单，并屏蔽提交按钮，避免二次提交.
 */
function onSubmit(){
  var form = document.forms[0];
  if(checkInput(form) == false) return false;
  var btn = document.forms[0].btnSubmit;
  btn.disabled = true;
  btn.value = "正在保存,请稍候...";
  document.forms[0].submit();
}

/**
 * 用途：选中行中的复选框.
 */
function onRowChecked(obj){
  var className = 'rowUnchecked';
  if(obj.checked === true) className = 'rowChecked';
  obj.parentNode.parentNode.className = className;
}

/*
 * 用途：查找TR中的checkbox对象
 */
function findChildCheckbox(obj){
  var inputs = obj.getElementsByTagName('INPUT');
  for(var i=0; i<inputs.length; i++){
	if(inputs[i].type == "checkbox")
	  return inputs[i];
  }
}

/**
 * 用途：鼠标移到TR上时，改变样式.
 * 用途：tr对象.
 */
function onRowFocus(tr){
  var checked = false;
  var chk = findChildCheckbox(tr);
  if(chk != undefined && chk.checked == true)
    checked = true;
  if(!checked) tr.className='datalistOn';
}

/**
 * 用途：鼠标离开TR上时，改变样式.
 * 用途：tr对象.
 */
function onRowUnfocused(tr){
  var checked = false;
  var chk = findChildCheckbox(tr);
  if(chk != null && chk.checked == true)
    checked = true;
  if(!checked) tr.className='datalist';
}

/**
 * 用途：对象所在的位置(兼容IE/FF)
 * 输入：e 目标对象
 * 返回：x,y坐标数组
 */
function getPosition(e){
  var offsetParent,x,y;
  offsetParent = e;
  var x=0,y=0;
  while(offsetParent!=null && offsetParent.tagName.toUpperCase()!="BODY") {
	x+=offsetParent.offsetLeft;
	y+=offsetParent.offsetTop;
	offsetParent=offsetParent.offsetParent;
  }
  return [x,y];
}

/**
 * 用途: 判断是否为整型数字
 * 输入: str字符串
 * 返回：如果通过验证返回true,否则返回false
 */
function isInteger(str){ 
  var regu = /^[-]{0,1}[0-9]{1,}$/;
  return regu.test(str);
}

/**
 * 用途：检查输入字符串是否符合正整数格式
 * 输入：s 字符串
 * 返回:如果通过验证返回true,否则返回false
 */
function isNumber(s){  
  var regu = "^[0-9]+$";
  var re = new RegExp(regu);
  if (s.search(re) != -1) return true;
  else return false;
}

/**
 * 用途：检查输入对象的值是否符合E-Mail格式
 * 输入：str 输入的字符串
 * 返回：如果通过验证返回true,否则返回false
 */
function isEmail(str){ 
  var myReg = /^[-_A-Za-z0-9.]+@(([_A-Za-z0-9]+\.)+[A-Za-z0-9]{2,3}$)|@([_A-Za-z0-9])/;
  if(myReg.test(str)) return true;
  return false;
}

/**
 * 用途：检查输入对象的值是符合长度限制
 * 输入：str 输入的字符串,len 限制的长度
 * 返回：如果通过验证返回true,否则返回false
 */
function checkTextLength(str,len){
  return (str != null && str.length > len)
  		 ? false : true;
}


/**
 * 模态窗口高度调整.
 * 根据操作系统及ie不同版本,重新设置窗口高度,避免滚动条出现.
 */
function resetDialogHeight(){
	if(window.dialogArguments == null){
		return; //忽略非模态窗口
	}

	var ua = navigator.userAgent;
	var oHeight = document.body.offsetHeight;
	var sHeight = document.body.scrollHeight;
	if(oHeight+20 > sHeight){
		return; //已做调整.
	}
	if(ua.lastIndexOf("MSIE 6.0") != -1){
		if(ua.lastIndexOf("Windows NT 5.1") != -1){
	 		//alert("xp.ie6.0");
			window.dialogHeight=(oHeight+102)+"px";
		}
		else if(ua.lastIndexOf("Windows NT 5.0") != -1){
			//alert("w2k.ie6.0");
			window.dialogHeight=(oHeight+49)+"px";
		}
	}
}

/**
* 用途:字串函数
*/
String.prototype.Trim = function()
{
    return this.replace(/(^\s*)|(\s*$)/g, "");
}

/**
 * 用途：设置cookies函数
 */
function SetCookie(name,value){
    var Days = 10; //此 cookie 将被保存 30 天
    var exp  = new Date(); //new Date("December 31, 9998");
    exp.setTime(exp.getTime() + Days*24*60*60*1000);
    document.cookie = name + "="+ escape (value) + ";expires=" + exp.toGMTString();
}
/**
 * 用途：取cookies函数
 */
function GetCookie(name) {
	var arr = document.cookie.match(new RegExp("(^| )"+name+"=([^;]*)(;|$)"));
	if(arr != null) return unescape(arr[2]); return null;
}
/**
 * 用途：删除cookie
 */
function DelCookie(name){
    var exp = new Date();
    exp.setTime(exp.getTime() - 1);
    var cval=GetCookie(name);
    if(cval!=null) document.cookie= name + "="+cval+";expires="+exp.toGMTString();
}

function formatDate(date, format){
	var d = date.split("-");
	if(d.length == 2){
		d[2] = 1;
	}else if(d.length == 1){
		d[1] = 1;
		d[2] = 1;
	}
	d[1] = d[1]-1;
	var now = new Date();
	now.setFullYear(d[0],d[1],d[2]);
	return now.Format(format);
}

/**
 * 用于检测密码强度
 * @returns 1极弱 2弱 3中 4强
 */
function pwdStrong(pwd){
	if(pwd){
		var score = 0;
		if(pwd.length > 5){
			var digit = false, alpha = false, other = false;
			//assic码：数字48-57 字母：65-90 97-122
			for(var i=0; i<pwd.length; i++){
				var c = pwd.charCodeAt(i);
				if(c>=48 && c<=57){
					digit = true;
				}else if(c>=65 && c<=90){
					alpha = true;
				}else if(c>=97 && c<=122){
					alpha = true;
				}else{
					other = true;
				}
			}
			if(digit) score++;
			if(alpha) score++;
			if(other) score++
		}
		return score;
	}
}