<!doctype html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>Reveal Triangles</title>
</head>
<body>
<form action="" method="post">
    <input type="text" name="inputText"/>
    <input type="submit"/>
</form>
<?php
if (isset($_POST['inputText'])) {
    $inputText = $_POST['inputText'];
    $Strings =  preg_split("/[\\s]+/", $inputText , -1 , PREG_SPLIT_NO_EMPTY);
    $matrix = [];

    for ($i = 0; $i < count($Strings); $i++) {
        $matrix[$i] = [];
        for ($j = 0; $j < strlen($Strings[$i]); $j++) {
            $matrix[$i][$j] = $Strings[$i][$j];
        }
    }
    //var_dump($matrix);

    $clone = [];
    for ($i = 0; $i < count($Strings); $i++) {
        $clone[$i] = [];
        for ($j = 0; $j < strlen($Strings[$i]); $j++) {
            $clone[$i][$j] = $Strings[$i][$j];
        }
    }

    for ($i = 0; $i < count($matrix) - 1; $i++) {
        for ($j = 1; $j < count($matrix[$i]); $j++) {
            if (isset($matrix[$i][$j]) &&
                isset($matrix[$i + 1][$j - 1]) &&
                isset($matrix[$i + 1][$j]) &&
                isset($matrix[$i + 1][$j + 1])) {

                if ($matrix[$i][$j] == $matrix[$i + 1][$j - 1] &&
                    $matrix[$i][$j] == $matrix[$i + 1][$j] &&
                    $matrix[$i][$j] == $matrix[$i + 1][$j + 1]) {
                    $clone[$i][$j] = '*';
                    $clone[$i + 1][$j - 1] = '*';
                    $clone[$i + 1][$j] = '*';
                    $clone[$i + 1][$j + 1] = '*';
                }
            }
        }
    }

    for ($i = 0; $i < count($clone); $i++) {
        for ($j = 0; $j < count($clone[$i]); $j++) {
            echo $clone[$i][$j];
        }
        echo "</br>";
    }
}

?>
</body>
</html>