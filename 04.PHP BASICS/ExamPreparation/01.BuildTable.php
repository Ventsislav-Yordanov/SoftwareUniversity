<!doctype html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>Build Table</title>
</head>
<body>
    <form action="" method="post">
        <input type="number" name="start"/>
        <input type="number" name="end"/>
        <input type="submit"/>
    </form>
    <?php
        if (isset($_POST['start']) && isset($_POST['end'])) {
            $start = (int) $_POST['start'];
            $end = (int) $_POST['end'];

            function createFibNumbers($maxNum) {
                $fibNumbers = [1];
                $f1 = 1;
                $f2 = 1;
                while (true) {
                    $f3 = $f1 + $f2;
                    if ($f3 > $maxNum) {
                        return $fibNumbers;
                    }
                    array_push($fibNumbers,$f3);
                    $f1 = $f2;
                    $f2 = $f3;
                }
            }

            $allFibNumbers = createFibNumbers($end);

            echo htmlentities("<table>");
            echo "<br>";
            echo htmlentities("<tr><th>Num</th><th>Square</th><th>Fib</th></tr>");
            echo "<br>";
            for ($i = $start; $i <= $end; $i++) {
                $sqrt = $i*$i;
                $isFib;
                if (in_array($i , $allFibNumbers)== 1) {
                    $isFib = "Yes";
                }
                else {
                    $isFib = "No";
                }
                echo htmlentities("<tr><td>$i</td><td>$sqrt</td><td>$isFib</td></tr>");
                echo "<br>";
            }
            echo htmlentities("</table>");
        }
    ?>
</body>
</html>