app.controller("NewWhiskeyController", ["$location", "$scope", "$http", "UserService",
    function ($location, $scope, $http, UserService) {

        $scope.new = (Whiskey) => {
            Whiskey.UserID = UserService.getUser().UserID;
            $http.post("/api/whiskeys/", Whiskey).then(function () {
                $location.path(`/whiskey`);
            }).catch((err) => {
                console.log("error posting new whiskey", err);
            });
        };
    }]);