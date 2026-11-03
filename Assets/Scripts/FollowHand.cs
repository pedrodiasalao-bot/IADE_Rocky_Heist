using UnityEngine;

public class FollowHand : MonoBehaviour
{
    public float bodyX;
    public float bodyY;

    [SerializeField] private int offSetX = 0;
    [SerializeField] private int offSetY = 0;

    void Start()
    {

    }

    void Update()
    {
        //get the x and y of the body and place the arm there
        bodyX = transform.parent.transform.position.x;
        bodyY = transform.parent.transform.position.y;

        //place it on the hand offset
        transform.position = new Vector2(bodyX + offSetX, bodyY + offSetY);
    }
}
