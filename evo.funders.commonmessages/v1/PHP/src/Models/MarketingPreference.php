<?php

namespace AzureFunderCommonMessages\PHP\Models;

use AzureFunderCommonMessages\PHP\Traits\JsonSerializer;

class MarketingPreference implements \JsonSerializable
{
	use JsonSerializer;
	protected bool $optInEmail;
	protected bool $optInSms;
	protected bool $optInPhone;
	protected bool $optInPost;

	public function getOptInEmail(): bool
	{
		return $this->optInEmail;
	}

	public function getOptInSms(): bool
	{
		return $this->optInSms;
	}

	public function getOptInPhone(): bool
	{
		return $this->optInPhone;
	}

	public function getOptInPost(): bool
	{
		return $this->optInPost;
	}

	public function setOptInEmail(bool $optInEmail): self
	{
		$this->optInEmail = $optInEmail;
		return $this;
	}

	public function setOptInSms(bool $optInSms): self
	{
		$this->optInSms = $optInSms;
		return $this;
	}

	public function setOptInPhone(bool $optInPhone): self
	{
		$this->optInPhone = $optInPhone;
		return $this;
	}

	public function setOptInPost(bool $optInPost): self
	{
		$this->optInPost = $optInPost;
		return $this;
	}
}
