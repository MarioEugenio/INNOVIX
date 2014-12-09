app.controller('EquipmentListCtrl', function ($scope, $http) {
    $scope.list = [];
    $scope.search = "";

    $scope.predicate = 'Id';
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

    $scope.remove = function (index, item) {
        console.log(item);
        var conf = confirm('Tem certeza que deseja remover?');
        if (conf) {
            $http.post(baseUrl + '/equipment/remove', { Id: item.Id })
               .success(function (response) {
                   if (response.success) {
                       $scope.list.splice(index, 1);
                   }

                   Modal.alert(
                          response.message,
                          global.titleModal,
                          response.success
                       );
               });
        }
    }

    $scope.getEquipment = function (current) {
        Loading.showAll();

        $http.post(baseUrl + '/equipment/getAll', {
            limit: global.limit,
            offset: current,
            predicate: $scope.predicate,
            order: $scope.order
        })
        .success(function (response) {
            $scope.list = response.data;
            $scope.totalItems = response.total;

            Loading.hideAll();
        });

    }

    $scope.searchEquipment = function (current) {
        if (!$scope.search) {
            $scope.getEquipment(current);
            return;
        }

        Loading.showAll();

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

            Loading.hideAll();
        });

    }

    $scope.pageChanged = function () {
        $scope.searchEquipment(
             $scope.currentPage
        );
    };

    $scope.maxSize = global.limit;
    $scope.currentPage = 1;
});