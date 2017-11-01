using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
    [SerializeField]
    GameObject endRoundPanel;
    [SerializeField]
    Text winningPlayerText;

    public void EndGame(PlayerID winningPlayerID)
    {
        winningPlayerText.text += winningPlayerID + 1;
        endRoundPanel.SetActive(true);
    }
}
