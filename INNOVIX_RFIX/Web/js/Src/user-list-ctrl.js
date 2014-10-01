app.controller('UserListCtrl', function ($scope, $http) {
    $scope.listUser = [];
    $scope.search = "";

    $scope.init = function () {
        $scope.getUser(1);
    };

    $scope.getUser = function (current) {
        $http.post('user/GetAll', {
            limit: global.limit,
            offset: current
        })
        .success(function (response) {
            $scope.listUser = response.data;
            $scope.totalItems = response.total;
        });

    }

    $scope.searchUser = function (current) {
        $http.post('user/GetUser', {
            search: $scope.search,
            limit: global.limit,
            offset: current
        })
        .success(function (response) {
            $scope.listUser = response.data;
            $scope.totalItems = response.total;
        });

    }

    $scope.pageChanged = function () {
        $scope.getUser(
             $scope.currentPage
        );
    };

    $scope.maxSize = global.limit;
    $scope.currentPage = 1;
});