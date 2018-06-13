﻿app.controller("CigarDetailController", ["$location", "$routeParams", "$scope", "$http",
    function ($location, $routeParams, $scope, $http, $window) {

        $scope.edit = false;

        $http.get("/api/whiskeys/").then(function (result) {
            $scope.whiskeys = result.data;
        });

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
            
        }

        $scope.DeleteCigar = () => {

            $http.delete(`/api/cigars/${$routeParams.id}/delete`);
            $location.path(`/cigars/`);
        };

        

        

    }
]);