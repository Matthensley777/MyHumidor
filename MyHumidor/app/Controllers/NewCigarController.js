app.controller("NewCigarController", ["$location", "$scope", "$http",
    function ($location, $scope, $http) {

        $http.get("/api/whiskeys/").then(function (result) {
            $scope.whiskeys = result.data;
        });

        $scope.new = (Cigar) => {

            $http.post("/api/cigars/", Cigar).then(function () {
                $location.path(`/cigars`);
            }).catch((err) => {
                console.log("error posting new cigars", err);
            });
        };
    }]);