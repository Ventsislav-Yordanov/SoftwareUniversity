(function(){
    var app = angular.module('tigerApp', []);
    app.controller('TigerController', function($scope){
        $scope.tiger = {
            'name': 'Ares',
            'born': 'Bulgaria',
            'birthDate': '2006',
            'live': 'Ruse Zoo',
            'photo': 'http://tigerday.org/wp-content/uploads/2013/04/tiger.jpg'
        } ;

        $scope.imgStyles = {
            width: '300px',
            height: '200px',
            margin: '10px'
        };

        $scope.tigerDivsStyles = {
            display: 'inline-block'
        };

        $scope.keyStyles = {
            fontSize: '20px',
            fontWeight: 'bold',
            fontFamily: 'Tahoma',
            color: '#3b4b5b',
            marginLeft: '10px'
        };

        $scope.valueStyles = {
            fontSize: '20px',
            fontFamily: 'Tahoma',
            color: '#3b4b5b',
        };

        $scope.tigerWrapperStyles = {
            backgroundColor: '#cacaca',
            display: 'inline-block'
        };
    });
})();