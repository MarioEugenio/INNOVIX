app.controller('UserCreateCtrl', function ($scope, $http, $routeParams, $location) {
    $scope.form = {};
    $scope.listProfile = [];

    $scope.init = function () {
        $scope.radioCPF = 'CPF';
        $scope.getAllProfile();

        if ($routeParams.id)
            $scope.get($routeParams.id);
    }

    $scope.get = function (id) {
        $http.post(baseUrl + '/user/get', { Id: id })
              .success(function (data) {
                  if (data.length > 0)
                      $scope.form = data[0];

                  $scope.form.noEmail = $scope.form.noEmail.trim();
                  $scope.form.TbPerfil = {
                      Id: $scope.form.idPerfil
                  };
                
              });
    }

    $scope.getAllProfile = function () {

        $http.post(baseUrl + '/profile/getAll', {})
               .success(function (data) {
                   $scope.listProfile = data;
               });

    }

    $scope.enableForm = function () {
        if (($scope.form.password) && ($scope.form.confCodSenha)) {
            if ($scope.form.password == $scope.form.confCodSenha) {
                return false;
            }
        }

        return true;
    }
    
    $scope.save = function () {
        var form = angular.copy($scope.form);

        form.idTipoUsuario = ($scope.radioCPF == 'CPF') ? 1 : 2;

        $http.post(baseUrl + '/user/save', form)
               .success(function (response) {
                   if (response.success) {
                       $location.path('/user/list');
                   }

                   Modal.alert(
                          response.message,
                          global.titleModal,
                          response.success
                       );
            });
    }
});