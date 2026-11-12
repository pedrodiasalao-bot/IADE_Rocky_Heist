
using UnityEngine;

public class LightQTE : MonoBehaviour
{
    public GameObject otherObject;


    //Light Out
    private float time;
    private int lightRadious;

    private int[] timers = { 5, 10, 15, 20, 25}; //reg

    //private int[] timers = { 1, 100, 102, 103, 104}; //testing
    private int currentStage;


    //QTE
    private bool canQTE = false;
    private bool inQTE = false;


    public float minX = -2f;
    public float maxX = 2f;
    public float minY = -3f;
    public float maxY = 3f;

    private Vector2 mouseWorldPos;
    private Collider2D hitCollider;

    private int amount;
    private GameObject[] hitBox;

    private float timerQTE;
    public GameObject itemPrefab;

    private GameObject interactFix, hideFix, lightFix, guardFix, objFix;

    void Start()
    {
        //Light Out
        time = 0;
        lightRadious = 5;
        currentStage = 0;

        //QTE
        timerQTE = 0;


        //temp bugfix
        interactFix = GameObject.FindGameObjectWithTag("Hand"); 
        hideFix = GameObject.FindGameObjectWithTag("HidingSpots"); 
        lightFix = GameObject.FindGameObjectWithTag("guardlight"); 
        guardFix = GameObject.FindGameObjectWithTag("guard"); 
        objFix = GameObject.FindGameObjectWithTag("Objects");

        


    }

    void Update()
    {
        //start the lights timer
        if(time < 0)
        {
            //in QTE
        }
        else
        {
            time += Time.deltaTime;
        }
        
        //Debug.Log(time);

        //get mouse positiona and collision
        mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        hitCollider = Physics2D.OverlapPoint(mouseWorldPos);


        //lower the light based on the range of the timer
        if (time >= 0 && time <= timers[0]) // r=5
        {
            canQTE = false;
            LightGoingOut(0); //stage 1
        }
        else if (time > timers[0] && time <= timers[1])
        {
            canQTE = true;
            LightGoingOut(1); //stage 2
        } 
        else if (time > timers[1] && time <= timers[2])
        {
            LightGoingOut(2); //stage 3
        }
        else if (time >= timers[2] && time <= timers[3])
        {
            LightGoingOut(3); //stage 4
        }
        else if (time >= timers[3] && time <= timers[4])
        {
            LightGoingOut(4); //stage 5
        }
        else if (time > timers[4]) // r=0
        {
            LightGoingOut(5); //stage 6
        }


        //if lost light and not in the QTE can enter it by right clicking
        if (canQTE && !inQTE && Input.GetMouseButtonDown(1))
        {
            time = -1;
            LightQuickTimeEvent(currentStage);
        }


        if (hitCollider != null)
        {
            //bugfix.GetComponent<Collider2D>().enabled = false;
            Debug.Log(interactFix.GetComponent<Collider2D>().enabled);
            Debug.Log(hideFix.GetComponent<Collider2D>().enabled);
            Debug.Log(lightFix.GetComponent<Collider2D>().enabled);
            Debug.Log(guardFix.GetComponent<Collider2D>().enabled);
            Debug.Log(objFix.GetComponent<Collider2D>().enabled);

            Debug.Log(hitCollider.GetComponent<Collider2D>().name);

            if (inQTE && hitCollider.GetComponent<Collider2D>().name == "QTE_HitBox(Clone)" && Input.GetMouseButtonDown(0))
            {
                interactFix.GetComponent<Collider2D>().enabled = false;
                hideFix.GetComponent<Collider2D>().enabled = false;
                lightFix.GetComponent<Collider2D>().enabled = false;
                guardFix.GetComponent<Collider2D>().enabled = false;
                objFix.GetComponent<Collider2D>().enabled = false;
                ClickQTE();
            }
        }
    }

    
    void LightGoingOut(int stage) //Turn the light smaller
    {
        if (currentStage != stage) return; //if the current stage is not the stage sent go back
        //transform shape of light
        transform.localScale = new Vector3(lightRadious-stage, lightRadious-stage, 0);

        //next stage
        currentStage += 1;
    }

    void LightQuickTimeEvent(int stage) //Enter the QTE
    {
        amount = stage; //depending on the stage different amount of hit boxes
        inQTE = true; //in the QTE

        //spawn the correct amount of items
        for (int i = 0; i < amount; i++)
        {
            SpawnItem();
        }
    }

    void SpawnItem()
    {
        //random posistion for the hit boxes
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);
        Vector2 spawnPosition = new Vector2(randomX, randomY);

        Instantiate(itemPrefab, spawnPosition, Quaternion.identity); //spawn
    }

    void ClickQTE()
    {
        Destroy(hitCollider.gameObject);
        
        amount -= 1;

        if(amount <= 0)
        {
            inQTE = false;
            time = 0;
            currentStage = 0;
            //bugfix.GetComponent<Collider2D>().enabled = true;
            interactFix.GetComponent<Collider2D>().enabled = true;
            hideFix.GetComponent<Collider2D>().enabled = true;
            lightFix.GetComponent<Collider2D>().enabled = true;
            guardFix.GetComponent<Collider2D>().enabled = true;
            objFix.GetComponent<Collider2D>().enabled = true;
        }
    }
}
