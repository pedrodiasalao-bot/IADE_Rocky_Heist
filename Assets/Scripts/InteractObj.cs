using UnityEngine;
using UnityEngine.InputSystem;

public class InteractObj : MonoBehaviour
{
    //[SerializeField] private PlayerBot BodyScript; //gets the script PlayerBot

    //public Transform MovoBody;
    public Rigidbody2D Body;


    public float bodyY;

    //triggers
    private bool triggerLever = false;
    private bool triggerHide = false;

    //states
    public bool hiding = false;

    //hide the goblin variables

    SpriteRenderer PlayerSprite;
    SpriteRenderer ArmSprite;

    void Start()
    {
        //get the rigidbody of PlayerBot
        Body = transform.parent.parent.parent.parent.GetComponent<Rigidbody2D>();

        //get the layer of playerBot
        PlayerSprite = transform.parent.parent.parent.parent.GetComponent<SpriteRenderer>();
        //get the layer of Arm
        ArmSprite = transform.parent.parent.parent.GetComponent<SpriteRenderer>();

        //Get the og y to place the player back on it
        bodyY = transform.parent.parent.parent.parent.transform.position.y;

    }


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
        //when collision is happening and click the mouse this will happen
        if (triggerLever && Input.GetMouseButtonDown(0))
        {
            PullLever();
        }

        if (triggerHide && Input.GetMouseButtonDown(0))
        {
            Hide(Body);
        }
    }

    public void PullLever() //pull the lever and this happens
    {
        Debug.Log("Pull the lever, Krunk!");
    }

    public void Hide(Rigidbody2D Body) //hides the body behind it
    {

        if (!hiding)
        {
            Debug.Log("HIDE!!!");
            hiding = true;
            PlayerSprite.sortingLayerName = "Hide";
            ArmSprite.sortingLayerName = "Hide";
        }
        else
        {
            hiding = false;
            Body.position = new Vector2(0, bodyY);
            PlayerSprite.sortingLayerName = "Player";
            ArmSprite.sortingLayerName = "Player";
        }

    }
}
