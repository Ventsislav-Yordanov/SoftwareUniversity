<!doctype html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>Sentence Extractor</title>
</head>
<body>
    <form action="" method="post">
        <label for="input">Text : </label>
        <br/>
        <textarea name="inputText" id="input" cols="23" rows="10"></textarea>
        <br/>
        <label for="banList">word : </label>
        <input type="text" name="word" id="word"/>
        <br/>
    </form>
    <?php
        if (isset($_POST['inputText']) && isset($_POST['word'])) {
            $text = $_POST['inputText'];
            $word = $_POST['word'];

            $sentence = "";
            $arraySentence = [];

            for ($i = 0; $i < strlen($text); $i++) {
                if ($text[$i] == "." || $text[$i] == "?" || $text[$i] == "!") {
                    $sentence .= $text[$i];
                    $arraySentence = preg_split("/([^a-zA-Z])/", $sentence , -1 , PREG_SPLIT_NO_EMPTY);
                    if (in_array($word ,$arraySentence)) {
                        echo "$sentence </br>";
                    }
                    $sentence = "";
                }
                else {
                    $sentence .= $text[$i];
                }
            }
        }
    ?>
</body>
</html>