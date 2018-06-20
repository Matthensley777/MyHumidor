app.controller("ViewAllDetailController", ["$location", "$routeParams", "$scope", "$http",
    function ($location, $routeParams, $scope, $http) {

        $scope.edit = false;

        $http.get(`/api/cigars/${$routeParams.id}`).then((result) => {

            $scope.Cigar = result.data;
        });

       

        



    }
]);