<?php
ob_start();
session_start();

// updating articles

include ('../inc/header.php');
include ('../config/connection.php');

if (isset($_SESSION['admin']))
	{
	$post = $_GET['id'];
	if (isset($_POST['postContent']))
		{
		$postTitle = $_POST['postTitle'];
		$postContent = $_POST['postContent'];
		$postDate = date("Y-m-d");
		$postDescription = $_POST['postDescription'];
		$postQuery = mysqli_query($connection, "update content set title ='" . mysqli_real_escape_string($connection, $postTitle) . "', content = '" . mysqli_real_escape_string($connection, $postContent) . "', date = '" . $postDate . "', description ='" . mysqli_real_escape_string($connection, $postDescription) . "' where id='" . $post . "'");

		Header("Location: ../");
		ob_end_flush();
		}

	if (isset($_GET['id']))
		{
		$query = mysqli_query($connection, "select * from content where id='" . $post . "'");
		while ($row = mysqli_fetch_assoc($query))
			{
?>
<div class="content">
  <div class="newPost">
    <form action="" method="post">
      title: <input type="text" name="postTitle" value="<?php
			echo $row['title']; ?>"></br></br>
      description: </br><textarea rows=15 cols=20 name="postDescription"><?php
			echo html_entity_decode($row['description']); ?></textarea></br>
      content: </br><textarea rows=15 cols=50 name="postContent"><?php
			echo html_entity_decode($row['content']); ?></textarea></br></br>
      <input type="submit" value="update"></br></br>
  </div>
</div>

<?php
			}
		}
	include ('../inc/footer.php');
	}
  else
	{
	Header('Location: ../login/');
	exit();
	}

?>
