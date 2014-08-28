<!doctype html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>Double Rakiya Numbers</title>
</head>
<body>
    <form action="" method="get">
        <input type="number" name="number1" value="5"/>
        <input type="number" name="number2" value="8"/>
        <input type="submit" value="Submit"/>
    </form>
    <?php
        function isRakiyaNumber($numberString) {
            for ($i = 0; $i < strlen($numberString) - 1; $i++) {
                $couple = $numberString[$i] . $numberString[$i + 1];

                for ($j = $i + 2; $j < strlen($numberString) - 1; $j++) {
                    $secondCouple = $numberString[$j] . $numberString[$j + 1];

                    if ($couple == $secondCouple) {
                        return true;
                    }
                }
            }
            return false;
        }
        if (isset($_GET['number1']) && isset($_GET['number2'])) {
            $number1 = (int) $_GET['number1'];
            $number2 = (int) $_GET['number2'];

            echo htmlentities("<ul>");
            echo "</br>";
            for ($i = $number1; $i <= $number2; $i++) {
                if (isRakiyaNumber((string)$i)) {
                    echo htmlentities('<li>' . '<span class="rakiya">' . $i . '</span>' . '<a href="view.php?id='. $i . '">View</a>' . '</li>' );
                    echo "</br>";
                }
                else {
                    echo htmlentities('<li>' . '<span class="num">' . $i . '</span>' . '</li>' );
                    echo "<br>";
                }
            }
            echo htmlentities('</ul>');
        }
    ?>
</body>
</html>