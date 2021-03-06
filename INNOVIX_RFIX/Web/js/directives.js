﻿
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
    })

    .directive('phone', function () {

        return {
            scope: true,
            link: function (scope, element, attrs) {
                element.inputmask('(99)9999[9]-9999');
            }

        };
    })

    .directive('select2', function () {

        return {
            scope: true,
            link: function (scope, element, attrs) {
                element.select2({ width: 'off' });
            }

        };
    });