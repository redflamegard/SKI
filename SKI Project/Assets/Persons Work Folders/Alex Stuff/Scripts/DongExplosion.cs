using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DongExplosion : MonoBehaviour {

	List<GameObject> carsInRadius = new List<GameObject> ();//holds all cars currently in sphere for explosion force to be added to

	public bool canExplode;//Dong script tells this to trigger explosion when car hits dong collider

	public float radius = 5.0f;
	public float power = 10.0f;

	Vector3 explosionPos;

	void Start()
	{
		explosionPos = this.transform.position;//origin point for explosion center of dong with this, right?
		//Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);
	}

	void Update () 
	{
		//if (canExplode) 
		//{
			//foreach (GameObject g in carsInRadius)
			//{
				//Rigidbody rb = g.GetComponentInParent<Rigidbody>();

				//rb.AddExplosionForce(power, explosionPos, radius, 3.0F);
			//}
	}

	public void CreateExplosion()
	{
		foreach (GameObject g in carsInRadius)
		{
			Rigidbody rb = g.GetComponentInParent<Rigidbody>();

			rb.AddExplosionForce(power, explosionPos, radius, 3f);
		}
	}

	void OnTriggerStay(Collider other)
	{
		if (other.gameObject.tag == "Player") 
		{
			print ("car in");
			carsInRadius.Add (other.gameObject);
		}
	}

	void OnTriggerExit(Collider other)
	{
		print ("car out");
		if (other.gameObject.tag == "Player") 
		{
			carsInRadius.Remove(other.gameObject);
		}
	}
}
