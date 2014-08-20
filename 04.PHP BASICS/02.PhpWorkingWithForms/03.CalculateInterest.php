<!doctype html>
<?php
if (isset($_GET['amount']) && isset($_GET['currency']) &&
    isset($_GET['CompoundInterestAmount']) && isset($_GET['period'])) {
    $moneyAmount = $_GET['amount'];
    $currency = $_GET['currency'];
    $interest = $_GET['CompoundInterestAmount'];
    $period = $_GET['period'];

    if ($period == '6Months') {
        $period = 6;
    }
    else if ($period == '1Year') {
        $period = 12;
    }
    else if ($period == '2Year') {
        $period = 24;
    }
    else {
        $period = 60;
    }

    $result = round($moneyAmount * pow(1 +(($interest / 100) / 12), $period / 12 * 12), 2);

    if ($currency == 'USD') {
        $result = '$ ' . $result;
    }
    else if (true) {
        $result = '&#8364; ' . $result;
    }
    else {
        $result = $result . ' Lv';
    }
}
?>

<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>Calculate Interest</title>
</head>
<body>
<form action="" method="get">
    <label for="amount">Enter Amount : </label>
    <input type="number" name="amount" id="amount"/> <br />
    <input type="radio" id="USD" name="currency"  value="usd"/>
    <label for="USD">USD</label>
    <input type="radio" id="EUR" name="currency"  value="usd"/>
    <label for="EUR">EUR</label>
    <input type="radio" id="BGN" name="currency"  value="usd"/>
    <label for="BGN">BGN</label> <br />
    <label for="CompoundInterestAmount">Compound Interest Amount </label>
    <input type="number" name="CompoundInterestAmount" id="CompoundInterestAmount"/>  <br />
    <select name="period" id="duration">
        <option value="6Months">6 Months</option>
        <option value="1Year">1 Year</option>
        <option value="2Year">2 Years</option>
        <option value="5Years">5 Years</option>
    </select>
    <input type="submit" value="Calculate"/>
</form>
<?php
    if (isset($result)) {
        echo htmlentities($result);
    }
?>
</body>
</html>