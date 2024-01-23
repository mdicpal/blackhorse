<?php

namespace AzureFunderCommonMessages\PHP\Response;

use AzureFunderCommonMessages\PHP\Traits\JsonSerializer;

class EnhancedBankingResponse extends Response implements \JsonSerializable
{
    use JsonSerializer;

    public static function fromJson(array $data): self
    {
        $instance = new self();
        $instance->message = $data['message'] ?? null;
		$instance->status = $data['status'] ?? null;
		$instance->errors = $data['errors'] ?? null;
        return $instance;
    }

	private ?string $message;
	private ?array $errors;
	private ?string $status;

	/**
	 * @return array|null
	 */
	public function getErrors(): ?array
	{
		return $this->errors;
	}

	/**
	 * @param array|null $errors
	 */
	public function setErrors(?array $errors): void
	{
		$this->errors = $errors;
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
	 */
	public function setStatus(?string $status): void
	{
		$this->status = $status;
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
     * @return GenericResponse
     */
    public function setMessage(?string $message): GenericResponse
    {
        $this->message = $message;
        return $this;
    }
}