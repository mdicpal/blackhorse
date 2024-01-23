<?php

namespace AzureFunderCommonMessages\PHP\Models;

use AzureFunderCommonMessages\PHP\Traits\JsonSerializer;

class RawData implements \JsonSerializable
{
	use JsonSerializer;

	private ?string $type;
	private ?string $dataFormat;
	private ?string $timestamp;
	private ?string $rawData;

	/**
	 * @return string|null
	 */
	public function getType(): ?string
	{
		return $this->type;
	}

	/**
	 * @param string|null $type
	 * @return RawData
	 */
	public function setType(?string $type): RawData
	{
		$this->type = $type;
		return $this;
	}

	/**
	 * @return string|null
	 */
	public function getDataFormat(): ?string
	{
		return $this->dataFormat;
	}

	/**
	 * @param string|null $dataFormat
	 * @return RawData
	 */
	public function setDataFormat(?string $dataFormat): RawData
	{
		$this->dataFormat = $dataFormat;
		return $this;
	}

	/**
	 * @return string|null
	 */
	public function getTimestamp(): ?string
	{
		return $this->timestamp;
	}

	/**
	 * @param string|null $timestamp
	 * @return RawData
	 */
	public function setTimestamp(?string $timestamp): RawData
	{
		$this->timestamp = $timestamp;
		return $this;
	}

	/**
	 * @return string|null
	 */
	public function getRawData(): ?string
	{
		return json_encode(json_decode($this->rawData), JSON_PRETTY_PRINT) ?? $this->rawData;
	}

	/**
	 * @param string|null $rawData
	 * @return RawData
	 */
	public function setRawData(?string $rawData): RawData
	{
		$this->rawData = $rawData;
		return $this;
	}

	public static function fromJson(array $data): self
	{
		$instance = new self();
		$instance->type = $data['type'] ?? null;
		$instance->dataFormat = $data['dataFormat'] ?? null;
		$instance->timestamp = $data['timestamp'] ?? null;
		$instance->rawData = $data['rawData'] ?? null;
		return $instance;
	}
}
