app.controller('EquipmentCreateCtrl', function ($scope, $http, $routeParams, $location) {
    $scope.form = {};

    $scope.listLocations = [];

    $scope.init = function () {
        $scope.getAllLocations();
        if ($routeParams.id)
            $scope.get($routeParams.id);
    }

    $scope.get = function (id) {
        $http.post(baseUrl + '/equipment/get', { Id: id })
              .success(function (data) {
                  console.log(data);
                  if (data.length > 0)
                      $scope.form = data[0];
                  
              });
    }

    $scope.getAllLocations = function () {
        $http.post(baseUrl + '/location/getAll', {})
            .success(function (data) {
                $scope.listLocations = data;
            });
    }

    $scope.save = function () {
        var form = angular.copy($scope.form);

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