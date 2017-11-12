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

    float countDownCount = 3f;

    public void Awake()
    {
        if(countDownText != null)
            countDownText.text = "" + countDownCount;
        for (int i = 0; i < PlayerManager.vehiclesInScene.Length; i++)
        {
            PlayerManager.vehiclesInScene[i].GetComponent<Rigidbody>().isKinematic = true;
        }
        //StartCoroutine(CountDown());   
    }

    public void EndGame(PlayerID winningPlayerID)
    {
        //winningPlayerText.text += winningPlayerID + 1;
        //endRoundPanel.SetActive(true);
    }

    private void Update()
    {
        countDownCount -= Time.deltaTime;

        countDownText.text = "" + (int)countDownCount;

        if (countDownCount <= 0)
        {
            for (int i = 0; i < PlayerManager.vehiclesInScene.Length; i++)
            {
                PlayerManager.vehiclesInScene[i].GetComponent<Rigidbody>().isKinematic = false;

            }
        }
    }
    
}
