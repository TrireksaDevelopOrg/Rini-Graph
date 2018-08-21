"strich"
angular.module("app.controllers", [])
    .controller("PerawatController", PerawatController)
    .controller("MainController", MainController)
    .controller("GraphController", GraphController)
    .controller("JadwalController",JadwalController)
    ;


function PerawatController(MessageServices, PerawatServices, $scope) {
    $scope.Perawats = PerawatServices.Perawats;
    $scope.ModalTitle;
    $scope.model = {};
    $scope.Save = function (item) {
        if (item.IdPerawat == undefined) {
            PerawatServices.post(item).then(function (response) {
                $scope.model = {};
            });
        } else {
            PerawatServices.put(item).then(function (response) {
                $scope.Selected.NIP = response.NIP;
                $scope.Selected.Nama = response.Nama;
                $scope.Selected.Gender = response.Gender;
                $scope.Selected.Alamat = response.Alamat;
                $scope.Selected.Golongan = response.Golongan;

            });
        }
    }

    $scope.SelectedItem = function (item) {
        $scope.ModalTitle = "Edit Perawat";
        $scope.Selected = item;
        $scope.model = angular.copy(item);
    }

    $scope.Delete = function (item) {
        MessageServices.dialog("Yakin Menghapus Data ? ")
            .then(function () {
                PerawatServices.delete(item);
            }, function () {

            })
    }

}



function JadwalController(MessageServices) {
    
}

function MainController($scope, MessageServices) {
   
     
}



function GraphController($scope,$http,MatrixServices,$filter) {
    var white = "white";
   // $scope.edges = [];
    $scope.DataNodes = [];
    $scope.apa = "AKU";
    MatrixServices.getLast().then(function (response) {
        $scope.DataNodes = response.data.Nodes;
        var matrixData = [];
        $scope.Datas = [];
        angular.forEach($scope.DataNodes, function (head, keyhead) {
            var items = [];
            var label = { value: head.id, Name:head.label };
            items.push(label);
            angular.forEach($scope.DataNodes, function (value, key) {
                var item = { from: label.value, to: value.id, value: 0 };
                angular.forEach(response.data.Adges, function (ad, adkey) {
                    if (item.from == ad.Baris && item.to == ad.Kolom) {
                        item.value = ad.Nilai;
                    }
                })
                items.push(item);

            });
            $scope.Datas.push(items);
        });
    });
   

    $scope.Show = function () {
        $scope.edges = [];
        var result = getDerajat($scope.Datas);
        angular.forEach(result, function (value, key) {
            value.Tetangga = [];
            angular.forEach($scope.Datas[key], function (value1, key1) {
                if (value1.from != undefined && value1.value > 0) {
                    $scope.edges.push(value1);
                    if (value1.from == value.value || value1.to == value.value) {
                        value.Tetangga.push(value1);
                    }
                }
            })

        });




      

        $filter('orderBy')(result, 'derajat');

        var colors = ['red', 'yellow', 'green', 'blue']
        var selectedColor = -1;
        angular.forEach(result, function (value, key) {
            var complete = false;
            var source = [];
            selectedColor++;
            while (!complete) {
                if (value.color == undefined &&  source.length <= 0) {
                    value.color = { background: colors[selectedColor] }
                    var item = { color: value.color, source: [] };
                    source.push(value);
                } else {
                    angular.forEach(result, function (sourceItem, Key1) {
                        var bertetangga = false;
                        if (Key1 == 14) {
                            complete = true;
                        } else if (sourceItem.color == undefined && sourceItem.value > value.value) {
                            angular.forEach(source, function (lasItem, Key2) {
                                angular.forEach(lasItem.Tetangga, function (item, k) {
                                    if (item.from == sourceItem.value || item.to == sourceItem.value)
                                        bertetangga = true;
                                })
                            })

                            if (!bertetangga) {
                                sourceItem.color = { background: colors[selectedColor] };
                                source.push(sourceItem);

                            }
                        }


                    })
                }
            }




           

        })


        angular.forEach(result, function (resultItem, key) {
            angular.forEach($scope.DataNodes, function (data, key) {
                if (resultItem.value == data.id)
                    data.color = resultItem.color;
            })

        })



        $scope.nodes = new vis.DataSet($scope.DataNodes);

        var data = {
            nodes: $scope.nodes,
            edges: $scope.edges
        };
        var options = {};

        // initialize your network!
        var container = document.getElementById('mynetwork');

        $scope.network = new vis.Network(container, data, options);
    }

    // create a network
    function getDerajat(data) {
        var derajats = [];
        angular.forEach(data, function (value, key) {
            var derajat = 0;
            angular.forEach(value, function (value1, key1) {
                if (value1.from != undefined && value1.value>0) {
                    derajat += 1;
                }
            })

            value[0].derajat = derajat;
            derajats.push(value[0]);
        })
        return derajats;
    }

    $scope.Save = function (model) {
        var matrixs = [];
        var period = {};
        switch (model.Periode) {
            case "Januari":
                period.TanggalMulai = new Date();
                period.TanggalAkhir = new Date();
                period.Maximum = model.Maximum;
                break;

            default:
                break;
        }



        angular.forEach($scope.Datas, function (value, key) {
            angular.forEach(value, function (value1, key) {
                if (value1.value > 0 && value1.from != undefined) {
                    var item = { Baris: value1.from, Kolom: value1.to, Nilai: value1.value };
                    matrixs.push(item);
                }
            })
        })

        var data = {};
        data.Periode = period;
        data.Adges = matrixs;
        MatrixServices.post(data);



    }

}