using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
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


    public int depth = 2;

    // Start is called before the first frame update
    void Start()
    {
        
        // Pick random starting prefab
        GameObject startPrefab = Instantiate(prefabs[Random.Range(0, prefabs.Count)]);


        generateWorld(startPrefab, 0);
        
    }
    
    void generateWorld(GameObject startPrefab, int d)
    {
        if(d > depth)
        {
            return ;
        }
        List<Transform> doors = new List<Transform>();

        // Find location of door
        foreach (Transform transform in startPrefab.transform)
        {
            if (transform.tag.Equals("DOOR"))
            {
                doors.Add(transform);
            }
        }

        foreach (Transform door in doors)
        {
            // Get a random room for each door
            GameObject connectingRoom = Instantiate(prefabs[Random.Range(0, prefabs.Count)]);
            connectingRoom.name = "ROOM :" + d.ToString();
            // Make sure its not the same as the og

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
            connectingDoor.gameObject.name = d.ToString();
            door.gameObject.name = "BOUTTA BE CONNECTED TO " + d.ToString();
            //connectingDoor.transform.rotation = door.rotation * Quaternion.AngleAxis(180, Vector3.up);
            Debug.Log("Original Rotation for " + connectingDoor.name + " was: " + connectingDoor.transform.rotation.eulerAngles);
            Debug.Log("The door's Rotation for " + door.name + " was: " + door.rotation.eulerAngles);
            Vector3 doorRot = (door.rotation.eulerAngles);
            doorRot.y -= 180;
            connectingDoor.transform.rotation = Quaternion.Euler(doorRot);
            Debug.Log("New Rotation for " + connectingDoor.name + " is: " + connectingDoor.transform.rotation.eulerAngles);
            Debug.Log("======");
            connectingDoor.position = door.position;

            generateWorld(connectingRoom, d + 1);

        }
    }

    // Update is called once per frame
    void Update()
    {
        // Nothing much to do here
    }
}
