app.controller("UserController", ["$location", "$scope", "$http", "UserService",
    function ($location, $scope, $http, UserService) {

        $scope.getUser = function () {
            $http.get(`/api/user/${encodeURIComponent($scope.User.Email)}`).then(function (result) {
                UserService.setUser(result.data);
                $location.path(`/cigars`);
            });
        }

        $scope.cigarDetail = (cigarId) => {
            $location.path(`/cigars/${cigarId}`);
        };

    }
]);