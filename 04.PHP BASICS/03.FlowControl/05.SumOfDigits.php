<!doctype html>
<?php
    if (isset($_POST['input'])) {
        $input = $_POST['input'];
        $strings =  explode("," , $input);
        $resultTable = "";
        foreach ($strings as $value) {
            if (is_numeric($value)) {
                $sumOfDigits = array_sum(str_split($value));
                $resultTable.= "<tr><td>$value</td><td>$sumOfDigits</td></tr>";
            }
            else {
                $sumOfDigits = "I cannot sum that";
                $resultTable.= "<tr><td>$value</td><td>$sumOfDigits</td></tr>";
            }
        }

    }
?>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>Sum of digits</title>
</head>
<body>
    <form action="" method="post">
        <label for="input">Input String: </label>
        <input type="text" id="input" name="input"/>
        <input type="submit" value="Submit"/>
    </form>
    <table border="1px">
        <?php
        if(isset($resultTable)) {
            echo $resultTable;
        }
        ?>
    </table>
</body>
</html>