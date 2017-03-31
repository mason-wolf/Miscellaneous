<?php
ob_start();
include('../inc/header.php');
include('../config/connection.php');

if (isset($_POST['usr'])) {
    $usr       = $_POST['usr'];
    $pass      = $_POST['pass'];
    $usrQuery  = "select * from managers where usr='" . $usr . "' AND pass='" . $pass . "'";
    $usrResult = mysqli_query($connection, $usrQuery);
    $usrCount  = mysqli_num_rows($usrResult);
    $usr       = mysqli_fetch_assoc($usrResult);
    if ($usrCount >= 1) {
        session_start();
        $_SESSION['admin'] = $usr;
        Header("Location: ../");
        ob_end_flush();
    } else {
        $badlogin = "</br><span style='color:red;'>Incorrect credentials.</span></br>";
    }
}
?>

<div class="content">  <div class="loginForm">    <form action="" method="post">
     username: <input type="text" name="usr">
     password: <input type="password" name="pass"></br></br>
               <input type="submit" value="login">    </form>      <?php
if (isset($badlogin)) {
    echo $badlogin;
}
?>   </div></div><?php
include('../inc/footer.php');
?>
