<?php
$month = date("F");
$year = date("Y");
$totalDays = date("t");

for ($i = 1; $i <= $totalDays; $i++) {
    $date = strtotime("$i $month $year"); // convert string to date
    if (date("l", $date) == "Sunday") { // date("l", $date) --> A full textual representation of the day of the week
        echo date("jS F, Y", $date). "<br />";
    }
}

// info : http://php.net/manual/en/function.date.php