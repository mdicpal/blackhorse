<?php

namespace AzureFunderCommonMessages\PHP\Response;

use AzureFunderCommonMessages\PHP\Traits\JsonSerializer;

class InvoiceAddressResponse extends Response implements \JsonSerializable
{
	use JsonSerializer;

	private ?string $addressReference;
	private ?string $message;
	private ?string $status;

    /**
     * @return string|null
     */
    public function getAddressReference(): ?string
    {
        return $this->addressReference;
    }

    /**
     * @param string|null $addressReference
     * @return InvoiceAddressResponse
     */
    public function setAddressReference(?string $addressReference): InvoiceAddressResponse
    {
        $this->addressReference = $addressReference;
        return $this;
    }

    /**
     * @return string|null
     */
    public function getMessage(): ?string
    {
        return $this->message;
    }

    /**
     * @param string|null $message
     * @return InvoiceAddressResponse
     */
    public function setMessage(?string $message): InvoiceAddressResponse
    {
        $this->message = $message;
        return $this;
    }

    /**
     * @return string|null
     */
    public function getStatus(): ?string
    {
        return $this->status;
    }

    /**
     * @param string|null $status
     * @return InvoiceAddressResponse
     */
    public function setStatus(?string $status): InvoiceAddressResponse
    {
        $this->status = $status;
        return $this;
    }



    public static function fromJson(array $data): self
    {
        $instance = new self();
        $instance->addressReference = $data['addressReference'] ?? null;
        $instance->message = $data['message'] ?? null;
        $instance->status = $data['status'] ?? null;
        return $instance;
    }

}
