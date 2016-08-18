<?php

if(isset($_POST['itemName'])) {

$uploaddir = '..\uploads\\';
$uploadfile = $uploaddir . basename($_FILES['toolImage']['name']);

if (move_uploaded_file($_FILES['toolImage']['tmp_name'], $uploadfile)) {
    $uploadStatus = "<span style='color:green;font-weight:bold;'>Uploaded image successfully.</span>";
} else {
    $uploadStatus = "<span style='color:red;font-weight:bold;'>Error uploading image.</span>";
}
	$itemName = $_POST['itemName'];
	$partNumber = $_POST['partNumber'];
	$manufacturer = $_POST['manufacturer'];
	$description = mysqli_real_escape_string($connection, $_POST['description']);
	$quantity = $_POST['quantity'];
	$imageFileName = generateFileName(20);
	$fileFormat = getImageFormat("..\uploads\\" . basename($_FILES['toolImage']['name']));
	$query = "INSERT INTO tools ( itemName, partNumber, manufacturer, description, quantity, imageFileName, fileFormat )
	VALUES('" . $itemName . "','" . $partNumber . "','" . $manufacturer . "','" . $description
			  . "','" . $quantity . "','" . $imageFileName . "', ' " . $fileFormat . "')";
	$result = mysqli_query($connection, $query);
	// After inserting the randomly generating file name for the image into the database,
	// we're going to pull it and rename the file itself 
	$fileNameQuery = "SELECT imageFileName from tools where itemName = '" . $itemName . "'";
	$fileName = mysqli_query($connection, $fileNameQuery);
	$newFileName = mysqli_fetch_assoc($fileName);
	// Assign the file its new name and previously identified file type
	rename("..\uploads\\" . basename($_FILES['toolImage']['name']) , "..\uploads\\" . $newFileName['imageFileName'] . $fileFormat);
	Header("Location: index.php");
	}
	
	// use this for pulling image format data from db
	$imageFileFormat =  preg_replace('/\s+/', '', $row['fileFormat']);
	
	?>
	