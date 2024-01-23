<?php

namespace AzureFunderCommonMessages\PHP\Response;

use AzureFunderCommonMessages\PHP\Traits\JsonSerializer;

class GenericResponse extends Response implements \JsonSerializable
{
    use JsonSerializer;

    public static function fromJson(array $data): self
    {
        $instance = new self();
        $instance->response = $data['response'] ?? null;
        $instance->message = $data['message'] ?? null;
		$instance->status = $data['status'] ?? null;
		$instance->errors = $data['errors'] ?? null;
        return $instance;
    }

    private ?string $response;
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
    public function getResponse(): ?string
    {
        return $this->response;
    }

    /**
     * @param string|null $response
     */
    public function setResponse(?string $response): void
    {
        $this->response = $response;
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