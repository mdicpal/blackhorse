<?php

namespace AzureFunderCommonMessages\PHP\Response;

use AzureFunderCommonMessages\PHP\Traits\JsonSerializer;

class OpenBankingResponse extends Response implements \JsonSerializable
{
	use JsonSerializer;

	public static function fromJson(array $data): self
	{
		$instance = new self();
		$instance->uri = $data['uri'] ?? null;
		$instance->message = $data['message'] ?? null;
		$instance->status = $data['status'] ?? null;
		return $instance;
	}

	private ?string $uri;
	private ?string $message;
	private ?string $status;

	/**
	 * @return string|null
	 */
	public function getUri(): ?string
	{
		return $this->uri;
	}

	/**
	 * @param string|null $uri
	 * @return EsignResponse
	 */
	public function setUri(?string $uri): EsignResponse
	{
		$this->uri = $uri;
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
	 * @return EsignResponse
	 */
	public function setMessage(?string $message): EsignResponse
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
	 * @param string|null $status
	 * @return EsignResponse
	 */
	public function setStatus(?string $status): EsignResponse
	{
		$this->status = $status;
		return $this;
	}

}
