<?php

namespace AzureFunderCommonMessages\PHP\Models;

use AzureFunderCommonMessages\PHP\Traits\JsonSerializer;

class DispersalOptions implements \JsonSerializable
{
	use JsonSerializer;
	protected ?string $name;
	protected ?int $amount;
	protected ?bool $isVatable;

	public function getName(): ?string
	{
		return $this->name;
	}

	public function getAmount(): ?int
	{
		return $this->amount;
	}

	public function getIsVatable(): ?bool
	{
		return $this->isVatable;
	}

	public function setName(?string $name): self
	{
		$this->name = $name;
		return $this;
	}

	public function setAmount(?int $amount): self
	{
		$this->amount = $amount;
		return $this;
	}

	public function setIsVatable(?bool $isVatable): self
	{
		$this->isVatable = $isVatable;
		return $this;
	}
}
