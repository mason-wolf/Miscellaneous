<?php

$connection = mysqli_connect("localhost", "root", "mason.wolf", "inventory");
$num_rec_per_page = 10;

if(isset($_GET['page'])) { $page = $_GET['page']; } else { $page = 1; }
$start_from = ($page-1) * $num_rec_per_page;
$sql = "SELECT * FROM tools ORDER BY id DESC LIMIT $start_from, $num_rec_per_page";
$result = mysqli_query($connection, $sql);

while ($row = mysqli_fetch_assoc($result)) {
  // do stuff
}
