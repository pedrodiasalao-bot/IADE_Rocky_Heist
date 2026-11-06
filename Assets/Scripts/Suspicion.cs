using UnityEngine;

public class Suspicion : MonoBehaviour
{
    public double suspicionMeter = 0;
    public bool chase = false;

    public void OnTriggerEnter2D(Collider2D other) //checks the collision is happened
    {
        //Debug.Log("-----------HELLO-----------");
        if (other.CompareTag("Player")) //Guards light found player
        {
            Debug.Log("Found you!");
            chase = true;

        }
    }

    public void OnTriggerStay2D(Collider2D other) //checks the collision is happening
    {
        if (other.CompareTag("Player"))
        {
            suspicionMeter = suspicionMeter + 0.1;
        }
    }

    public void OnTriggerExit2D(Collider2D other) //checks the collision stopped happening
    {
        //Debug.Log("-----------BYE-----------");
        if (other.CompareTag("Player")) //Guards light found player
        {
            Debug.Log("Lost you!");
            chase = false;
        }
    }

    void Update()
    {
        //Debug.Log(suspicionMeter);
    }
}
