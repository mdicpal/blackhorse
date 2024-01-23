<?php

namespace AzureFunderCommonMessages\PHP\Response;

use AzureFunderCommonMessages\PHP\Traits\JsonSerializer;

class DocumentAvailable extends Response implements \JsonSerializable
{
	use JsonSerializer;

	public const INVOICE_DOCUMENT = "Invoice";
	public const PAYOUT_DOCUMENT = "PayoutDocument";

	private ?string $url;
	private ?string $message;
	private ?string $type;

	public static function fromJson(array $data): self
	{
		$instance = new self();
		$instance->url = $data['url'] ?? null;
		$instance->message = $data['message'] ?? null;
		$instance->type = $data['type'] ?? null;
		return $instance;
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
	 * @return DocumentAvailable
	 */
	public function setUrl(?string $url): DocumentAvailable
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
	 * @return DocumentAvailable
	 */
	public function setMessage(?string $message): DocumentAvailable
	{
		$this->message = $message;
		return $this;
	}

	/**
	 * @return string|null
	 */
	public function getType(): ?string
	{
		return $this->type;
	}

	/**
	 * @param string|null $type
	 * @return DocumentAvailable
	 */
	public function setType(?string $type): DocumentAvailable
	{
		$this->type = $type;
		return $this;
	}
}
