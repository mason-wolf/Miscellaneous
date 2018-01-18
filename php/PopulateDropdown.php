<?php
$sql = mysqli_query($connection, "SELECT title FROM categories");
while ($row = $sql->fetch_assoc()){
echo "<option value=\"category\">" . $row['title'] . "</option>";
}
?>
