<!doctype html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>Concerts</title>
</head>
<body>
    <form action="" method="post">
        <input type="text" name="inputText"/>
        <input type="submit"/>
    </form>
    <?php
        if (isset($_POST['inputText'])) {
            $inputText = $_POST['inputText'];
            $strings = preg_split("/Stadium/" , $inputText , -1 , PREG_SPLIT_NO_EMPTY);
            //var_dump($strings);

            $concertInfo = [];

            for ($i = 0; $i < count($strings); $i++) {
                $currentStringWords = explode(" | ", $strings[$i]);
                $band = $currentStringWords[0];
                $town = $currentStringWords[1];
                $date = $currentStringWords[2];
                $stadium = $currentStringWords[3] . "stadium";

                for ($j = 0; $j < count($currentStringWords); $j++) {
                    if (isset($concertInfo[$town])) {
                        if (isset($concertInfo[$town][$stadium])) {
                            if (in_array($band, $concertInfo[$town][$stadium])) {
                                continue;
                            }
                            else {
                                array_push($concertInfo[$town][$stadium], $band);
                            }
                        }
                        else {
                            $concertInfo[$town][$stadium] = [];
                            array_push($concertInfo[$town][$stadium], $band);
                        }
                    }
                    else {
                        $concertInfo[$town] = [];
                        $concertInfo[$town][$stadium] = [];
                        array_push($concertInfo[$town][$stadium], $band);
                    }
                }
            }
            // sort all arrays
            ksort($concertInfo);
            foreach ($concertInfo as $key => $value) {
                ksort($concertInfo[$key]);
                foreach ($concertInfo[$key] as $inner => $value) {
                    sort($concertInfo[$key][$inner]);
                }

            }
            echo json_encode($concertInfo);
        }
    ?>
</body>
</html>