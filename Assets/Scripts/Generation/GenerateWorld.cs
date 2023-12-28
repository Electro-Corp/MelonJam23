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
        GameObject startPrefab = Instantiate(prefabs[Random.Range(0, prefabs.Count)]);

        List<Transform> doors = new List<Transform>();

        // Find location of door
        foreach(Transform transform in startPrefab.transform)
        {
            if (transform.tag.Equals("DOOR"))
            {
                doors.Add(transform);
            }
        }
        
        foreach(Transform door in doors)
        {
            // Get a random room for each door
            GameObject connectingRoom = Instantiate(prefabs[Random.Range(0, prefabs.Count)]);
            Transform connectingDoor = null;
            foreach (Transform transform in connectingRoom.transform)
            {
                if (transform.tag.Equals("DOOR"))
                {
                    // Get the first door we find
                    connectingDoor = transform;
                    break;
                }
            }

            // Connect them. Now. 
           
            // First, align them so they face the same direction
            connectingRoom.transform.rotation = door.rotation * Quaternion.AngleAxis(180, Vector3.up);

            // Now the hard part, move the doors onto each other
            connectingDoor.parent = null;
            connectingRoom.transform.parent = connectingDoor;
            connectingDoor.position = door.position;


        }

        
    }

    // Update is called once per frame
    void Update()
    {
        // Nothing much to do here
    }
}
