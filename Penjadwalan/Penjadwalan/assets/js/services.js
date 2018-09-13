angular.module("app.services",[])
    .factory("AuthServices", AuthServices)
    .factory("PerawatServices", PerawatServices)
    .factory("MessageServices", MessageServices)
    .factory("MatrixServices", MatrixServices)
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

function PerawatServices($http, $q, AuthServices,MessageServices) {
    var services = {
        instance: false,
        Perawats:[],
        get: get, post: post, put: EditItem, delete: deleteItem
    };

    get();
    function get() {
        var def = $q.defer();
        if (!services.instance) {
            services.instance = true;
            $http({
                header: AuthServices.getHeader(),
                method: "get",
                url: "/api/perawat",
            }).then(function (response) {
                angular.forEach(response.data, function (value, key) {
                    services.Perawats.push(value);
                });
                def.resolve(response.data);
            }, function (error) {
                MessageServices.error(error.data);
            });
        } else {
            def.resolve(services.Perawats);
        }

        return def.promise;
    }

    function post(model) {
        var def = $q.defer();
        $http({
            header: AuthServices.getHeader(),
            method: "post",
            url: "/api/perawat",
            data:model
        }).then(function (response) {
            services.Perawats.push(response.data);
            def.resolve(response.data);
            MessageServices.success("Data Berhasil Disimpan");
            model = {};
        }, function (error) {
            MessageServices.error(error.data);
            });

        return def.promise;
    }

    function EditItem(model) {
        var def = $q.defer();
        $http({
            header: AuthServices.getHeader(),
            method: "put",
            url: "/api/perawat/" + model.IdPerawat,
            data:model
        }).then(function (response) {
            MessageServices.success("Data Berhasil Diubah");
            def.resolve(response.data);
        }, function (error) {
            MessageServices.error(error.data);
            def.reject();
            });

        return def.promise;
    }


    function deleteItem(model) {
        var def = $q.defer();
        $http({
            method: "delete",
            url: "/api/perawat/"+model.IdPerawat,
        }).then(function (response) {
            var index = services.Perawats.indexOf(model);
            services.Perawats.splice(index, 1);
            MessageServices.success("Data Berhasil Dihapus");
            def.resolve(response.data);
        }, function (error) {
            MessageServices.error(error.data);
            });

        return def.promise;
    }

    return services;

}



function MatrixServices($http,$q,MessageServices) {
    var services = {
        instance: false,
        Matrixs: [],
        get: get, post: post, getPeriode: getPeriode, getJadwal: getJadwal
    };
   
    function get() {
        var def = $q.defer();
        if (!services.instance) {
            services.instance = true;
            $http({
                method: "get",
                url: "/api/matrik",
            }).then(function (response) {
                angular.forEach(response.data, function (value, key) {
                    services.Matrixs.push(value);
                });
                def.resolve(response.data);
            }, function (error) {
                MessageServices.error(error.data);
            });
        } else {
            def.resolve(services.Matrixs);
        }

        return def.promise;
    }


    function post(model) {
        NProgress.start();
        var def = $q.defer();
        $http({
            method: "post",
            url: "/api/matrik",
            data: model
        }).then(function (response) {
            def.resolve(response.data);
            MessageServices.success("Data Berhasil Disimpan");
            model = {};
            NProgress.done();
        }, function (error) {
            MessageServices.error(error.data.Message);
        });

        return def.promise;
    }

    function getPeriode() {
        var def = $q.defer();
        $http({
            method: "get",
            url: "/api/jadwal"
        }).then(function (response) {
            def.resolve(response.data);
        }, function (error) {
            MessageServices.error(error.data.Message);
            def.reject();
        });
        return def.promise;
    }


    function getJadwal(item) {
        var def = $q.defer();
        $http({
            method: "get",
            url: "/api/jadwal/"+item.idperiode,
        }).then(function (response) {
            def.resolve(response.data);
        }, function (error) {
            MessageServices.error(error.data.Message);
            def.reject();
        });
        return def.promise;
    }

    return services;

}
