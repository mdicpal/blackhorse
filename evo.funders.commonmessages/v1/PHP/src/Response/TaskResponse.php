<?php
namespace AzureFunderCommonMessages\PHP\Response;

use AzureFunderCommonMessages\PHP\Models\Task;
use AzureFunderCommonMessages\PHP\Traits\JsonSerializer;

class TaskResponse extends Response implements \JsonSerializable
{
    use JsonSerializer;

    /** @var Task[] */
    private array $tasks;

    /**
     * @return Task[]
     */
    public function getTasks(): array
    {
        return $this->tasks;
    }

    /**
     * @param Task[] $tasks
     * @return TaskResponse
     */
    public function setTasks(array $tasks): TaskResponse
    {
        $this->tasks = $tasks;
        return $this;
    }

    public static function fromJson(array $data): self
    {
        $instance = new self();
        array_walk($data['tasks'], function(&$task){$task = Task::fromJson($task);});
        $instance->tasks = $data['tasks'];
        return $instance;
    }

}