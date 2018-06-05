app.controller("CigarDetailController", ["$location", "$routeParams", "$scope", "$http",
    function ($location, $routeParams, $scope, $http) {

        $scope.edit = false;

        $http.get(`/api/cigars/${$routeParams.id}`).then((result) => {
            
            $scope.cigar = result.data;
        });

        $scope.edits = () => {
            $scope.edit = true;
        }

        

       

    }
]);