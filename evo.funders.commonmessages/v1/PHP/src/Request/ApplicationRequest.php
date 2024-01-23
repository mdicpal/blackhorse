<?php

namespace AzureFunderCommonMessages\PHP\Request;

use AzureFunderCommonMessages\PHP\Traits\JsonSerializer;
use AzureFunderCommonMessages\PHP\Models\{
	FunderFees,
	Applicant,
	Dealer,
	Quote,
	Asset,
	DispersalOptions
};

class ApplicationRequest extends AbstractData implements \JsonSerializable
{
	use JsonSerializer;

	/** @var FunderFees[]|null */
	protected ?array $funderFees;
	/** @var Applicant[] */
	protected array $applicants;
	protected ?Dealer $dealer;
	protected ?Quote $quote;
	protected ?Asset $asset;
	/** @var DispersalOptions[]|null */
	protected ?array $dispersalOptions;

	/**
	 * @return FunderFees[]|null
	 */
	public function getFunderFees(): ?array
	{
		return $this->funderFees;
	}

	/**
	 * @return Applicant[]|null
	 */
	public function getApplicants(): ?array
	{
		return $this->applicants;
	}

	public function getDealer(): ?Dealer
	{
		return $this->dealer;
	}

	public function getQuote(): ?Quote
	{
		return $this->quote;
	}

	public function getAsset(): ?Asset
	{
		return $this->asset;
	}

	/**
	 * @return DispersalOptions[]|null
	 */
	public function getDispersalOptions(): ?array
	{
		return $this->dispersalOptions;
	}

	/**
	 * @param FunderFees[]|null $funderFees
	 */
	public function setFunderFees(?array $funderFees): self
	{
		$this->funderFees = $funderFees;
		return $this;
	}

	/**
	 * @param Applicant[] $applicants
	 */
	public function setApplicants(array $applicants): self
	{
		$this->applicants = $applicants;
		return $this;
	}

	public function setDealer(?Dealer $dealer): self
	{
		$this->dealer = $dealer;
		return $this;
	}

	public function setQuote(?Quote $quote): self
	{
		$this->quote = $quote;
		return $this;
	}

	public function setAsset(?Asset $asset): self
	{
		$this->asset = $asset;
		return $this;
	}

	/**
	 * @param DispersalOptions[]|null $dispersalOptions
	 */
	public function setDispersalOptions(?array $dispersalOptions): self
	{
		$this->dispersalOptions = $dispersalOptions;
		return $this;
	}
}
