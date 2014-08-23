<!doctype html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>URL Replacer</title>
</head>
<body>
    <form action="" method="post">
        <label for="text">Text :</label> <br/>
        <textarea name="text" id="text" cols="30" rows="10"></textarea> <br/>
        <input type="submit" value="Replace URL's"/>
    </form>
    <?php
        if (isset($_POST['text'])) {
            $text = $_POST['text'];
            $text = str_replace('</a>', '[/URL]' , $text);
            $text = preg_replace('/<a href="(.*?)">/', '[URL=\1]', $text);
            echo htmlentities($text);
        }
    ?>
</body>
</html>