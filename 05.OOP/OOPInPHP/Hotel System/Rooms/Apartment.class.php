<?php

namespace Rooms;

use Utility\RoomInformation;
use Utility\RoomType;

class Apartment extends Room {

    public function __construct($roomNumber, $price)
    {
        parent::__construct(
            new RoomInformation(4, $price, true, true, "TV, air-conditioner, refrigerator, kitchen box, mini-bar, bathtub, free Wi-fi",
                $roomNumber, RoomType::Diamond));
    }

    function __toString()
    {
        return parent::__toString();
    }
} 