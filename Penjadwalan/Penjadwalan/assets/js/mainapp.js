angular.module("mainapp", ["ngRoute",
    "app.controllers",
    "app.services"])
    .config(function ($routeProvider) {
        $routeProvider
            .when("/", {
                templateUrl: "/assets/templates/jadwal.html",
                controller: "JadwalController"
            })
    });
    ;
