<?php

namespace AzureFunderCommonMessages\PHP\Models;

use AzureFunderCommonMessages\PHP\Traits\JsonSerializer;


class Dealer implements \JsonSerializable
{
	use JsonSerializer;
	protected ?string $dealerId = null;
	protected ?string $groupId = null;
	protected ?string $dealerCode = null;
	protected ?string $dealerGroupCode = null;
	protected bool $isMccWeblead = false;
	protected ?string $commissionType = null;
	protected ?string $dealerPackageCode = null;
	protected ?string $comparisonProvider = null;

	public function getDealerId(): string
	{
		return $this->dealerId;
	}

	public function getGroupId(): string
	{
		return $this->groupId;
	}

	public function getDealerCode(): ?string
	{
		return $this->dealerCode;
	}

	public function getDealerGroupCode(): ?string
	{
		return $this->dealerGroupCode;
	}

	public function getIsMccWeblead(): bool
	{
		return $this->isMccWeblead;
	}

	public function getCommissionType(): string
	{
		return $this->commissionType;
	}

	public function getDealerPackageCode(): string
	{
		return $this->dealerPackageCode;
	}

	public function setDealerId(string $dealerId): self
	{
		$this->dealerId = $dealerId;
		return $this;
	}

	public function setGroupId(string $groupId): self
	{
		$this->groupId = $groupId;
		return $this;
	}

	public function setDealerCode(?string $dealerCode): self
	{
		$this->dealerCode = $dealerCode;
		return $this;
	}

	public function setDealerGroupCode(?string $dealerGroupCode): self
	{
		$this->dealerGroupCode = $dealerGroupCode;
		return $this;
	}

	public function setIsMccWeblead(bool $isMccWeblead): self
	{
		$this->isMccWeblead = $isMccWeblead;
		return $this;
	}

	public function setCommissionType(string $commissionType): self
	{
		$this->commissionType = $commissionType;
		return $this;
	}

	public function setDealerPackageCode(string $dealerPackageCode): self
	{
		$this->dealerPackageCode = $dealerPackageCode;
		return $this;
	}

    /**
     * @return string|null
     */
    public function getComparisonProvider(): ?string
    {
        return $this->comparisonProvider;
    }

    /**
     * @param string|null $comparisonProvider
     * @return Dealer
     */
    public function setComparisonProvider(?string $comparisonProvider): Dealer
    {
        $this->comparisonProvider = $comparisonProvider;
        return $this;
    }

}
