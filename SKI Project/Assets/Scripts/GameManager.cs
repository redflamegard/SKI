using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
    [SerializeField]
    GameObject endRoundPanel;
    [SerializeField]
    Text winningPlayerText;
    [SerializeField]
    Text countDownText;
    [SerializeField]
    Text roundCountDownText;

    bool hasStartedRoundCountdown = false;
    float countDownCount = 3f;
    float gameCountDownTime = 99f;

    public void Awake()
    {
        if (countDownText != null)
            countDownText.text = "" + countDownCount;
        if (PlayerManager.vehiclesInScene == null)
        {
            InstantiateVehiclesInScene();
        }
        else
        {
            StartCoroutine(InstantiateVehiclesInSceneAtEndOfFrame());
        }

        hasStartedRoundCountdown = false;
        //StartCoroutine(CountDown());   
    }

    private IEnumerator InstantiateVehiclesInSceneAtEndOfFrame()
    {
        yield return new WaitForEndOfFrame();
        InstantiateVehiclesInScene();
    }

    private static void InstantiateVehiclesInScene()
    {
        for (int i = 0; i < PlayerManager.vehiclesInScene.Length; i++)
        {
            PlayerManager.vehiclesInScene[i].GetComponent<Rigidbody>().isKinematic = true;
        }
    }

    public void EndGame(PlayerID winningPlayerID)
    {
        winningPlayerText.text += winningPlayerID;
        endRoundPanel.SetActive(true);
    }

    void EndGame(PlayerID [] winningPlayerIDList)
    {
        winningPlayerText.text = "  Tie Game!";
        endRoundPanel.SetActive(true);
    }

    private void Update()
    {
        countDownCount -= Time.deltaTime;
        if (countDownText.enabled == true)
        {
            countDownText.text = " " + ((int)countDownCount + 1);
        }
        else
        {
            roundCountDownText.text = " " + ((int)countDownCount + 1);
        }

        if (countDownCount <= 0)
        {
            if(hasStartedRoundCountdown)
            {
                PlayerID winningID = PlayerID.one;
                List<PlayerID> winningIDList = new List<PlayerID>();

                int highestLives = PlayerManager.vehiclesInScene[0].GetComponent<PlayerHealth>().LivesRemaining;
                bool hasMatch = false;
                for (int i = 0; i < PlayerManager.vehiclesInScene.Length; i++)
                {
                    PlayerHealth currentPlayerHealth = PlayerManager.vehiclesInScene[i].GetComponent<PlayerHealth>();
                    CarController currentCarController = PlayerManager.vehiclesInScene[i].GetComponent<CarController>();

                    if (currentPlayerHealth.LivesRemaining == highestLives)
                    {
                        hasMatch = true;
                        winningIDList.Add(currentCarController._PlayerID);
                    }
                    if (currentPlayerHealth.LivesRemaining > highestLives)
                    {
                        winningID = currentCarController._PlayerID;
                        winningIDList.Clear();
                        winningIDList.Add(currentCarController._PlayerID);
                        hasMatch = false;
                    }
                }
                if (hasMatch)
                {
                    EndGame(winningIDList.ToArray());
                }
                else
                {
                    EndGame(winningID);
                }
                hasStartedRoundCountdown = false;
                countDownCount = gameCountDownTime;
            }
            if (!hasStartedRoundCountdown)
            {
                for (int i = 0; i < PlayerManager.vehiclesInScene.Length; i++)
                {
                    PlayerManager.vehiclesInScene[i].GetComponent<Rigidbody>().isKinematic = false;
                }
                hasStartedRoundCountdown = true;
                countDownCount = gameCountDownTime;
                countDownText.enabled = false;
            }
        }
    }
    
}
