<?php
ob_start();
session_start();

// creating a new article

include ('../inc/header.php');
include ('../config/connection.php');

// check the session to see if user is admin

if (isset($_SESSION['admin'])) {

  // if the form is submitted, post the content
	if (isset($_POST['postContent'])) {

		$postTitle = $_POST['postTitle'];
		$postContent = $_POST['postContent'];
		$postDate = date("Y-m-d");
		$postDescription = $_POST['postDescription'];

    // mysqli_real_escape_string is used to strip the special characters escaping the query, causing it to fail
		$postQuery = mysqli_query($connection, "insert into content (title, content, date, description) VALUES
     ('" . mysqli_real_escape_string($connection, $postTitle) . "', '" . mysqli_real_escape_string($connection, $postContent) . "','" . $postDate . "', '" . mysqli_real_escape_string($connection, $postDescription) . "')");
		if (!$postQuery) {
			echo "<span color='white;'>" . mysqli_error($connection) . "</span>";
		}
		Header("Location: ../");
		ob_end_flush();
	}

?>
<div class="content">
  <div class="newPost">
    <form action="" method="post">
      title: <input type="text" name="postTitle"></br></br>
      description: </br><textarea rows=15 cols=20 name="postDescription"></textarea></br>
      content: </br><textarea rows=15 cols=50 name="postContent"></textarea></br></br>
      <input type="submit" value="post"></br></br>
  </div>
</div>

<?php
	include ('../inc/footer.php');

}
else {
	Header('Location: ../login/');
	exit();
}

?>
