﻿app.controller('ReportSealsListCtrl', function ($scope, $http, $modal, $routeParams) {
    $scope.list = [];
    $scope.search = "";
    $scope.predicate = 'id';
    $scope.order = 'ASC';

    $scope.init = function () {
        $scope.getReportItem(1);
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
        $scope.search(1);
    };

    $scope.getReportItem = function (current) {
        $http.post(baseUrl + '/reportSeals/getAll', {
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
        $http.post(baseUrl + '/reportSeals/getReportItem', {
            search: $scope.search,
            limit: global.limit,
            offset: current,
            predicate: $scope.predicate,
            order: $scope.order
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

    $scope.open = function (id) {
        $routeParams.id = id
        $modal.open({
            templateUrl: '/ReportSeals/Item'
        });

    }
});