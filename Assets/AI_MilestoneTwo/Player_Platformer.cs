using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class Player_Platformer : MonoBehaviour
{
    private float movementspeed = 4;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * movementspeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * movementspeed * Time.deltaTime);
        }
    }
}
