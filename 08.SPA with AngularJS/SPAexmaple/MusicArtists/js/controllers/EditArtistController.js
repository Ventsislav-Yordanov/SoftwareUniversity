'use strict';
// TODO: rename to AddArtistController
musicApp.controller('EditArtistController',
    function EditArtistController($scope, $location, artistData){
        $scope.saveArtist = function(artist, newArtistForm){
            if (newArtistForm.$valid){
                artistData.saveArtist(artist);
            } else {
                alert('invalid data');
            }
        };

        $scope.cancel = function(){
            $location.path('/home');
        };
    }
);