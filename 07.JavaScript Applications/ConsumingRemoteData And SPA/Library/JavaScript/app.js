var books = [];
(function () {
    'use strict';
    $(function () {
        service.getAllBooks(loadBooks, error);
        $('#addBook').on('click', function () {
            var title = $('#title').val();
            var author = $('#author').val();
            var isbn = $('#isbn').val();

            addBook(title, author, isbn);
        });

        $(document).on('click', '.book', function () {
            var _this = $(this);
            var BookTitle = $(_this).find('td:first-child').text();
            var BookAuthor = $(_this).find('td:nth-child(2)').text();
            var BookiIsbn = $(_this).find('td:nth-child(3)').text(); 

            $('#edittedBook').text(BookTitle);

            $('#editTitle').val(BookTitle);
            $('#editAuthor').val(BookAuthor);
            $('#editIsbn').val(BookiIsbn);
        });

        $('#edit').on('click', function () {
            var title = $('#editTitle').val();
            var author = $('#editAuthor').val();
            var isbn = $('#editIsbn').val();
            var objectId = books[$('#edittedBook').text()];

            editBook(title, author, isbn, objectId);
            $('#edittedBook').val('');
        });
        
        $(document).on('click', '.btn-remove', function () {
            console.log(this);
            var objectId = books[$(this).parent().prev().prev().prev().text()];
            removeBook(objectId);
        });

    });

    var loadBooks = function (data) {
        $('.books tbody').html('');
        for (var b in data.results) {
            var book = data.results[b];
            // add book to array books
            books[book.title] = book.objectId;

            var removeButton = $('<button class="btn btn-remove btn-xs btn-danger">').text('Delete');

            $('.books tbody')
                    .append(
                        $('<tr>')
                            .attr('class', 'book')
                            .append($('<td>').text(book.title))
                            .append($('<td>').text(book.author))
                            .append($('<td>').text(book.isbn))
                            .append($('<td>').append(removeButton))
			        );
        }
    }

    var addBook = function (title, author, isbn) {
        var data = {
            title: title,
            author: author,
            isbn: isbn
        };

        service.postBook(data, function () {
            success('New book successfully added.');
            var title = $('#title').val('');
            var author = $('#author').val('');
            var isbn = $('#isbn').val('');
            // Reload Books
            service.getAllBooks(loadBooks, error);
        }, error);
    }

    var editBook = function (title, author, isbn, objectId) {
        var data = {
            title: title,
            author: author,
            isbn: isbn
        }

        service.putBook(objectId, data, function () {
            success('Book edited successfully');
            // Reload Books
            service.getAllBooks(loadBooks, error);
        }, error);
    }

    var removeBook = function (objectId) {
        service.deleteBook(objectId, function () {
            $('#editTitle').val('');
            $('#editAuthor').val('');
            $('#editIsbn').val('');
            $('#edittedBook').val('');
            $('#edittedBook').text('');
            success('Book successfully deleted.');
            // Reload Books
            service.getAllBooks(loadBooks, error);
        }, error);
    }

    function success(message) {
        noty({
            text: message,
            type: 'success',
            layout: 'topCenter',
            timeout: 1000
        });
    }

    function error () {
        noty({
            text: 'An error has occurred!',
            type: 'error',
            layout: 'topCenter',
            timeout: 1000
        });
    }
}());