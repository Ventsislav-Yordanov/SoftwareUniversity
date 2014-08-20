<!doctype html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>Most Frequent Tag</title>
</head>
<body>
<form method="post" action="">
    <p>Enter tags:</p>
    <input type="text" name="tags" required="true">
    <input type="submit" value="submit" name="submit"/>
</form>
<?php
if (isset($_GET['tags'])) {
    $tags = explode(", ", $_POST['tags']); // Сплитва масива по запетайка и разстояние
    $tagsCountValues = array_count_values($tags); // обхожда масива и връща всяка една стойност колко пъти я има (връща друг масив)
    $maxValue = array_search(max($tagsCountValues), $tagsCountValues); // намираме макса на масива
    arsort($tagsCountValues); // сортираме го по стойност
    foreach ($tagsCountValues as $key => $value) {
        echo "$key : $value times <br>"; // след това го принтим в този ред
    }
    if (true) {
        // some code here
    }
    echo "<p>Most Frequent Tag is: $maxValue </p>"; // и изкарваме този таг, който е с най-много повторения
}
?>
</body>
</html>