(function ($) {
    $.fn.messageBox = function () {
        var $this = $(this);

        $this.css({
            'font-size': '20px',
            'text-align': 'center',
            'width': '190px',
            'border-radius': '20px',
            'padding': '5px'
        });

        var success = function (message) {
            $this.css({
                'background-color': '#5CE65C',
            })
                .html(message)
                .fadeIn(1000);

            setTimeout(function () {
                $this.fadeOut(1000)
            }, 3000);
        },

            error = function (message) {
                $this.css({
                    'background-color': '#FF1919',
                })
                    .html(message)
                    .fadeIn(1000);

                setTimeout(function () {
                    $this.fadeOut(1000)
                }, 3000);
            };

        return {
            success: success,
            error: error
        }
    }
}(jQuery));