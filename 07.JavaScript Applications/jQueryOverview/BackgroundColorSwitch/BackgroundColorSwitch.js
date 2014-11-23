function BackgroundColorSwitch() {
    var className = $('#Class').val();
    var color = $('#colorPicker').val();
    var elements = $('.' + className);

    //for (var i = 0; i < elements.length; i++) {
    //    $(elements[i]).css('background-color', color);
    //}

    elements.each(function (i) {
        $(elements[i]).css('background-color', color);
    });
}

$(document).ready(function () {
    $('#Paint').on('click', BackgroundColorSwitch);
});