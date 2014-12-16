var ajaxRequester = (function () {
    var makeRequest = function (method, url, data, success, error) {
        $.ajax({
            url: url,
            type: method,
            headers: {
                "X-Parse-Application-Id": "u9GBFEa5MCbDm1y9wy35OaNde0pTNAmE7upm9iTR",
                "X-Parse-REST-API-Key": "7cGBqM011wxkY351qm35alQ8NasAAFnpHi0904hF"
            },
            contentType: 'application/json',
            data: JSON.stringify(data) || undefined,
            success: success,
            error: error
        });
    }

    var makeGetRequest = function (url, success, error) {
        return makeRequest('GET', url, null, success, error);
    }

    var makePostRequest = function (url, data, success, error) {
        return makeRequest('POST', url, data, success, error);
    }

    var makePutRequest = function (url, data, success, error) {
        return makeRequest('PUT', url, data, success, error);
    }

    var makeDeleteRequest = function (url, success, error) {
        return makeRequest('DELETE', url, null, success, error);
    }

    return {
        get: makeGetRequest,
        post: makePostRequest,
        put: makePutRequest,
        delete: makeDeleteRequest
    }

}());