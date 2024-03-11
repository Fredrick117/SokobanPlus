using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField]
    private GameObject managerObject;

    [SerializeField]
    private AudioSource undoSound;
    [SerializeField]
    private AudioSource redoSound;
    [SerializeField]
    private AudioSource moveSound;

    // Update is called once per frame
    void Update()
    {
        // Movement
        if (Input.GetKeyDown(KeyCode.W))
        {
            Vector2 newPosition = (Vector2)transform.position + Vector2.up;
            MoveCommand command = new MoveCommand((int)transform.position.x, (int)transform.position.y, (int)newPosition.x, (int)newPosition.y);
            managerObject.GetComponent<CommandManager>().AddCommand(command);

            moveSound.Play();
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            Vector2 newPosition = (Vector2)transform.position + Vector2.down;
            MoveCommand command = new MoveCommand((int)transform.position.x, (int)transform.position.y, (int)newPosition.x, (int)newPosition.y);
            managerObject.GetComponent<CommandManager>().AddCommand(command);

            moveSound.Play();
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            Vector2 newPosition = (Vector2)transform.position + Vector2.left;
            MoveCommand command = new MoveCommand((int)transform.position.x, (int)transform.position.y, (int)newPosition.x, (int)newPosition.y);
            managerObject.GetComponent<CommandManager>().AddCommand(command);

            moveSound.Play();
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            Vector2 newPosition = (Vector2)transform.position + Vector2.right;
            MoveCommand command = new MoveCommand((int)transform.position.x, (int)transform.position.y, (int)newPosition.x, (int)newPosition.y);
            managerObject.GetComponent<CommandManager>().AddCommand(command);

            moveSound.Play();
        }
        else if (Input.GetKeyDown(KeyCode.Z))
        {
            managerObject.GetComponent<CommandManager>().Undo();
            undoSound.Play();
        }
        else if (Input.GetKeyDown(KeyCode.X))
        {
            managerObject.GetComponent<CommandManager>().Redo();
            redoSound.Play();
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("Level1");
        }
    }
}
