app.
    config(['$routeProvider', function ($routeProvider) {
        $routeProvider.
        when('/user/create', { templateUrl: 'User/Create' });
    }]);