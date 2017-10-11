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
}


//public enum PlayerID { one, two, three, four };

public class PlayerData
{
    public PlayerID playerID;
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