using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Big boi class, it generates the worlds
 */
public class GenerateWorld : MonoBehaviour
{
    [Header ("Prefabs to generate world from")]
    public List<GameObject> prefabs;


    // Start is called before the first frame update
    void Start()
    {
        // Pick random starting prefab
        GameObject startPrefab = prefabs[Random.RandomRange(0, prefabs.Count)];

        
    }

    // Update is called once per frame
    void Update()
    {
        // Nothing much to do here
    }
}
