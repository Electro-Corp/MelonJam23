using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunAnim : MonoBehaviour
{
    public GameObject Gun;
    public bool reloading;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!reloading)
        {
            Gun.GetComponent<Animator>().enabled = true;

            if (Input.GetMouseButtonDown(1) && !Input.GetButton("Fire1"))
            {
                Gun.GetComponent<Animator>().Play("Aim");
            }
            if (Input.GetMouseButtonUp(1))
            {
                Gun.GetComponent<Animator>().Play("AimReturn");
            }
        }
        else
        {
            Gun.GetComponent<Animator>().Play("Reload");
        }
    }
}
