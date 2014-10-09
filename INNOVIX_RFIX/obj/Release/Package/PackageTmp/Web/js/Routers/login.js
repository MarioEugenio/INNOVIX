app.
    config(['$routeProvider', function ($routeProvider) {
        $routeProvider.
        when('/login/init', { templateUrl: '/Login/Init' }).
          otherwise({ redirectTo: '/login/init' });
    }]);