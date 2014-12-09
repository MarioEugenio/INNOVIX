var numLoadings = 0;
var Loading = {
    show: function (component) {
        var html = ' <div id="load" style="width: 100%;height: 100;"><img src="/Web/img/ajax-loader.gif" style="vertical-align: middle;">&nbsp;Processando...</div>';
        $(component).html(html);
    },
    hide: function () {
        $('#load').hide(300);
    },
    showAll: function () {
        //$(".form-loading").center();
        $('.form-loading').css('margin-left', (($('body').width() - 200) / 2) + 'px');
        numLoadings++;
        $("#loading").fadeIn(300);
    },
    hideAll: function () {
        numLoadings--;
        if (numLoadings < 0) numLoadings = 0;
        if (numLoadings == 0) $("#loading").fadeOut(500);
    }
}