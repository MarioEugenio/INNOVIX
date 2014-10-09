app.
    config(['$routeProvider', function ($routeProvider) {
        $routeProvider.
        when('/user/create', { templateUrl: '/User/Create' })
        .when('/user/list', { templateUrl: '/User/List' })
        .when('/user/:id/alter', { templateUrl: '/User/Create' });
    }]);