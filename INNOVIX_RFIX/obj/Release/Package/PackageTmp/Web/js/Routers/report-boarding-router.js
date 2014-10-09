app.
    config(['$routeProvider', function ($routeProvider) {
        $routeProvider.
        when('/report/boarding/list', { templateUrl: '/ReportBoarding/List' })
        .when('/report/boarding/:id/item', { templateUrl: '/ReportBoarding/Item' });
    }]);