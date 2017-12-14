﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerPowerUpComponent : MonoBehaviour {
    //[SerializeField]
    //GameObject canonPrefab;
    //[SerializeField]
    //Transform canonBallSpawnTransform;
    [SerializeField]
    Image[] powerUpImages;
    [SerializeField]
    Image UI_PowerUpImage;
    [SerializeField]
    AudioClip audioClip_CanonFire;
    [SerializeField]
    AudioClip audioClip_Shield;
    [SerializeField]
    AudioSource audioSource_Impact;

    GameObject canonInUse;
    InputManagerStatic inputMan;
    bool hasPowerUp = false;
    PowerUpType currentPowerUp;

    private void Awake()
    {
        if(UI_PowerUpImage != null)
            UI_PowerUpImage.enabled = false;
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
        UI_PowerUpImage.enabled = false;
        switch (currentPowerUp)
        {
            case PowerUpType.TorqueIncrease:
                GetComponent<CarController>().SendMessage("TorqueIncreasePowerUp");
                break;
            case PowerUpType.Cannon:
                audioSource_Impact.clip = audioClip_CanonFire;
                audioSource_Impact.Play();
                break;
            case PowerUpType.GrapplingHook:
                Debug.Log("Grappling hook not setup yet");
                break;
            case PowerUpType.Shield:
                GetComponent<PlayerHealth>().ActivateShield();
                audioSource_Impact.clip = audioClip_Shield;
                audioSource_Impact.Play();
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
        {
            UI_PowerUpImage.enabled = true;
            currentPowerUp = PowerUpType.TorqueIncrease;
            UI_PowerUpImage.sprite = powerUpImages[(int)PowerUpType.TorqueIncrease].sprite;
        }
    }

    public void AddCanonPowerUp()
    {
        if (!hasPowerUp)
        {
            UI_PowerUpImage.enabled = true;
            //canonInUse = Instantiate(canonPrefab, transform);
            currentPowerUp = PowerUpType.Cannon;
            UI_PowerUpImage.sprite = powerUpImages[(int)PowerUpType.Cannon].sprite;
        }
    }
    

    public void AddHealPowerUp()
    {
        if (!hasPowerUp)
        {
            UI_PowerUpImage.enabled = true;
            currentPowerUp = PowerUpType.Heal;
            UI_PowerUpImage.sprite = powerUpImages[(int)PowerUpType.Heal].sprite;
        }
    }

    public void AddShieldPowerUp()
    {
        if (!hasPowerUp)
        {
            UI_PowerUpImage.enabled = true;
            currentPowerUp = PowerUpType.Shield;
            UI_PowerUpImage.sprite = powerUpImages[(int)PowerUpType.Shield].sprite;
        }
    }

    //private void DoHeal()
    //{
    //    GetComponent<PlayerHealth>().Damage(-1);
    //}
}
