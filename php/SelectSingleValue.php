    $balancequery = mysqli_fetch_assoc(mysqli_query($connection, "select balance from users where email='" . $user . "'"));
    $balanceresult = $balancequery['balance'];
