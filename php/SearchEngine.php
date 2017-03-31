<?php
session_start();
if(isset($_SESSION['admin'])) {
include('../admin/header.php');
}
else {
include('header.php');
}
$connection = mysqli_connect('localhost', 'root', 'mason.wolf', 'inventory');

if(isset($_GET['keyword'])) {
  $keyword = $_GET['keyword'];

  // Perform the fulltext search

  $query = "SELECT ID, itemName, description
            FROM tools WHERE MATCH (itemName) AGAINST ('" . $keyword . " ')";
  $result = mysqli_query($connection, $query);
  
  // If results were found, output them
 if (@mysqli_num_rows($result) > 0) {


    while ($row = mysqli_fetch_array($result)) {
      $searchResults = "<a href='itemView.php?item=" . $row['ID'] . "'> " . $row['itemName'] . "</a></br>" . $row['description'];
    }

  } else {
    $searchResults = "No results";
  }
}
?>


<div class="inventory_fullDisplay">
	<div class="toolDisplay_full">
	<div class="searchresults">
	<?php if(isset($searchResults)) { echo $searchResults; } ?>
	</div>
	</div></div>
