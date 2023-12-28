using System.Collections;
using System.Collections.Generic;
using UnityEditor.Networking.PlayerConnection;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

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
            // Make sure its not the same as the og
            while(connectingRoom.Equals(startPrefab)) {
                connectingRoom = Instantiate(prefabs[Random.Range(0, prefabs.Count)]);
            }
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

            // First, align the room and the door so they face opposite directions
            

           
            //connectingRoom.transform.rotation *= Quaternion.AngleAxis(180, Vector3.up);

            //connectingRoom.transform.rotation = Quaternion.LookRotation(-door.rotation.eulerAngles);


            // Now the hard part, move the doors onto each other
            connectingDoor.parent = null;
            connectingRoom.transform.parent = connectingDoor;
            //connectingDoor.transform.rotation = door.rotation * Quaternion.AngleAxis(180, Vector3.up);
            Debug.Log("Original Rotation for " + connectingDoor.name + " was: " + connectingDoor.transform.rotation.eulerAngles);
            Vector3 doorRot = (door.rotation.eulerAngles);
            doorRot.y -= 180;

            connectingDoor.transform.rotation = Quaternion.Euler(doorRot);// * Quaternion.Euler(0, 180, 0);
            Debug.Log("New Rotation for " + connectingDoor.name + " is: " + connectingDoor.transform.rotation.eulerAngles);
            Debug.Log("The door's Rotation for " + door.name + " was: " + door.rotation.eulerAngles);
            Debug.Log("======");
            connectingDoor.position = door.position;

        }

        
    }

    // Update is called once per frame
    void Update()
    {
        // Nothing much to do here
    }
}
