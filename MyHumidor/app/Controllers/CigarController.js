app.controller("CigarController", ["$location", "$scope", "$http", "UserService",
    function ($location, $scope, $http, UserService) {

        $http.get(`/api/cigars/user/${UserService.getUser().UserID}`).then(function (result) {
            $scope.cigars = result.data;
        });

        $scope.cigarDetail = (cigarId) => {
            $location.path(`/cigars/${cigarId}`);
        };

        $scope.AddNewCigar = () => {
            $location.path(`/cigars/new`);
        };

    }
]);