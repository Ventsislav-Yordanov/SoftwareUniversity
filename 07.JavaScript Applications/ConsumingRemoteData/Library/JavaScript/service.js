var service = (function () {
    'use strict';

    var parseUrl = 'https://api.parse.com/1/classes';

    var getAllBooks = function (sucess, error) {
        return ajaxRequester.get(parseUrl + '/Book', sucess, error);
    };

    var postBook = function (data, success, error) {
        return ajaxRequester.post(parseUrl + '/Book', data, success, error);
    };

    var putBook = function (objectId, data, success, error) {
        return ajaxRequester.put(parseUrl + '/Book/' + objectId, data, success, error);
    };

    var deleteBook = function (objectId, sucess, error) {
        return ajaxRequester.delete(parseUrl + '/Book/' + objectId, sucess, error);
    };

    return {
        getAllBooks: getAllBooks,
        postBook: postBook,
        putBook: putBook,
        deleteBook: deleteBook
    }

}());