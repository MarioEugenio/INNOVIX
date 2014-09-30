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
        .success(function (data) {
            $scope.list = data;
        });

    }

    $scope.searchEquipment = function (current) {
        $http.post('equipment/getEquipment', {
            search: $scope.search,
            limit: global.limit,
            offset: current
        })
        .success(function (data) {
            $scope.list = data;
        });

    }

    $scope.pageChanged = function () {
        $scope.getEquipment(
             $scope.currentPage
        );
    };

    $scope.maxSize = global.limit;
    $scope.totalItems = $scope.list.length;
    $scope.currentPage = 1;
});