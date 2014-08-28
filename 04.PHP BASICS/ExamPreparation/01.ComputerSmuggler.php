<!doctype html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>Computer Smuggler</title>
</head>
<body>
    <form action="" method="get">
        <input type="text" name="list" value="CPU, RAM, VIA, ROM, RAM, RAM, CPU, CPU, CPU, VIA, ROM, ROM, CPU"/>
        <input type="submit"/>
    </form>
    <?php
    $list = $_GET['list'];
    $arr = explode(", ", $list);

    $parts = [];
    foreach ($arr as $key => $value) {
        if (isset($parts[$value]) ) {
            $parts[$value]++;
        }
        else {
            $parts[$value] = 1;
        }
    }
    $totalSum = 0;

    //get money Nakov has paid for the parts
    foreach ($parts as $key => $value) {
        if ($key === 'CPU') {
            if ($value >= 5) {
                $totalSum += ($value * 85) / 2;
            }
            else {
                $totalSum += $value * 85;
            }
        }
        elseif ($key === 'RAM') {
            if ($value >= 5) {
                $totalSum += ($value * 35) / 2;
            }
            else {
                $totalSum += $value * 35;
            }

        }
        elseif ($key === 'ROM') {
            if ($value >= 5) {
                $totalSum += ($value * 45) / 2;
            }
            else {
                $totalSum += $value * 45;
            }

        }
        elseif ($key === 'VIA') {
            if ($value >= 5) {
                $totalSum += ($value * 45) / 2;
            }
            else {
                $totalSum += $value * 45;
            }

        }
    }
    $comCount = 0;
    while ($parts['CPU'] > 0 && $parts['RAM'] > 0 &&
        $parts['ROM'] > 0 && $parts['VIA'] > 0) {
        $comCount++;
        $parts['CPU']--;
        $parts['RAM']--;
        $parts['ROM']--;
        $parts['VIA']--;
    }
    $partsLeft = 0;
    $sellRestTotal = 0;
    foreach ($parts as $key => $value) {
        if ($key === 'CPU') {
            $sellRestTotal += $value * 85/2;
            $partsLeft += $value;
        }
        elseif ($key === 'RAM') {
            $sellRestTotal += $value * 35/2;
            $partsLeft += $value;

        }
        elseif ($key === 'ROM') {
            $sellRestTotal += $value * 45/2;
            $partsLeft += $value;

        }
        if ($key === 'VIA') {
            $sellRestTotal += $value * 45/2;
            $partsLeft += $value;

        }
    }
    $profit = ((420 * $comCount) + $sellRestTotal) - $totalSum;

    echo "<ul>";
    echo "<li>$comCount computers assembled</li>";
    echo "<li>$partsLeft parts left</li>";
    echo "</ul>";
    if ($profit > 0) {
        echo "<p>Nakov gained $profit leva</p>";
    }
    else {
        echo "<p>Nakov lost $profit leva</p>";

    }
    ?>
</body>
</html>