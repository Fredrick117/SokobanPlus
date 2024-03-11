using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Grid
    public int minX = 0;
    public int maxX = 9;
    public int maxY = 9;
    public int minY = 0;

    public GameObject[,] grid = new GameObject[10, 10];

    // Start is called before the first frame update
    void Start()
    {
        // Initialize player
        Vector2 playerPos = GetPlayerLocation();
        grid[(int)playerPos.x, (int)playerPos.y] = GameObject.Find("Player");

        // Initialize crates
        GameObject[] objects = GetObjects();
        foreach (GameObject obj in objects)
        {
            grid[(int)obj.transform.position.x, (int)obj.transform.position.y] = obj;
        }

        // Initialize walls
        GameObject[] walls = GetWalls();
        foreach (GameObject wall in walls)
        {
            grid[(int)wall.transform.position.x, (int)wall.transform.position.y] = wall;
        }

        // Initialize goal
        GameObject goal = GameObject.Find("Goal");
        grid[(int)goal.transform.position.x, (int)goal.transform.position.y] = goal;
    }

    private Vector2 GetPlayerLocation()
    {
        GameObject player = GameObject.Find("Player");

        if (player != null)
        {
            return new Vector2(player.transform.position.x, player.transform.position.y);
        }

        Debug.Log("<color=red>ERROR: PLAYER NOT FOUND!</color>");
        return Vector2.zero;
    }

    private GameObject[] GetObjects()
    {
        GameObject[] objects = GameObject.FindGameObjectsWithTag("Object");
        return objects;
    }

    private GameObject[] GetWalls()
    {
        GameObject[] walls = GameObject.FindGameObjectsWithTag("Wall");
        return walls;
    }
}
