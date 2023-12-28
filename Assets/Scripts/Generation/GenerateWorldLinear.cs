using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Networking.PlayerConnection;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

/*
 * Big boi class, it generates the worlds
 */
public class GenerateWorldLinear : MonoBehaviour
{
    [Header ("Prefabs to generate world from")]
    public List<GameObject> prefabs;

    [Header ("How deep we wanna go")]
    public int depth = 0;

    [Header("Generate connecting rooms for starting room only? (debug option)")]
    public bool genDebug = false;


    private int prevInd = -1;

    // Start is called before the first frame update
    void Start()
    {
        
        // Pick random starting prefab
        GameObject startPrefab = Instantiate(prefabs[UnityEngine.Random.Range(0, prefabs.Count)]);

        for(int i = 0; i < depth; i++)
        {
            startPrefab = GenerateRooms(startPrefab);
        }
        
        
    }

    GameObject GenerateRooms(GameObject startPrefab)
    {
        List<Transform> doors = new List<Transform>();

        Transform door = null;


        // Find location of door
        foreach (Transform transform in startPrefab.transform)
        {
            if (transform.tag.Equals("DOOR"))
            {
                door = transform;
            }
        }
         
        

        // Get a random room for each door
        GameObject connectingRoom = Instantiate(prefabs[UnityEngine.Random.Range(0, prefabs.Count)]);
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

        // Set the connecing door to be the parent of the room
        connectingDoor.parent = null;
        connectingRoom.transform.parent = connectingDoor;

        // Rotate the room so its facing the opposite direction of the door
        Debug.Log("Original Rotation for " + connectingDoor.name + " was: " + connectingDoor.transform.rotation.eulerAngles);
        Debug.Log("The door's Rotation for " + door.name + " was: " + door.rotation.eulerAngles);
        Vector3 doorRot = (door.rotation.eulerAngles);
        if (Math.Abs(connectingDoor.transform.rotation.eulerAngles.y - doorRot.y) % 180 != 0)
        {
            doorRot.y -= 180;
        }
        connectingDoor.transform.rotation = Quaternion.Euler(doorRot);
        Debug.Log("New Rotation for " + connectingDoor.name + " is: " + connectingDoor.transform.rotation.eulerAngles);
            
        Debug.Log("======");

        // Move to door position
        connectingDoor.position = door.position;

        return connectingDoor.gameObject;
     
    }

    // Update is called once per frame
    void Update()
    {
        // Nothing much to do here
    }
}
