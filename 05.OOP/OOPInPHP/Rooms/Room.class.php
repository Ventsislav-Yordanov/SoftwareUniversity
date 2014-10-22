<?php

namespace Rooms;

use Interfaces\iReservable;
use Exceptions\EReservationException;
use Utility\Reservation;
use Utility\RoomInformation;

abstract class Room implements iReservable{
    protected  $roomInformation;
    protected $reservations = [];

    protected function __construct(RoomInformation $roomInformation)
    {
        $this->setRoomInformation($roomInformation);
    }

    /**
     * Reservation @return array(Reservation)
     */
    public function getReservations()
    {
        return $this->reservations;
    }

    /**
     * @param array Reservation $reservations
     */
    protected function setReservations($reservations)
    {
        $this->reservations[] = $reservations;
    }

    /**
     * @return RoomInformation
     */
    public function getRoomInformation()
    {
        return $this->roomInformation;
    }

    /**
     * @param RoomInformation $roomInformation
     */
    public function setRoomInformation($roomInformation)
    {
        $this->roomInformation = $roomInformation;
    }

    /**
     * @param $reservation Reservation
     * @throws EReservationException
     */
    public function addReservation($reservation)
    {
        if (($key = array_search($reservation, $this->reservations)) !== false) {
            throw new EReservationException();
        }

        // check if this reservation date match with the others reservation dates
        /** @var Reservation $thisReservation */
        foreach ($this->getReservations() as $thisReservation) {
            if ( (strtotime($thisReservation->getStartDate()) <= strtotime($reservation->getStartDate() ) &&
                    strtotime($reservation->getStartDate()) <= strtotime($thisReservation->getEndDate()) ) ||
                (strtotime($thisReservation->getStartDate()) <= strtotime($reservation->getEndDate() ) &&
                    strtotime($reservation->getEndDate()) <= strtotime($thisReservation->getEndDate()) ) ||
                (strtotime($reservation->getStartDate()) < strtotime($thisReservation->getStartDate() ) &&
                    strtotime($reservation->getEndDate()) > strtotime($thisReservation->getEndDate()) )
            ) {
                throw new EReservationException("Room is reserved for this date.");
            }
        }
        $this->setReservations($reservation);

        array_multisort($this->reservations);
    }

    /**
     * @param $reservation Reservation
     * @throws EReservationException
     */
    public function removeReservation($reservation)
    {
        if(($key = array_search($reservation, $this->reservations)) !== false) {
            unset($this->reservations[$key]);
        } else {
            throw new EReservationException("There is no such reservation.");
        }
    }

    function __toString()
    {
        $result = "\n" . get_class($this) . " -> Room information: \n" . $this->getRoomInformation() . "\nReservations: \n";
        if (count($this->getReservations()) > 0){
            foreach($this->getReservations() as $item){
                $result .= "$item \n";
            }
        } else {
            $result .= "\tNo reservations";
        }
        return $result;
    }
} 