<!doctype html>
<?php
if (isset($_POST['carsInput'])) {
    $cars = explode("," , $_POST['carsInput']);
    $Colors = array('aqua', 'black', 'blue', 'fuchsia', 'gray', 'green', 'lime', 'maroon', 'navy',
        'olive', 'orange', 'purple', 'red', 'silver', 'teal', 'white', 'yellow' , 'DarkSlateBlue', 'Fuchsia ',
        'Indigo', 'Navy ');

    $resultTable = "";

    for ($i = 0; $i < count($cars); $i++) {
        $randomColor = $Colors[rand(0,count($Colors) - 1)];//
        $randomCount = rand(1,10);
        $resultTable .= "<tr><td>{$cars[$i]}</td><td>{$randomColor}</td><td>{$randomCount}</td></tr>";
    }
}
?>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>Rich People</title>
</head>
<body>
<form method="post">
    <label for="cars">Enter cars : </label>
    <input type="text" id="cars" name="carsInput"/>
    <input type="submit" value="Show result"/>
    <br/>
    <table border="1">
        <thead>
            <tr>
                <th>Car</th>
                <th>Color</th>
                <th>Count</th>
            </tr>
        </thead>
        <tbody>
        <?php
            if(isset($resultTable)) {
                echo $resultTable;
            }
        ?>
        </tbody>
    </table>
</form>
</body>
</html>