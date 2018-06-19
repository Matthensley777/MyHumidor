app.controller("CigarDetailController", ["$location", "$routeParams", "$scope", "$http", "UserService",
    function ($location, $routeParams, $scope, $http, UserService) {

        $scope.edit = false;

        $http.get(`/api/whiskeys/user/${UserService.getUser().UserID}`).then(function (result) {
            $scope.whiskeys = result.data;
        });

        $http.get(`/api/cigars/${$routeParams.id}`).then((result) => {
            
            $scope.Cigar = result.data;
        });

        $scope.edits = () => {
            $scope.edit = true;
        }

        $scope.saveEdits = (Cigar) => {
            $http.put(`/api/cigars/${$routeParams.id}`, Cigar).then((result) => {
                $location.path(`/cigars/`);
            })
            
        }

        $scope.DeleteCigar = () => {

            $http.delete(`/api/cigars/${$routeParams.id}/delete`);
            $location.path(`/cigars/`);
        };

        

        

    }
]);