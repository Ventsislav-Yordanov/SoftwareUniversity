<?php
$name = "Gosho";
$phone = "0882-321-423";
$age = "24";
$address = "Hadji Dimitar";
?>

<!doctype html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>Info Table</title>
    <style>
        table ,td ,th {
            border: 1px solid black;
            border-collapse: collapse;
        }
        td, th {
            width: 130px;
            padding: 5px;

        }
        th {
            background-color: darkorange;
            text-align: left;
        }
        td{
            text-align: right;
        }
    </style>
</head>
<body>
 <table>
    <tr>
        <th>Name</th>
        <td><?php echo $name; ?></td>
    </tr>
     <tr>
         <th>Phone number</th>
         <td><?php echo $phone; ?></td>
     </tr>
     <tr>
         <th>Age</th>
         <td><?php echo $age; ?></td>
     </tr>
     <tr>
         <th>Address</th>
         <td><?php echo $address; ?></td>
     </tr>
 </table>
</body>
</html>