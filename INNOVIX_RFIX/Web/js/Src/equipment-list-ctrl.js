app.controller('EquipmentListCtrl', function ($scope, $http) {
    $scope.list = [];
    $scope.search = "";

    $scope.init = function () {
        $scope.getEquipment(1);
    };

    $scope.getEquipment = function (current) {
        $http.post('equipment/getAll', {
            limit: global.limit,
            offset: current
        })
        .success(function (response) {
            $scope.list = response.data;
            $scope.totalItems = response.total;
        });

    }

    $scope.searchEquipment = function (current) {
        $http.post('equipment/getEquipment', {
            search: $scope.search,
            limit: global.limit,
            offset: current
        })
        .success(function (response) {
            $scope.list = response.data;
            $scope.totalItems = response.total;
        });

    }

    $scope.pageChanged = function () {
        $scope.getEquipment(
             $scope.currentPage
        );
    };

    $scope.maxSize = global.limit;
    $scope.currentPage = 1;
});