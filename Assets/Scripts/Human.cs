using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Human : MonoBehaviour
{

    public float health;
    public Transform last;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void takeDamage(float damage, Transform theGuyWhoDidIt)
    {
        health -= damage;
        if (theGuyWhoDidIt.tag != transform.tag)
            this.last = theGuyWhoDidIt;
    }


}
