<!doctype html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>Meeting Dates</title>
    <style>
        body {
            font-family: tahoma;
        }
    </style>
</head>
<body>
<form action="" method="get">
    <input type="text" name="dateOne" value="31-12-2014"/>
    <input type="text" name="dateTwo" value="01-01-2014"/>
    <input type="submit" value="Submit"/>
</form>
<?php
if (isset($_GET['dateOne']) && isset($_GET['dateTwo'])) {
    date_default_timezone_set('Europe/Sofia');
    $firstDate = strtotime($_GET['dateOne']);
    $secondDate = strtotime($_GET['dateTwo']);
    $thursDays = [];

    if ($firstDate < $secondDate) {
        $currentDate = $firstDate;
        while ($currentDate <= $secondDate) {
            $dayOfWeek = date("N", $currentDate);
            if ($dayOfWeek == 4) {
                array_push($thursDays, $currentDate);
                $currentDate = strtotime("+7 days" , $currentDate);
            }
            else {
                $currentDate = strtotime("+1 day" , $currentDate);
            }
        }
    } else if ($secondDate < $firstDate) {
        $currentDate = $secondDate;
        while ($currentDate <= $firstDate) {
            $dayOfWeek = date("N" , $currentDate);
            if ($dayOfWeek == 4) {
                array_push($thursDays, $currentDate);
                $currentDate = strtotime("+7 days" , $currentDate);
            }
            else {
                $currentDate = strtotime("+1 day" , $currentDate);
            }
        }
    }
    if (count($thursDays) == 0) {
        echo "<h2>No Thursdays</h2>";
    } else {
        echo "<ol>";
        for($i = 0; $i < count($thursDays); $i++) {
            $thursday = date("d-m-Y", $thursDays[$i]);
            echo "<li>$thursday</li>";
        }
        echo "</ol>";
    }
}
?>
</body>
</html>