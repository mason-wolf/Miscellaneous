  <?php
  // displays July 10th, 2018
  $time = date("F j, Y, g:i a");
  echo $time;

  // retrieves last day of the month
  $defaultStartDate = date("Y-m") . "-01"; 
  $defaultEndDate = date("Y-m-t", strtotime($defaultStartDate));

   ?>
