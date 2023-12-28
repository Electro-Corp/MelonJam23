using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Charm : MonoBehaviour
{
    public string activeKey;
    /*public Image cover;
    public Sprite inActive;
    public Sprite active;*/
    public CharmUse abl;
    public float time;
    float prevT;
    bool use = false;
    void Start()
    {
        abl = (CharmUse)GetComponent(typeof(CharmUse));
    }
    void Update()
    {
        if (use && Time.fixedTime - prevT > time)
        {
            use = false;
            inAct();
            abl.end();
        }
    }

    public void setActive()
    {
        //cover.sprite = active;
        prevT = Time.fixedTime;
        abl.use();
        use = true;
    }
    public void inAct()
    {
        //cover.sprite = inActive;
    }
    public string getActiveKey()
    {
        return activeKey;
    }
}