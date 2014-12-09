app.
    config(['$routeProvider', function ($routeProvider) {
        $routeProvider.
        when('/report/item/list', { templateUrl: '/ReportItem/List' })
        .when('/report/item/:id/item', { templateUrl: '/ReportItem/Item' });
    }]);