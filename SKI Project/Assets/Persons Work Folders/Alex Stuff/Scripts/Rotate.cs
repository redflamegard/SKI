using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{

    public float speed;

    public float rotateMode = 0;

    public bool lightHouseDependant = false;
    public GameObject levelControl;
    //public PowerPlantLevel powerPlantLevel;



    // Use this for initialization
    void Start()
    {
        //levelControl = GameObject.Find("LevelControl");
        //if (lightHouseDependant)
        //{
        //    powerPlantLevel = levelControl.gameObject.GetComponent<PowerPlantLevel>();
        //}
    }

    // Update is called once per frame
    void Update()
    {


        //if (lightHouseDependant)
        //{

        //        if (rotateMode == 0)
        //        {
        //            transform.Rotate(Vector3.up * Time.deltaTime * speed);
        //        }
        //        else if (rotateMode == 1)
        //        {
        //            transform.Rotate(Vector3.forward * Time.deltaTime * speed);
        //        }
        //        else if (rotateMode == 2)
        //        {
        //            transform.Rotate(Vector3.right * Time.deltaTime * speed);
        //        }

        //}
        //else
        //{
        if (rotateMode == 0)
        {
            transform.Rotate(Vector3.up * Time.deltaTime * speed);
        }
        else if (rotateMode == 1)
        {
            transform.Rotate(Vector3.forward * Time.deltaTime * speed);
        }
        else if (rotateMode == 2)
        {
            transform.Rotate(Vector3.right * Time.deltaTime * speed);
        }
        else if (rotateMode == 3)
        {
            transform.Rotate(Vector3.right * Time.deltaTime * speed);
            transform.Rotate(Vector3.forward * Time.deltaTime * speed);
            transform.Rotate(Vector3.up * Time.deltaTime * speed);
        }
        //    }
        //}
    }
}
