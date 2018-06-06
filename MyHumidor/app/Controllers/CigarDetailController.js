app.controller("CigarDetailController", ["$location", "$routeParams", "$scope", "$http",
    function ($location, $routeParams, $scope, $http) {

        $scope.edit = false;

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
            
            console.log(Cigar);
        }
       
       

    }
]);