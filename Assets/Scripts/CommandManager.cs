using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandManager : MonoBehaviour
{
    public interface ICommand
    {
        void Execute();
        void Undo();
        void Redo();
    }

    private List<ICommand> commandList = new List<ICommand>();
    private int positionInList = -1;

    public void AddCommand(ICommand command)
    {
        command.Execute();
        commandList.Add(command);
        positionInList++;
    }

    public void Undo()
    {
        if (commandList.Count == 0 || positionInList == -1)
            return;

        print("Calling undo");
        var command = commandList[positionInList];
        positionInList--;
        command.Undo();
    }

    public void Redo()
    {
        if (commandList.Count == 0 || positionInList == commandList.Count - 1)
            return;

        print("Calling redo");
        positionInList++;
        var command = commandList[positionInList];
        command.Redo();
    }
}
