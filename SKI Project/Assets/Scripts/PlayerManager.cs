using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Serialization;

public class PlayerManager : MonoBehaviour {
    public static PlayerData[] playersInScene;
    public static GameObject[] vehiclesInScene;

    public static event Action GrabPowerUp;
    

    public static void AddHealPowerUp(PlayerID _playerID)
    {
        for (int i = 0; i < vehiclesInScene.Length; i++)
        {
            if (_playerID == vehiclesInScene[i].GetComponent<CarController>()._PlayerID)
            {
                vehiclesInScene[i].GetComponent<PlayerPowerUpComponent>().AddHealPowerUp();
                playersInScene[i].AddPowerUp(PowerUpType.Heal);
            }
        }
    }
    
    public static void AddShieldPowerUp(PlayerID _playerID)
    {
        for (int i = 0; i < vehiclesInScene.Length; i++)
        {
            if (_playerID == vehiclesInScene[i].GetComponent<CarController>()._PlayerID)
            {
                vehiclesInScene[i].GetComponent<PlayerPowerUpComponent>().AddShieldPowerUp();
                playersInScene[i].AddPowerUp(PowerUpType.Shield);
            }
        }
    }
    public static void AddTorquePowerUp(PlayerID _playerID)
    {
        for (int i = 0; i < vehiclesInScene.Length; i++)
        {
            if (_playerID == vehiclesInScene[i].GetComponent<CarController>()._PlayerID)
            {
                vehiclesInScene[i].GetComponent<PlayerPowerUpComponent>().AddTorquePowerUp();
                playersInScene[i].AddPowerUp(PowerUpType.TorqueIncrease);
            }
        }
    }

    public static void AddCannonPowerUp(PlayerID _playerID)
    {
        for (int i = 0; i < vehiclesInScene.Length; i++)
        {
            if (_playerID == vehiclesInScene[i].GetComponent<CarController>()._PlayerID)
            {
                vehiclesInScene[i].GetComponent<PlayerPowerUpComponent>().AddCanonPowerUp();
                playersInScene[i].AddPowerUp(PowerUpType.Cannon);
            }
        }
    }

    //public static void AddGrapplingHookPowerUp(PlayerID _playerID)
    //{
    //    for (int i = 0; i < vehiclesInScene.Length; i++)
    //    {
    //        if (_playerID == vehiclesInScene[i].GetComponent<CarController>()._PlayerID)
    //        {
    //            //currentVehicle.SendMessage("InstantiateGrapplingHook");
    //        }
    //    }
    //}

    public static void PlayerDied(PlayerID id)
    {
        bool onePlayerAlive = false;
        bool twoPlayersAlive = false;
        PlayerID winningID = PlayerID.one;
        for (int i = 0; i < playersInScene.Length; i++)
        {
            if (id == playersInScene[i].PlayerID)
            {
                playersInScene[i].IsAlive = false;
                vehiclesInScene[i].GetComponent<CarController>().enabled = false;

            }
            if (playersInScene[i].IsAlive == true)
            {
                if (onePlayerAlive == false)
                {
                    onePlayerAlive = true;
                    winningID = playersInScene[i].PlayerID;
                }
                else if(twoPlayersAlive == false)
                {
                    twoPlayersAlive = true;
                }
            }
        }

        if (!twoPlayersAlive)
        {
            GameManager gameManager = null;
            try { gameManager = GameObject.Find("GameManager").GetComponent<GameManager>(); }
            catch { throw new Exception("Scene must contain a GameManager called GameManager"); }
            if (gameManager != null)
                gameManager.EndGame(winningID);
        }

    }

    private void Awake()
    {
        CarController [] cars = GameObject.FindObjectsOfType<CarController>();
        playersInScene = new PlayerData[cars.Length];
        for (int i = 0; i < playersInScene.Length; i++)
        {
            playersInScene[i] = new PlayerData("PlayerSaveSlot_1", Color.white, CarModelType.Ninja, cars[i]._PlayerID);
        }
    }
}


//Enums for save data
public enum PowerUpType { TorqueIncrease, Cannon, GrapplingHook, Shield, Heal };
public enum CarModelType { Ninja, Prehistoric, Castle, Hover };

public class PlayerData
{
    public bool IsAlive { get { return isAlive; } set { isAlive = value; } }
    public PlayerID PlayerID{ get { return playerID; } set { playerID = value; } }
    public CarModelType CarModel { get { return modelOfCar; } }

    [XmlElement]
    private PlayerID playerID;
    [XmlElement]
    bool isAlive = true;
    PowerUpType currentPowerUp;

    Color carColor;
    CarModelType modelOfCar;
    int roundsWon;
    int livesLeft;

    string playerName;

    public void AddPowerUp(PowerUpType powerUpObj)
    {
        currentPowerUp = powerUpObj;
    }

    //created at start of the round AFTER track / vehicle selection completed
    //Game Manager tells player manager to instantiate new PlayerData objects, sends save profile / selection info
    public PlayerData(string name, Color colorOfCar, CarModelType carModel, PlayerID playerID)
    {
        //Pull achievement data form XML else create new XML

        //set current selection values
        carColor = colorOfCar;
        modelOfCar = carModel;
        playerName = name;
        this.PlayerID = playerID;

    }

    //void OnGameOver(){
        //Save end of round totals to XML

    //}
}