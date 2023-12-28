using UnityEngine;
using System.Collections;
using TMPro;
public class PlayerGun : MonoBehaviour
{

    public float damage = 10f;
    public float range = 100f;
    public float fireRate = 15f;
    public Camera cam;
    public ParticleSystem flash;

    private float nextTimeFire = 0f;
    private float mov = 0f;

    public int maxAmmo = 100;
    public int ammo;

    public float reloadTime = 1f;
    public float prevT;
    public bool reloading;

    public TextMeshProUGUI ammoUI;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        ammo = maxAmmo;
    }

    // Update is called once per frame
    void Update()
    {
        ammoUI.text = "Ammo: " + ammo;
        if (reloading && (Time.fixedTime - prevT) > reloadTime)
        {
            reloading = false;
            transform.parent.GetComponent<GunAnim>().reloading = false;
            transform.GetComponent<Animator>().Play("New State");
            Debug.Log("Reload finished : " + (Time.fixedTime - prevT));
            ammo = maxAmmo;
        }

        if (!reloading && Input.GetButton("Fire1") && Time.time >= nextTimeFire)
        {
            mov = 0f;
            nextTimeFire = Time.time + 1f / fireRate;
            Shoot();
            // transform.Rotate(0.0f, 0.0f, Mathf.Sin(Time.time) * 20.0f, Space.Self);
            // mov += Mathf.Sin(Time.time) * 20.0f;
        }

        if (transform.rotation.eulerAngles.z != 0.0f)
        {
            // transform.Rotate(0.0f, 0.0f, mov * -1.0f, Space.Self);
        }
    }
    void Shoot()
    {
        ammo--;
        RaycastHit hit;
        flash.Play();
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range))
        {
            Human e = hit.transform.GetComponent<Human>();
            Debug.Log(e);
            if (e != null)
            {
                e.takeDamage(4f, transform.parent.transform.parent);
            }
        }
        if (ammo < 1)
        {
            prevT = Time.fixedTime;
            reloading = true;
            transform.parent.GetComponent<GunAnim>().reloading = true;
        }
    }
}