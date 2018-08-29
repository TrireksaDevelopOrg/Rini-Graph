angular.module("app.routes", ["ngRoute"])
    .config(function ($routeProvider) {
        $routeProvider
            .when("/", {
                templateUrl: "/assets/templates/main.html",
                controller:"MainController"
            })
            .when("/perawat", {
                templateUrl: "/assets/templates/perawat.html",
                controller: "PerawatController"
            })
            .when("/graph", {
                templateUrl: "/assets/templates/graph.html",
                controller:"GraphController"
            })
            .when("/jadwal", {
                templateUrl: "/assets/templates/jadwal.html",
                controller: "JadwalController"
            })
    });
