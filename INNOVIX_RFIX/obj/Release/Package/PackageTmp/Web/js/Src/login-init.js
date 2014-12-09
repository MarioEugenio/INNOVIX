app.controller('LoginInitCtrl', function ($scope, $http) {
    $scope.form = {};

    $scope.access = function () {
        $http.post('user/AuthenticateRequest', $scope.form)
              .success(function (response) {
                  if (response.success) {
                      window.location = '/Home/Index';
                  } else {

                      Modal.alert(
                             response.message,
                             global.titleModal,
                             response.success
                          );
                  }

              });
    }
    
});