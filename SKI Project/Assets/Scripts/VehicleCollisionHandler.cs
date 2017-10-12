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
    float minimumForceForDamage;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject other = collision.gameObject;
        if (other.GetComponent<Rigidbody>())
        {
            if (Vector3.Project(rb.velocity, transform.position - collision.contacts[0].point).magnitude > 
                Vector3.Project(other.GetComponent<Rigidbody>().velocity, other.transform.position - collision.contacts[0].point).magnitude)
            {
                other.GetComponent<Rigidbody>().AddExplosionForce(explosionForceConstant * (1f + other.GetComponent<PlayerHealth>().CurrentDamage), 
                    collision.contacts[0].point, explosionForceRadius);
                other.gameObject.GetComponent<PlayerHealth>().Damage((Vector3.Project(rb.velocity, transform.position - collision.contacts[0].point).magnitude) * other.GetComponent<PlayerHealth>().CurrentDamage *
                impactDamageConstant);
            }
        }
        else if(Vector3.Project(rb.velocity, transform.position - collision.contacts[0].point).magnitude > minimumForceForDamage)
        {
            GetComponent<PlayerHealth>().Damage((Vector3.Project(rb.velocity, transform.position - collision.contacts[0].point).magnitude) * other.GetComponent<PlayerHealth>().CurrentDamage *
                impactDamageConstant);
        }
    }
}
