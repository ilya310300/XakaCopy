<?php
session_start();
define('DB_HOST', 'localhost');
define('DB_NAME', 'hack_food');
define('DB_USER', 'hack_food');
define('DB_PASS', 'az4FphoDKr0nqDxB');
define('DB_CHAR', 'UTF8');
include __DIR__.'/SQL.php';

$url = $_SERVER['REQUEST_URI'];
$method = strtolower($_SERVER['REQUEST_METHOD']);


$url = array_slice(explode('/', $url), 2);

function outputAnswer($answer) {
    header('Content-Type: application/json');
    echo json_encode($answer);
}


if($url[0] === 'restaurant') {
    $db = SQL::getObj();
    $stmt = $db->run('SELECT * FROM `t_restaurant`');
    $rests = $stmt->fetchAll(PDO::FETCH_OBJ);
    outputAnswer(array(
        'restaurants' => $rests
    ));
} else if($url[0] === 'dish') {
    $db = SQL::getObj();
    $where = '';
    if(!empty($url[1])) {
        $where = 'WHERE `restaurant_id` = "'.((int)$url[1]).'"';
    }
    $stmt = $db->run('SELECT * FROM `t_dish` '.$where);
    $dishes = $stmt->fetchAll(PDO::FETCH_OBJ);
    outputAnswer(array(
        'dishes' => $dishes
    ));
}