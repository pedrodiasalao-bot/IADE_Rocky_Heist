using JetBrains.Annotations;
using UnityEngine;

public class Suspicion : MonoBehaviour
{
    public int suspicionMeter = 0;

    public void OnTriggerEnter2D(Collider2D other) //checks the collision is happening
    {
        //Debug.Log("-----------HELLO-----------");
        if (other.CompareTag("Player"))
        {
            Debug.Log("Found you!");
        }
    }

    public void OnTriggerExit2D(Collider2D other) //checks the collision stopped happening
    {
        //Debug.Log("-----------BYE-----------");
        if (other.CompareTag("Player"))
        {
            Debug.Log("Lost you!");
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CheckSupicion() //pull the lever and this happens
    {
        
    }

    public void Chase() //pull the lever and this happens
    {
    }
}
