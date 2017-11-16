using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PowerUpObject : MonoBehaviour {

    [SerializeField]
    private PowerUpType powerUpGet;
    [SerializeField]
    float secondsToWait;

    PlayerID playerIDThatHit;
    AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponentInParent<CarController>())
        {
            audioSource.Play();
            playerIDThatHit = other.gameObject.GetComponentInParent<CarController>()._PlayerID;

            switch (powerUpGet)
            {
                case PowerUpType.TorqueIncrease:
                    PlayerManager.GrabPowerUp += GrabTorquePowerUp;
                    break;
                case PowerUpType.Cannon:
                    PlayerManager.GrabPowerUp += GrabCannonPowerUp;
                    break;
                case PowerUpType.GrapplingHook:
                    //PlayerManager.GrabPowerUp += GrabGrapplingHook;
                    Debug.Log("Grappling Hook not implimented yet. Error, Error.");
                    break;
                case PowerUpType.Shield:
                    PlayerManager.GrabPowerUp += AddShieldPowerUp;
                    break;
                case PowerUpType.Heal:
                    PlayerManager.GrabPowerUp += AddHealPowerUp;
                    break;
                default:
                    break;
            }
            GetComponent<MeshRenderer>().enabled = false;
            StartCoroutine(DestroySelfAfterSeconds(secondsToWait));
        }
    }

    private IEnumerator DestroySelfAfterSeconds(float secondsToWait)
    {
        yield return new WaitForSeconds(secondsToWait);
        Destroy(gameObject);
    }

    private void AddHealPowerUp()
    {
        PlayerManager.AddHealPowerUp(playerIDThatHit);
    }

    private void AddShieldPowerUp()
    {
        PlayerManager.AddShieldPowerUp(playerIDThatHit);
    }
    private void GrabTorquePowerUp()
    {
        PlayerManager.AddTorquePowerUp(playerIDThatHit);
    }

    private void GrabCannonPowerUp()
    {
        PlayerManager.AddCannonPowerUp(playerIDThatHit);
    }

    //private void GrabGrapplingHook()
    //{
    //    PlayerManager.AddGrapplingHookPowerUp(playerIDThatHit);
    //}

}
