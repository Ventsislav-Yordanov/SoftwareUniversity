(function () {
    'use strict';

    $(function () {
        service.getAllBooks(drawBooks, error);

        $('#add-book').on('click', addBook);
    });
    var drawBooks = function (data) {
        if (data.results.length > 0) {
            $('.books').append($('<tbody>'));
            $(data.results).each(function (index, book) {
                $('.books tbody')
                    .append(
                        $('<tr>')
                            .attr('book-Id', book.objectId)
                            .append($('<td>').text(book.title))
                            .append($('<td>').text(book.author))
                            .append($('<td>').text(book.isbn))
                            .append($('<td>').append($('<button class="btn btn-remove btn-xs btn-danger">').text('Remove').on('click', removeBook)))
                            .append($('<td>').append($('<button class="btn btn-xs btn-info">').text('Edit').on('click', editBook)))
				);
            });
        } else {
            $('.books').append($('<tbody>').append($('<h1>').text('No Books here.')));
        }
    }

    var addBook = function () {
        var bookAuthor = $('#inputBookAuthor').val();
        var bookTitle = $('#inputBookTitle').val();
        var bookISBN = $('#inputBookISBN').val();
        var data = {
            "author": bookAuthor,
            "title": bookTitle,
            "isbn": bookISBN
        };

        service.postBook(data, function (data) {
            $('.books tbody')
                .append(
                    $('<tr>')
                        .attr('book-Id', data.objectId)
                        .append($('<td>').text(bookTitle))
                        .append($('<td>').text(bookAuthor))
                        .append($('<td>').text(bookISBN))
                        .append($('<td>').append($('<button class="btn btn-remove btn-xs btn-danger">').text('Remove').on('click', removeBook)))
                        .append($('<td>').append($('<button class="btn btn-xs btn-info">').text('Edit').on('click', editBook)))
                );
        }, error);
    }

    var removeBook = function () {
        var bookId = $(this).parent().parent().attr('book-Id');
        var _this = this;
        service.deleteBook(bookId, function () {
            $(_this).parent().parent().remove();
        }, error);
    }

    var editBook = function () {
        var bookTitle = $('#inputEditBookTitle').val();
        var bookAuthor = $('#inputEditBookAuthor').val();
        var bookISBN = $('#inputEditBookISBN').val();
        var data = {
            "author": bookAuthor,
            "title": bookTitle,
            "isbn": bookISBN
        };
        var bookId = $(this).parent().parent().attr('book-Id')

        service.putBook(bookId, data, function () {
            var thisBookQuery = 'tr[book-id="' + bookId + '"]';
            var book = $(thisBookQuery);
            book.find('td:nth-child(1)').text(bookTitle);
            book.find('td:nth-child(2)').text(bookAuthor);
            book.find('td:nth-child(3)').text(bookISBN);
        }, error);
    }

    var error = function () {
        alert('Error!');
    }
}());