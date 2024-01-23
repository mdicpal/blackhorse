<?php

namespace AzureFunderCommonMessages\PHP\Response;

use AzureFunderCommonMessages\PHP\Traits\JsonSerializer;

class StatusResponse extends Response implements \JsonSerializable
{
	use JsonSerializer;

	const APPLICATION_WITH_FUNDER = "Application with funder";

	public static function fromJson(array $data): self
	{
		$instance = new self();
		$instance->status = $data['status'] ?? null;
		$instance->applicationStatus = $data['applicationStatus'] ?? null;
		$instance->message = $data['message'] ?? null;
		$instance->messages = $data['messages'] ?? [];
		$instance->conditions = $data['conditions'] ?? [];
		$instance->snags = $data['snags'] ?? [];
		$instance->advance = $data['advance'] ?? null;
		$instance->term = $data['term'] ?? null;
		$instance->setFlatRate($data['flatRate'] ?? null);
		$instance->apr = $data['apr'] ?? null;
		$instance->firstPayment = $data['firstPayment'] ?? null;
		$instance->regularPayment = $data['regularPayment'] ?? null;
		$instance->finalPayment = $data['finalPayment'] ?? null;
		$instance->balloonValue = $data['balloonValue'] ?? null;
		$instance->tier = $data['tier'] ?? null;
		$instance->upfrontFee = $data['upfrontFee'] ?? null;
		$instance->expiryDate = $data['expiryDate'] ?? null;
		$instance->totalAmountRepayable = $data['totalAmountRepayable'] ?? null;
		$instance->payoutStatus = $data['payoutStatus'] ?? null;
		return $instance;
	}

	private ?string $message;
	private ?string $status;

	private ?string $applicationStatus;
	private ?string $payoutStatus;

	private array $messages;
	private array $conditions;
	private array $snags;

	private ?float $advance;
	private ?int $term;
	private ?float $flatRate;
	private ?float $apr;
	private ?float $firstPayment;
	private ?float $regularPayment;
	private ?float $finalPayment;
	private ?float $balloonValue;
	private ?string $tier;
	private ?float $upfrontFee;
	private ?string $expiryDate;
	private ?float $totalAmountRepayable;

	/**
	 * @return float|null
	 */
	public function getUpfrontFee(): ?float
	{
		return $this->upfrontFee;
	}

	/**
	 * @param float|null $upfrontFee
	 * @return StatusResponse
	 */
	public function setUpfrontFee(?float $upfrontFee): StatusResponse
	{
		$this->upfrontFee = $upfrontFee;
		return $this;
	}

	/**
	 * @return string|null
	 */
	public function getExpiryDate(): ?string
	{
		return $this->expiryDate;
	}

	/**
	 * @param string|null $expiryDate
	 * @return StatusResponse
	 */
	public function setExpiryDate(?string $expiryDate): StatusResponse
	{
		$this->expiryDate = $expiryDate;
		return $this;
	}

	/**
	 * @return float|null
	 */
	public function getTotalAmountRepayable(): ?float
	{
		return $this->totalAmountRepayable;
	}

	/**
	 * @param float|null $totalAmountRepayable
	 * @return StatusResponse
	 */
	public function setTotalAmountRepayable(?float $totalAmountRepayable): StatusResponse
	{
		$this->totalAmountRepayable = $totalAmountRepayable;
		return $this;
	}

/**
 * @return string
 */
public function getApplicationStatus(): string
{
	return $this->applicationStatus ?? "";
}

/**
 * @param string $applicationStatus
 */
public function setApplicationStatus(string $applicationStatus): self
{
	$this->applicationStatus = $applicationStatus;
	return $this;
}

/**
 * @return string[]
 */
public function getSnags(): array
{
	return $this->snags ?? [];
}

/**
 * @param string[] $snags
 */
public function setSnags(array $snags): self
{
	$this->snags = $snags;
	return $this;
}

	/**
	 * @return float|null
	 */
	public function getAdvance(): ?float
	{
		return $this->advance;
	}

	/**
	 * @param float|null $advance
	 * @return StatusResponse
	 */
	public function setAdvance(?float $advance): StatusResponse
	{
		$this->advance = $advance;
		return $this;
	}

