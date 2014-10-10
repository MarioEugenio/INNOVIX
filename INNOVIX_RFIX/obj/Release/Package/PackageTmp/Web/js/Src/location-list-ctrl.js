app.controller('LocationListCtrl', function ($scope, $http) {
    $scope.list = [];
    $scope.search = "";
    $scope.predicate = 'id_localidade';
    $scope.order = 'ASC';

    $scope.init = function () {
        $scope.getLocation(1);
    };

    $scope.sorting = function (predicate) {
        if ($scope.predicate == predicate && $scope.order == 'DESC') {
            return 'glyphicon glyphicon-chevron-down';
        }
        return 'glyphicon glyphicon-chevron-up';
    };

    $scope.remove = function (index, item) {
        console.log(item);
        var conf = confirm('Tem certeza que deseja remover?');
        if (conf) {
            $http.post(baseUrl + '/location/remove', { Id: item.Id })
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


    $scope.sortingTable = function (predicate) {

        if ($scope.predicate == predicate && $scope.order == 'DESC') {
            $scope.predicate = predicate;
            $scope.order = 'ASC';
        } else {
            $scope.predicate = predicate;
            $scope.order = 'DESC';
        }
        $scope.searchLocation(1);
    };

    $scope.getLocation = function (current) {
        $http.post(baseUrl + '/location/GetAll', {
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

    $scope.searchLocation = function (current) {
        if (!$scope.search) {
            $scope.getLocation(current);
            return;
        }

        $http.post(baseUrl + '/location/GetLocation', {
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
        $scope.getLocation(
             $scope.currentPage
        );
    };

    $scope.maxSize = global.limit;
    $scope.currentPage = 1;
});