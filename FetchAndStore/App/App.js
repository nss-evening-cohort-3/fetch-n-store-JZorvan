var app = angular.module("FetchAndStore", []);

app.controller("FetchCtrl", ['$scope', '$http', function ($scope, $http) {



    $scope.goFetch = () => {
        alert("Hello World");
        $scope.UserMethod;
        $scope.UserURL;
        console.log($scope.UserURL);
        $http.get($scope.UserURL);
        //$http.post("/api/Response", { "Name": "Janelle", "Class": "E3" })
        //    .success(function (response) {
        //    })
        //    .error(function (response) {
        //        alert("Bad!");
        //    });
    }
}]);

