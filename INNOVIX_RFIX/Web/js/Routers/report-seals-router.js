app.
    config(['$routeProvider', function ($routeProvider) {
        $routeProvider.
        when('/report/seals/list', { templateUrl: '/ReportSeals/List' })
        .when('/report/seals/:id/item', { templateUrl: '/ReportSeals/Item' });
    }]);