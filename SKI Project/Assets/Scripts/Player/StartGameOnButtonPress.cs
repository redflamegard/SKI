using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartGameOnButtonPress : MonoBehaviour {
    InputManagerStatic inputManagerStatic;
    FadingUI panelImage;
	// Use this for initialization
	void Start () {
        panelImage = GetComponent<FadingUI>();
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

            panelImage.FadeOutUI();
            
        }
	}
}
