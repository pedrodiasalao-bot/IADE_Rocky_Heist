using JetBrains.Annotations;
using UnityEngine;

public class Suspicion : MonoBehaviour
{
    public double suspicionMeter = 0;

    public void OnTriggerEnter2D(Collider2D other) //checks the collision is happening
    {
        //Debug.Log("-----------HELLO-----------");
        if (other.CompareTag("Player"))
        {
            Debug.Log("Found you!");

        }
    }

    public void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            
            if (suspicionMeter >= 20)
            {
                Debug.Log("Game Over");
            }
            else
            {
                Debug.Log(suspicionMeter);
                suspicionMeter = suspicionMeter + 0.1;
            }
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

}
