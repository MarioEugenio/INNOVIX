app.controller('ReportSealsCtrl', function ($scope, $http, $routeParams) {
    $scope.list = [];
    $scope.objItem = {};
    $scope.search = "";

    $scope.init = function () {
        $scope.get($routeParams.id);
        $scope.getReportHistoryItem(1);
    };

    $scope.get = function (id) {
        $http.post(baseUrl + '/reportSeals/get', { Id: id })
              .success(function (data) {
                  $scope.objItem = {
                      Id: 1,
                      awb: '00001',
                      origin: 'teste',
                      destiny: 'teste',
                      route: 'teste',
                      status: 'teste',
                      dtAtualizacao: '10/02/2015',
                      responsavel: 'Teste',
                      lacre: 'Teste',
                      embarque: 'Teste',
                      dtCadastro: '10/02/2015',
                      epc: '0000000000000001111111542',
                  };
              });
    };

    $scope.getReportHistoryItem = function (current) {
        $http.post(baseUrl + '/reportSeals/getAllHistory', {
            id: $routeParams.id,
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
    };

    $scope.pageChanged = function () {
        $scope.getReportItem(
             $scope.currentPage
        );
    };

    $scope.maxSize = global.limit;
    $scope.currentPage = 1;

});