using UnityEngine;

public class LightFollow : MonoBehaviour
{
    public float bodyX;
    public float bodyY;

    void Start()
    {

    }

    void Update()
    {
        //get the x and y of the body and place the arm there
        bodyX = transform.parent.transform.position.x;
        bodyY = transform.parent.transform.position.y;

        //move the arm to it's place and offset it to the correct place times direction to turn to the right direction
        transform.position = new Vector2(bodyX, bodyY);
    }
}
