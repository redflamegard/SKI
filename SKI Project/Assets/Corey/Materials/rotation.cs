using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotation : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        this.gameObject.transform.Rotate(2,5,5);
		
	}
}
