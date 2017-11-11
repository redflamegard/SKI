using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//PUT ME ON THE CAMERA FOR THE RESPECTIVE PLAYER
public class PlayerCameraScript : MonoBehaviour
{
    private enum CameraState { RotateVertical, RotateHorizontal }

    CameraState cameraState;

    public bool IsInvertedHorizontal;
    public bool IsInvertedVertical;

    [SerializeField]
    private float turnRate = 10;


    Transform target;
    Camera camera;
    InputManagerStatic inputManager;

    private Vector3 resetPosition;
    private Quaternion resetRotation;

    private float horizontalInput;
    private float horizontalOutput;

    private float verticalInput;
    private float verticalOutput;

    private int invertRateHorizontal = 1;
    private int invertRateVertical = 1;

    private void Awake()
    {
        inputManager = GameObject.Find("InputManager").GetComponent<InputManagerStatic>();
    }

    // Use this for initialization
    void Start()
    {
        camera = GetComponent<Camera>();
        target = GetComponentInParent<CarController>().transform;
        SetUpInvertRate();
        cameraState = CameraState.RotateHorizontal;
        resetPosition = transform.localPosition;
        resetRotation = transform.localRotation;
    }

    private void SetUpInvertRate()
    {
        if (IsInvertedHorizontal)
        {
            invertRateHorizontal *= -1;
        }

        if (IsInvertedVertical)
        {
            invertRateVertical *= -1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //transform.LookAt(target.transform);
        //transform.position = targetLookAtPoint.transform.position + bufferDistance;


        UpdateCameraControlInput();
        UpdateOutputValues();
        UpdateRotationOfCameraBasedOnState();
        UpdateCheckToResetCameraPositionAndRotation();
        //UpdateCameraState();
        Debugging();
    }

    private void UpdateCameraControlInput()
    {
        float[] inputAxis;
        bool[] inputButtons;
        inputManager.GetInputForPlayer(target.GetComponent<CarController>()._PlayerID, out inputButtons, out inputAxis);
        horizontalInput = inputAxis[(int)InputAxisIndex.CameraHorizontal];
    }

    private void UpdateRotationOfCameraBasedOnState()
    {
        switch (cameraState)
        {
            case CameraState.RotateVertical:
                //transform.RotateAround(target.position, target.transform.right, verticalOutput * Time.deltaTime);
                break;
            case CameraState.RotateHorizontal:
                transform.RotateAround(target.position, target.transform.up, horizontalOutput * Time.deltaTime);
                break;
            default:
                break;
        }
    }

    private void UpdateCheckToResetCameraPositionAndRotation()
    {
        //add back in when tom adds buttons
        /*if (Input.GetButtonDown("rightstickclick"))
        {
            transform.localPosition = resetPosition;
            transform.localRotation = resetRotation;
        }*/
    }
    private void UpdateOutputValues()

    {
        horizontalOutput = horizontalInput * turnRate;
        //verticalOutput = verticalInput * turnRate;
    }

    /*Intended to make it so you can only adjust rotation around the vertical or horizontal axis of the vehicle of the time, 
    *otherwise camera control gets strange */
    private void UpdateCameraState()
    {
        if (horizontalOutput > verticalOutput)
        {
            cameraState = CameraState.RotateHorizontal;
        }
        if (verticalOutput > horizontalOutput)
        {
            cameraState = CameraState.RotateVertical;
        }
    }

    private void Debugging()
    {
        Debug.Log("Camera Horizontal Input Value: " + horizontalInput.ToString());
        //Debug.Log("Vertical Input: " + (Input.GetAxis("Vertical") * turnRate).ToString());
    }
}
