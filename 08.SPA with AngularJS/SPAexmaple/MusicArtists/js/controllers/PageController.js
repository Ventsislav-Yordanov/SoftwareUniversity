'use strict';

musicApp.controller('PageController', function PageController($scope, author){
    $scope.author =  author;
    $scope.date = {
        year: 2014,
        month: 12,
        day: 22
    };
});