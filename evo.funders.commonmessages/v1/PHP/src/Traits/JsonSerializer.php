<?php

namespace AzureFunderCommonMessages\PHP\Traits;

trait JsonSerializer {

	public function jsonSerialize(): array
	{
		return get_object_vars($this);
	}

	public function __toString()
	{
		return json_encode($this);
	}
}