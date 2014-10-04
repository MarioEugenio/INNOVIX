app.controller('LocationCreateCtrl', function ($scope, $http, $routeParams, $location) {
    $scope.form = {};

    $scope.init = function () {
        if ($routeParams.id)
            $scope.get($routeParams.id);
    }

    $scope.get = function (id) {
        $http.post(baseUrl + '/location/get', { Id: id })
              .success(function (data) {
                  if (data.length > 0)
                    $scope.form = data[0];
              });
    }

    $scope.save = function () {
        var form = angular.copy($scope.form);

        $http.post(baseUrl + '/location/save', form)
               .success(function (response) {
                   if (response.success) {
                       $location.path('/location/list');
                   }

                   Modal.alert(
                          response.message,
                          global.titleModal,
                          response.success
                       );
               });
    }
});