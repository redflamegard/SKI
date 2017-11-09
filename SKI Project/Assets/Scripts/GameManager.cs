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

    int countDownCount = 3;

    public void Start()
    {
        countDownText.text = countDownCount.ToString();
        //StartCoroutine(CountDown());   
    }

    public void EndGame(PlayerID winningPlayerID)
    {
        //winningPlayerText.text += winningPlayerID + 1;
        //endRoundPanel.SetActive(true);
    }


    public void GameStartCountDown()
    {
        if (countDownCount == 0)
        {
            foreach (GameObject players in PlayerManager.vehiclesInScene)
            {
                players.GetComponent<Rigidbody>().isKinematic = false;
            }
        }
    }

    public IEnumerator CountDown1()
    {
        if (countDownCount == 3)
        {
            yield return WaitForSeconds(1);
            countDownCount--;
            StartCoroutine(CountDown2());
        }
    }

    public IEnumerator CountDown2()
    {
        if (countDownCount == 2)
        {
            yield return countDownCount--;
        }
    }


}
