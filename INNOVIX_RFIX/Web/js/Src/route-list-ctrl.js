app.controller('RouteListCtrl', function ($scope, $http) {
    $scope.list = [];
    $scope.search = "";
    $scope.predicate = 'Id';
    $scope.order = 'ASC';

    $scope.init = function () {
        $scope.getRoute(1);
    };

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
        $scope.searchRoute(1);
    };

    $scope.getRoute = function (current) {
        Loading.showAll();

        $http.post(baseUrl + '/route/GetAll', {
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

    $scope.remove = function (index, item) {
        console.log(item);
        var conf = confirm('Tem certeza que deseja remover?');
        if (conf) {
            $http.post(baseUrl + '/route/remove', { Id: item.Id })
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


    $scope.searchRoute = function (current) {
        if (!$scope.search) {
            $scope.getRoute(current);
            return;
        }

        Loading.showAll();

        $http.post(baseUrl + '/route/GetRoute', {
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

    $scope.setPage = function (pageNo) {
        $scope.currentPage = pageNo;
    };

    $scope.pageChanged = function () {
        $scope.searchRoute(
             $scope.currentPage
        );
    };

    $scope.maxSize = global.limit;
    $scope.currentPage = 1;
});