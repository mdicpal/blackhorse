<?php

namespace AzureFunderCommonMessages\PHP\Response;

use AzureFunderCommonMessages\PHP\Traits\JsonSerializer;

class EsignResponse extends Response implements \JsonSerializable
{
	use JsonSerializer;

	public static function fromJson(array $data): self
	{
		$instance = new self();
		$instance->url = $data['url'] ?? null;
		$instance->urlRequired = $data['urlRequired'] ?? true;
		$instance->message = $data['message'] ?? null;
		$instance->status = $data['status'] ?? null;
		return $instance;
	}

	private ?string $url;
	private ?bool $urlRequired = true;
	private ?string $message;
	private ?string $status;

	/**
	 * @return bool|null
	 */
	public function getUrlRequired(): ?bool
	{
		return $this->urlRequired;
	}

	/**
	 * @param bool|null $urlRequired
	 * @return EsignResponse
	 */
	public function setUrlRequired(?bool $urlRequired): EsignResponse
	{
		$this->urlRequired = $urlRequired;
		return $this;
	}

	/**
	 * @return string|null
	 */
	public function getUrl(): ?string
	{
		return $this->url;
	}

	/**
	 * @param string|null $url
	 * @return EsignResponse
	 */
	public function setUrl(?string $url): EsignResponse
	{
		$this->url = $url;
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
