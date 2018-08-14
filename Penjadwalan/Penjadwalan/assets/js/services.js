angular.module("app.services",[])
    .factory("AuthServices", AuthServices)
    .factory("PetugasServices", PetugasServices)
    .factory("MessageServices",MessageServices)
    ;
function MessageServices() {
    var service = {
        error: error, success: success, warning: warning,info:innfo
    };

    function error(message) {

    }
    function success(message) {

    }
    function warning(message) {

    }
    function info(message) {

    }
    function dialog(message, type) {

    }


    return service;
}

function AuthServices($http, MessageServices, $q) {

    
    var services = {
        login: login, register: register, logout: logout,
        getHeader: getHeader
    };


    function login(model) {
        var def = $q.defer();
        $http({
            method:"post",
            url: "",
            data: model
        }).then(function (response) {

            MessageServices.success("Welcome !");
            def.resolve(response.data);

            }, function (error) {
                MessageServices.error(error.data);
            });
    }

    function register(model) {
        var def = $q.defer();
        $http({
            method: "post",
            url: "",
            data: model
        }).then(function (response) {

            MessageServices.success("Welcome !");
            def.resolve(response.data);

        }, function (error) {
            MessageServices.error(error.data);
        });
    }

    function logout() {
        $state.go("login");
    }

    function getHeader() {
        return "bearer "+ sessionStorage.getItem("Token");
    }

    return services;
}

function PetugasServices($http, $q, AuthServices,MessageServices) {
    var services = {
        instance: false,
        DataPetugas:[],
        get: get, post: post, put: EditItem, delete: deleteItem
    };

    function get() {
        var def = $q.defer();
        if (instance) {
            instance = true;
            $http({
                header: AuthServices.getHeader(),
                method: "get",
                url: "api/petugas",
            }).then(function (response) {
                angular.forEach(response.data, function (value, key) {
                    services.DataPetugas.push(value);
                });
                def.resolve(response.data);
            }, function (error) {
                MessageServices.error(error.data);
            });
        } else {
            def.resolve(services.DataPetugas);
        }
    }

    function post(model) {
        var def = $q.defer();
        $http({
            header: AuthServices.getHeader(),
            method: "post",
            url: "api/petugas",
        }).then(function (response) {
            services.DataPetugas.push(value);
            def.resolve(response.data);
        }, function (error) {
            MessageServices.error(error.data);
        });
    }

    function EditItem(model) {
        var def = $q.defer();
        $http({
            header: AuthServices.getHeader(),
            method: "put",
            url: "api/petugas",
            data:model
        }).then(function (response) {
            MessageServices.success("Data Berhasil Diubah");
            def.resolve(response.data);
        }, function (error) {
            MessageServices.error(error.data);
        });
    }


    function DeleteItem(model) {
        var def = $q.defer();
        $http({
            method: "delete",
            url: "api/petugas",
        }).then(function (response) {
            var index = services.DataPetugas.indexOf(model);
            services.DataPetugas.splice(index, 1);
            MessageServices.success("Data Berhasil Dihapus");
            def.resolve(response.data);
        }, function (error) {
            MessageServices.error(error.data);
        });
    }

    return services;

}