angular.module('innovix', [])
    .directive('cpf', function () {

        return {
            scope: true,
            link: function (scope, element, attrs) {
                element.inputmask('999.999.999-99');
            }

        };
    })

    .directive('cnpj', function () {

        return {
            scope: true,
            link: function (scope, element, attrs) {
                element.inputmask('99.999.999/9999-99');
            }

        };
    });