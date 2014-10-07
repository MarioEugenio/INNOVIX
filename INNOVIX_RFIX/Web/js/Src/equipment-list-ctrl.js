app.controller('EquipmentListCtrl', function ($scope, $http) {
    $scope.list = [];
    $scope.search = "";

    $scope.predicate = 'id_equipamento';
    $scope.order = 'ASC';

    $scope.sorting = function (predicate) {
        if ($scope.predicate == predicate && $scope.order == 'DESC') {
            return 'glyphicon glyphicon-chevron-down';
        }
        return 'glyphicon glyphicon-chevron-up';
    };

    $scope.sortingTable = function (predicate) {
        
        if ($scope.predicate == predicate && $scope.order == 'DESC') {
            $scope.predicate = predicate;
            $scope.order = 'ASC';
        } else {
            $scope.predicate = predicate;
            $scope.order = 'DESC';
        }
        $scope.searchEquipment(1);
    };

    $scope.init = function () {
        $scope.getEquipment(1);
    };

    $scope.getEquipment = function (current) {
        $http.post(baseUrl + '/equipment/getAll', {
            limit: global.limit,
            offset: current,
            predicate: $scope.predicate,
            order: $scope.order
        })
        .success(function (response) {
            $scope.list = response.data;
            $scope.totalItems = response.total;
        });

    }

    $scope.searchEquipment = function (current) {
        if (!$scope.search) {
            $scope.getEquipment(current);
            return;
        }

        $http.post(baseUrl + '/equipment/getEquipment', {
            search: $scope.search,
            limit: global.limit,
            offset: current,
            predicate: $scope.predicate,
            order: $scope.order
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