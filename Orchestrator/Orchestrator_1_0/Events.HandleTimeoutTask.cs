namespace Orchestrator.Orchestrator_1_0;

using System.Threading.Tasks;

public partial class OrchestratorV1_0
{
    /**
         * <summary>
         * Check if the event loop has timed out
         * </summary>
         */
    public static bool HandleTimeoutTask(Task timeoutTask, bool exitLoop)
    {
        if (EventWasTriggered(timeoutTask))
        {
            exitLoop = true;
        }

        return exitLoop;
    }
}