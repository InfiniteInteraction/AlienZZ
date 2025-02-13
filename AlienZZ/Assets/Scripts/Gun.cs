﻿using UnityEngine;
using UnityEngine.SceneManagement;

public class Gun : MonoBehaviour
{
    public Transform spawnPoint; //Point the raycast will originate from
    public LayerMask layerMask; //The layer mask that detects enemy
    public float damageValue = 0;
    [Header("Ammo")]
    public int currAmmo = 10;
    public int maxAmmo = 20;
    public int ammoReturn = 3;
    [Header("Weapon Firing")]
    public bool canShoot = false;
    public bool fullAutoMode = false;
    public float currTime = 0;
    public float shootTime = 0;
    public float fullAutoTime = 0;
    public float semiAutoTime = 0;

    void Start()
    {
        currAmmo = maxAmmo;
        currTime = shootTime;
        fullAutoMode = false;
        damageValue = 1;
    }

    void Update()
    {        
        RaycastHit hit;
        if(currTime >= shootTime)
        {
            canShoot = true;            
        }
        else
        {
            currTime += Time.deltaTime;
            canShoot = false;
        }
        if (Input.GetMouseButtonDown(0) )//&& canShoot && currAmmo > 0)
        {
            GameManager.gameManager.shotsFired++;
            if (Physics.Raycast(spawnPoint.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, layerMask))
            {
                hit.collider.GetComponent<ENemyHealth>().TakeDamage(20);
                Debug.DrawRay(spawnPoint.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
                RegainAmmo();
                GameManager.gameManager.hits++;
                Debug.Log("Did Hit");
            }
            else
            {
                Debug.DrawRay(spawnPoint.position, transform.TransformDirection(Vector3.forward) * 1000, Color.red);
                ReduceAmmo();               
            }
            currTime = 0;
        }
        if (Input.GetMouseButton(0) && currAmmo <= 0)
        {
            Debug.Log("Out of Ammo");
        }
        
    }

    void ReduceAmmo()
    {
        currAmmo--;
        currAmmo = Mathf.Clamp(currAmmo, 0, maxAmmo);
    }

    void RegainAmmo()
    {
        currAmmo += ammoReturn;
        currAmmo = Mathf.Clamp(currAmmo, 0, maxAmmo);
    }

    void SwitchFireMode()
    {
        fullAutoMode = !fullAutoMode;
        if (fullAutoMode == true)
        {
            shootTime = fullAutoTime;
        }
        else
        {
            shootTime = semiAutoTime;
        }
    }
}