<?php


namespace AzureFunderCommonMessages\PHP\Request;

use AzureFunderCommonMessages\PHP\Traits\JsonSerializer;

class ActivateQuote extends AbstractData implements \JsonSerializable
{
    use JsonSerializer;

    private string $funderApplicationId;
    private ?string $funderQuoteId;

    /**
     * @return int
     */
    public function getFunderApplicationId(): string
    {
        return $this->funderApplicationId;
    }

    /**
     * @param string $funderApplicationId
     * @return ActivateQuote
     */
    public function setFunderApplicationId(string $funderApplicationId): ActivateQuote
    {
        $this->funderApplicationId = $funderApplicationId;
        return $this;
    }

    /**
     * @return string
     */
    public function getFunderQuoteId(): ?string
    {
        return $this->funderQuoteId;
    }

    /**
     * @param string|null $funderQuoteId
     * @return ActivateQuote
     */
    public function setFunderQuoteId(?string $funderQuoteId): ActivateQuote
    {
        $this->funderQuoteId = $funderQuoteId;
        return $this;
    }

    public static function fromJson(array $data): self
    {
        $instance = new self();
        $instance->funderApplicationId = $data["funderApplicationId"];
        $instance->funderQuoteId = $data["funderQuoteId"];
    }
}