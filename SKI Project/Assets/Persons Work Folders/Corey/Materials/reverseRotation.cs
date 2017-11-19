using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reverseRotation : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void FixedUpdate()
    {
        this.gameObject.transform.Rotate(-3, -1, -2);

    }
}
