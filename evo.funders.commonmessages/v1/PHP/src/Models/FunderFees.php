<?php

namespace AzureFunderCommonMessages\PHP\Models;

use AzureFunderCommonMessages\PHP\Traits\JsonSerializer;

class FunderFees implements \JsonSerializable
{
	use JsonSerializer;
	protected int $front;
	protected int $frontSpread;
	protected int $back;
	protected int $monthlyAddition;
	protected int $maxAdvance;
	protected bool $interestSpread;
	protected bool $frontSpecial;

	public function getFront(): int
	{
		return $this->front;
	}

	public function getFrontSpread(): int
	{
		return $this->frontSpread;
	}

	public function getBack(): int
	{
		return $this->back;
	}

	public function getMonthlyAddition(): int
	{
		return $this->monthlyAddition;
	}

	public function getMaxAdvance(): int
	{
		return $this->maxAdvance;
	}

	public function getInterestSpread(): bool
	{
		return $this->interestSpread;
	}

	public function getFrontSpecial(): bool
	{
		return $this->frontSpecial;
	}

	public function setFront(int $front): self
	{
		$this->front = $front;
		return $this;
	}

	public function setFrontSpread(int $frontSpread): self
	{
		$this->frontSpread = $frontSpread;
		return $this;
	}

	public function setBack(int $back): self
	{
		$this->back = $back;
		return $this;
	}

	public function setMonthlyAddition(int $monthlyAddition): self
	{
		$this->monthlyAddition = $monthlyAddition;
		return $this;
	}

	public function setMaxAdvance(int $maxAdvance): self
	{
		$this->maxAdvance = $maxAdvance;
		return $this;
	}

	public function setInterestSpread(bool $interestSpread): self
	{
		$this->interestSpread = $interestSpread;
		return $this;
	}

	public function setFrontSpecial(bool $frontSpecial): self
	{
		$this->frontSpecial = $frontSpecial;
		return $this;
	}
}