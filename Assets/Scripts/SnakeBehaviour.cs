using System;
using System.Collections;
using UnityEngine;

public class SnakeBehaviour : MonoBehaviour
{
    public static SnakeBehaviour instance;
    public int SnakeLength = 4;
    public GameObject SnakeHead,SnakeTail,TriggerObj,FoodObj;
    public string CurrentDirection = "Left";
    public float SnakeSpeed = 0.2f;
    public Action<float> SpeedChanged;
    private GameObject tempFood;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        StartCoroutine(IncrementSpeed());
        StartCoroutine(AddSnakeBody());
    }
    private void OnEnable()
    {
        InputManager.instance.ChangeDirection += OnDirectionChanged;
     
    }
    private void OnDisable()
    {
        InputManager.instance.ChangeDirection -= OnDirectionChanged;
       
    }

    private IEnumerator AddSnakeBody()
    {
        while (true)
        {
            yield return new WaitForSeconds(5);
            yield return new WaitForEndOfFrame();
            GameObject tmpTail = Instantiate(SnakeTail, SnakeTail.transform.position, Quaternion.identity);
            tmpTail.GetComponent<Link>().FrontObject = GameObject.Find("Sphere" + SnakeLength);
            tmpTail.GetComponent<Link>().OnRegister();
            SnakeLength++;
            tmpTail.name = "Sphere" + SnakeLength;
            tmpTail.transform.parent = gameObject.transform;
            
        }
    }

    private void OnDirectionChanged(string dir)
    {
        Debug.Log("Input working");
        if(CurrentDirection != dir)
        {
            
            if (dir == "Up" && CurrentDirection != "Down")
            {
                CurrentDirection = dir;
            }
            else if (dir == "Down" && CurrentDirection != "Up")
            {          
                CurrentDirection = dir;
            }
            else if (dir == "Left" && CurrentDirection != "Right")
            {         
                CurrentDirection = dir;
            }
            else if (dir == "Right" && CurrentDirection != "Left")
            {            
                CurrentDirection = dir;
            }
            else if (dir == "Front" && CurrentDirection != "Back")
            {
                CurrentDirection = dir;
            }
            else if(dir == "Back" && CurrentDirection != "Front")
            {
                CurrentDirection = dir;
            }
            SnakeHead.GetComponent<SnakeMovement>().OnDirectionChanged(CurrentDirection);
          
        }

    }


    private IEnumerator IncrementSpeed()
    {
        while (true)
        {
            yield return new WaitForSeconds(30);
            SnakeSpeed += 0.05f;
            SpeedChanged?.Invoke(SnakeSpeed);
        }
    }

    private IEnumerator SupplyFood()
    {
        while (true)
        {
            yield return new WaitForSeconds(30);
            if(tempFood != null)
            {
                Destroy(tempFood);
            }
            Vector3 pos = new Vector3(UnityEngine.Random.Range(-0.4f, 0.4f), UnityEngine.Random.Range(-0.4f, 0.4f), UnityEngine.Random.Range(-0.4f, 0.4f));
            tempFood = Instantiate(FoodObj, pos, Quaternion.identity);
        }
    }
}
