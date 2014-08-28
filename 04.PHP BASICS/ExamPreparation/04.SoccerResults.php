<?php
$input = ["Germany / Argentina: 1-0",
    "Brazil / Netherlands: 0-3",
    "Netherlands / Argentina: 0-0",
    "Brazil / Germany: 1-7",
    "Argentina / Belgium: 1-0",
    "Netherlands / Costa Rica: 0-0",
    "France / Germany: 0-1",
    "Brazil / Colombia: 2-1"];

$results = [];

foreach ($input as $match) {
    $match = preg_split("/[^a-zA-Z0-9 ]/", $match, -1, PREG_SPLIT_NO_EMPTY);
    $firstTeam = trim($match[0]);
    $secondTeam = trim($match[1]);
    $firstTeamGoals = $match[2];
    $secondTeamGoals = $match[3];

    // first team
    if (isset($results[$firstTeam])) {
        $results[$firstTeam]["goalsScored"] += (int) $firstTeamGoals;
        $results[$firstTeam]["goalsConceded"] += (int) $secondTeamGoals;
        array_push($results[$firstTeam]["matchesPlayedWith"] , $secondTeam);
        //$results[$firstTeam]["matchesPlayedWith"] .= ", " . $secondTeam ;
    }
    else {
        $results[$firstTeam]["goalsScored"] = (int) $firstTeamGoals;
        $results[$firstTeam]["goalsConceded"] = (int) $secondTeamGoals;
        $results[$firstTeam]["matchesPlayedWith"] = [] ;
        array_push($results[$firstTeam]["matchesPlayedWith"] , $secondTeam);
    }

    //second team
    if (isset($results[$secondTeam])) {
        $results[$secondTeam]["goalsScored"] += (int) $secondTeamGoals;
        $results[$secondTeam]["goalsConceded"] += (int) $firstTeamGoals;
        array_push($results[$secondTeam]["matchesPlayedWith"] , $firstTeam);
        //$results[$secondTeam]["matchesPlayedWith"] .=  ", " . $firstTeam;
    }
    else {
        $results[$secondTeam]["goalsScored"] = (int) $secondTeamGoals;
        $results[$secondTeam]["goalsConceded"] = (int) $firstTeamGoals;
        $results[$secondTeam]["matchesPlayedWith"] = [] ;
        array_push($results[$secondTeam]["matchesPlayedWith"] , $firstTeam);
    }
}
ksort($results);
//var_dump($results);

foreach ($results as $match => $value) {
    //echo json_encode($match) . json_encode($value) . "<br>";
    array_multisort($results[$match]['matchesPlayedWith']);
}

foreach ($results as $match => $value) {
    echo json_encode($match) . json_encode($value) . "<br>";
}
