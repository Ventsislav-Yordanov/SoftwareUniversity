<!doctype html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>String Matrix Rotation</title>
</head>
<body>
<form action="" method="get">
    <textarea name="input" id="input" cols="30" rows="10"></textarea>
    <br/>
    <input type="submit"/>
</form>
<?php
if (isset($_GET['input'])) {
    $input = $_GET['input'];
    $keywords = preg_split("/[\\s]+/", $input , -1 , PREG_SPLIT_NO_EMPTY);
    $rotation = $keywords[0]; // get rotation
    unset($keywords[0]); // remove rotation from keywords
    $keywords = array_values($keywords);
    var_dump($keywords);

    $matrix = [];

    for ($i = 0; $i < count($keywords); $i++) {
        for ($j = 0; $j < strlen($keywords[$i]); $j++) {
            $matrix[$i][$j] = $keywords[$i][$j];
        }
    }

    $maxLength = max(array_map('strlen', $keywords));
    for ($k = 0; $k < count($keywords); $k++) {
        for ($n = 0; $n < $maxLength; $n++) {
            if (isset($matrix[$k][$n])) {
                continue;
            }
            else {
                $matrix[$k][$n] = " ";
            }
        }
    }

    $rows = count($matrix);
    $cols = count($matrix[0]);
    $result = [];

    for ($a = 0; $a < $cols; $a++) {
        $result[$a] = [];
        for ($b = 0; $b < $rows; $b++) {
            $result[$a][$rows - $b] = $matrix[$b][$a];
        }
    }
    // TO DO <----------------------------------------------------------------------------------------------------------
    var_dump($result);
}
?>
</body>
</html>