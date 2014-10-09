﻿app.controller('ReportBoardingCtrl', function ($scope, $http, $routeParams, $modal) {
    $scope.list = [];
    $scope.listSeals = [];
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

    $scope.getReportHistoryItem = function (current) {
        $http.post(baseUrl + '/reportBoarding/getAllItem', {
            id: $routeParams.id,
            limit: global.limit,
            offset: current,
            predicate: $scope.predicate,
            order: $scope.order
        })
        .success(function (response) {
            
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