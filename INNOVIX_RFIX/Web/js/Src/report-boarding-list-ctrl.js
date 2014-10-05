app.controller('ReportBoardingListCtrl', function ($scope, $http, $modal, $routeParams) {
    $scope.list = [];
    $scope.search = "";

    $scope.init = function () {
        $scope.getReportItem(1);
    };

    $scope.getReportItem = function (current) {
        $http.post(baseUrl + '/reportBoarding/getAll', {
            limit: global.limit,
            offset: current
        })
        .success(function (response) {
            response = {
                data: [{
                    Id: 1,
                    awb: '00001',
                    origin: 'teste',
                    destiny: 'teste',
                    route: 'teste',
                    status: 'teste',
                    dtAtualizacao: '10/02/2015'
                },
                {
                    Id: 1,
                    awb: '00002',
                    origin: 'teste',
                    destiny: 'teste',
                    route: 'teste',
                    status: 'teste',
                    dtAtualizacao: '10/02/2015'
                }], total: 5
            };
            $scope.list = response.data;
            $scope.totalItems = response.total;
        });

    }

    $scope.search = function (current) {
        $http.post(baseUrl + '/reportBoarding/getReportItem', {
            search: $scope.search,
            limit: global.limit,
            offset: current
        })
        .success(function (response) {
            response = {
                data: [{
                    Id: 1,
                    awb: '00001',
                    origin: 'teste',
                    destiny: 'teste',
                    route: 'teste',
                    status: 'teste',
                    dtAtualizacao: '10/02/2015'
                }], total: 5
            };
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

    $scope.open = function (id)
    {
        $routeParams.id = id
        $modal.open({
            templateUrl: '/ReportBoarding/Item'
            });

    }
});