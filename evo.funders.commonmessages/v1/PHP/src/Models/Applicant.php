<?php

namespace AzureFunderCommonMessages\PHP\Models;

use AzureFunderCommonMessages\PHP\Traits\JsonSerializer;



class Applicant implements \JsonSerializable
{
	use JsonSerializer;
	protected ?bool $isMainApplicant;
	protected ?string $applicantType;
	protected ?string $companyType;
	protected ?string $title;
	protected ?string $forename;
	protected ?string $middlename;
	protected ?string $surname;
	protected ?string $dob;
	protected ?string $sexAtBirth;
	protected ?string $maritalStatus;
	protected ?bool $isUkResident;
	protected ?string $homephone;
	protected ?string $workphone;
	protected ?string $mobile;
	protected ?string $email;
	protected ?string $drivingLicenceType;
	protected ?string $nationality;
	/** @var ResidenceHistory[]|null */
	protected ?array $residenceHistory;
	/** @var EmploymentHistory[]|null */
	protected ?array $employmentHistory;
	protected ?Company $company;
	protected ?FinancialStatus $financialStatus;
	protected ?Bank $bank;
	protected ?MarketingPreference $marketingPreference;

	public function getCompanyType(): ?string 
	{
		return $this->companyType;
	}

	public function getIsMainApplicant(): ?bool
	{
		return $this->isMainApplicant;
	}

	public function getNationality(): ?string
	{
		return $this->nationality;
	}

	public function getApplicantType(): ?string
	{
		return $this->applicantType;
	}

	public function getTitle(): ?string
	{
		return $this->title;
	}

	public function getForename(): ?string
	{
		return $this->forename;
	}

	public function getMiddlename(): ?string
	{
		return $this->middlename;
	}

	public function getSurname(): ?string
	{
		return $this->surname;
	}

	public function getDob(): ?string
	{
		return $this->dob;
	}

	public function getSexAtBirth(): ?string
	{
		return $this->sexAtBirth;
	}

	public function getMaritalStatus(): ?string
	{
		return $this->maritalStatus;
	}

	public function getIsUkResident(): ?bool
	{
		return $this->isUkResident;
	}

	public function getHomephone(): ?string
	{
		return $this->homephone;
	}

	public function getWorkphone(): ?string
	{
		return $this->workphone;
	}

	public function getMobile(): ?string
	{
		return $this->mobile;
	}

	public function getEmail(): ?string
	{
		return $this->email;
	}

	public function getDrivingLicenceType(): ?string
	{
		return $this->drivingLicenceType;
	}

	/**
	 * @return ResidenceHistory[]|null
	 */
	public function getResidenceHistory(): ?array
	{
		return $this->residenceHistory;
	}

	/**
	 * @return EmploymentHistory[]|null
	 */
	public function getEmploymentHistory(): ?array
	{
		return $this->employmentHistory;
	}

	public function getCompany(): ?Company
	{
		return $this->company;
	}

	public function getFinancialStatus(): ?FinancialStatus
	{
		return $this->financialStatus;
	}

	public function getBank(): ?Bank
	{
		return $this->bank;
	}

	public function getMarketingPreference(): ?MarketingPreference
	{
		return $this->marketingPreference;
	}

	public function setNationality(?string $nationality): self
	{
		$this->nationality = $nationality;
		return $this;
	}

	public function setIsMainApplicant(?bool $isMainApplicant): self
	{
		$this->isMainApplicant = $isMainApplicant;
		return $this;
	}

	public function setApplicantType(?string $applicantType): self
	{
		$this->applicantType = $applicantType;
		return $this;
	}

	public function setTitle(?string $title): self
	{
		$this->title = $title;
		return $this;
	}

	public function setForename(?string $forename): self
	{
		$this->forename = $forename;
		return $this;
	}

	public function setMiddlename(?string $middlename): self
	{
		$this->middlename = $middlename;
		return $this;
	}

	public function setSurname(?string $surname): self
	{
		$this->surname = $surname;
		return $this;
	}

	public function setDob(?string $dob): self
	{
		$this->dob = $dob;
		return $this;
	}

	public function setSexAtBirth(?string $sexAtBirth): self
	{
		$this->sexAtBirth = $sexAtBirth;
		return $this;
	}

	public function setMaritalStatus(?string $maritalStatus): self
	{
		$this->maritalStatus = $maritalStatus;
		return $this;
	}

	public function setIsUkResident(?bool $isUkResident): self
	{
		$this->isUkResident = $isUkResident;
		return $this;
	}

	public function setHomephone(?string $homephone): self
	{
		$this->homephone = $homephone;
		return $this;
	}

	public function setWorkphone(?string $workphone): self
	{
		$this->workphone = $workphone;
		return $this;
	}

	public function setMobile(?string $mobile): self
	{
		$this->mobile = $mobile;
		return $this;
	}

	public function setEmail(?string $email): self
	{
		$this->email = $email;
		return $this;
	}

	public function setDrivingLicenceType(?string $drivingLicenceType): self
	{
		$this->drivingLicenceType = $drivingLicenceType;
		return $this;
	}

	/**
	 * @param ResidenceHistory[]|null $residenceHistory
	 */
	public function setResidenceHistory(?array $residenceHistory): self
	{
		$this->residenceHistory = $residenceHistory;
		return $this;
	}

	/**
	 * @param EmploymentHistory[]|null $employmentHistory
	 */
	public function setEmploymentHistory(?array $employmentHistory): self
	{
		$this->employmentHistory = $employmentHistory;
		return $this;
	}

	public function setCompany(?Company $company): self
	{
		$this->company = $company;
		return $this;
	}

	public function setFinancialStatus(?FinancialStatus $financialStatus): self
	{
		$this->financialStatus = $financialStatus;
		return $this;
	}

	public function setBank(?Bank $bank): self
	{
		$this->bank = $bank;
		return $this;
	}

	public function setMarketingPreference(?MarketingPreference $marketingPreference): self
	{
		$this->marketingPreference = $marketingPreference;
		return $this;
	}

	public function setCompanyType(?string $companyType): self
	{
		$this->companyType = $companyType;
	}
}