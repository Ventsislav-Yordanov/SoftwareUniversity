<!doctype html>
<?php
    if (isset($_POST['inputText'])) {
        $inputString = strtolower($_POST['inputText']); // The search should be case-insensitive.
        $pattern  = "/\\W+/"; // original pattern : /\W+/g
        $words = preg_split($pattern , $inputString , -1, PREG_SPLIT_NO_EMPTY);
        $wordMap = [];
        foreach ($words as $word) {
            if (isset($wordMap[$word])) {
                $wordMap[$word]++;
            }
            else {
                $wordMap[$word] = 1;
            }
        }
        arsort($wordMap); // sorting
?>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>Word Mapping</title>
</head>
<body>
    <form action="" method="post">
        <textarea name="inputText" id="input" cols="30" rows="10"></textarea>
        <br/>
        <input type="submit" value="Count words"/>
    </form>
    <br/>
    <table border="1px">
        <?php foreach ($wordMap as $word => $count) { ?>
        <tr>
            <td><?=$word?></td>
            <td><?=$count?></td>
        </tr>
        <?php }; ?>
    </table>
    <?php }; ?>
</body>
</html>