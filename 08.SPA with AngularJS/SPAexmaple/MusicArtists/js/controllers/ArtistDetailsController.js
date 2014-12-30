'use strict';

musicApp.controller('ArtistDetailsController', function($scope, $routeParams, artistData){

    $scope.artist = artistData.getArtist($routeParams.id);

    $scope.hideRecordsInformation = true;
    $scope.showRecordsText = 'Show';
    $scope.showAndHideRecords = showAndHideRecords;

    $scope.hideBandMembers = true;
    $scope.showBandMembersText = 'Show';
    $scope.showAndHideBandMembers = showAndHideBandMembers;

    $scope.boldFontCss = {
        fontWeight: 'bold'
    };

    $scope.blueTextClass = 'grey-text';
    $scope.grayBackgroundClass = 'grey-background';

    $scope.upVoteRating = upVoteRating;
    $scope.downVoteRating = downVoteRating;

    $scope.sort = '-rating';

    function showAndHideBandMembers(){
        if ($scope.hideBandMembers == true){
            $scope.hideBandMembers = false;
            $scope.showBandMembersText = 'Hide';
        } else {
            $scope.hideBandMembers = true;
            $scope.showBandMembersText = 'Show';
        }
    }

    function showAndHideRecords(){
        if ($scope.hideRecordsInformation == true){
            $scope.hideRecordsInformation = false;
            $scope.showRecordsText = 'Hide';
        } else {
            $scope.hideRecordsInformation = true;
            $scope.showRecordsText = 'Show';
        }
    }

    function upVoteRating(album) {
        album.rating++;
    }

    function downVoteRating(album) {
        album.rating--;
    }
})