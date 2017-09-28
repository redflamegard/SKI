using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonController : MonoBehaviour {
    public PlayerID currentPlayerID;
    [SerializeField]
    float rotationSpeed;
    [SerializeField]
    float aimSpeed;
    [SerializeField]
    GameObject cannonBallPrefab;
    [SerializeField]
    Transform shotPoint;
    [SerializeField]
    float shotForce;

    private bool isRotating = false;

    private void Update()
    {
        if (Input.GetAxis("Horizontal") != 0f || Input.GetAxis("Vertical") != 0f)
        {
            isRotating = true;
        }
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        GameObject shot = Instantiate(cannonBallPrefab, shotPoint.position, Quaternion.identity);
        shot.GetComponent<Rigidbody>().AddForce(0f, 0f, shotForce);
    }

    private void FixedUpdate()
    {
        if (isRotating)
        {
            RotateCannon();
        }
        
    }
    
    private void RotateCannon()
    {
        float lookRotation = transform.localEulerAngles.y + Mathf.Clamp(Input.GetAxis("Horizontal"), -1f, 1f) * rotationSpeed * Time.deltaTime;
        float aimRotation = transform.localEulerAngles.x + Mathf.Clamp(Input.GetAxis("Vertical"), -1f, 1f) * aimSpeed * Time.deltaTime;
        
        transform.localEulerAngles = new Vector3(aimRotation, lookRotation, 0);
    }
}
