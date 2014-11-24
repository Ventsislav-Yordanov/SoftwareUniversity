(function ($) {
    $.fn.treeView = function () {
        $(this).click(function (e) {
            $(e.target).children().toggleClass('visible');
            e.stopPropagation();
        });

        return this;
    }
}(jQuery));