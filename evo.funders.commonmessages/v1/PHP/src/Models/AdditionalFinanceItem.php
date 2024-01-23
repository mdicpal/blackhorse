<?php

namespace AzureFunderCommonMessages\PHP\Models;

use AzureFunderCommonMessages\PHP\Traits\JsonSerializer;

class AdditionalFinanceItem implements \JsonSerializable
{
	use JsonSerializer;

	private ?string $label;
	private ?string $value;

	/**
	 * @return string|null
	 */
	public function getLabel(): ?string
	{
		return $this->label;
	}

	/**
	 * @param string|null $label
	 * @return AdditionalFinanceItem
	 */
	public function setLabel(?string $label): AdditionalFinanceItem
	{
		$this->label = $label;
		return $this;
	}

	/**
	 * @return string|null
	 */
	public function getValue(): ?string
	{
		return $this->value;
	}

	/**
	 * @param string|null $value
	 * @return AdditionalFinanceItem
	 */
	public function setValue(?string $value): AdditionalFinanceItem
	{
		$this->value = $value;
		return $this;
	}

	public static function fromJson(array $data): self
	{
		$instance = new self();
		$instance->label = $data['label'] ?? null;
		$instance->value = $data['value'] ?? null;
		return $instance;
	}

}