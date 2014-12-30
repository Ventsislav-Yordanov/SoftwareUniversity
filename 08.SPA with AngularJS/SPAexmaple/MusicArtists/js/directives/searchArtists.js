'use strict';

musicApp.directive('searchArtists', function() {
   return {
       restrict: 'EA',
       templateUrl: '/templates/directives/search-artists.html',
       replace: true,
       scope: {
           search: '=parent'
       }
   }
});