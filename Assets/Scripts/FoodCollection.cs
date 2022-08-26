using System;
using UnityEngine;

public class FoodCollection : MonoBehaviour
{
    public Action AteFood;
    public void OnCollisionEnter(Collision collision)
    {

        if (collision.collider.gameObject.tag == "Food")
        {
            AteFood?.Invoke();
        }

    }

}
