'use strict';

musicApp.directive('datepicker', function () {
    return {
        restrict: 'A',
        link: function (scope, element, attr) {
            element.datepicker();
        }
    }
})