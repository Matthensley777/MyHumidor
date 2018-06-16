app.service("UserService", function ($http, $q) {

    var User = {};

    return {
        getUser: function () { return User; },
        setUser: function (user) { User = user }
    }


    //const getUserCigars = (userId) => {
    //    let userCigars = [];
    //    return $q((resolve, reject) => {
    //        $http.get(`${databaseURL}/"${userId}"`).then((results) => {
    //            let cigars = results.data;
    //            Object.keys(photos).forEach((key) => {
    //                cigars[key].id = key;
    //                userCigars.push(cigars[key]);
    //            });
    //            resolve(userCigars);
    //        }).catch((error) => {
    //            reject(error);
    //        });
    //    });
    //};


});