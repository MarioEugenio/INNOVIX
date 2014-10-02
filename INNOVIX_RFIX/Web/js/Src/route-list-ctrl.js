app.controller('RouteListCtrl', function ($scope, $http) {
    $scope.list = [];
    $scope.search = "";

    $scope.init = function () {
        $scope.getRoute(1);
    };

    $scope.getRoute = function (current) {
        $http.post(baseUrl + '/route/GetAll', {
            limit: global.limit,
            offset: current
        })
        .success(function (response) {
            $scope.list = response.data;
            $scope.totalItems = response.total;
        });

    }

    $scope.searchRoute = function (current) {
        $http.post(baseUrl + '/route/GetRoute', {
            search: $scope.search,
            limit: global.limit,
            offset: current
        })
        .success(function (response) {
            $scope.list = response.data;
            $scope.totalItems = response.total;
        });

    }

    $scope.setPage = function (pageNo) {
        $scope.currentPage = pageNo;
    };

    $scope.pageChanged = function () {
        $scope.getRoute(
             $scope.currentPage
        );
    };

    $scope.maxSize = global.limit;
    $scope.currentPage = 1;
});