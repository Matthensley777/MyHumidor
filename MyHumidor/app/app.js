var app = angular.module("MyHumidor", ['ngRoute']);

app.config([
    '$routeProvider', function ($routeProvider) {
        $routeProvider
            
            .when("/cigars",
            {
                templateUrl: '/app/partials/Cigars.html',
                controller: 'CigarController'
            })
            .when("/cigars/new",
            {
                templateUrl: '/app/partials/new_cigar.html',
                controller: 'NewCigarController'
            })
            
    }
]);