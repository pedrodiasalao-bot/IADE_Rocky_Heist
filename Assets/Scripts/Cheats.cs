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

    // Update is called once per frame
    void Update()
    {
        //not working at the moment
        if (Input.GetKeyDown(KeyCode.P) && collidersOn)
        {
            //it is on so turn it off
            for (int i = 0; i < colliders.Length; i++)
            {
                spriteRenderer = colliders[i].GetComponent<SpriteRenderer>();
                spriteRenderer.sortingLayerName = "Hide";
                //colliders[i].layer = 1;
            }
            
        }
        else if (Input.GetKeyDown(KeyCode.P) && !collidersOn)
        {
            for (int i = 0; i < colliders.Length; i++)
            {
                spriteRenderer = colliders[i].GetComponent<SpriteRenderer>();
                spriteRenderer.sortingLayerName = "Foreground";
            }
        }
    }
}
