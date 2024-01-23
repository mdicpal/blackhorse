<?php

namespace AzureFunderCommonMessages\PHP\Models;

use AzureFunderCommonMessages\PHP\Traits\JsonSerializer;

class EmploymentHistory implements \JsonSerializable
{
	use JsonSerializer;
	protected int $orderNumber;
	protected ?string $occupationType;
	protected ?string $jobTitle;
	protected ?string $company;
	protected ?int $yearsAtCompany;
	protected ?int $monthsAtCompany;
	protected ?string $employmentType;
	protected ?string $employmentStatus;
	protected ?string $phoneNumber = null;
	protected ?Address $address;

	public function getPhoneNumber(): ?string
	{
		return $this->phoneNumber;
	}

	public function getOrderNumber(): int
	{
		return $this->orderNumber;
	}

	public function getOccupationType(): ?string
	{
		return $this->occupationType;
	}

	public function getJobTitle(): ?string
	{
		return $this->jobTitle;
	}

	public function getCompany(): ?string
	{
		return $this->company;
	}

	public function getYearsAtCompany(): ?int
	{
		return $this->yearsAtCompany;
	}

	public function getMonthsAtCompany(): ?int
	{
		return $this->monthsAtCompany;
	}

	public function getEmploymentType(): ?string
	{
		return $this->employmentType;
	}

	public function getEmploymentStatus(): ?string
	{
		return $this->employmentStatus;
	}

	public function getAddress(): ?Address
	{
		return $this->address;
	}

	public function setOrderNumber(int $orderNumber): self
	{
		$this->orderNumber = $orderNumber;
		return $this;
	}

	public function setOccupationType(?string $occupationType): self
	{
		$this->occupationType = $occupationType;
		return $this;
	}

	public function setJobTitle(?string $jobTitle): self
	{
		$this->jobTitle = $jobTitle;
		return $this;
	}

	public function setCompany(?string $company): self
	{
		$this->company = $company;
		return $this;
	}

	public function setYearsAtCompany(?int $yearsAtCompany): self
	{
		$this->yearsAtCompany = $yearsAtCompany;
		return $this;
	}

	public function setMonthsAtCompany(?int $monthsAtCompany): self
	{
		$this->monthsAtCompany = $monthsAtCompany;
		return $this;
	}

	public function setEmploymentType(?string $employmentType): self
	{
		$this->employmentType = $employmentType;
		return $this;
	}

	public function setEmploymentStatus(?string $employmentStatus): self
	{
		$this->employmentStatus = $employmentStatus;
		return $this;
	}

	public function setAddress(?Address $address): self
	{
		$this->address = $address;
		return $this;
	}

	public function setPhoneNumber(string $phoneNumber): self
	{
		$this->phoneNumber = $phoneNumber;
		return $this;
	}
}
