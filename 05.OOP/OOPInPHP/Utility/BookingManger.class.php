<?php

namespace Utility;

use Rooms\Room;

class BookingManager {
    public static function bookRoom(Room $room, Reservation $reservation){
        $room->addReservation($reservation);
        $message = "\nRoom <strong>" . $room->getRoomInformation()->getRoomNumber() . "</strong>\n" .
            "successfully booked for\n" .
            "<strong>" . $reservation->getGuest()->getFirstName() . " " . $reservation->getGuest()->getLastName() .  "</strong>\n".
            "from <time>" . $reservation->getStartDate() . "</time> to\n".
            "<time>" . $reservation->getEndDate() . "</time>!\n";

        echo $message;
    }
}