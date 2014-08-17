<?php
$tests = array(
    "hello",
    15,
    array(1,2,3),
    1.234,
    (object)[2,34]
);

foreach ($tests as $element) {
    if (is_numeric($element)) {
        echo var_dump($element), "\n";
    } else {
        echo gettype($element), "\n";
    }
}