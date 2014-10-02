app.controller('RouteCreateCtrl', function ($scope, $http, $routeParams) {
    $scope.form = {};

    $scope.init = function () {
        if ($routeParams.id)
            $scope.get($routeParams.id);
    }

    $scope.get = function (id) {
        $http.post(baseUrl + '/route/get', { Id: id })
              .success(function (data) {
                  if (data.length > 0)
                    $scope.form = data[0];
              });
    }

    $scope.save = function () {

    }
});