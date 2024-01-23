namespace Orchestrator.Orchestrator_1_0;

using System.Threading.Tasks;

public partial class OrchestratorV1_0
{
    /**
         * <summary>
         * Checks that the given Task is not null and has completed successfully
         * </summary>
         * <returns>
         * True: when task is not null and has completed
         * </returns>
         */
    private static bool EventWasTriggered(Task task)
    {
        //TODO no async operations here - can i extract this
        return task is not null && task.IsCompletedSuccessfully;
    }
}