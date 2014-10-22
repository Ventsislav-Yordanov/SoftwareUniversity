<?php

use Rooms\Apartment;
use Rooms\Room;
use Rooms\SingleRoom;
use Rooms\BedRoom;
use Utility\Guest;
use Utility\Reservation;
use Utility\BookingManager;

require_once("Utility/RoomInformation.class.php");
require_once("Exceptions/EReservationException.class.php");
require_once("Interfaces/iReservable.php");
require_once("Rooms/Room.class.php");
require_once("Rooms/SingleRoom.class.php");
require_once("Utility/Guest.class.php");
require_once("Utility/Reservation.class.php");
require_once("Utility/RoomType.class.php");
require_once("Utility/BookingManger.class.php");
require_once("Rooms/Apartment.class.php");
require_once("Rooms/BedRoom.class.php");


$room = new Apartment(1408, 500);
$guest = new Guest("Svetlin", "Nakov", 8003224277);
$startDate = strtotime("24.10.2014");
$endDate = strtotime("26.10.2014");

$reservation = new Reservation($startDate, $endDate, $guest);
$reservation2 = new Reservation(strtotime("17.10.2014"), strtotime("19.10.2014"), new Guest("Goshko", "Petkov", 7804100000));
BookingManager::bookRoom($room, $reservation);
BookingManager::bookRoom($room, $reservation2);
$secondRoom = new Apartment(101, 120);
BookingManager::bookRoom($secondRoom, $reservation);
BookingManager::bookRoom($secondRoom, new Reservation(strtotime("10.10.2014"), strtotime("12.10.2014"), new Guest("Goshko", "Petkov", 7804100000)));
$thirdRoom = new BedRoom(543, 250);
BookingManager::bookRoom($thirdRoom, $reservation);
BookingManager::bookRoom($thirdRoom, $reservation2);
$fourthRoom = new SingleRoom(666, 60);
BookingManager::bookRoom($fourthRoom, $reservation);
BookingManager::bookRoom($fourthRoom, $reservation2);

$arrayOfRooms = [$room, $secondRoom, $thirdRoom, $fourthRoom];

// Filter by bedrooms and apartments with a price less or equal to 250.00
$apartmentsAndBedrooms = array_filter($arrayOfRooms, function (Room $r) {
    return ($r instanceof BedRoom || $r instanceof Apartment) && ($r->getRoomInformation()->getPrice() <= 250.00);
});
var_dump($apartmentsAndBedrooms);

// Filter the array by all rooms with a balcony
$roomsWithBalcony = array_filter($arrayOfRooms, function (Room $r) {
    return $r->getRoomInformation()->getHasBalcony();
});
var_dump($roomsWithBalcony);

// Return the room numbers of all rooms which have a bathtub in their extras
$roomNumbersOfRoomsWithBathtub = array_map(function (Room $r) {
    $extras = $r->getRoomInformation()->getExtras();
    $roomNumber = $r->getRoomInformation()->getRoomNumber();
    if (preg_match("/bathtub/", $extras)) {
        return $roomNumber;
    }
}, $arrayOfRooms);

print_r($roomNumbersOfRoomsWithBathtub);