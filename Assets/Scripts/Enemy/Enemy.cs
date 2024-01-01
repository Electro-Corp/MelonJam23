using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public UnityEngine.AI.NavMeshAgent agent;
    public Transform[] covers;
    public Transform[] enemies;

    public Transform player = null;
    public float range = 100f;

    public float MAXHEALTH = 100;
    public float health = 100;

    public bool isDead;

    public string targetToKill;


    public bool intransit;
    public Transform location;
    private float maxRange;

    private bool over = false;

    // Start is called before the first frame update
    void Start()
    {
        health = MAXHEALTH; // set health

        maxRange = range;

        

        GameObject[] target = GameObject.FindGameObjectsWithTag("Cover");
        covers = new Transform[target.Length];
        for (int i = 0; i < target.Length; i++)
        {
            if (target[i].transform.parent.name.Equals(transform.parent.name))
                covers[i] = target[i].transform;
            
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        health = transform.GetComponent<Human>().health;
        if (health > 0f)
        {
            // He dont see, so just like walk around
            if (player == null)
            {
                if (!intransit)
                {
                    location = getClosestInRange(covers, 100f);
                    intransit = true;
                }
            }
            else
            {
                range = maxRange - ((health / MAXHEALTH));
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
                            //location = transform.GetComponent<Human>().last;//player;
                            //transform.Find("GUN").transform.GetComponent<EnemyGun>().player = transform.GetComponent<Human>().last;
                            //Debug.Log(transform.GetComponent<Human>().last);
                            location = getClosestInRange(covers, 100f);
                        }
                        else
                        {

                            location = player;
                            transform.Find("GUN").transform.GetComponent<EnemyGun>().player = player;
                            over = true;
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
            }
            /*if (!intransit)
            {
                location = player;
            }*/
            if (Vector3.Distance(this.transform.position, location.position) < 5 && intransit)
            {
                Debug.Log("YEAH!");
                intransit = false;
            }
            if (intransit)
            {
                if (agent.velocity.magnitude < 1 || over) {
                    agent.SetDestination(location.position);
                    over = false;
                }
            }
        }
        else
        {
            Die();
        }
    }
    Transform getClosestInRange(Transform[] arr, float range)
    {

        Transform near = arr[0];
        int i = 0;
        while(near == null)
        {
            near = arr[i++];
        }
        float prevDiff = 0f;
        for (i = 0; i < arr.Length; i++)
        {
            if (arr[i] != null)
            {

                if (Vector3.Distance(arr[i].position, transform.position) > prevDiff && Vector3.Distance(arr[i].position, transform.position) < range && Random.RandomRange(0,2) == 1)
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
        }
        return near;
    }

    public void Die()
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