(function (){
    'use strict';

    $(function(){

        $('#menu ul:nth-child(2)').hide();
        $('#wrapper #main section').hide();
        $('#wrapper #main .welcome-message').parent().show();

        // register click
        $('#menu ul:nth-child(1) li:nth-child(3)').on('click', function() {
            $('#wrapper #main section').hide();
            $('#wrapper #main .register-form').parent().show();
        });

        $('.login-form a').on('click', function() {
            $('#wrapper #main section').hide();
            $('#wrapper #main .register-form').parent().show();
        });

        $('.login').on('click', function(){
            $('#wrapper #main section').hide();
            $('#wrapper #main .login-form').parent().show();
        })

        // login click
        $('#menu ul:nth-child(1) li:nth-child(2)').on('click', function() {
            $('#wrapper #main section').hide();
            $('#wrapper #main .login-form').parent().show();
        });

        $('.welcome-message a').on('click', function(){
            $('#wrapper #main section').hide();
            $('#wrapper #main .login-form').parent().show();
        })

        // home click
        $('#menu ul:nth-child(1) li:nth-child(1)').on('click', function() {
            $('#wrapper #main section').hide();
            $('#wrapper #main .welcome-message').parent().show();
        });


        // ----- Register -----
        $('#register-button').on('click', function() {
            var username = $('.register-form .data #username').val();
            var password = $('.register-form .data #password').val();
            var confirmPassword = $('.register-form .data #confirm-password').val();

            if(password === confirmPassword){
                registerUser(username, password);
            } else {
                error('Passwords must be identical')
            }
        });

        // ----- Login -----
        $('#login-button').on('click', function() {
            var username = $('.login-form .data #username').val();
            var password = $('.login-form .data #password').val();
            loginUser(username, password);
        });


        // ----- check for logged user -----
        if(sessionStorage.length > 0) {
            $('#menu ul:nth-child(1)').hide();
            $('#menu ul:nth-child(2)').show();
            $('#wrapper #main section').hide();
            $('#wrapper #main .welcome-message-user .main-header').text('Welcome ' + sessionStorage.name);
            $('#wrapper #main .welcome-message-user').parent().show();
        }

        // ----- logout -----
        $('#menu ul:nth-child(2) li:nth-child(4)').on('click', function(){
            sessionStorage.clear();
            success("You have logged out!");

            $('#wrapper #main section').hide();
            $('#wrapper #main .welcome-message').parent().show();
            $('#menu ul:nth-child(2)').hide();
            $('#menu ul:nth-child(1)').show();
        });

        // ----- show products -----
        $('#menu ul:nth-child(2) li:nth-child(2)').on('click', function(){
            $('#wrapper #main section').hide();
            $('#wrapper #main .products').parent().show();
            service.getAllProducts(loadProducts, function(){
                error('Cannot get products');
            })
        })

        // --- home ---
        $('#menu ul:nth-child(2) li:nth-child(1)').on('click', function(){
            $('#wrapper #main section').hide();
            $('#wrapper #main .welcome-message-user').parent().show();
        })

        //--- add product ---
        $('#menu ul:nth-child(2) li:nth-child(3)').on('click', function(){
            $('#wrapper #main section').hide();
            $('#wrapper #main .add-product-form').parent().show();
            service.getAllProducts(loadProducts, function(){
                error('Cannot get products');
            })
        })

        $('#add-product-button').on('click', addProduct);

        // ----- Delete product -----
        $(document).on('click', '.delete-button', function(){
            var id = $(this).parent().attr('id');
            deleteProduct(id);
        })

        // ----- Edit product -----
        $(document).on('click', '.edit-button', function(){
            $('#wrapper #main section').hide();
            $('#wrapper #main .edit-product-form').parent().show();
            //TODO ADD VALUES
            sessionStorage.productId = $(this).parent().attr('id');
            //console.log(sessionStorage.productId);
        });

        $('#edit-product-button').on('click', function () {
            var name = $('#item-name').val();
            var category = $('#edit-category').val();
            var price = $('#edit-price').val();
            var objectId = sessionStorage.productId;

            editProduct(name, category, price, objectId);
        });

        $('.cancel-product-button').on('click', function(){
            $('#wrapper #main section').hide();
            $('#wrapper #main .products').parent().show();
            service.getAllProducts(loadProducts, function(){
                error('Cannot get products');
            })
        })

    });

    var registerUser = function (username, password) {
        var data = {
            username: username,
            password: password
        };
        ajaxRequester.post('https://api.parse.com/1/classes/_User', data, function (){
                success('Account created successfully.');
                loginUser(username, password);
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
                "X-Parse-Application-Id": "u9GBFEa5MCbDm1y9wy35OaNde0pTNAmE7upm9iTR",
                "X-Parse-REST-API-Key": "7cGBqM011wxkY351qm35alQ8NasAAFnpHi0904hF"
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

                $('#menu ul:nth-child(1)').hide();
                $('#menu ul:nth-child(2)').show();
                $('#wrapper #main section').hide();
                $('#wrapper #main .welcome-message-user .main-header').text('Welcome ' + sessionStorage.name);
                $('#wrapper #main .welcome-message-user').parent().show();
            },
            error: function(){
                error('Login error!');
            }
        });
    }

    var loadProducts = function(data){
        $('.products').html('');
        for (var p in data.results){
            var product = data.results[p];

            var newProduct = $('<li class="product">').attr('id', product.objectId);
            var productinfo = $('<div class="product-info">');

            productinfo.appendTo(newProduct);
            var itemName = $('<p class="item-name">').text(product.name);
            itemName.appendTo(newProduct);
            var itemCategory = $('<p class="category">').text('Category: ' + product.category);
            itemCategory.appendTo(newProduct);
            var itemPrice = $('<p class="price">').text('Price: ' + product.price);
            itemPrice.appendTo(newProduct);

            if(product.author.objectId === sessionStorage.objectId){
                $('<button class="edit-button">Edit</button>').appendTo(newProduct);
                $('<button class="delete-button">Delete</button>').appendTo(newProduct);
            }

            newProduct.appendTo($('.products'));

        }
    }

    var addProduct = function(){
        var name = $('.add-product-form .data #name').val();
        var category =  $('.add-product-form .data #category').val();
        var price =  $('.add-product-form .data #price').val();
        var data = {
            name: name,
            category: category,
            price: price,
             author: {
                '__type': 'Pointer',
                'className': '_User',
                'objectId' : sessionStorage.objectId
             }
        }

        service.postProduct(data, function(){
            success('Product added.');
            $('#wrapper #main .add-product-form').parent().hide();
            $('#wrapper #main .products').parent().show();

            service.getAllProducts(loadProducts , function(){
                error('Cannot load bookmarks!');
            })
        }, function(){
            error('Error occurred while posting bookmark!');
        })
    }

    var deleteProduct = function(id){
        noty({
            text: 'Delete this Product?',
            type: 'confirm',
            layout: 'topCenter',
            buttons:
                [
                    {
                        text: 'Yes',
                        onClick: function($noty){
                            service.deleteProduct(id, function(){
                                success('Product successfully deleted.');
                                service.getAllProducts(loadProducts, function(){
                                    error('Cannot load products!');
                                })
                            }, function(){
                                error('Product delete error.')
                            })
                            $noty.close();
                        }
                    },
                    {
                        text: 'Cancel',
                        onClick: function($noty){
                            $noty.close();
                        }
                    }
                ]
        });
    };

    var editProduct = function(name, category, price, objectId){
        var data = {
            name: name,
            category: category,
            price: price
        }

        service.putProduct(objectId, data, function(){
            success('Product edit successfully.');
            sessionStorage.removeItem('productId');
            $('#wrapper #main section').hide();
            $('#wrapper #main .products').parent().show();
            service.getAllProducts(loadProducts, function(){
                error('Cannot load products!');
            })
        }, function(){
            error('Product edit error!');
        })
    }


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