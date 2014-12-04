(function () {
    // On document ready ----- Short syntax for: $(document).ready(function(){}); -----
    $(function () {
        $('#firstTimeVisit').hide();
        $('#greetingMessage').hide();

        var addUsername = function () {
            var username = $('#username').val();
            // Remove white spaces before and after username
            if (/^\s*$/.test(username)) {
                addItemError();
                $('#addUser').val('');
                return;
            }

            localStorage.setItem('user', username);
            $('#firstTimeVisit').hide();
            $('#greetingMessage').text('Hello ' + username + '!').show();
        }

        $('#addUser').on('click', addUsername);

        var clearHistory = function () {
            window.localStorage.clear();
            window.sessionStorage.clear();
            location.reload(true);
            $('#greetingMessage').hide();
        }

        $('#clearHistory').on('click', clearHistory);

        // Check if the user is visiting the page for the first time and get his name or greet him
        if (!localStorage.getItem('counter')) {
            localStorage.setItem('counter', 0);
            $('#firstTimeVisit').show();
        } else {
            var user = localStorage.getItem('user');
            if (user === null) {
                user = 'unknown user';
            }

            $('#greetingMessage').text('Hello ' + user + '!');
            $('#greetingMessage').show();
        }

        if (!sessionStorage.getItem('counter')) {
            sessionStorage.setItem('counter', 0);
        }

        // increment total visits
        var totalCount = parseInt(localStorage.getItem('counter'));
        totalCount++;
        localStorage.setItem('counter', totalCount);
        $('#totalCount').text(totalCount);

        // increment session visits
        var sessionCount = parseInt(sessionStorage.getItem('counter'));
        sessionCount++;
        sessionStorage.setItem('counter', sessionCount);
        $('#sessionCount').text(sessionCount);

        function addItemError() {
            noty({
                text: 'Text cannot be empty!',
                type: 'error',
                layout: 'topCenter',
                timeout: 1000
            });
        }
    });
}());