<?php

namespace AzureFunderCommonMessages\PHP\Response;

use AzureFunderCommonMessages\PHP\Traits\JsonSerializer;

class GuaranteedFutureValueResponse extends Response implements \JsonSerializable
{
	use JsonSerializer;

	private ?float $guaranteedFutureValue;

	public static function fromJson(array $data): self
	{
		$instance = new self();
		$instance->setGuaranteedFutureValue($data['guaranteedFutureValue'] ?? null);
		return $instance;
	}

	/**
	 * @return float|null
	 */
	public function getGuaranteedFutureValue(): ?float
	{
		return $this->guaranteedFutureValue;
	}

	/**
	 * @param float|null $guaranteedFutureValue
	 * @return GuaranteedFutureValueResponse
	 */
	public function setGuaranteedFutureValue(?float $guaranteedFutureValue): GuaranteedFutureValueResponse
	{
		$this->guaranteedFutureValue = $guaranteedFutureValue;
		return $this;
	}


}
