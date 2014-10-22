<?php

namespace Rooms;

use Utility\RoomInformation;
use Utility\RoomType;

class Bedroom  extends Room {

    public function __construct($roomNumber, $price)
    {
        parent::__construct(
            new RoomInformation(2, $price, true, true, "TV, air-conditioner, refrigerator, mini-bar, bathtub",
                $roomNumber, RoomType::Gold));
    }

    function __toString()
    {
        return parent::__toString();
    }
} 