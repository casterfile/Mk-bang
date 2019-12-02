<?php
include("bl_Common.php");

 $link=dbConnect();
 
    $query = "SELECT * FROM `MK_RegisterUpdate` ORDER by `MK_RegisterUpdate_Score` DESC  LIMIT 10";
    $result = mysql_query($query) or die('Query failed: ' . mysql_error());
 
    $num_results = mysql_num_rows($result);  
 
    for($i = 0; $i < $num_results; $i++)
    {
         $row = mysql_fetch_array($result);
         echo $row['MK_RegisterUpdate_Name'] . "-" . $row['MK_RegisterUpdate_Score']. "-\n";
    }
    mysql_close($link);
?>