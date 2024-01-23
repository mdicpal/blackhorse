<?php


namespace AzureFunderCommonMessages\PHP\Models;


use AzureFunderCommonMessages\PHP\Traits\JsonSerializer;

class Task implements \JsonSerializable
{
    use JsonSerializer;

    private string $id;
    private string $taskAction;
    private string $label;
    private ?string $description;
    /** @var string[] */
    private array $comments;
    /** @var DocumentRequest[] */
    private array $requiredDocuments;

    /**
     * @return string
     */
    public function getId(): string
    {
        return $this->id;
    }

    /**
     * @param string $id
     * @return Task
     */
    public function setId(string $id): Task
    {
        $this->id = $id;
        return $this;
    }

    /**
     * @return string
     */
    public function getTaskAction(): string
    {
        return $this->taskAction;
    }

    /**
     * @param string $taskAction
     * @return Task
     */
    public function setTaskAction(string $taskAction): Task
    {
        $this->taskAction = $taskAction;
        return $this;
    }



    /**
     * @return string
     */
    public function getLabel(): string
    {
        return $this->label;
    }

    /**
     * @param string $label
     * @return Task
     */
    public function setLabel(string $label): Task
    {
        $this->label = $label;
        return $this;
    }

    /**
     * @return string|null
     */
    public function getDescription(): ?string
    {
        return $this->description;
    }

    /**
     * @param string|null $description
     * @return Task
     */
    public function setDescription(?string $description): Task
    {
        $this->description = $description;
        return $this;
    }

    /**
     * @return string[]
     */
    public function getComments(): array
    {
        return $this->comments;
    }

    /**
     * @param string[] $comments
     * @return Task
     */
    public function setComments(array $comments): Task
    {
        $this->comments = $comments;
        return $this;
    }

    /**
     * @return DocumentRequest[]
     */
    public function getRequiredDocuments(): array
    {
        return $this->requiredDocuments;
    }

    /**
     * @param DocumentRequest[] $requiredDocuments
     * @return Task
     */
    public function setRequiredDocuments(array $requiredDocuments): Task
    {
        $this->requiredDocuments = $requiredDocuments;
        return $this;
    }

    public static function fromJson(array $data): self
    {
        $instance = new self();
        $instance->id = $data['id'];
        $instance->label = $data['label'];
        $instance->taskAction = $data['taskAction'];
        $instance->description = $data['description'] ?? null;
        $instance->comments = $data['comments'] ?? [];
        array_walk($data['requiredDocuments'], function(&$task){$task = DocumentRequest::fromJson($task);});
        $instance->requiredDocuments = $data['requiredDocuments'] ?? [];
        return $instance;
    }
}