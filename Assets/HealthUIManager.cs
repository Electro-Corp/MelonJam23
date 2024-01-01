using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUIManager : MonoBehaviour
{

    private GameObject player;
    private Human plH;

    private Slider health;
    // Start is called before the first frame update
    void Start()
    {
        
        health = transform.GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
            plH = player.GetComponent<Human>();
        }
        else
        {
            health.value = plH.health;
        }
    }
}
