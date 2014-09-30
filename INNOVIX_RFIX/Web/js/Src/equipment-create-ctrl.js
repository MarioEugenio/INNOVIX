app.controller('EquipmentCreateCtrl', function ($scope, $http, $routeParams) {
    $scope.form = {};

    $scope.listLocations = [];

    $scope.init = function () {
        $scope.getAllLocations();
        if ($routeParams.id)
            $scope.get($routeParams.id);
    }

    $scope.get = function (id) {
        $http.post('equipment/get', { Id: id })
              .success(function (data) {
                  console.log(data);
                  if (data.length > 0)
                      $scope.form = data[0];
                  
              });
    }

    $scope.getAllLocations = function () {
        $http.post('location/getAll', {})
            .success(function (data) {
                $scope.listLocations = data;
            });
    }

    $scope.save = function () {

    }
});