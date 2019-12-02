<?php
include("bl_Common.php");
    $link=dbConnect();
 
    $MK_RegisterUpdate_UUID = safe($_POST['MK_RegisterUpdate_UUID']);
    $MK_RegisterUpdate_Name = safe($_POST['MK_RegisterUpdate_Name']);
    $MK_RegisterUpdate_Score = safe($_POST['MK_RegisterUpdate_Score']);

    // $MK_RegisterUpdate_UUID = "kkkkkkkkkkkkkk";
    // $MK_RegisterUpdate_Name = "kkkkkkkkkkkkkk";
    // $MK_RegisterUpdate_Score = "kkkkkkkkkkkkkk";

    // $MK_RegisterUpdate_UUID = "kkkkkkkkkkkkkk";
    // $MK_RegisterUpdate_Name = "222222";
    // $MK_RegisterUpdate_Score = "222222";
 

    $real_hash = md5($name . $password . $secretKey);
    if($real_hash == $hash)
    {
        
    }

    if ($MK_RegisterUpdate_UUID !== '')
    {
        $check = mysql_query("SELECT * FROM MK_RegisterUpdate WHERE `MK_RegisterUpdate_UUID`= '$MK_RegisterUpdate_UUID'");

        $numrows = mysql_num_rows($check);
        if ($numrows == 0 )
        {
            $ins = mysql_query("INSERT INTO  `MK_RegisterUpdate` (`MK_RegisterUpdate_Name` ,  `MK_RegisterUpdate_Score` ,  `MK_RegisterUpdate_UUID` ) 
            VALUES ('".mysql_real_escape_string($MK_RegisterUpdate_Name)."' ,  '".mysql_real_escape_string($MK_RegisterUpdate_Score)."',  '".mysql_real_escape_string($MK_RegisterUpdate_UUID)."') ");
            if ($ins){
                
                die ("Done");
            }else{
                die ("Error: " . mysql_error());
            }
        }
        else
        {
            // die("A user with this name already exists,\n please choose another one!");
            // $sql = "UPDATE MyGuests SET lastname='Doe' WHERE id=2";

            $ins = mysql_query("UPDATE `MK_RegisterUpdate` SET `MK_RegisterUpdate_Name` = '".mysql_real_escape_string($MK_RegisterUpdate_Name)."', 
            `MK_RegisterUpdate_Score` = '".mysql_real_escape_string($MK_RegisterUpdate_Score)."'  WHERE  `MK_RegisterUpdate_UUID` = '".mysql_real_escape_string($MK_RegisterUpdate_UUID)."'");
            if ($ins){
                
                die ("Updated");
            }else{
                die ("Error: " . mysql_error());
            }
        }
    }
    mysql_close( $link);
?>