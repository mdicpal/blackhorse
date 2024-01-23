<?php


namespace AzureFunderCommonMessages\PHP\Models;

use AzureFunderCommonMessages\PHP\Traits\JsonSerializer;

class FunderReference implements \JsonSerializable
{
	use JsonSerializer;
	protected ?string $proposal;
	protected ?string $application;
	protected ?string $agreement;

	public function getProposal(): ?string
	{
		return $this->proposal;
	}

	public function getApplication(): ?string
	{
		return $this->application;
	}

	public function getAgreement(): ?string
	{
		return $this->agreement;
	}

	public function setProposal(?string $proposal): self
	{
		$this->proposal = $proposal;
		return $this;
	}

	public function setApplication(?string $application): self
	{
		$this->application = $application;
		return $this;
	}

	public function setAgreement(?string $agreement): self
	{
		$this->agreement = $agreement;
		return $this;
	}

	public static function fromJson(array $data): self
	{
		$instance = new self();
		$instance->setProposal($data['proposal'] ?? null);
		$instance->setApplication($data['application'] ?? null);
		$instance->setAgreement($data['agreement'] ?? null);
		return $instance;
	}
}