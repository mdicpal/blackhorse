<?php


namespace AzureFunderCommonMessages\PHP\Models;


use AzureFunderCommonMessages\PHP\Traits\JsonSerializer;

class SecureFiles  implements \JsonSerializable
{
    use JsonSerializer;

    protected string $filePath;
    protected string $containerName;
    protected ?string $fileType;
    protected ?string $taskId;

    /**
     * @return string
     */
    public function getFilePath(): ?string
    {
        return $this->filePath;
    }

    /**
     * @param string $filePath
     * @return SecureFiles
     */
    public function setFilePath(string $filePath): SecureFiles
    {
        $this->filePath = $filePath;
        return $this;
    }

    /**
     * @return string
     */
    public function getContainerName(): string
    {
        return $this->containerName;
    }

    /**
     * @param string $containerName
     * @return SecureFiles
     */
    public function setContainerName(string $containerName): SecureFiles
    {
        $this->containerName = $containerName;
        return $this;
    }

    /**
     * @return string
     */
    public function getFileType(): ?string
    {
        return $this->fileType;
    }

    /**
     * @param string|null $fileType
     * @return SecureFiles
     */
    public function setFileType(?string $fileType): SecureFiles
    {
        $this->fileType = $fileType;
        return $this;
    }

    /**
     * @return string|null
     */
    public function getTaskId(): ?string
    {
        return $this->taskId;
    }

    /**
     * @param string|null $taskId
     * @return SecureFiles
     */
    public function setTaskId(?string $taskId): SecureFiles
    {
        $this->taskId = $taskId;
        return $this;
    }


    public static function fromJson(array $data): self
    {
        $instance = new self();
        $instance->filePath = $data['filePath'];
        $instance->containerName = $data['containerName'];
        $instance->fileType = $data['fileType'] ?? null;
        $instance->taskId = $data['taskId'] ?? null;
        return $instance;
    }
}