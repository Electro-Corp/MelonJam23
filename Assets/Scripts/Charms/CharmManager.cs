using System.Collections;
using System.Collections.Generic;
using UnityEditor.Playables;
using UnityEngine;

public class CharmManager : MonoBehaviour
{
    public List<Charm> charms = new List<Charm>();
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < charms.Count; i++)
        {
            if (Input.GetKey(charms[i].getActiveKey()) && !(GlobalVarsAbl.Instance.cutscene))
            {
                charms[i].setActive();
            }
        }
    }
}