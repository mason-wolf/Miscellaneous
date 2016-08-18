<?php

$connection = mysqli_connect("localhost", "root", "mason.wolf", "inventory");
$num_rec_per_page = 3;
if(isset($_GET['page'])) { $page = $_GET['page']; } else { $page = 1; }
$start_from = ($page-1) * $num_rec_per_page;
$sql = "SELECT * FROM tools LIMIT $start_from, $num_rec_per_page";
$result = mysqli_query($connection, $sql);

while ($row = mysqli_fetch_assoc($result)) { 
  
  // handle output
  
}

$paginateQuery = "SELECT * FROM tools";
	$queryResult = mysqli_query($connection, $paginateQuery);
	$total_records = mysqli_num_rows($queryResult);
	$total_pages = ceil($total_records / $num_rec_per_page);
	
	echo "<a href='Inventory_FullView.php?page=1' class='pagination'>" . 'First' . "</a>";

	for ($i=1;$i<=$total_pages; $i++) {
		echo "<a href='Inventory_FullView.php?page=" . $i . "' class='pagination'>" . $i . "</a>";
		}; 
	echo "<a href='Inventory_FullView.php?page=" . $total_pages . "' class='pagination'>" . 'Last' . "</a>";