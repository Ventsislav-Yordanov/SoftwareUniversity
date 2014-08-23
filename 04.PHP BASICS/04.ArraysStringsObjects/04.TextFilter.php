<!doctype html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>Text Filter</title>
</head>
<body>
    <form action="" method="post">
        <label for="input">Text : </label>
        <br/>
        <textarea name="inputText" id="input" cols="23" rows="10"></textarea>
        <br/>
        <label for="banList">banList : </label>
        <input type="text" name="bannedWords" id="banList"/>
        <br/>
    </form>
    <?php
        if (isset($_POST['inputText']) && isset($_POST['bannedWords'])) {
            $text = $_POST['inputText'];
            $bannedWords = explode(", ", $_POST['bannedWords']);
            foreach ($bannedWords as $bannedWord) {
                $text = str_replace($bannedWord , str_repeat('*' , strlen($bannedWord)), $text);
            }
            echo "<p>$text</p>";
        }
    ?>
</body>
</html>