using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class LessRandoGen : MonoBehaviour
{

    [Header("Prefabs to generate world from")]
    public List<GameObject> prefabs;


    [Header("Root")]
    public GameObject root;

    // Start is called before the first frame update
    void Start()
    {
        foreach (Transform transformBoi in root.transform)
        {
            if (transformBoi.tag.Equals("LocGen"))
            {
                GameObject funny = Instantiate(prefabs[Random.Range(0, prefabs.Count)], transformBoi.position, transformBoi.rotation);
                funny.transform.parent = transformBoi.parent;

                //funny.transform.localScale = transform.localScale;
                Destroy(transformBoi.gameObject);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
