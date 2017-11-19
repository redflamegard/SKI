using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGameOnButtonPress : MonoBehaviour {
    InputManagerStatic inputManagerStatic;

	// Use this for initialization
	void Start () {
        inputManagerStatic = GameObject.Find("InputManager").GetComponent<InputManagerStatic>();
	}
	
	// Update is called once per frame
	void Update () {
        bool[] inputButtonsArray;
        float[] inputAxisArray;
        inputManagerStatic.GetInputForPlayer(PlayerID.one, out inputButtonsArray, out inputAxisArray);
        if (inputButtonsArray[(int)InputButtonIndex.Action])
        {
            for (int i = 0; i < PlayerManager.vehiclesInScene.Length; i++)
            {
                PlayerManager.vehiclesInScene[i].GetComponent<CarController>().enabled = true;
            }
            GameObject.Find("GameManager").GetComponent<GameManager>().StartGame();
            gameObject.SetActive(false);
        }
	}
}
