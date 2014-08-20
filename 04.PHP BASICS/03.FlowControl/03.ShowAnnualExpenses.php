<!doctype html>
<?php
    if (isset($_POST['years'])) {
        $years = $_POST['years'];
        $currentYear = date("Y");

        $result = '';

        for ($i = 0; $i < $years; $i++) {
            $ExpensesJanuary = rand(0, 999);
            $ExpensesFebruary = rand(0, 999);
            $ExpensesMarch = rand(0, 999);
            $ExpensesApril = rand(0, 999);
            $ExpensesMay = rand(0, 999);
            $ExpensesJune = rand(0, 999);
            $ExpensesJuly = rand(0, 999);
            $ExpensesAugust = rand(0, 999);
            $ExpensesSeptember = rand(0, 999);
            $ExpensesOctober = rand(0, 999);
            $ExpensesNovember = rand(0, 999);
            $ExpensesDecember = rand(0, 999);

            $sumForYear = $ExpensesJanuary +  $ExpensesFebruary + $ExpensesMarch  +
            $ExpensesApril + $ExpensesMay  + $ExpensesJune + $ExpensesJuly + $ExpensesAugust +
            $ExpensesSeptember + $ExpensesOctober + $ExpensesNovember + $ExpensesDecember;

            $result .= "<tr><td>$currentYear</td>" .
                "<td>$ExpensesJanuary</td><td>$ExpensesFebruary</td>" .
                "<td>$ExpensesMarch</td><td>$ExpensesApril</td>" .
                "<td>$ExpensesMay</td><td>$ExpensesJune</td>" .
                "<td>$ExpensesJuly</td><td>$ExpensesAugust</td>" .
                "<td>$ExpensesSeptember</td><td>$ExpensesOctober</td>" .
                "<td>$ExpensesNovember</td><td>$ExpensesDecember</td>" .
                "<td>$sumForYear</td></tr>";
            $currentYear--;
        }
    }
?>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>Annual Expenses</title>
</head>
<body>
    <form action="" method="post">
        <label for="years">Enter number of years : </label>
        <input type="text" id="years" name="years"/>
        <input type="submit" value="Show costs"/>
    </form>
    <br/>
    <table border="1px">
        <thead>
            <tr>
                <th>Year</th>
                <th>January</th>
                <th>February</th>
                <th>March</th>
                <th>April</th>
                <th>May</th>
                <th>June</th>
                <th>July</th>
                <th>August</th>
                <th>September</th>
                <th>October</th>
                <th>November</th>
                <th>December</th>
                <th>Total:</th>
            </tr>
        </thead>
        <tbody>
        <?php
            if (isset($result)) {
                echo "$result";
            }
        ?>
        </tbody>
    </table>
</body>
</html>