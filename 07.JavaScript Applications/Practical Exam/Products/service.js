var service = (function () {
    'use strict';

    var parseUrl = 'https://api.parse.com/1/classes';

    var getAllProducts = function (success, error) {
        return ajaxRequester.get(parseUrl + '/Product', success, error);
    };

    var postProduct = function (data, success, error) {
        return ajaxRequester.post(parseUrl + '/Product', data, success, error);
    };

    var putProduct = function (objectId, data, success, error) {
        return ajaxRequester.put(parseUrl + '/Product/' + objectId, data, success, error);
    };

    var deleteProduct = function (objectId, success, error) {
        return ajaxRequester.delete(parseUrl + '/Product/' + objectId, success, error);
    };

    return {
        getAllProducts: getAllProducts,
        postProduct: postProduct,
        putProduct: putProduct,
        deleteProduct: deleteProduct
    }

}());