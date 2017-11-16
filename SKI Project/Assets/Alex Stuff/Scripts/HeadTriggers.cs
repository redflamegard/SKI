using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadTriggers : MonoBehaviour {

    //cars
    public GameObject car1;
    public GameObject car2;
    //public GameObject car3;
    //public GameObject car4;

    public GameObject headObj;//gameobject that will fall after a player enters a trigger
    Vector3 ogHeadLoc;//where head will placed when it is not down, set to where headObj starts

    bool canFall;//State if head can be dropped, when true, trigger is active
    bool playerInTrigger;//if player has entered trigger, head will fall, turning "canFall" false

    public float timeBeforeFall;//how long after player enters trigger will head fall
    public float timeHeadIsDown;//how long head will remain down before going back up, acts as a cooldown time too
    float maxTimeBeforeFall;//holds default timer to revert back to each time
    float maxTimeHeadIsDown;
    
    // Use this for initialization
    void Start ()
    {
        canFall = true;
        ogHeadLoc = headObj.transform.position;

        maxTimeBeforeFall = timeBeforeFall;
        maxTimeHeadIsDown = timeHeadIsDown;
    }
	
	// Update is called once per frame
	void Update ()
    {
		if(!canFall)
        {
            timeBeforeFall -= Time.deltaTime;

            if(timeBeforeFall <= 0)
            {
                headObj.transform.position = this.transform.position;

                timeHeadIsDown -= Time.deltaTime;

                if(timeHeadIsDown <= 0)
                {
                    headObj.transform.position = ogHeadLoc;
                    canFall = true;

                    timeBeforeFall = maxTimeBeforeFall;
                    timeHeadIsDown = maxTimeHeadIsDown;
                }
            }
        }
	}

    void OnTriggerEnter(Collider other)
    {
        if(canFall)
        {
            if(other.gameObject == car1 || other.gameObject == car2)//had other.GameObject.name == "Player1", didnt work either
            {
                print("in trigger");//not working

                canFall = false;
            }
        }
    }
}
