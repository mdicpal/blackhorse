<?php

namespace AzureFunderCommonMessages\PHP\Models;

use AzureFunderCommonMessages\PHP\Traits\JsonSerializer;

class Company implements \JsonSerializable
{
	use JsonSerializer;
	protected ?string $type;
	protected ?string $companyNumber;
	protected ?string $name;
	protected ?Address $address;
	protected ?string $phone;
	protected ?int $establishedMonth;
	protected ?int $establishedYear;
	protected ?string $nature;
	protected ?string $sortcode;
	protected ?string $accountNumber;
	protected ?bool $isVatRegistered;
	protected ?string $vatNumber;
	protected ?string $companyRole;

	public function getType(): ?string
	{
		return $this->type;
	}

	public function getCompanyNumber(): ?string
	{
		return $this->companyNumber;
	}

	public function getName(): ?string
	{
		return $this->name;
	}

	public function getAddress(): ?Address
	{
		return $this->address;
	}

	public function getPhone(): ?string
	{
		return $this->phone;
	}

	public function getEstablishedMonth(): ?int
	{
		return $this->establishedMonth;
	}

	public function getEstablishedYear(): ?int
	{
		return $this->establishedYear;
	}

	public function getNature(): ?string
	{
		return $this->nature;
	}

	public function getSortcode(): ?string
	{
		return $this->sortcode;
	}

	public function getAccountNumber(): ?string
	{
		return $this->accountNumber;
	}

	public function getIsVatRegistered(): ?bool
	{
		return $this->isVatRegistered;
	}

	public function getVatNumber(): ?string
	{
		return $this->vatNumber;
	}

	public function getCompanyRole(): ?string
	{
		return $this->companyRole;
	}

	public function setType(?string $type): self
	{
		$this->type = $type;
		return $this;
	}

	public function setCompanyNumber(?string $companyNumber): self
	{
		$this->companyNumber = $companyNumber;
		return $this;
	}

	public function setName(?string $name): self
	{
		$this->name = $name;
		return $this;
	}

	public function setAddress(?Address $address): self
	{
		$this->address = $address;
		return $this;
	}

	public function setPhone(?string $phone): self
	{
		$this->phone = $phone;
		return $this;
	}

	public function setEstablishedMonth(?int $establishedMonth): self
	{
		$this->establishedMonth = $establishedMonth;
		return $this;
	}

	public function setEstablishedYear(?int $establishedYear): self
	{
		$this->establishedYear = $establishedYear;
		return $this;
	}

	public function setNature(?string $nature): self
	{
		$this->nature = $nature;
		return $this;
	}

	public function setSortcode(?string $sortcode): self
	{
		$this->sortcode = $sortcode;
		return $this;
	}

	public function setAccountNumber(?string $accountNumber): self
	{
		$this->accountNumber = $accountNumber;
		return $this;
	}

	public function setIsVatRegistered(?bool $isVatRegistered): self
	{
		$this->isVatRegistered = $isVatRegistered;
		return $this;
	}

	public function setVatNumber(?string $vatNumber): self
	{
		$this->vatNumber = $vatNumber;
		return $this;
	}

	public function setCompanyRole(?string $companyRole): self
	{
		$this->companyRole = $companyRole;
		return $this;
	}
}