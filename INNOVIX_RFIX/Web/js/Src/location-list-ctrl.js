app.controller('LocationListCtrl', function ($scope, $http) {
    $scope.list = [];
    $scope.search = "";

    $scope.init = function () {
        $scope.getLocation(1);
    };

    $scope.getLocation = function (current) {
        $http.post('location/GetAll', {
            limit: global.limit,
            offset: current
        })
        .success(function (data) {
            $scope.list = data;
        });

    }

    $scope.searchLocation = function (current) {
        $http.post('location/GetLocation', {
            search: $scope.search,
            limit: global.limit,
            offset: current
        })
        .success(function (data) {
            $scope.list = data;
        });

    }

    $scope.pageChanged = function () {
        $scope.getLocation(
             $scope.currentPage
        );
    };

    $scope.maxSize = global.limit;
    $scope.totalItems = $scope.list.length;
    $scope.currentPage = 1;
});