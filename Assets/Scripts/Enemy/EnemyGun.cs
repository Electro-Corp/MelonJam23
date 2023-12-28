using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGun : MonoBehaviour
{
    public Transform player;
    public Camera cam;
    public ParticleSystem flash;
    public float damage = 10f;
    public float range = 100f;
    public float fireRate = 15f;
    private float nextTimeFire = 0f;



    public int ammo, maxAmmo;
    public float reloadTime = 5f;
    public float prevT;
    public bool reloading;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(player);
        if (reloading && Time.fixedTime - prevT > reloadTime)
        {
            reloading = false;
            ammo = maxAmmo;
        }
    }

    public void decideShoot()
    {
        if (Time.time >= nextTimeFire && !reloading)
        {
            Debug.Log("Im shooin");
            nextTimeFire = Time.time + 1f / fireRate;
            shoot();
        }
    }

    void shoot()
    {
        ammo--;
        flash.Play();
        RaycastHit hit;
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range))
        {
            Human e = hit.transform.GetComponent<Human>();
            if (e != null)
            {
                e.takeDamage(10.0f, transform.parent);
            }
        }
        if (ammo < 1)
        {
            prevT = Time.fixedTime;
            reloading = true;
        }
    }
}