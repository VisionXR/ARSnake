using System;
using UnityEngine;

public class Link : MonoBehaviour
{
    public GameObject FrontObject;
    public Action<Vector3> SendPreviousPosition;
    private Vector3 PreviousPosition;
    private Vector3 CurrentDirection;
    public float Speed;

    private void OnEnable()
    {
        if (FrontObject != null)
        {
            FrontObject.GetComponent<Link>().SendPreviousPosition += OnPreviousPositionReceived;
        }
    }
    public void OnRegister()
    {
        if(FrontObject != null)
        {
            FrontObject.GetComponent<Link>().SendPreviousPosition += OnPreviousPositionReceived;
        }
    }

    private void OnPreviousPositionReceived(Vector3 NewPosition)
    {
        PreviousPosition = transform.position;
        transform.position = NewPosition;
        SendPreviousPosition?.Invoke(PreviousPosition);
     
    }

}
