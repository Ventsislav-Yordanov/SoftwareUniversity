<!doctype html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>HTML Tags Counter</title>
</head>
<body>
<form action="" method="post">
    <label for="tag">Enter HTML tags:</label> <br />
    <input type="text" name="tag" id="tagBox"/>
    <input type="submit" value="submit" name="submit"/>
    <div id="output"></div>
</form>
<?php
    $_SESSION['count'] = 0;
    session_start();
    $validTags = array('a', 'abbr', 'acronym', 'address', 'applet', 'area', 'b', 'base', 'basefont',
        'bdo', 'bgsound', 'big', 'blockquote', 'blink', 'body', 'br', 'button', 'caption', 'center', 'cite', 'code',
        'col', 'colgroup', 'dd', 'dfn', 'del', 'dir', 'dl', 'div', 'dt', 'embed', 'em', 'fieldset', 'font', 'form',
        'frame', 'frameset', 'h1', 'h2', 'h3', 'h4', 'h5', 'h6', 'head', 'hr', 'html', 'iframe', 'img', 'input',
        'ins', 'isindex', 'i', 'kbd', 'label', 'legend', 'li', 'link', 'marquee', 'menu', 'meta', 'noframe',
        'noscript', 'optgroup', 'option', 'ol', 'p', 'pre', 'q', 's', 'samp', 'script', 'select', 'small', 'span', 'strike',
        'strong', 'style', 'sub', 'sup', 'table', 'td', 'th', 'tr', 'tbody', 'textarea', 'tfoot', 'thead', 'title',
        'tt', 'u', 'ul', 'var');
    $message = "";
    if (isset($_POST['tag'])) {
        $tagName = $_POST['tag'];
        if (in_array($tagName , $validTags)) {
            $_SESSION['count']++;
            $message = "Valid HTML tag! <br /> Score: ". $_SESSION['count'];
        }
        else {
            $message = "Invalid HTML tag! <br /> Score: ". $_SESSION['count'];
        }
    }
    echo "$message";
?>
</body>
</html>