<!DOCTYPE html>
<html>
<head>
    <title></title>
    <style>
        label, textarea, input {
            display: block;
        }
        textarea {
            height: 200px;
        }
    </style>
</head>
<body>
<form method="get" action="">
    <label>Start date:</label>
    <input type="text" name="dateOne" value="17-12-2014"/>
    <label>End date:</label>
    <input type="text" name="dateTwo" value="31-12-2014"/>
    <label>Holidays:</label>
    <textarea name="holidays">31-12-2014
        24-12-2014
        08-12-2014</textarea>
    <input type="submit" />
</form>
<?php
if (isset($_GET['dateOne']) && isset($_GET['dateTwo']) && isset($_GET['holidays'])) {
    date_default_timezone_set('Europe/Sofia');
    $dateOne = strtotime($_GET['dateOne']);
    $dateTwo = strtotime($_GET['dateTwo']);
    $holidaysString = $_GET['holidays'];
    $holidays = preg_split("/\\s+/", $holidaysString, -1, PREG_SPLIT_NO_EMPTY);
    //var_dump($holidays);

    $AllDays = floor(($dateTwo - $dateOne)/(60*60*24));
    $AllDays += 1; // including last date
    //echo $AllDays;

    $workDays = [];
    $currentDate = $dateOne;
    //echo $currentDate;

    for ($i = 0; $i < $AllDays; $i++) {
        $dayOfWeek = date('N',$currentDate);
        if (($dayOfWeek > 5) || in_array(date("d-m-Y", $currentDate), $holidays)) {
            $currentDate = strtotime('+1 day', $currentDate);
        }
        else {
            $workDays[] = $currentDate;
            $currentDate = strtotime('+1 day', $currentDate);
        }
    }

    if (count($workDays) == 0) {
        echo "<h2>No workdays</h2>";
    }
    else {
        echo "<ol>";
        for ($i = 0; $i < count($workDays); $i++) {
            $date = date("d-m-Y", $workDays[$i]);
            echo "<li>$date</li>";
        }
        echo "</ol>";
    }
}
?>
</body>
</html>