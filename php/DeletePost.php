<?php
ob_start();
session_start();

// deleting post

include ('../inc/header.php');
include ('../config/connection.php');

if (isset($_SESSION['admin'])) {
	$post = $_GET['id'];
	$query = mysqli_query($connection, "delete from content where id='" . $post . "'");
	Header("Location: ../");
	exit();
}
else {
	Header("Location: ../");
}
