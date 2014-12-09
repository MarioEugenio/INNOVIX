app.
    config(['$routeProvider', function ($routeProvider) {
        $routeProvider.
        when('/equipment/create', { templateUrl: '/Equipment/Create' })
        .when('/equipment/list', { templateUrl: '/Equipment/List' })
        .when('/equipment/:id/alter', { templateUrl: '/Equipment/Create' });
    }]);