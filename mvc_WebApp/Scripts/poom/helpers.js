
var _prefix = $('#h_prefix').val();

function ajaxPost(webMethod, data, fxSuccess, isStringifyData, isAsync) {
    loader_show();

    var result;
    if (typeof isAsync === 'undefined' || isAsync == null) {
        isAsync = true;
    }
    if (typeof fxSuccess === 'undefined' || fxSuccess == null) {
        isAsync = false;
        fxSuccess = function (response) {
            result = response;
        }
    }
    if (isStringifyData === true) {
        data = "{'data':" + JSON.stringify(data) + "}";
    } else {
        data = JSON.stringify(data);
    }
    var result2 = $.ajax({
        async: isAsync
        , type: "POST"
        , url: webMethod
        , contentType: "application/json; charset=utf-8"
        , dataType: "json"
        , data: data
        , success: fxSuccess,
        error: function (xhr, status, msg) {
            var error = eval("(" + xhr.responseText + ")");
            console.log(error.Message);
            result = null;
        }
    });

    return isAsync ? result2 : result;
}
function loader_hide() {
    $('#divProgress').fadeOut();
}
function loader_show() {
    $('#divProgress').show();
}

function getPath(url) {
    var _url = _prefix + url;
    return _url;
}

function roundfix2(val) {
    tmp = Math.round(parseFloat(val) * 10 * 10) / 10 / 10;
    vals = parseFloat(tmp.toFixed(2));
    return vals;
}
function commasAddFloat(val) {

    if (val == '' || val == 0) {
    } else {
        val = roundfix2(val).toFixed(2);
        while (/(\d+)(\d{3})/.test(val.toString())) {
            val = val.toString().replace(/(\d+)(\d{3})/, '$1' + ',' + '$2');
        }
    }
    return val;
}
function commasAdd(val) {

    if (val == '' || val == 0) {
    } else {
        val = parseFloat(val);
        while (/(\d+)(\d{3})/.test(val.toString())) {
            val = val.toString().replace(/(\d+)(\d{3})/, '$1' + ',' + '$2');
        }
    }
    return val;
}

function num_key(evt) {
    evt = evt || windows.event;
    var iKeyCode = evt.keyCode || evt.which;

    if (iKeyCode > 47 && iKeyCode < 58 || iKeyCode == 8 || iKeyCode == 9) {
        return true;
    } else {
        return false;
    }
}

function getQueryString(sParam) {
    var sPageURL = decodeURIComponent(window.location.search.substring(1));
    var sURLVar = sPageURL.split('&');
    for (var i = 0; i < sURLVar.length; i++) {
        var sParamName = sURLVar[i].split('=');
        if (sParamName[0] == sParam) {
            return sParamName[1] || "";
        }
    }
    return "";
}

function getFileExtension(filename) {
    return (/[.]/.exec(filename)) ? '' + /[^.]+$/.exec(filename) : ''; //undefined;
}

//$('#btn_logout').on('click', function () {
//    var tmp = ajaxPost(getPath('import/chkOut'), '{}');
//    if (tmp) {
//        location.href = '/partner_payment/login.aspx';
//    }
//});
function chkUser_Login() {
    if (location.pathname.toLowerCase().indexOf('login.aspx') > -1) {
        console.info('true')
        $('#navbar').find('.nav').hide();
    } else {
        console.info('false')
        $('#navbar').find('.nav').show();
    }
}

Date.prototype.addDays = function (days) {
    var dat = new Date(this.valueOf());
    dat.setDate(dat.getDate() + days);
    return dat;
}

