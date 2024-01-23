<?php


namespace AzureFunderCommonMessages\PHP\Request;


use AzureFunderCommonMessages\PHP\Traits\JsonSerializer;

class OpenBankingRequest extends AbstractData implements \JsonSerializable
{
    use JsonSerializer;

    private string $funderApplicationId;

    /**
     * @return string
     */
    public function getFunderApplicationId(): string
    {
        return $this->funderApplicationId;
    }

    /**
     * @param string $funderApplicationId
     * @return OpenBankingRequest
     */
    public function setFunderApplicationId(string $funderApplicationId): OpenBankingRequest
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