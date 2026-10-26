using UnityEngine;

public class LightFollow : MonoBehaviour
{
    public Rigidbody2D LightPlacement;

    //[SerializeField] private PlayerBot BodyScript; //gets the script PlayerBot

    //The bodies location variables
    public float handX;
    public float handY;

    //The offset to place arm on shhoulder
    public float offset = 1;


    void Start()
    {
        LightPlacement = GetComponent<Rigidbody2D>();
    }


    void Update()
    {

        Debug.Log(transform.parent.transform.position);
        //get the x and y of the body and place the arm there
        handX = transform.parent.transform.position.x;
        handY = transform.parent.transform.position.y;

        //move the arm to it's place and offset it to the correct place times direction to turn to the right direction
        LightPlacement.position = new Vector2(handX, handY);
    }
}
