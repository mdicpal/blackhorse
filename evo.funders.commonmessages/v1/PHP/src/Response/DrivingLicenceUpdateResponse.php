<?php

namespace AzureFunderCommonMessages\PHP\Response;

use AzureFunderCommonMessages\PHP\Traits\JsonSerializer;

class DrivingLicenceUpdateResponse extends Response implements \JsonSerializable
{
	use JsonSerializer;

	public static function fromJson(array $data): self
	{
		$instance = new self();
		$instance->message = $data['message'] ?? null;
		$instance->status = $data['status'] ?? null;
		return $instance;
	}

	private ?string $message;
	private ?string $status;

	/**
	 * @return string|null
	 */
	public function getMessage(): ?string
	{
		return $this->message;
	}

	/**
	 * @param string|null $message
	 * @return DrivingLicenceUpdateResponse
	 */
	public function setMessage(?string $message): DrivingLicenceUpdateResponse
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
	 * @return DrivingLicenceUpdateResponse
	 */
	public function setStatus(?string $status): DrivingLicenceUpdateResponse
	{
		$this->status = $status;
		return $this;
	}

}
