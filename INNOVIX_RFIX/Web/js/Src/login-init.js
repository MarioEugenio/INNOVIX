app.controller('LoginInitCtrl', function ($scope, $http) {
    $scope.form = {};

    $scope.access = function () {
        $http.post(baseUrl + '/user/AuthenticateRequest', $scope.form)
              .success(function (response) {
                  if (response.success) {
                      window.location = '/Home/Index';
                  }

                  Modal.alert(
                         response.message,
                         global.titleModal,
                         response.success
                      );

              });
    }
    
});