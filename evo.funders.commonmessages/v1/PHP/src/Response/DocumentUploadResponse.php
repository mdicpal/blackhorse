<?php

namespace AzureFunderCommonMessages\PHP\Response;

use AzureFunderCommonMessages\PHP\Traits\JsonSerializer;

class DocumentUploadResponse extends Response implements \JsonSerializable
{
	use JsonSerializer;

	public static function fromJson(array $data): self
	{
		$instance = new self();
		$instance->documents = $data['documents'] ?? null;
		$instance->message = $data['message'] ?? null;
		$instance->status = $data['status'] ?? null;
		$instance->errors = $data['errors'] ?? null;
		return $instance;
	}

	private ?array $documents;
	private ?string $message;
	private ?string $status;
	private ?array $errors;

	public function getDocuments():?array
	{
		return $this->documents;
	}

	public function getMessage():?string
	{
		return $this->message;
	}

	public function getStatus():?string
	{
		return $this->status;
	}

	public function getErrors():?array
	{
		return $this->errors;
	}
}
