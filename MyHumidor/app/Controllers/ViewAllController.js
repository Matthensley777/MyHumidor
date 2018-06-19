app.controller("ViewAllController", ["$location", "$scope", "$http",
    function ($location, $scope, $http) {

        $http.get("/api/cigars/").then(function (result) {
            $scope.cigars = result.data;
        });

        $scope.cigarDetail = (cigarId) => {
            $location.path(`/cigars/${cigarId}`);
        };

       
    }
]);