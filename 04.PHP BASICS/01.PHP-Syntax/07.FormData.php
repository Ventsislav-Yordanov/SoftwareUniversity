<!doctype html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>Form Data</title>
</head>
<body>
    <form method="post">
        <input type="text" placeholder="Name" name="name"><br />
        <input type="number" placeholder="Age" name="age"><br />
        <input type="radio" name="sex" value="male">Male<br />
        <input type="radio" name="sex" value="female">Female<br />
        <input type="submit" name="submit" value="submit">
    </form>
</body>
</html>

<?php
    if ((count($_POST) == 4)&& isset($_POST['submit'])) {
        $name = htmlentities($_POST['name']);
        $age = htmlentities($_POST['age']);
        $sex = htmlentities($_POST['sex']);

        echo "My name is $name. I am $age years old. I am $sex";
    }
?>