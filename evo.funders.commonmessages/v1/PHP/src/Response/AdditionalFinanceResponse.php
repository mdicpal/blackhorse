<?php

namespace AzureFunderCommonMessages\PHP\Response;

use AzureFunderCommonMessages\PHP\Models\AdditionalFinanceItem;
use AzureFunderCommonMessages\PHP\Models\DocumentRequest;
use AzureFunderCommonMessages\PHP\Traits\JsonSerializer;

class AdditionalFinanceResponse extends Response implements \JsonSerializable
{
	use JsonSerializer;

	private array $financeItems = [];

	/**
	 * @return AdditionalFinanceItem[]
	 */
	public function getFinanceItems(): array
	{
		return $this->financeItems;
	}

	/**
	 * @param AdditionalFinanceItem[] $financeItems
	 * @return AdditionalFinanceResponse
	 */
	public function setFinanceItems(array $financeItems): AdditionalFinanceResponse
	{
		$this->financeItems = $financeItems;
		return $this;
	}



	public static function fromJson(array $data): self
	{
		$instance = new self();
		array_walk($data['financeItems'], function(&$financeItem){ $financeItem = AdditionalFinanceItem::fromJson($financeItem); });
		$instance->financeItems = $data['financeItems'] ?? [];
		return $instance;
	}
}

;
