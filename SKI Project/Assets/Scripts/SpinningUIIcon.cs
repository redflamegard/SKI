using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinningUIIcon : MonoBehaviour {

    RectTransform canvasTransform;
    float spinAmount = 500f;
    // Use this for initialization
    void Start () {
        canvasTransform = GetComponent<RectTransform>();
    }
	
	// Update is called once per frame
	void Update () {
        canvasTransform.Rotate(0, spinAmount * Time.deltaTime, 0);
	}
}
