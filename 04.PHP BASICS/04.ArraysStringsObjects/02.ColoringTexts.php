<!doctype html>
<html lang="en">
<?php
    if (isset($_POST['inputText'])) {
        $inputText = $_POST['inputText'];
        $charsArray = str_split($inputText);
        foreach ($charsArray as $char) {
            if (ord($char) % 2 == 0) {
                echo "<span class='blue'>$char </span>";
            }
            else {
                echo "<span class='red'>$char </span>";
            }
        }
    }
?>
<head>
    <meta charset="UTF-8">
    <title>Coloring Texts</title>
    <style>
        .red {
            color: red;
        }
        .blue {
            color: blue;
        }
    </style>
</head>
<body>
    <form action="" method="post">
        <form action="" method="post">
            <textarea name="inputText" id="input" cols="30" rows="10"></textarea>
            <br/>
            <input type="submit" value="Color text"/>
        </form>
        <br/>
    </form>
</body>
</html>