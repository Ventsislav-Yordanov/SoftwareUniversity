<?php
$firstNumber = 1234.5678;
$secondNumber = 333;
$sum = $firstNumber + $secondNumber;
$sum = number_format($sum, 2);

echo '$firstNumber + $secondNumber = ' , "$firstNumber + $secondNumber = " , $sum;
?>