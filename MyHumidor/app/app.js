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
            .when("/whiskeys",
            {
                templateUrl: '/app/partials/Whiskey.html',
                controller: 'WhiskeyController'
            })
            .when("/whiskeys/new",
            {
                templateUrl: '/app/partials/new_whiskey.html',
                controller: 'NewWhiskeyController'
            })
            .when("/cigars/:id",
            {
                templateUrl: '/app/partials/cigar_detail.html',
                controller: 'CigarDetailController'
            })
            .when("/user/:id",
            {
                templateUrl: '/app/partials/user.html',
                controller: 'UserController'
            })
            .when("/viewall",
            {
                templateUrl: '/app/partials/viewall.html',
                controller: 'ViewAllController'
            })
            .when("/viewall/:id",
            {
                templateUrl: '/app/partials/viewalldetail.html',
                controller: 'ViewAllDetailController'
            })
            .otherwise({
                templateUrl: '/app/partials/user.html',
                controller: 'UserController'
            });
            
    }
]);