'use strict';

musicApp.factory('artistData', function($resource){

    var resource = $resource('/data/artist/:id', {id: '@id'});

    return {
        getArtist: function(id){
            return resource.get({id: id});
        },
        saveArtist: function(artist){
            if (!artist.id){
                resource.query().$promise.then(function(data){
                    artist.id = data.length + 1;
                    resource.save(artist);
                })
            }
            else {
                resource.save(artist);
            }
        },
        getAllArtists: function(){
            return resource.query();
        }
    }
});