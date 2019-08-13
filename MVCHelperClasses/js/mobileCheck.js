//手机格式验证
function MobilePhoneCheck() {
    var result = true;
    var mobilePhone = $.trim($("#mobilePhone").val());
    //手机号码规则：可以以0开头+三位固定号段+8为数字*/
    //170是虚拟号段
    /*移动号段16个
     *  134、135、136、137、138、139、147、150、151、152、157、158、159、182、183、187、188 170
     */
    var pattern1 = /^0{0,1}(13[4-9]|147|15[0-2]|15[7-9]|18[23478]|178|170)[0-9]{8}$/;
    /*联通号段7个
     130、131、132、155、156、185、186
     */
    var pattern2 = /^0{0,1}(13[0-2]|15[56]|145|18[56]|176)[0-9]{8}$/;
    /*电信号段4个
    133、153、180、189
    */
    var pattern3 = /^0{0,1}(133|153|180|181|189|177|173)[0-9]{8}$/;

    if (mobilePhone != "" && !pattern1.test(mobilePhone) && !pattern2.test(mobilePhone) && !pattern3.test(mobilePhone)) {
        layer.msg("手机号格式不正确，请输入正确的手机号");
        $("#mobilePhone").focus();
        result = false;
    }
    if (mobilePhone != "") {
        $.ajax({
            type: 'post',
            url: '/User/UserRegister',
            data: { Telephone: mobilePhone },
            success: function (data) {
                console.log(data);
                if (data.Result) {
                    layer.msg('该手机号已被使用，请重新输入');
                    $("#mobilePhone").focus();
                    result = false;
                }
            }
        })
    }
    return result;
}