app.
    config(['$routeProvider', function ($routeProvider) {
        $routeProvider.
        when('/route/create', { templateUrl: 'Route/Create' })
        .when('/route/list', { templateUrl: 'Route/List' })
        .when('/route/:id/alter', { templateUrl: 'Route/Create' });
    }]);