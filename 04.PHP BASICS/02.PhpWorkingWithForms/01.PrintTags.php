<!doctype html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>Print Tags</title>
</head>
<body>
<form method="get" action="">
    <p>Enter tags:</p>
    <input type="text" name="tags" required="true">
    <input type="submit" value="submit" name="submit"/>
</form>
<?php
if (isset($_GET['tags'])) {
    $tagsStr = ($_GET['tags']);
    $tags = explode(", ",  $tagsStr);
   for ($i = 0; $i < sizeof($tags); $i++) {
       echo "$i : $tags[$i] <br / >";
   }
}
?>
</body>
</html>