using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//reference an array of players using enum
public enum PlayerID { one, two, three, four };
//reference array of input axiis using enum
public enum InputAxisIndex { Steering, Gas, Brakes };
//reference array of input buttons using enum
public enum InputButtonIndex { Jump, Shoot, NextCam, PrevCam };

public class InputManagerStatic : MonoBehaviour {
    [SerializeField]
    string[] inputAxisNames;
    [SerializeField]
    string[] inputButtonNames;
    


    //Input in the input manager needs to be assembled as action + (player number - 1) "Gas0" is player 1 gas pedal

    public void GetInputForPlayer(PlayerID _playerID, out bool[] _inputButtons, out float[] _inputAxis)
    {
        float[] inputAxis = new float[inputAxisNames.Length];
        bool[] inputButtons = new bool[inputButtonNames.Length];
        for (int i = 0; i < inputAxisNames.Length; i++)
        {
            inputAxis[i] = Input.GetAxis(inputAxisNames[i] + (int)_playerID);
        }
        for (int i = 0; i < inputButtonNames.Length; i++)
        {
            //buttons haven't been assigned yet, just placeholder for now
            //inputButtons[i] = Input.GetButtonDown(inputButtonNames[i] + (int)_playerID);
        }
        _inputButtons = inputButtons;
        _inputAxis = inputAxis;
    }
}
