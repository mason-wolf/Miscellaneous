  <?php
  // displays July 10th, 2018
  $time = date("F j, Y, g:i a");
  echo $time;

  // retrieves last day of the month
  $defaultStartDate = date("Y-m") . "-01"; 
  $defaultEndDate = date("Y-m-t", strtotime($defaultStartDate));

  // reformats date from 2018-01-07 to July 1, 2018
  $defaultStartDate = date("Y-m") . "-01"; 
  $startDate = date("F j, Y", strtotime($defaultStartDate));
  echo $startDate;
   ?>
