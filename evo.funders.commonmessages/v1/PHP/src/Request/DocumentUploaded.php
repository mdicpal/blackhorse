<?php


namespace AzureFunderCommonMessages\PHP\Request;


use AzureFunderCommonMessages\PHP\Models\SecureFiles;
use AzureFunderCommonMessages\PHP\Traits\JsonSerializer;

class DocumentUploaded extends AbstractData implements \JsonSerializable
{
	use JsonSerializer;

    /**
     * @var SecureFiles[]
     */
	private array $files;
	private ?string $message;
	private ?string $subject;
	private ?string $fromAddress;
	private ?array $toAddresses;

	/**
	 * @return SecureFiles[]
	 */
	public function getFiles(): array
	{
		return $this->files;
	}

	/**
	 * @param SecureFiles[] $files
	 * @return DocumentUploaded
	 */
	public function setFiles(array $files): DocumentUploaded
	{
		$this->files = $files;
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
	 * @return DocumentUploaded
	 */
	public function setMessage(?string $message): DocumentUploaded
	{
		$this->message = $message;
		return $this;
	}

	/**
	 * @return string|null
	 */
	public function getSubject(): ?string
	{
		return $this->subject;
	}

	/**
	 * @param string|null $subject
	 * @return DocumentUploaded
	 */
	public function setSubject(?string $subject): DocumentUploaded
	{
		$this->subject = $subject;
		return $this;
	}

	/**
	 * @return string|null
	 */
	public function getFromAddress(): ?string
	{
		return $this->fromAddress;
	}

	/**
	 * @param string|null $fromAddress
	 * @return DocumentUploaded
	 */
	public function setFromAddress(?string $fromAddress): DocumentUploaded
	{
		$this->fromAddress = $fromAddress;
		return $this;
	}

	/**
	 * @return array|null
	 */
	public function getToAddresses(): ?array
	{
		return $this->toAddresses;
	}

	/**
	 * @param array|null $toAddresses
	 * @return DocumentUploaded
	 */
	public function setToAddresses(?array $toAddresses): DocumentUploaded
	{
		$this->toAddresses = $toAddresses;
		return $this;
	}



	public static function fromJson(array $data): self
	{
		$instance = new self();
		$instance->files = $data['files'];
		$instance->message = $data['message'] ?? null;
		$instance->subject = $data['subject'] ?? null;
		$instance->fromAddress = $data['fromAddress'] ?? null;
		$instance->toAddresses = $data['toAddresses'] ?? null;
		return $instance;
	}
}