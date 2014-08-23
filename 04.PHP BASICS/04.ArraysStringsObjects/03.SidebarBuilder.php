<!doctype html>
<?php
if (isset($_POST['categories']) && isset($_POST['tags']) && isset($_POST['months'])) {
    $categories = $_POST['categories'];
    $categoriesArray = explode(", " , $categories);
    $tags = $_POST['tags'];
    $tagsArray = explode(", ", $tags);
    $months = $_POST['months'];
    $monthsArray = explode(", ", $months);
}
?>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>Sidebar Builder</title>
</head>
<body>
<form action="" method="post">
    <label for="categories">Categories : </label>
    <input type="text" name="categories" id="categories"/>
    <br/>
    <label for="tags">Tags : </label>
    <input type="text" name="tags" id="tags"/>
    <br/>
    <label for="months">Months : </label>
    <input type="text" name="months" id="months"/>
    <br/>
    <input type="submit" value="Generate"/>
</form>
<div id="result">
    <?php
    if (isset($categoriesArray)) {
        echo "<div>";
        echo "<h1>Categories</h1>";
        echo "<ul>";
        foreach ($categoriesArray as $category) {
            echo "<li>$category</li>";
        }
        echo "</ul>";
        echo "</div>";
        }

    if (isset($tagsArray)) {
        echo "<div>";
        echo "<h1>Tags</h1>";
        echo "<ul>";
        foreach ($tagsArray as $tag) {
            echo "<li>$tag</li>";
        }
        echo "</ul>";
        echo "</div>";
    }

    if (isset($monthsArray)) {
        echo "<div>";
        echo "<h1>Month</h1>";
        echo "<ul>";
        foreach ($monthsArray as $month) {
            echo "<li>$month</li>";
        }
        echo "</ul>";
        echo "</div>";
    }
    ?>
</div>
</body>
</html>