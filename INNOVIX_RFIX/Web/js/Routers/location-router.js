app.
    config(['$routeProvider', function ($routeProvider) {
        $routeProvider.
        when('/location/create', { templateUrl: '/Location/Create' })
        .when('/location/list', { templateUrl: '/Location/List' })
        .when('/location/:id/alter', { templateUrl: '/Location/Create' });
    }]);