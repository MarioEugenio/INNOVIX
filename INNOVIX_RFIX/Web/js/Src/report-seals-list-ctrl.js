﻿app.controller('ReportSealsListCtrl', function ($scope, $http, $modal, $routeParams) {
    $scope.list = [];
    $scope.export = [];
    $scope.search = {};
    $scope.predicate = 'dtAtualizacao';
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

    $scope.exportPDF = function () {
        var doc = new jsPDF('landscape', 'pt', 'a4');
        doc.setFont("times", "normal");
        doc.text(20, 20, "Relatorio de Lacres");
        doc.setFontSize(12);
        data = [];
        data = doc.tableToJson('reportItens');
        height = doc.drawTable(data, {
            xstart: 15,
            ystart: 40,
            tablestart: 30,
            marginleft: 40,
            xOffset: 5,
            yOffset: 15
        });
        doc.save('Relatorio de Lacres.pdf');
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
        $scope.searchSeals(1);
    };

    $scope.getReportItem = function (current) {
        Loading.showAll();

        $http.post(baseUrl + '/reportSeals/getAll', {
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

    }

    $scope.searchSeals = function (current) {
        if (!$scope.search) {
            $scope.getReportItem(current);
            return;
        }

        Loading.showAll();

        $http.post(baseUrl + '/reportSeals/getReportItem', {
            search: $scope.search,
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

    }

    $scope.clear = function () {
        $scope.search = {};
    }
    $scope.pageChanged = function () {
        $scope.searchSeals(
             $scope.currentPage
        );
    };

    $scope.maxSize = global.limit;
    $scope.currentPage = 1;

    $scope.openModal = function (id) {
        $routeParams.id = id
        $modal.open({
            templateUrl: '/ReportSeals/Item'
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