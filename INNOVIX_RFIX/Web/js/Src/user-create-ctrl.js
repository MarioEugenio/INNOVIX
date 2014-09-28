app.controller('UserCreateCtrl', function ($scope, $http) {
    $scope.form = {};
    $scope.listProfile = [];

    $scope.init = function () {
        $scope.getAllProfile();
    };

    $scope.getAllProfile = function () {
        var list = [];
        $http({ method: 'POST', url: 'profile/getAll' }).
          success(function (data, status, headers, config) {
              list = data;
          });

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