using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerPowerUpComponent : MonoBehaviour {
    [SerializeField]
    GameObject canonPrefab;

    GameObject canonInUse;
    InputManagerStatic inputMan;
    bool hasPowerUp = false;
    PowerUpType currentPowerUp;

    private void Awake()
    {
        inputMan = GameObject.Find("InputManager").GetComponent<InputManagerStatic>();
    }
    private void Update()
    {
        bool[] inputButtons;
        float[] inputAxiis;
        inputMan.GetInputForPlayer(GetComponent<CarController>()._PlayerID, out inputButtons, out inputAxiis);
        if (inputButtons[(int)InputButtonIndex.Action] && hasPowerUp)
        {
            ActivatePowerUp();
            hasPowerUp = false;
        }
    }

    private void ActivatePowerUp()
    {
        switch (currentPowerUp)
        {
            case PowerUpType.TorqueIncrease:
                GetComponent<CarController>().SendMessage("TorqueIncreasePowerUp");
                break;
            case PowerUpType.Cannon:
                //FIRE!
                break;
            case PowerUpType.GrapplingHook:
                Debug.Log("Grappling hook not setup yet");
                break;
            case PowerUpType.Shield:
                GetComponent<PlayerHealth>().ActivateShield();
                break;
            case PowerUpType.Heal:
                GetComponent<PlayerHealth>().Damage(-1f);
                break;
            default:
                break;
        }
    }

    public void AddTorquePowerUp()
    {
        if (!hasPowerUp)
            currentPowerUp = PowerUpType.TorqueIncrease;
    }

    public void AddCanonPowerUp()
    {
        if (!hasPowerUp)
        {
            canonInUse = Instantiate(canonPrefab, transform);
            currentPowerUp = PowerUpType.Cannon;
        }
    }
    

    public void AddHealPowerUp()
    {
        if (!hasPowerUp)
            currentPowerUp = PowerUpType.Heal;
    }

    public void AddShieldPowerUp()
    {
        if (!hasPowerUp)
            currentPowerUp = PowerUpType.Shield;
    }

    //private void DoHeal()
    //{
    //    GetComponent<PlayerHealth>().Damage(-1);
    //}
}
