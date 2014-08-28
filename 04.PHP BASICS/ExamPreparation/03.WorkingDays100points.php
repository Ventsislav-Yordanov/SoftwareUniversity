<?php
date_default_timezone_set("Europe/Sofia");

$start = $_GET['dateOne'];
$end = $_GET['dateTwo'];
$holidays = $_GET['holidays'];

$holidayArray = explode(PHP_EOL, $holidays);


function isWeekend($day) {
    $formatDay = date('w', strtotime($day));
    return ($formatDay == 0 || $formatDay == 6);
}
$result = '<ol>';
while(strtotime($start) <= strtotime($end)) {
    if(!isWeekend($start) && !in_array($start, $holidayArray)) {
        $result .= '<li>' . $start . '</li>';
    }
    $start = date("d-m-Y", strtotime("+ 1 day", strtotime($start)));
}
$result .= '</ol>';

if(strlen($result) == 9) {
    echo "<h2>No workdays</h2>";
}
else {
    echo $result;
}