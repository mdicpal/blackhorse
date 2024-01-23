<?php

namespace AzureFunderCommonMessages\PHP\Response;

use AzureFunderCommonMessages\PHP\Traits\JsonSerializer;

class EsignCompletedResponse extends Response implements \JsonSerializable
{
	use JsonSerializer;
	
	private ?string $message;
	private ?string $status;
	private ?array $errors;

	public static function fromJson(array $data): self
	{
		$instance = new self();
		$instance->message = $data['message'] ?? null;
		$instance->status = $data['status'] ?? null;
		$instance->errors = $data['errors'] ?? [];
		return $instance;
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
	 * @return self
	 */
	public function setMessage(?string $message): self
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
	 * @return self
	 */
	public function setStatus(?string $status): self
	{
		$this->status = $status;
		return $this;
	}

	/**
	 * @return array|null
	 */
	public function getErrors(): ?array
	{
		return $this->errors;
	}

	/**
	 * @param array|null $errors
	 * @return Error
	 */
	public function setErrors(?array $errors): self
	{
		$this->errors = $errors;
		return $this;
	}

}
