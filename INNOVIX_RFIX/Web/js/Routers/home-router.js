app.
    config(['$routeProvider', function ($routeProvider) {
        $routeProvider.
        when('/home/init', { templateUrl: 'Home/Init' }).
          otherwise({ redirectTo: '/home/init' });
    }]);