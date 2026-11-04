using UnityEngine;

public class Interact : MonoBehaviour
{
    private bool triggerLever = false;
    private bool triggerHide = false;

    
    public void OnTriggerEnter2D(Collider2D other) //checks the collision is happening
    {
        //Debug.Log("-----------HELLO-----------");
        if (other.CompareTag("Objects"))
        {
            //Debug.Log("Lever Collider");
            triggerLever = true;
        }

        if (other.CompareTag("HidingSpots"))
        {
            //Debug.Log("Hiding Spot Collider");
            triggerHide = true;
        }
    }

    public void OnTriggerExit2D(Collider2D other) //checks the collision stopped happening
    {
        //Debug.Log("-----------BYE-----------");
        if (other.CompareTag("Objects"))
        {
            triggerLever = false;
        }

        if (other.CompareTag("HidingSpots"))
        {
            triggerHide = false;
        }
    }

    private void Update()
    {
        if (triggerLever && Input.GetMouseButtonDown(0))
        {
            PullLever();
        }

        if (triggerHide && Input.GetMouseButtonDown(0))
        {
            PullHide();
        }


    }

    public void PullLever()
    {
        Debug.Log("Pull the lever, Krunk!");
    }

    public void PullHide()
    {
        Debug.Log("HIDE!!!");
    }
}
