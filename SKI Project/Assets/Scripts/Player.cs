using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void PlayerDieDelegate();

public class Player : MonoBehaviour {
    Color carColor;
    GameObject modelOfCar;
    bool isAlive;
    float currentDamage;
    string playerName;
    PlayerID playerID;


    private void PlayerSpawn()
    {
        PlayerManager.playersInScene[PlayerManager.playersInScene.Length] = new PlayerData(playerName, carColor, modelOfCar, playerID);
        isAlive = true;
        currentDamage = 0f;
    }

    private void GrabPickUp(GameObject pickUp)
    {
        //Instantiate shtuffs
        PlayerManager.AddPowerUpToPlayer(pickUp, playerID);

    }
}


