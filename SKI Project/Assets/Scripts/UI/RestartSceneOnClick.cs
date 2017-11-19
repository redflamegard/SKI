using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartSceneOnClick : MonoBehaviour {
    [SerializeField]
    private string sceneToLoad;

    InputManagerStatic inputManager;

    public void OnClick()
    {
        SceneManager.LoadScene(sceneToLoad);
    }

    private void Start()
    {
        inputManager = GameObject.Find("GameManager").GetComponent<InputManagerStatic>();
    }

    private void Update()
    {
        float[] inputAxis;
        bool[] inputButtons;

        inputManager.GetInputForPlayer(PlayerID.one, out inputButtons, out inputAxis);

        if (inputButtons[(int)InputButtonIndex.Action])
        {
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
