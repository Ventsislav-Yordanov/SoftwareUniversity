var ajaxRequester = (function () {
    var makeRequest = function (method, url, data, success, error) {
        $.ajax({
            url: url,
            type: method,
            headers: {
                "X-Parse-Application-Id": "dfh3H9mg2mFb3CojgpSNYgLkHssSoe34fP3qGsCa",
                "X-Parse-REST-API-Key": "8sXTjvbTvLXASg39xu5clGJQLWA0xmriUer7FbOv"
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