<?php
if (isset($_GET['text']) && isset($_GET['hashValue']) && isset($_GET['fontSize']) && isset($_GET['fontStyle'])) {
    $text = $_GET['text'];
    $hashValue = $_GET['hashValue'];
    $fontSize = $_GET['fontSize'];
    $fontStyle = $_GET['fontStyle'];

    for ($i = 0; $i < strlen($text); $i++) {
        if ($i % 2 == 0) {
            $text[$i] = chr(ord($text[$i]) + $hashValue);
        }
        else {
            $text[$i] = chr(ord($text[$i]) - $hashValue);
        }
    }

    $result = '<p style="font-size:'.$fontSize . ';';
    if ($fontStyle == "bold") {
        $result .= 'font-weight:'.$fontStyle . ';">';
    }
    else {
        $result .= 'font-style:'.$fontStyle . ';">';
    }
    $result .= $text;
    $result .= '</p>';

    echo $result;
}