app.controller('ReportSealsListCtrl', function ($scope, $http) {
    $scope.list = [];
    $scope.search = "";

    $scope.init = function () {
        $scope.getReportItem(1);
    };

    $scope.getReportItem = function (current) {
        $http.post(baseUrl + '/reportSeals/getAll', {
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
        $http.post(baseUrl + '/reportSeals/getReportItem', {
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
});