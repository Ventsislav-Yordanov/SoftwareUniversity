<?php

namespace Utility;

use Exception;
use InvalidArgumentException;

class RoomInformation {
    private $roomType;
    private $hasRestroom;
    private $hasBalcony;
    private $bedCount;
    private $roomNumber;
    private $extras;
    private $price;

    /**
     * @param int $bedCount
     * @param double $price
     * @param boolean $hasRestroom
     * @param boolean $hasBalcony
     * @param string $extras
     * @param int $roomNumber
     * @param RoomType $roomType
     * @throws Exception InvalidArgumentException
     */
    public function __construct($bedCount, $price, $hasRestroom, $hasBalcony, $extras, $roomNumber, $roomType)
    {
        $this->setBedCount($bedCount);
        $this->setPrice($price);
        $this->setHasRestroom($hasRestroom);
        $this->setHasBalcony($hasBalcony);
        $this->setExtras($extras);
        $this->setRoomNumber($roomNumber);
        $this->setRoomType($roomType);
    }

    /**
     * @return mixed
     */
    public function getBedCount()
    {
        return $this->bedCount;
    }

    /**
     * @param mixed $bedCount
     */
    public function setBedCount($bedCount)
    {
        if ($bedCount <= 0){
            throw new InvalidArgumentException("Bed count cannot be ne 0 or negative.");
        }
        $this->bedCount = $bedCount;
    }

    /**
     * @return mixed
     */
    public function getExtras()
    {
        return $this->extras;
    }

    /**
     * @param mixed $extras
     */
    public function setExtras($extras)
    {
        if ($extras === null || $extras === ""){
            throw new InvalidArgumentException("Extras cannot be null or empty.");
        }
        $this->extras = $extras;
    }

    /**
     * @return mixed
     */
    public function getHasBalcony()
    {
        return $this->hasBalcony;
    }

    /**
     * @param mixed $hasBalcony
     */
    public function setHasBalcony($hasBalcony)
    {
        $this->hasBalcony = $hasBalcony;
    }

    /**
     * @return mixed
     */
    public function getHasRestroom()
    {
        return $this->hasRestroom;
    }

    /**
     * @param mixed $hasRestroom
     */
    public function setHasRestroom($hasRestroom)
    {
        $this->hasRestroom = $hasRestroom;
    }

    /**
     * @return mixed
     */
    public function getPrice()
    {
        return $this->price;
    }

    /**
     * @param mixed $price
     */
    public function setPrice($price)
    {
        if ($price < 0){
            throw new InvalidArgumentException("Invalid price.");
        }
        $this->price = $price;
    }

    /**
     * @return mixed
     */
    public function getRoomNumber()
    {
        return $this->roomNumber;
    }

    /**
     * @param mixed $roomNumber
     */
    public function setRoomNumber($roomNumber)
    {
        if ($roomNumber < 0){
            throw new InvalidArgumentException("Invalid room number.");
        }
        $this->roomNumber = $roomNumber;
    }

    /**
     * @return RoomType
     */
    public function getRoomType()
    {
        return $this->roomType;
    }

    /**
     * @param RoomType $roomType
     */
    public function setRoomType($roomType)
    {
        $this->roomType = $roomType;
    }

    /**
     * @return string
     */
    function __toString()
    {
        $hasBalcony = $this->getHasBalcony() ? "Yes" : "No";
        $hasRestroom = $this->getHasRestroom() ? "Yes" : "No";

        $result = "Price: " . $this->getPrice() .
            "\nBed count: " . $this->getBedCount() .
            "\nRoom type: " . $this->getRoomType() .
            "\nRoom number: " . $this->getRoomNumber() .
            "\nHas balcony: " . $hasBalcony .
            "\nHas Restroom: " . $hasRestroom .
            "\nExtras: " . $this->getExtras();
        return $result;
    }
} 