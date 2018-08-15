"strich"
angular.module("app.controllers", [])
    .controller("PetugasController", PetugasController)
    .controller("MainController", MainController)
    .controller("GraphController", GraphController)
    .controller("JadwalController",JadwalController)
    ;


function PetugasController(MessageServices) {
   
}



function JadwalController(MessageServices) {
    
}

function MainController($scope, MessageServices) {
    MessageServices.dialog("Want Delete ?").then(function (response) {
        MessageServices.success("OK");
    }, function () {
        MessageServices.error("Error");
        });
     
}



function GraphController($scope,$http) {
    var white = "white";
    $scope.edges = [];
    $scope.DataNodes = [];
    $scope.apa = "AKU";
    $http({
        method: 'GET',
        url: 'api/matrik'
    }).then(function successCallback(response) {
        $scope.DataNodes = response.data.Nodes;
        $scope.nodes = new vis.DataSet($scope.DataNodes);


        $scope.Datas = [];
        for (var i = 1; i <= 3; i++) {
            var items = [];
            var label = { value: i.toString() };
            items.push(label);
            angular.forEach($scope.DataNodes, function (value, key) {
                var item = { from: i, to: value.id, value: 0 };
                items.push(item);
               
            });
            $scope.Datas.push(items);
        }
    }, function errorCallback(response) {
        // called asynchronously if an error occurs
        // or server returns response with an error status.
    });

    $scope.Show = function () {
        $scope.edges = [];
        angular.forEach($scope.Datas, function (value, key) {
            angular.forEach(value, function (value1, key1) {
                if (value1.from != undefined && value1.value > 0) {
                    $scope.edges.push(value1);
                }
            })
        })


        var result = getDerajat($scope.edges);
        

        // provide the data in the vis format

        angular.forEach($scope.nodes._data, function (value, key) {


        });




        $scope.container = {};
        $scope.network = {};



        var data = {
            nodes: $scope.nodes,
            edges: $scope.edges
        };
        var options = {};

        // initialize your network!
        $scope.container = document.getElementById('mynetwork');

        $scope.network = new vis.Network($scope.container, data, options);
    }

    // create a network
    function getDerajat(edget) {
        angular.forEach($scope.nodes._data, function (value, key) {
            value.derajat = 0;
            angular.forEach(edget, function (value1, key1) {
                if (value1.from != undefined) {
                    if (value.id == value1.from || value.id == value1.to) {
                        value.derajat += 1;
                    }
                }
            })

        })
    }


}