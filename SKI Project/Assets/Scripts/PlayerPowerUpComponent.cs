using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPowerUpComponent : MonoBehaviour {
    [SerializeField]
    GameObject canonPrefab;
    [SerializeField]
    float cooldownTime = 3f;

    GameObject canonInUse;
    public void AddCanonPowerUp()
    {
        canonInUse = Instantiate(canonPrefab, transform);
        StartCoroutine(CanonCooldown(cooldownTime));
    }

    private IEnumerator CanonCooldown(float cooldownTime)
    {
        yield return new WaitForSeconds(cooldownTime);
        Destroy(canonInUse);
    }
}
