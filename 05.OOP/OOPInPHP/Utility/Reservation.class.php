<?php

namespace Utility;

class Reservation {
    private $startDate;
    private $endDate;
    private $guest;

    function __construct($startDate, $endDate, Guest $guest)
    {
        $this->setStartDate($startDate);
        $this->setEndDate($endDate);
        $this->setGuest($guest);
    }


    /**
     * @param Date $startDate
     */
    public function setStartDate($startDate)
    {
        $this->startDate = $startDate;
    }

    /**
     * @return Date
     */
    public function getStartDate()
    {
        return date("d-m-Y", $this->startDate);
    }

    /**
     * @param Date $endDate
     */
    public function setEndDate($endDate)
    {
        $this->endDate = $endDate;
    }

    /**
     * @return Date
     */
    public function getEndDate()
    {
        return date("d-m-Y", $this->endDate);
    }

    /**
     * @param Guest $guest
     */
    public function setGuest($guest)
    {
        $this->guest = $guest;
    }

    /**
     * @return Guest
     */
    public function getGuest()
    {
        return $this->guest;
    }

    function __toString()
    {
        $reservationToString = "\tReservation Start date:" . $this->getStartDate() .
            ", End date:" . $this->getEndDate() . ", Guest: " . $this->getGuest();

        return $reservationToString;
    }
}