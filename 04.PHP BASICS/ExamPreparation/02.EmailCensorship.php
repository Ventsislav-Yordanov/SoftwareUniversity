<!DOCTYPE html>
<html>
<head>
    <title></title>
    <style>
        label, textarea, input {
            display: block;
        }
        textarea {
            width: 300px;
            height: 200px;
        }
    </style>
</head>
<body>
<form method="get" action="">
    <label>Text:</label>
    <textarea name="text">Hi, I'm an air-conditioner technician, so if you need any assistance you can contact me at air-conditioners@gmail.com .
        Secondary email: kinky_technician@yahoo.in or at naked-screwdriver@abv.bg OR pesho@dir.tk</textarea>
    <label>Blacklist:</label>
    <textarea name="blacklist">*.bg
        pesho@dir.tk
        *.com</textarea>
    <input type="submit" />
</form>
<?php
function getReplacement($match , $blacklist) {
    preg_match("/(\\..*)/" , $match , $domain); // get domain from current match
    $dom = "*" . $domain[0]; // get domain with * before it
    if (in_array($dom, $blacklist) || in_array($match , $blacklist)) {
        return str_pad('', strlen($match), '*'); // encode domain/match from blacklist
    }
    else {
        return "<a href=\"mailto:" . $match . "\">$match</a>";
    }
}
    if (isset($_GET['text']) && isset($_GET['blacklist'])) {
        $textArea = $_GET['text'];
        $bl = $_GET['blacklist']; // get value from text area with name "blacklist"
        //var_dump($bl) . "</br>";
        $blacklist = preg_split("/\\s/", $bl, -1, PREG_SPLIT_NO_EMPTY); // split value from $bl by empty spaces , this return array of blacklist values
        //var_dump($blacklist) . "</br>" ;
        $pattern = "/[a-zA-Z0-9_+-]+@[a-zA-Z0-9-]+\\.[a-zA-Z0-9-.]+/"; // pattern for valid e-mails
        preg_match_all($pattern, $textArea, $matches); // save the emails in variable $matches by $pattern.
        //var_dump($matches) . "</br>";
        foreach ($matches[0] as $match) {
            $replacement = getReplacement($match , $blacklist); // get replacement
            $textArea = str_replace($match, $replacement, $textArea); // replace current replacement in textArea
        }
        echo "<p>$textArea</p>";
    }
?>
</body>
</html>