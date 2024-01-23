<?php

namespace AzureFunderCommonMessages\PHP\Request;

use AzureFunderCommonMessages\PHP\Traits\JsonSerializer;

abstract class AbstractData implements \JsonSerializable
{
	use JsonSerializer;
}