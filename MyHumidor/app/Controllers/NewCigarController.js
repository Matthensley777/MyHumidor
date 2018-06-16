app.controller("NewCigarController", ["$location", "$scope", "$http","UserService",
    function ($location, $scope, $http,UserService) {

        $http.get("/api/whiskeys/").then(function (result) {
            $scope.whiskeys = result.data;
        });

        $scope.new = (Cigar) => {
            Cigar.UserID = UserService.getUser().UserID;
            $http.post("/api/cigars/", Cigar).then(function () {
                $location.path(`/cigars`);
            }).catch((err) => {
                console.log("error posting new cigars", err);
            });
        };
    }]);