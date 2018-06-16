app.controller("WhiskeyController", ["$location", "$scope", "$http", "$routeParams", "UserService",
    function ($location, $scope, $http, $routeParams, UserService) {

        $http.get(`/api/whiskeys/user/${UserService.getUser().UserID}`).then(function (result) {
            $scope.whiskeys = result.data;
        });

        $scope.whiskeysDetail = (whiskeyId) => {
            $location.path(`/whiskeys/${whiskeyId}`);
        };

        $scope.AddNewWhiskey = () => {
            $location.path(`/whiskeys/new`);
        };

        

        $scope.DeleteWhiskey = (whiskeyId) => {

            $http.delete(`/api/whiskeys/${whiskeyId}/delete`).then(function (result) {
                $location.path(`/whiskeys/`)
                console.log(result);
            });
        };
    }
]);