app.controller('ReportItemListCtrl', function ($scope, $http, $modal, $routeParams) {
    $scope.list = [];
    $scope.search = "";
    $scope.predicate = 'id';
    $scope.order = 'ASC';
    $scope.listLocation = [];

    $scope.init = function () {
        $scope.getLocation();
        $scope.getReportItem(1);
    };

    $scope.getLocation = function (id) {
        $http.post(baseUrl + '/location/getAll', {
            limit: 1000000,
            offset: 1
        })
              .success(function (response) {
                  $scope.listLocation = response.data;
              });
    }

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
        $scope.search(1);
    };

    $scope.getReportItem = function (current) {
        $http.post(baseUrl + '/reportItem/getAll', {
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

    $scope.search = function (current) {
        if (!$scope.search) {
            $scope.getReportItem(current);
            return;
        }
        $http.post(baseUrl + '/reportItem/getReportItem', {
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

    $scope.clear = function () {
        $scope.search = {};
    }
    $scope.pageChanged = function () {
        $scope.getReportItem(
             $scope.currentPage
        );
    };

    $scope.maxSize = global.limit;
    $scope.currentPage = 1;

    $scope.open = function (id) {
        $routeParams.id = id
        $modal.open({
            templateUrl: '/ReportItem/Item'
        });

    }

    // Disable weekend selection
    $scope.disabled = function (date, mode) {
        return (mode === 'day' && (date.getDay() === 0 || date.getDay() === 6));
    };

    $scope.toggleMin = function () {
        $scope.minDate = $scope.minDate ? null : new Date();
    };
    $scope.toggleMin();

    $scope.open = function ($event) {
        $event.preventDefault();
        $event.stopPropagation();

        $scope.opened = true;
    };

    $scope.dateOptions = {
        formatYear: 'yy',
        startingDay: 1
    };

    $scope.format = 'dd/MM/yyyy';
});