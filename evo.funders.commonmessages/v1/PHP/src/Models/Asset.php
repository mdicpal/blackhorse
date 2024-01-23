<?php

namespace AzureFunderCommonMessages\PHP\Models;

use AzureFunderCommonMessages\PHP\Traits\JsonSerializer;

class Asset implements \JsonSerializable
{
	use JsonSerializer;
	protected ?bool $isCreditLimitVehicle = false;
	protected ?string $make;
	protected ?string $model;
	protected ?string $style;
	protected ?string $assetType;
	protected ?bool $isNew;
	protected ?string $vrm;
	protected ?string $vin;
	protected ?string $capCode;
	protected ?int $currentMileage;
	protected ?string $registrationDate;
	protected ?string $bikeCc;

	/**
	 * @param bool|null $isCreditLimitVehicle
	 * @return Asset
	 */
	public function setIsCreditLimitVehicle(?bool $isCreditLimitVehicle) : Asset
	{
		$this->isCreditLimitVehicle = $isCreditLimitVehicle;
		return $this;
	}

	/**
	 * @return bool
	 */
	public function getIsCreditLimitVehicle(): bool 
	{
		return $this->getIsCreditLimitVehicle ?? false;
	}

    /**
     * @return string|null
     */
    public function getBikeCc(): ?string
    {
        return $this->bikeCc;
    }

    /**
     * @param string|null $bikeCc
     * @return Asset
     */
    public function setBikeCc(?string $bikeCc): Asset
    {
        $this->bikeCc = $bikeCc;
        return $this;
    }


	public function getMake(): ?string
	{
		return $this->make;
	}

	public function getModel(): ?string
	{
		return $this->model;
	}

	public function getStyle(): ?string
	{
		return $this->style;
	}

	public function getAssetType(): ?string
	{
		return $this->assetType;
	}

	public function getIsNew(): ?bool
	{
		return $this->isNew;
	}

	public function getVrm(): ?string
	{
		return $this->vrm;
	}

	public function getVin(): ?string
	{
		return $this->vin;
	}

	public function getCapCode(): ?string
	{
		return $this->capCode;
	}

	public function getCurrentMileage(): ?int
	{
		return $this->currentMileage;
	}

	public function getRegistrationDate(): ?string
	{
		return $this->registrationDate;
	}

	public function setMake(?string $make): self
	{
		$this->make = $make;
		return $this;
	}

	public function setModel(?string $model): self
	{
		$this->model = $model;
		return $this;
	}

	public function setStyle(?string $style): self
	{
		$this->style = $style;
		return $this;
	}

	public function setAssetType(?string $assetType): self
	{
		$this->assetType = $assetType;
		return $this;
	}

	public function setIsNew(?bool $isNew): self
	{
		$this->isNew = $isNew;
		return $this;
	}

	public function setVrm(?string $vrm): self
	{
		$this->vrm = $vrm;
		return $this;
	}

	public function setVin(?string $vin): self
	{
		$this->vin = $vin;
		return $this;
	}

	public function setCapCode(?string $capCode): self
	{
		$this->capCode = $capCode;
		return $this;
	}

	public function setCurrentMileage(?int $currentMileage): self
	{
		$this->currentMileage = $currentMileage;
		return $this;
	}

	public function setRegistrationDate(?string $registrationDate): self
	{
		$this->registrationDate = $registrationDate;
		return $this;
	}
}