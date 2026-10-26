using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class ArmFollow : MonoBehaviour
{
    public Rigidbody2D ArmPlacement;

    [SerializeField] private PlayerBot BodyScript; //gets the script PlayerBot

    //The bodies location variables
    public float bodyX;
    public float bodyY;

    //The offset to place arm on shhoulder
    public float armOffset = 2;


    void Start()
    {
        ArmPlacement = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        //get the x and y of the body and place the arm there
        bodyX = transform.parent.transform.position.x;
        bodyY = transform.parent.transform.position.y;

        //move the arm to it's place and offset it to the correct place times direction to turn to the right direction
        ArmPlacement.position = new Vector2(bodyX+(armOffset*BodyScript.direction), bodyY);
    }
}
