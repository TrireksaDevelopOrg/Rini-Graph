

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



function JadwalController(MessageServices, MatrixServices, $scope) {
    $scope.monthNames = ["Januari", "Februari", "Maret", "April", "Mei", "Juni",
        "Juli", "Agustus", "September", "October", "November", "Desember"
    ];

    $scope.SelectedItem = function (item) {
        MatrixServices.getJadwal(item).then(function (response) {
            $scope.Jadwals = response;
        });
    }

    MatrixServices.getPeriode().then(function (response) {
        $scope.Periodes = response;
    });
}

function MainController($scope, MessageServices) {
   
     
}



function GraphController($scope,$http,MatrixServices,$filter,PerawatServices) {
    var white = "white";
   // $scope.edges = [];
    $scope.DataNodes = [];
    $scope.Datas = [];
    $scope.apa = "AKU";
    MatrixServices.get().then(function (response) {
        $scope.DataNodes = response.Nodes;
        $scope.Datas = [];
        angular.forEach($scope.DataNodes, function (head, keyhead) {
            var items = [];
            var label = { value: head.id, Name: head.label, Day: head.Day, IsMoorning: head.IsMoorning };
            items.push(label);
            angular.forEach($scope.DataNodes, function (value, key) {
                var item = { from: label.value, to: value.id, value: 0 };
                angular.forEach(response.Adges, function (ad, adkey) {
                    if (item.from == ad.Baris && item.to == ad.Kolom) {
                        item.value = ad.Nilai;
                    }
                })
                items.push(item);

            });
            $scope.Datas.push(items);
          
        });
        $scope.Show();
    });

   

    $scope.ClearMatrix = function () {

        $scope.Datas = [];
        angular.forEach($scope.DataNodes, function (head, keyhead) {
            var items = [];
            var label = { value: head.id, Name: head.label, Day: head.Day, IsMoorning:head.IsMoorning };
            items.push(label);
            angular.forEach($scope.DataNodes, function (value, key) {
                var item = { from: label.value, to: value.id, value: 0 };
                items.push(item);

            });
            $scope.Datas.push(items);
        });

    }

    $scope.Show = function () {
        $scope.edges = [];
        var result = getDerajat($scope.Datas);
        angular.forEach(result, function (value, key) {
            value.Tetangga = [];
            angular.forEach($scope.Datas[key], function (value1, key1) {
                if (value1.from != undefined && value1.value > 0) {
                    var ed = { from: value1.from, to: value1.to, value:10 }
                    $scope.edges.push(ed);
                    if (value1.from == value.value || value1.to == value.value) {
                        value.Tetangga.push(value1);
                    }
                }
            })

        });

       var result1= $filter('orderBy')(result, '-derajat');

        var colors = ['#EF5B5B', '#FFBA49', '#0DAB76', '#C3ACCE', '#0892A5', '#ED217C'];
        var selectedColor = -1;
        angular.forEach(result1, function (value, key) {
            var complete = false;
            var source = [];
            selectedColor++;
            while (!complete) {
                if (value.color == undefined &&  source.length <= 0) {
                    value.color = { background: colors[selectedColor] }
                    var item = { color: value.color, source: [] };
                    source.push(value);
                } else {

                    angular.forEach(result1, function (sourceItem, Key1) {
                        var bertetangga = false;
                        angular.forEach(source, function (parent, k) {
                            angular.forEach(parent.Tetangga, function (item, k) {
                                if (item.from == sourceItem.value || item.to == sourceItem.value)
                                    bertetangga = true;
                            })

                           


                        })

                        if (!bertetangga)
                            angular.forEach(sourceItem.Tetangga, function (parent, k) {
                                if (parent.from == value.value || parent.to == value.value)
                                    bertetangga = true;
                            })


                        if (!bertetangga) {
                            if (sourceItem.color == undefined) {
                                sourceItem.color = { background: colors[selectedColor] };
                                source.push(sourceItem);
                            }


                        }



                       
                    })

                    complete = true;
                }
            }




           

        })


        angular.forEach(result1, function (resultItem, key) {
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
        var options = {
            "edges": {
                "smooth": {
                    "forceDirection": "none",
                    "roundness":0.1
                }
            },
            "physics": {
                "minVelocity": 0.1
            }
        }
        $scope.Graph = result1;
        // initialize your network!
        var container = document.getElementById('mynetwork');

        $scope.network = new vis.Network(container, data, options);
    }
    $scope.Calender = function () {
        const monthNames = ["Januari", "Februari", "Maret", "April", "Mei", "Juni",
            "Juli", "Agustus", "September", "October", "November", "Desember"
        ];

        $scope.Calenders = [];
        for (var i = $scope.Periode.TanggalMulai.getDate(); i <= $scope.Periode.TanggalAkhir.getDate(); i++) {
            var year = $scope.Periode.TanggalMulai.getFullYear();
            var mont = $scope.Periode.TanggalMulai.getMonth();
            var date = new Date(Date.UTC(year, mont, i));
            $scope.Calenders.push(date);
        }
        var perawats = [];
        angular.forEach(PerawatServices.Perawats, function (val, ke) {
            var item = {};
            angular.copy(val, item);
            item.Masuk = 0;
            perawats.push(item);
        })


        angular.forEach($scope.Calenders, function (d, dkey) {

            angular.forEach(perawats, function (value, key) {
                if (value.Dates == undefined)
                    value.Dates = [];
                var itemDate = {};
                itemDate.Date = d;
                itemDate.Value = "L";
                angular.forEach($scope.Graph, function (g, k) {
                    var dd = d.getDay();
                    if (d.getDay() == g.Day) {
                        angular.forEach(g.Perawat, function (per, perK) {
                            if (value.IdPerawat == per.IdPerawat) {
                                if (g.IsMoorning)
                                    itemDate.Value = "P";
                                else
                                    itemDate.Value = "M";
                            }
                            
                        })
                    }
                })
                value.Dates.push(itemDate)
            })
        });
        $scope.Result = {};
        var Periode = $scope.Periode;
        $scope.Result.Periode = monthNames[Periode.TanggalMulai.getMonth()] + " " + Periode.TanggalMulai.getFullYear();
        $scope.Result.Data = perawats;
       

    }


    $scope.BuatJadwal = function (model) {
     
        var periode = CreatePeriode(model);
        $scope.Periode = periode;
        var a = $scope.Graph;
        var perawats = [];
        var colorCount = Math.floor(PerawatServices.Perawats.length / periode.Maximum);
        angular.forEach(PerawatServices.Perawats, function (val, ke) {
            var item = {};
            angular.copy(val, item);
            item.Masuk = 0;
            perawats.push(item);
        });
        var calenders = [];
        angular.forEach($scope.Graph, function (item, key) {
            item.Perawat = [];
            if (perawats.length >= periode.Maximum) {
                for (var i = 0; i < periode.Maximum; i++) {
                    var indexRandom = Math.floor(Math.random() * (perawats.length));
                    var result = perawats[indexRandom];
                    result.Masuk++;
                    result.LastColor = item.color;
                    item.Perawat.push(result);
                    perawats.splice(indexRandom, 1);
                 
                }
            } else {
                var index = $scope.Graph.indexOf(item);
                var node = $scope.Graph[index - colorCount];
             
             
                angular.forEach(node.Perawat, function (value, key) {
                    var newItem = {};
                    var item = angular.copy(value, newItem);
                    perawats.push(newItem);
                })
               $filter('orderBy')(perawats, 'Masuk');
                for (var i = 0; i < periode.Maximum; i++) {
                    var result = perawats[0];
                    result.Masuk++;
                    result.LastColor = item.color;
                    item.Perawat.push(result);
                    perawats.splice(0, 1);
                }
            }
            
           
        })

        $scope.Calender();
    }

    function RandomPerawat(perawats) {
        var rand = perawats[Math.floor(Math.random() * (perawats.length - 1))];
        var result = {};
        angular.copy(rand, result);
        var index = perawats.indexOf(rand, 1);
        perawats.splice(index, 1);
        return result;
    }


    function CreatePeriode(model) {
        var period = {};
        var year = new Date().getFullYear();
        var month = 0;
        switch (model.Periode) {
            case "Januari":
                month = 0;
                break;
            case "Februari":
                month = 1;
                break;
            case "Maret":
                month = 2;
                break;
            case "April":
                month = 3;
                break;
            case "Mei":
                month = 4;
                break;
            case "Juni":
                month = 5;
                break;
            case "Juli":
                month = 6;
                break;
            case "Agustus":
                month = 7;
                break;
            case "September":
                month = 8;
                break;
            case "Oktober":
                month = 9;
                break;
            case "November":
                month = 10;
                break;
            case "Desember":
                month = 11;

                break;

            default:
                break;
        }

        period.TanggalMulai = new Date(year, month, 1,1,0,1);
        period.TanggalAkhir = new Date(year, month+1, 0,1,0,1);
        period.Maximum = model.Maximum;
        period.Bulan = month;
        period.Tahun = year;
        return period;

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

        var data = {};
        data.Periode = $scope.Periode;
        data.Jadwals = [];
        angular.forEach(model.Data, function (value, key) {
            data.Jadwals.push(value);
        });

        MatrixServices.post(data);
    }

}