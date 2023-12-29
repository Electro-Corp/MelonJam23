using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class GenerateRoomsAndPaths : MonoBehaviour
{

    [Header("Prefabs for rooms")]
    public List<GameObject> prefabs;

    [Header("Max rooms")]
    public int maxRooms = 50;

    [Header("Min/Max Positions")]
    public float maxXPos = 100;
    public float minXPos = -100;
    public float minZPos = -100;
    public float maxZPos = -100;

    // Start is called before the first frame update
    void Start()
    {
        // Place rooms randomly
        List<GameObject> rooms = new List<GameObject>();
        for(int i = 0; i < maxRooms; i++)
        {
            rooms.Add(Instantiate(prefabs[UnityEngine.Random.Range(0, prefabs.Count)]));
            rooms[i].transform.position = new Vector3(Random.Range(minXPos, maxXPos), 0, Random.Range(minZPos, maxZPos));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
