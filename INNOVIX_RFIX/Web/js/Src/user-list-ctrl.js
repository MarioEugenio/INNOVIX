app.controller('UserListCtrl', function ($scope, $http) {
    $scope.listUser = [];
    $scope.search = "";
    $scope.predicate = 'id';
    $scope.order = 'ASC';

    $scope.init = function () {
        $scope.getUser(1);
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

        $scope.searchUser(1);
    };

    $scope.remove = function (index, item) {
        console.log(item);
        var conf = confirm('Tem certeza que deseja remover ' + item.noUsuario.trim() + '?');
        if (conf) {
            $http.post(baseUrl + '/user/remove', { Id: item.Id })
               .success(function (response) {
                   if (response.success) {
                       $scope.listUser.split(index, 1);
                   }

                   Modal.alert(
                          response.message,
                          global.titleModal,
                          response.success
                       );
               });
        }
    }

    $scope.getUser = function (current) {
        $http.post(baseUrl + '/user/GetAll', {
            limit: global.limit,
            offset: current,
            predicate: $scope.predicate,
            order: $scope.order
        })
        .success(function (response) {
            $scope.listUser = response.data;
            $scope.totalItems = response.total;
        });

    }

    $scope.searchUser = function (current) {
        if (!$scope.search) {
            $scope.getUser(current);
            return;
        }

        $http.post(baseUrl + '/user/GetUser', {
            search: $scope.search,
            limit: global.limit,
            offset: current,
            predicate: $scope.predicate,
            order: $scope.order
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