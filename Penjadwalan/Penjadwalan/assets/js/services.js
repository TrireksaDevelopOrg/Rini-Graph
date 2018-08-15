angular.module("app.services",[])
    .factory("AuthServices", AuthServices)
    .factory("PetugasServices", PetugasServices)
    .factory("MessageServices",MessageServices)
    ;
function MessageServices($q) {



    var service = {
        error: error, success: success, warning: warning, info: info,dialog:dialog
    };
  

    function dialog(message) {
       

        var def = $q.defer();
      var notice=  new PNotify({
            title: 'Confirmation',
          text: message, styling: 'bootstrap3',
          icon: 'glyphicon glyphicon-question-sign',
            hide: false,
            confirm: {
                confirm: true
            },
            buttons: {
                closer: false,
                sticker: false
            },
            history: {
                history: false
            },
            addclass: 'stack-modal',
            stack: { 'dir1': 'down', 'dir2': 'right', 'modal': true }
        });

        notice.get().on('pnotify.confirm', function () {
            def.resolve()
        }).on('pnotify.cancel', function () {
            def.reject();
        })   

        return def.promise;
    }


    function error(message) {
        var stack_bottomright = {
            dir1: 'up',
            dir2: 'right'
        };
        new PNotify({
            title: 'ERROR',
            text: message,addclass: 'stack-bottomright',
            type: 'error', push: 'bottom',
            styling: 'bootstrap3'
        });
    }

    function info(message) {
        new PNotify({
            title: 'INFO',
            text: message,
            type: 'info',
            styling: 'bootstrap3'
        });
    }

    function warning(message) {
        new PNotify({
            title: 'WARNING',
            text: message,
            type: 'warning',
            styling: 'bootstrap3'
        });
    }

    function success(message) {
        new PNotify({
            title: 'SUCCESS',
            text: message,
            type: 'success',
            styling: 'bootstrap3'
        });
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