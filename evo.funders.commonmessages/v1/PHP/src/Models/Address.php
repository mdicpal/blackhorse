<?php

namespace AzureFunderCommonMessages\PHP\Models;

use AzureFunderCommonMessages\PHP\Traits\JsonSerializer;

class Address implements \JsonSerializable
{
	use JsonSerializer;
	protected ?string $unit;
	protected ?string $houseName;
	protected ?string $houseNumber;
	protected ?string $addressLine1;
	protected ?string $addressLine2;
	protected ?string $addressLine3;
	protected ?string $town;
	protected ?string $county;
	protected ?string $postcode;

	public function getUnit(): ?string
	{
		return $this->unit;
	}

	public function getHouseName(): ?string
	{
		return $this->houseName;
	}

	public function getHouseNumber(): ?string
	{
		return $this->houseNumber;
	}

	public function getAddressLine1(): ?string
	{
		return $this->addressLine1;
	}

	public function getAddressLine2(): ?string
	{
		return $this->addressLine2;
	}

	public function getAddressLine3(): ?string
	{
		return $this->addressLine3;
	}

	public function getTown(): ?string
	{
		return $this->town;
	}

	public function getCounty(): ?string
	{
		return $this->county;
	}

	public function getPostcode(): ?string
	{
		return $this->postcode;
	}

	public function setUnit(?string $unit): self
	{
		$this->unit = $unit;
		return $this;
	}

	public function setHouseName(?string $houseName): self
	{
		$this->houseName = $houseName;
		return $this;
	}

	public function setHouseNumber(?string $houseNumber): self
	{
		$this->houseNumber = $houseNumber;
		return $this;
	}

	public function setAddressLine1(?string $addressLine1): self
	{
		$this->addressLine1 = $addressLine1;
		return $this;
	}

	public function setAddressLine2(?string $addressLine2): self
	{
		$this->addressLine2 = $addressLine2;
		return $this;
	}

	public function setAddressLine3(?string $addressLine3): self
	{
		$this->addressLine3 = $addressLine3;
		return $this;
	}

	public function setTown(?string $town): self
	{
		$this->town = $town;
		return $this;
	}

	public function setCounty(?string $county): self
	{
		$this->county = $county;
		return $this;
	}

	public function setPostcode(?string $postcode): self
	{
		$this->postcode = $postcode;
		return $this;
	}
}
