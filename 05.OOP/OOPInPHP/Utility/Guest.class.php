<?php

namespace Utility;
use InvalidArgumentException;

class Guest {
    private $firstName;
    private $lastName;
    private $id;

    function __construct($firstName, $lastName, $id)
    {
        $this->setFirstName($firstName);
        $this->setLastName($lastName);
        $this->setId($id);
    }


    /**
     * @param string $firstName
     * @throws InvalidArgumentException
     */
    public function setFirstName($firstName)
    {
        if ($firstName === null || $firstName === "") {
            throw new InvalidArgumentException("FirstName cannot be empty or null!");
        }

        $this->firstName = $firstName;
    }

    /**
     * @return string
     */
    public function getFirstName()
    {
        return $this->firstName;
    }

    /**
     * @param string $lastName
     * @throws InvalidArgumentException
     */
    public function setLastName($lastName)
    {
        if ($lastName === null || $lastName === "") {
            throw new InvalidArgumentException("LastName cannot be empty or null!");
        }

        $this->lastName = $lastName;
    }

    /**
     * @return string
     */
    public function getLastName()
    {
        return $this->lastName;
    }

    /**
     * @param mixed $id
     * @throws InvalidArgumentException
     */
    public function setId($id)
    {
        if (!is_numeric($id)) {
            throw new InvalidArgumentException("Id must be numeric!");
        }

        $this->id = $id;
    }

    /**
     * @return mixed
     */
    public function getId()
    {
        return $this->id;
    }

    function __toString()
    {
        $guestToString = $this->getFirstName() . " " . $this->getLastName() . ", EGN" . $this->getId();
        return $guestToString;
    }
} 