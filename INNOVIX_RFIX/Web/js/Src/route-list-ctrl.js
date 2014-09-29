app.controller('RouteListCtrl', function ($scope, $http) {
    $scope.list = [];
    $scope.search = "";

    $scope.init = function () {
        $scope.getRoute(1);
    };

    $scope.getRoute = function (current) {
        $http.post('route/GetAll', {
            limit: global.limit,
            offset: current
        })
        .success(function (data) {
            $scope.list = data;
        });

    }

    $scope.searchRoute = function (current) {
        $http.post('route/GetRoute', {
            search: $scope.search,
            limit: global.limit,
            offset: current
        })
        .success(function (data) {
            $scope.list = data;
        });

    }

    $scope.pageChanged = function () {
        $scope.getRoute(
             $scope.currentPage
        );
    };

    $scope.maxSize = global.limit;
    $scope.totalItems = $scope.list.length;
    $scope.currentPage = 1;
});