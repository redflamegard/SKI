using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PowerUpState
{
    CannonBall,
    HealthUp
}

public class PowerUpObject : MonoBehaviour {

    public PowerUpState powerUpGet;

    public PowerUpObject(PowerUpState powerUpFromBox)
    {
        powerUpGet = powerUpFromBox;
    }

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    
}
