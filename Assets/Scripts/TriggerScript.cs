using UnityEngine;

public class TriggerScript : MonoBehaviour
{
    public string Direction;

    public void OnCollisionExit(Collision collision)
    {
        if(collision.collider.tag == "Tail")
        {
            Destroy(gameObject);
        }
    }

}
