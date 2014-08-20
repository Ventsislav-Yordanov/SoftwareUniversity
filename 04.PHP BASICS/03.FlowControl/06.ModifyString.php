<!doctype html>
<?php
    if (isset($_POST['input']) && isset($_POST['choice'])) {
        $stringValue = $_POST['input'];
        $choice = $_POST['choice'];

        if ($choice == "checkPalindrome") {
            if ($stringValue = strrev($stringValue)) {
                $result = "$stringValue is a palindrome!";
            }
            else {
                $result = "$stringValue is not a palindrome!";
            }
        }
        else if ($choice == "reverseString") {
            $result = strrev($stringValue);
        }
        else if ($choice == "split") {
            $array = str_split($stringValue);
            $result = implode($array, ' ');
        }
        else if ($choice == "hashString") {
            $result = crypt($stringValue);
        }
        else if ($choice == "shuffleString") {
            $result = str_shuffle($stringValue);
        }
    }
?>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>Modify String</title>
</head>
<body>
    <form action="" method="post">
        <input type="text" name="input"/>
        <input type="radio" name="choice" value="checkPalindrome" id="checkPalindrome"/>
        <label for="checkPalindrome">Check Palindrome</label>
        <input type="radio" name="choice" value="reverseString" id="reverseString"/>
        <label for="reverseString">Reverse String</label>
        <input type="radio" name="choice" value="split" id="split"/>
        <label for="split">Split</label>
        <input type="radio" name="choice" value="hashString" id="hashString"/>
        <label for="hashString">Hash String</label>
        <input type="radio" name="choice" value="shuffleString" id="shuffleString"/>
        <label for="shuffleString">Shuffle String</label>
        <input type="submit" value="Submit"/>
    </form>
    <div id="result">
        <?php
        if(isset($result)) {
            echo $result;
        }
        ?>
</body>
</html>