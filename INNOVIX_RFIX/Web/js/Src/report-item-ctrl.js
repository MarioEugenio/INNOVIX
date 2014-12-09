app.controller('ReportItemCtrl', function ($scope, $http, $routeParams) {
    $scope.list = [];
    $scope.objItem = {};
    $scope.export = [];
    $scope.search = "";
    $scope.predicate = 'dtAtualizacao';
    $scope.order = 'ASC';

    $scope.init = function () {
        $scope.get($routeParams.id);
        $scope.getReportHistoryItem(1);
    };

    $scope.pageChanged = function () {
        $scope.getReportHistoryItem(
             $scope.currentPage
        );
    };


    $scope.exportPDF = function () {
        var doc = new jsPDF('landscape', 'pt', 'a4');
        doc.setFont("times", "normal");
        doc.text(20, 20, "AWB: " + ($scope.objItem.awb|| ''));
        doc.text(20, 40, "Embarque: " + ($scope.objItem.embarque|| ''));
        doc.text(300, 40, "Origem: " + ($scope.objItem.origin|| ''));
        doc.text(20, 60, "Status: " + ($scope.objItem.status|| ''));
        doc.text(300, 60, "Destino: " + ($scope.objItem.destiny|| ''));
        doc.text(20, 80, "Lacre: " + ($scope.objItem.lacre|| ''));
        doc.text(300, 80, "Rota: " + ($scope.objItem.route|| ''));
        doc.text(20, 100, "Dt. Atualização: " + ($scope.objItem.dtAtualizacao|| ''));
        doc.text(300, 100, "Dt. Cadastro: " + ($scope.objItem.dtCadastro|| ''));
        doc.text(20, 120, "Responsável: " + ($scope.objItem.responsavel|| ''));
        doc.text(300, 120, "EPC: " + ($scope.objItem.epc|| ''));

        data = [];
        data = doc.tableToJson('reportItenPDFItem');
        if (data.length) {
            doc.text(20, 160, "Itens");
            doc.setFontSize(12);
            height = doc.drawTable(data, {
                xstart: 15,
                ystart: 40,
                tablestart: 180,
                marginleft: 40,
                xOffset: 5,
                yOffset: 15
            });
        }
        doc.save('Relatorio de Item.pdf');
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

    $scope.close = function () {
        $('body').removeClass('modal-open');
        $('.modal-backdrop').remove();
        $('.modal-dialog').remove();
        $('.modal').find('.in').remove();
    };

    $scope.get = function (id) {
        $http.post(baseUrl + '/reportItem/get', { Id: id })
              .success(function (data) {
                  if (data.length > 0) {
                      $scope.objItem = data[0];
                  }

                  /*{
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
                  };*/
              });
    };

    $scope.getReportHistoryItem = function (current) {
        Loading.showAll();

        $http.post(baseUrl + '/reportItem/getAllHistory', {
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

            Loading.hideAll();
        });
    };

 
    $scope.maxSize = global.limit;
    $scope.currentPage = 1;

});