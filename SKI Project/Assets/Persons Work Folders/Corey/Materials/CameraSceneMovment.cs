using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraSceneMovment : MonoBehaviour {
    [SerializeField]
    List<Transform> CameraPositions;
    [SerializeField] float Speed, Accel, Handling;
    [SerializeField] GameObject CameraObject;
    Random ran = new Random();
    int currentNum;
   [SerializeField]  Slider SpeedSlider, AccelSlider, HandlerSlider;

    // Use this for initialization
    void Start() {
        Debug.Log(currentNum);
        currentNum = 0;
        UpdateStats();


    }

    // Update is called once per frame
    void Update() {
       // Debug.Log(CameraPositions[currentNum]);

    }

    void UpdateStats ()
    {
        Speed = Random.Range(20, 100);
        SpeedSlider.value = Speed;
        Accel = Random.Range(30, 100);
        AccelSlider.value = Accel;
        Handling = Random.Range(20, 100);
        HandlerSlider.value = Handling;

    }

    public void NextPosition()
    {
        UpdateStats();
        if (currentNum != CameraPositions.Count-1)
        {
            Debug.Log(currentNum);
            CameraObject.transform.position = CameraPositions[currentNum + 1].position;
            currentNum++;
        }


    }

    public void LastPosition ()
    {
        UpdateStats();
        if (currentNum != 0)
        {
            CameraObject.transform.position = CameraPositions[currentNum - 1].position;
            currentNum--;
        }
    }
}
