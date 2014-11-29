$(document).ready(function () {
    if (localStorage.name) {
        $('form').hide();
        $('#info').text('Hello ' + localStorage.name +
            ' session visits count:' + sessionStorage.sessionVisitscount +
            ' total visits count :' + localStorage.totalVisitscount);
    }

    $('#submit').on('click', function () {
        localStorage.name = $('#name').val();
    })

    function incrementSessionCount() {
        if (sessionStorage.sessionVisitscount) {
            sessionStorage.sessionVisitscount++;
        } else {
            sessionStorage.sessionVisitscount = 1
        }
    }

    function incrementTotalCount() {
        if (localStorage.totalVisitscount) {
            localStorage.totalVisitscount++;
        } else {
            localStorage.totalVisitscount = 1
        }
    }

    incrementTotalCount();
    incrementSessionCount();
})
    
    