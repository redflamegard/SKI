﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartSceneOnClick : MonoBehaviour {
    [SerializeField]
    private string sceneToLoad;

    public void OnClick()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}
