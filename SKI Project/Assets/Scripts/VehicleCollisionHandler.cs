using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleCollisionHandler : MonoBehaviour {


    [SerializeField]
    float explosionForceConstant;
    [SerializeField]
    float explosionForceRadius;
    [SerializeField]
    float impactDamageConstant;
    [SerializeField]
    float minimumVelocityForDamage;
    [SerializeField]
    private float impulseMagnitudeReductionDivider;
    [SerializeField]
    AudioClip audioClip_vehicleCollision;
    [SerializeField]
    AudioClip audioClip_objectCollision;
    [SerializeField]
    AudioSource audioSource_Impact;

    Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        audioSource_Impact = GetComponent<AudioSource>();

    }
    

    

    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("Collision Registered");
        Rigidbody other_RB = null;
        if (collision.gameObject.GetComponent<Rigidbody>())
            other_RB = collision.gameObject.GetComponent<Rigidbody>();

        PlayerHealth other_Health = null;
        if (collision.gameObject.GetComponent<PlayerHealth>())
            other_Health = collision.gameObject.GetComponent<PlayerHealth>();

        
        if (other_RB != null)
        {
            PlayVehicleCollisionSound();
            //Debug.Log("Found other rigidbody");
            bool rigBodyCollidedSameAsMine = (other_RB.gameObject == rb.gameObject);
            ContactPoint[] contactPoints = collision.contacts;
            float myAngularVelocity = Vector3.Project(rb.velocity, transform.position - contactPoints[0].point).magnitude;
            float otherAngularVelocity = Vector3.Project(other_RB.velocity, collision.transform.position - contactPoints[0].point).magnitude;

            if (!rigBodyCollidedSameAsMine && collision.gameObject.GetComponent<CarController>())
            {
                bool hasAdvantage = false;

                //Debug.Log("Player: " + GetComponent<CarController>()._PlayerID + 
                //    "\nAngular Velocity: " + myAngularVelocity +
                //    "Other Player: " + collision.gameObject.GetComponent<CarController>()._PlayerID +
                //    "\nOther Angular Velocity: " + otherAngularVelocity);

                for (int i = 0; i < contactPoints.Length; i++)
                {
                if (myAngularVelocity > otherAngularVelocity)
                        hasAdvantage = true;
                }

                if (hasAdvantage)
                {
                    float forceToAdd = (explosionForceConstant * (collision.impulse.magnitude / impulseMagnitudeReductionDivider) * ((other_Health.CurrentDamage > 1f ? 0f : 1f) +
                        other_Health.CurrentDamage));
                    if (forceToAdd >= 3000000f)
                        forceToAdd = 3000000f;
                    //Add explosive force to vehicle with lower agular velocity along collision trajectory proportionate to current damage of vehicle at a minimum of 1
                    
                    other_RB.AddExplosionForce(forceToAdd, contactPoints[0].point, explosionForceRadius, 1f, ForceMode.Impulse);
                    Debug.Log("Explosive force added: " + forceToAdd + "Impulse magnitude: " + collision.impulse.magnitude);

                    if (other_Health != null)
                    {
                        //Damage player if have health script proportionate to angular velocity along collision trajectory * impactDamageConstant
                        other_Health.Damage((myAngularVelocity - otherAngularVelocity) *
                            /*((other_Health.CurrentDamage > 1f ? 0f : 1f) + other_Health.CurrentDamage) **/ impactDamageConstant);

                    }
                }
                //static object with a rigidbody
                else if(other_RB.velocity.magnitude <= 2f && !collision.gameObject.GetComponent<PlayerHealth>() &&
                    myAngularVelocity > minimumVelocityForDamage)
                {
                    GetComponent<PlayerHealth>().Damage((myAngularVelocity - otherAngularVelocity) * 
                        GetComponent<PlayerHealth>().CurrentDamage * impactDamageConstant);
                }
            }
        }
        else if (collision.gameObject.CompareTag("DeadZone"))
        {
            PlayerManager.PlayerDied(GetComponent<CarController>()._PlayerID);
            GetComponent<CarController>().SendMessage("RespawnAtStartingLocation");
        }
        else if (collision.gameObject.GetComponent<MeshCollider>())
        {
            PlayObjectCollisionSound();
        }
    }

    private void PlayObjectCollisionSound()
    {
        audioSource_Impact.clip = audioClip_objectCollision;
        audioSource_Impact.loop = false;
        audioSource_Impact.Play();
    }

    private void PlayVehicleCollisionSound()
    {
        audioSource_Impact.clip = audioClip_vehicleCollision;
        audioSource_Impact.loop = false;
        audioSource_Impact.Play();
    }
    
}
