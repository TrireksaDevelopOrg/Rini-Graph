﻿angular.module("app.routes", ["ngRoute"])
    .config(function ($routeProvider) {
        $routeProvider
            .when("/", {
                templateUrl: "assets/templates/main.html",
                controller:"MainController"
            })
            .when("/petugas", {
                templateUrl: "assets/templates/petugas.html",
                controller: "PetugasController"
            })
            .when("/graph", {
                templateUrl: "assets/templates/graph.html",
                controller:"GraphController"
            })
    });