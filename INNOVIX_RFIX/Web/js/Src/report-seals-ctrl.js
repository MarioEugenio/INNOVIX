﻿app.controller('ReportSealsCtrl', function ($scope, $http, $routeParams) {
    $scope.list = [];
    $scope.objItem = {};
    $scope.search = "";
    $scope.predicate = 'dtAtualizacao';
    $scope.order = 'ASC';

    $scope.init = function () {
        $scope.get($routeParams.id);
        $scope.getReportHistoryItem(1);
    };

    $scope.close = function () {
        $('body').removeClass('modal-open');
        $('.modal-backdrop').remove();
        $('.modal-dialog').remove();
        $('.modal').find('.in').remove();
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


    $scope.get = function (id) {
        Loading.showAll();

        $http.post(baseUrl + '/reportSeals/get', { Id: id })
              .success(function (data) {
                  if (data.length > 0) {
                    $scope.objItem = data[0];
                  }

                  Loading.hideAll();
              });
    };

    $scope.getReportHistoryItem = function (current) {
        Loading.showAll();

        $http.post(baseUrl + '/reportSeals/getAllHistory', {
            id: $routeParams.id,
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
    };

    $scope.pageChanged = function () {
        $scope.getReportHistoryItem(
             $scope.currentPage
        );
    };

    $scope.maxSize = global.limit;
    $scope.currentPage = 1;

});