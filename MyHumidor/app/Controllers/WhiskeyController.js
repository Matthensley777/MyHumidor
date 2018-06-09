app.controller("WhiskeyController", ["$location", "$scope", "$http", "$routeParams",
    function ($location, $scope, $http, $routeParams) {

        $http.get("/api/whiskeys/").then(function (result) {
            $scope.whiskeys = result.data;
        });

        $scope.whiskeysDetail = (whiskeyId) => {
            $location.path(`/whiskeys/${whiskeyId}`);
        };

        $scope.AddNewWhiskey = () => {
            $location.path(`/whiskeys/new`);
        };

        //$scope.DeleteWhiskey = () => {

            //$http.delete(`/api/whiskeys/${whiskeyId}/delete`);
            //$location.path(`/whiskeys/`);
        //};

        $scope.DeleteWhiskey = (whiskeyId) => {

            $http.delete(`/api/whiskeys/${whiskeyId}/delete`).then(function (result) {
                $location.path(`/whiskeys/`)
                console.log(result);
            });
        };
    }
]);