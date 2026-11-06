using UnityEngine;

public class Cheats : MonoBehaviour
{
    private bool collidersOn = false;

    private GameObject[] colliders;

    SpriteRenderer spriteRenderer;

    void Start()
    {
        colliders = GameObject.FindGameObjectsWithTag("collider"); //find all colliders
    }

    void Update()
    {
        //Turn On The visible Colliders
        if (Input.GetKeyDown(KeyCode.P))
        {
            ColliderSwitch();
        }
    }

    void ColliderSwitch()
    {
        if(collidersOn)
        {
            //it is on so turn it off
            for (int i = 0; i < colliders.Length; i++)
            {
                colliders[i].GetComponent<SpriteRenderer>().sortingLayerName = "Hide"; //get the layer and change it
                collidersOn = false;
            }

        }
        else if (!collidersOn)
        {
            //it is off so turn it on
            for (int i = 0; i < colliders.Length; i++)
            {
                colliders[i].GetComponent<SpriteRenderer>().sortingLayerName = "Colliders"; //get the layer and change it
                collidersOn = true;
            }
        }
    }
}
