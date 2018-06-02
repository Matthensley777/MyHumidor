app.controller("NewCigarController", ["$location", "$scope", "$http",
    function ($location, $scope, $http) {

        $scope.new = (Cigar) => {

            $http.post("/api/cigars/", Cigar).then(function () {
                $location.path(`/cigars`);
            }).catch((err) => {
                console.log("error posting new cigars", err);
            });
        };
    }]);