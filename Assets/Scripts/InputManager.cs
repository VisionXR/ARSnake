using System;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager instance;
    public bool isInputActive = true;
    public Action<string> ChangeDirection;
    public string CurrentDirection = "Left";

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        
    }
    public void EnableInput()
    {
        isInputActive = true;
    }

    public void DisableInput()
    {
        isInputActive = false;
    }

    // Update is called once per frame
    void Update()
    {
       if(isInputActive)
        {
            if(Input.GetKeyDown(KeyCode.LeftArrow))
            {
                ChangeDirection?.Invoke("Left");
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                ChangeDirection?.Invoke("Right");
            }
            else if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                ChangeDirection?.Invoke("Up");
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                ChangeDirection?.Invoke("Down");
            }
            else if (Input.GetKeyDown(KeyCode.LeftControl))
            {
                ChangeDirection?.Invoke("Back");
            }
            else if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                ChangeDirection?.Invoke("Front");
            }
        }
    }
}
