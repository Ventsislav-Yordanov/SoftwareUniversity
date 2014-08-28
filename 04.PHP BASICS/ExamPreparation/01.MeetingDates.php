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
    if ($firstDate > $secondDate) {
        $firstDate = $firstDate + $secondDate;
        $secondDate = $firstDate - $secondDate;
        $firstDate = $firstDate - $secondDate;
    }
    $thursDays = [];
    $AllDays = floor(($secondDate - $firstDate)/(60*60*24)) + 1;


    $currentDate = $firstDate;

    for ($i = 0; $i < $AllDays; $i++) {
        $dayOfWeek = date('N', $currentDate);
        if ($dayOfWeek == 4) {
            array_push($thursDays , date("d-m-Y", $currentDate));
        }
        $currentDate = strtotime('+1 day', $currentDate);
    }
    ;

    if (count($thursDays) > 0) {
        echo '<ol>';
        foreach ($thursDays as $thursDay) {
            echo '<li>' . $thursDay . '</li>';
        }
        echo '</ol>';
    }
    else {
        echo '<h2>No Thursdays</h2>';
    }
}
?>
</body>
</html>