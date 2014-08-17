<html>
<head>
    <title>Numbers</title>
</head>
<body>
<form method="post">
    Enter n here: <input type="number" name="n">
    <input type="submit" name="submit" value="submit">
</form>
</body>
</html>

<?php
if($_POST)
{
    $n = $_POST['n'];
    $count = 0;

    for ($i = 1; $i <= 9; $i++) {
        for ($j = 0; $j <= 9; $j++) {
            for ($k = 0; $k <= 9; $k++) {

                $numStr = $i.$j.$k;
                $number = (int)$numStr;
                if ($number > $n) {
                    break;
                }

                $firstDigit = floor($number / 100);
                $secondDigit = floor(($number / 10)% 10);
                $thirdDigit  = floor($number % 10);

                if ($firstDigit != $secondDigit && $firstDigit != $thirdDigit) {
                    if ($secondDigit != $thirdDigit) {
                        echo $firstDigit;
                        echo $secondDigit;
                        echo $thirdDigit;
                        echo " ";
                        $count++;
                    }
                }
            }
        }
    }
    if ($count == 0) {
        echo "no";
    }
}
?>