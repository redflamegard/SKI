using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {
    public static PlayerData[] playersInScene;

    public static event Action<GameObject, PlayerID> GrabPowerUp;

    public static void AddPowerUpToPlayer(GameObject powerUp, PlayerID id)
    {
        GrabPowerUp += PlayerManager_GrabPowerUp;
    }

    private static void PlayerManager_GrabPowerUp(GameObject powerUpToAdd, PlayerID id)
    {
        foreach (var player in playersInScene)
        {
            if (id == player.playerID)
            {
                player.AddPowerUp(powerUpToAdd);
            }
        }
    }

    public static void PlayerDied(PlayerID id)
    {
        bool onePlayerAlive = false;
        bool twoPlayersAlive = false;
        PlayerID winningID = PlayerID.one;

        for (int i = 0; i < playersInScene.Length; i++)
        {
            if (id == playersInScene[i].playerID)
            {
                playersInScene[i].IsAlive = false;
            }
            if (playersInScene[i].IsAlive == true)
            {
                if (onePlayerAlive == false)
                {
                    onePlayerAlive = true;
                    winningID = playersInScene[i].playerID;
                }
                else if(twoPlayersAlive == false)
                {
                    twoPlayersAlive = true;
                }
            }
        }

        if (!twoPlayersAlive)
        {
            GameManager_New gameManager = null;
            try { gameManager = GameObject.Find("GameManager").GetComponent<GameManager_New>(); }
            catch { throw new Exception("Scene must contain a GameManager called GameManager"); }
            if (gameManager != null)
                gameManager.EndGame(winningID);
        }

    }
}


//public enum PlayerID { one, two, three, four };

public class PlayerData
{
    public PlayerID playerID;
    public bool IsAlive { get { return isAlive; } set { isAlive = value; } }
    bool isAlive = true;
    GameObject currentPowerUp;
    Color carColor;
    GameObject modelOfCar;
    int roundsWon;
    int livesLeft;

    string playerName;

    public void AddPowerUp(GameObject powerUpObj)
    {
        currentPowerUp = powerUpObj;
    }

    public PlayerData(string name, Color colorOfCar, GameObject carModel, PlayerID playerID)
    {
        carColor = colorOfCar;
        modelOfCar = carModel;
        playerName = name;
        this.playerID = playerID;
    }
}