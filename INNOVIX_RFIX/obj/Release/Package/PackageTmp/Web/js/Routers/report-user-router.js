app.
    config(['$routeProvider', function ($routeProvider) {
        $routeProvider.
        when('/report/user/list', { templateUrl: '/ReportUser/List' });
    }]);