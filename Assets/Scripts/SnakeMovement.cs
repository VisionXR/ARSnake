using System;
using UnityEngine;

public class SnakeMovement : MonoBehaviour
{
    public float Speed = 0.1f;
    public string CurrentDirection = "Left";
    private Vector3 PreviousPosition;
    private bool CanIChange = true;

    private void OnEnable()
    {
        SnakeBehaviour.instance.SpeedChanged += OnSpeedChanged;
    }

    private void OnDisable()
    {
        SnakeBehaviour.instance.SpeedChanged -= OnSpeedChanged;

    }

    private void OnSpeedChanged(float NewSpeed)
    {
        Speed = NewSpeed;
    }

    public void OnDirectionChanged(string dir)
    {
      
        CurrentDirection = dir;
    }

    private void Update()
    {


        if (CanIChange)
        {
            PreviousPosition = transform.position;
        }
        Speed = SnakeBehaviour.instance.SnakeSpeed;
        if(CurrentDirection == "Left")
        {
            transform.position += -transform.right * Speed * Time.deltaTime;
        }
        else if (CurrentDirection == "Right")
        {
            transform.position += transform.right * Speed * Time.deltaTime;
        }
        else if (CurrentDirection == "Front")
        {
            transform.position += transform.forward * Speed * Time.deltaTime;
        }
        else if (CurrentDirection == "Back")
        {
            transform.position -= transform.forward * Speed * Time.deltaTime;
        }
        else if (CurrentDirection == "Up")
        {
            transform.position += transform.up * Speed * Time.deltaTime;
        }
        else 
        {
            transform.position -= transform.up * Speed * Time.deltaTime;
        }

        if (Vector3.Distance(PreviousPosition, transform.position) >= 0.1f)
        {
            GetComponent<Link>().SendPreviousPosition(PreviousPosition);
            CanIChange = true;
        }
        else
        {
            CanIChange = false;
        }

    }

    public void OnCollisionExit(Collision collision)
    {
       
        if(collision.collider.gameObject.tag == "Trigger")
        {
            OnDirectionChanged(collision.collider.gameObject.GetComponent<TriggerScript>().Direction);
        }
   
    }

}
