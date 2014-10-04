var Modal = {
    alert: function (text, title, typeAlert) {
        $('#myModalAlert').remove();

        var htmlTitle = '<h4 class="modal-info"><span class="ico_information">' + title + '</span></h4>';

        if (typeAlert == true) {
            htmlTitle = '<h4 class="modal-success"><span class="glyphicon glyphicon-ok"></span> ' + title + '</h4>';
        }

        if (typeAlert == false) {
            htmlTitle = '<h4 class="modal-warning"><span class="glyphicon glyphicon-warning-sign"></span> ' + title + '</h4>';
        }

        var html = '<div class="modal fade" id="myModalAlert" tabindex="-1" role="dialog" aria-labelledby="myModalAlert" >';
        html += '<div class="modal-dialog">';
        html += '<div class="modal-content">';
        html += '<div class="modal-header">';
        html += '   <button class="close" onclick="Modal.close(\'myModalAlert\')" data-dismiss="modal">×</button>';
        html += htmlTitle;
        html += '</div>';
        html += '<div id="modal-body" class="modal-body">';
        html += '<p><h4>' + text + '</h4></p>';
        html += '</div>';
        html += '<div class="modal-footer">';
        html += '<a href="#" class="btn btn-primary"  data-dismiss="modal" onclick="Modal.close(\'myModalAlert\');">OK</a>';
        html += '</div>';
        html += '</div>';
        html += '</div>';
        html += '</div>';

        $('body').append(html);

        $('#myModalAlert').modal('show');
    },

    confirm: function (text, type, callback, callbackCancel) {
        var n = noty({
            text: text,
            type: type,
            dismissQueue: true,
            buttons: true,
            modal: true,
            layout: 'center',
            theme: 'bootstrap',
            buttons: [
                {
                    addClass: 'btn btn-primary', text: 'Ok', onClick: callback
                },
                {
                    addClass: 'btn', text: 'Cancelar', onClick: function ($noty) {
                        if (typeof callbackCancel != 'undefined') {
                            callbackCancel();
                        }
                        $noty.close();
                    }
                }
            ]
        });
    },

    growl: function (text, type) {
        if (type == 'error') {
            $.sticky('<li class="icon-exclamation-sign"></li></span> <b>' + text + '</b>');
        }

        if (type == 'success') {
            $.sticky('<li class="icon-ok-circle"></li></span> <b>' + text + '</b>');
        }
    }

};