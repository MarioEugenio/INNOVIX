app.controller('BoardingListCtrl', function ($scope, $http) {
    $scope.list = [];
    $scope.search = "";

    $scope.predicate = 'noDesc';
    $scope.order = 'ASC';

    $scope.init = function () {
        $scope.getEquipment(1);
    };

    $scope.getEquipment = function (current) {
        Loading.showAll();

        $http.post(baseUrl + '/reportBoarding/getAll', {
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
        $scope.getEquipment(
             $scope.currentPage
        );
    };

    $scope.maxSize = global.limit;
    $scope.currentPage = 1;
});