	/**
	 * @return int|null
	 */
	public function getTerm(): ?int
	{
		return $this->term;
	}

	/**
	 * @param int|null $term
	 * @return StatusResponse
	 */
	public function setTerm(?int $term): StatusResponse
	{
		$this->term = $term;
		return $this;
	}

	/**
	 * @return float|null
	 */
	public function getFlatRate(): ?float
	{
		return $this->flatRate;
	}

	/**
	 * @param float|null $flatRate
	 * @return StatusResponse
	 */
	public function setFlatRate($flatRate): StatusResponse
	{
		$this->flatRate = is_numeric($flatRate) ? $flatRate : null;
		return $this;
	}

	/**
	 * @return float|null
	 */
	public function getApr(): ?float
	{
		return $this->apr;
	}

	/**
	 * @param float|null $apr
	 * @return StatusResponse
	 */
	public function setApr(?float $apr): StatusResponse
	{
		$this->apr = $apr;
		return $this;
	}

	/**
	 * @return float|null
	 */
	public function getFirstPayment(): ?float
	{
		return $this->firstPayment;
	}

	/**
	 * @param float|null $firstPayment
	 * @return StatusResponse
	 */
	public function setFirstPayment(?float $firstPayment): StatusResponse
	{
		$this->firstPayment = $firstPayment;
		return $this;
	}

	/**
	 * @return float|null
	 */
	public function getRegularPayment(): ?float
	{
		return $this->regularPayment;
	}

	/**
	 * @param float|null $regularPayment
	 * @return StatusResponse
	 */
	public function setRegularPayment(?float $regularPayment): StatusResponse
	{
		$this->regularPayment = $regularPayment;
		return $this;
	}

	/**
	 * @return float|null
	 */
	public function getFinalPayment(): ?float
	{
		return $this->finalPayment;
	}

	/**
	 * @param float|null $finalPayment
	 * @return StatusResponse
	 */
	public function setFinalPayment(?float $finalPayment): StatusResponse
	{
		$this->finalPayment = $finalPayment;
		return $this;
	}

	/**
	 * @return float|null
	 */
	public function getBalloonValue(): ?float
	{
		return $this->balloonValue;
	}

	/**
	 * @param float|null $balloonValue
	 * @return StatusResponse
	 */
	public function setBalloonValue(?float $balloonValue): StatusResponse
	{
		$this->balloonValue = $balloonValue;
		return $this;
	}

	/**
	 * @return string|null
	 */
	public function getTier(): ?string
	{
		return $this->tier;
	}

	/**
	 * @param string|null $tier
	 * @return StatusResponse
	 */
	public function setTier(?string $tier): StatusResponse
	{
		$this->tier = $tier;
		return $this;
	}



	/**
	 * @return string[]
	 */
	public function getMessages()
	{
		return $this->messages ?? [];
	}

	/**
	 * @return string[]
	 */
	public function getConditions()
	{
		return $this->conditions ?? [];
	}

	/**
	 * @param string[] $conditions
	 * @return StatusResponse
	 */
	public function setConditions(array $conditions): StatusResponse
	{
		$this->conditions = $conditions;
		return $this;
	}

	/**
	 * @param string[] $messages
	 * @return StatusResponse
	 */
	public function setMessages(array $messages): StatusResponse
	{
		$this->messages = $messages;
		return $this;
	}

	/**
	 * @return string|null
	 */
	public function getMessage(): ?string
	{
		return $this->message;
	}

    /**
     * @param string|null $message
     * @return StatusResponse
     */
	public function setMessage(?string $message): StatusResponse
	{
		$this->message = $message;
		return $this;
	}

	/**
	 * @return string|null
	 */
	public function getStatus(): ?string
	{
		return $this->status;
	}

	/**
	 * @param string $status
	 * @return StatusResponse
	 */
	public function setStatus(?string $status): StatusResponse
	{
		$this->status = $status;
		return $this;
	}

	/**
	 * @return string|null
	 */
	public function getPayoutStatus(): ?string
	{
		return $this->payoutStatus;
	}

	/**
	 * @param string|null $payoutStatus
	 * @return StatusResponse
	 */
	public function setPayoutStatus(?string $payoutStatus): StatusResponse
	{
		$this->payoutStatus = $payoutStatus;
		return $this;
	}



}

;
