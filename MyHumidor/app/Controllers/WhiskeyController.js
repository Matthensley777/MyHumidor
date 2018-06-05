app.controller("WhiskeyController", ["$location", "$scope", "$http",
    function ($location, $scope, $http) {

        $http.get("/api/whiskeys/").then(function (result) {
            $scope.whiskeys = result.data;
        });

        $scope.whiskeysDetail = (whiskeyId) => {
            $location.path(`/whiskeys/${whiskeyId}`);
        };

        $scope.AddNewWhiskey = () => {
            $location.path(`/whiskeys/new`);
        };

    }
]);