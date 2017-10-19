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
        rb = GetComponentInParent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject other = collision.gameObject;
        if (other.GetComponent<Rigidbody>())
        {
            if (Vector3.Project(rb.velocity, transform.position - collision.contacts[0].point).magnitude > 
                Vector3.Project(other.GetComponent<Rigidbody>().velocity, other.transform.position - collision.contacts[0].point).magnitude)
            {
                //Add explosive force to vehicle with lower agular velocity along collision trajectory proportionate to current damage of vehicle at a minimum of 1
                other.GetComponent<Rigidbody>().AddExplosionForce(explosionForceConstant * ((other.GetComponent<PlayerHealth>().CurrentDamage > 1f ? 0f : 1f) + 
                    other.GetComponent<PlayerHealth>().CurrentDamage), collision.contacts[0].point, explosionForceRadius);
                if (other.GetComponentInParent<PlayerHealth>())
                {
                    //Damage player if have health script proportionate to angular velocity along collision trajectory * impactDamageConstant
                    other.gameObject.GetComponentInParent<PlayerHealth>().Damage((Vector3.Project(rb.velocity, transform.position - collision.contacts[0].point).magnitude) * 
                        other.GetComponentInParent<PlayerHealth>().CurrentDamage * impactDamageConstant);

                }
            }
            else if(Vector3.Project(rb.velocity, transform.position - collision.contacts[0].point).magnitude > minimumForceForDamage)
            {
                GetComponentInParent<PlayerHealth>().Damage((Vector3.Project(rb.velocity, transform.position - collision.contacts[0].point).magnitude) * 
                    other.GetComponentInParent<PlayerHealth>().CurrentDamage * impactDamageConstant);
            }
        }
        else if (other.gameObject.CompareTag("DeadZone"))
        {
            GetComponent<CarController>().RespawnAtStartingLocation();
        }
    }
}
