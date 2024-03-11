using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCommand : CommandManager.ICommand
{
    private int xPrev;
    private int yPrev;

    private int xTo;
    private int yTo;

    public MoveCommand(int xPrev, int yPrev, int xTo, int yTo)
    {
        this.xPrev = xPrev;
        this.yPrev = yPrev;
        this.xTo = xTo;
        this.yTo = yTo;
    }

    public void Execute()
    {
        var obj = GameObject.Find("GameManager").GetComponent<GameManager>().grid[xPrev, yPrev];
        if (obj != null && obj.GetComponent<MovableObject>() != null)
        {
            obj.GetComponent<MovableObject>().Move(xTo, yTo, xPrev, yPrev);
        }
    }

    public void Undo()
    {
        var obj = GameObject.Find("GameManager").GetComponent<GameManager>().grid[xTo, yTo];
        if (obj != null && obj.GetComponent<MovableObject>() != null)
        {
            obj.GetComponent<MovableObject>().Move(xPrev, yPrev, xTo, yTo);
        }
    }

    public void Redo()
    {
        var obj = GameObject.Find("GameManager").GetComponent<GameManager>().grid[xPrev, yPrev];
        if (obj != null && obj.GetComponent<MovableObject>() != null)
        {
            obj.GetComponent<MovableObject>().Move(xTo, yTo, xPrev, yPrev);
        }
    }
}
