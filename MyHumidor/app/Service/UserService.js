app.service("UserService", function ($http, $q) {

    var User = {};

    return {
        getUser: function () { return User; },
        setUser: function (user) { User = user }
    }



});