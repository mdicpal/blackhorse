<?php

namespace AzureFunderCommonMessages\PHP\Response;

use AzureFunderCommonMessages\PHP\Traits\JsonSerializer;

class Response implements \JsonSerializable
{
	use JsonSerializer;

	public static function fromJson(array $data): self
	{
		$instance = new self();
		$instance->raw = $data;
		return $instance;
	}
}
