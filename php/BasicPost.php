<?php

include 'header.php';
include 'connections.php';

if (isset($_POST['FirstName'])) {
    $FirstName = $_POST['FirstName'];
    $LastName = $_POST['LastName'];
    $PhoneNumber = $_POST['PhoneNumber'];
    $HomeAddress = $_POST['HomeAddress'];
    $City = $_POST['City'];
    $Comments = $_POST['Comments'];
    $Date = date("Y-m-d");
    $Query = mysqli_query($connection, "insert into jobs (FirstName, LastName, PhoneNumber, HomeAddress, Comments, City, Date) VALUES
    
    # mysqli::real_escape_string -- mysqli_real_escape_string — Escapes special characters in a string
    
    ('" . mysqli_real_escape_string($connection, $FirstName) . "','" . mysqli_real_escape_string($connection, $LastName) .
    "','" . mysqli_real_escape_string($connection, $PhoneNumber) . "','" . mysqli_real_escape_string($connection, $HomeAddress) .
    "','" . mysqli_real_escape_string($connection, $City) . "','" . mysqli_real_escape_string($connection, $Comments) .
    "','" . mysqli_real_escape_string($connection, $Date) . "')");

    if (!$Query) {
      echo mysqli_error($connection);
    }
    
# ob_end_flush — Flush (send) the output buffer and turn off output buffering

    ob_end_flush();
}
