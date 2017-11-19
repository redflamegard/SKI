using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpBox : MonoBehaviour {

    public GameObject test;

	// Use this for initialization
	void Start ()
    {
	    	
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameObject newprefabthingy = Instantiate(test, transform.position, Quaternion.identity);
            newprefabthingy.transform.parent = collision.gameObject.transform;
            this.gameObject.SetActive(false);
        }
    }
}