(function (){
    'use strict';

    $(function(){
        // ----- show Home view -----
        $('#wrapper > *').hide();
        $('#homeView').show();
        if(sessionStorage.length > 0) {
            $('#wrapper > *').hide();
            $('#greeting').text('Welcome ' + sessionStorage.name);
            $('#bookmarksView').show();
            service.getAllBookmarks(loadBookmarks, function(){
                error('Cannot load bookmarks!');
            })
        }

        // ----- Register -----
        $('#register').on('click', function() {
            $('#wrapper > *').hide();
            $('#registerView').show();
        });

        $('#submitRegister').on('click', function(){
            var username =  $('#usernameRegister').val();
            var password = $('#passwordRegister').val();
            registerUser(username, password);
        });

        // ----- Login -----
        $('#login').on('click', function(){
            $('#wrapper > *').hide();
            $('#loginView').show();
        });

        $('#submitLogin').on('click',function(){
            var username =  $('#usernameLogin').val();
            var password = $('#passwordLogin').val();
            loginUser(username, password);
        });

        // ----- Add bookmark -----
        $('#addBookmark').on('click', addBookMark);

        // ----- Delete bookmark -----
        $(document).on('click', '.delete', function(){
            var id = $(this).parent().attr('id');
            deleteBookmark(id);
        })

        // ----- Logout -----
        $('#logout').on('click', function(){
            sessionStorage.clear();
            success("You have logged out!");
            $('#wrapper > *').hide();
            $('#homeView').show();
        })
    });

    var registerUser = function (username, password) {
        var data = {
            username: username,
            password: password
        };
        ajaxRequester.post('https://api.parse.com/1/classes/_User', data, function (){
            success('Account created successfully.');
            setTimeout(function(){
                loginUser(username, password);
            },1000);
        },
        function(){
            error('Registration error!');
        });
    }

    var loginUser = function(username, password){
        $.ajax({
            method: 'GET',
            url: 'https://api.parse.com/1/login',
            headers: {
                "X-Parse-Application-Id": "dfh3H9mg2mFb3CojgpSNYgLkHssSoe34fP3qGsCa",
                "X-Parse-REST-API-Key": "8sXTjvbTvLXASg39xu5clGJQLWA0xmriUer7FbOv"
            },
            contentType: 'application/json',
            data: {
                username: username,
                password: password
            },
            success: function(data){
                success('Login successfully.');
                sessionStorage.name = data.username;
                sessionStorage.objectId = data.objectId;
                sessionStorage.token = data.sessionToken;
                $('#wrapper > *').hide();
                $('#greeting').text('Welcome ' + sessionStorage.name);
                $('#bookmarksView').show();
                service.getAllBookmarks(loadBookmarks, function(){
                    error('Cannot load bookmarks!');
                })
            },
            error: function(){
                error('Login error!');
            }
        });
    }

    var loadBookmarks = function(data){
        $('#bookmarks').html('');
            for (var b in data.results){
                var bookmark = data.results[b];

                if(bookmark.author.objectId === sessionStorage.objectId){
                    var newBookMark = $('<div class="bookmark">').attr('id', bookmark.objectId);
                    $('<div>').text(bookmark.title).appendTo(newBookMark);
                    $('<a href="'+ bookmark.url +'">' + bookmark.url + '</a>').appendTo(newBookMark);
                    $('<button class="delete">Delete</button>').appendTo(newBookMark);
                    newBookMark.appendTo($('#bookmarks'));
                };
            }
    }

    var addBookMark = function(){
        var title = $('#title').val();
        var url = $('#url').val();
        var data = {
            title: title,
            url: url,
            author: {
                '__type': 'Pointer',
                'className': '_User',
                'objectId' : sessionStorage.objectId
            }
        }

        service.postBookmark(data, function(){
            var title = $('#title');
            var url = $('#url');
            success('Bookmark added.');

            service.getAllBookmarks(loadBookmarks , function(){
                error('Cannot load bookmarks!');
            })
        }, function(){
            error('Error occurred while posting bookmark!');
        })
    }

    var deleteBookmark = function(id){
        service.deleteBookmark(id, function(){
            success('Bookmark successfully deleted.')
            service.getAllBookmarks(loadBookmarks, function(){
                error('Cannot load bookmarks!');
            })
        }, function(){
            error('Bookmark delete error.')
        })
    };

    function success(message) {
        noty({
            text: message,
            type: 'success',
            layout: 'topCenter',
            timeout: 1000
        });
    }

    function error (text) {
        noty({
            text: text,
            type: 'error',
            layout: 'topCenter',
            timeout: 1000
        });
    }
}());