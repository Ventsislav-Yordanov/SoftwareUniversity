<!doctype html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>Square Root Sum</title>
    <style>
        table , tr , td, th {
            border: 1px solid black;
        }
    </style>
</head>
<body>
    <table>
        <tr>
            <th>Number</th>
            <th>Square</th>
        </tr>
        <?php
        $squareSum = 0;
            for ($i = 0; $i <= 100; $i+= 2) {
                $square = sqrt($i);
                $square = round($square, 2);
                $squareSum += $square;
                echo "<tr>";
                echo "<td>$i</td>";
                echo "<td>$square</td>";
                echo "</tr>";
            }
        echo "<tr>";
        echo "<td>Total :</td>";
        echo "<td>$squareSum</td>";
        echo "</tr>";
        ?>
    </table>
</body>
</html>