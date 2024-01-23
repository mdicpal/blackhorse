<?php

namespace AzureFunderCommonMessages\PHP\Models;

use AzureFunderCommonMessages\PHP\Traits\JsonSerializer;

class FinancialStatus implements \JsonSerializable
{
	use JsonSerializer;
	protected ?int $annualGrossIncome;
	protected ?string $affordability;
	protected ?string $affordabilityReason;
	protected ?int $affordabilityMonthlyMortgageRentContribution;
	protected ?int $affordabilityMonthlyOtherExpenditure;
	protected ?float $netMonthlyIncome;

	public function getAnnualGrossIncome(): ?int
	{
		return $this->annualGrossIncome;
	}

	public function getAffordability(): ?string
	{
		return $this->affordability;
	}

	public function getAffordabilityReason(): ?string
	{
		return $this->affordabilityReason;
	}

	public function getAffordabilityMonthlyMortgageRentContribution(): ?int
	{
		return $this->affordabilityMonthlyMortgageRentContribution;
	}

	public function getAffordabilityMonthlyOtherExpenditure(): ?int
	{
		return $this->affordabilityMonthlyOtherExpenditure;
	}

	public function getNetMonthlyIncome(): ?float
	{
		return $this->netMonthlyIncome;
	}

	public function setAnnualGrossIncome(?int $annualGrossIncome): self
	{
		$this->annualGrossIncome = $annualGrossIncome;
		return $this;
	}

	public function setAffordability(?string $affordability): self
	{
		$this->affordability = $affordability;
		return $this;
	}

	public function setAffordabilityReason(?string $affordabilityReason): self
	{
		$this->affordabilityReason = $affordabilityReason;
		return $this;
	}

	public function setAffordabilityMonthlyMortgageRentContribution(?int $affordabilityMonthlyMortgageRentContribution): self
	{
		$this->affordabilityMonthlyMortgageRentContribution = $affordabilityMonthlyMortgageRentContribution;
		return $this;
	}

	public function setAffordabilityMonthlyOtherExpenditure(?int $affordabilityMonthlyOtherExpenditure): self
	{
		$this->affordabilityMonthlyOtherExpenditure = $affordabilityMonthlyOtherExpenditure;
		return $this;
	}

	public function setNetMonthlyIncome(?float $netMonthlyIncome): self
	{
		$this->netMonthlyIncome = $netMonthlyIncome;
		return $this;
	}
}
