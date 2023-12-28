using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public UnityEngine.AI.NavMeshAgent agent;
    public Transform[] covers;
    public Transform[] enemies;

    public Transform player;
    public float range = 20f;

    public float MAXHEALTH = 100;
    public float health = 100;

    public bool isDead;

    public string targetToKill;


    private bool intransit;
    private Transform location;
    private float maxRange;
    // Start is called before the first frame update
    void Start()
    {
        health = MAXHEALTH; // set health

        maxRange = range;

        GameObject[] target = GameObject.FindGameObjectsWithTag("Cover");
        covers = new Transform[target.Length];
        for (int i = 0; i < target.Length; i++)
        {
            covers[i] = target[i].transform;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        health = transform.GetComponent<Human>().health;
        if (health > 0f)
        {

            range = maxRange - ((health / MAXHEALTH) / 20);
            location = player;

            if (Random.Range(0, MAXHEALTH) >= health && !intransit)
            {
                location = getClosestInRange(covers, 100f);
                intransit = true;
            }
            else if (!intransit)
            {
                intransit = true;
                if (Vector3.Distance(this.transform.position, player.position) > range)
                {
                    if (transform.GetComponent<Human>().last)
                    {
                        location = transform.GetComponent<Human>().last;//player;
                        //transform.Find("GUN").transform.GetComponent<EnemyGun>().player = transform.GetComponent<Human>().last;
                        Debug.Log(transform.GetComponent<Human>().last);
                    }
                    else
                    {
                        location = player;
                        transform.Find("GUN").transform.GetComponent<EnemyGun>().player = player;
                    }
                }
                else
                {
                    Debug.Log("Close enough ngl");
                    intransit = false;
                    transform.Find("GUN").transform.GetComponent<EnemyGun>().decideShoot();
                    location = this.transform;
                }
            }
            /*if (!intransit)
            {
                location = player;
            }*/
            if (Vector3.Distance(this.transform.position, location.position) < 10 && intransit)
            {
                Debug.Log("YEAH!");
                intransit = false;
            }
            if(intransit)
                agent.SetDestination(location.position);    
        }
        else
        {
            Die();
        }
    }
    Transform getClosestInRange(Transform[] arr, float range)
    {
        Transform near = arr[0];
        float prevDiff = 0f;
        for (int i = 0; i < arr.Length; i++)
        {

            if (Vector3.Distance(arr[i].position, transform.position) > prevDiff && Vector3.Distance(arr[i].position, transform.position) < range)
            {
                /*if (transform.tag == targetToKill && transform.GetComponent<Human>().health > 0 || transform.tag != targetToKill)
                {
                    near = arr[i];
                    prevDiff = Vector3.Distance(arr[i].position, player.position);
                }*/
                near = arr[i];
                prevDiff = Vector3.Distance(arr[i].position, transform.position);

            }
        }
        return near;
    }

    void Die()
    {
        this.agent.enabled = false;
        transform.GetComponent<Rigidbody>().AddForce(transform.forward * 100);
        transform.Find("GUN").transform.GetComponent<Rigidbody>().isKinematic = false;
        transform.Find("GUN").transform.parent = null;
        transform.GetComponent<Enemy>().enabled = false;
        isDead = true;
    }

    public void DropGun(Vector3 velocity) {
        // TODO: Make do thing
    }

    public bool IsDead() {
        return isDead;
    }
}