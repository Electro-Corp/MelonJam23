using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Experimental.Rendering;
using UnityEngine.XR;

public class LessRandoGen : MonoBehaviour
{

    [Header("Prefabs to generate world from")]
    public List<GameObject> prefabs;


    [Header("Root")]
    public GameObject root;

    [Header("Player")]
    public GameObject player;
    public GameObject cam;
    public GameObject spawnLoc;
    
    // Start is called before the first frame update
    void Start()
    {

        GameObject pSa = Instantiate(player, spawnLoc.transform.position, spawnLoc.transform.rotation);
        pSa.transform.parent = null;
        pSa.GetComponent<PlayerMovement>().playerCam = cam.transform;
        cam.GetComponent<MoveCamera>().player = pSa.transform;
        
        int i = 0;
        foreach (Transform transformBoi in root.transform)
        {
            if (transformBoi.tag.Equals("LocGen"))
            {
                GameObject funny = Instantiate(prefabs[Random.Range(0, prefabs.Count)], transformBoi.position, transformBoi.rotation);
                funny.transform.name = funny.transform.name + i.ToString();
                funny.transform.parent = transformBoi.parent;
                
                //funny.transform.localScale = transform.localScale;
                Destroy(transformBoi.gameObject);
            }
            i++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
