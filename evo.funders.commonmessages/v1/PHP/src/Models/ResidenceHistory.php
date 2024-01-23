<?php

namespace AzureFunderCommonMessages\PHP\Models;

use AzureFunderCommonMessages\PHP\Traits\JsonSerializer;

class ResidenceHistory implements \JsonSerializable
{
	use JsonSerializer;
	protected Address $address;
	protected int $orderNumber;
	protected string $residentialStatusShortcode;
	protected int $yearsAtAddress;
	protected int $monthsAtAddress;

	public function getAddress(): Address
	{
		return $this->address;
	}

	public function getOrderNumber(): int
	{
		return $this->orderNumber;
	}

	public function getResidentialStatusShortcode(): string
	{
		return $this->residentialStatusShortcode;
	}

	public function getYearsAtAddress(): int
	{
		return $this->yearsAtAddress;
	}

	public function getMonthsAtAddress(): int
	{
		return $this->monthsAtAddress;
	}

	public function setAddress(Address $address): self
	{
		$this->address = $address;
		return $this;
	}

	public function setOrderNumber(int $orderNumber): self
	{
		$this->orderNumber = $orderNumber;
		return $this;
	}

	public function setResidentialStatusShortcode(string $residentialStatusShortcode): self
	{
		$this->residentialStatusShortcode = $residentialStatusShortcode;
		return $this;
	}

	public function setYearsAtAddress(int $yearsAtAddress): self
	{
		$this->yearsAtAddress = $yearsAtAddress;
		return $this;
	}

	public function setMonthsAtAddress(int $monthsAtAddress): self
	{
		$this->monthsAtAddress = $monthsAtAddress;
		return $this;
	}
}