app.controller('ReportBoardingCtrl', function ($scope, $http, $routeParams, $modal) {
    $scope.list = [];
    $scope.listSeals = [];
    $scope.objItem = {};
    $scope.search = "";

    $scope.init = function () {
        $scope.get($routeParams.id);
        $scope.getReportHistoryItem(1);
        $scope.getReportHistorySeals(1);
    };

    $scope.close = function () {
        $('body').removeClass('modal-open');
        $('.modal-backdrop').remove();
        $('.modal-dialog').remove();
        $('.modal').find('.in').remove();
    };
    $scope.get = function (id) {
        $http.post(baseUrl + '/reportBoarding/get', { Id: id })
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
        $http.post(baseUrl + '/reportBoarding/getAllItem', {
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

    $scope.getReportHistorySeals = function (current) {
        $http.post(baseUrl + '/reportBoarding/getAllSeals', {
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
                $scope.listSeals = response.data;
                $scope.totalSeals = response.total;
            });
    };

    $scope.pageChanged = function () {
        $scope.getReportHistoryItem(
             $scope.currentPage
        );
    };

    $scope.maxSize = global.limit;
    $scope.currentPage = 1;
    $scope.currentPageSeals = 1;

    $scope.pageChangedSeals = function () {
        $scope.getReportHistorySeals(
             $scope.currentPageSeals
        );
    };

});