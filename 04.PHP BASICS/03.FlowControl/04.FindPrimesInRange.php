<!doctype html>
<?php
    if (isset($_POST['startIndex']) && isset($_POST['endIndex'])) {
        function isPrime($n) // http://www.stoimen.com/blog/2012/05/08/computer-algorithms-determine-if-a-number-is-prime/
        {
            $i = 2;
            if ($n == 2) {
                return true;
            }

            $sqrtN = sqrt($n);
            while ($i <= $sqrtN) {
                if ($n % $i == 0) {
                    return false;
                }
                $i++;
            }
            return true;
        }

        $start = $_POST['startIndex'];
        $end = $_POST['endIndex'];
        $numbers = array();

        for ($i = $start; $i <= $end ; $i++) {
            if (isPrime($i)) {
                $numbers[] = "<span class='prime'>{$i}</span>";
            }
            else {
                $numbers[] = "<span>{$i}</span>";
            }
        }
        $result = implode("," , $numbers);
    }
?>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>Primes in range</title>
    <style>
        body {
            font-family: tahoma;
        }
        span.prime {
            font-weight: bold;
            color: dodgerblue;
        }
    </style>
</head>
<body>
    <form action="" method="post">
        <label for="start">Starting Index: </label>
        <input type="number" id="start" name="startIndex"/>
        <label for="end">End: </label>
        <input type="number" id="end" name="endIndex"/>
        <input type="submit" value="Submit"/>
    </form>
    <div id="result">
        <?php
        if(isset($result)) {
            echo $result;
        }
        ?>
    </div>
</body>
</html>