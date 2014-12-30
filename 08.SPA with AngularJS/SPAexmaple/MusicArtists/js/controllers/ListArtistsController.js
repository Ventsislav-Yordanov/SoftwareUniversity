'use strict';

musicApp.controller('ListArtistsController',
    function ListArtistsController($scope, artistData) {
        $scope.search = 'enter artist name';
        $scope.artists = artistData.getAllArtists();
    }
);