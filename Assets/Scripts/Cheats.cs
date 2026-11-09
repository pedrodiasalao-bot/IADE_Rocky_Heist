using UnityEngine;

public class Cheats : MonoBehaviour
{
    private bool collidersOn = false;
    private bool darknessOn = true;

    private GameObject[] colliders;
    private GameObject darkness;

    //SpriteRenderer spriteRenderer;

    void Start()
    {
        colliders = GameObject.FindGameObjectsWithTag("collider"); //find all colliders
        darkness = GameObject.FindGameObjectWithTag("Darkness"); //find the darkness
    }

    void Update()
    {
        //Turn On The visible Colliders
        if (Input.GetKeyDown(KeyCode.P))
        {
            ColliderSwitch();
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            DarknessSwitch();
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

    void DarknessSwitch()
    {
        if (darknessOn)
        {
            //it is on so turn it off
            darkness.GetComponent<SpriteRenderer>().sortingLayerName = "Hide"; //get the layer and change it
            darknessOn = false;

        }
        else if (!darknessOn)
        {
            //it is off so turn it on
            darkness.GetComponent<SpriteRenderer>().sortingLayerName = "Foreground"; //get the layer and change it
            darknessOn = true;
        }
    }
}
