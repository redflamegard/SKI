using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DongCollider : MonoBehaviour {

	public DongExplosion dongExplosion;

	bool canCoolDown;

	public float explosionCoolDownTimer;// how long until canExplode can be triggered again
	float maxTimer;

	// Use this for initialization
	void Start () 
	{
		maxTimer = explosionCoolDownTimer;

		dongExplosion = GetComponentInChildren<DongExplosion> ();
	}
	
	// Update is called once per frame
	void Update () 
	{

		//FOR IF WE WANT A TIMER?
		//if (canCoolDown) 
		//{
			//explosionCoolDownTimer -= Time.deltaTime;

			//if (explosionCoolDownTimer <= 0) 
			//{
				//dongExplosion
				//canCoolDown = false;
				//explosionCoolDownTimer = maxTimer;
			//}
	}	

	void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.tag == "Player") 
		{
			dongExplosion.CreateExplosion ();

			//dongExplosion.canExplode = true;

			//canCoolDown = true;
		}
	}
}
