<?php


namespace AzureFunderCommonMessages\PHP\Request;

use AzureFunderCommonMessages\PHP\Traits\JsonSerializer;

class CancelApplicationRequest extends AbstractData implements \JsonSerializable
{
    use JsonSerializer;

    private ?string $funderApplicationId;

    /**
     * @return string|null
     */
    public function getFunderApplicationId(): ?string
    {
        return $this->funderApplicationId;
    }

    /**
     * @param string|null $funderApplicationId
     * @return CancelApplicationRequest
     */
    public function setFunderApplicationId(?string $funderApplicationId): CancelApplicationRequest
    {
        $this->funderApplicationId = $funderApplicationId;
        return $this;
    }

    public static function fromJson(array $data): self
    {
        $instance = new self();
        $instance->funderApplicationId = $data["funderApplicationId"];
    }

}