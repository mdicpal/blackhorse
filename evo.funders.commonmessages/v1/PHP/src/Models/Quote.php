<?php

namespace AzureFunderCommonMessages\PHP\Models;

use AzureFunderCommonMessages\PHP\Traits\JsonSerializer;

class Quote implements \JsonSerializable
{
	use JsonSerializer;
	protected bool $isBusinessQuote;
	protected ?string $quoteDate;
	protected ?int $annualMileage;
	protected ?float $partExchange;
	protected ?float $settlement;
	protected ?float $deposit;
	protected ?float $flatRate;
	protected ?int $term;
	protected ?float $vehicleCashPrice;
	protected ?bool $isVehicleVatQualifying;
	protected ?float $balloonValue;
	protected ?string $financeType;
	protected ?float $apr;
	protected bool $isDistanceSold;
	protected ?float $settlementMonthlyAmount;
	protected ?int $experianCountyCourtJudgments;
	protected ?int $experianDefaults;
	protected ?int $equifaxCountyCourtJudgments;
	protected ?int $equifaxDefaults;

	/**
	 * @return int|null
	 */
	public function getExperianCountyCourtJudgments(): ?int
	{
		return $this->experianCountyCourtJudgments;
	}

	/**
	 * @param int|null $experianCountyCourtJudgments
	 * @return Quote
	 */
	public function setExperianCountyCourtJudgments(?int $experianCountyCourtJudgments): Quote
	{
		$this->experianCountyCourtJudgments = $experianCountyCourtJudgments;
		return $this;
	}

	/**
	 * @return int|null
	 */
	public function getExperianDefaults(): ?int
	{
		return $this->experianDefaults;
	}

	/**
	 * @param int|null $experianDefaults
	 * @return Quote
	 */
	public function setExperianDefaults(?int $experianDefaults): Quote
	{
		$this->experianDefaults = $experianDefaults;
		return $this;
	}

	/**
	 * @return int|null
	 */
	public function getEquifaxCountyCourtJudgments(): ?int
	{
		return $this->equifaxCountyCourtJudgments;
	}

	/**
	 * @param int|null $equifaxCountyCourtJudgments
	 * @return Quote
	 */
	public function setEquifaxCountyCourtJudgments(?int $equifaxCountyCourtJudgments): Quote
	{
		$this->equifaxCountyCourtJudgments = $equifaxCountyCourtJudgments;
		return $this;
	}

	/**
	 * @return int|null
	 */
	public function getEquifaxDefaults(): ?int
	{
		return $this->equifaxDefaults;
	}

	/**
	 * @param int|null $equifaxDefaults
	 * @return Quote
	 */
	public function setEquifaxDefaults(?int $equifaxDefaults): Quote
	{
		$this->equifaxDefaults = $equifaxDefaults;
		return $this;
	}




	/**
	 * @return float|null
	 */
	public function getSettlementMonthlyAmount(): ?float
	{
		return $this->settlementMonthlyAmount;
	}

	/**
	 * @param float|null $settlementMonthlyAmount
	 * @return Quote
	 */
	public function setSettlementMonthlyAmount(?float $settlementMonthlyAmount): Quote
	{
		$this->settlementMonthlyAmount = $settlementMonthlyAmount;
		return $this;
	}

	public function getIsBusinessQuote(): ?bool
	{
		return $this->isBusinessQuote;
	}

	public function getIsDistanceSold(): ?bool
	{
		return $this->isDistanceSold;
	}

	public function getQuoteDate(): ?string
	{
		return $this->quoteDate;
	}

	public function getAnnualMileage(): ?int
	{
		return $this->annualMileage;
	}

	public function getPartExchange(): ?float
	{
		return $this->partExchange;
	}

	public function getSettlement(): ?float
	{
		return $this->settlement;
	}

	public function getDeposit(): ?float
	{
		return $this->deposit;
	}

	public function getFlatRate(): ?float
	{
		return $this->flatRate;
	}

	public function getTerm(): ?int
	{
		return $this->term;
	}

	public function getVehicleCashPrice(): ?float
	{
		return $this->vehicleCashPrice;
	}

	public function getIsVehicleVatQualifying(): ?bool
	{
		return $this->isVehicleVatQualifying;
	}

	public function getBalloonValue(): ?float
	{
		return $this->balloonValue;
	}

	public function getFinanceType(): ?string
	{
		return $this->financeType;
	}

	public function getApr(): ?float
	{
		return $this->apr;
	}

	public function setIsDistanceSold(bool $isDistanceSold): self
	{
		$this->isDistanceSold = $isDistanceSold;
		return $this;
	}

	public function setIsBusinessQuote(bool $isBusinessQuote): self
	{
		$this->isBusinessQuote = $isBusinessQuote;
		return $this;
	}

	public function setQuoteDate(?string $quoteDate): self
	{
		$this->quoteDate = $quoteDate;
		return $this;
	}

	public function setAnnualMileage(?int $annualMileage): self
	{
		$this->annualMileage = $annualMileage;
		return $this;
	}

	public function setPartExchange(?float $partExchange): self
	{
		$this->partExchange = $partExchange;
		return $this;
	}

	public function setSettlement(?float $settlement): self
	{
		$this->settlement = $settlement;
		return $this;
	}

	public function setDeposit(?float $deposit): self
	{
		$this->deposit = $deposit;
		return $this;
	}

	public function setFlatRate(?float $flatRate): self
	{
		$this->flatRate = $flatRate;
		return $this;
	}

	public function setTerm(?int $term): self
	{
		$this->term = $term;
		return $this;
	}

	public function setVehicleCashPrice(?float $vehicleCashPrice): self
	{
		$this->vehicleCashPrice = $vehicleCashPrice;
		return $this;
	}

	public function setIsVehicleVatQualifying(?bool $isVehicleVatQualifying): self
	{
		$this->isVehicleVatQualifying = $isVehicleVatQualifying;
		return $this;
	}

	public function setBalloonValue(?float $balloonValue): self
	{
		$this->balloonValue = $balloonValue;
		return $this;
	}

	public function setFinanceType(?string $financeType): self
	{
		$this->financeType = $financeType;
		return $this;
	}

	public function setApr(?float $apr): self
	{
		$this->apr = $apr;
		return $this;
	}

	public function getAdvance() {
		return ($this->getVehicleCashPrice() ?? 0) - ($this->getDeposit() ?? 0) - ($this->getPartExchange() ?? 0) + ($this->getSettlement() ?? 0);
	}
}