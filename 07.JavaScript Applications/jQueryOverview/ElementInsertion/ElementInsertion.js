function addElementBeforeOtherElement() {
    var element = $('#wrapper');
    element.before("<h4>Added before element with id:" + element.attr('id') + "<h4>");
}

function addElementAfterOtherElement() {
    var element = $('#wrapper');
    element.after("<h4>Added after element with id:" + element.attr('id') + "<h4>");
}

$(document).ready(function () {
    $('#addBefore').on('click', addElementBeforeOtherElement);
    $('#addAfter').on('click', addElementAfterOtherElement);
});