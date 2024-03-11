using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MovableObject : MonoBehaviour
{
    [HideInInspector]
    public int x;
    [HideInInspector]
    public int y;

    private GameManager manager;

    private void Start()
    {
        manager = GameObject.Find("GameManager").GetComponent<GameManager>();

        x = (int)transform.position.x;
        y = (int)transform.position.y;
    }

    public void Move(int _xTo, int _yTo, int _xFrom, int _yFrom)
    {
        if (CanMoveTo(_xTo, _yTo, _xFrom, _yFrom))
        {
            GameObject go = manager.grid[_xTo, _yTo];

            if (go != null)
            {
                if (go.tag == "Object")
                {
                    int nextX = _xTo + (_xTo - _xFrom);
                    int nextY = _yTo + (_yTo - _yFrom);

                    go.GetComponent<MovableObject>().Move(nextX, nextY, _xTo, _yTo);

                    // Set transforms
                    transform.position = new Vector3(_xTo, _yTo, 0);

                    // Change grid values
                    manager.grid[_xTo, _yTo] = gameObject;
                    manager.grid[_xFrom, _yFrom] = null;
                }
                else if (gameObject.tag == "Player" && manager.grid[_xTo, _yTo] != null)
                {
                    if (manager.grid[_xTo, _yTo].tag == "Goal")
                        SceneManager.LoadScene("Level1");
                }
            }
            else
            {
                // Set transforms
                transform.position = new Vector3(_xTo, _yTo, 0);

                // Change grid values
                manager.grid[_xTo, _yTo] = gameObject;
                manager.grid[_xFrom, _yFrom] = null;
            }
        }
    }

    public bool CanMoveTo(int _xTo, int _yTo, int _xFrom, int _yFrom)
    {
        if (_xTo <= manager.maxX && _xTo >= manager.minX && 
            _yTo <= manager.maxY && _yTo >= manager.minY)
        {
            if (manager.grid[_xTo, _yTo] == null)
            {
                return true;
            }
            else if (manager.grid[_xTo, _yTo].tag == "Object")
            {
                int nextX = _xTo + (_xTo - _xFrom);
                int nextY = _yTo + (_yTo - _yFrom);

                if (nextX <= manager.maxX && nextX >= manager.minX &&
                    nextY <= manager.maxY && nextY >= manager.minY)
                {
                    if (manager.grid[nextX, nextY] == null)
                        return manager.grid[_xTo, _yTo].GetComponent<MovableObject>().CanMoveTo(nextX, nextY, _xTo, _yTo);
                    else
                        return false;
                }
                else
                {
                    return false;
                }
            }
            else if (manager.grid[_xTo, _yTo].tag == "Wall")
            {
                return false;
            }
            else if (manager.grid[_xTo, _yTo].tag == "Goal")
            {
                return true;
            }
            else { return false; }
        }
        else { return false; }
    }
}
