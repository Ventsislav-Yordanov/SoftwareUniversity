(function () {
    $form = $('#inputForm');

    if (!sessionStorage.name) {
        $name = $('#name').val();
        sessionStorage.setItem('name', $name);
    }
}());