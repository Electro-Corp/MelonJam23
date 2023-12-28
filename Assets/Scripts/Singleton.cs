using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T instance;
    private static object _lock = new object();

    private static bool applicationIsQuitting = false;

    public static T Instance
    {
        get
        {
            if (applicationIsQuitting)
            {
                // wer're exiting, so just dont do nothin
                return null;
            }
            lock(_lock)
            {
                if(instance == null)
                {
                    instance = (T) FindObjectOfType(typeof(T));

                    if(FindObjectsOfType(typeof(T)).Length > 1)
                    {
                        Debug.Log("Singleton: More than 1 singleton open. Damn. (bad) repon scene");
                        return instance;
                    }
                    if(instance == null)
                    {
                        GameObject singleton = new GameObject();
                        instance = singleton.AddComponent<T>();
                        singleton.name = "(singleton) " + typeof(T).ToString();

                        DontDestroyOnLoad(singleton);
                    }
                }
                return instance;
            }
        }

    }

    public void OnDestroy()
    {
        applicationIsQuitting = true;
    }
}
