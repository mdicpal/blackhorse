<?php

namespace AzureFunderCommonMessages\PHP\Models;

use AzureFunderCommonMessages\PHP\Traits\JsonSerializer;

class Bank implements \JsonSerializable
{
	use JsonSerializer;
	protected string $accountName;
	protected string $bankName;
	protected Address $address;
	protected string $accountNumber;
	protected string $sortCode;
	protected string $years;
	protected string $months;

	public function getAccountName(): string
	{
		return $this->accountName;
	}

	public function getBankName(): string
	{
		return $this->bankName;
	}

	public function getAddress(): Address
	{
		return $this->address;
	}

	public function getAccountNumber(): string
	{
		return $this->accountNumber;
	}

	public function getSortCode(): string
	{
		return $this->sortCode;
	}

	public function getYears(): string
	{
		return $this->years;
	}

	public function getMonths(): string
	{
		return $this->months;
	}

	public function setAccountName(string $accountName): self
	{
		$this->accountName = $accountName;
		return $this;
	}

	public function setBankName(string $bankName): self
	{
		$this->bankName = $bankName;
		return $this;
	}

	public function setAddress(Address $address): self
	{
		$this->address = $address;
		return $this;
	}

	public function setAccountNumber(string $accountNumber): self
	{
		$this->accountNumber = $accountNumber;
		return $this;
	}

	public function setSortCode(string $sortCode): self
	{
		$this->sortCode = $sortCode;
		return $this;
	}

	public function setYears(string $years): self
	{
		$this->years = $years;
		return $this;
	}

	public function setMonths(string $months): self
	{
		$this->months = $months;
		return $this;
	}
}
