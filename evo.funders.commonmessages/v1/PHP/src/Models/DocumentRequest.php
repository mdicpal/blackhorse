<?php


namespace AzureFunderCommonMessages\PHP\Models;


use AzureFunderCommonMessages\PHP\Traits\JsonSerializer;

class DocumentRequest implements \JsonSerializable
{
    use JsonSerializer;

    /** @var string - FileType */
    private string $fileType;
    private ?string $notes;

    /**
     * @return string
     */
    public function getFileType(): string
    {
        return $this->fileType;
    }

    /**
     * @param string $fileType
     * @return DocumentRequest
     */
    public function setFileType(string $fileType): DocumentRequest
    {
        $this->fileType = $fileType;
        return $this;
    }


    /**
     * @return string|null
     */
    public function getNotes(): ?string
    {
        return $this->notes;
    }

    /**
     * @param string|null $notes
     * @return DocumentRequest
     */
    public function setNotes(?string $notes): DocumentRequest
    {
        $this->notes = $notes;
        return $this;
    }


    public static function fromJson(array $data): self
    {
        $instance = new self();
        $instance->fileType = $data['fileType'];
        $instance->notes = $data['notes'] ?? null;
        return $instance;
    }
}