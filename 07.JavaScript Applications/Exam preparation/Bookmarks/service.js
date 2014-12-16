var service = (function () {
    'use strict';

    var parseUrl = 'https://api.parse.com/1/classes';

    var getAllBookmarks = function (success, error) {
        return ajaxRequester.get(parseUrl + '/Bookmark', success, error);
    };

    var postBookmark = function (data, success, error) {
        return ajaxRequester.post(parseUrl + '/Bookmark', data, success, error);
    };

    var putBookmark = function (objectId, data, success, error) {
        return ajaxRequester.put(parseUrl + '/Bookmark/' + objectId, data, success, error);
    };

    var deleteBookmark = function (objectId, success, error) {
        return ajaxRequester.delete(parseUrl + '/Bookmark/' + objectId, success, error);
    };

    return {
        getAllBookmarks: getAllBookmarks,
        postBookmark: postBookmark,
        putBookmark: putBookmark,
        deleteBookmark: deleteBookmark
    }

}());