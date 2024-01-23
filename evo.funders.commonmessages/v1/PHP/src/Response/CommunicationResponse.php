<?php

namespace AzureFunderCommonMessages\PHP\Response;

use AzureFunderCommonMessages\PHP\Traits\JsonSerializer;

class CommunicationResponse extends Response implements \JsonSerializable
{
    use JsonSerializer;

	public const SEND_SMS_TO_CUSTOMER = "SendSmsToCustomer";
    public const SEND_PAYOUT_PENDING_EMAIL_TO_DEALER = "SendPayoutPendingPdfToDealer";

    public static function fromJson(array $data): self
    {
        $instance = new self();
        $instance->communicationMessage = $data['communicationMessage'] ?? null;
        $instance->sender = $data['sender'] ?? null;
        $instance->type = $data['type'] ?? null;
        return $instance;
    }

    private ?string $communicationMessage;
    private ?string $sender;
    private ?string $type;

	/**
     * @return string|null
     */
    public function getType(): ?string
    {
        return $this->type;
    }

    /**
     * @param string|null $sender
     */
    public function setType(?string $type): void
    {
        $this->type = $type;
    }	

    /**
     * @return string|null
     */
    public function getCommunicationMessage(): ?string
    {
        return $this->communicationMessage;
    }

    /**
     * @param string|null $communicationMessage
     */
    public function setCommunicationMessage(?string $communicationMessage): void
    {
        $this->communicationMessage = $communicationMessage;
    }

    /**
     * @return string|null
     */
    public function getSender(): ?string
    {
        return $this->sender;
    }

    /**
     * @param string|null $sender
     */
    public function setSender(?string $sender): void
    {
        $this->sender = $sender;
    }


}