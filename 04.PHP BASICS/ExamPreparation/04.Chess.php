<!DOCTYPE html>
<html>
<head>
    <title></title>
    <style>
        label, textarea, input {
            display: block;
        }
        input[type="text"] {
            width: 700px;
        }
    </style>
</head>
<body>
<form method="get" action="">
    <label>Board:</label>
    <input type="text" name="board" value="R-H-B-K-Q-B-H-R/P-P- -P-P- -P-P/ - -P- - - - - / - - - - -P- - / - - - - - - - / -P- - - - - -H/P- -P-P-P-P-P-P/R-H-B-K-Q-B- -R"/>
    <input type="submit"/>
</form>
<?php
$stringBoard = $_GET['board'];
$rows = explode("/", $stringBoard);
//var_dump($rows);

$isValid = isValidChessboard($rows);
if (!$isValid) {
    echo "<h1>Invalid chess board</h1>";
    return;
}

$figures = [];

    echo "<table>";
    for ($i = 0; $i < count($rows); $i++) {
        echo "<tr>";
        $currentRow = explode("-", $rows[$i]);
        for ($j = 0; $j < count($currentRow); $j++) {
            echo "<td>" . $currentRow[$j] . "</td>";
            if ($currentRow[$j] === 'B') {
                if (isset($figures['Bishop'])) {
                    $figures['Bishop']++;
                }
                else {
                    $figures['Bishop'] = 1;
                }
            }
            else if ($currentRow[$j] === 'H') {
                if (isset($figures['Horseman'])) {
                    $figures['Horseman']++;
                }
                else {
                    $figures['Horseman'] = 1;
                }
            }
            else if ($currentRow[$j] === 'K') {
                if (isset($figures['King'])) {
                    $figures['King']++;
                }
                else {
                    $figures['King'] = 1;
                }
            }
            else if ($currentRow[$j] === 'Q') {
                if (isset($figures['Queen'])) {
                    $figures['Queen']++;
                }
                else {
                    $figures['Queen'] = 1;
                }
            }
            else if ($currentRow[$j] === 'P') {
                if (isset($figures['Pawn'])) {
                    $figures['Pawn']++;
                }
                else {
                    $figures['Pawn'] = 1;
                }
            }
            else if ($currentRow[$j] === 'R') {
                if (isset($figures['Rook'])) {
                    $figures['Rook']++;
                }
                else {
                    $figures['Rook'] = 1;
                }
            }
        }
        echo '</tr>';
    }
    echo '</table>';
    ksort($figures);
    echo json_encode($figures);



function isValidChessboard($lines) {
    // check if rows == 8
    if (count($lines) != 8) {
        return false;
    }
    foreach ($lines as $line) {
        // check if each row has length 15 ( all "-" + pieces)
        if (strlen($line) != 15) {
            return false;
        }
        // check if all letters are valid pieces (excluding "-" on odd positions)
        for ($i = 0; $i < strlen($line); $i += 2) {
            if (!isPieceOrEmpty($line[$i])) {
                return false;
            }
        }
    }
    return true;
}

function isPieceOrEmpty($letter) {
    return $letter == "R" || $letter == "B" || $letter == "H" ||
    $letter == "Q" || $letter == "K" || $letter == "P" || $letter == " ";
}
?>
</body>
</html>