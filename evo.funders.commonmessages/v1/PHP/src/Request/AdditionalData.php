<?php

namespace AzureFunderCommonMessages\PHP\Request;
use AzureFunderCommonMessages\PHP\Traits\JsonSerializer;

class AdditionalData extends AbstractData implements \JsonSerializable
{
	use JsonSerializer;
	protected array $additionalData = [];

	public function set(array $data): self
	{
		$this->additionalData = $data;
		return $this;
	}

	public function add($key, $value): self
	{
		$this->additionalData[$key] = $value;
		return $this;
	}

	public function remove($key): self
	{
		unset($this->additionalData[$key]);
		return $this;
	}

	public function get(): array
	{
		return $this->additionalData;
	}

}
