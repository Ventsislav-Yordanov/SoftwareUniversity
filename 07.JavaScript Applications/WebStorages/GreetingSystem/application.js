(function () {
    $form = $('#inputForm');
    if ($name = $('#name').val() != "") {
        if (!sessionStorage.name) {
            $name = $('#name').val();
            sessionStorage.setItem('name', $name);
        }
    }
    
}());