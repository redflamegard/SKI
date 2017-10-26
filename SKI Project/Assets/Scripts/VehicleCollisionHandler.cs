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

    Rigidbody rb;
    [SerializeField]
    float minimumForceForDamage;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    
    private void OnTriggerEnter(Collider collider)
    {
        Rigidbody other_RB;
        if (collider.GetComponent<Rigidbody>())
            other_RB = collider.GetComponent<Rigidbody>();
        else other_RB = null;
        PlayerHealth other_Health;
        if (collider.GetComponent<PlayerHealth>())
            other_Health = collider.GetComponent<PlayerHealth>();
        else other_Health = null;

        bool otherHasRigidbody = other_RB != null;
        if (otherHasRigidbody)
        {
            bool rigBodyCollidedSameAsMine = other_RB.gameObject != rb.gameObject;
            if (!rigBodyCollidedSameAsMine && collider.GetComponent<CarController>())
            {
                if (Vector3.Project(rb.velocity, transform.position - collider.transform.position).magnitude > 
                    Vector3.Project(other_RB.velocity, collider.transform.position - transform.position).magnitude)
                {
                    float forceToAdd = (explosionForceConstant * ((other_Health.CurrentDamage > 1f ? 0f : 1f) +
                        other_Health.CurrentDamage));
                    if (forceToAdd >= 3000000f)
                        forceToAdd = 3000000f;
                    //Add explosive force to vehicle with lower agular velocity along collision trajectory proportionate to current damage of vehicle at a minimum of 1
                    other_RB.AddExplosionForce(forceToAdd, transform.position, explosionForceRadius);
                    Debug.Log("Explosive force added: " + forceToAdd);
                    if (other_Health)
                    {
                        //Damage player if have health script proportionate to angular velocity along collision trajectory * impactDamageConstant
                        other_Health.Damage(Vector3.Project(rb.velocity, transform.position - collider.transform.position).magnitude *
                            ((other_Health.CurrentDamage > 1f ? 0f : 1f) + other_Health.CurrentDamage) * impactDamageConstant);

                    }
                }
                else if(Vector3.Project(rb.velocity, transform.position - transform.position).magnitude > minimumForceForDamage)
                {
                    GetComponent<PlayerHealth>().Damage((Vector3.Project(rb.velocity, transform.position - collider.transform.position).magnitude) * 
                        collider.GetComponent<PlayerHealth>().CurrentDamage * impactDamageConstant);
                }
            }
        }
        else if (collider.gameObject.CompareTag("DeadZone"))
        {
            GetComponent<CarController>().RespawnAtStartingLocation();
        }
    }
}
