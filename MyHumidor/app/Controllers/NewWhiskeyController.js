﻿app.controller("NewWhiskeyController", ["$location", "$scope", "$http",
    function ($location, $scope, $http) {

        $scope.new = (Whiskey) => {

            $http.post("/api/whiskeys/", Whiskey).then(function () {
                $location.path(`/whiskeys`);
            }).catch((err) => {
                console.log("error posting new whiskey", err);
            });
        };
    }]);