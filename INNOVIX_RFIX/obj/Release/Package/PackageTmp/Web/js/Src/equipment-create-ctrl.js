app.controller('EquipmentCreateCtrl', function ($scope, $http, $routeParams, $location) {
    $scope.form = {};

    $scope.listLocations = [];

    $scope.init = function () {
        $scope.getLocation();
        if ($routeParams.id)
            $scope.get($routeParams.id);
    }

    $scope.get = function (id) {
        $http.post(baseUrl + '/equipment/get', { Id: id })
              .success(function (data) {
                  if (data.length > 0) {
                      $scope.form = data[0];
                  }
              });
    }

    $scope.getLocation = function (id) {
        $http.post(baseUrl + '/location/getAll', {
            limit: 1000000,
            offset: 1
        })
              .success(function (response) {
                  $scope.listLocations = response.data;
              });
    }

    $scope.save = function () {
        var form = angular.copy($scope.form);
        var tbLocalidade = {
            Id: form.localidade
        };

        form.tbLocalidade = tbLocalidade;

        $http.post(baseUrl + '/equipment/save', form)
               .success(function (response) {
                   if (response.success) {
                       $location.path('/equipment/list');
                   }

                   Modal.alert(
                          response.message,
                          global.titleModal,
                          response.success
                       );
               });
    }
});