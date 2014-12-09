app.
    config(['$routeProvider', function ($routeProvider) {
        $routeProvider.
        when('/home/init', { templateUrl: '/Boarding/List' }).
          otherwise({ redirectTo: '/home/init' });
    }]);