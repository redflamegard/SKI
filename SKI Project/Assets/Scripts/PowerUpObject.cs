using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PowerUpObject : MonoBehaviour {

    [SerializeField]
    private PowerUpType powerUpGet;

    PlayerID playerIDThatHit;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<CarController>())
        {
            playerIDThatHit = other.gameObject.GetComponent<CarController>()._PlayerID;

            switch (powerUpGet)
            {
                case PowerUpType.TorqueIncrease:
                    PlayerManager.GrabPowerUp += GrabTorquePowerUp;
                    break;
                case PowerUpType.Cannon:
                    PlayerManager.GrabPowerUp += GrabCannonPowerUp;
                    break;
                case PowerUpType.GrapplingHook:
                    PlayerManager.GrabPowerUp += GrabGrapplingHook;
                    break;
                default:
                    break;
            }
        }
    }
    
    private void GrabTorquePowerUp()
    {
        PlayerManager.AddTorquePowerUp(playerIDThatHit);
    }

    private void GrabCannonPowerUp()
    {
        PlayerManager.AddCannonPowerUp(playerIDThatHit);
    }

    private void GrabGrapplingHook()
    {

    }

}
