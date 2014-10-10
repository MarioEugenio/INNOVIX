app.controller('ReportBoardingCtrl', function ($scope, $http, $routeParams, $modal) {
    $scope.list = [];
    $scope.export = [];
    $scope.listSeals = [];
    $scope.exportSeals = [];
    $scope.objItem = {};
    $scope.search = "";
    $scope.predicate = 'id';
    $scope.order = 'ASC';
    $scope.predicateSeals = 'id';
    $scope.orderSeals = 'ASC';

    $scope.init = function () {
        $scope.get($routeParams.id);
        $scope.getReportHistoryItem(1);
        $scope.getReportHistorySeals(1);
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
        $scope.getReportHistoryItem(1);
    };

    $scope.sortingSeals = function (predicate) {
        if ($scope.predicateSeals == predicate && $scope.orderSeals == 'DESC') {
            return 'glyphicon glyphicon-chevron-down';
        }
        return 'glyphicon glyphicon-chevron-up';
    };

    $scope.sortingTableSeals = function (predicate) {

        if ($scope.predicateSeals == predicate && $scope.orderSeals == 'DESC') {
            $scope.predicateSeals = predicate;
            $scope.orderSeals = 'ASC';
        } else {
            $scope.predicateSeals = predicate;
            $scope.orderSeals = 'DESC';
        }
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
                  if (data.length > 0) {
                      $scope.objItem = data[0];
                  }
              });
    };

    $scope.exportPDF = function () {
        var doc = new jsPDF('landscape', 'pt', 'a4');
        doc.setFont("times", "normal");
        doc.text(20, 20, "Embarque: " + ($scope.objItem.embarque || ''));
        doc.text(300, 20, "Status: " + ($scope.objItem.status || ''));
        doc.text(20, 40, "Origem: " + ($scope.objItem.origin || ''));
        doc.text(300, 40, "Dt. Atualização: " + ($scope.objItem.dtAtualizacao  || ''));
        doc.text(20, 60, "Destino: " + ($scope.objItem.destiny  || ''));
        doc.text(300, 60, "Dt. Cadastro: " + ($scope.objItem.dtCadastro  || ''));
        doc.text(20, 80, "Rota: " + ($scope.objItem.route  || ''));
        doc.text(300, 80, "Responsável: " + ($scope.objItem.responsavel || ''));
       
        doc.setFontSize(12);
        data = [];
        data = doc.tableToJson('reportItenPDFItem');
        data2 = [];
        data2 = doc.tableToJson('reportItenPDFSeals');
        if (data.length || data2.length) {
            if (data.length) {
                doc.text(20, 120, "Itens");
            } else {
                data = data2;
                data2 = [];
            }
            
            height = doc.drawTable(data, {
                xstart: 15,
                ystart: 40,
                tablestart: 140,
                marginleft: 40,
                xOffset: 5,
                yOffset: 15
            }, data2);
        }
        doc.save('Relatorio de embarque.pdf');
    };

    $scope.getReportHistoryItem = function (current) {
        $http.post(baseUrl + '/reportBoarding/getAllItem', {
            id: $routeParams.id,
            limit: global.limit,
            offset: current,
            predicate: $scope.predicate,
            order: $scope.order
        })
        .success(function (response) {
            $scope.export = response.export;
            $scope.list = response.data;
            $scope.totalItems = response.total;
        });
    };

    $scope.getReportHistorySeals = function (current) {
        $http.post(baseUrl + '/reportBoarding/getAllSeals', {
                id: $routeParams.id,
                limit: global.limit,
                offset: current,
                predicate: $scope.predicateSeals,
                order: $scope.orderSeals
            })
            .success(function (response) {
                $scope.exportSeals = response.export;
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