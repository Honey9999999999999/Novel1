using Fungus;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowStarter : MonoBehaviour
{
    [SerializeField] private Flowchart flowchart;
    private Block runnableBlock;
    private Command runnableCommand;

    public void Stop()
    {
        runnableBlock = flowchart.SelectedBlock;

        runnableCommand = runnableBlock.ActiveCommand;
        runnableBlock.Stop();
    }

    public void Resume()
    {
        if (runnableBlock != null && runnableCommand != null)
        {
            runnableBlock.StartExecution();
            runnableBlock.JumpToCommandIndex = runnableCommand.CommandIndex;
        }
        else
        {
            throw new Exception("Runnable command null reference exception");
        }
    }
}
