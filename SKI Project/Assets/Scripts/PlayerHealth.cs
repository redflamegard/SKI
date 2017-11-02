using UnityEngine;
using System.Collections;
using System;

public class PlayerHealth : MonoBehaviour {

    enum DamageStatus {
    none, light, medium, heavy, critical };

    public float CurrentDamage{get{return currentDamage;}}
    [SerializeField]
    int livesStarting;

    int livesRemaining;

    //[SerializeField]
    //GameObject[] damageIndicatorPrefabs;
    //[SerializeField]
    //Transform vfxSpawnPoint;
    

    //GameObject showDamage;
    float currentDamage;

	// Use this for initialization
	void Start () {
        currentDamage = 0f;
        livesRemaining = livesStarting;
        //showDamage = new GameObject();
	}

    public bool CheckIsAlive() {
        //return currentDamage > 0;
        return true;
    }

    public void Damage(float damage) {
        currentDamage += damage;
        //if (currentDamage >= 75)
        //    UpdateDamageStatus(DamageStatus.critical);
        //else if (currentDamage < 75 && currentDamage >= 50)
        //    UpdateDamageStatus(DamageStatus.heavy);
        //else if (currentDamage < 50 && currentDamage >= 25)
        //    UpdateDamageStatus(DamageStatus.medium);
        //else if (currentDamage < 25 && currentDamage >= 1)
        //    UpdateDamageStatus(DamageStatus.light);
        //else if (currentDamage < 1)
        //    UpdateDamageStatus(DamageStatus.none);
    }

    //internal void Damage(object p)
    //{
        
    //}

    //private void UpdateDamageStatus(DamageStatus damageStatusTemp) {
        

    //    switch (damageStatusTemp)
    //    {
    //        case DamageStatus.light:
    //            ShowDamageLevel(0);
    //            break;
    //        case DamageStatus.medium:
    //            ShowDamageLevel(1);
    //            break;
    //        case DamageStatus.heavy:
    //            ShowDamageLevel(2);
    //            break;
    //        case DamageStatus.critical:
    //            ShowDamageLevel(3);
    //            RespawnWithCarController();
    //            break;
    //        default:
    //            break;
    //    }
    //}

    //private void ShowDamageLevel(int i) {
    //    Destroy(showDamage);
    //    showDamage = new GameObject();
    //    showDamage = Instantiate(damageIndicatorPrefabs[i], vfxSpawnPoint) as GameObject;
    //    showDamage.transform.parent = vfxSpawnPoint;
    //    showDamage.transform.localPosition = new Vector3(0, 0, 0);
    //}

    public void RespawnHealth() {
        //transform.gameObject.GetComponent<CarController>().SendMessage("Respawn");
        //moved off the CarController, will implement here
        livesRemaining--;
        if (livesRemaining > 0)
        {
            currentDamage = 0f;
        }
        else
        {
            //No more lives, tell game manager player isDead
        }
        //UpdateDamageStatus(DamageStatus.none);
        //Damage(0);
    }
}
