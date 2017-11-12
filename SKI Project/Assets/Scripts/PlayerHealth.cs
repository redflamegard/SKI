using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

    enum DamageStatus {
    none, light, medium, heavy, critical };

    
    private IEnumerator StopShieldingAfterSeconds(float shieldTime)
    {
        yield return new WaitForSeconds(shieldTime);
        isShielded = false;
    }

    public int LivesRemaining { get { return livesRemaining; } }
    public float CurrentDamage{get{return currentDamage;}}
    [SerializeField]
    int livesStarting;
    [SerializeField]
    float shieldingTime;

    bool isShielded = false;
    int livesRemaining;



    //[SerializeField]
    //GameObject[] damageIndicatorPrefabs;
    //[SerializeField]
    //Transform vfxSpawnPoint;
    

    //GameObject showDamage;
    float currentDamage;



    #region UI_Stuffs
    [SerializeField]
    float maxHealth = 250f;
    [SerializeField]
    Slider healthSlider;
    [SerializeField]
    Text livesRemainingText;


    #endregion

    // Use this for initialization
    void Awake () {

        //showDamage = new GameObject();
        ResetUIValues();
	}

    void ResetUIValues()
    {
        currentDamage = 0f;
        livesRemaining = livesStarting;
        healthSlider.maxValue = maxHealth;
        healthSlider.value = maxHealth;
    }
    

    public void Damage(float damage) {
        if(!isShielded)
            currentDamage += damage;
        if (damage == -1)   //Heal pickUp
            currentDamage = 0;
        healthSlider.value = maxHealth - currentDamage;
        Debug.Log("Player: " + GetComponent<CarController>()._PlayerID + "Current Damage: " + currentDamage);
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

    public void ActivateShield()
    {
        isShielded = true;
        StartCoroutine(StopShieldingAfterSeconds(shieldingTime));
    }

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
            PlayerManager.PlayerDied(GetComponent<CarController>()._PlayerID);
            livesRemainingText.text = "" + livesRemaining;
            //No more lives, tell game manager player isDead
        }
        //UpdateDamageStatus(DamageStatus.none);
        //Damage(0);
    }
}
