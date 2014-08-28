<!doctype html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>PIN Validation</title>
</head>
<body>
    <form action="" method="get">
        <input type="text" name="name" value="Ana Ivanova"/>
        <input type="text" name="gender" value="female"/>
        <input type="text" name="pin" value="9912164756"/>
        <input type="submit"/>
    </form>
    <?php
        if (isset($_GET['name']) && isset($_GET['gender']) && isset($_GET['pin'])) {
            $name = $_GET['name'];
            $gender = $_GET['gender'];
            $pin = $_GET['pin'];
            $isValidNamePin = true;

            $namePattern = "/[A-Z][a-z]+\\s[A-Z][a-z]+/";
            preg_match($namePattern, $name, $nameMatch);
            //var_dump($nameMatch);
            $pinPattern = "/[0-9]{10}/";
            preg_match($pinPattern, $pin , $pinMatch);
            //var_dump($pinMatch);

            if (empty($nameMatch) || empty($pinMatch)) {
                $isValidNamePin = false;
            }

            $result = [];
            if (isCorrectDate($pin) && isCorrectGender($gender, $pin) && isCorrectChecksum($pin) && $isValidNamePin) {
                $result['name'] = $name;
                $result['gender'] = $gender;
                $result['pin'] = $pin;
                echo json_encode($result);
            }
            else {
                echo "<h2>Incorrect data</h2>";
            }
        }
    function isCorrectDate($pin) {
        $date = substr($pin, 0, 6);
        $year = intval(substr($date, 0, 2));
        $month = intval(substr($date, 2, 2));
        $day = intval(substr($date, 4, 2));

        if ($month > 20 && $month <= 32) {
            $month -= 20;
        }else if ($month > 40 && $month <= 52) {
            $month -= 40;
        }

        if (checkdate($month, $day , $year)) {
            return true;
        }
        return false;
    }

    function isCorrectGender($gender, $pin) {
        $genderDigit = substr($pin, -2, 1);
        if ($genderDigit % 2 == 0 && $gender == "male") { // if genderDigit is even and gender == male
            return true;
        }else if ($genderDigit % 2 == 1 && $gender == "female") { // if genderDigit is odd and gender == female
            return true;
        }
        return false;
    }

    function isCorrectChecksum($pin) {
        $checksumDigit = intval(substr($pin, -1));
        $weights = [2, 4, 8, 5, 10, 9, 7, 3, 6];
        $checkSum = 0;

        for ($i = 0; $i < 9; $i++) {
            $checkSum += intval(substr($pin, $i, 1)) * $weights[$i];
        }

        $remainder = $checkSum % 11;
        if ($remainder == 10) {
            $remainder = 0;
            if ($remainder == $checksumDigit) {
                return true;
            }
        }
        else {
            if ($remainder == $checksumDigit) {
                return true;
            }
        }
        return false;
    }
    ?>
</body>
</html>