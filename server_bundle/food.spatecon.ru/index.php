<meta charset="UTF-8">

<form method="post" enctype="multipart/form-data">
    <input type="file" name="image_file">
    <input type="submit" value="Загрузить">
</form>


<?php

if(strtoupper($_SERVER['REQUEST_METHOD']) === 'POST') {
    $info = pathinfo($_FILES['image_file']['name']);
    $ext = strtolower($info['extension']); // get the extension of the file
    if($ext === 'jpeg') {
        $ext = 'jpg';
    }
    $new_name = strtolower(md5(time())).".".$ext;
    $allowed_exts = ['jpg', 'png'];
    if(!in_array($ext, $allowed_exts, true)) {
        exit('WRONG FILE TYPE!');
    }

    $target = __DIR__.'/images/'.$new_name;
    move_uploaded_file( $_FILES['image_file']['tmp_name'], $target);
    echo 'Ссылка на последний загруженный файл:<br><textarea style="width: 100%; height: 30px;" readonly="readonly">https://'.$_SERVER['HTTP_HOST'].'/images/'.$new_name.'</textarea>';
}