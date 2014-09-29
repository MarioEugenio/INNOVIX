﻿app.controller('UserCreateCtrl', function ($scope, $http, $routeParams) {
    $scope.form = {};
    $scope.listProfile = [];

    $scope.init = function () {
        $scope.getAllProfile();

        if ($routeParams.id)
            $scope.get($routeParams.id);
    }

    $scope.get = function (id) {
        $http.post('user/get', { Id: id })
              .success(function (data) {
                  if (data.length > 0)
                    $scope.form = data[0];
              });
    }

    $scope.getAllProfile = function () {

        $http.post('profile/getAll', {})
               .success(function (data) {
                   $scope.listProfile = data;
               });

    }

    $scope.enableForm = function () {
        if (($scope.form.codSenha) && ($scope.form.confCodSenha)) {
            if ($scope.form.codSenha == $scope.form.confCodSenha) {
                return false;
            }
        }

        return true;
    }

    $scope.save = function () {

    }
});