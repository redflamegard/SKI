using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//reference an array of players using enum
public enum PlayerID { one, two, three, four, AI };
//reference array of input axiis using enum
public enum InputAxisIndex { Steering, Gas, Brakes };
//reference array of input buttons using enum
public enum InputButtonIndex { Jump, Action, NextCam, PrevCam };

public class InputManagerStatic : MonoBehaviour {
    [SerializeField]
    string[] inputAxisNames;
    [SerializeField]
    string[] inputButtonNames;

    private void Start()
    {
        SetInputAxisNames();

    }

    private void SetInputAxisNames()
    {
        inputAxisNames = new string[3];
        foreach (string n in Input.GetJoystickNames())
        {
            if (n == "Controller (Xbox One For Windows)")
            {
                for (int i = 0; i < inputAxisNames.Length; i++)
                {
                    inputAxisNames[i] = "XBOX_ONE_";
                }
            }
            else if (n == "Controller (Xbox 360 For Windows)" || n == "Controller (Rock Candy Gamepad for Xbox 360)")
            {
                for (int i = 0; i < inputAxisNames.Length; i++)
                {
                    inputAxisNames[i] = "XBOX_360_";
                }
            }
        }
        inputAxisNames[0] += "Steering";
        inputAxisNames[1] += "Gas";
        inputAxisNames[2] += "Brakes";
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
                //inputButtons[i] = Input.GetButtonDown(inputButtonNames[i] + (int)_playerID);
            }
        }
        _inputButtons = inputButtons;
        _inputAxis = inputAxis;
    }
}
