<?php

namespace AzureFunderCommonMessages\PHP\Request;

use AzureFunderCommonMessages\PHP\Traits\JsonSerializer;

class CommonRequest implements \JsonSerializable
{
	use JsonSerializer;
	protected string $requestType;
	protected int $quoteId;
	protected string $funderCode;
	protected int $version = 1;
	protected AbstractData $data;

	public function getRequestType(): string
	{
		return $this->requestType;
	}

	public function getQuoteId(): int
	{
		return $this->quoteId;
	}

	public function getFunderCode(): string
	{
		return $this->funderCode;
	}

	public function getVersion(): int
	{
		return $this->version;
	}

	public function getData(): AbstractData
	{
		return $this->data;
	}

	public function setRequestType(string $requestType): self
	{
		$this->requestType = $requestType;
		return $this;
	}

	public function setQuoteId(int $quoteId): self
	{
		$this->quoteId = $quoteId;
		return $this;
	}

	public function setFunderCode(string $funderCode): self
	{
		$this->funderCode = $funderCode;
		return $this;
	}

	public function setVersion(int $version): self
	{
		$this->version = $version;
		return $this;
	}

	public function setData(AbstractData $data): self
	{
		$this->data = $data;
		return $this;
	}
}