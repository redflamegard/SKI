using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//reference an array of players using enum
public enum PlayerID { one, two, three, four, AI };
//reference array of input axiis using enum
public enum InputAxisIndex { Steering, Gas, Brakes, CameraHorizontal, CameraVertical };
//reference array of input buttons using enum
public enum InputButtonIndex { Action, Jump, NextCam, PrevCam };

public class InputManagerStatic : MonoBehaviour
{
    [SerializeField]
    string[] inputAxisNames;
    [SerializeField]
    string[] inputButtonNames;

    bool hasJoystick = false;

    private void Start()
    {
        SetInputAxisNames();
    }

    private void SetInputAxisNames()
    {
        hasJoystick = false;
        inputAxisNames = new string[5];
        inputButtonNames = new string[2];
        
        foreach (string n in Input.GetJoystickNames())
        {
            if (n == "Controller (Xbox One For Windows)")
            {
                hasJoystick = true;
                for (int i = 0; i < inputAxisNames.Length; i++)
                {
                    inputAxisNames[i] = "XBOX_ONE_";
                }
                for (int i = 0; i < inputButtonNames.Length; i++)
                {
                    inputButtonNames[i] = "XBOX_ONE_";
                }
            }
            else if (n == "Controller (XBOX 360 For Windows)" || n == "Controller (Rock Candy Gamepad for Xbox 360)")
            {
                hasJoystick = true;
                for (int i = 0; i < inputAxisNames.Length; i++)
                {
                    inputAxisNames[i] = "XBOX_360_";
                }
                for (int i = 0; i < inputButtonNames.Length; i++)
                {
                    inputButtonNames[i] = "XBOX_360_";
                }
            }
        }
        if (!hasJoystick)
        {
            for (int i = 0; i < inputAxisNames.Length; i++)
            {
                inputAxisNames[i] = "Keyboard_";
            }
            for (int i = 0; i < inputButtonNames.Length; i++)
            {
                inputButtonNames[i] = "Keyboard_";
            }
        }

        inputButtonNames[0] += "Action";
        inputButtonNames[1] += "Jump";
        inputAxisNames[0] += "Steering";
        inputAxisNames[1] += "Gas";
        inputAxisNames[2] += "Brakes";
        inputAxisNames[3] += "CameraHorizontal";
        inputAxisNames[4] += "CameraVertical";

    }

    

    public void GetInputForPlayer(PlayerID _playerID, out bool[] _inputButtons, out float[] _inputAxis)
    {
        float[] inputAxis = new float[inputAxisNames.Length];
        bool[] inputButtons = new bool[inputButtonNames.Length];
        if (_playerID != PlayerID.AI)
        {
            for (int i = 0; i < inputAxisNames.Length; i++)
            {
                inputAxis[i] = Input.GetAxis(inputAxisNames[i] + (int)_playerID);
            }
            for (int i = 0; i < inputButtonNames.Length; i++)
            {
                //buttons haven't been assigned yet, just placeholder for now
                inputButtons[i] = Input.GetButtonDown(inputButtonNames[i] + ((int)_playerID));
            }
        }
        _inputButtons = inputButtons;
        _inputAxis = inputAxis;
    }
}
